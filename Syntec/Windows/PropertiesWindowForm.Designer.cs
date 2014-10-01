namespace Syntec.Windows
{
	partial class PropertiesWindowForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PropertiesWindowForm ) );
			this.PropertiesViewer = new Azuria.Common.Controls.FilteredPropertyGrid();
			this.SuspendLayout();
			// 
			// PropertiesViewer
			// 
			this.PropertiesViewer.BrowsableProperties = null;
			this.PropertiesViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PropertiesViewer.HiddenAttributes = null;
			this.PropertiesViewer.HiddenProperties = null;
			this.PropertiesViewer.Location = new System.Drawing.Point( 0, 0 );
			this.PropertiesViewer.Name = "PropertiesViewer";
			this.PropertiesViewer.Size = new System.Drawing.Size( 284, 262 );
			this.PropertiesViewer.TabIndex = 0;
			// 
			// PropertiesWindowForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 284, 262 );
			this.Controls.Add( this.PropertiesViewer );
			this.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.HideOnClose = true;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "PropertiesWindowForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Properties";
			this.ResumeLayout( false );

		}

		#endregion

		private Azuria.Common.Controls.FilteredPropertyGrid PropertiesViewer;

	}
}