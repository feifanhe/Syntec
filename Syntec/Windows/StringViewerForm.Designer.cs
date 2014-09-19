namespace Syntec.Windows
{
	partial class StringViewerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( StringViewerForm ) );
			this.StringViewer_ToolStrip = new System.Windows.Forms.ToolStrip();
			this.Refresh_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.String_TreeView = new System.Windows.Forms.TreeView();
			this.StringViewer_ToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// StringViewer_ToolStrip
			// 
			this.StringViewer_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.StringViewer_ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.Refresh_ToolStripButton} );
			this.StringViewer_ToolStrip.Location = new System.Drawing.Point( 0, 0 );
			this.StringViewer_ToolStrip.Name = "StringViewer_ToolStrip";
			this.StringViewer_ToolStrip.Size = new System.Drawing.Size( 249, 25 );
			this.StringViewer_ToolStrip.TabIndex = 0;
			this.StringViewer_ToolStrip.Text = "toolStrip1";
			// 
			// Refresh_ToolStripButton
			// 
			this.Refresh_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.Refresh_ToolStripButton.Enabled = false;
			this.Refresh_ToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "Refresh_ToolStripButton.Image" ) ) );
			this.Refresh_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Refresh_ToolStripButton.Name = "Refresh_ToolStripButton";
			this.Refresh_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.Refresh_ToolStripButton.Text = "Refresh";
			this.Refresh_ToolStripButton.ToolTipText = "Refresh";
			// 
			// String_TreeView
			// 
			this.String_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.String_TreeView.Location = new System.Drawing.Point( 0, 25 );
			this.String_TreeView.Name = "String_TreeView";
			this.String_TreeView.Size = new System.Drawing.Size( 249, 351 );
			this.String_TreeView.TabIndex = 1;
			// 
			// StringViewer
			// 
			this.ClientSize = new System.Drawing.Size( 249, 376 );
			this.Controls.Add( this.String_TreeView );
			this.Controls.Add( this.StringViewer_ToolStrip );
			this.Font = new System.Drawing.Font( "PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.Name = "StringViewer";
			this.Text = "String Viewer";
			this.StringViewer_ToolStrip.ResumeLayout( false );
			this.StringViewer_ToolStrip.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip StringViewer_ToolStrip;
		private System.Windows.Forms.ToolStripButton Refresh_ToolStripButton;
		private System.Windows.Forms.TreeView String_TreeView;
	}
}
