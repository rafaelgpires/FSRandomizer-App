using System.Windows.Forms;

namespace FSRandomizer {
	class error {
		public error(string error, string title, bool die) {
			if(die) {
				MessageBox.Show(error, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			} else {
				MessageBox.Show(error, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}
