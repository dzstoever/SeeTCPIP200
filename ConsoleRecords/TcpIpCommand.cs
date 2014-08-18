using System;
using System.ComponentModel;
using System.Reflection;
using System.Drawing.Design;
using System.Drawing;
//using csi.property;



//using System.Collections;



using System.Windows.Forms;

//using System.Data;
namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for Command.
	/// </summary>
	/// 
	
	public class TcpIpCommand : ICustomTypeDescriptor 
	{
		private static CategoryAttribute OPTIONAL_CATEGORY_ATTRIBUTE = new CategoryAttribute("Optional");
		private static CategoryAttribute REQUIRED_CATEGORY_ATTRIBUTE = new CategoryAttribute("*Required");
		private static TypeConverterAttribute DROP_DOWN_ATTRIBUTE = new TypeConverterAttribute(typeof(MyConverter));
        
		private PropertyDescriptorCollection properties = new PropertyDescriptorCollection(null);
		
		public string Name;
		public string Family;
		public string Shortcut;
		public string Syntax;
		public string Description;
		public string Example;
		public string Exposition;
		public string Notes;
		public string Related;

		public event OnValueChangedHandler OnValueChanged;
		public delegate void OnValueChangedHandler(object sender, string command);


		/*public TcpIpCommand(string name, string family, string shortcut, string syntax, string description, string example, string exposition, string notes, string related) 
		{
			Name = name;
			Family = family;		
			Shortcut = shortcut;
			Syntax = syntax;
			Description = description;	
			Example = example;
			Exposition = exposition;		
			Notes = notes;
			Related = related;
		}*/

        public TcpIpCommand(string name, string family, string shortcut, string syntax, string description, string example, string related)
        {
            Name = name;
            Family = family;
            Shortcut = shortcut;
            Syntax = syntax;
            Description = description;
            //Example = example;        //Leave this out - don't display
            //Exposition = exposition;  //Leave these out - they are in a different table
            //Notes = notes;
            Related = related;
        }


		public TcpIpCommand(String name, string family, string shortcut) 
		{
			Name = name;
			Family = family;
			Shortcut = shortcut;
		}

		public TcpIpCommand(String name, string shortcut) : this(name, null, shortcut)
		{	
			//Name = name;
			//ShortCut = shortcut;
			
		}
		

		#region EVENTS THROWN
		public event OnPropertyErrorHandler OnPropertyError;

		public delegate void OnPropertyErrorHandler(object sender, string property, string message);
		#endregion


		public VirtualProperty Add(string name, string parm, Constraint[] constraints, bool required, string description) 
		{
			Attribute[] attributes;
			
			int count = 2;
			//int count = 3;		
			bool constrainedByList = false;

			if (constraints != null) 
			{
				foreach (Constraint constraint in constraints) 
				{
					if (constraint is ListConstraint) 
					{
						count++;
						constrainedByList = true;
						break;
					}
				}
			}

			if (description != null)
				count++;
			
			attributes = new Attribute[count];
			
			count--;

			attributes[count--] = new DefaultValueAttribute(typeof(string), parm);

			if (required == true)
                attributes[count--] = REQUIRED_CATEGORY_ATTRIBUTE;
			else
				attributes[count--] = OPTIONAL_CATEGORY_ATTRIBUTE;
			
			if (description != null)
				attributes[count--] = new DescriptionAttribute(description);

			if (constrainedByList == true)
				attributes[count--] = new TypeConverterAttribute(typeof(MyConverter));

			//attributes[count--] = new EditorAttribute(typeof(CBEditor), typeof(UITypeEditor));
			
			VirtualField vf = new VirtualField(this, parm, name);
						
			VirtualProperty vpx = new VirtualProperty(vf, constraints, attributes);
						
			properties.Add(vpx);
			vpx.AddValueChanged(this, new EventHandler(ValueChanged));
			//vpx.OnPropertyError += new csi.property.VirtualProperty.OnPropertyErrorHandler(vpx_OnPropertyError);
			return vpx;
		}
	
		private void ValueChanged(object sender, System.EventArgs args) 
		{
			if (OnValueChanged != null
				&& OnValueChanged.GetInvocationList() != null)
				OnValueChanged(this, ToString());
		}


		public string ToString(bool required, bool optional) 
		{
			//string delimiter;
            string command = "";
			
			if (Family != null && Family.Equals("SET"))
				command = Family + " ";
			else if (Name.IndexOf(" ") > 0)
				command = Name;
			else 
				command = Name + " ";

			if (required == true) 
			{
				foreach (VirtualProperty property in properties) 
				{
					if (property.Category.Equals("*Required")) 
						command += formatProperty(property);
				}
			}

			if (optional == true) 
			{
				foreach (VirtualProperty property in properties) 
				{

					if (property.Category.Equals("Optional") 
					 && property.ShouldSerializeValue(this) == true)
					{
						command += formatProperty(property);
					}
				}
			}

			return command;
		}

		public string formatProperty(VirtualProperty property) 
		{
			string delimiter = property.Delimited ? "," : "";

			if (property.Assigned == true) 
			{
				string pValue = (string) property.GetValue(this);
				if (pValue.Equals(""))
					pValue = "?";

				return delimiter + property.Name + "=" + pValue;
			}
			else 
			{
				if (property.Keyword == true)
					return delimiter + property.Name;
				else
					return delimiter + property.GetValue(this);
			}
		}

		public override string ToString() 
		{
			return ToString(true, true);
		}

		public String GetClassName()
		{
			return TypeDescriptor.GetClassName(this,true);
		}

		public AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, true);
		}

		public String GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, true);
		}

		public TypeConverter GetConverter()
		{
			return TypeDescriptor.GetConverter(this, true);
		}

		public EventDescriptor GetDefaultEvent() 
		{
			return TypeDescriptor.GetDefaultEvent(this, true);
		}

		public PropertyDescriptor GetDefaultProperty() 
		{
			foreach (VirtualProperty property in properties) 
			{
				if (property.Category.Equals("*Required"))
					return property;
			}

			return TypeDescriptor.GetDefaultProperty(this, true);
		}

		public object GetEditor(Type editorBaseType) 
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes) 
		{
			return TypeDescriptor.GetEvents(this, attributes, true);
		}

		public EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(this, true);
		}

		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			return properties;
		}
	
		public PropertyDescriptorCollection GetProperties()
		{
			return properties;
		}
	
		public object GetPropertyOwner(PropertyDescriptor pd) 
		{
			return this;
		}

		private void vpx_OnPropertyError(object sender, string property, string message)
		{
			if (OnPropertyError != null
				&& OnPropertyError.GetInvocationList() != null)
				OnPropertyError(sender, property, message);
		}
	}

	public class CBEditor : UITypeEditor
	{
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{	
			//return false;
			return true;
		}

		public override void PaintValue(PaintValueEventArgs e)
		{

			
		//	Rectangle rect = new Rectangle(new Point(e.Bounds.Location.X - 1, e.Bounds.Location.Y - 1), new Size(e.Bounds.Width + 1, e.Bounds.Height + 1));
			e.Graphics.FillRectangle(new SolidBrush(Color.Blue), e.Bounds.X - 1, e.Bounds.Y - 1, e.Bounds.Right + 2, e.Bounds.Bottom + 2);
			//ControlPaint.DrawBorder(e.Graphics, rect, Color.Green, ButtonBorderStyle.Solid);
			//ControlPaint.DrawCheckBox(e.Graphics,e.Bounds,ButtonState.Checked);
			e = new PaintValueEventArgs(e.Context, e.Value, e.Graphics, new Rectangle(e.Bounds.Location, new Size(0, 0)));
		}
	}

	internal class MyConverter : StringConverter
	{
		public bool supported = true;
		public bool exclusive = true;
	
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			//true means show a combobox
			return supported;
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			//true will limit to list. false will show the list, but allow free-form entry
			return exclusive;
		}

		public override
			System.ComponentModel.TypeConverter.StandardValuesCollection
			GetStandardValues(ITypeDescriptorContext context)
		{

			Constraint[] constraints = ((VirtualProperty) context.PropertyDescriptor).Constraints;
			if (constraints != null) 
			{
				foreach (Constraint constraint in constraints)
					if (constraint is ListConstraint)
						return new StandardValuesCollection(((ListConstraint) constraint).List);
			}
			
			return new StandardValuesCollection(new object[0]);

			//return new StandardValuesCollection(((VirtualProperty) context.PropertyDescriptor).Options);
		}
	}
}
