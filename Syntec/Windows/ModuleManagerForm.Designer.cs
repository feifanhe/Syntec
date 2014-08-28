namespace Syntec.Windows
{
	partial class ModuleManagerForm
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
			this.PluginList = new System.Windows.Forms.ListView();
			this.NameHeader = new System.Windows.Forms.ColumnHeader();
			this.VersionHeader = new System.Windows.Forms.ColumnHeader();
			this.LocationHeader = new System.Windows.Forms.ColumnHeader();
			this.Browse_Button = new System.Windows.Forms.Button();
			this.OK_Button = new System.Windows.Forms.Button();
			this.Cancel_Button = new System.Windows.Forms.Button();
			this.Description = new System.Windows.Forms.TextBox();
			this.Description_Label = new System.Windows.Forms.Label();
			this.Refresh_Button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// PluginList
			// 
			this.PluginList.CheckBoxes = true;
			this.PluginList.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader,
            this.VersionHeader,
            this.LocationHeader} );
			this.PluginList.FullRowSelect = true;
			this.PluginList.GridLines = true;
			this.PluginList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.PluginList.Location = new System.Drawing.Point( 12, 12 );
			this.PluginList.MultiSelect = false;
			this.PluginList.Name = "PluginList";
			this.PluginList.Size = new System.Drawing.Size( 560, 186 );
			this.PluginList.TabIndex = 0;
			this.PluginList.UseCompatibleStateImageBehavior = false;
			this.PluginList.View = System.Windows.Forms.View.Details;
			// 
			// NameHeader
			// 
			this.NameHeader.Text = "Name";
			this.NameHeader.Width = 180;
			// 
			// VersionHeader
			// 
			this.VersionHeader.Text = "Version";
			this.VersionHeader.Width = 70;
			// 
			// LocationHeader
			// 
			this.LocationHeader.Text = "Location";
			this.LocationHeader.Width = 280;
			// 
			// Browse_Button
			// 
			this.Browse_Button.Location = new System.Drawing.Point( 12, 377 );
			this.Browse_Button.Name = "Browse_Button";
			this.Browse_Button.Size = new System.Drawing.Size( 75, 23 );
			this.Browse_Button.TabIndex = 2;
			this.Browse_Button.Text = "Browse";
			this.Browse_Button.UseVisualStyleBackColor = true;
			this.Browse_Button.Click += new System.EventHandler( this.BrowseButton_Click );
			// 
			// OK_Button
			// 
			this.OK_Button.Location = new System.Drawing.Point( 416, 377 );
			this.OK_Button.Name = "OK_Button";
			this.OK_Button.Size = new System.Drawing.Size( 75, 23 );
			this.OK_Button.TabIndex = 3;
			this.OK_Button.Text = "OK";
			this.OK_Button.UseVisualStyleBackColor = true;
			this.OK_Button.Click += new System.EventHandler( this.OKButton_Click );
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.Location = new System.Drawing.Point( 497, 377 );
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size( 75, 23 );
			this.Cancel_Button.TabIndex = 4;
			this.Cancel_Button.Text = "Cancel";
			this.Cancel_Button.UseVisualStyleBackColor = true;
			this.Cancel_Button.Click += new System.EventHandler( this.CancelButton_Click );
			// 
			// Description
			// 
			this.Description.Location = new System.Drawing.Point( 12, 233 );
			this.Description.Multiline = true;
			this.Description.Name = "Description";
			this.Description.ReadOnly = true;
			this.Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.Description.Size = new System.Drawing.Size( 560, 124 );
			this.Description.TabIndex = 5;
			// 
			// Description_Label
			// 
			this.Description_Label.AutoSize = true;
			this.Description_Label.Location = new System.Drawing.Point( 9, 217 );
			this.Description_Label.Name = "Description_Label";
			this.Description_Label.Size = new System.Drawing.Size( 63, 13 );
			this.Description_Label.TabIndex = 6;
			this.Description_Label.Text = "Description:";
			// 
			// Refresh_Button
			// 
			this.Refresh_Button.Location = new System.Drawing.Point( 93, 377 );
			this.Refresh_Button.Name = "Refresh_Button";
			this.Refresh_Button.Size = new System.Drawing.Size( 75, 23 );
			this.Refresh_Button.TabIndex = 7;
			this.Refresh_Button.Text = "Refresh";
			this.Refresh_Button.UseVisualStyleBackColor = true;
			this.Refresh_Button.Click += new System.EventHandler( this.RefreshButton_Click );
			// 
			// ModuleManagerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 584, 412 );
			this.Controls.Add( this.Refresh_Button );
			this.Controls.Add( this.Description_Label );
			this.Controls.Add( this.Description );
			this.Controls.Add( this.Cancel_Button );
			this.Controls.Add( this.OK_Button );
			this.Controls.Add( this.Browse_Button );
			this.Controls.Add( this.PluginList );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ModuleManagerForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Plugin Manager";
			this.Load += new System.EventHandler( this.PluginManagerForm_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView PluginList;
		private System.Windows.Forms.ColumnHeader NameHeader;
		private System.Windows.Forms.ColumnHeader VersionHeader;
		private System.Windows.Forms.ColumnHeader LocationHeader;
		private System.Windows.Forms.Button Browse_Button;
		private System.Windows.Forms.Button OK_Button;
		private System.Windows.Forms.Button Cancel_Button;
		private System.Windows.Forms.TextBox Description;
		private System.Windows.Forms.Label Description_Label;
		private System.Windows.Forms.Button Refresh_Button;
	}
}