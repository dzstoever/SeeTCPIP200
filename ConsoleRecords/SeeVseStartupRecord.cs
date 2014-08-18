using System;
using System.Text;
//using csi.seevse.VseServiceAgent;
using csi.see.classlib1;

namespace ConsoleRecords
{
	/// <summary>
	/// Represents a SEEVSE startup record.  
	/// </summary>
	///	0010	STRTCTOD DS	XL8		Date and time created
	///	0018	STRTCPUI DS XL8		System CPU serial number
	///	0020	STRTPROG DS CL8		Program ID
	///	0028	STRTVERS DS CL8		Program version	
	/// </summary>
	/// <remarks>
	/// Revision History 20060216 P. McClain	Initial version
	/// </remarks>
	public class SeeVseStartupRecord
	{
		#region MEMBER VARIABLES
		private byte[] blok;
		private long utcOffset;
		private RawDataConverter converter = new RawDataConverter();
		public const string STANDARD_VSE_DATE = "yyyyMMdd hhmmss.ff";
		private int FIELD_DATE_LENGTH = 22;
		#endregion
		
		#region MEMBER PROPERTIES
		private DateTime startTime;
		/// <summary>
		/// Get date and time created.
		/// </summary>
		public DateTime StartTime { get { return startTime; } }

		private string cpuId;
		/// <summary>
		/// Get system CPU serial number.
		/// </summary>
		public string CpuId { get { return cpuId; } }		
		
		private string programId;
		/// <summary>
		/// Get program ID.
		/// </summary>
		public string ProgramId { get { return  programId; } }

		private string programVersion;
		/// <summary>
		/// Get program version.
		/// </summary>
		public string ProgramVersion { get { return programVersion; } }	

		private string dateFormat;
		public string DateFormat { 
			get { return dateFormat; }
			set 
			{ 
				dateFormat = value;
				if (value != null)
					FIELD_DATE_LENGTH = value.Length;
			}
		}
		#endregion

		#region CONSTRUCTORS and DECONSTRUCTORS
		/// <summary>
		/// Create an instance of a SEEVSE startup record.
		/// </summary>
		/// <param name="blok">Raw SEEVSE startup record</param>
		public SeeVseStartupRecord(byte[] blok) : this(blok, 0) {}
		
		/// <summary>
		/// Create an instance of a SEEVSE startup record.
		/// </summary>
		/// <param name="blok">Raw SEEVSE startup record</param>
		/// <param name="utcOffset">UTC offset for time stamps</param>
		public SeeVseStartupRecord(byte[] blok, long utcOffset) 
		{
			this.blok = blok;
			this.utcOffset = utcOffset;

			startTime = converter.GetDTutc(16, blok);
			startTime = startTime.AddSeconds(utcOffset);
			cpuId = converter.GetCPUID(24, blok); 
			programId = converter.GetEBCDIC(32, blok, 8);
			programVersion = converter.GetEBCDIC(40, blok, 8);
		}

		public SeeVseStartupRecord(
			DateTime startTime,
			string cpuId,
			string programId,
			string programVersion) 
		{
			this.startTime = startTime;
			this.cpuId = cpuId;
			this.programId = programId;
			this.programVersion = programVersion;
		}
		#endregion
			
		#region MEMBER METHODS
		/// <summary>
		/// Format the data section of a SEEVSE startup record.
		/// </summary>
		/// <returns>String representation of a SEEVSE startup record.</returns>
		public override string ToString() 
		{			
			return CpuId.PadRight(17, ' ')                
                + "  " + ProgramId.PadRight(8 + 2, ' ')
                + "  " + ProgramVersion.PadRight(8, ' ')
				+ "  " + DateFormatter(StartTime).PadRight(FIELD_DATE_LENGTH, ' '); 
		}

		/// <summary>
		/// Format the date and time as a string one of the following.
		///		STANDARD_VSE_DATE "yyyyMMdd hhmmss.f"
		/// </summary>
		/// <param name="dt">Date and time.</param>
		/// <returns>A string representation of the specified date and time</returns>	
		private string DateFormatter(DateTime dt) 
		{
			if (dateFormat == null || dateFormat.Equals(""))
				return dt.ToString();

			return dt.ToString(dateFormat);
		}
		#endregion
	} // end of SeeVseStartupRecord
}
