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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Fenu ) );
			this.FormSplitContainer = new System.Windows.Forms.SplitContainer();
			this.TitleBarSplitterContainer = new System.Windows.Forms.SplitContainer();
			this.FenuTitle = new System.Windows.Forms.Label();
			this.CloseFenu = new System.Windows.Forms.Panel();
			this.ButtonPanel = new System.Windows.Forms.Panel();
			this.FormSplitContainer.Panel1.SuspendLayout();
			this.FormSplitContainer.SuspendLayout();
			this.TitleBarSplitterContainer.Panel1.SuspendLayout();
			this.TitleBarSplitterContainer.Panel2.SuspendLayout();
			this.TitleBarSplitterContainer.SuspendLayout();
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
			this.FormSplitContainer.Panel2.Click += new System.EventHandler( this.FormSplitContainer_Panel2_Click );
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
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.SplitContainer FormSplitContainer;
		private System.Windows.Forms.SplitContainer TitleBarSplitterContainer;
		private System.Windows.Forms.Label FenuTitle;
		private System.Windows.Forms.Panel ButtonPanel;
		private System.Windows.Forms.Panel CloseFenu;
	}
}
