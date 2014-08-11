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
			this.ScrollBarPanel = new System.Windows.Forms.Panel();
			this.FenuButtonPanel = new System.Windows.Forms.Panel();
			this.ScrollBarPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// ScrollBarPanel
			// 
			//this.ScrollBarPanel.AutoScroll = true;
			this.ScrollBarPanel.HorizontalScroll.Enabled = true;
			this.ScrollBarPanel.HorizontalScroll.Visible = true;

			this.ScrollBarPanel.Controls.Add( this.FenuButtonPanel );
			this.ScrollBarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ScrollBarPanel.Location = new System.Drawing.Point( 0, 0 );
			this.ScrollBarPanel.Name = "ScrollBarPanel";
			this.ScrollBarPanel.Size = new System.Drawing.Size( 48, 86 );
			this.ScrollBarPanel.TabIndex = 0;
			// 
			// FenuButtonPanel
			// 
			this.FenuButtonPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.FenuButtonPanel.Location = new System.Drawing.Point( 0, 0 );
			this.FenuButtonPanel.AutoSize = true;
			this.FenuButtonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.FenuButtonPanel.Name = "FenuButtonPanel";
			this.FenuButtonPanel.Size = new System.Drawing.Size( 48, 66 );
			this.FenuButtonPanel.TabIndex = 0;
			// 
			// Fenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.ScrollBarPanel );
			this.Name = "Fenu";
			this.Size = new System.Drawing.Size( 48, 86 );
			this.ScrollBarPanel.ResumeLayout( false );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel ScrollBarPanel;
		private System.Windows.Forms.Panel FenuButtonPanel;
	}
}
