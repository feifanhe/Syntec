namespace Syntec.Windows
{
	partial class NewFileDialog
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
			this.SelectionPanel = new Syntec.Windows.NewItemSelectionPanel();
			this.ButtonPanel = new System.Windows.Forms.Panel();
			this.OK_Button = new System.Windows.Forms.Button();
			this.Cancel_Button = new System.Windows.Forms.Button();
			this.ButtonPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// SelectionPanel
			// 
			this.SelectionPanel.Location = new System.Drawing.Point( 12, 12 );
			this.SelectionPanel.Name = "SelectionPanel";
			this.SelectionPanel.Size = new System.Drawing.Size( 640, 360 );
			this.SelectionPanel.TabIndex = 0;
			// 
			// ButtonPanel
			// 
			this.ButtonPanel.Controls.Add( this.OK_Button );
			this.ButtonPanel.Controls.Add( this.Cancel_Button );
			this.ButtonPanel.Location = new System.Drawing.Point( 12, 378 );
			this.ButtonPanel.Name = "ButtonPanel";
			this.ButtonPanel.Size = new System.Drawing.Size( 640, 29 );
			this.ButtonPanel.TabIndex = 1;
			// 
			// OK_Button
			// 
			this.OK_Button.Location = new System.Drawing.Point( 481, 3 );
			this.OK_Button.Name = "OK_Button";
			this.OK_Button.Size = new System.Drawing.Size( 75, 23 );
			this.OK_Button.TabIndex = 1;
			this.OK_Button.Text = "OK";
			this.OK_Button.UseVisualStyleBackColor = true;
			this.OK_Button.Click += new System.EventHandler( this.OK_Button_Click );
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.Location = new System.Drawing.Point( 562, 3 );
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size( 75, 23 );
			this.Cancel_Button.TabIndex = 0;
			this.Cancel_Button.Text = "Cancel";
			this.Cancel_Button.UseVisualStyleBackColor = true;
			this.Cancel_Button.Click += new System.EventHandler( this.Cancel_Button_Click );
			// 
			// NewFileDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 664, 419 );
			this.Controls.Add( this.ButtonPanel );
			this.Controls.Add( this.SelectionPanel );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NewFileDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New File";
			this.ButtonPanel.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private NewItemSelectionPanel SelectionPanel;
		private System.Windows.Forms.Panel ButtonPanel;
		private System.Windows.Forms.Button OK_Button;
		private System.Windows.Forms.Button Cancel_Button;
	}
}