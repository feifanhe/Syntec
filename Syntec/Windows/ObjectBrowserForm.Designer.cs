namespace Syntec.Windows
{
	partial class ObjectBrowserForm
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
			this.Object_TreeView = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// Object_TreeView
			// 
			this.Object_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Object_TreeView.Location = new System.Drawing.Point( 0, 0 );
			this.Object_TreeView.Name = "Object_TreeView";
			this.Object_TreeView.Size = new System.Drawing.Size( 248, 326 );
			this.Object_TreeView.TabIndex = 0;
			// 
			// ObjectBrowserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 248, 326 );
			this.Controls.Add( this.Object_TreeView );
			this.Name = "ObjectBrowserForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Object Browser";
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.TreeView Object_TreeView;
	}
}