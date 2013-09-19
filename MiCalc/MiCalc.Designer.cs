namespace MiCalc
{
	partial class fMain
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbDecimal = new System.Windows.Forms.TextBox();
			this.tbScience = new System.Windows.Forms.TextBox();
			this.tbHex = new System.Windows.Forms.TextBox();
			this.tbBin = new System.Windows.Forms.TextBox();
			this.rtbExpression = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Decimal:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Science:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 93);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Hex:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 119);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(25, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Bin:";
			// 
			// tbDecimal
			// 
			this.tbDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbDecimal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
			this.tbDecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbDecimal.Location = new System.Drawing.Point(63, 38);
			this.tbDecimal.Name = "tbDecimal";
			this.tbDecimal.ReadOnly = true;
			this.tbDecimal.Size = new System.Drawing.Size(627, 23);
			this.tbDecimal.TabIndex = 1;
			// 
			// tbScience
			// 
			this.tbScience.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbScience.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
			this.tbScience.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbScience.Location = new System.Drawing.Point(63, 64);
			this.tbScience.Name = "tbScience";
			this.tbScience.ReadOnly = true;
			this.tbScience.Size = new System.Drawing.Size(627, 23);
			this.tbScience.TabIndex = 2;
			// 
			// tbHex
			// 
			this.tbHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbHex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
			this.tbHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbHex.Location = new System.Drawing.Point(63, 90);
			this.tbHex.Name = "tbHex";
			this.tbHex.ReadOnly = true;
			this.tbHex.Size = new System.Drawing.Size(627, 23);
			this.tbHex.TabIndex = 3;
			// 
			// tbBin
			// 
			this.tbBin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbBin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
			this.tbBin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbBin.Location = new System.Drawing.Point(63, 116);
			this.tbBin.Name = "tbBin";
			this.tbBin.ReadOnly = true;
			this.tbBin.Size = new System.Drawing.Size(627, 23);
			this.tbBin.TabIndex = 4;
			// 
			// rtbExpression
			// 
			this.rtbExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbExpression.CausesValidation = false;
			this.rtbExpression.DetectUrls = false;
			this.rtbExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.rtbExpression.HideSelection = false;
			this.rtbExpression.Location = new System.Drawing.Point(12, 9);
			this.rtbExpression.Multiline = false;
			this.rtbExpression.Name = "rtbExpression";
			this.rtbExpression.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbExpression.ShortcutsEnabled = false;
			this.rtbExpression.Size = new System.Drawing.Size(678, 23);
			this.rtbExpression.TabIndex = 0;
			this.rtbExpression.Text = "";
			this.rtbExpression.WordWrap = false;
			this.rtbExpression.TextChanged += new System.EventHandler(this.rtbExpression_TextChanged);
			// 
			// fMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(702, 146);
			this.Controls.Add(this.rtbExpression);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbBin);
			this.Controls.Add(this.tbHex);
			this.Controls.Add(this.tbScience);
			this.Controls.Add(this.tbDecimal);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::MiCalc.Properties.Resources.icon;
			this.Name = "fMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MiCalc";
			this.Load += new System.EventHandler(this.fMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbDecimal;
		private System.Windows.Forms.TextBox tbScience;
		private System.Windows.Forms.TextBox tbHex;
		private System.Windows.Forms.TextBox tbBin;
		private System.Windows.Forms.RichTextBox rtbExpression;

	}
}

