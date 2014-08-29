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
			this.CloseFenu = new System.Windows.Forms.Panel();
			this.ButtonPanel = new System.Windows.Forms.Panel();
			this.ButtonContextMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
			this.Create_ButtonContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GoTo_ButtonContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ButtonContextMenu_Separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.Cut_ButtonContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Copy_ButtonContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Paste_ButtonContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ButtonContextMenu_Separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.Delete_ButtonContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FormSplitContainer.Panel1.SuspendLayout();
			this.FormSplitContainer.SuspendLayout();
			this.TitleBarSplitterContainer.Panel1.SuspendLayout();
			this.TitleBarSplitterContainer.Panel2.SuspendLayout();
			this.TitleBarSplitterContainer.SuspendLayout();
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
			this.FormSplitContainer.Size = new System.Drawing.Size( 489, 110 );
			this.FormSplitContainer.SplitterDistance = 22;
			this.FormSplitContainer.SplitterWidth = 3;
			this.FormSplitContainer.TabIndex = 0;
			// 
			// TitleBarSplitterContainer
			// 
			this.TitleBarSplitterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
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
			this.TitleBarSplitterContainer.Panel2.Controls.Add( this.CloseFenu );
			this.TitleBarSplitterContainer.Panel2MinSize = 0;
			this.TitleBarSplitterContainer.Size = new System.Drawing.Size( 489, 22 );
			this.TitleBarSplitterContainer.SplitterDistance = 449;
			this.TitleBarSplitterContainer.SplitterWidth = 3;
			this.TitleBarSplitterContainer.TabIndex = 0;
			// 
			// FenuTitle
			// 
			this.FenuTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FenuTitle.Location = new System.Drawing.Point( 0, 0 );
			this.FenuTitle.Name = "FenuTitle";
			this.FenuTitle.Size = new System.Drawing.Size( 449, 22 );
			this.FenuTitle.TabIndex = 0;
			this.FenuTitle.Text = "NAME - PATH";
			this.FenuTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FenuTitle.Click += new System.EventHandler( this.FenuTitle_Click );
			// 
			// CloseFenu
			// 
			this.CloseFenu.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "CloseFenu.BackgroundImage" ) ) );
			this.CloseFenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.CloseFenu.Dock = System.Windows.Forms.DockStyle.Right;
			this.CloseFenu.Location = new System.Drawing.Point( 17, 0 );
			this.CloseFenu.Name = "CloseFenu";
			this.CloseFenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CloseFenu.Size = new System.Drawing.Size( 20, 22 );
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
            this.ButtonContextMenu_Separator1,
            this.Cut_ButtonContextMenuItem,
            this.Copy_ButtonContextMenuItem,
            this.Paste_ButtonContextMenuItem,
            this.ButtonContextMenu_Separator2,
            this.Delete_ButtonContextMenuItem} );
			this.ButtonContextMenu.Name = "ButtonContextMenu";
			this.ButtonContextMenu.Size = new System.Drawing.Size( 153, 170 );
			this.ButtonContextMenu.Opening += new System.ComponentModel.CancelEventHandler( this.ButtonContextMenu_Opening );
			// 
			// Create_ButtonContextMenuItem
			// 
			this.Create_ButtonContextMenuItem.Name = "Create_ButtonContextMenuItem";
			this.Create_ButtonContextMenuItem.Size = new System.Drawing.Size( 152, 22 );
			this.Create_ButtonContextMenuItem.Text = "Create..";
			this.Create_ButtonContextMenuItem.Click += new System.EventHandler( this.Create_ButtonContextMenuItem_Click );
			// 
			// GoTo_ButtonContextMenuItem
			// 
			this.GoTo_ButtonContextMenuItem.Name = "GoTo_ButtonContextMenuItem";
			this.GoTo_ButtonContextMenuItem.Size = new System.Drawing.Size( 152, 22 );
			this.GoTo_ButtonContextMenuItem.Text = "Go to link";
			this.GoTo_ButtonContextMenuItem.Click += new System.EventHandler( this.GoTo_ButtonContextMenuItem_Click );
			// 
			// ButtonContextMenu_Separator1
			// 
			this.ButtonContextMenu_Separator1.Name = "ButtonContextMenu_Separator1";
			this.ButtonContextMenu_Separator1.Size = new System.Drawing.Size( 149, 6 );
			// 
			// Cut_ButtonContextMenuItem
			// 
			this.Cut_ButtonContextMenuItem.Name = "Cut_ButtonContextMenuItem";
			this.Cut_ButtonContextMenuItem.Size = new System.Drawing.Size( 152, 22 );
			this.Cut_ButtonContextMenuItem.Text = "Cut";
			this.Cut_ButtonContextMenuItem.Click += new System.EventHandler( this.Cut_ButtonContextMenuItem_Click );
			// 
			// Copy_ButtonContextMenuItem
			// 
			this.Copy_ButtonContextMenuItem.Name = "Copy_ButtonContextMenuItem";
			this.Copy_ButtonContextMenuItem.Size = new System.Drawing.Size( 152, 22 );
			this.Copy_ButtonContextMenuItem.Text = "Copy";
			this.Copy_ButtonContextMenuItem.Click += new System.EventHandler( this.Copy_ButtonContextMenuItem_Click );
			// 
			// Paste_ButtonContextMenuItem
			// 
			this.Paste_ButtonContextMenuItem.Name = "Paste_ButtonContextMenuItem";
			this.Paste_ButtonContextMenuItem.Size = new System.Drawing.Size( 152, 22 );
			this.Paste_ButtonContextMenuItem.Text = "Paste";
			this.Paste_ButtonContextMenuItem.Click += new System.EventHandler( this.Paste_ButtonContextMenuItem_Click );
			// 
			// ButtonContextMenu_Separator2
			// 
			this.ButtonContextMenu_Separator2.Name = "ButtonContextMenu_Separator2";
			this.ButtonContextMenu_Separator2.Size = new System.Drawing.Size( 149, 6 );
			// 
			// Delete_ButtonContextMenuItem
			// 
			this.Delete_ButtonContextMenuItem.Name = "Delete_ButtonContextMenuItem";
			this.Delete_ButtonContextMenuItem.Size = new System.Drawing.Size( 152, 22 );
			this.Delete_ButtonContextMenuItem.Text = "Delete";
			this.Delete_ButtonContextMenuItem.Click += new System.EventHandler( this.Delete_ButtonContextMenuItem_Click );
			// 
			// Fenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.FormSplitContainer );
			this.Name = "Fenu";
			this.Size = new System.Drawing.Size( 489, 110 );
			this.FormSplitContainer.Panel1.ResumeLayout( false );
			this.FormSplitContainer.ResumeLayout( false );
			this.TitleBarSplitterContainer.Panel1.ResumeLayout( false );
			this.TitleBarSplitterContainer.Panel2.ResumeLayout( false );
			this.TitleBarSplitterContainer.ResumeLayout( false );
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
		private System.Windows.Forms.ToolStripSeparator ButtonContextMenu_Separator1;
		private System.Windows.Forms.ToolStripMenuItem Cut_ButtonContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Copy_ButtonContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Paste_ButtonContextMenuItem;
		private System.Windows.Forms.ToolStripSeparator ButtonContextMenu_Separator2;
		private System.Windows.Forms.ToolStripMenuItem Delete_ButtonContextMenuItem;
	}
}
