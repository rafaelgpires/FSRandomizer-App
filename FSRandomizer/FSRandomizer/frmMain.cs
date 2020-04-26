using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace FSRandomizer {
	public partial class frmMain : Form
	{
		/* Drag window on MouseDown
		 * URL: https://www.codeproject.com/Articles/11114/Move-window-form-without-Titlebar-in-C
		 */
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();

		/* FSRandomizer Variables */
		editFolder editFolder;
		readHash readHash;

		/* Windows Form */
		public frmMain() { InitializeComponent(); }
		private void frmMain_Load(object sender, EventArgs e) {
			//Prevent it automatically focusing a textbox
			this.ActiveControl = picCHLogo;

			//Initialize FSRandomizer Variables
			this.editFolder = new editFolder();	//GET.: (Online) FSFolder Size
			this.readHash = new readHash();         //GET.: (Online) Breakdown List

			/*
			readHash.getHash("");				//GET.: Full Series List
			editFolder.readCHFolder("");			//GET.: CH's folder path
			editFolder.readFSFolder("");                    //GET.: FSFolder
			editFolder.prepareCHFolder();                   //DO..: Clean CHSongsFolder
			editFolder.unzipFSFolder();                     //DO..: Extract FSFolder
			editFolder.prepareFSFolder();                   //GET.: FSFolder's songs
			editFolder.createChapters(readHash.fslist);     //DO..: Create the chapters
			editFolder.changeSettings();			//DO..: Change CH settings
			*/
		}

		/* Drag/Double-click Form */
		private void frmMain_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				if (e.Clicks == 1) {
					//Drag
					ReleaseCapture();
					SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
				} else {
					//Double click
					this.ActiveControl = picCHLogo; //Remove focus
				}
			}
		}

		/* Close Button (Picture) */
		private void picClose_MouseEnter(object sender, EventArgs e) { picClose.Image = Properties.Resources.Close_Hover; }
		private void picClose_MouseLeave(object sender, EventArgs e) { picClose.Image = Properties.Resources.Close; }
		private void picClose_MouseDown(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { picClose.Image = Properties.Resources.Close_Press; } }
		private void picClose_Click(object sender, EventArgs e) { Application.Exit(); }

		/* Transfer Button */
		private void btnTransferList_EnabledChanged(object sender, EventArgs e) {
			if (btnTransferList.Enabled == true) {
				btnTransferList.Image = Properties.Resources.Transfer_Button;
			} else btnTransferList.Image = Properties.Resources.Transfer_Button_Disabled;
		}
		private void btnTransferList_MouseEnter(object sender, EventArgs e) { btnTransferList.Image = Properties.Resources.Transfer_Button_Hover; }
		private void btnTransferList_MouseLeave(object sender, EventArgs e) { btnTransferList.Image = Properties.Resources.Transfer_Button; }
		private void btnTransferList_MouseDown(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { btnTransferList.Image = Properties.Resources.Transfer_Button_Press; } }

		/* FSList Text-Input */
		private void txtFSList_Enter(object sender, EventArgs e) {
			//Entered focus, if it was on default value, switch to active
			if (txtFSList.Text == "http://www.fsrandomizer.com/5ea458d733d32") {
				txtFSList.Text = "";
				txtFSList.ForeColor = Color.FromArgb(0, 0, 0);
			}
		}
		private void txtFSList_Leave(object sender, EventArgs e) {
			//Left focus, if it's empty, switch back to default value
			if(txtFSList.Text == "") {
				//Load defaults
				txtFSList.ForeColor = Color.FromArgb(153, 153, 153);
				txtFSList.Text = "http://www.fsrandomizer.com/5ea458d733d32";
			} else {
				//Do something with value provided
			}
		}
		private void txtFSList_KeyUp(object sender, KeyEventArgs e) {
			//Tab to next control on enter
			if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return)) {
				this.SelectNextControl((Control)sender, true, true, true, true);
			}
		}
	}
}
