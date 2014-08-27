namespace Syntec.Windows
{
	partial class WorkspaceExplorer
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( WorkspaceExplorer ) );
			this.Workspace_ToolStrip = new System.Windows.Forms.ToolStrip();
			this.Workspace_Separator_1 = new System.Windows.Forms.ToolStripSeparator();
			this.WorkspaceTreeView = new System.Windows.Forms.TreeView();
			this.FileType_ImageList = new System.Windows.Forms.ImageList( this.components );
			this.ShowAll_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.Refresh_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ViewCode_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ViewDesigner_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ViewStructure_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.Workspace_ToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// Workspace_ToolStrip
			// 
			this.Workspace_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.Workspace_ToolStrip.Location = new System.Drawing.Point( 0, 0 );
			this.Workspace_ToolStrip.Name = "Workspace_ToolStrip";
			this.Workspace_ToolStrip.Size = new System.Drawing.Size( 248, 25 );
			this.Workspace_ToolStrip.TabIndex = 0;
			this.Workspace_ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { 
				this.ShowAll_ToolStripButton,
				this.Refresh_ToolStripButton,
				this.Workspace_Separator_1,
				this.ViewCode_ToolStripButton,
				this.ViewDesigner_ToolStripButton,
				this.ViewStructure_ToolStripButton} );
			// 
			// Workspace_Separator_1
			// 
			this.Workspace_Separator_1.Name = "Workspace_Separator_1";
			this.Workspace_Separator_1.Size = new System.Drawing.Size( 6, 25 );
			// 
			// WorkspaceTreeView
			// 
			this.WorkspaceTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.WorkspaceTreeView.ImageIndex = 1;
			this.WorkspaceTreeView.ImageList = this.FileType_ImageList;
			this.WorkspaceTreeView.Location = new System.Drawing.Point( 0, 25 );
			this.WorkspaceTreeView.Name = "WorkspaceTreeView";
			this.WorkspaceTreeView.SelectedImageIndex = 1;
			this.WorkspaceTreeView.Size = new System.Drawing.Size( 248, 301 );
			this.WorkspaceTreeView.TabIndex = 1;
			this.WorkspaceTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler( this.WorkspaceTreeView_BeforeExpand );
			this.WorkspaceTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler( this.WorkspaceTreeView_BeforeCollapse );
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
			// ViewCode_ToolStripButton
			// 
			this.ViewCode_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ViewCode_ToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "ViewCode_ToolStripButton.Image" ) ) );
			this.ViewCode_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ViewCode_ToolStripButton.Name = "ViewCode_ToolStripButton";
			this.ViewCode_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.ViewCode_ToolStripButton.ToolTipText = "View Code";
			this.ViewCode_ToolStripButton.Click += new System.EventHandler( this.ViewCode_ToolStripButton_Click );
			// 
			// ViewDesigner_ToolStripButton
			// 
			this.ViewDesigner_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ViewDesigner_ToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "ViewDesigner_ToolStripButton.Image" ) ) );
			this.ViewDesigner_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ViewDesigner_ToolStripButton.Name = "ViewDesigner_ToolStripButton";
			this.ViewDesigner_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.ViewDesigner_ToolStripButton.ToolTipText = "View Designer";
			this.ViewDesigner_ToolStripButton.Click += new System.EventHandler( this.ViewDesigner_ToolStripButton_Click );
			// 
			// ViewStructure_ToolStripButton
			// 
			this.ViewStructure_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ViewStructure_ToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "ViewStructure_ToolStripButton.Image" ) ) );
			this.ViewStructure_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ViewStructure_ToolStripButton.Name = "ViewStructure_ToolStripButton";
			this.ViewStructure_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.ViewStructure_ToolStripButton.ToolTipText = "View Structure";
			this.ViewStructure_ToolStripButton.Click += new System.EventHandler( this.ViewStructure_ToolStripButton_Click );
			// 
			// WorkspaceExplorer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 248, 326 );
			this.Controls.Add( this.WorkspaceTreeView );
			this.Controls.Add( this.Workspace_ToolStrip );
			this.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.Name = "WorkspaceExplorer";
			this.Text = "WorkspaceExplorer";
			this.Workspace_ToolStrip.ResumeLayout( false );
			this.Workspace_ToolStrip.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip Workspace_ToolStrip;
		private System.Windows.Forms.ToolStripButton ViewCode_ToolStripButton;
		private System.Windows.Forms.ToolStripButton ViewDesigner_ToolStripButton;
		private System.Windows.Forms.ToolStripButton ViewStructure_ToolStripButton;
		private System.Windows.Forms.TreeView WorkspaceTreeView;
		private System.Windows.Forms.ToolStripSeparator Workspace_Separator_1;
		private System.Windows.Forms.ToolStripButton Refresh_ToolStripButton;
		private System.Windows.Forms.ToolStripButton ShowAll_ToolStripButton;
		private System.Windows.Forms.ImageList FileType_ImageList;
	}
}