using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;

namespace StringManager.XML
{
	public class XmlMessageState
	{
		private XmlResmapState _Parent;
		[XmlIgnore]
		public XmlResmapState Parent
		{
			get
			{
				return this._Parent;
			}
			set
			{
				this._Parent = value;
			}
		}

		private string _ID;
		[XmlAttribute( "ID" )]
		public string ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		private string _Content;
		[XmlAttribute( "Content" )]
		public string Content
		{
			get
			{
				return _Content;
			}
			set
			{
				_Content = value;
			}
		}
	}
}
