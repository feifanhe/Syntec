namespace Fenubars
{
	partial class NormalButton
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
			this.components = new System.ComponentModel.Container();
			this.NormalButtonPropertiesBindingSource = new System.Windows.Forms.BindingSource( this.components );
			( (System.ComponentModel.ISupportInitialize)( this.NormalButtonPropertiesBindingSource ) ).BeginInit();
			this.SuspendLayout();
			// 
			// NormalButtonPropertiesBindingSource
			// 
			this.NormalButtonPropertiesBindingSource.DataSource = typeof( Fenubars.NormalButtonProperties );
			// 
			// NormalButton
			// 
			this.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.NormalButtonPropertiesBindingSource, "Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			( (System.ComponentModel.ISupportInitialize)( this.NormalButtonPropertiesBindingSource ) ).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.BindingSource NormalButtonPropertiesBindingSource;


	}
}
