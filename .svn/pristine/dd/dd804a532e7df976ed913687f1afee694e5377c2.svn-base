using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Syntec.Methods
{
	public partial class SearchDialog : Form
	{
		public enum SearchScopeType
		{
			[Description( "Current Document" )]
			CurrentDocument,
			[Description( "All Open Document" )]
			AllOpenDocument
		};

		#region Properties

		public string Keyword
		{
			get
			{
				return this.txtKeyword.Text;
			}
		}

		public bool MatchCase
		{
			get
			{
				return this.chkMatchCase.Checked;
			}
		}

		public bool MatchWholeWord
		{
			get
			{
				return this.chkMatchWholeWord.Checked;
			}
		}

		public SearchScopeType SearchScope
		{
			get
			{
				return (SearchScopeType)this.cbbSearchScope.SelectedValue;
			}
		}

		#endregion

		#region Constructor

		public SearchDialog()
		{
			InitializeComponent();
			// Bind combobox data with SearchScope
			SetSearchScope();

		}

		public void SetSearchScope()
		{
			List<KeyValuePair<Enum, string>> searchScopeList = new List<KeyValuePair<Enum, string>>();
			Array searchScopeValues = Enum.GetValues( typeof( SearchScopeType ) );

			foreach( Enum value in searchScopeValues ) {
				string description = value.ToString();
				FieldInfo fieldInfo = value.GetType().GetField( description );
				DescriptionAttribute[] attributes = 
					(DescriptionAttribute[])
					fieldInfo.GetCustomAttributes( typeof( DescriptionAttribute ), false );

				if( attributes != null && attributes.Length > 0 ) {
					description = attributes[ 0 ].Description;
				}

				searchScopeList.Add( new KeyValuePair<Enum, string>( value, description ) );
			}


			cbbSearchScope.DataSource = searchScopeList;
			cbbSearchScope.DisplayMember = "Value";
			cbbSearchScope.ValueMember = "Key";
		}

		#endregion

	}
}