namespace Syntec.Plugin
{
	partial class PluginManagerForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( ) {
			this.listView1 = new System.Windows.Forms.ListView();
			this.NameHeader = new System.Windows.Forms.ColumnHeader();
			this.VersionHeader = new System.Windows.Forms.ColumnHeader();
			this.LocationHeader = new System.Windows.Forms.ColumnHeader();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.Description_Label = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader,
            this.VersionHeader,
            this.LocationHeader} );
			this.listView1.Location = new System.Drawing.Point( 12, 12 );
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size( 560, 186 );
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// NameHeader
			// 
			this.NameHeader.Text = "Name";
			// 
			// VersionHeader
			// 
			this.VersionHeader.Text = "Version";
			// 
			// LocationHeader
			// 
			this.LocationHeader.Text = "Location";
			// 
			// BrowseButton
			// 
			this.BrowseButton.Location = new System.Drawing.Point( 12, 377 );
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size( 75, 23 );
			this.BrowseButton.TabIndex = 2;
			this.BrowseButton.Text = "Browse";
			this.BrowseButton.UseVisualStyleBackColor = true;
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point( 416, 377 );
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size( 75, 23 );
			this.OKButton.TabIndex = 3;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point( 497, 377 );
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size( 75, 23 );
			this.CancelButton.TabIndex = 4;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point( 12, 238 );
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size( 560, 124 );
			this.textBox1.TabIndex = 5;
			// 
			// Description_Label
			// 
			this.Description_Label.AutoSize = true;
			this.Description_Label.Location = new System.Drawing.Point( 9, 222 );
			this.Description_Label.Name = "Description_Label";
			this.Description_Label.Size = new System.Drawing.Size( 63, 13 );
			this.Description_Label.TabIndex = 6;
			this.Description_Label.Text = "Description:";
			// 
			// PluginManagerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 584, 412 );
			this.Controls.Add( this.Description_Label );
			this.Controls.Add( this.textBox1 );
			this.Controls.Add( this.CancelButton );
			this.Controls.Add( this.OKButton );
			this.Controls.Add( this.BrowseButton );
			this.Controls.Add( this.listView1 );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PluginManagerForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Plugin Manager";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader NameHeader;
		private System.Windows.Forms.ColumnHeader VersionHeader;
		private System.Windows.Forms.ColumnHeader LocationHeader;
		private System.Windows.Forms.Button BrowseButton;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label Description_Label;
	}
}