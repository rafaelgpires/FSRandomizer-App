using System.Net;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System;

namespace FSRandomizer {
	class editFolder {
		/* Declarations */
		private List<List<List<string>>> songlist;	//List of songs gotten from the folder when done
		private string RealFSSize;			//Intended FSFolder size as given by the Website
		private string CHSongsFolderLoc;		//Confirmed location of CH's /songs/
		private string SettingsFile;			//Confirmed location of CH's settings.ini
		private bool unzipping = false;			//Check if we're still unzipping
		private bool unzipped = false;			//Confirmed unzipping of FSFolder
		private bool listsongs = false;                 //Confirmed this.songlist is ready for processing
		private int progState;				//Current progress bar state
		public string FSFolderLoc;			//Confirmed location of Standardized FS folder
		public string CHFolderLoc;			//Confirmed location of CH installation
		public string error;                            //Error message to send when returning false
		public bool FolderPrepared;                     //Confirmed successful run of prepareCHFolder()
		ProgressBar progress;                           //UI Element
		Label lblProg;                                  //UI Element
		Label lblETA;					//UI Element

		/* Public Methods */
		public editFolder (ref ProgressBar progress, ref Label lblProg, ref Label lblETA) {
			//Get the FSList expected size
			this.getRealFSSize();

			//Store references to UI Elements
			this.progress = progress;
			this.lblProg = lblProg;
			this.lblETA = lblETA;
		}
		public bool readCHFolder(string CHFolderLoc) {
			//Check validity by finding...
			try {
				//...Settings File
				string SettingsFile = CHFolderLoc + "\\settings.ini";
				if (File.Exists(SettingsFile)) this.SettingsFile = SettingsFile;
				else { this.error = "Unrecognised CH Folder.\nCouldn't find a settings file."; this.CHFolderLoc = ""; return false; }

				//...Clone Hero.exe
				if (!File.Exists((CHFolderLoc + "\\Clone Hero.exe"))) { this.error = "Unrecognised CH Folder.\nCouldn't find the executable."; this.CHFolderLoc = ""; return false; }

				//.../songs folder
				string CHSongsFolderLoc = CHFolderLoc + "\\songs";
				if (Directory.Exists(CHSongsFolderLoc)) this.CHSongsFolderLoc = CHSongsFolderLoc;
				else { this.error = "Unrecognised CH Folder.\nCouldn't find the songs folder."; this.CHFolderLoc = ""; return false; }
			} catch { this.error = "Couldn't read directory. Try running as administrator?"; this.CHFolderLoc = ""; return false; }

			//It's valid, store it
			this.CHFolderLoc = CHFolderLoc;
			return true;
		}
		public bool readFSFolder(string FSFolderLoc) {
			//Check if it exists
			if (!File.Exists(FSFolderLoc)) { this.error = "Couldn't access the Full Series zipped file."; this.FSFolderLoc = ""; return false; }

			//Check validity by comparing file size
			if (new FileInfo(FSFolderLoc).Length.ToString() != this.RealFSSize) { this.error = "Invalid Charts file...\nRemember to use the up-to-date file from our website!"; this.FSFolderLoc = ""; return false; }

			//File is valid, store it
			this.FSFolderLoc = FSFolderLoc;
			return true;
		}
		public async Task<bool> transferList(readHash readHash) {
			this.ProgressChange("Preparing CH Folder...", 15, 0);	if (!(await Task.Run(() => this.prepareCHFolder()))) return false;
			this.ProgressChange("Unzipping folder...", 14, 5);	if (!(await this.unzipFSFolder())) return false;
			this.ProgressChange("Preparing FS Folder...", 1, 95);	if (!(await Task.Run(() => this.prepareFSFolder()))) return false;
			this.ProgressChange("Creating chapters...", 1, 96);	if (!(await Task.Run(() => this.createChapters(readHash.fslist)))) return false;
			this.ProgressChange("Changing settings...", 0, 99);	if (!(await Task.Run(() => this.changeSettings()))) return false;
			this.ProgressChange("Done!", -1, 100); return true;
		}

		/* Private Methods (Transfer List) */
		private bool prepareCHFolder(int i = 1) {
			//Check if readCHFolder has already been ran successfully
			if (string.IsNullOrEmpty(this.CHSongsFolderLoc)) { new error("Internal error.\nClone Hero Songs folder location unexpectedly unknown.\n\nPlease fix.", "Fatal Error", true); this.FolderPrepared = false; return false; }

			//Check if the directory has anything on it
			string UserCHSongsFolderLoc;
			if (Directory.EnumerateFileSystemEntries(this.CHSongsFolderLoc).Any()) {
				//Create a folder to store user's previous content
				UserCHSongsFolderLoc = Path.GetDirectoryName(this.CHSongsFolderLoc) + "\\songs_backup" + (i > 1 ? i.ToString() : "");
				if(Directory.Exists(UserCHSongsFolderLoc)) {
					i++; //Recursively more backups
					if (i > 100) { this.error = "Reached limit creating backup folders. Please clear your Clone Hero folder..."; this.FolderPrepared = false; return false; }
					return prepareCHFolder(i);
				}
				try { Directory.CreateDirectory(UserCHSongsFolderLoc); }
				catch { this.error = "Couldn't create directory songs_backup to store your songs in.\nTry running as administrator or deleting any existing songs_bakcup directory."; this.FolderPrepared = false; return false; }
				
				//Loop through the content of the user's directory and put it all in the created folder
				try {
					//Take care of files
					foreach (string fileName in Directory.GetFiles(this.CHSongsFolderLoc))
						File.Move(fileName, UserCHSongsFolderLoc + "\\" + Path.GetFileName(fileName));

					//Take care of directories
					foreach (string dir in Directory.GetDirectories(this.CHSongsFolderLoc))
						Directory.Move(dir, UserCHSongsFolderLoc + "\\" + Path.GetFileName(dir));
				} catch { this.error = "Couldn't move your stuff to the new directory.\nTry running as administrator or empty out your songs folder for now."; this.FolderPrepared = false; return false; }
			}

			//Either all went well or nothing needs to be done
			this.FolderPrepared = true;
			return true;
		}
		private async Task<bool> unzipFSFolder() {
			//Check if readFSFolder has already been ran successfully
			if(string.IsNullOrEmpty(this.FSFolderLoc)) { new error("Internal error.\nFull Series file location unexpectedly unknown.\n\nPlease fix.", "Fatal Error", true); return false; }

			//Check if CHFolder has been prepared
			if(!this.FolderPrepared) { new error("Internal error.\nI moved on without preparing Clone Hero's folder?\n\nPlease fix.", "Fatal Error", true); return false; }

			//Start unzipping asynchronously
			this.unzipping = true;
			Task _ = Task.Run(() => ZipFile.ExtractToDirectory(this.FSFolderLoc, this.CHSongsFolderLoc));
			
			//Track progress
			while(this.unzipping) {
				await Task.Delay(2500); //Check every 2.5s
				List<int> output = new List<int>();

				int s = 0;
				foreach (string Game in Directory.GetDirectories(CHSongsFolderLoc))
					foreach (string Song in Directory.GetDirectories(Game))
						s++;

				if(s > 0) {
					//Some flavour progress
					int prog = (int)Math.Ceiling((double)(s / 660m * 100));
					int mins = 14 - ((int)Math.Ceiling((double)(prog / 8m)));
					prog = (int)Math.Round((prog * 0.90) + 5);
					this.ProgressChange("Unzipping folder...", mins, prog);

					//Check if we can leave
					if (s >= 660) this.unzipping = false;
				}
			}

			//All went well
			this.unzipped = true;
			return true;
		}
		private bool prepareFSFolder() {
			//Check if it's been unzipped before working with it
			if(this.unzipped != true) { new error("Internal error.\nExpected file to be unzipped.\n\nPlease fix.", "Fatal Error", true); return false; }

			//Start going through the extracted directories and build the array of games with songs
			try {
				this.songlist = new List<List<List<string>>>();
				foreach (string Game in Directory.GetDirectories(this.CHSongsFolderLoc)) {
					this.songlist.Add(new List<List<string>>());
					foreach (string Song in Directory.GetDirectories(Game)) {
						List<string> songInfo = new List<string>();
						songInfo.Add(Song);
						songInfo.Add(Regex.Replace(Song, "^.+\\\\.+? - ", ""));
						this.songlist[(songlist.Count - 1)].Add(songInfo);
					}
				}
			} catch { this.error = "Failed preparing my own Full Series folder. What the heck?\nTry running as administrator."; return false; }

			//List is ready for processing
			// 0 => Guitar Hero - Aerosmith
			// 1 => Guitar Hero - Metallica
			// 2 => Guitar Hero - Smash Hits
			// 3 => Guitar Hero - Van Halen
			// 4 => Guitar Hero - Warriors of Rock
			// 5 => Guitar Hero 5
			// 6 => Guitar Hero Encore Rock The 80s
			// 7 => Guitar Hero I
			// 8 => Guitar Hero II
			// 9 => Guitar Hero III
			// 10 => Guitar Hero World Tour
			this.listsongs = true;
			return true;
		}
		private bool createChapters(List<List<List<string>>> fslist) {
			//Check that songlist is ready to be processed
			if(this.listsongs != true) { new error("Internal error.\nAttempted to create chapters before being ready.\n\nPlease fix.", "Fatal Error", true); return false; }

			//Loop through the full series list
			int SongNum = 1;
			for (int Chapter = 0; Chapter < fslist.Count; ++Chapter) {
				//Create chapter folder, zero-pad chapter to keep alphabetical order correct
				string padChapter    = (Chapter + 1).ToString().PadLeft(2, '0');
				string ChapterFolder = this.CHSongsFolderLoc + "\\Chapter " + padChapter;
				try { Directory.CreateDirectory(ChapterFolder); }
				catch { this.error = "Couldn't create chapter folder.\nTry running as admin, I'll have to unzip again..."; return false; }

				//Loop through chapter songs
				int chapterSong = 0;
				foreach(List<string> song in fslist[Chapter]) {
					//Zero-pad song number to keep alphabetical order correct
					string padSongNum = SongNum.ToString().PadLeft(3, '0');
					
					//Remove encore prefixes from song names but add them in the new dir
					string encore = "";
					string encorePattern = "(\\[ENCORE\\] )|(\\[SUPER ENCORE\\] )";
					Match Match = Regex.Match(song[1], encorePattern);
					if(Match.Success) {
						encore = Match.Value;
						song[1] = Regex.Replace(song[1], encorePattern, "");
					}

					//Find them in the FSFolder list (songlist)
					bool found = false;
					int GameKey = convertGame2Key(song[2]);
					if (GameKey == -1) { new error("Internal error.\nError converting game names.\n\nPlease fix.", "Fatal Error", true); return false; }
					foreach (List<string> songName in this.songlist[GameKey]) {
						if (song[1].ToLower() == songName[1].ToLower()) {
							//Found the song in a local folder
							found = true;
							chapterSong++;

							//Change ini and move to chapter folder
							string newName = "[" + padSongNum + "] " + encore + song[1];
							string iniName = (encore == "[ENCORE] " ? "(Encore) " : "(Super Encore) ") + song[1];
							if (!this.changeSongIni(songName[0], iniName, chapterSong, song[0])) return false;
							try { Directory.Move(songName[0], ChapterFolder + "\\" + newName); }
							catch { this.error = "Couldn't move song to chapter folder.\nTry running as admin, I'll have to unzip again..."; return false; }
						}
					}

					//If we can't find it, throw an error
					if (found != true) { this.error = "Couldn't find song '" + song[1] + "' from '" + song[2] + "' in the folder.\nIf you didn't mess with it during execution, contact the developer."; return false; }
					SongNum++; //Otherwise, keep counting
				}
			}

			//When done, remove old folders
			foreach(List<List<string>> Game in this.songlist) {
				string GameName = Path.GetDirectoryName(Game[0][0]);
				try { Directory.Delete(GameName); }
				catch { new error("Couldn't delete leftover folders...\nGood news is: I was almost done anyway!\n\nPlease change the following setting manually:\n    - [Gameplay] Default Sorting: Change to \"Playlist\"\n\nRemember to Scan Songs!", "Fatally Good Error", true); return false; }
			}

			//All went well
			return true;
		}
		private bool changeSettings() {
			string[] Settings;
			try {
				//Read settings file
				List<string> newSettings = new List<string>();
				Settings = File.ReadAllLines(SettingsFile);

				//Look for sort_filter
				bool foundSetting = false;
				foreach (string line in Settings) {
					Match Match = Regex.Match(line, "^([a-z0-9_]+) ?= ?(.+)$");
					if (Match.Success) {
						string configName = Match.Groups[1].Value;
						if (configName.Trim() == "sort_filter") {
							foundSetting = true;
							newSettings.Add("sort_filter = 8");
						} else newSettings.Add(line);
					} else newSettings.Add(line);
				}

				//If by chance we didn't find it, append it to the end of the file
				if (!foundSetting) newSettings.Add("sort_filter = 8");

				//Write the new config file
				string newSettingsFile = string.Join("\n", newSettings);
				File.WriteAllText(SettingsFile, newSettingsFile);
			} catch { new error("Couldn't change your Clone Hero settings.\nGood news is: I was almost done anyway!\n\nPlease change the following setting manually:\n    - [Gameplay] Default Sorting: Change to \"Playlist\"\n\nRemember to Scan Songs!", "Fatally Good Error", true); return false; }

			//All went well
			return true;
		}

		/* Private Methods (Other) */
		private void getRealFSSize() {
			//Download RealFSSize
			WebClient client = new WebClient();
			client.Encoding = System.Text.Encoding.UTF8;
			try { this.RealFSSize = client.DownloadString("http://localhost/FSRandomizer/docs/RealFSSize.txt"); } //TODO: Update on host
			catch { new error("Couldn't retrieve file verification online to confirm there's no problems with your folder. Maybe website is down?", "Fatal Error", true); return; }
		}
		private bool changeSongIni(string songPath, string songName, int playlistTrack, string difficulty) {
			string songIniPath = songPath + "\\song.ini";
			string[] songIni;

			try {
				//Read through the current ini file and start writing our version
				List<string> newFile = new List<string>();
				songIni = File.ReadAllLines(songIniPath);
				foreach(string line in songIni) {
					Match Match = Regex.Match(line, "^([a-z0-9_]+) ?= ?(.+)$");
					if(Match.Success) {
						string configName = Match.Groups[1].Value;
						switch(configName) {
							//Find the settings we're gonna change, don't add them
							case "name": break;
							case "diff_guitar": break;
							case "playlist_track": break;
							default:
								//Remove other difficulties
								if(configName.Length > 5)
									if (configName.Substring(0, 5) == "diff_")
										break;

								//Otherwise, add the config as normal
								newFile.Add(line);
								break;
						}
					} else { newFile.Add(line); }
				}

				//Append our settings to the end of the file
				newFile.Add("name = " + songName);
				newFile.Add("diff_guitar = " + difficulty);
				newFile.Add("playlist_track = " + playlistTrack);

				//Write the new config file
				string configFile = string.Join("\n", newFile);
				File.WriteAllText(songIniPath, configFile);
			}
			catch { this.error = "Couldn't change '" + "'s song.ini at '" + songPath + "'. Try running as administrator?"; return false; }

			//All went well
			return true;
		}
		private int convertGame2Key(string Game) {
			switch (Game) {
				case "Guitar Hero: A":		return 0;
				case "Guitar Hero: M":		return 1;
				case "Guitar Hero: SH":		return 2;
				case "Guitar Hero: VH":		return 3;
				case "Guitar Hero 6":		return 4;
				case "Guitar Hero 5":		return 5;
				case "Guitar Hero: 80s":	return 6;
				case "Guitar Hero 1":		return 7;
				case "Guitar Hero 2":		return 8;
				case "Guitar Hero 3":		return 9;
				case "Guitar Hero: WT":		return 10;
				default: return -1;
			}
		}
		private void ProgressChange(string text, int eta, int prog) {
			//Change progress bar colors depending on progress
			if(prog < 33 && this.progState != 2) { this.progress.SetState(2); this.progState = 2; }
			if(prog > 33 && prog < 66 && this.progState != 3) { this.progress.SetState(3); this.progState = 3; }
			if(prog > 66 && this.progState != 1) { this.progress.SetState(1); this.progState = 1; }

			//Update labels and progress
			this.lblETA.Text = (eta == -1) ? "" : (eta + " minutes");
			this.lblProg.Text = text;
			this.progress.Value = prog;
		}
	}
}
