namespace MiCalc
{
	partial class fFunctions
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Operators", System.Windows.Forms.HorizontalAlignment.Center);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Constants", System.Windows.Forms.HorizontalAlignment.Center);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Functions", System.Windows.Forms.HorizontalAlignment.Center);
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "( )",
            "Grouping"}, -1);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "+ -",
            "Unary plus and minus"}, -1);
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "!",
            "Factorial"}, -1);
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "^",
            "Power"}, -1);
			System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "~",
            "Bitwise NOT (64 bit)"}, -1);
			System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "&",
            "Bitwise & (64 bit)"}, -1);
			System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            ":",
            "Bitwise XOR (64 bit)"}, -1);
			System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "|",
            "Bitwise OR (64 bit)"}, -1);
			System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "%",
            "Integer remainder"}, -1);
			System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "* /",
            "Multiplication, division"}, -1);
			System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "+ -",
            "Adding, substracting"}, -1);
			System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            ">> <<",
            "Bitwise right and left shift (64 bit)"}, -1);
			System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] {
            "pi",
            "Pi number"}, -1);
			System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new string[] {
            "e",
            "E number"}, -1);
			System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new string[] {
            "floor, ceil, round",
            "Rounding down, up, nearest"}, -1);
			System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem(new string[] {
            "sin, cos, tan",
            "Sine, cosine, tangent"}, -1);
			System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem(new string[] {
            "sinh, cosh, tanh",
            "Hyperbolic sine, cosine, tangent"}, -1);
			System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem(new string[] {
            "asin, acos, atan",
            "Inverse of sine, cosine, tangent"}, -1);
			System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem(new string[] {
            "asinh, acosh, atanh",
            "Inverse of hyperbolic sine, cosine, tangent"}, -1);
			System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem(new string[] {
            "ln",
            "Natural lorarithm"}, -1);
			System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem(new string[] {
            "lg",
            "Logarithm to base 10"}, -1);
			System.Windows.Forms.ListViewItem listViewItem22 = new System.Windows.Forms.ListViewItem(new string[] {
            "exp",
            "Exponent "}, -1);
			System.Windows.Forms.ListViewItem listViewItem23 = new System.Windows.Forms.ListViewItem(new string[] {
            "sqrt",
            "Square root"}, -1);
			this.btnOK = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(205, 561);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(45, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			listViewGroup1.Header = "Operators";
			listViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			listViewGroup1.Name = "lvgOperators";
			listViewGroup2.Header = "Constants";
			listViewGroup2.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			listViewGroup2.Name = "lvgConstants";
			listViewGroup3.Header = "Functions";
			listViewGroup3.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			listViewGroup3.Name = "lvgFunctions";
			listViewGroup3.Tag = "";
			this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			listViewItem1.Group = listViewGroup1;
			listViewItem2.Group = listViewGroup1;
			listViewItem3.Group = listViewGroup1;
			listViewItem4.Group = listViewGroup1;
			listViewItem5.Group = listViewGroup1;
			listViewItem6.Group = listViewGroup1;
			listViewItem7.Group = listViewGroup1;
			listViewItem8.Group = listViewGroup1;
			listViewItem9.Group = listViewGroup1;
			listViewItem10.Group = listViewGroup1;
			listViewItem11.Group = listViewGroup1;
			listViewItem12.Group = listViewGroup1;
			listViewItem13.Group = listViewGroup2;
			listViewItem14.Group = listViewGroup2;
			listViewItem15.Group = listViewGroup3;
			listViewItem16.Group = listViewGroup3;
			listViewItem17.Group = listViewGroup3;
			listViewItem18.Group = listViewGroup3;
			listViewItem19.Group = listViewGroup3;
			listViewItem20.Group = listViewGroup3;
			listViewItem21.Group = listViewGroup3;
			listViewItem22.Group = listViewGroup3;
			listViewItem23.Group = listViewGroup3;
			this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20,
            listViewItem21,
            listViewItem22,
            listViewItem23});
			this.listView1.Location = new System.Drawing.Point(12, 25);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(434, 530);
			this.listView1.TabIndex = 2;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(237, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Functions and operators list in precedence order:";
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Function/Operator";
			this.columnHeader1.Width = 105;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Description";
			this.columnHeader2.Width = 270;
			// 
			// fFunctions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(458, 590);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "fFunctions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Functions and Operators";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
	}
}