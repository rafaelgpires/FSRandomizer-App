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
	public partial class frmMain : Form {
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
			this.ActiveControl = null;

			//Initialize FSRandomizer Variables
			this.editFolder = new editFolder();	//GET.: (Online) FSFolder Size
			this.readHash = new readHash();         //GET.: (Online) Breakdown List
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
					this.ActiveControl = null; //Remove focus
					
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
			/* Check if we have the required inputs */
			//Check hash
			if(!this.readHash.gotHash) {
				new error("You haven't given a valid Full Series list URL.", "Full Series List", false);
				txtFSList.Focus();
				return;
			}
			//Check CH Folder
			if(string.IsNullOrEmpty(editFolder.CHFolderLoc)) {
				new error("You haven't given a valid Clone Hero folder location.", "Clone Hero Folder", false);
				txtCHFolder.Focus();
				return;	
			}
			//TODO: Check the last input
			if(string.IsNullOrEmpty(editFolder.FSFolderLoc)) {
				new error("You haven't given a valid Full Series Charts file.", "Full Series Charts", false);
				txtFSCharts.Focus();
				return;
			}

			/* Attempt Executing */
			//Disable controllers first, this might take a while
			btnTransferList.Enabled = false;
			txtFSList.Enabled = false;
			txtCHFolder.Enabled = false;
			txtFSCharts.Enabled = false;

			//Execute Transfer List
			if(!editFolder.transferList()) new error(editFolder.error, "Transfer List", false);
			else {
				MessageBox.Show("Full Series Randomizer has transferred your list to Clone Hero.\n\nRemember to Scan Songs!\nROCK ON!!", "Full List Randomized", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Application.Exit();
			}

			//Re-enable controllers
			btnTransferList.Enabled = true;
			txtFSList.Enabled = true;
			txtCHFolder.Enabled = true;
			txtFSCharts.Enabled = true;
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
				}
			}
		}

		/* CHFolder Input */
		public string txtCHFolder_Default = @"D:\Games\Clone Hero\";
		private void txtCHFolder_Click(object sender, EventArgs e) {
			//Show FolderBrowserDialog on click
			FolderBrowserDialog folderPicker = new FolderBrowserDialog();
			folderPicker.Description = "Select your Clone Hero installation folder.";
			folderPicker.ShowNewFolderButton = false;
			DialogResult result = folderPicker.ShowDialog();
			if(result == DialogResult.OK) {
				TextBox textbox = (TextBox)sender;
				textbox.Text = folderPicker.SelectedPath;
				textbox.SelectionStart = textbox.Text.Length; //Put caret at the end
			}
		}
		public void txtCHFolder_Parse(string input) {
			if (String.IsNullOrEmpty(input)) {
				//Set CHFolder to empty to prevent execution with previous value
				this.editFolder.CHFolderLoc = "";
			} else {
				//Read CH Folder
				if(!editFolder.readCHFolder(input)) {
					new error(this.editFolder.error, "Clone Hero Folder", false);
					txtCHFolder.SelectionStart = txtCHFolder.Text.Length;
					txtCHFolder.Focus();
				}
			}
		}

		/* FSCharts Input */
		public string txtFSCharts_Default = @"D:\Downloads\Original Series.zip";
		private void txtFSCharts_Click(object sender, EventArgs e) {
			//Show FileBrowserDialog on click
			OpenFileDialog filePicker = new OpenFileDialog();
			filePicker.Filter = "Zip file (*.zip)|*.zip";
			DialogResult result = filePicker.ShowDialog();
			if(result == DialogResult.OK) {
				TextBox textbox = (TextBox)sender;
				textbox.Text = filePicker.FileName;
				textbox.SelectionStart = textbox.Text.Length; //Put caret at the end
			}
		}
		public void txtFSCharts_Parse(string input) {
			if (string.IsNullOrEmpty(input)) {
				//Set FSCharts to false to prevent execution with previous value
				this.editFolder.FSFolderLoc = "";
			} else {
				//Read FSCharts file
				if(!editFolder.readFSFolder(input)) {
					new error(this.editFolder.error, "Full Series Charts", false);
					txtFSCharts.SelectionStart = txtFSCharts.Text.Length;
					txtFSCharts.Focus();
				}
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
