namespace Fenubars.Display
{
	partial class FenuContextMenuStrip
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( ) {
			this.Create_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GoTo_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Copy_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ContextMenu_Separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ContextMenu_Separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.Paste_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Delete_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Cut_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.Create_ContextMenuItem,
            this.GoTo_ContextMenuItem,
            this.ContextMenu_Separator1,
            this.Cut_ContextMenuItem,
            this.Copy_ContextMenuItem,
            this.Paste_ContextMenuItem,
            this.ContextMenu_Separator2,
            this.Delete_ContextMenuItem} );
			this.Name = "contextMenuStrip1";
			this.Size = new System.Drawing.Size( 113, 148 );
			// 
			// Create_ContextMenuItem
			// 
			this.Create_ContextMenuItem.Name = "Create_ContextMenuItem";
			this.Create_ContextMenuItem.Size = new System.Drawing.Size( 112, 22 );
			this.Create_ContextMenuItem.Text = "Create";
			// 
			// GoTo_ContextMenuItem
			// 
			this.GoTo_ContextMenuItem.Name = "GoTo_ContextMenuItem";
			this.GoTo_ContextMenuItem.Size = new System.Drawing.Size( 112, 22 );
			this.GoTo_ContextMenuItem.Text = "Go To..";
			// 
			// Copy_ContextMenuItem
			// 
			this.Copy_ContextMenuItem.Name = "Copy_ContextMenuItem";
			this.Copy_ContextMenuItem.Size = new System.Drawing.Size( 112, 22 );
			this.Copy_ContextMenuItem.Text = "Copy";
			// 
			// ContextMenu_Separator1
			// 
			this.ContextMenu_Separator1.Name = "ContextMenu_Separator1";
			this.ContextMenu_Separator1.Size = new System.Drawing.Size( 109, 6 );
			// 
			// ContextMenu_Separator2
			// 
			this.ContextMenu_Separator2.Name = "ContextMenu_Separator2";
			this.ContextMenu_Separator2.Size = new System.Drawing.Size( 109, 6 );
			// 
			// Paste_ContextMenuItem
			// 
			this.Paste_ContextMenuItem.Name = "Paste_ContextMenuItem";
			this.Paste_ContextMenuItem.Size = new System.Drawing.Size( 112, 22 );
			this.Paste_ContextMenuItem.Text = "Paste";
			// 
			// Delete_ContextMenuItem
			// 
			this.Delete_ContextMenuItem.Name = "Delete_ContextMenuItem";
			this.Delete_ContextMenuItem.Size = new System.Drawing.Size( 112, 22 );
			this.Delete_ContextMenuItem.Text = "Delete";
			// 
			// Cut_ContextMenuItem
			// 
			this.Cut_ContextMenuItem.Name = "Cut_ContextMenuItem";
			this.Cut_ContextMenuItem.Size = new System.Drawing.Size( 112, 22 );
			this.Cut_ContextMenuItem.Text = "Cut";
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ToolStripMenuItem Create_ContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem GoTo_ContextMenuItem;
		private System.Windows.Forms.ToolStripSeparator ContextMenu_Separator1;
		private System.Windows.Forms.ToolStripMenuItem Cut_ContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Copy_ContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Paste_ContextMenuItem;
		private System.Windows.Forms.ToolStripSeparator ContextMenu_Separator2;
		private System.Windows.Forms.ToolStripMenuItem Delete_ContextMenuItem;
	}
}
