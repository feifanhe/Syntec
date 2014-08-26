namespace Syntec.Windows
{
	partial class WorkspaceExplorer
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( ) {
			this.Workspace_ToolStrip = new System.Windows.Forms.ToolStrip();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.Workspace_Separator_1 = new System.Windows.Forms.ToolStripSeparator();
			this.Refresh_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ShowAll_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ViewCode_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ViewDesigner_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ViewStructure_ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.Workspace_ToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// Workspace_ToolStrip
			// 
			this.Workspace_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.Workspace_ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.ShowAll_ToolStripButton,
            this.Refresh_ToolStripButton,
            this.Workspace_Separator_1,
            this.ViewCode_ToolStripButton,
            this.ViewDesigner_ToolStripButton,
            this.ViewStructure_ToolStripButton} );
			this.Workspace_ToolStrip.Location = new System.Drawing.Point( 0, 0 );
			this.Workspace_ToolStrip.Name = "Workspace_ToolStrip";
			this.Workspace_ToolStrip.Size = new System.Drawing.Size( 248, 25 );
			this.Workspace_ToolStrip.TabIndex = 0;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new System.Drawing.Point( 0, 25 );
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size( 248, 301 );
			this.treeView1.TabIndex = 1;
			// 
			// Workspace_Separator_1
			// 
			this.Workspace_Separator_1.Name = "Workspace_Separator_1";
			this.Workspace_Separator_1.Size = new System.Drawing.Size( 6, 25 );
			// 
			// Refresh_ToolStripButton
			// 
			this.Refresh_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.Refresh_ToolStripButton.Image = global::Syntec.Properties.Resources.Refresh;
			this.Refresh_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Refresh_ToolStripButton.Name = "Refresh_ToolStripButton";
			this.Refresh_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.Refresh_ToolStripButton.Text = "toolStripButton4";
			// 
			// ShowAll_ToolStripButton
			// 
			this.ShowAll_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ShowAll_ToolStripButton.Image = global::Syntec.Properties.Resources.ShowAllFiles_349_32;
			this.ShowAll_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ShowAll_ToolStripButton.Name = "ShowAll_ToolStripButton";
			this.ShowAll_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.ShowAll_ToolStripButton.Text = "toolStripButton5";
			// 
			// ViewCode_ToolStripButton
			// 
			this.ViewCode_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ViewCode_ToolStripButton.Image = global::Syntec.Properties.Resources.Control_ViewCode;
			this.ViewCode_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ViewCode_ToolStripButton.Name = "ViewCode_ToolStripButton";
			this.ViewCode_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.ViewCode_ToolStripButton.Text = "toolStripButton1";
			// 
			// ViewDesigner_ToolStripButton
			// 
			this.ViewDesigner_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ViewDesigner_ToolStripButton.Image = global::Syntec.Properties.Resources.ViewDesigner_6280_32;
			this.ViewDesigner_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ViewDesigner_ToolStripButton.Name = "ViewDesigner_ToolStripButton";
			this.ViewDesigner_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.ViewDesigner_ToolStripButton.Text = "toolStripButton2";
			// 
			// ViewStructure_ToolStripButton
			// 
			this.ViewStructure_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ViewStructure_ToolStripButton.Image = global::Syntec.Properties.Resources.OrgchartHS;
			this.ViewStructure_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ViewStructure_ToolStripButton.Name = "ViewStructure_ToolStripButton";
			this.ViewStructure_ToolStripButton.Size = new System.Drawing.Size( 23, 22 );
			this.ViewStructure_ToolStripButton.Text = "toolStripButton3";
			// 
			// WorkspaceExplorer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 248, 326 );
			this.Controls.Add( this.treeView1 );
			this.Controls.Add( this.Workspace_ToolStrip );
			this.Name = "WorkspaceExplorer";
			this.Text = "WorkspaceExplorer";
			this.Workspace_ToolStrip.ResumeLayout( false );
			this.Workspace_ToolStrip.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip Workspace_ToolStrip;
		private System.Windows.Forms.ToolStripButton ViewCode_ToolStripButton;
		private System.Windows.Forms.ToolStripButton ViewDesigner_ToolStripButton;
		private System.Windows.Forms.ToolStripButton ViewStructure_ToolStripButton;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ToolStripSeparator Workspace_Separator_1;
		private System.Windows.Forms.ToolStripButton Refresh_ToolStripButton;
		private System.Windows.Forms.ToolStripButton ShowAll_ToolStripButton;
	}
}