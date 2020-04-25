using System;
using System.Windows.Forms;

namespace FSRandomizer {
	static class main {
		[STAThread]
		static void Main()
		{
			editFolder editFolder = new editFolder();       //GET.: (Online) FSFolder Size
			readHash readHash = new readHash();             //GET.: (Online) Breakdown List
			
			readHash.getHash("");				//GET.: Full Series List
			editFolder.readCHFolder("");			//GET.: CH's folder path
			editFolder.readFSFolder("");                    //GET.: FSFolder
			editFolder.prepareCHFolder();                   //DO..: Clean CHSongsFolder
			editFolder.unzipFSFolder();                     //DO..: Extract FSFolder
			editFolder.prepareFSFolder();                   //GET.: FSFolder's songs
			editFolder.createChapters(readHash.fslist);     //DO..: Create the chapters
			editFolder.changeSettings();			//DO..: Change CH settings

			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new frmMain());
		}
	}
}
