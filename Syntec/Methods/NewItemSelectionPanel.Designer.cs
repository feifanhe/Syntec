namespace Syntec.Windows
{
	partial class NewItemSelectionPanel
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( NewItemSelectionPanel ) );
			this.Main_SplitContainer = new System.Windows.Forms.SplitContainer();
			this.Category_SplitContainer = new System.Windows.Forms.SplitContainer();
			this.Categories_TreeView = new System.Windows.Forms.TreeView();
			this.Categories_Label = new System.Windows.Forms.Label();
			this.Templates_ListView = new System.Windows.Forms.ListView();
			this.NewItem_ImageList = new System.Windows.Forms.ImageList( this.components );
			this.Templates_Label = new System.Windows.Forms.Label();
			this.Description_TextBox = new System.Windows.Forms.TextBox();
			this.Main_SplitContainer.Panel1.SuspendLayout();
			this.Main_SplitContainer.Panel2.SuspendLayout();
			this.Main_SplitContainer.SuspendLayout();
			this.Category_SplitContainer.Panel1.SuspendLayout();
			this.Category_SplitContainer.Panel2.SuspendLayout();
			this.Category_SplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// Main_SplitContainer
			// 
			this.Main_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Main_SplitContainer.IsSplitterFixed = true;
			this.Main_SplitContainer.Location = new System.Drawing.Point( 0, 0 );
			this.Main_SplitContainer.Name = "Main_SplitContainer";
			this.Main_SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// Main_SplitContainer.Panel1
			// 
			this.Main_SplitContainer.Panel1.Controls.Add( this.Category_SplitContainer );
			// 
			// Main_SplitContainer.Panel2
			// 
			this.Main_SplitContainer.Panel2.Controls.Add( this.Description_TextBox );
			this.Main_SplitContainer.Panel2MinSize = 22;
			this.Main_SplitContainer.Size = new System.Drawing.Size( 640, 360 );
			this.Main_SplitContainer.SplitterDistance = 330;
			this.Main_SplitContainer.TabIndex = 0;
			// 
			// Category_SplitContainer
			// 
			this.Category_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Category_SplitContainer.IsSplitterFixed = true;
			this.Category_SplitContainer.Location = new System.Drawing.Point( 0, 0 );
			this.Category_SplitContainer.Name = "Category_SplitContainer";
			// 
			// Category_SplitContainer.Panel1
			// 
			this.Category_SplitContainer.Panel1.Controls.Add( this.Categories_TreeView );
			this.Category_SplitContainer.Panel1.Controls.Add( this.Categories_Label );
			// 
			// Category_SplitContainer.Panel2
			// 
			this.Category_SplitContainer.Panel2.Controls.Add( this.Templates_ListView );
			this.Category_SplitContainer.Panel2.Controls.Add( this.Templates_Label );
			this.Category_SplitContainer.Size = new System.Drawing.Size( 640, 330 );
			this.Category_SplitContainer.SplitterDistance = 240;
			this.Category_SplitContainer.TabIndex = 0;
			// 
			// Categories_TreeView
			// 
			this.Categories_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Categories_TreeView.HideSelection = false;
			this.Categories_TreeView.Location = new System.Drawing.Point( 0, 23 );
			this.Categories_TreeView.Name = "Categories_TreeView";
			this.Categories_TreeView.Size = new System.Drawing.Size( 240, 307 );
			this.Categories_TreeView.TabIndex = 1;
			this.Categories_TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.Category_TreeView_AfterSelect );
			// 
			// Categories_Label
			// 
			this.Categories_Label.Dock = System.Windows.Forms.DockStyle.Top;
			this.Categories_Label.Location = new System.Drawing.Point( 0, 0 );
			this.Categories_Label.Name = "Categories_Label";
			this.Categories_Label.Size = new System.Drawing.Size( 240, 23 );
			this.Categories_Label.TabIndex = 0;
			this.Categories_Label.Text = "Categories:";
			// 
			// Templates_ListView
			// 
			this.Templates_ListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Templates_ListView.HideSelection = false;
			this.Templates_ListView.LargeImageList = this.NewItem_ImageList;
			this.Templates_ListView.Location = new System.Drawing.Point( 0, 23 );
			this.Templates_ListView.MultiSelect = false;
			this.Templates_ListView.Name = "Templates_ListView";
			this.Templates_ListView.Size = new System.Drawing.Size( 396, 307 );
			this.Templates_ListView.SmallImageList = this.NewItem_ImageList;
			this.Templates_ListView.TabIndex = 1;
			this.Templates_ListView.UseCompatibleStateImageBehavior = false;
			this.Templates_ListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler( this.Template_ListView_ItemSelectionChanged );
			// 
			// NewItem_ImageList
			// 
			this.NewItem_ImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "NewItem_ImageList.ImageStream" ) ) );
			this.NewItem_ImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.NewItem_ImageList.Images.SetKeyName( 0, "Templates.png" );
			// 
			// Templates_Label
			// 
			this.Templates_Label.Dock = System.Windows.Forms.DockStyle.Top;
			this.Templates_Label.Location = new System.Drawing.Point( 0, 0 );
			this.Templates_Label.Name = "Templates_Label";
			this.Templates_Label.Size = new System.Drawing.Size( 396, 23 );
			this.Templates_Label.TabIndex = 0;
			this.Templates_Label.Text = "Templates:";
			// 
			// Description_TextBox
			// 
			this.Description_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Description_TextBox.Location = new System.Drawing.Point( 0, 0 );
			this.Description_TextBox.Name = "Description_TextBox";
			this.Description_TextBox.ReadOnly = true;
			this.Description_TextBox.Size = new System.Drawing.Size( 640, 22 );
			this.Description_TextBox.TabIndex = 0;
			this.Description_TextBox.Text = "Description";
			// 
			// NewItemSelectionPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.Main_SplitContainer );
			this.Name = "NewItemSelectionPanel";
			this.Size = new System.Drawing.Size( 640, 360 );
			this.Main_SplitContainer.Panel1.ResumeLayout( false );
			this.Main_SplitContainer.Panel2.ResumeLayout( false );
			this.Main_SplitContainer.Panel2.PerformLayout();
			this.Main_SplitContainer.ResumeLayout( false );
			this.Category_SplitContainer.Panel1.ResumeLayout( false );
			this.Category_SplitContainer.Panel2.ResumeLayout( false );
			this.Category_SplitContainer.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.SplitContainer Main_SplitContainer;
		private System.Windows.Forms.TextBox Description_TextBox;
		private System.Windows.Forms.SplitContainer Category_SplitContainer;
		private System.Windows.Forms.Label Categories_Label;
		private System.Windows.Forms.Label Templates_Label;
		private System.Windows.Forms.TreeView Categories_TreeView;
		private System.Windows.Forms.ListView Templates_ListView;
		private System.Windows.Forms.ImageList NewItem_ImageList;
	}
}
