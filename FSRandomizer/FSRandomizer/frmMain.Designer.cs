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
			this.btnTransferList = new System.Windows.Forms.Button();
			this.picCHLogo = new System.Windows.Forms.PictureBox();
			this.picClose = new System.Windows.Forms.PictureBox();
			this.picTitleBar = new System.Windows.Forms.PictureBox();
			this.picLabelFSList = new System.Windows.Forms.PictureBox();
			this.pnlFSList = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.picCHLogo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picTitleBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picLabelFSList)).BeginInit();
			this.pnlFSList.SuspendLayout();
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
			this.txtFSList.TabIndex = 4;
			this.txtFSList.Text = "http://www.fsrandomizer.com/5ea458d733d32";
			this.txtFSList.Enter += new System.EventHandler(this.txtFSList_Enter);
			this.txtFSList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFSList_KeyUp);
			this.txtFSList.Leave += new System.EventHandler(this.txtFSList_Leave);
			// 
			// btnTransferList
			// 
			this.btnTransferList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnTransferList.Enabled = false;
			this.btnTransferList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
			this.btnTransferList.FlatAppearance.BorderSize = 0;
			this.btnTransferList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
			this.btnTransferList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
			this.btnTransferList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTransferList.Image = global::FSRandomizer.Properties.Resources.Transfer_Button_Disabled;
			this.btnTransferList.Location = new System.Drawing.Point(85, 463);
			this.btnTransferList.Name = "btnTransferList";
			this.btnTransferList.Size = new System.Drawing.Size(131, 43);
			this.btnTransferList.TabIndex = 3;
			this.btnTransferList.EnabledChanged += new System.EventHandler(this.btnTransferList_EnabledChanged);
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
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
			this.ClientSize = new System.Drawing.Size(300, 573);
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
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
			((System.ComponentModel.ISupportInitialize)(this.picCHLogo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picTitleBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picLabelFSList)).EndInit();
			this.pnlFSList.ResumeLayout(false);
			this.pnlFSList.PerformLayout();
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
	}
}

