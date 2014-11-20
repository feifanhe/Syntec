using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Ookii.Dialogs;
using System.Reflection;

namespace Syntec.Windows
{
	public partial class NewItemInputPanel : UserControl
	{
		public enum NewWorkspaceSolutionType
		{
			[Description( "Create new Res folder" )]
			CreateNewResFolder,
			[Description( "Add to existing Res folder" )]
			AddToExistingResFolder
		};

		#region Properties

		public string SelectedPath
		{
			get
			{
				return this.Location_Text.Text;
			}
		}

		public NewWorkspaceSolutionType SelectedSolution
		{
			get
			{
				return (NewWorkspaceSolutionType)this.Solution_ComboBox.SelectedValue;
			}
		}

		#endregion

		#region Constructor

		public NewItemInputPanel()
		{
			InitializeComponent();
			this.SetSolution();
			this.Solution_ComboBox.SelectedIndex = 0;
		}


		private void SetSolution()
		{
			List<KeyValuePair<Enum, string>> solutionList = new List<KeyValuePair<Enum, string>>();
			Array solutionValues = Enum.GetValues( typeof( NewWorkspaceSolutionType ) );

			foreach( Enum value in solutionValues ) {
				string description = value.ToString();
				FieldInfo fieldInfo = value.GetType().GetField( description );
				DescriptionAttribute[] attributes =
					(DescriptionAttribute[])
					fieldInfo.GetCustomAttributes( typeof( DescriptionAttribute ), false );

				if( attributes != null && attributes.Length > 0 ) {
					description = attributes[ 0 ].Description;
				}

				solutionList.Add( new KeyValuePair<Enum, string>( value, description ) );
			}

			this.Solution_ComboBox.DataSource = solutionList;
			this.Solution_ComboBox.DisplayMember = "Value";
			this.Solution_ComboBox.ValueMember = "Key";
		}

		#endregion

		#region Button Click

		private void Browser_Button_Click( object sender, EventArgs e )
		{
			VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
			if( dialog.ShowDialog() == DialogResult.OK ) {
				this.Location_Text.Text = dialog.SelectedPath;
			}
		}

		#endregion
	}
}
