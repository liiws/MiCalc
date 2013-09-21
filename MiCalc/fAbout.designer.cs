namespace MiCalc.Forms
{
    partial class fAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAbout));
			this.btnOK = new System.Windows.Forms.Button();
			this.lbTitleVersion = new System.Windows.Forms.Label();
			this.lbCopyright = new System.Windows.Forms.Label();
			this.tbLicense = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(177, 410);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(45, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lbTitleVersion
			// 
			this.lbTitleVersion.AutoSize = true;
			this.lbTitleVersion.Location = new System.Drawing.Point(12, 9);
			this.lbTitleVersion.Name = "lbTitleVersion";
			this.lbTitleVersion.Size = new System.Drawing.Size(69, 13);
			this.lbTitleVersion.TabIndex = 1;
			this.lbTitleVersion.Text = "title && version";
			// 
			// lbCopyright
			// 
			this.lbCopyright.AutoSize = true;
			this.lbCopyright.Location = new System.Drawing.Point(12, 31);
			this.lbCopyright.Name = "lbCopyright";
			this.lbCopyright.Size = new System.Drawing.Size(50, 13);
			this.lbCopyright.TabIndex = 2;
			this.lbCopyright.Text = "copyright";
			// 
			// tbLicense
			// 
			this.tbLicense.BackColor = System.Drawing.SystemColors.Control;
			this.tbLicense.Location = new System.Drawing.Point(15, 56);
			this.tbLicense.Multiline = true;
			this.tbLicense.Name = "tbLicense";
			this.tbLicense.Size = new System.Drawing.Size(372, 348);
			this.tbLicense.TabIndex = 4;
			// 
			// AboutBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(399, 437);
			this.Controls.Add(this.tbLicense);
			this.Controls.Add(this.lbCopyright);
			this.Controls.Add(this.lbTitleVersion);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox";
			this.Padding = new System.Windows.Forms.Padding(9);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About...";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbTitleVersion;
		private System.Windows.Forms.Label lbCopyright;
		private System.Windows.Forms.TextBox tbLicense;

    }
}
