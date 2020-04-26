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
			this.picTitleBar = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picTitleBar)).BeginInit();
			this.SuspendLayout();
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
			this.Controls.Add(this.picTitleBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Clone Hero - Full Series Randomizer";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
			((System.ComponentModel.ISupportInitialize)(this.picTitleBar)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.PictureBox picTitleBar;
	}
}

