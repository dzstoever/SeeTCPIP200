using System;
using System.ComponentModel;
using System.Reflection;

namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for VirtualProperty.
	/// </summary>
	public class VirtualProperty : PropertyDescriptor
	{
		public bool Assigned;
		public bool Delimited;
		public bool Keyword;

		private FieldInfo _field;
		private Constraint[] constraints;
		public Constraint[] Constraints 
		{
			get { return constraints; }
		}
		
		public VirtualProperty(FieldInfo field) : this(field, null, (Attribute[]) field.GetCustomAttributes(typeof(Attribute), true))
		{}

		public VirtualProperty(FieldInfo field, Constraint[] constraints, Attribute[] attr) : base(field.Name, attr)
		{
			if (constraints != null)
				this.constraints = (Constraint[]) constraints.Clone();
			else
				this.constraints = null;
				
			_field = field;
		}

		public static Constraint[] createConstraint(string constraint) 
		{
			Constraint[] constraints = new Constraint[1];
            if (constraint == null | constraint.Equals(" "))
                return null;
            if (constraint.IndexOf("|") > 0)
            { // list constraint
                constraints[0] = new ListConstraint(constraint.Split('|'));
                return constraints;
            }
            else if (constraint.IndexOf(":") > 0)
            {
                string[] range = constraint.Split(':');
                long min = Convert.ToInt64(range[0]);
                long max = Convert.ToInt64(range[1]);

                constraints[0] = new NumericRangeConstraint(min, max);
                return constraints;
            }
			return null;
		}

		public FieldInfo Field 
		{ 
			get { 
				return _field; 
			} 
		}
	//	#region EVENTS THROWN
	//	public event OnPropertyErrorHandler OnPropertyError;
//
//		public delegate void OnPropertyErrorHandler(object sender, string property, string message);
//		#endregion

		public override bool Equals(object obj)
		{
			VirtualProperty other = obj as VirtualProperty;
			return other != null && other._field.Equals(_field);
		}

		public override int GetHashCode() { return _field.GetHashCode(); }
		
		#region IMPLEMENTATION PropertyDescriptor
		
		
		public override bool CanResetValue(object component) 
		{
			return true;
			//return false; 
		}
		public override Type ComponentType { get { return _field.DeclaringType; }}
		public override object GetValue(object component) 
		{
			
			return _field.GetValue(component);
		}
		public override bool IsReadOnly { get { return false; }}
		
		public override Type PropertyType { get { return _field.FieldType; }}
		public override void ResetValue(object component) 
		{
			foreach (Attribute attribute in Attributes) 
			{
				if (attribute is DefaultValueAttribute)
                    SetValue(this, ((DefaultValueAttribute) attribute).Value);
			}
		}

		public override void SetValue(object component, object value) 
		{
			bool valid = true;
			if (constraints != null) 
			{
				//try 
				//{
					foreach (Constraint constraint in constraints) 
					{
						if (constraint.IsValid(value) == false) 
						{
							valid = false;
							break;
						}	
					}
				//} 
				//catch (Exception e) 
			    //{
				//	if (OnPropertyError != null
				//		&& OnPropertyError.GetInvocationList() != null)
				//		OnPropertyError(this, Name, e.Message);
				//}
			}

			if (valid == true) 
			{
				_field.SetValue(component, value);
				OnValueChanged(component, EventArgs.Empty);
			} 
				
		}

		public void SetUnrestrictedValue(object component, object value) 
		{
			_field.SetValue(component, value);
			OnValueChanged(component, EventArgs.Empty);
		}

		public override bool ShouldSerializeValue(object component) 
		{
			foreach (Attribute attribute in Attributes) 
			{
				if (attribute is DefaultValueAttribute
				  && GetValue(component).Equals(((DefaultValueAttribute) attribute).Value))
					return false;
			}

			return true;
		}
		#endregion
	}
}
