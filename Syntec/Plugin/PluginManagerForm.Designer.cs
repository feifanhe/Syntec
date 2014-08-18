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
			this.PluginList = new System.Windows.Forms.ListView();
			this.NameHeader = new System.Windows.Forms.ColumnHeader();
			this.VersionHeader = new System.Windows.Forms.ColumnHeader();
			this.LocationHeader = new System.Windows.Forms.ColumnHeader();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.Description = new System.Windows.Forms.TextBox();
			this.Description_Label = new System.Windows.Forms.Label();
			this.RefreshButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// PluginList
			// 
			this.PluginList.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader,
            this.VersionHeader,
            this.LocationHeader} );
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
			// BrowseButton
			// 
			this.BrowseButton.Location = new System.Drawing.Point( 12, 377 );
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size( 75, 23 );
			this.BrowseButton.TabIndex = 2;
			this.BrowseButton.Text = "Browse";
			this.BrowseButton.UseVisualStyleBackColor = true;
			this.BrowseButton.Click += new System.EventHandler( this.BrowseButton_Click );
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point( 416, 377 );
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size( 75, 23 );
			this.OKButton.TabIndex = 3;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler( this.OKButton_Click );
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point( 497, 377 );
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size( 75, 23 );
			this.CancelButton.TabIndex = 4;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler( this.CancelButton_Click );
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
			// RefreshButton
			// 
			this.RefreshButton.Location = new System.Drawing.Point( 93, 377 );
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size( 75, 23 );
			this.RefreshButton.TabIndex = 7;
			this.RefreshButton.Text = "Refresh";
			this.RefreshButton.UseVisualStyleBackColor = true;
			this.RefreshButton.Click += new System.EventHandler( this.RefreshButton_Click );
			// 
			// PluginManagerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 584, 412 );
			this.Controls.Add( this.RefreshButton );
			this.Controls.Add( this.Description_Label );
			this.Controls.Add( this.Description );
			this.Controls.Add( this.CancelButton );
			this.Controls.Add( this.OKButton );
			this.Controls.Add( this.BrowseButton );
			this.Controls.Add( this.PluginList );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PluginManagerForm";
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
		private System.Windows.Forms.Button BrowseButton;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.TextBox Description;
		private System.Windows.Forms.Label Description_Label;
		private System.Windows.Forms.Button RefreshButton;
	}
}