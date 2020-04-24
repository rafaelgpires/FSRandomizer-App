using System.Collections.Generic;
using System.Net;

namespace FSRandomizer {
	class readHash {
		private string hash;
		private List<List<string>> songlist = new List<List<string>>(); //[key](diff, name, game)
		private List<List<string>> fslist   = new List<List<string>>(); //[key](diff, name, game, ID, chapter)
        
		public readHash() {
			this.getBreakdown();
		}
		public void getHash(string hash="") {
			//Download Hash
			WebClient client = new WebClient();
			client.Encoding = System.Text.Encoding.UTF8;
			this.hash = client.DownloadString("http://localhost/FSRandomizer/docs/?uniqueID=5ea1db75defc1&output=hash"); //TODO: Remove hardcoding when form is complete
			
			//Build the full series list
			try {
				string[] hashChapters = this.hash.Split('|');
				for (int i = 0; i < hashChapters.Length; ++i) {
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
						song.Add(songID.ToString());
						song.Add((i + 1).ToString());

						//Register the song
						this.fslist.Add(song);
					}
				}
			} catch { new die("Error: Couldn't recognise a valid Full Series list from the link given."); }
		}

		private void getBreakdown() {
			//Download the breakdown file
			WebClient client = new WebClient();
			client.Encoding = System.Text.Encoding.UTF8;
			string breakdownFile = client.DownloadString("http://localhost/FSRandomizer/docs/breakdown.txt"); //TODO: Update on Host

			//Build the song list from the breakdown
			try {
				string[] breakdown = breakdownFile.Split('\n');
				for (int breakdownKey = 0; breakdownKey < breakdown.Length; ++breakdownKey) {
					string[] song = breakdown[breakdownKey].Remove(0, 6).Trim().Split('|');
					songlist.Add(new List<string>());
					for (int songKey = 0; songKey < song.Length; ++songKey) {
					songlist[breakdownKey].Add(song[songKey].Trim());
					}
				}
			} catch { new die("Error: Couldn't retrieve the Master FC Breakdown. Maybe website is down?"); }
		}
    }
}
