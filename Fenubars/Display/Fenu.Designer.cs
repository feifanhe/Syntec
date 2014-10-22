namespace Fenubars.Display
{
	partial class Fenu
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Fenu ) );
			this.FormSplitContainer = new System.Windows.Forms.SplitContainer();
			this.TitleBarSplitterContainer = new System.Windows.Forms.SplitContainer();
			this.FenuTitle = new System.Windows.Forms.Label();
			this.FenuContextMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
			this.Refresh_FenuContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Close_FenuContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FenuContextMenuItem_Separator_1 = new System.Windows.Forms.ToolStripSeparator();
			this.Delete_FenuContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DisplayMode_CheckBox = new System.Windows.Forms.CheckBox();
			this.CloseFenu = new System.Windows.Forms.Panel();
			this.ButtonPanel = new System.Windows.Forms.Panel();
			this.ButtonContextMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
			this.Create_ButtonContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GoTo_ButtonContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ButtonContextMenu_Separator_1 = new System.Windows.Forms.ToolStripSeparator();
			this.Cut_ButtonContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Copy_ButtonContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Paste_ButtonContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ButtonContextMenu_Separator_2 = new System.Windows.Forms.ToolStripSeparator();
			this.Delete_ButtonContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FormSplitContainer.Panel1.SuspendLayout();
			this.FormSplitContainer.SuspendLayout();
			this.TitleBarSplitterContainer.Panel1.SuspendLayout();
			this.TitleBarSplitterContainer.Panel2.SuspendLayout();
			this.TitleBarSplitterContainer.SuspendLayout();
			this.FenuContextMenu.SuspendLayout();
			this.ButtonContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// FormSplitContainer
			// 
			this.FormSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FormSplitContainer.IsSplitterFixed = true;
			this.FormSplitContainer.Location = new System.Drawing.Point( 0, 0 );
			this.FormSplitContainer.Name = "FormSplitContainer";
			this.FormSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// FormSplitContainer.Panel1
			// 
			this.FormSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.FormSplitContainer.Panel1.Controls.Add( this.TitleBarSplitterContainer );
			this.FormSplitContainer.Panel1MinSize = 0;
			// 
			// FormSplitContainer.Panel2
			// 
			this.FormSplitContainer.Panel2.AutoScroll = true;
			this.FormSplitContainer.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler( this.FormSplitContainer_Panel2_MouseDown );
			this.FormSplitContainer.Panel2MinSize = 0;
			this.FormSplitContainer.Size = new System.Drawing.Size( 489, 102 );
			this.FormSplitContainer.SplitterDistance = 20;
			this.FormSplitContainer.SplitterWidth = 3;
			this.FormSplitContainer.TabIndex = 0;
			// 
			// TitleBarSplitterContainer
			// 
			this.TitleBarSplitterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TitleBarSplitterContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.TitleBarSplitterContainer.IsSplitterFixed = true;
			this.TitleBarSplitterContainer.Location = new System.Drawing.Point( 0, 0 );
			this.TitleBarSplitterContainer.Name = "TitleBarSplitterContainer";
			// 
			// TitleBarSplitterContainer.Panel1
			// 
			this.TitleBarSplitterContainer.Panel1.Controls.Add( this.FenuTitle );
			this.TitleBarSplitterContainer.Panel1MinSize = 0;
			// 
			// TitleBarSplitterContainer.Panel2
			// 
			this.TitleBarSplitterContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.TitleBarSplitterContainer.Panel2.Controls.Add( this.DisplayMode_CheckBox );
			this.TitleBarSplitterContainer.Panel2.Controls.Add( this.CloseFenu );
			this.TitleBarSplitterContainer.Panel2MinSize = 107;
			this.TitleBarSplitterContainer.Size = new System.Drawing.Size( 489, 20 );
			this.TitleBarSplitterContainer.SplitterDistance = 379;
			this.TitleBarSplitterContainer.SplitterWidth = 3;
			this.TitleBarSplitterContainer.TabIndex = 0;
			// 
			// FenuTitle
			// 
			this.FenuTitle.ContextMenuStrip = this.FenuContextMenu;
			this.FenuTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FenuTitle.Location = new System.Drawing.Point( 0, 0 );
			this.FenuTitle.Name = "FenuTitle";
			this.FenuTitle.Size = new System.Drawing.Size( 379, 20 );
			this.FenuTitle.TabIndex = 0;
			this.FenuTitle.Text = "NAME - PATH";
			this.FenuTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FenuTitle.Click += new System.EventHandler( this.FenuTitle_Click );
			// 
			// FenuContextMenu
			// 
			this.FenuContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.Refresh_FenuContextMenuItem,
            this.Close_FenuContextMenuItem,
            this.FenuContextMenuItem_Separator_1,
            this.Delete_FenuContextMenuItem} );
			this.FenuContextMenu.Name = "contextMenuStrip1";
			this.FenuContextMenu.Size = new System.Drawing.Size( 119, 76 );
			// 
			// Refresh_FenuContextMenuItem
			// 
			this.Refresh_FenuContextMenuItem.Enabled = false;
			this.Refresh_FenuContextMenuItem.Name = "Refresh_FenuContextMenuItem";
			this.Refresh_FenuContextMenuItem.Size = new System.Drawing.Size( 118, 22 );
			this.Refresh_FenuContextMenuItem.Text = "Refresh";
			this.Refresh_FenuContextMenuItem.Click += new System.EventHandler( this.Refresh_FenuContextMenuItem_Click );
			// 
			// Close_FenuContextMenuItem
			// 
			this.Close_FenuContextMenuItem.Name = "Close_FenuContextMenuItem";
			this.Close_FenuContextMenuItem.Size = new System.Drawing.Size( 118, 22 );
			this.Close_FenuContextMenuItem.Text = "Close";
			this.Close_FenuContextMenuItem.Click += new System.EventHandler( this.Close_FenuContextMenuItem_Click );
			// 
			// FenuContextMenuItem_Separator_1
			// 
			this.FenuContextMenuItem_Separator_1.Name = "FenuContextMenuItem_Separator_1";
			this.FenuContextMenuItem_Separator_1.Size = new System.Drawing.Size( 115, 6 );
			// 
			// Delete_FenuContextMenuItem
			// 
			this.Delete_FenuContextMenuItem.Enabled = false;
			this.Delete_FenuContextMenuItem.Name = "Delete_FenuContextMenuItem";
			this.Delete_FenuContextMenuItem.Size = new System.Drawing.Size( 118, 22 );
			this.Delete_FenuContextMenuItem.Text = "Delete";
			this.Delete_FenuContextMenuItem.Click += new System.EventHandler( this.Delete_FenuContextMenuItem_Click );
			// 
			// DisplayMode_CheckBox
			// 
			this.DisplayMode_CheckBox.AutoSize = true;
			this.DisplayMode_CheckBox.Dock = System.Windows.Forms.DockStyle.Right;
			this.DisplayMode_CheckBox.Location = new System.Drawing.Point( 0, 0 );
			this.DisplayMode_CheckBox.Name = "DisplayMode_CheckBox";
			this.DisplayMode_CheckBox.Size = new System.Drawing.Size( 87, 20 );
			this.DisplayMode_CheckBox.TabIndex = 1;
			this.DisplayMode_CheckBox.Text = "Merged View";
			this.DisplayMode_CheckBox.UseVisualStyleBackColor = true;
			this.DisplayMode_CheckBox.CheckedChanged += new System.EventHandler( this.DisplayMode_CheckBox_CheckedChanged );
			// 
			// CloseFenu
			// 
			this.CloseFenu.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "CloseFenu.BackgroundImage" ) ) );
			this.CloseFenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.CloseFenu.Dock = System.Windows.Forms.DockStyle.Right;
			this.CloseFenu.Location = new System.Drawing.Point( 87, 0 );
			this.CloseFenu.Name = "CloseFenu";
			this.CloseFenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CloseFenu.Size = new System.Drawing.Size( 20, 20 );
			this.CloseFenu.TabIndex = 0;
			this.CloseFenu.MouseLeave += new System.EventHandler( this.CloseFenu_MouseLeave );
			this.CloseFenu.Click += new System.EventHandler( this.CloseFenu_Click );
			this.CloseFenu.MouseEnter += new System.EventHandler( this.CloseFenu_MouseEnter );
			// 
			// ButtonPanel
			// 
			this.ButtonPanel.Location = new System.Drawing.Point( 0, 0 );
			this.ButtonPanel.Name = "ButtonPanel";
			this.ButtonPanel.Size = new System.Drawing.Size( 200, 100 );
			this.ButtonPanel.TabIndex = 0;
			// 
			// ButtonContextMenu
			// 
			this.ButtonContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.Create_ButtonContextMenuItem,
            this.GoTo_ButtonContextMenuItem,
            this.ButtonContextMenu_Separator_1,
            this.Cut_ButtonContextMenuItem,
            this.Copy_ButtonContextMenuItem,
            this.Paste_ButtonContextMenuItem,
            this.ButtonContextMenu_Separator_2,
            this.Delete_ButtonContextMenuItem} );
			this.ButtonContextMenu.Name = "ButtonContextMenu";
			this.ButtonContextMenu.Size = new System.Drawing.Size( 131, 148 );
			this.ButtonContextMenu.Opening += new System.ComponentModel.CancelEventHandler( this.ButtonContextMenu_Opening );
			// 
			// Create_ButtonContextMenuItem
			// 
			this.Create_ButtonContextMenuItem.Name = "Create_ButtonContextMenuItem";
			this.Create_ButtonContextMenuItem.Size = new System.Drawing.Size( 130, 22 );
			this.Create_ButtonContextMenuItem.Text = "Create..";
			this.Create_ButtonContextMenuItem.Click += new System.EventHandler( this.Create_ButtonContextMenuItem_Click );
			// 
			// GoTo_ButtonContextMenuItem
			// 
			this.GoTo_ButtonContextMenuItem.Name = "GoTo_ButtonContextMenuItem";
			this.GoTo_ButtonContextMenuItem.Size = new System.Drawing.Size( 130, 22 );
			this.GoTo_ButtonContextMenuItem.Text = "Go to link";
			this.GoTo_ButtonContextMenuItem.Click += new System.EventHandler( this.GoTo_ButtonContextMenuItem_Click );
			// 
			// ButtonContextMenu_Separator_1
			// 
			this.ButtonContextMenu_Separator_1.Name = "ButtonContextMenu_Separator_1";
			this.ButtonContextMenu_Separator_1.Size = new System.Drawing.Size( 127, 6 );
			// 
			// Cut_ButtonContextMenuItem
			// 
			this.Cut_ButtonContextMenuItem.Name = "Cut_ButtonContextMenuItem";
			this.Cut_ButtonContextMenuItem.Size = new System.Drawing.Size( 130, 22 );
			this.Cut_ButtonContextMenuItem.Text = "Cut";
			this.Cut_ButtonContextMenuItem.Click += new System.EventHandler( this.Cut_ButtonContextMenuItem_Click );
			// 
			// Copy_ButtonContextMenuItem
			// 
			this.Copy_ButtonContextMenuItem.Name = "Copy_ButtonContextMenuItem";
			this.Copy_ButtonContextMenuItem.Size = new System.Drawing.Size( 130, 22 );
			this.Copy_ButtonContextMenuItem.Text = "Copy";
			this.Copy_ButtonContextMenuItem.Click += new System.EventHandler( this.Copy_ButtonContextMenuItem_Click );
			// 
			// Paste_ButtonContextMenuItem
			// 
			this.Paste_ButtonContextMenuItem.Name = "Paste_ButtonContextMenuItem";
			this.Paste_ButtonContextMenuItem.Size = new System.Drawing.Size( 130, 22 );
			this.Paste_ButtonContextMenuItem.Text = "Paste";
			this.Paste_ButtonContextMenuItem.Click += new System.EventHandler( this.Paste_ButtonContextMenuItem_Click );
			// 
			// ButtonContextMenu_Separator_2
			// 
			this.ButtonContextMenu_Separator_2.Name = "ButtonContextMenu_Separator_2";
			this.ButtonContextMenu_Separator_2.Size = new System.Drawing.Size( 127, 6 );
			// 
			// Delete_ButtonContextMenuItem
			// 
			this.Delete_ButtonContextMenuItem.Name = "Delete_ButtonContextMenuItem";
			this.Delete_ButtonContextMenuItem.Size = new System.Drawing.Size( 130, 22 );
			this.Delete_ButtonContextMenuItem.Text = "Delete";
			this.Delete_ButtonContextMenuItem.Click += new System.EventHandler( this.Delete_ButtonContextMenuItem_Click );
			// 
			// Fenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.FormSplitContainer );
			this.Name = "Fenu";
			this.Size = new System.Drawing.Size( 489, 102 );
			this.FormSplitContainer.Panel1.ResumeLayout( false );
			this.FormSplitContainer.ResumeLayout( false );
			this.TitleBarSplitterContainer.Panel1.ResumeLayout( false );
			this.TitleBarSplitterContainer.Panel2.ResumeLayout( false );
			this.TitleBarSplitterContainer.Panel2.PerformLayout();
			this.TitleBarSplitterContainer.ResumeLayout( false );
			this.FenuContextMenu.ResumeLayout( false );
			this.ButtonContextMenu.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.SplitContainer FormSplitContainer;
		private System.Windows.Forms.SplitContainer TitleBarSplitterContainer;
		private System.Windows.Forms.Label FenuTitle;
		private System.Windows.Forms.Panel ButtonPanel;
		private System.Windows.Forms.Panel CloseFenu;
		private System.Windows.Forms.ContextMenuStrip ButtonContextMenu;
		private System.Windows.Forms.ToolStripMenuItem Create_ButtonContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem GoTo_ButtonContextMenuItem;
		private System.Windows.Forms.ToolStripSeparator ButtonContextMenu_Separator_1;
		private System.Windows.Forms.ToolStripMenuItem Cut_ButtonContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Copy_ButtonContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Paste_ButtonContextMenuItem;
		private System.Windows.Forms.ToolStripSeparator ButtonContextMenu_Separator_2;
		private System.Windows.Forms.ToolStripMenuItem Delete_ButtonContextMenuItem;
		private System.Windows.Forms.ContextMenuStrip FenuContextMenu;
		private System.Windows.Forms.ToolStripMenuItem Refresh_FenuContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Close_FenuContextMenuItem;
		private System.Windows.Forms.ToolStripSeparator FenuContextMenuItem_Separator_1;
		private System.Windows.Forms.ToolStripMenuItem Delete_FenuContextMenuItem;
		private System.Windows.Forms.CheckBox DisplayMode_CheckBox;
	}
}
