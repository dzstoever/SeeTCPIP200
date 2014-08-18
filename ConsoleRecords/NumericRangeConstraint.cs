using System;

namespace ConsoleRecords
{
	/// <summary>
	/// Represents a constraint defined by a numeric range.
	/// </summary>
	/// <remarks>
	/// 20060327 P. McClain		initial version
	/// </remarks>
	public class NumericRangeConstraint : Constraint
	{
		#region CLASS AND MEMBER VARIABLES
		/// <summary>
		/// Lower bounds of the numeric range.
		/// </summary>
		private long min = long.MinValue;

		/// <summary>
		/// Upper bounds of the numeric range.
		/// </summary>
		private long max = long.MaxValue;
		#endregion

		#region CONSTRUCTORS AND DECONSTRUCTORS
		/// <summary>
		/// Create an NumericRangeConstraint object that defines a constraint
		/// based on a range of numbers.
		/// </summary>
		/// <param name="min">Lower bounds of the range.</param>
		/// <param name="max">Upper bounds of the range.</param>
		public NumericRangeConstraint(long min, long max)
		{
			this.min = min;
			this.max = max;
		}
		#endregion
		
		#region IMPLEMENTATIONS (Constraint)
		/// <summary>
		/// Determine whether a object falls within a numeric range.
		/// </summary>
		/// <param name="number">Number to validate.</param>
		/// <returns>true if valid; Exception otherwise.</returns>
		///<exception cref="Exception">object is invalid</exception> 
		public override bool IsValid(object number) 
		{
			Int64 number64;

			if (number is string && ((string) number) == "")
				return true;

			try 
			{
				number64 = Convert.ToInt64(number);
			} 
			catch (Exception) 
			{
				throw new Exception("value must be numeric");
			}

			if (number64 >= min && number64 <= max)
				return true;
			else 
				throw new Exception("value must be in the range " + min + " to " + max); 
		}
		#endregion
	} // end of NumericRangeConstraint
}
