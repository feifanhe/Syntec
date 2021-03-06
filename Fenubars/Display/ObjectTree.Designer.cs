namespace Fenubars.Display
{
	partial class ObjectTree
	{
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ObjectTree ) );
			this.ObjectType_ImageList = new System.Windows.Forms.ImageList( this.components );
			this.ObjectTree_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip( this.components );
			this.SuspendLayout();
			// 
			// ObjectType_ImageList
			// 
			this.ObjectType_ImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "ObjectType_ImageList.ImageStream" ) ) );
			this.ObjectType_ImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.ObjectType_ImageList.Images.SetKeyName( 0, "Fenubar_Fenu_Main.png" );
			this.ObjectType_ImageList.Images.SetKeyName( 1, "Fenubar_Fenu.png" );
			// 
			// ObjectTree_ContextMenuStrip
			// 
			this.ObjectTree_ContextMenuStrip.Name = "ObjectTree_ContextMenuStrip";
			this.ObjectTree_ContextMenuStrip.Size = new System.Drawing.Size( 61, 4 );
			this.ObjectTree_ContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler( this.ObjectTree_ContextMenuStrip_Opening );
			// 
			// ObjectTree
			// 
			this.ContextMenuStrip = this.ObjectTree_ContextMenuStrip;
			this.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ImageIndex = 0;
			this.ImageList = this.ObjectType_ImageList;
			this.LabelEdit = true;
			this.LineColor = System.Drawing.Color.Black;
			this.SelectedImageIndex = 0;
			this.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler( this.ObjectTree_AfterLabelEdit );
			this.ResumeLayout( false );

		}

		private System.Windows.Forms.ImageList ObjectType_ImageList;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ContextMenuStrip ObjectTree_ContextMenuStrip;
	}
}
