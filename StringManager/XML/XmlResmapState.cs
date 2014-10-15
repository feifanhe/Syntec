using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;

namespace StringManager.XML
{
	[XmlRoot( "ResMap" )]
	public class XmlResmapState
	{
		private string _Filename;
		[XmlIgnore]
		public string Filename
		{
			get
			{
				return this._Filename;
			}
			set
			{
				this._Filename = value;
			}
		}

		private List<XmlMessageState> _IncludedMessages = new List<XmlMessageState>();
		[XmlElement( "Message" )]
		[Browsable( false )]
		public List<XmlMessageState> IncludedMessages
		{
			get
			{
				return _IncludedMessages;
			}
			set
			{
				_IncludedMessages = value;
			}
		}
	}
}
