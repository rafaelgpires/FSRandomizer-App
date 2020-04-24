using System;
using System.Windows.Forms;

namespace FSRandomizer {
	static class main {
		[STAThread]
		static void Main()
		{
			readHash readHash = new readHash();
			readHash.getHash();

			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new frmMain());
		}
	}
}
