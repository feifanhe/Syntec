namespace Fenubars.Display
{
	partial class ObjectTree
	{
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ObjectTree ) );
			this.ObjectType_ImageList = new System.Windows.Forms.ImageList( this.components );
			this.SuspendLayout();
			// 
			// ObjectType_ImageList
			// 
			this.ObjectType_ImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "ObjectType_ImageList.ImageStream" ) ) );
			this.ObjectType_ImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.ObjectType_ImageList.Images.SetKeyName( 0, "Fenubar_Fenu_Main.png" );
			this.ObjectType_ImageList.Images.SetKeyName( 1, "Fenubar_Fenu.png" );
			this.ResumeLayout( false );

		}

		private System.Windows.Forms.ImageList ObjectType_ImageList;
		private System.ComponentModel.IContainer components;
	}
}
