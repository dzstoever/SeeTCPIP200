using System;
//using csi.seevse.VseServiceAgent;
using csi.see.classlib1;

namespace ConsoleRecords
{
	/// <summary>
	/// Represents an FTP termination record.  The data secton of the record
	/// adheres to the following format:
	/// 
	/// 0010 T002_FTNODE	DS	CL16	FTP VSE node name
	/// 0020 T002_FTACUSER	DS	CL16	FTP VSE user id
	/// 0030 T002_FTBXSNTA	DS	XL8		Bytes sent + acked count
	/// 0038 T002_FTBXRCVC	DS	XL8		Bytes received count
	/// 0040 T002_FTBXSTIM	DS	XL8		Clock startup
	/// 0048 T002_FTBXTREP	DS	XL8		Clock terminated
	/// 0050 T002_FTBXFIRC	DS	XL4		Count of files received
	/// 0054 T002_FTBXFISC	DS	XL4		Count of files sent
	/// 0058 T002_FTLIPADR	DS	XL4		VSE IP address
	/// 005C T002_FTACIPAD	DS	XL4		Client IP address
	/// 0060 T002_FTPORT	DS	XL2		VSE port
	/// 0062 T002_FTACPORT	DS	XL2		Client port
	/// 0064 T002_FTBXTID	DS	XL2		VSE task id
	/// 0066 T002_FTSSLFLG	DS	XL1		SSL flag
	/// 0067 T002_FTFLAG02	DS	XL1		General purpose flag
	/// 0068 T002_FTBXFDIP	DS	XL4		Foreign data connection ip address
	/// 
	/// 
	/// where T002_FTSSLFLG value is restricted to:
	///	
	///	0x80 = SSL Server
	///	0x40 = SSL Client
	///	0x20 = SSL Client Auth
	///	0x10 = SSL Clear Data
	///	
	///	Revision History 20060216	P. McClain	Initial version
	/// </summary>
	public class FtpTerminationRecord
	{
		#region MEMBER VARIABLES
		private byte[] blok;
		private RawDataConverter converter = new RawDataConverter();
		public const string STANDARD_VSE_DATE = "yyyyMMdd hhmmss.ff";
		private static string format = STANDARD_VSE_DATE;
		public const byte FLAG_SSL_SERVER = 0x80;
		public const byte FLAG_SSL_CLIENT = 0x40;
		public const byte FLAG_SSL_CLIENT_AUTH = 0x20;
		public const byte FLAG_SSL_CLEAR_DATA = 0x10;
		public const byte FLAG_SSL_NONE = 0x00;

		public const byte FLAG_GENERAL_FTP_BATCH = 0x40;
		private string ftpNodeName;
		/// <summary>
		/// FTP VSE node name.
		/// </summary>	
		public string FtpNodeName { get { return ftpNodeName; } }

		public string ftpUserId;
		/// <summary>
		/// FTP VSE user id.
		/// </summary>
		public string FtpUserId { get { return ftpUserId; } }
		
		private ulong bytesSentAcked;
		/// <summary>
		/// Bytes sent + acked count.
		/// </summary>
		public ulong BytesSentAcked { get { return bytesSentAcked; } }

		private ulong bytesReceived;
		/// <summary>
		/// Bytes received count.
		/// </summary>
		public ulong BytesReceived { get { return bytesReceived; } }

		private DateTime startTime;
		/// <summary>
		/// Clock startup.
		/// </summary>
		public DateTime StartTime { get { return startTime; } }

		private DateTime endTime;
		/// <summary>
		/// Clock terminated.
		/// </summary>
		public DateTime EndTime { get { return endTime; } }

		private uint filesReceived;
		/// <summary>
		/// Count of files received.
		/// </summary>
		public uint FilesReceived { get { return filesReceived; } }

		private uint filesSent;
		/// <summary>
		/// Count of files sent.
		/// </summary>
		public uint FilesSent { get { return filesSent; } }

		private string vseIp;
		/// <summary>
		/// VSE IP address.
		/// </summary>
		public string VseIp { get { return vseIp; } }

		private string clientIp;
		/// <summary>
		/// Client IP address.
		/// </summary>
		public string ClientIp { get { return clientIp; } }

		private ushort vsePort;
		/// <summary>
		/// VSE port.
		/// </summary>
		public ushort VsePort { get { return vsePort; } }

		private ushort clientPort;
		/// <summary>
		/// Client port.
		/// </summary>
		public ushort ClientPort { get { return clientPort; } }

		private ushort vseTaskId;
		/// <summary>
		/// VSE task id.
		/// </summary>
		public ushort VseTaskId { get { return vseTaskId; } }

		private byte sslFlag;
		/// <summary>
		/// SSL flag.
		/// </summary>
		public byte SslFlag { get { return sslFlag; } }

		private byte generalFlag;
		/// <summary>
		/// General purpose flag.
		/// </summary>
		public byte GeneralFlag { get { return generalFlag; } }

		private string foreignDataIp;
		/// <summary>
		/// Foreign data connection ip address.
		/// </summary>
		public string ForeignDataIp { get { return foreignDataIp; } }
		#endregion

		#region CONSTRUCTORS AND DESTRUCTORS
		public FtpTerminationRecord() {}	 
				
		/// <summary>
		/// Create an instance of an FTP termination record.
		/// </summary>
		/// <param name="blok"></param>
		public FtpTerminationRecord(byte[] blok) : this(blok, 0) {}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="blok"></param>
		/// <param name="utcOffset"></param>
		public FtpTerminationRecord(byte[] blok, long utcOffset) 
		{
			this.blok = blok;
			this.utcOffset = utcOffset;

			/*ftpNodeName = converter.GetEBCDIC(18, blok, 16);
			ftpUserId = converter.GetEBCDIC(34, blok, 16);
			bytesSentAcked = converter.GetUINT64(50, blok);
			bytesReceived = converter.GetUINT64(58, blok);
			startTime = converter.GetDTutc(66, blok);
			startTime = startTime.AddSeconds(utcOffset);
			endTime = converter.GetDTutc(74, blok);
			endTime = endTime.AddSeconds(utcOffset);
			filesReceived = converter.GetUINT32(82, blok);
			filesSent = converter.GetUINT32(86, blok);
			vseIp = converter.GetIPAD(90, blok);
			clientIp = converter.GetIPAD(94, blok);
			vsePort = converter.GetUINT16(98, blok);
			clientPort = converter.GetUINT16(100, blok);
			vseTaskId = converter.GetUINT16(102, blok);
			sslFlag = converter.GetBYTE(104, blok);
			generalFlag = converter.GetBYTE(105, blok); 
			foreignDataIp = converter.GetIPAD(106, blok); 
*/
			ftpNodeName = converter.GetEBCDIC(16, blok, 16);
			ftpUserId = converter.GetEBCDIC(32, blok, 16);
			bytesSentAcked = converter.GetUINT64(48, blok);
			bytesReceived = converter.GetUINT64(56, blok);
			startTime = converter.GetDTutc(64, blok);
			startTime = startTime.AddSeconds(utcOffset);
			endTime = converter.GetDTutc(72, blok);
			endTime = endTime.AddSeconds(utcOffset);
			filesReceived = converter.GetUINT32(80, blok);
			filesSent = converter.GetUINT32(84, blok);
			vseIp = converter.GetIPAD(88, blok);
			clientIp = converter.GetIPAD(92, blok);
			vsePort = converter.GetUINT16(96, blok);
			clientPort = converter.GetUINT16(98, blok);
			vseTaskId = converter.GetUINT16(100, blok);
			sslFlag = converter.GetBYTE(102, blok);
			generalFlag = converter.GetBYTE(103, blok); 
			foreignDataIp = converter.GetIPAD(104, blok); 

		}
		
		public FtpTerminationRecord(
			ushort vseTaskId,
			string ftpNodeName,
			byte generalFlag,
			byte sslFlag,
			string ftpUserId,
			uint filesSent,
			uint filesReceived,
			ulong bytesSentAcked,
			ulong bytesReceived,
			string vseIp,
			ushort vsePort,
			string clientIp,
			ushort clientPort,
			string foreignDataIp,
			DateTime startTime,
			DateTime endTime)
		{
			this.vseTaskId = vseTaskId;
			this.ftpNodeName = ftpNodeName;
			this.generalFlag = generalFlag;
			this.sslFlag = sslFlag;
			this.ftpUserId = ftpUserId;
			this.filesSent = filesSent;
			this.filesReceived = filesReceived;
			this.bytesSentAcked = bytesSentAcked;
			this.bytesReceived = bytesReceived;
			this.vseIp = vseIp;
			this.vsePort = vsePort;
			this.clientIp = clientIp;
			this.clientPort = clientPort;
			this.foreignDataIp = foreignDataIp;
			this.startTime = startTime;
			this.endTime = endTime;
		}


		private long utcOffset;
		#endregion

		#region MEMBER METHODS
		/// <summary>
		/// Format the data section of a FTP termination record.
		/// </summary>
		/// <returns>String representation of a FTP termination record.</returns>
		public override string ToString() 
		{
			return StartTime.ToString().PadRight(22, ' ')
			  + "  " + EndTime.ToString().PadRight(22, ' ')
			  + "  " + VseTaskId.ToString().PadRight(2 + 5, ' ')
			  + "  " + FtpNodeName.PadRight(16, ' ')
			  + "  " + FtpUserId.PadRight(8, ' ')
			  + "  " + VseIp.PadRight(15, ' ')
			  + "  " + VsePort.ToString().PadRight(8, ' ')
 			  + "  " + ClientPort.ToString().PadRight(11, ' ')
			  + "  " + ClientIp.PadRight(15, ' ')
			  + "  " + ForeignDataIp.PadRight(15, ' ')
			  + "  " + FilesSent.ToString().PadRight(10, ' ')
			  + "  " + FilesReceived.ToString().PadRight(10, ' ')
			  + "  " + BytesSentAcked.ToString().PadRight(20, ' ')
			  + "  " + BytesReceived.ToString().PadRight(20, ' ')
			  + "  " + GeneralFlagFormatter(GeneralFlag).PadRight(8, ' ')
			  + "  " + SslFlagFormatter(SslFlag).ToString().PadRight(5, ' ');			  
			  
		}
		
		public string ToSummary() 
		{
			return 
			  DateFormatter(EndTime)
			  + " " + VseIp + ":" + VsePort
			  + " " + ClientIp + ":" + ClientPort
			  + " " + FtpUserId;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sslFlag"></param>
		/// <returns></returns>
		private bool SslFlagFormatter(byte sslFlag) 
		{
			if (sslFlag == FLAG_SSL_SERVER || sslFlag == FLAG_SSL_CLIENT)
				return true;
			else  
				return false;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="generalFlag"></param>
		/// <returns></returns>
		private string GeneralFlagFormatter(byte generalFlag) 
		{
			if (generalFlag == FLAG_GENERAL_FTP_BATCH) 
				return "FTPBATCH";
			else 
				return "INT-FTP"; 
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ip"></param>
		/// <returns></returns>
		private String IpAddressFormatter(uint ip) 
		{
			return ((ip & 0xFF000000) >> 24).ToString() + "." 
			  + ((ip & 0x00FF0000) >> 16).ToString() + "." 
			  + ((ip & 0x0000FF00) >> 8).ToString() + "." 
			  + ((ip & 0x000000FF)).ToString();
		}

		/// <summary>
		/// Format the date and time as a string one of the following.
		///		STANDARD_VSE_DATE "yyyyMMdd hhmmss.f"
		/// </summary>
		/// <param name="dt">Date and time.</param>
		/// <returns>A string representation of the specified date and time</returns>	
		public static string DateFormatter(DateTime dt) 
		{
			return dt.ToString(format);
		}
		#endregion

	} // end of FtpTerminationRecord
}
