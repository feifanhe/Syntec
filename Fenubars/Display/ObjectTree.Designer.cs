namespace Fenubars.Display
{
	partial class ObjectTree
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// ObjectTree
			// 
			this.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Name = "Object_TreeView";
			this.Size = new System.Drawing.Size( 150, 150 );
			this.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler( this.ObjectTree_NodeMouseDoubleClick );
			this.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler( this.ObjectTree_BeforeExpand );
			this.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler( this.ObjectTree_BeforeCollapse );
			this.ResumeLayout( false );

		}

		#endregion

		//private System.Windows.Forms.TreeView Object_TreeView;
	}
}
