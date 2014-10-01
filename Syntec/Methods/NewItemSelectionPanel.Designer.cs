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
			this.Main_SplitContainer = new System.Windows.Forms.SplitContainer();
			this.Category_SplitContainer = new System.Windows.Forms.SplitContainer();
			this.Category_TreeView = new System.Windows.Forms.TreeView();
			this.Category_Label = new System.Windows.Forms.Label();
			this.Template_ListView = new System.Windows.Forms.ListView();
			this.Template_Label = new System.Windows.Forms.Label();
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
			this.Category_SplitContainer.Panel1.Controls.Add( this.Category_TreeView );
			this.Category_SplitContainer.Panel1.Controls.Add( this.Category_Label );
			// 
			// Category_SplitContainer.Panel2
			// 
			this.Category_SplitContainer.Panel2.Controls.Add( this.Template_ListView );
			this.Category_SplitContainer.Panel2.Controls.Add( this.Template_Label );
			this.Category_SplitContainer.Size = new System.Drawing.Size( 640, 330 );
			this.Category_SplitContainer.SplitterDistance = 240;
			this.Category_SplitContainer.TabIndex = 0;
			// 
			// Category_TreeView
			// 
			this.Category_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Category_TreeView.Location = new System.Drawing.Point( 0, 23 );
			this.Category_TreeView.Name = "Category_TreeView";
			this.Category_TreeView.Size = new System.Drawing.Size( 240, 307 );
			this.Category_TreeView.TabIndex = 1;
			this.Category_TreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler( this.Category_TreeView_NodeMouseClick );
			// 
			// Category_Label
			// 
			this.Category_Label.Dock = System.Windows.Forms.DockStyle.Top;
			this.Category_Label.Location = new System.Drawing.Point( 0, 0 );
			this.Category_Label.Name = "Category_Label";
			this.Category_Label.Size = new System.Drawing.Size( 240, 23 );
			this.Category_Label.TabIndex = 0;
			this.Category_Label.Text = "Categories:";
			// 
			// Template_ListView
			// 
			this.Template_ListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Template_ListView.Location = new System.Drawing.Point( 0, 23 );
			this.Template_ListView.MultiSelect = false;
			this.Template_ListView.Name = "Template_ListView";
			this.Template_ListView.Size = new System.Drawing.Size( 396, 307 );
			this.Template_ListView.TabIndex = 1;
			this.Template_ListView.UseCompatibleStateImageBehavior = false;
			this.Template_ListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler( this.Template_ListView_ItemChecked );
			// 
			// Template_Label
			// 
			this.Template_Label.Dock = System.Windows.Forms.DockStyle.Top;
			this.Template_Label.Location = new System.Drawing.Point( 0, 0 );
			this.Template_Label.Name = "Template_Label";
			this.Template_Label.Size = new System.Drawing.Size( 396, 23 );
			this.Template_Label.TabIndex = 0;
			this.Template_Label.Text = "Templates:";
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
		private System.Windows.Forms.Label Category_Label;
		private System.Windows.Forms.Label Template_Label;
		private System.Windows.Forms.TreeView Category_TreeView;
		private System.Windows.Forms.ListView Template_ListView;
	}
}
