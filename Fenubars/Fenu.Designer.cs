namespace Fenubars
{
	partial class Fenu
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
			this.normalButton1 = new NormalButton();
			this.SuspendLayout();
			// 
			// normalButton1
			// 
			this.normalButton1.action = null;
			this.normalButton1.actions = null;
			this.normalButton1.alignment = 0;
			this.normalButton1.alignmentSpecified = false;
			this.normalButton1.backcolor = null;
			this.normalButton1.enablerule = null;
			this.normalButton1.forecolor = null;
			this.normalButton1.holdmode = false;
			this.normalButton1.holdmodeSpecified = false;
			this.normalButton1.invisibledevice = null;
			this.normalButton1.lightoncolor = null;
			this.normalButton1.link = null;
			this.normalButton1.Location = new System.Drawing.Point( 300, 67 );
			this.normalButton1.name = null;
			this.normalButton1.Name = "normalButton1";
			this.normalButton1.picture = null;
			this.normalButton1.position = 0;
			this.normalButton1.positionSpecified = false;
			this.normalButton1.pwd = null;
			this.normalButton1.Size = new System.Drawing.Size( 75, 23 );
			this.normalButton1.state = State.enable;
			this.normalButton1.stateSpecified = false;
			this.normalButton1.TabIndex = 0;
			this.normalButton1.Text = "normalButton1";
			this.normalButton1.title = "";
			this.normalButton1.userlevel = 0;
			this.normalButton1.userlevelSpecified = false;
			this.normalButton1.UseVisualStyleBackColor = true;
			this.normalButton1.visible = false;
			this.normalButton1.visibleSpecified = false;
			// 
			// Fenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.normalButton1 );
			this.Name = "Fenu";
			this.Size = new System.Drawing.Size( 769, 152 );
			this.ResumeLayout( false );

		}

		#endregion

		private NormalButton normalButton1;



	}
}
