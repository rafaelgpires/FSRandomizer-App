using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Linq;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace FSRandomizer {
	class editFolder {
		private List<List<List<string>>> songlist;	//List of songs gotten from the folder when done
		private string RealFSSize;			//Intended FSFolder size as given by the Website
		private string CHFolderLoc;			//Confirmed location of CH installation
		private string FSFolderLoc;			//Confirmed location of Standardized FS folder
		private string CHSongsFolderLoc;		//Confirmed location of CH's /songs/
		private string SettingsFile;			//Confirmed location of CH's settings.ini
		private string UserCHSongsFolderLoc;		//Confirmed location of CH's /songs/[Customs]
		private bool unzipped = false;			//Confirmed unzipping of FSFolder
		private bool listsongs = false;			//Confirmed this.songlist is ready for processing

		public editFolder () {
			this.getRealFSSize();
		}
		public void readCHFolder(string CHFolderLoc) {
			CHFolderLoc = "D:\\Games\\Clone Hero"; //TODO: Remove hardcoding on Design

			//Check validity by finding...
			//...Settings File
			string SettingsFile = CHFolderLoc + "\\settings.ini";
			if (File.Exists(SettingsFile)) this.SettingsFile = SettingsFile;
			else { new die("Invalid Clone Hero folder, you sure you got the right location?\nCouldn't find a settings file."); }

			//...Clone Hero.exe
			if(!File.Exists((CHFolderLoc + "\\Clone Hero.exe"))) { new die("Invalid Clone Hero folder, you sure you got the right location?\nCouldn't find the executable."); }

			//.../songs folder
			string CHSongsFolderLoc = CHFolderLoc + "\\songs";
			if (Directory.Exists(CHSongsFolderLoc)) this.CHSongsFolderLoc = CHSongsFolderLoc;
			else { new die("Invalid Clone Hero folder, you sure you got the right location?\nCouldn't find the songs folder."); }

			//It's valid, store it
			this.CHFolderLoc = CHFolderLoc;
		}
		public void readFSFolder(string FSFolderLoc) {
			FSFolderLoc = "D:\\Backups\\Game Files\\Clone Hero\\Songs\\Original Series.zip"; //TODO: Remove hardcoding on Design

			//Check if it exists
			if (!File.Exists(FSFolderLoc)) new die("Couldn't access the Full Series zipped file.");

			//Check validity by comparing file size
			if(new FileInfo(FSFolderLoc).Length.ToString() != this.RealFSSize) new die("Given file isn't identical to the file I expected.");

			//File is valid, store it
			this.FSFolderLoc = FSFolderLoc;
		}
		public void prepareCHFolder() {
			//Check if readCHFolder has already been ran successfully
			if (string.IsNullOrEmpty(this.CHSongsFolderLoc)) { new die("Clone Hero folder not selected yet."); }

			//Check if the directory has anything on it
			string UserCHSongsFolderLoc;
			if (Directory.EnumerateFileSystemEntries(this.CHSongsFolderLoc).Any()) {
				//Create a folder to store user's previous content
				UserCHSongsFolderLoc = this.CHSongsFolderLoc + "\\[Customs]";
				try { Directory.CreateDirectory(UserCHSongsFolderLoc); } catch { new die("Couldn't create a directory [Customs] to store your songs in.\nTry running this app as administrator or deleting any existing [Customs] directory."); return; }

				//Loop through the content of the user's directory and put it all in the created folder
				try {
					//Take care of files
					foreach (string fileName in Directory.GetFiles(this.CHSongsFolderLoc)) {
						File.Move(fileName, UserCHSongsFolderLoc + "\\" + Path.GetFileName(fileName));
					}

					//Take care of directories
					foreach (string dir in Directory.GetDirectories(this.CHSongsFolderLoc)) {
						if (dir == UserCHSongsFolderLoc) continue; //Skip our own folder
						Directory.Move(dir, UserCHSongsFolderLoc + "\\" + Path.GetFileName(dir));
					}
				} catch (System.Exception e) { new die("Couldn't move your stuff to the new directory.\nTry running this app as administrator or empty out your songs folder for now." + e.ToString()); }
			} else UserCHSongsFolderLoc = "-";

			//All went well, store created folder
			this.UserCHSongsFolderLoc = UserCHSongsFolderLoc;
		}
		public void unzipFSFolder() {
			//Check if readFSFolder has already been ran successfully
			if(string.IsNullOrEmpty(this.FSFolderLoc)) { new die("Full Series zipped folder not selected yet."); }

			//Check if CHFolder has been prepared
			if(string.IsNullOrEmpty(this.UserCHSongsFolderLoc)) { new die("Customs song folder hasn't been prepared for my unzipping yet."); }

			//Unzip
			//try { ZipFile.ExtractToDirectory(this.FSFolderLoc, this.CHSongsFolderLoc); } catch { new die("Failed to unzip. Try running as administrator?"); } //TODO: Add progress bar in Design, this is gonna take a while

			this.unzipped = true;
		}
		public void prepareFSFolder() {
			//Check if it's been unzipped before working with it
			if(this.unzipped != true) { new die("Full Series folder hasn't been unzipped yet."); }

			//Start going through the extracted directories and build the array of games with songs
			//TODO: This array could be hardcoded so this step isn't necessary, since the file is always the same
			this.songlist = new List<List<List<string>>>();
			foreach (string Game in Directory.GetDirectories(this.CHSongsFolderLoc)) {
				if(Game == this.UserCHSongsFolderLoc) { continue; } //Skip their customs folder
				this.songlist.Add(new List<List<string>>());
				foreach (string Song in Directory.GetDirectories(Game)) {
					List<string> songInfo = new List<string>();
					songInfo.Add(Song);
					songInfo.Add(Regex.Replace(Song, "^.+\\\\.+? - ", ""));
					this.songlist[(songlist.Count - 1)].Add(songInfo);
				}
			}

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
		}
		public void createChapters(List<List<List<string>>> fslist) {
			//TODO: Edit song.ini while we have the directory...

			//Check that songlist is ready to be processed
			if(this.listsongs != true) { new die("Attempted to create chapters before being ready."); }

			//Loop through the full series list
			int SongNum = 0;
			for (int Chapter = 0; Chapter < fslist.Count; ++Chapter) {
				//Create chapter folder, zero-pad chapter to keep alphabetical order correct
				string padChapter    = (Chapter + 1).ToString().PadLeft(2, '0');
				string ChapterFolder = this.CHSongsFolderLoc + "\\Chapter " + padChapter;
				try { Directory.CreateDirectory(ChapterFolder); }
				catch { new die("Couldn't create chapter folder. Try running as admin?"); }

				//Loop through chapter songs
				foreach(List<string> song in fslist[Chapter]) {
					//Zero-pad song number to keep alphabetical order correct
					string padSongNum = SongNum.ToString().PadLeft(3, '0');

					if(SongNum >= 339) { continue; } //DEBUG

					
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
					foreach (List<string> songName in this.songlist[this.convertGame2Key(song[2])]) {
						if (song[1].ToLower() == songName[1].ToLower()) {
							found = true;

							//Move to chapter folder
							string newName = "[" + padSongNum + "] " + encore + song[1];
							try { Directory.Move(songName[0], ChapterFolder + "\\" + newName); }
							catch { new die("Couldn't move song to chapter folder. Try running as administrator?"); }
						}
					}

					//If we can't find it, throw an error
					if (found != true) new die("Couldn't find song '" + song[1] + "' from '" + song[2] + "' in the folder.\nAdd it manually and try again or contact the developer.");
					SongNum++; //Otherwise, keep counting
				}
			}

			//When done, remove old folders
			foreach(List<List<string>> Game in this.songlist) {
				string GameName = Path.GetDirectoryName(Game[0][0]);
				try { Directory.Delete(GameName); }
				catch { new die("Couldn't delete leftover folders."); }
			}
		}

		private void getRealFSSize() {
			//Download RealFSSize
			WebClient client = new WebClient();
			client.Encoding = System.Text.Encoding.UTF8;
			try { this.RealFSSize = client.DownloadString("http://localhost/FSRandomizer/docs/RealFSSize.txt"); } //TODO: Update on host
			catch { new die("Couldn't retrieve file verification online to confirm there's no problems with your folder. Maybe website is down?"); }
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
				default:
					new die("Error converting game names.");
					return 0;
			}
		}
		private string convertKey2Folder(int Key) {
			switch (Key) {
				case 0: return "Guitar Hero - Aerosmith";
				case 1: return "Guitar Hero - Metallica";
				case 2: return "Guitar Hero - Smash Hits";
				case 3: return "Guitar Hero - Van Halen";
				case 4: return "Guitar Hero - Warriors of Rock";
				case 5: return "Guitar Hero 5";
				case 6: return "Guitar Hero Encore Rock The 80s";
				case 7: return "Guitar Hero I";
				case 8: return "Guitar Hero II";
				case 9: return "Guitar Hero III";
				case 10: return "Guitar Hero World Tour";
				default:
					new die("Error converting game names.");
					return "";
			}
		}
	}
}
