using System;

namespace ConsoleRecords
{
	/// <summary>
	/// Represents the details of a status event.
	/// </summary>
	public class StatusEventArgs
	{
		#region MEMBER CONSTANTS
		public const int NORMAL = 0;
		public const int INFORMATION = 1;
		public const int WARNING = 5;
		public const int SEVERE = 10;
		#endregion

		#region MEMBER PROPERTIES
		/// <summary>
		/// Get the code property.  The code can be used to identify a type
		/// of message even when the text is different
		/// 
		/// </summary>
		private int code;
		public int Code { get { return code; } }

		/// <summary>
		/// Get the level property which indicates the severity of the 
		/// message.
		/// </summary>
		private int level;
		public int Level { get { return level; } }

		/// <summary>
		/// Get the message property.
		/// </summary>
		private string message;
		public string Message { get { return message; } }

		/// <summary>
		/// Get the details property which may contain additional 
		/// informatation about the event.
		/// </summary>
		private string details;
		public string Details { get { return details; } }
		#endregion

		#region CONSTRUCTORS AND DECONSTRUCTORS
		/// <summary>
		/// Create an instance of a StatusEventArgs object.
		/// </summary>
		/// <param name="code">Message identification code.</param>
		/// <param name="level">Severity level.</param>
		/// <param name="message">Text of the message.</param>
		/// <param name="details">Addition message details.</param>
		public StatusEventArgs(int code, int level, string message, string details) 
		{
			this.code = code;
			this.level = level;
			this.message = message;
			this.details = details;
		}
		
		/// <summary>
		/// Create an instance of a StatusEventArgs object.
		/// </summary>
		/// <param name="code">Message identification code.</param>
		/// <param name="level">Severity level.</param>
		/// <param name="message">Text of the message</param>
		public StatusEventArgs(int code, int level, string message) : this(code, level, message, null) {
		}
		#endregion
	} // end of StatusEventArgs
}
