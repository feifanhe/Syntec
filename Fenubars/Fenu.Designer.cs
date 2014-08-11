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
			this.FenuButtonPanel.Size = new System.Drawing.Size( 48, 86 );
			this.FenuButtonPanel.TabIndex = 0;
			// 
			// Fenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.FenuButtonPanel );
			this.Name = "Fenu";
			this.Size = new System.Drawing.Size( 48, 86 );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel FenuButtonPanel;
	}
}
