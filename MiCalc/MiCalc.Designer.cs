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
			this.ubClose = new MiCalc.Controls.UnfocusedButton();
			this.ubCopy = new MiCalc.Controls.UnfocusedButton();
			this.ubFunctions = new MiCalc.Controls.UnfocusedButton();
			this.ubOnTop = new MiCalc.Controls.UnfocusedButton();
			this.ubMinimize = new MiCalc.Controls.UnfocusedButton();
			this.ubQuestion = new MiCalc.Controls.UnfocusedButton();
			this.ubDegrees = new MiCalc.Controls.UnfocusedButton();
			this.ubPaste = new MiCalc.Controls.UnfocusedButton();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Decimal:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(0, 105);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Science:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(0, 131);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Hex:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(0, 157);
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
			this.tbDecimal.Location = new System.Drawing.Point(50, 74);
			this.tbDecimal.Name = "tbDecimal";
			this.tbDecimal.ReadOnly = true;
			this.tbDecimal.Size = new System.Drawing.Size(336, 23);
			this.tbDecimal.TabIndex = 1;
			// 
			// tbScience
			// 
			this.tbScience.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbScience.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
			this.tbScience.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbScience.Location = new System.Drawing.Point(50, 100);
			this.tbScience.Name = "tbScience";
			this.tbScience.ReadOnly = true;
			this.tbScience.Size = new System.Drawing.Size(336, 23);
			this.tbScience.TabIndex = 2;
			// 
			// tbHex
			// 
			this.tbHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbHex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
			this.tbHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbHex.Location = new System.Drawing.Point(50, 126);
			this.tbHex.Name = "tbHex";
			this.tbHex.ReadOnly = true;
			this.tbHex.Size = new System.Drawing.Size(336, 23);
			this.tbHex.TabIndex = 3;
			// 
			// tbBin
			// 
			this.tbBin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbBin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
			this.tbBin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbBin.Location = new System.Drawing.Point(50, 152);
			this.tbBin.Name = "tbBin";
			this.tbBin.ReadOnly = true;
			this.tbBin.Size = new System.Drawing.Size(336, 23);
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
			this.rtbExpression.Location = new System.Drawing.Point(4, 45);
			this.rtbExpression.Multiline = false;
			this.rtbExpression.Name = "rtbExpression";
			this.rtbExpression.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbExpression.ShortcutsEnabled = false;
			this.rtbExpression.Size = new System.Drawing.Size(382, 23);
			this.rtbExpression.TabIndex = 0;
			this.rtbExpression.Text = "";
			this.rtbExpression.WordWrap = false;
			this.rtbExpression.TextChanged += new System.EventHandler(this.rtbExpression_TextChanged);
			// 
			// ubClose
			// 
			this.ubClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ubClose.ImageKey = "icon-wnd-close.png";
			this.ubClose.Location = new System.Drawing.Point(354, 5);
			this.ubClose.Name = "ubClose";
			this.ubClose.Size = new System.Drawing.Size(32, 32);
			this.ubClose.TabIndex = 6;
			this.ubClose.TabStop = false;
			this.ubClose.UseVisualStyleBackColor = true;
			this.ubClose.Click += new System.EventHandler(this.ubClose_Click);
			// 
			// ubCopy
			// 
			this.ubCopy.ImageKey = "icon-copy.png";
			this.ubCopy.Location = new System.Drawing.Point(50, 5);
			this.ubCopy.Name = "ubCopy";
			this.ubCopy.Size = new System.Drawing.Size(32, 32);
			this.ubCopy.TabIndex = 6;
			this.ubCopy.TabStop = false;
			this.ubCopy.UseVisualStyleBackColor = true;
			this.ubCopy.Click += new System.EventHandler(this.ubCopy_Click);
			// 
			// ubFunctions
			// 
			this.ubFunctions.ImageKey = "icon-functions.png";
			this.ubFunctions.Location = new System.Drawing.Point(140, 5);
			this.ubFunctions.Name = "ubFunctions";
			this.ubFunctions.Size = new System.Drawing.Size(32, 32);
			this.ubFunctions.TabIndex = 6;
			this.ubFunctions.TabStop = false;
			this.ubFunctions.UseVisualStyleBackColor = true;
			this.ubFunctions.Click += new System.EventHandler(this.ubFunctions_Click);
			// 
			// ubOnTop
			// 
			this.ubOnTop.ImageKey = "icon-wnd-normal.png";
			this.ubOnTop.Location = new System.Drawing.Point(4, 5);
			this.ubOnTop.Name = "ubOnTop";
			this.ubOnTop.Size = new System.Drawing.Size(32, 32);
			this.ubOnTop.TabIndex = 6;
			this.ubOnTop.TabStop = false;
			this.ubOnTop.UseVisualStyleBackColor = true;
			this.ubOnTop.Click += new System.EventHandler(this.ubOnTop_Click);
			// 
			// ubMinimize
			// 
			this.ubMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ubMinimize.ImageKey = "icon-wnd-min.png";
			this.ubMinimize.Location = new System.Drawing.Point(316, 5);
			this.ubMinimize.Name = "ubMinimize";
			this.ubMinimize.Size = new System.Drawing.Size(32, 32);
			this.ubMinimize.TabIndex = 6;
			this.ubMinimize.TabStop = false;
			this.ubMinimize.UseVisualStyleBackColor = true;
			this.ubMinimize.Click += new System.EventHandler(this.ubMinimize_Click);
			// 
			// ubQuestion
			// 
			this.ubQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ubQuestion.ImageKey = "_std_ico.ico";
			this.ubQuestion.Location = new System.Drawing.Point(278, 5);
			this.ubQuestion.Name = "ubQuestion";
			this.ubQuestion.Size = new System.Drawing.Size(32, 32);
			this.ubQuestion.TabIndex = 6;
			this.ubQuestion.TabStop = false;
			this.ubQuestion.UseVisualStyleBackColor = true;
			this.ubQuestion.Click += new System.EventHandler(this.ubQuestion_Click);
			// 
			// ubDegrees
			// 
			this.ubDegrees.ImageKey = "icon-degrees.png";
			this.ubDegrees.Location = new System.Drawing.Point(178, 5);
			this.ubDegrees.Name = "ubDegrees";
			this.ubDegrees.Size = new System.Drawing.Size(32, 32);
			this.ubDegrees.TabIndex = 6;
			this.ubDegrees.TabStop = false;
			this.ubDegrees.UseVisualStyleBackColor = true;
			this.ubDegrees.Click += new System.EventHandler(this.ubDegrees_Click);
			// 
			// ubPaste
			// 
			this.ubPaste.ImageKey = "icon-paste.png";
			this.ubPaste.Location = new System.Drawing.Point(88, 5);
			this.ubPaste.Name = "ubPaste";
			this.ubPaste.Size = new System.Drawing.Size(32, 32);
			this.ubPaste.TabIndex = 6;
			this.ubPaste.TabStop = false;
			this.ubPaste.UseVisualStyleBackColor = true;
			this.ubPaste.Click += new System.EventHandler(this.ubPaste_Click);
			// 
			// fMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 180);
			this.Controls.Add(this.ubClose);
			this.Controls.Add(this.ubCopy);
			this.Controls.Add(this.ubFunctions);
			this.Controls.Add(this.ubOnTop);
			this.Controls.Add(this.ubMinimize);
			this.Controls.Add(this.ubQuestion);
			this.Controls.Add(this.ubDegrees);
			this.Controls.Add(this.ubPaste);
			this.Controls.Add(this.rtbExpression);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbBin);
			this.Controls.Add(this.tbHex);
			this.Controls.Add(this.tbScience);
			this.Controls.Add(this.tbDecimal);
			this.Icon = global::MiCalc.Properties.Resources.icon;
			this.Name = "fMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MiCalc";
			this.Load += new System.EventHandler(this.fMain_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fMain_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fMain_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fMain_MouseUp);
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
		private Controls.UnfocusedButton ubPaste;
		private Controls.UnfocusedButton ubClose;
		private Controls.UnfocusedButton ubCopy;
		private Controls.UnfocusedButton ubDegrees;
		private Controls.UnfocusedButton ubQuestion;
		private Controls.UnfocusedButton ubMinimize;
		private Controls.UnfocusedButton ubOnTop;
		private Controls.UnfocusedButton ubFunctions;

	}
}

