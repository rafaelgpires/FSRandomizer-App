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
			this.btnTransferList = new System.Windows.Forms.Button();
			this.picCHLogo = new System.Windows.Forms.PictureBox();
			this.picClose = new System.Windows.Forms.PictureBox();
			this.picTitleBar = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picCHLogo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picTitleBar)).BeginInit();
			this.SuspendLayout();
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
			this.btnTransferList.Image = global::FSRandomizer.Properties.Resources.Transfer_Button_Press;
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
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
			this.ClientSize = new System.Drawing.Size(300, 573);
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
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.PictureBox picTitleBar;
		private System.Windows.Forms.PictureBox picClose;
		private System.Windows.Forms.PictureBox picCHLogo;
		private System.Windows.Forms.Button btnTransferList;
	}
}

