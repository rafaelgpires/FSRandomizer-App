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

		/* Main Form */
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
		private void btnTransferList_Enter(object sender, EventArgs e) { btnTransferList.Image = Properties.Resources.Transfer_Button_Hover; }
		private void btnTransferList_Leave(object sender, EventArgs e) { btnTransferList.Image = Properties.Resources.Transfer_Button; }
		private void btnTransferList_MouseEnter(object sender, EventArgs e) { btnTransferList.Image = Properties.Resources.Transfer_Button_Hover; }
		private void btnTransferList_MouseLeave(object sender, EventArgs e) { btnTransferList.Image = Properties.Resources.Transfer_Button; }
		private void btnTransferList_MouseDown(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { btnTransferList.Image = Properties.Resources.Transfer_Button_Press; } }
		private void btnTransferList_Click(object sender, EventArgs e) {
			//Check if we have the required inputs
			//TODO: Check the other 3 inputs
			if(!this.readHash.gotHash) {
				new error("You haven't given a valid Full Series list.", "Full Series List", false);
				txtFSList.Focus();
			} else {
				MessageBox.Show("Success");
			}

			//TODO: stuff
			//Remember to disable controller while doing stuff and re-enabling when it's done or on error
		}

		/* FSList Input */
		public string txtFSList_Default = "http://www.fsrandomizer.com/5ea458d733d32";
		public void txtFSList_Parse(string input) {
			if (string.IsNullOrEmpty(input)) {
				//Set hash to false to prevent execution with previous value
				this.readHash.gotHash = false;
			} else {
				//Read new hash
				if (!this.readHash.getHash(input)) {
					new error(this.readHash.error, "Full Series List", false);
					txtFSList.SelectionStart = txtFSList.Text.Length; //Put caret at the end
					txtFSList.Focus();
					return;
				}
			}
		}

		/* CHFolder Input */
		public string txtCHFolder_Default = @"D:\Games\Clone Hero\";
		public void txtCHFolder_Parse(string input) {
			if (String.IsNullOrEmpty(input)) {
				//Set having CHFolder to false
			} else {
				//Value was set, do something
			}
		}

		/* TextBox Event Handlers */
		private void txtKeyDown(object sender, KeyEventArgs e) {
			//Tab to next control on enter
			if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return)) {
				e.SuppressKeyPress = true;
				this.SelectNextControl((Control)sender, true, true, true, true);
			}
		}
		private void txtEnterFocus(object sender, EventArgs e) {
			//Get info
			TextBox textbox = (TextBox)sender;
			string defaultText = (string)this.GetType().GetField(textbox.Name + "_Default").GetValue(this);

			//If it contains default text, empty it before user writes
			if (textbox.Text == defaultText) {
				textbox.Text = "";
				textbox.ForeColor = Color.FromArgb(75, 75, 75);
			}
		}
		private void txtLeaveFocus(object sender, EventArgs e) {
			//Get info
			TextBox textbox = (TextBox)sender;
			string input = textbox.Text;
			string defaultText = (string)this.GetType().GetField(textbox.Name + "_Default").GetValue(this);

			//If it's empty, switch back to default value
			if (textbox.Text == "") {
				textbox.ForeColor = Color.FromArgb(150, 150, 150);
				textbox.Text = defaultText;
			}

			//Scroll contents left
			textbox.SelectionStart = 0;
			textbox.ScrollToCaret();

			//Call Parser
			this.GetType().GetMethod(textbox.Name + "_Parse").Invoke(this, new object[]{ input });
		}
	}
}
