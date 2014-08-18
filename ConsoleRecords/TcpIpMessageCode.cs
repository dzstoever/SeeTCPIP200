using System;

namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for TcpIpMessageCode.
	/// </summary>
	public class TcpIpMessageCode
	{
		#region MEMBER VARIABLES;
		private string name;
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get { return name; }
		}

		/// <summary>
		/// Get the message family property (derived from Code).
		/// </summary>
		public string Family 
		{
			get { 
				if (Char.IsDigit(Name, 2) == true)
					return Name.Substring(0, 2);
				else 
					return Name.Substring(0, 3);
			}
		}

		/// <summary>
		/// Get the numeric message id property (derived from Code).
		/// </summary>
		public string Id
		{
			get { 
				if (Char.IsDigit(Name, 2) == true)
					return Name.Substring(2, 4);
				else 
					return Name.Substring(3, 3);
			}
		}
		/// <summary>
		/// Get the message level property (derived from Code).
		/// </summary>
		public string Level 
		{
			get { return Name.Substring(6); }
		}

		private string summary;
		/// <summary>
		/// 
		/// </summary>
		public string Summary 
		{
			get { return summary; }
		}

		private string detail;
		/// <summary>
		/// 
		/// </summary>
		public string Detail 
		{
			get { return detail; }
		}

		private string systemAction;
		public string SystemAction 
		{
			get { return systemAction; }
		}
		
		private string operatorAction;
		public string OperatorAction 
		{
			get { return operatorAction; }
		}

		private string administratorAction;
		public string AdministratorAction 
		{
			get { return administratorAction; }
		}
		#endregion

		#region CLASS VARIABLES
		public static char ERROR = 'E';
		public static char INFORMATIONAL = 'I';
		public static char WARNING = 'W';
		#endregion

		#region CONSTRUCTORS AND DECONSTRUCTORS
		public TcpIpMessageCode()
		{
		}

		public TcpIpMessageCode(
		  string name, 
		  string summary, 
		  string detail, 
		  string administratorAction, 
		  string operatorAction, 
		  string systemAction) 
		{
			this.name = name;
			this.summary = summary;
			this.detail = detail;
			this.administratorAction = administratorAction;
			this.operatorAction = operatorAction;
			this.systemAction = systemAction;
		}

		#endregion

		public static string GetFamily(string message) 
		{
			if (message.Length < 3)
				return message;
		
			if (Char.IsDigit(message, 2) == true)
				return message.Substring(0, 2);
			else 
				return message.Substring(0, 3);
		}

		public static string GetId(string message) 
		{
			if (message.Length < 3)
				return "";

			if (message.Length < 6) 
			{
				if (Char.IsDigit(message, 2) == true)
					return message.Substring(2);
				else
					return message.Substring(3);
			}

			if (Char.IsDigit(message, 2) == true)
				return message.Substring(2, 4);
			else 
				return message.Substring(3, 3);
		}

		public static string GetLevel(string message) 
		{
			if (message.Length < 7)
				return "";
			else 
				return message.Substring(6);
		}

		/// <summary>
		/// Format the single character level to its corresponding
		/// descriptive string. 
		/// </summary>
		/// <param name="level">Message code level</param>
		/// <returns>A descriptive string.</returns>
		public static string LevelFormatter(char level) 
		{
			if (level == INFORMATIONAL)
				return "INFORMATIONAL";
			else if (level == WARNING)
				return "WARNING";
			else if (level == ERROR)
				return "ERROR";
			else
				return "UNSPECIFIED";			
		}
	} // end of TcpIpMessageCode
}
