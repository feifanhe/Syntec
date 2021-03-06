namespace ActionsSelector
{
	partial class ActionsSelectDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ActionsSelectDialog ) );
			this.Category_Label = new System.Windows.Forms.Label();
			this.Category_Panel = new System.Windows.Forms.Panel();
			this.Category_ListView = new System.Windows.Forms.ListView();
			this.Description_Panel = new System.Windows.Forms.Panel();
			this.Form_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.Add_Button = new System.Windows.Forms.Button();
			this.Description_TextBox = new System.Windows.Forms.TextBox();
			this.Description_Label = new System.Windows.Forms.Label();
			this.Actions_Panel = new System.Windows.Forms.Panel();
			this.Delete_Button = new System.Windows.Forms.Button();
			this.Down_Button = new System.Windows.Forms.Button();
			this.Up_Button = new System.Windows.Forms.Button();
			this.Actions_ListView = new System.Windows.Forms.ListView();
			this.Actions_Label = new System.Windows.Forms.Label();
			this.Cancel_Button = new System.Windows.Forms.Button();
			this.OK_Button = new System.Windows.Forms.Button();
			this.Category_Panel.SuspendLayout();
			this.Description_Panel.SuspendLayout();
			this.Actions_Panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// Category_Label
			// 
			this.Category_Label.AutoSize = true;
			this.Category_Label.Location = new System.Drawing.Point( 3, 0 );
			this.Category_Label.Name = "Category_Label";
			this.Category_Label.Size = new System.Drawing.Size( 57, 12 );
			this.Category_Label.TabIndex = 0;
			this.Category_Label.Text = "Categories:";
			// 
			// Category_Panel
			// 
			this.Category_Panel.Controls.Add( this.Category_ListView );
			this.Category_Panel.Controls.Add( this.Category_Label );
			this.Category_Panel.Location = new System.Drawing.Point( 12, 12 );
			this.Category_Panel.Name = "Category_Panel";
			this.Category_Panel.Size = new System.Drawing.Size( 286, 466 );
			this.Category_Panel.TabIndex = 1;
			// 
			// Category_ListView
			// 
			this.Category_ListView.HideSelection = false;
			this.Category_ListView.Location = new System.Drawing.Point( 3, 15 );
			this.Category_ListView.MultiSelect = false;
			this.Category_ListView.Name = "Category_ListView";
			this.Category_ListView.Size = new System.Drawing.Size( 280, 448 );
			this.Category_ListView.TabIndex = 1;
			this.Category_ListView.UseCompatibleStateImageBehavior = false;
			this.Category_ListView.View = System.Windows.Forms.View.Tile;
			this.Category_ListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler( this.Category_ListView_ItemSelectionChanged );
			// 
			// Description_Panel
			// 
			this.Description_Panel.Controls.Add( this.Form_FlowLayoutPanel );
			this.Description_Panel.Controls.Add( this.Add_Button );
			this.Description_Panel.Controls.Add( this.Description_TextBox );
			this.Description_Panel.Controls.Add( this.Description_Label );
			this.Description_Panel.Location = new System.Drawing.Point( 304, 12 );
			this.Description_Panel.Name = "Description_Panel";
			this.Description_Panel.Size = new System.Drawing.Size( 306, 466 );
			this.Description_Panel.TabIndex = 2;
			// 
			// Form_FlowLayoutPanel
			// 
			this.Form_FlowLayoutPanel.Location = new System.Drawing.Point( 5, 246 );
			this.Form_FlowLayoutPanel.Name = "Form_FlowLayoutPanel";
			this.Form_FlowLayoutPanel.Size = new System.Drawing.Size( 298, 188 );
			this.Form_FlowLayoutPanel.TabIndex = 3;
			// 
			// Add_Button
			// 
			this.Add_Button.Location = new System.Drawing.Point( 228, 440 );
			this.Add_Button.Name = "Add_Button";
			this.Add_Button.Size = new System.Drawing.Size( 75, 23 );
			this.Add_Button.TabIndex = 2;
			this.Add_Button.Text = "Add";
			this.Add_Button.UseVisualStyleBackColor = true;
			this.Add_Button.Click += new System.EventHandler( this.Add_Button_Click );
			// 
			// Description_TextBox
			// 
			this.Description_TextBox.AcceptsReturn = true;
			this.Description_TextBox.AcceptsTab = true;
			this.Description_TextBox.Location = new System.Drawing.Point( 3, 15 );
			this.Description_TextBox.Multiline = true;
			this.Description_TextBox.Name = "Description_TextBox";
			this.Description_TextBox.ReadOnly = true;
			this.Description_TextBox.Size = new System.Drawing.Size( 300, 225 );
			this.Description_TextBox.TabIndex = 1;
			// 
			// Description_Label
			// 
			this.Description_Label.AutoSize = true;
			this.Description_Label.Location = new System.Drawing.Point( 3, 0 );
			this.Description_Label.Name = "Description_Label";
			this.Description_Label.Size = new System.Drawing.Size( 61, 12 );
			this.Description_Label.TabIndex = 0;
			this.Description_Label.Text = "Description:";
			// 
			// Actions_Panel
			// 
			this.Actions_Panel.Controls.Add( this.Delete_Button );
			this.Actions_Panel.Controls.Add( this.Down_Button );
			this.Actions_Panel.Controls.Add( this.Up_Button );
			this.Actions_Panel.Controls.Add( this.Actions_ListView );
			this.Actions_Panel.Controls.Add( this.Actions_Label );
			this.Actions_Panel.Location = new System.Drawing.Point( 616, 12 );
			this.Actions_Panel.Name = "Actions_Panel";
			this.Actions_Panel.Size = new System.Drawing.Size( 326, 466 );
			this.Actions_Panel.TabIndex = 3;
			// 
			// Delete_Button
			// 
			this.Delete_Button.Image = ( (System.Drawing.Image)( resources.GetObject( "Delete_Button.Image" ) ) );
			this.Delete_Button.Location = new System.Drawing.Point( 291, 91 );
			this.Delete_Button.Name = "Delete_Button";
			this.Delete_Button.Size = new System.Drawing.Size( 32, 32 );
			this.Delete_Button.TabIndex = 4;
			this.Delete_Button.UseVisualStyleBackColor = true;
			this.Delete_Button.Click += new System.EventHandler( this.Delete_Button_Click );
			// 
			// Down_Button
			// 
			this.Down_Button.Image = ( (System.Drawing.Image)( resources.GetObject( "Down_Button.Image" ) ) );
			this.Down_Button.Location = new System.Drawing.Point( 291, 53 );
			this.Down_Button.Name = "Down_Button";
			this.Down_Button.Size = new System.Drawing.Size( 32, 32 );
			this.Down_Button.TabIndex = 3;
			this.Down_Button.UseVisualStyleBackColor = true;
			this.Down_Button.Click += new System.EventHandler( this.Down_Button_Click );
			// 
			// Up_Button
			// 
			this.Up_Button.Image = ( (System.Drawing.Image)( resources.GetObject( "Up_Button.Image" ) ) );
			this.Up_Button.Location = new System.Drawing.Point( 291, 15 );
			this.Up_Button.Name = "Up_Button";
			this.Up_Button.Size = new System.Drawing.Size( 32, 32 );
			this.Up_Button.TabIndex = 2;
			this.Up_Button.UseVisualStyleBackColor = true;
			this.Up_Button.Click += new System.EventHandler( this.Up_Button_Click );
			// 
			// Actions_ListView
			// 
			this.Actions_ListView.Font = new System.Drawing.Font( "PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.Actions_ListView.HideSelection = false;
			this.Actions_ListView.Location = new System.Drawing.Point( 5, 15 );
			this.Actions_ListView.Name = "Actions_ListView";
			this.Actions_ListView.Size = new System.Drawing.Size( 280, 448 );
			this.Actions_ListView.TabIndex = 1;
			this.Actions_ListView.UseCompatibleStateImageBehavior = false;
			this.Actions_ListView.View = System.Windows.Forms.View.List;
			// 
			// Actions_Label
			// 
			this.Actions_Label.AutoSize = true;
			this.Actions_Label.Location = new System.Drawing.Point( 3, 0 );
			this.Actions_Label.Name = "Actions_Label";
			this.Actions_Label.Size = new System.Drawing.Size( 43, 12 );
			this.Actions_Label.TabIndex = 0;
			this.Actions_Label.Text = "Actions:";
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel_Button.Location = new System.Drawing.Point( 867, 484 );
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size( 75, 23 );
			this.Cancel_Button.TabIndex = 4;
			this.Cancel_Button.Text = "Cancel";
			this.Cancel_Button.UseVisualStyleBackColor = true;
			// 
			// OK_Button
			// 
			this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK_Button.Location = new System.Drawing.Point( 786, 484 );
			this.OK_Button.Name = "OK_Button";
			this.OK_Button.Size = new System.Drawing.Size( 75, 23 );
			this.OK_Button.TabIndex = 5;
			this.OK_Button.Text = "OK";
			this.OK_Button.UseVisualStyleBackColor = true;
			this.OK_Button.Click += new System.EventHandler( this.OK_Button_Click );
			// 
			// ActionsSelectDialog
			// 
			this.AcceptButton = this.OK_Button;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size( 954, 519 );
			this.Controls.Add( this.OK_Button );
			this.Controls.Add( this.Cancel_Button );
			this.Controls.Add( this.Actions_Panel );
			this.Controls.Add( this.Description_Panel );
			this.Controls.Add( this.Category_Panel );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ActionsSelectDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Actions";
			this.Category_Panel.ResumeLayout( false );
			this.Category_Panel.PerformLayout();
			this.Description_Panel.ResumeLayout( false );
			this.Description_Panel.PerformLayout();
			this.Actions_Panel.ResumeLayout( false );
			this.Actions_Panel.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Label Category_Label;
		private System.Windows.Forms.Panel Category_Panel;
		private System.Windows.Forms.ListView Category_ListView;
		private System.Windows.Forms.Panel Description_Panel;
		private System.Windows.Forms.TextBox Description_TextBox;
		private System.Windows.Forms.Label Description_Label;
		private System.Windows.Forms.Button Add_Button;
		private System.Windows.Forms.Panel Actions_Panel;
		private System.Windows.Forms.ListView Actions_ListView;
		private System.Windows.Forms.Label Actions_Label;
		private System.Windows.Forms.Button Cancel_Button;
		private System.Windows.Forms.Button OK_Button;
		private System.Windows.Forms.FlowLayoutPanel Form_FlowLayoutPanel;
		private System.Windows.Forms.Button Up_Button;
		private System.Windows.Forms.Button Down_Button;
		private System.Windows.Forms.Button Delete_Button;
	}
}