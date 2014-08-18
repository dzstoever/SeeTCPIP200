using System;

namespace ConsoleRecords
{
	/// <summary>
	/// Abstract representation of a data constraint.
	/// </summary>
	/// /// <remarks>
	/// 20060325 P. McClain		initial version
	/// </remarks>
	public abstract class Constraint
	{
		#region CLASS AND MEMBER METHODS
		/// <summary>
		/// Determine whether data is valid within the given constraint.
		/// </summary>
		/// <param name="data">data to test against constraint.</param>
		/// <returns>true when valid; false otherwise.</returns>
		public virtual bool IsValid(object data) { return true; }
		#endregion
	} // end of Constraint
}