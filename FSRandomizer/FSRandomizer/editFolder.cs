using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Linq;
using System.IO.Compression;

namespace FSRandomizer {
	class editFolder {
		private List<List<string>> songlist = new List<List<string>>(); //List of songs gotten from the folder when done
		private string RealFSSize;					//Intended FSFolder size as given by the Website
		private string CHFolderLoc;					//Confirmed location of CH installation
		private string FSFolderLoc;					//Confirmed location of Standardized FS folder
		private string CHSongsFolderLoc;				//Confirmed location of CH's /songs/
		private string SettingsFile;					//Confirmed location of CH's settings.ini
		private string UserCHSongsFolderLoc;				//Confirmed location of CH's /songs/[Customs]
		private bool unzipped = false;                                  //Confirmed unzipping of FSFolder
		private bool listsongs = false;					//Confirmed this.songlist is ready for processing

		public editFolder () {
			this.getRealFSSize();

			//Debug
			this.readCHFolder("");
			this.readFSFolder("");

			//this.prepareCHFolder(); Debugging
			this.UserCHSongsFolderLoc = "D:\\Games\\Clone Hero\\songs\\[Customs]"; //To place values the above function would've placed

			this.unzipFSFolder();
			this.prepareFSFolder();
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
		public void prepareCHFolder() {
			//Check if readCHFolder has already been ran successfully
			if(string.IsNullOrEmpty(this.CHSongsFolderLoc)) { new die("Clone Hero folder not selected yet."); }

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
		public void readFSFolder(string FSFolderLoc) {
			FSFolderLoc = "D:\\Backups\\Game Files\\Clone Hero\\Songs\\Original Series + DLC (Standardized Directories).zip"; //TODO: Remove hardcoding on Design

			//Check if it exists
			if (!File.Exists(FSFolderLoc)) new die("Couldn't access the Full Series zipped file.");

			//Check validity by comparing file size
			if(new FileInfo(FSFolderLoc).Length.ToString() != this.RealFSSize) new die("Given file isn't identical to the file I expected.");

			//File is valid, store it
			this.FSFolderLoc = FSFolderLoc;
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
			foreach (string Game in Directory.GetDirectories(this.CHSongsFolderLoc)) {
				if(Game == this.UserCHSongsFolderLoc) { continue; } //Skip their customs folder
				songlist.Add(new List<string>());
				foreach (string Song in Directory.GetDirectories(Game))
					songlist[(songlist.Count - 1)].Add(Song);
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

		private void getRealFSSize() {
			//Download RealFSSize
			WebClient client = new WebClient();
			client.Encoding = System.Text.Encoding.UTF8;
			try { this.RealFSSize = client.DownloadString("http://localhost/FSRandomizer/docs/RealFSSize.txt"); } //TODO: Update on host
			catch { new die("Couldn't retrieve file verification online to confirm there's no problems with your folder. Maybe website is down?"); }
		}
	}
}
