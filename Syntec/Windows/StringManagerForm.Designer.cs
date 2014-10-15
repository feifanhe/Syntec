namespace Syntec.Windows
{
	partial class StringManagerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( StringManagerForm ) );
			this.StringManager_ToolStrip = new System.Windows.Forms.ToolStrip();
			this.Refresh_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.String_TreeView = new StringManager.Display.ObjectTree();
			this.StringManager_ToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// StringManager_ToolStrip
			// 
			this.StringManager_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.StringManager_ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.Refresh_ToolStripButton} );
			this.StringManager_ToolStrip.Location = new System.Drawing.Point( 0, 0 );
			this.StringManager_ToolStrip.Name = "StringManager_ToolStrip";
			this.StringManager_ToolStrip.Size = new System.Drawing.Size( 249, 25 );
			this.StringManager_ToolStrip.TabIndex = 0;
			this.StringManager_ToolStrip.Text = "toolStrip1";
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
			this.String_TreeView.ImageIndex = 0;
			this.String_TreeView.Location = new System.Drawing.Point( 0, 25 );
			this.String_TreeView.Name = "String_TreeView";
			this.String_TreeView.SelectedImageIndex = 0;
			this.String_TreeView.Size = new System.Drawing.Size( 249, 351 );
			this.String_TreeView.TabIndex = 1;
			// 
			// StringManagerForm
			// 
			this.ClientSize = new System.Drawing.Size( 249, 376 );
			this.Controls.Add( this.String_TreeView );
			this.Controls.Add( this.StringManager_ToolStrip );
			this.Font = new System.Drawing.Font( "PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "StringManagerForm";
			this.Text = "String Manager";
			this.StringManager_ToolStrip.ResumeLayout( false );
			this.StringManager_ToolStrip.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip StringManager_ToolStrip;
		private System.Windows.Forms.ToolStripButton Refresh_ToolStripButton;
		private StringManager.Display.ObjectTree String_TreeView;
	}
}
