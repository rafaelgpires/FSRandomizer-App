namespace FSRandomizer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.txtFSList = new System.Windows.Forms.TextBox();
			this.pnlFSList = new System.Windows.Forms.Panel();
			this.pnlCHFolder = new System.Windows.Forms.Panel();
			this.txtCHFolder = new System.Windows.Forms.TextBox();
			this.picLabelCHFolder = new System.Windows.Forms.PictureBox();
			this.picLabelFSList = new System.Windows.Forms.PictureBox();
			this.btnTransferList = new System.Windows.Forms.Button();
			this.picCHLogo = new System.Windows.Forms.PictureBox();
			this.picClose = new System.Windows.Forms.PictureBox();
			this.picTitleBar = new System.Windows.Forms.PictureBox();
			this.picLabelFSCharts = new System.Windows.Forms.PictureBox();
			this.pnlFSCharts = new System.Windows.Forms.Panel();
			this.txtFSCharts = new System.Windows.Forms.TextBox();
			this.progTransfer = new System.Windows.Forms.ProgressBar();
			this.lblETA = new System.Windows.Forms.Label();
			this.lblProg = new System.Windows.Forms.Label();
			this.pnlFSList.SuspendLayout();
			this.pnlCHFolder.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picLabelCHFolder)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picLabelFSList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picCHLogo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picTitleBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picLabelFSCharts)).BeginInit();
			this.pnlFSCharts.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtFSList
			// 
			this.txtFSList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtFSList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFSList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
			this.txtFSList.Location = new System.Drawing.Point(5, 5);
			this.txtFSList.Name = "txtFSList";
			this.txtFSList.Size = new System.Drawing.Size(270, 18);
			this.txtFSList.TabIndex = 0;
			this.txtFSList.Text = "http://www.fsrandomizer.com/5ea458d733d32";
			this.txtFSList.Enter += new System.EventHandler(this.txtEnterFocus);
			this.txtFSList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyDown);
			this.txtFSList.Leave += new System.EventHandler(this.txtLeaveFocus);
			// 
			// pnlFSList
			// 
			this.pnlFSList.BackColor = System.Drawing.Color.White;
			this.pnlFSList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlFSList.Controls.Add(this.txtFSList);
			this.pnlFSList.Location = new System.Drawing.Point(10, 230);
			this.pnlFSList.Name = "pnlFSList";
			this.pnlFSList.Size = new System.Drawing.Size(280, 32);
			this.pnlFSList.TabIndex = 6;
			// 
			// pnlCHFolder
			// 
			this.pnlCHFolder.BackColor = System.Drawing.Color.White;
			this.pnlCHFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlCHFolder.Controls.Add(this.txtCHFolder);
			this.pnlCHFolder.Location = new System.Drawing.Point(10, 310);
			this.pnlCHFolder.Name = "pnlCHFolder";
			this.pnlCHFolder.Size = new System.Drawing.Size(280, 32);
			this.pnlCHFolder.TabIndex = 8;
			// 
			// txtCHFolder
			// 
			this.txtCHFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtCHFolder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCHFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
			this.txtCHFolder.Location = new System.Drawing.Point(5, 5);
			this.txtCHFolder.Name = "txtCHFolder";
			this.txtCHFolder.Size = new System.Drawing.Size(270, 18);
			this.txtCHFolder.TabIndex = 1;
			this.txtCHFolder.Text = "D:\\Games\\Clone Hero\\";
			this.txtCHFolder.Click += new System.EventHandler(this.txtCHFolder_Click);
			this.txtCHFolder.Enter += new System.EventHandler(this.txtEnterFocus);
			this.txtCHFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyDown);
			this.txtCHFolder.Leave += new System.EventHandler(this.txtLeaveFocus);
			// 
			// picLabelCHFolder
			// 
			this.picLabelCHFolder.Image = global::FSRandomizer.Properties.Resources.Label_Clone_Hero_Folder;
			this.picLabelCHFolder.Location = new System.Drawing.Point(10, 285);
			this.picLabelCHFolder.Name = "picLabelCHFolder";
			this.picLabelCHFolder.Size = new System.Drawing.Size(107, 17);
			this.picLabelCHFolder.TabIndex = 7;
			this.picLabelCHFolder.TabStop = false;
			// 
			// picLabelFSList
			// 
			this.picLabelFSList.Image = global::FSRandomizer.Properties.Resources.Label_Full_Series_List;
			this.picLabelFSList.Location = new System.Drawing.Point(10, 206);
			this.picLabelFSList.Name = "picLabelFSList";
			this.picLabelFSList.Size = new System.Drawing.Size(83, 17);
			this.picLabelFSList.TabIndex = 5;
			this.picLabelFSList.TabStop = false;
			// 
			// btnTransferList
			// 
			this.btnTransferList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnTransferList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
			this.btnTransferList.FlatAppearance.BorderSize = 0;
			this.btnTransferList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
			this.btnTransferList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
			this.btnTransferList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTransferList.Image = global::FSRandomizer.Properties.Resources.Transfer_Button;
			this.btnTransferList.Location = new System.Drawing.Point(85, 463);
			this.btnTransferList.Name = "btnTransferList";
			this.btnTransferList.Size = new System.Drawing.Size(131, 43);
			this.btnTransferList.TabIndex = 3;
			this.btnTransferList.EnabledChanged += new System.EventHandler(this.btnTransferList_EnabledChanged);
			this.btnTransferList.Click += new System.EventHandler(this.btnTransferList_Click);
			this.btnTransferList.Enter += new System.EventHandler(this.btnTransferList_Enter);
			this.btnTransferList.Leave += new System.EventHandler(this.btnTransferList_Leave);
			this.btnTransferList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTransferList_MouseDown);
			this.btnTransferList.MouseEnter += new System.EventHandler(this.btnTransferList_MouseEnter);
			this.btnTransferList.MouseLeave += new System.EventHandler(this.btnTransferList_MouseLeave);
			// 
			// picCHLogo
			// 
			this.picCHLogo.Image = global::FSRandomizer.Properties.Resources.CHLogo;
			this.picCHLogo.Location = new System.Drawing.Point(46, 47);
			this.picCHLogo.Name = "picCHLogo";
			this.picCHLogo.Size = new System.Drawing.Size(207, 137);
			this.picCHLogo.TabIndex = 2;
			this.picCHLogo.TabStop = false;
			// 
			// picClose
			// 
			this.picClose.BackColor = System.Drawing.Color.Transparent;
			this.picClose.BackgroundImage = global::FSRandomizer.Properties.Resources.TitleBackground;
			this.picClose.Image = global::FSRandomizer.Properties.Resources.Close;
			this.picClose.Location = new System.Drawing.Point(260, 0);
			this.picClose.Name = "picClose";
			this.picClose.Size = new System.Drawing.Size(40, 32);
			this.picClose.TabIndex = 1;
			this.picClose.TabStop = false;
			this.picClose.Click += new System.EventHandler(this.picClose_Click);
			this.picClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picClose_MouseDown);
			this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
			this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
			// 
			// picTitleBar
			// 
			this.picTitleBar.Image = global::FSRandomizer.Properties.Resources.TitleBar;
			this.picTitleBar.Location = new System.Drawing.Point(0, 0);
			this.picTitleBar.Name = "picTitleBar";
			this.picTitleBar.Size = new System.Drawing.Size(300, 32);
			this.picTitleBar.TabIndex = 0;
			this.picTitleBar.TabStop = false;
			this.picTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
			// 
			// picLabelFSCharts
			// 
			this.picLabelFSCharts.Image = global::FSRandomizer.Properties.Resources.Label_Full_Series_Charts;
			this.picLabelFSCharts.Location = new System.Drawing.Point(10, 364);
			this.picLabelFSCharts.Name = "picLabelFSCharts";
			this.picLabelFSCharts.Size = new System.Drawing.Size(100, 17);
			this.picLabelFSCharts.TabIndex = 9;
			this.picLabelFSCharts.TabStop = false;
			// 
			// pnlFSCharts
			// 
			this.pnlFSCharts.BackColor = System.Drawing.Color.White;
			this.pnlFSCharts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlFSCharts.Controls.Add(this.txtFSCharts);
			this.pnlFSCharts.Location = new System.Drawing.Point(10, 388);
			this.pnlFSCharts.Name = "pnlFSCharts";
			this.pnlFSCharts.Size = new System.Drawing.Size(280, 32);
			this.pnlFSCharts.TabIndex = 9;
			// 
			// txtFSCharts
			// 
			this.txtFSCharts.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtFSCharts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFSCharts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
			this.txtFSCharts.Location = new System.Drawing.Point(5, 5);
			this.txtFSCharts.Name = "txtFSCharts";
			this.txtFSCharts.Size = new System.Drawing.Size(270, 18);
			this.txtFSCharts.TabIndex = 2;
			this.txtFSCharts.Text = "D:\\Downloads\\Original Series.zip";
			this.txtFSCharts.Click += new System.EventHandler(this.txtFSCharts_Click);
			this.txtFSCharts.Enter += new System.EventHandler(this.txtEnterFocus);
			this.txtFSCharts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyDown);
			this.txtFSCharts.Leave += new System.EventHandler(this.txtLeaveFocus);
			// 
			// progTransfer
			// 
			this.progTransfer.Location = new System.Drawing.Point(50, 523);
			this.progTransfer.Name = "progTransfer";
			this.progTransfer.Size = new System.Drawing.Size(200, 4);
			this.progTransfer.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progTransfer.TabIndex = 10;
			this.progTransfer.Visible = false;
			// 
			// lblETA
			// 
			this.lblETA.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblETA.ForeColor = System.Drawing.Color.Red;
			this.lblETA.Location = new System.Drawing.Point(85, 447);
			this.lblETA.Name = "lblETA";
			this.lblETA.Size = new System.Drawing.Size(131, 13);
			this.lblETA.TabIndex = 11;
			this.lblETA.Text = "15 minutes";
			this.lblETA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblETA.Visible = false;
			// 
			// lblProg
			// 
			this.lblProg.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProg.Location = new System.Drawing.Point(85, 537);
			this.lblProg.Name = "lblProg";
			this.lblProg.Size = new System.Drawing.Size(131, 13);
			this.lblProg.TabIndex = 12;
			this.lblProg.Text = "Parsing Input...";
			this.lblProg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblProg.Visible = false;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
			this.ClientSize = new System.Drawing.Size(300, 573);
			this.Controls.Add(this.lblProg);
			this.Controls.Add(this.lblETA);
			this.Controls.Add(this.progTransfer);
			this.Controls.Add(this.pnlFSCharts);
			this.Controls.Add(this.picLabelFSCharts);
			this.Controls.Add(this.pnlCHFolder);
			this.Controls.Add(this.picLabelCHFolder);
			this.Controls.Add(this.pnlFSList);
			this.Controls.Add(this.picLabelFSList);
			this.Controls.Add(this.btnTransferList);
			this.Controls.Add(this.picCHLogo);
			this.Controls.Add(this.picClose);
			this.Controls.Add(this.picTitleBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Clone Hero - Full Series Randomizer";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
			this.pnlFSList.ResumeLayout(false);
			this.pnlFSList.PerformLayout();
			this.pnlCHFolder.ResumeLayout(false);
			this.pnlCHFolder.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picLabelCHFolder)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picLabelFSList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picCHLogo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picTitleBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picLabelFSCharts)).EndInit();
			this.pnlFSCharts.ResumeLayout(false);
			this.pnlFSCharts.PerformLayout();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.PictureBox picTitleBar;
		private System.Windows.Forms.PictureBox picClose;
		private System.Windows.Forms.PictureBox picCHLogo;
		private System.Windows.Forms.Button btnTransferList;
		private System.Windows.Forms.TextBox txtFSList;
		private System.Windows.Forms.PictureBox picLabelFSList;
		private System.Windows.Forms.Panel pnlFSList;
		private System.Windows.Forms.PictureBox picLabelCHFolder;
		private System.Windows.Forms.Panel pnlCHFolder;
		private System.Windows.Forms.TextBox txtCHFolder;
		private System.Windows.Forms.PictureBox picLabelFSCharts;
		private System.Windows.Forms.Panel pnlFSCharts;
		private System.Windows.Forms.TextBox txtFSCharts;
		private System.Windows.Forms.ProgressBar progTransfer;
		private System.Windows.Forms.Label lblETA;
		private System.Windows.Forms.Label lblProg;
	}
}

