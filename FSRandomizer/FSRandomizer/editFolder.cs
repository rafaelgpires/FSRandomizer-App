using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace FSRandomizer {
	class editFolder {
		private string md5sum;
		private string CHFolderLoc;
		private string CHSongsFolderLoc;
		private string SettingsFile;

		public editFolder () {
			this.getMD5();
			this.readCHFolder("");
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

			//Check if the directory has anything on it
			if (Directory.EnumerateFileSystemEntries(this.CHSongsFolderLoc).Any()) {
				//Create a folder to store user's previous content
				string UserCHSongsFolderLoc = this.CHSongsFolderLoc + "\\[Customs]";
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
			}

			//Everything worked out, store directory
			this.CHFolderLoc = CHFolderLoc;
		}
		public void readFSFolder(string FSFolderLoc) {

		}

		private void getMD5() {
			//Download MD5 Sum
			WebClient client = new WebClient();
			client.Encoding = System.Text.Encoding.UTF8;
			string md5sum = client.DownloadString("http://localhost/FSRandomizer/docs/md5sum.txt"); //TODO: Update on host

			//Check if it's a valid MD5 Hash
			if(!Regex.IsMatch(md5sum, "^[0-9a-fA-F]{32}$", RegexOptions.Compiled)) {
				new die("Couldn't retrieve file verification online to confirm there's no problems with your folder. Maybe website is down?");
			} else { this.md5sum = md5sum; }
		}
	}
}
