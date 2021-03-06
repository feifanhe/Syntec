using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ActionsSelector
{
	public partial class ActionsSelectDialog : Form
	{
		const int LARGE_FORM_WIDTH = 295;
		const int MEDIUM_FORM_WIDTH = 143;
		const int SMALL_FORM_WIDTH = 68;

		private List<string> _Actions;

		public ActionsSelectDialog()
		{
			InitializeComponent();
			LoadConfigXml();
		}

		public DialogResult ShowDialog( List<string> actions )
		{
			this._Actions = actions;
			foreach( string action in actions ) {
				this.Actions_ListView.Items.Add( action );
			}
			return this.ShowDialog();
		}

		private void LoadConfigXml()
		{
			XmlDocument document = new XmlDocument();

			try {
				document.Load( "Definitions\\ActionList.xml" );
			}
			catch( Exception ) {
			}

			XmlElement root = document.DocumentElement;

			foreach( XmlElement category in root.ChildNodes ) {
				PopulateCategory( category );
			}
		}

		private void PopulateCategory( XmlElement category )
		{
			string categoryName = category.GetAttribute( "name" );
			ListViewGroup group = new ListViewGroup( categoryName );
			this.Category_ListView.Groups.Add( group );

			foreach( XmlElement action in category.ChildNodes ) {
				PopulateAction( group, action );
			}
		}

		private void PopulateAction( ListViewGroup group, XmlElement action )
		{
			string actionName = action.GetAttribute( "name" );
			ListViewItem item = new ListViewItem( actionName, group );
			this.Category_ListView.Items.Add( item );
			item.Tag = action;
		}

		private void Category_ListView_ItemSelectionChanged( object sender, ListViewItemSelectionChangedEventArgs e )
		{
			XmlElement action = e.Item.Tag as XmlElement;
			PopulateDescription( action );
			PopulateForm( action );
		}

		private void PopulateDescription( XmlElement action )
		{
			XmlNodeList children = action.GetElementsByTagName( "Description" );
			this.Description_TextBox.Text = string.Empty;
			if( children.Count > 0 ) {
				this.Description_TextBox.Text = children[ 0 ].InnerText;
			}
		}

		private void PopulateForm( XmlElement action )
		{
			XmlNodeList children = action.GetElementsByTagName( "Form" );
			this.Form_FlowLayoutPanel.Controls.Clear();
			if( children.Count > 0 ) {
				foreach( XmlElement control in children[ 0 ].ChildNodes ) {
					PopulateControl( control );
				}
			}
		}

		private void PopulateControl( XmlElement control )
		{
			Control template;

			switch( control.Name ) {
				case "TextBox":
					template = new TextBox();
					break;
				default:
					return;
			}

			switch( control.GetAttribute( "size" ) ) {
				case "large":
					template.Width = LARGE_FORM_WIDTH;
					break;
				case "medium":
					template.Width = MEDIUM_FORM_WIDTH;
					break;
				case "small":
					template.Width = SMALL_FORM_WIDTH;
					break;
				default:
					template.Width = LARGE_FORM_WIDTH;
					break;
			}

			template.Tag = control;

			this.Form_FlowLayoutPanel.Controls.Add( template );
		}

		private void AddAction()
		{
			if( this.Category_ListView.SelectedItems.Count > 0 ) {
				ListViewItem item = this.Category_ListView.SelectedItems[ 0 ];
				XmlElement tag = item.Tag as XmlElement;
				StringBuilder action = new StringBuilder();
				action.Append( tag.GetAttribute( "value" ) );
				
				foreach( Control template in this.Form_FlowLayoutPanel.Controls ) {
					XmlElement control = template.Tag as XmlElement;
					
					if( control.GetAttribute( "null" ) == "false" && template.Text == string.Empty ) {
						MessageBox.Show( "Invalid value." );
						return;	
					}
					
					action.Append( control.GetAttribute( "separator" ) );
					action.Append( control.GetAttribute( "prefix" ) );
					action.Append( template.Text );
					action.Append( control.GetAttribute( "postfix" ) );
				}

				this.Actions_ListView.Items.Add( action.ToString() );
			}
		}

		private void SetActions()
		{
			this._Actions.Clear();
			foreach( ListViewItem action in this.Actions_ListView.Items ) {
				this._Actions.Add( action.Text );
			}
		}

		private void Add_Button_Click( object sender, EventArgs e )
		{
			AddAction();
		}

		private void OK_Button_Click( object sender, EventArgs e )
		{
			SetActions();
		}

		private void Up_Button_Click( object sender, EventArgs e )
		{
			if( this.Actions_ListView.SelectedItems.Count > 0 ) {
				ListViewItem item = this.Actions_ListView.SelectedItems[ 0 ];
				int index = this.Actions_ListView.Items.IndexOf( item );

				if( index > 0 ) {
					this.Actions_ListView.Items.RemoveAt( index );
					this.Actions_ListView.Items.Insert( index - 1, item );
				}
			}
		}

		private void Down_Button_Click( object sender, EventArgs e )
		{
			if( this.Actions_ListView.SelectedItems.Count > 0 ) {
				ListViewItem item = this.Actions_ListView.SelectedItems[ 0 ];
				int index = this.Actions_ListView.Items.IndexOf( item );

				if( index < this.Actions_ListView.Items.Count - 1 ) {
					this.Actions_ListView.Items.RemoveAt( index );
					this.Actions_ListView.Items.Insert( index + 1, item );
				}
			}
		}

		private void Delete_Button_Click( object sender, EventArgs e )
		{
			if( this.Actions_ListView.SelectedItems.Count > 0 ) {
				ListViewItem item = this.Actions_ListView.SelectedItems[ 0 ];
				int index = this.Actions_ListView.Items.IndexOf( item );

				if( index >= 0 ) {
					this.Actions_ListView.Items.RemoveAt( index );
				}
			}
		}
	}
}