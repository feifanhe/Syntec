namespace Syntec.Windows
{
	partial class ObjectBrowserForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ObjectBrowserForm ) );
			this.ObjectBrowser_ToolStrip = new System.Windows.Forms.ToolStrip();
			this.Refresh_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ToolStrip_Separator_1 = new System.Windows.Forms.ToolStripSeparator();
			this.ViewCode_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ViewDesigner_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ViewStructure_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ObjectTree_Panel = new System.Windows.Forms.Panel();
			this.ObjectBrowser_ToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// ObjectBrowser_ToolStrip
			// 
			this.ObjectBrowser_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ObjectBrowser_ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.Refresh_ToolStripButton,
            this.ToolStrip_Separator_1,
            this.ViewCode_ToolStripButton,
            this.ViewDesigner_ToolStripButton,
            this.ViewStructure_ToolStripButton} );
			this.ObjectBrowser_ToolStrip.Location = new System.Drawing.Point( 0, 0 );
			this.ObjectBrowser_ToolStrip.Name = "ObjectBrowser_ToolStrip";
			this.ObjectBrowser_ToolStrip.Size = new System.Drawing.Size( 248, 25 );
			this.ObjectBrowser_ToolStrip.TabIndex = 0;
			// 
			// Refresh_ToolStripButton
			// 
			this.Refresh_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.Refresh_ToolStripButton.Enabled = false;
			this.Refresh_ToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "Refresh_ToolStripButton.Image" ) ) );
			this.Refresh_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Refresh_ToolStripButton.Name = "Refresh_ToolStripButton";
			this.Refresh_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.Refresh_ToolStripButton.ToolTipText = "Refresh";
			this.Refresh_ToolStripButton.Click += new System.EventHandler( this.Refresh_ToolStripButton_Click );
			// 
			// ToolStrip_Separator_1
			// 
			this.ToolStrip_Separator_1.Name = "ToolStrip_Separator_1";
			this.ToolStrip_Separator_1.Size = new System.Drawing.Size( 6, 25 );
			// 
			// ViewCode_ToolStripButton
			// 
			this.ViewCode_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ViewCode_ToolStripButton.Enabled = false;
			this.ViewCode_ToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "ViewCode_ToolStripButton.Image" ) ) );
			this.ViewCode_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ViewCode_ToolStripButton.Name = "ViewCode_ToolStripButton";
			this.ViewCode_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.ViewCode_ToolStripButton.Text = "toolStripButton1";
			this.ViewCode_ToolStripButton.ToolTipText = "View Code";
			this.ViewCode_ToolStripButton.Click += new System.EventHandler( this.ViewCode_ToolStripButton_Click );
			// 
			// ViewDesigner_ToolStripButton
			// 
			this.ViewDesigner_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ViewDesigner_ToolStripButton.Enabled = false;
			this.ViewDesigner_ToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "ViewDesigner_ToolStripButton.Image" ) ) );
			this.ViewDesigner_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ViewDesigner_ToolStripButton.Name = "ViewDesigner_ToolStripButton";
			this.ViewDesigner_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.ViewDesigner_ToolStripButton.Text = "toolStripButton1";
			this.ViewDesigner_ToolStripButton.ToolTipText = "View Designer";
			this.ViewDesigner_ToolStripButton.Click += new System.EventHandler( this.ViewDesigner_ToolStripButton_Click );
			// 
			// ViewStructure_ToolStripButton
			// 
			this.ViewStructure_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ViewStructure_ToolStripButton.Enabled = false;
			this.ViewStructure_ToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "ViewStructure_ToolStripButton.Image" ) ) );
			this.ViewStructure_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ViewStructure_ToolStripButton.Name = "ViewStructure_ToolStripButton";
			this.ViewStructure_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.ViewStructure_ToolStripButton.Text = "toolStripButton1";
			this.ViewStructure_ToolStripButton.ToolTipText = "View Structure";
			this.ViewStructure_ToolStripButton.Click += new System.EventHandler( this.ViewStructure_ToolStripButton_Click );
			// 
			// ObjectTree_Panel
			// 
			this.ObjectTree_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ObjectTree_Panel.Location = new System.Drawing.Point( 0, 25 );
			this.ObjectTree_Panel.Name = "ObjectTree_Panel";
			this.ObjectTree_Panel.Size = new System.Drawing.Size( 248, 301 );
			this.ObjectTree_Panel.TabIndex = 2;
			// 
			// ObjectBrowserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 248, 326 );
			this.Controls.Add( this.ObjectTree_Panel );
			this.Controls.Add( this.ObjectBrowser_ToolStrip );
			this.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.HideOnClose = true;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "ObjectBrowserForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Object Browser";
			this.ObjectBrowser_ToolStrip.ResumeLayout( false );
			this.ObjectBrowser_ToolStrip.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip ObjectBrowser_ToolStrip;
		private System.Windows.Forms.ToolStripButton Refresh_ToolStripButton;
		private System.Windows.Forms.ToolStripSeparator ToolStrip_Separator_1;
		private System.Windows.Forms.ToolStripButton ViewCode_ToolStripButton;
		private System.Windows.Forms.ToolStripButton ViewDesigner_ToolStripButton;
		private System.Windows.Forms.ToolStripButton ViewStructure_ToolStripButton;
		private System.Windows.Forms.Panel ObjectTree_Panel;
	}
}