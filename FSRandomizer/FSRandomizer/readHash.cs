using System.Collections.Generic;
using System.Net;

namespace FSRandomizer {
	class readHash {
		public string error;                    //Error string
		public bool gotHash = false;		//Check if getHash has been ran successfully
		public List<List<List<string>>> fslist; //[chapter][key](diff, name, game)
		private List<List<string>> songlist;	//[key](diff, name, game)
        
		public readHash() { this.getBreakdown(); }
		public bool getHash(string hash) {
			//Download Hash
			try {
				WebClient client = new WebClient();
				client.Encoding = System.Text.Encoding.UTF8;
				hash = client.DownloadString(hash + "?output=hash");
			} catch { this.error = "Couldn't download list from your link."; this.gotHash = false; return false; }
			
			//Build the full series list
			this.fslist = new List<List<List<string>>>();
			try {
				string[] hashChapters = hash.Split('|');
				for (int i = 0; i < hashChapters.Length; ++i) {
					//Create chapter and get songs
					List<List<string>> songs = new List<List<string>>();
					for (int x = 0; x < hashChapters[i].Length; x += 4) {
						//Declarations
						List<string> song;
						string prefix;
						int songID;

						//Encore switch
						switch (hashChapters[i][x]) {
							case '1': prefix = "[ENCORE] "; break;
							case '2': prefix = "[SUPER ENCORE] "; break;
							default: prefix = ""; break;
						}

						//Get song info
						int.TryParse(hashChapters[i].Substring((x + 1), 3), out songID);
						song = new List<string>(this.songlist[songID]);
						song[1] = prefix + song[1];

						//Add song to chapter
						songs.Add(song);
					}

					//Add chapter to list
					this.fslist.Add(songs);
				}
			} catch { this.error = "Couldn't recognise a valid Full Series list from the link given."; this.gotHash = false;  return false; }

			//All went well
			this.gotHash = true;
			return true;
		}

		private void getBreakdown() {
			//Download the breakdown file
			WebClient client = new WebClient();
			client.Encoding = System.Text.Encoding.UTF8;
			string breakdownFile = client.DownloadString("https://www.fsrandomizer.psarchives.com/breakdown.txt");

			//Build the song list from the breakdown
			this.songlist = new List<List<string>>();
			try {
				string[] breakdown = breakdownFile.Split('\n');
				for (int breakdownKey = 0; breakdownKey < breakdown.Length; ++breakdownKey) {
					string[] song = breakdown[breakdownKey].Remove(0, 6).Trim().Split('|');
					this.songlist.Add(new List<string>());
					for (int songKey = 0; songKey < song.Length; ++songKey)
						this.songlist[breakdownKey].Add(song[songKey].Trim());
				}
			} catch { new error("Couldn't retrieve the Master FC Breakdown. Maybe website is down?", "Fatal Error", true); return; }
		}
    }
}
