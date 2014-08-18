using System;
using System.Reflection;

namespace ConsoleRecords
{
	/// <summary>
	/// Create field information for a virtual field.  A virtual field does
	/// not actually exist in the parent class, but instead is created
	/// 'virtually' at runtime.
	/// </summary>
	public class VirtualField : FieldInfo
	{
		#region MEMBER VARIABLES
		private object parent;
		private object field;
		private string name;
		#endregion

		#region CONSTRUCTORS AND DECONSTRUCTORS
		public VirtualField(object parent, object field, string name) : base()
		{
			this.parent = parent;
			this.field = field;
			this.name = name;
			
		}
		#endregion

		#region IMPLEMENTATION FieldInfo
		/// <summary>
		/// Gets the attributes of this field.  In all cases, an empty set
		/// is returned.
		/// </summary>
		public override FieldAttributes Attributes
		{
			get {
				return FieldAttributes.HasDefault | FieldAttributes.Public;
				//return new FieldAttributes(); 
				
				
			}
		}

		/// <summary>
		/// Gets the runtime handle of the field.  In all cases, a new
		/// field handle is returned.
		/// </summary>
		public override RuntimeFieldHandle FieldHandle
		{
			get { return new RuntimeFieldHandle(); }
		}

		/// <summary>
		///  Gets the type of type of the field.
		/// </summary>
		public override Type FieldType
		{
			get { return field.GetType(); }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override object GetValue(object obj)
		{
			return field;
		}
 
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		/// <param name="invokeAttr"></param>
		/// <param name="binder"></param>
		/// <param name="culture"></param>
		public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, System.Globalization.CultureInfo culture)
		{
			field = value;
			
		}

		/// <summary>
		/// Gets the class that declares this field.
		/// </summary>
		public override Type DeclaringType
		{
			get
			{
				return parent.GetType();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="inherit"></param>
		/// <returns></returns>
		public override object[] GetCustomAttributes(bool inherit)
		{
			Attribute[] attributes = new Attribute[0];
			return attributes;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeType"></param>
		/// <param name="inherit"></param>
		/// <returns></returns>
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			Attribute[] attributes = new Attribute[0];
			return attributes;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeType"></param>
		/// <param name="inherit"></param>
		/// <returns></returns>
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return false;
		}

		/// <summary>
		/// Gets the displayable name of the field.
		/// </summary>
		public override string Name
		{
			get { return name; }
		}

		/// <summary>
		///  Gets the type of the field reflected by the current instance.
		/// </summary>
		public override Type ReflectedType
		{
			get { return field.GetType(); }
		}
		#endregion
	} // end of VirtualField
}