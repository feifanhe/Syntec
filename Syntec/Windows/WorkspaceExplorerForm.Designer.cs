namespace Syntec.Windows
{
	partial class WorkspaceExplorerForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( WorkspaceExplorerForm ) );
			this.Workspace_ToolStrip = new System.Windows.Forms.ToolStrip();
			this.ShowAll_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.Refresh_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.Workspace_TreeView = new System.Windows.Forms.TreeView();
			this.FileType_ImageList = new System.Windows.Forms.ImageList( this.components );
			this.Workspace_ToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// Workspace_ToolStrip
			// 
			this.Workspace_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.Workspace_ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.ShowAll_ToolStripButton,
            this.Refresh_ToolStripButton} );
			this.Workspace_ToolStrip.Location = new System.Drawing.Point( 0, 0 );
			this.Workspace_ToolStrip.Name = "Workspace_ToolStrip";
			this.Workspace_ToolStrip.Size = new System.Drawing.Size( 248, 25 );
			this.Workspace_ToolStrip.TabIndex = 0;
			// 
			// ShowAll_ToolStripButton
			// 
			this.ShowAll_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ShowAll_ToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "ShowAll_ToolStripButton.Image" ) ) );
			this.ShowAll_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ShowAll_ToolStripButton.Name = "ShowAll_ToolStripButton";
			this.ShowAll_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.ShowAll_ToolStripButton.ToolTipText = "Show All Files";
			this.ShowAll_ToolStripButton.Click += new System.EventHandler( this.ShowAll_ToolStripButton_Click );
			// 
			// Refresh_ToolStripButton
			// 
			this.Refresh_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.Refresh_ToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "Refresh_ToolStripButton.Image" ) ) );
			this.Refresh_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Refresh_ToolStripButton.Name = "Refresh_ToolStripButton";
			this.Refresh_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.Refresh_ToolStripButton.ToolTipText = "Refresh";
			this.Refresh_ToolStripButton.Click += new System.EventHandler( this.Refresh_ToolStripButton_Click );
			// 
			// Workspace_TreeView
			// 
			this.Workspace_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Workspace_TreeView.ImageIndex = 1;
			this.Workspace_TreeView.ImageList = this.FileType_ImageList;
			this.Workspace_TreeView.Location = new System.Drawing.Point( 0, 25 );
			this.Workspace_TreeView.Name = "Workspace_TreeView";
			this.Workspace_TreeView.SelectedImageIndex = 1;
			this.Workspace_TreeView.Size = new System.Drawing.Size( 248, 301 );
			this.Workspace_TreeView.TabIndex = 1;
			this.Workspace_TreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler( this.WorkspaceTreeView_NodeMouseDoubleClick );
			this.Workspace_TreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler( this.WorkspaceTreeView_BeforeExpand );
			this.Workspace_TreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler( this.WorkspaceTreeView_BeforeCollapse );
			// 
			// FileType_ImageList
			// 
			this.FileType_ImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "FileType_ImageList.ImageStream" ) ) );
			this.FileType_ImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.FileType_ImageList.Images.SetKeyName( 0, "Product" );
			this.FileType_ImageList.Images.SetKeyName( 1, "Folder" );
			this.FileType_ImageList.Images.SetKeyName( 2, "XML" );
			this.FileType_ImageList.Images.SetKeyName( 3, "FolderOpen" );
			this.FileType_ImageList.Images.SetKeyName( 4, "File_Hidden.bmp" );
			this.FileType_ImageList.Images.SetKeyName( 5, "Base_Workspace.bmp" );
			// 
			// WorkspaceExplorerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 248, 326 );
			this.Controls.Add( this.Workspace_TreeView );
			this.Controls.Add( this.Workspace_ToolStrip );
			this.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.HideOnClose = true;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "WorkspaceExplorerForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "WorkspaceExplorer";
			this.Workspace_ToolStrip.ResumeLayout( false );
			this.Workspace_ToolStrip.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip Workspace_ToolStrip;
		private System.Windows.Forms.TreeView Workspace_TreeView;
		private System.Windows.Forms.ToolStripButton Refresh_ToolStripButton;
		private System.Windows.Forms.ToolStripButton ShowAll_ToolStripButton;
		private System.Windows.Forms.ImageList FileType_ImageList;
	}
}