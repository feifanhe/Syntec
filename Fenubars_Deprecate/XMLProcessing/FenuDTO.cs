using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace Fenubars
{
	[Serializable]
	//[XmlType( Namespace = "Fenubars" )]
	[XmlRoot( ElementName = "root", IsNullable = true )]
	public class FenusProperties
	{

		private bool _NoLR;
		private bool _NoLR_Specified;
		private bool _Button3D;
		private bool _Button3D_Specified;
		private int _Level3D;
		private bool _Level3D_Sepecified;
		private bool _TextOverPic;
		private bool _TextOverPic_Specified;
		private bool _NoFunc;
		private bool _NoFunc_Specified;
		private bool _BigLR;
		private bool _BigLR_Specified;
		private int _Alignment;
		private bool _Alignment_Specified;
		private List<FenuProperties> _Fenus;

		public bool NoLR {
			get {
				return this._NoLR;
			}
			set {
				this._NoLR = value;
			}
		}
		[XmlIgnore]
		public bool NoLRSpecified {
			get {
				return this._NoLR_Specified;
			}
			set {
				this._NoLR_Specified = value;
			}
		}

		public bool Button3D {
			get {
				return this._Button3D;
			}
			set {
				this._Button3D = value;
			}
		}
		[XmlIgnore]
		public bool Button3DSpecified {
			get {
				return this._Button3D_Specified;
			}
			set {
				this._Button3D_Specified = value;
			}
		}

		public int Level3D {
			get {
				return this._Level3D;
			}
			set {
				this._Level3D = value;
			}
		}
		[XmlIgnore]
		public bool Level3DSpecified {
			get {
				return this._Level3D_Sepecified;
			}
			set {
				this._Level3D_Sepecified = value;
			}
		}

		public bool TextOverPic {
			get {
				return this._TextOverPic;
			}
			set {
				this._TextOverPic = value;
			}
		}
		[XmlIgnore]
		public bool TextOverPicSpecified {
			get {
				return this._TextOverPic_Specified;
			}
			set {
				this._TextOverPic_Specified = value;
			}
		}

		public bool NoFunc {
			get {
				return this._NoFunc;
			}
			set {
				this._NoFunc = value;
			}
		}
		[XmlIgnore]
		public bool NoFuncSpecified {
			get {
				return this._NoFunc_Specified;
			}
			set {
				this._NoFunc_Specified = value;
			}
		}

		public bool BigLR {
			get {
				return this._BigLR;
			}
			set {
				this._BigLR = value;
			}
		}
		[XmlIgnore]
		public bool BigLRSpecified {
			get {
				return this._BigLR_Specified;
			}
			set {
				this._BigLR_Specified = value;
			}
		}

		public int Alignment {
			get {
				return this._Alignment;
			}
			set {
				this._Alignment = value;
			}
		}
		[XmlIgnore]
		public bool AlignmentSpecified {
			get {
				return this._Alignment_Specified;
			}
			set {
				this._Alignment_Specified = value;
			}
		}

		[XmlElement( "fenu" )]
		public List<FenuProperties> Fenus {
			get {
				return this._Fenus;
			}
			set {
				this._Fenus = value;
			}
		}
	}

	[Serializable]
	public class FenuProperties
	{
		//private EscapeButtonProperties _EscapeButton;
		private List<NormalButtonProperties> _NormalButton;
		//private NextButtonProperties _NextButton;
		private string _Name;

		//public EscapeButtonProperties escape {
		//    get {
		//        return this._EscapeButton;
		//    }
		//    set {
		//        this._EscapeButton = value;
		//    }
		//}

		[XmlElement( "button" )]
		public List<NormalButtonProperties> NormalButton {
			get {
				return this._NormalButton;
			}
			set {
				this._NormalButton = value;
			}
		}

		//public NextButtonProperties next {
		//    get {
		//        return this._NextButton;
		//    }
		//    set {
		//        this._NextButton = value;
		//    }
		//}

		[XmlAttribute( "name" )]
		public string Name {
			get {
				return this._Name;
			}
			set {
				this._Name = value;
			}
		}
	}

	[Serializable]
	//[XmlTypeAttribute( Namespace = "Fenubars" )]
	public enum State
	{
		enable,
		disable,
	}

	[Serializable]
	//[XmlTypeAttribute( Namespace = "Fenubars" )]
	public class PwdActions
	{

		private int valueField;
		private ActionCollection corField;
		private ActionCollection incorField;

		/// <remarks/>
		public int value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}

		/// <remarks/>
		public ActionCollection cor {
			get {
				return this.corField;
			}
			set {
				this.corField = value;
			}
		}

		/// <remarks/>
		public ActionCollection incor {
			get {
				return this.incorField;
			}
			set {
				this.incorField = value;
			}
		}
	}

	[Serializable]
	//[XmlTypeAttribute( Namespace = "Fenubars" )]
	public class ActionCollection
	{

		private string actionField;
		private string[] actionsField;

		/// <remarks/>
		public string action {
			get {
				return this.actionField;
			}
			set {
				this.actionField = value;
			}
		}

		/// <remarks/>
		[XmlArrayItemAttribute( "action", IsNullable = false )]
		public string[] actions {
			get {
				return this.actionsField;
			}
			set {
				this.actionsField = value;
			}
		}
	}

	[Serializable]
	//[XmlTypeAttribute( Namespace = "Fenubars" )]
	public class EscapeButtonProperties
	{

		private string titleField;
		private State stateField;
		private bool stateFieldSpecified;
		private string actionField;
		private string[] actionsField;
		private string linkField;
		private string enableruleField;
		private PwdActions pwdField;
		private string nameField;

		/// <remarks/>
		public string title {
			get {
				return this.titleField;
			}
			set {
				this.titleField = value;
			}
		}

		/// <remarks/>
		public State state {
			get {
				return this.stateField;
			}
			set {
				this.stateField = value;
			}
		}

		/// <remarks/>
		[XmlIgnore]
		public bool stateSpecified {
			get {
				return this.stateFieldSpecified;
			}
			set {
				this.stateFieldSpecified = value;
			}
		}

		/// <remarks/>
		public string action {
			get {
				return this.actionField;
			}
			set {
				this.actionField = value;
			}
		}

		/// <remarks/>
		[XmlArrayItemAttribute( "action", IsNullable = false )]
		public string[] actions {
			get {
				return this.actionsField;
			}
			set {
				this.actionsField = value;
			}
		}

		/// <remarks/>
		public string link {
			get {
				return this.linkField;
			}
			set {
				this.linkField = value;
			}
		}

		/// <remarks/>
		public string enablerule {
			get {
				return this.enableruleField;
			}
			set {
				this.enableruleField = value;
			}
		}

		/// <remarks/>
		public PwdActions pwd {
			get {
				return this.pwdField;
			}
			set {
				this.pwdField = value;
			}
		}

		/// <remarks/>
		[XmlAttribute]
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
	}

	[Serializable]
	//[XmlTypeAttribute( Namespace = "Fenubars" )]
	public class NextButtonProperties
	{

		private string titleField;
		private State stateField;
		private bool stateFieldSpecified;
		private string actionField;
		private string[] actionsField;
		private string linkField;
		private string enableruleField;
		private int userlevelField;
		private bool userlevelFieldSpecified;
		private string nameField;

		/// <remarks/>
		public string title {
			get {
				return this.titleField;
			}
			set {
				this.titleField = value;
			}
		}

		/// <remarks/>
		public State state {
			get {
				return this.stateField;
			}
			set {
				this.stateField = value;
			}
		}

		/// <remarks/>
		[XmlIgnore]
		public bool stateSpecified {
			get {
				return this.stateFieldSpecified;
			}
			set {
				this.stateFieldSpecified = value;
			}
		}

		/// <remarks/>
		public string action {
			get {
				return this.actionField;
			}
			set {
				this.actionField = value;
			}
		}

		/// <remarks/>
		[XmlArrayItemAttribute( "action", IsNullable = false )]
		public string[] actions {
			get {
				return this.actionsField;
			}
			set {
				this.actionsField = value;
			}
		}

		/// <remarks/>
		public string link {
			get {
				return this.linkField;
			}
			set {
				this.linkField = value;
			}
		}

		/// <remarks/>
		public string enablerule {
			get {
				return this.enableruleField;
			}
			set {
				this.enableruleField = value;
			}
		}

		/// <remarks/>
		public int userlevel {
			get {
				return this.userlevelField;
			}
			set {
				this.userlevelField = value;
			}
		}

		/// <remarks/>
		[XmlIgnore]
		public bool userlevelSpecified {
			get {
				return this.userlevelFieldSpecified;
			}
			set {
				this.userlevelFieldSpecified = value;
			}
		}

		/// <remarks/>
		[XmlAttributeAttribute()]
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
	}

	[Serializable]
	//[XmlTypeAttribute( Namespace = "Fenubars" )]
	public class NormalButtonProperties
	{

		private string _Title = "ORIGINAL STRING";
		private State stateField = State.disable;
		private bool stateFieldSpecified;
		private string actionField;
		private string[] actionsField;
		private string linkField;
		private string enableruleField;
		private int positionField;
		private bool positionFieldSpecified;
		private bool visibleField;
		private bool visibleFieldSpecified;
		private string pictureField;
		private int userlevelField;
		private bool userlevelFieldSpecified;
		private string forecolorField;
		private string backcolorField;
		private string lightoncolorField;
		private bool holdmodeField;
		private bool holdmodeFieldSpecified;
		private int alignmentField;
		private bool alignmentFieldSpecified;
		private string invisibledeviceField;
		private PwdActions pwdField;
		private string nameField;

		/// <remarks/>
		[XmlElement("title" )]
		public string Title {
			get {
				return this._Title;
			}
			set {
				this._Title = value;
			}
		}

		/// <remarks/>
		public State state {
			get {
				return this.stateField;
			}
			set {
				this.stateField = value;
			}
		}

		/// <remarks/>
		[XmlIgnore]
		public bool stateSpecified {
			get {
				return this.stateFieldSpecified;
			}
			set {
				this.stateFieldSpecified = value;
			}
		}

		/// <remarks/>
		public string action {
			get {
				return this.actionField;
			}
			set {
				this.actionField = value;
			}
		}

		/// <remarks/>
		[XmlArrayItem( "action", IsNullable = false )]
		public string[] actions {
			get {
				return this.actionsField;
			}
			set {
				this.actionsField = value;
			}
		}

		/// <remarks/>
		public string link {
			get {
				return this.linkField;
			}
			set {
				this.linkField = value;
			}
		}

		/// <remarks/>
		public string enablerule {
			get {
				return this.enableruleField;
			}
			set {
				this.enableruleField = value;
			}
		}

		/// <remarks/>
		public int position {
			get {
				return this.positionField;
			}
			set {
				this.positionField = value;
			}
		}

		/// <remarks/>
		[XmlIgnore]
		public bool positionSpecified {
			get {
				return this.positionFieldSpecified;
			}
			set {
				this.positionFieldSpecified = value;
			}
		}

		/// <remarks/>
		public bool visible {
			get {
				return this.visibleField;
			}
			set {
				this.visibleField = value;
			}
		}

		/// <remarks/>
		[XmlIgnore]
		public bool visibleSpecified {
			get {
				return this.visibleFieldSpecified;
			}
			set {
				this.visibleFieldSpecified = value;
			}
		}

		/// <remarks/>
		public string picture {
			get {
				return this.pictureField;
			}
			set {
				this.pictureField = value;
			}
		}

		/// <remarks/>
		public int userlevel {
			get {
				return this.userlevelField;
			}
			set {
				this.userlevelField = value;
			}
		}

		/// <remarks/>
		[XmlIgnore]
		public bool userlevelSpecified {
			get {
				return this.userlevelFieldSpecified;
			}
			set {
				this.userlevelFieldSpecified = value;
			}
		}

		/// <remarks/>
		public string forecolor {
			get {
				return this.forecolorField;
			}
			set {
				this.forecolorField = value;
			}
		}

		/// <remarks/>
		public string backcolor {
			get {
				return this.backcolorField;
			}
			set {
				this.backcolorField = value;
			}
		}

		/// <remarks/>
		public string lightoncolor {
			get {
				return this.lightoncolorField;
			}
			set {
				this.lightoncolorField = value;
			}
		}

		/// <remarks/>
		public bool holdmode {
			get {
				return this.holdmodeField;
			}
			set {
				this.holdmodeField = value;
			}
		}

		/// <remarks/>
		[XmlIgnore]
		public bool holdmodeSpecified {
			get {
				return this.holdmodeFieldSpecified;
			}
			set {
				this.holdmodeFieldSpecified = value;
			}
		}

		/// <remarks/>
		public int alignment {
			get {
				return this.alignmentField;
			}
			set {
				this.alignmentField = value;
			}
		}

		/// <remarks/>
		[XmlIgnore]
		public bool alignmentSpecified {
			get {
				return this.alignmentFieldSpecified;
			}
			set {
				this.alignmentFieldSpecified = value;
			}
		}

		/// <remarks/>
		public string invisibledevice {
			get {
				return this.invisibledeviceField;
			}
			set {
				this.invisibledeviceField = value;
			}
		}

		/// <remarks/>
		public PwdActions pwd {
			get {
				return this.pwdField;
			}
			set {
				this.pwdField = value;
			}
		}

		/// <remarks/>
		[XmlAttribute]
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
	}
}