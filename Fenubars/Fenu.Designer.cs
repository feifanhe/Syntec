namespace Fenubars
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
			this.FenuButtonPanel = new System.Windows.Forms.Panel();
			this.SplitContainer = new System.Windows.Forms.SplitContainer();
			this.FenuName = new System.Windows.Forms.Label();
			this.SplitContainer.Panel1.SuspendLayout();
			this.SplitContainer.Panel2.SuspendLayout();
			this.SplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// FenuButtonPanel
			// 
			this.FenuButtonPanel.AutoScroll = true;
			this.FenuButtonPanel.AutoSize = true;
			this.FenuButtonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.FenuButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FenuButtonPanel.Location = new System.Drawing.Point( 0, 0 );
			this.FenuButtonPanel.Name = "FenuButtonPanel";
			this.FenuButtonPanel.Size = new System.Drawing.Size( 48, 90 );
			this.FenuButtonPanel.TabIndex = 0;
			// 
			// SplitContainer
			// 
			this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer.IsSplitterFixed = true;
			this.SplitContainer.Location = new System.Drawing.Point( 0, 0 );
			this.SplitContainer.Name = "SplitContainer";
			this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// SplitContainer.Panel1
			// 
			this.SplitContainer.Panel1.BackColor = System.Drawing.Color.Aqua;
			this.SplitContainer.Panel1.Controls.Add( this.FenuName );
			this.SplitContainer.Panel1MinSize = 10;
			// 
			// SplitContainer.Panel2
			// 
			this.SplitContainer.Panel2.Controls.Add( this.FenuButtonPanel );
			this.SplitContainer.Size = new System.Drawing.Size( 48, 104 );
			this.SplitContainer.SplitterDistance = 13;
			this.SplitContainer.SplitterWidth = 1;
			this.SplitContainer.TabIndex = 1;
			// 
			// FenuName
			// 
			this.FenuName.AutoSize = true;
			this.FenuName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FenuName.Location = new System.Drawing.Point( 0, 0 );
			this.FenuName.Name = "FenuName";
			this.FenuName.Size = new System.Drawing.Size( 89, 13 );
			this.FenuName.TabIndex = 0;
			this.FenuName.Text = "DEFAULT TITLE";
			this.FenuName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Fenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.SplitContainer );
			this.Name = "Fenu";
			this.Size = new System.Drawing.Size( 48, 104 );
			this.SplitContainer.Panel1.ResumeLayout( false );
			this.SplitContainer.Panel1.PerformLayout();
			this.SplitContainer.Panel2.ResumeLayout( false );
			this.SplitContainer.Panel2.PerformLayout();
			this.SplitContainer.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Panel FenuButtonPanel;
		private System.Windows.Forms.SplitContainer SplitContainer;
		private System.Windows.Forms.Label FenuName;
	}
}
