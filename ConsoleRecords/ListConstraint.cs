using System;

namespace ConsoleRecords
{
	/// <summary>
	/// Represents a contraint that is defined by a list of values.
	/// </summary>
	/// <remarks>
	/// 20060327 P. McClain		initial version
	/// </remarks>
	public class ListConstraint : Constraint
	{
		#region CLASS AND MEMBER VARIABLES
		/// <summary>
		/// Constraint list of valid values.
		/// </summary>
		private object[] list;
		#endregion

		#region PROPERTIES
		/// <summary>
		/// Get the defined constraint list.
		/// </summary>
		public object[] List { get { return list; } }
		#endregion

		#region CONSTRUCTORS AND DECONSTRUCTORS
		/// <summary>
		/// Create an ListConstraint object that defines a constraint based on
		/// an inclusive set of values.
		/// </summary>
		/// <param name="list">List of objects</param>
		public ListConstraint(object[] list)
		{
			this.list = list;
		}
		#endregion

		#region IMPLEMENTATIONS (Constraint)
		/// <summary>
		/// Determine whether an object matches an entry in the list.
		/// </summary>
		/// <param name="data">Object to validate.</param>
		/// <returns>true if valid; Exception otherwise.</returns>
		/// <exception cref="Exception">object is invalid.</exception>
		public override bool IsValid(object data) 
		{
			if (data == null || data.Equals(""))
				return true;

			for (int i = 0; i < list.Length; i++) 
			{
				if (list[i].Equals(data))
					return true;
			}

			string error = "value must be one of the following:\n";
			for (int i = 0; i < list.Length; i++)
				error += ("   " + list[i] + "\n");
			throw new Exception(error); 
		}
		#endregion
	} // end of ListConstraint
}
