using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;

namespace FSRandomizer {
	static class main {
		[STAThread]
		static void Main()
		{
			//Try to run myself as administrator
			var wi = WindowsIdentity.GetCurrent();
			var wp = new WindowsPrincipal(wi);
			bool runAsAdmin = wp.IsInRole(WindowsBuiltInRole.Administrator);

			if(!runAsAdmin) {
				var processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase);
				processInfo.UseShellExecute = true;
				processInfo.Verb = "runas";

				try { Process.Start(processInfo); }
				catch { new error("Please run me as an administrator, I need to write stuff in Clone Hero!", "Privileges", true); }
			} else {
				//Start application
				//Only use this while debugging
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new frmMain());
			}
		}
	}
}
