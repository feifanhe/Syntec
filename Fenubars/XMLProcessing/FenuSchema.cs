using System;
using System.Xml.Serialization;
using System.ComponentModel;

namespace Fenubars
{
	[Serializable()]
	[DesignerCategoryAttribute( "code" )]
	[XmlType( Namespace = "Fenubars" )]
	[XmlRoot( "root", Namespace = "Fenubars", IsNullable = false )]
	public partial class FenubarProperties
	{

		private bool noLRField;

		private bool noLRFieldSpecified;

		private bool button3DField;

		private bool button3DFieldSpecified;

		private int level3DField;

		private bool level3DFieldSpecified;

		private bool textOverPicField;

		private bool textOverPicFieldSpecified;

		private bool noFuncField;

		private bool noFuncFieldSpecified;

		private bool bigLRField;

		private bool bigLRFieldSpecified;

		private int alignmentField;

		private bool alignmentFieldSpecified;

		private Fenu[] fenuField;

		/// <remarks/>
		public bool NoLR {
			get {
				return this.noLRField;
			}
			set {
				this.noLRField = value;
			}
		}

		/// <remarks/>
		[XmlIgnoreAttribute()]
		public bool NoLRSpecified {
			get {
				return this.noLRFieldSpecified;
			}
			set {
				this.noLRFieldSpecified = value;
			}
		}

		/// <remarks/>
		public bool Button3D {
			get {
				return this.button3DField;
			}
			set {
				this.button3DField = value;
			}
		}

		/// <remarks/>
		[XmlIgnoreAttribute()]
		public bool Button3DSpecified {
			get {
				return this.button3DFieldSpecified;
			}
			set {
				this.button3DFieldSpecified = value;
			}
		}

		/// <remarks/>
		public int Level3D {
			get {
				return this.level3DField;
			}
			set {
				this.level3DField = value;
			}
		}

		/// <remarks/>
		[XmlIgnoreAttribute()]
		public bool Level3DSpecified {
			get {
				return this.level3DFieldSpecified;
			}
			set {
				this.level3DFieldSpecified = value;
			}
		}

		/// <remarks/>
		public bool TextOverPic {
			get {
				return this.textOverPicField;
			}
			set {
				this.textOverPicField = value;
			}
		}

		/// <remarks/>
		[XmlIgnoreAttribute()]
		public bool TextOverPicSpecified {
			get {
				return this.textOverPicFieldSpecified;
			}
			set {
				this.textOverPicFieldSpecified = value;
			}
		}

		/// <remarks/>
		public bool NoFunc {
			get {
				return this.noFuncField;
			}
			set {
				this.noFuncField = value;
			}
		}

		/// <remarks/>
		[XmlIgnoreAttribute()]
		public bool NoFuncSpecified {
			get {
				return this.noFuncFieldSpecified;
			}
			set {
				this.noFuncFieldSpecified = value;
			}
		}

		/// <remarks/>
		public bool BigLR {
			get {
				return this.bigLRField;
			}
			set {
				this.bigLRField = value;
			}
		}

		/// <remarks/>
		[XmlIgnoreAttribute()]
		public bool BigLRSpecified {
			get {
				return this.bigLRFieldSpecified;
			}
			set {
				this.bigLRFieldSpecified = value;
			}
		}

		/// <remarks/>
		public int Alignment {
			get {
				return this.alignmentField;
			}
			set {
				this.alignmentField = value;
			}
		}

		/// <remarks/>
		[XmlIgnoreAttribute()]
		public bool AlignmentSpecified {
			get {
				return this.alignmentFieldSpecified;
			}
			set {
				this.alignmentFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute( "fenu" )]
		public Fenu[] fenu {
			get {
				return this.fenuField;
			}
			set {
				this.fenuField = value;
			}
		}
	}

	[SerializableAttribute()]
	[DesignerCategoryAttribute( "code" )]
	[XmlTypeAttribute( Namespace = "Fenubars" )]
	public partial class Fenu
	{

		private EscapeButton escapeField;

		private NormalButton[] buttonField;

		private NextButton nextField;

		private string nameField;

		/// <remarks/>
		public EscapeButton escape {
			get {
				return this.escapeField;
			}
			set {
				this.escapeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute( "button" )]
		public NormalButton[] button {
			get {
				return this.buttonField;
			}
			set {
				this.buttonField = value;
			}
		}

		/// <remarks/>
		public NextButton next {
			get {
				return this.nextField;
			}
			set {
				this.nextField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
	}

	[SerializableAttribute()]
	[XmlTypeAttribute( Namespace = "Fenubars" )]
	public enum State
	{
		enable,
		disable,
	}

	[SerializableAttribute()]
	[DesignerCategoryAttribute( "code" )]
	[XmlTypeAttribute( Namespace = "Fenubars" )]
	public partial class PwdActions
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

	[SerializableAttribute()]
	[DesignerCategoryAttribute( "code" )]
	[XmlTypeAttribute( Namespace = "Fenubars" )]
	public partial class ActionCollection
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

	[SerializableAttribute()]
	[DesignerCategoryAttribute( "code" )]
	[XmlTypeAttribute( Namespace = "Fenubars" )]
	public partial class EscapeButton
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
		[XmlIgnoreAttribute()]
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
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
	}


	[SerializableAttribute()]
	[DesignerCategoryAttribute( "code" )]
	[XmlTypeAttribute( Namespace = "Fenubars" )]
	public partial class NextButton
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
		[XmlIgnoreAttribute()]
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
		[XmlIgnoreAttribute()]
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

	[SerializableAttribute()]
	[DesignerCategoryAttribute( "code" )]
	[XmlTypeAttribute( Namespace = "Fenubars" )]
	public partial class NormalButton
	{

		private string titleField = string.Empty;
		private State stateField;
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
		[XmlIgnoreAttribute()]
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
		public int position {
			get {
				return this.positionField;
			}
			set {
				this.positionField = value;
			}
		}

		/// <remarks/>
		[XmlIgnoreAttribute()]
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
		[XmlIgnoreAttribute()]
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
		[XmlIgnoreAttribute()]
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
		[XmlIgnoreAttribute()]
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
		[XmlIgnoreAttribute()]
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
}