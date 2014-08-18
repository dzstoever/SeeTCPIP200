using System;
//using csi.seevse.VseServiceAgent;
using csi.see.classlib1;

namespace ConsoleRecords
{
	/// <summary>
	/// Represents a TCP/IP termination record.  The data secton of the record
	/// adheres to the following format:
	/// 
	/// 0010 T004_CCSTATE	DS	XL1		
	/// 0011 T004_CCPROTO	DS	XL1		
	/// 0012 T004_CCIDENT	DS	XL8		
	/// 001A T004_CCLOPORT	DS	XL2		
	/// 001C T004_CCFOPORT	DS	XL2		
	/// 001E T004_CCFOIP	DS	XL4		
	/// 0022 T004_CCFLAGAA	DS	XL1		
	/// 0023 T004_CCLOCAL	DS	XL1		ON : Local Call
	/// 0024 T004_CCRETCNT	DS	XL8		
	/// 002C T004_CCIBCNTI	DS	XL8		Stat:
	/// 0034 T004_CCIBDUPI	DS	XL8		Stat:
	/// 003C T004_CCBTCNTI	DS	XL8		Stat: 
	/// 0044 T004_CCBTDUPI	DS	XL8		Stat: 
	/// 004C T004_CCIBCNTO	DS	XL8		Stat: 
	/// 0054 T004_CCIBDUPO	DS	XL8		Stat: 
	/// 005C T004_CCBTCNTO	DS	XL8		Stat: 
	/// 0064 T004_CCBTDUPO	DS	XL8		Stat: 
	/// 006C T004_CCSWSCNT	DS	XL8		 
	/// 0074 T004_CCRETMOD	DS	XL8		Stat: 
	/// 007C T004_CCRWCCNT	DS	XL8		Stat:
	/// 0084 T004_CCDEPMAX	DS	XL8		Stat:
	/// 008C T004_CCSOSCNT	DS	XL8		Stat:
	/// 0094 T004_CCSORCNT	DS	XL8		Stat:
	/// 009C T004_CCMAXWND	DS	XL4		Max send window size
	/// 00A0 T004_CCRWINSZ	DS	XL4		Max receive window size
	/// 00A4 T004_CCIDEND	DS	XL8		
	/// 00AC T004_PID		DS	CL2		Partition ID
	/// 00AE T004_PIK		DS	XL2		Pik
	/// </summary>

	public class TcpIpTerminationRecord
	{
		public const string STANDARD_VSE_DATE = "yyyyMMdd hhmmss.ff";
		private static string format = STANDARD_VSE_DATE;

		private RawDataConverter converter = new RawDataConverter();

		/* The efficiency rating indicates that ratio of
		 *%       data bytes to the actual bytes traversing the network.
		 *%       For example, an efficiency of 75% indicates that
		 *%       25% of your network resource was consumed by overhead
		 *%       while this connection was communicating.*/
		
		public float InboundEfficiency 
		{
			get 
			{ 
				float inbound = 40 * (inboundIBBK + inboundIBBKDup) + inboundByte + inboundByteDup;
				if (inbound > 0 && inboundByte > 0)
					return inboundByte / inbound;
				else 
					return 0;
			}
		}

		public float OutboundEfficiency 
		{
			get 
			{ 
				float outbound = 40 * (outboundIBBK + outboundIBBKDup) + outboundByte + outboundByteDup;
				if (outbound > 0 && outboundByte > 0)
					return outboundByte / outbound;
				else 
					return 0;

			}
		}

		private byte state;
		public byte State { get { return state; } }
		
		private byte protocol;
		public byte Protocol { get { return protocol; } }

		private DateTime startTime;
		public DateTime StartTime { get { return startTime; } }

		private ushort localPort;
		public ushort LocalPort { get { return localPort; } }
		
		private ushort foreignPort;
		public ushort ForeignPort { get { return foreignPort; } }

		private string foreignIp;
		public string ForeignIp { get { return foreignIp; } }

		private byte flagAA;
		public byte FlagAA { get { return flagAA; } }

		private byte localCall;
		public byte LocalCall { get { return localCall; } }
		
		private ulong retransmitted;
		public ulong Retransmitted { get { return retransmitted; } }

		private ulong inboundIBBK;
		public ulong InboundIBBK{ get { return inboundIBBK; } }

		private ulong inboundIBBKDup;
		public ulong InboundIBBKDup { get { return inboundIBBKDup; } }

		private ulong inboundByte;
		public ulong InboundByte { get { return inboundByte; } }

		private ulong inboundByteDup;
		public ulong InboundByteDup { get { return inboundByteDup; } }

		private ulong outboundIBBK;
		public ulong OutboundIBBK { get { return outboundIBBK; } }

		private ulong outboundIBBKDup;
		public ulong OutboundIBBKDup { get { return outboundIBBKDup; } }

		private ulong outboundByte;
		public ulong OutboundByte { get { return outboundByte; } }

		private ulong outboundByteDup;
		public ulong OutboundByteDup { get { return outboundByteDup; } }

		private ulong sws;
		public ulong Sws { get { return sws; } }

		private ulong inRetransmitMode;
		public ulong InRetransmitMode { get { return inRetransmitMode; } }

		private ulong recvWindowClosed;
		public ulong RecvWindowClosed { get { return recvWindowClosed; } }

		private ulong highestDepth;
		public ulong HighestDepth { get { return highestDepth; } }

		private ulong sendSocket;
		public ulong SendSocket { get { return sendSocket; } }

		private ulong rcvdSocket;
		public ulong RcvdSocket { get { return rcvdSocket; } }

		private uint maxSendWindow;
		public uint MaxSendWindow { get { return maxSendWindow; } }

		private uint maxRecvWindow;
		public uint MaxRecvWindow { get { return maxRecvWindow; } }

		private DateTime endTime;
		public DateTime EndTime { get { return endTime; } }

		private string partitionId;
		public string PartitionId { get { return partitionId; } }

		private ushort pik; // not used
		public ushort Pik { get { return pik; } }

		public TcpIpTerminationRecord(byte[] blok, long utcOffset)
		{
			state = converter.GetBYTE(0x10, blok);
			protocol = converter.GetBYTE(0x11, blok);
			startTime = converter.GetDTutc(0x12, blok);
			startTime = startTime.AddSeconds(utcOffset);
			localPort = converter.GetUINT16(0x1A, blok);
			foreignPort = converter.GetUINT16(0x1C, blok);
			foreignIp = converter.GetIPAD(0x1E, blok);
			flagAA = converter.GetBYTE(0x22, blok);
			localCall = converter.GetBYTE(0x23, blok);
			retransmitted = converter.GetUINT64(0x24, blok);
			inboundIBBK = converter.GetUINT64(0x2C, blok);
			inboundIBBKDup = converter.GetUINT64(0x34, blok);
			inboundByte = converter.GetUINT64(0x3C, blok);
			inboundByteDup = converter.GetUINT64(0x44, blok);
			outboundIBBK = converter.GetUINT64(0x4C, blok);
			outboundIBBKDup = converter.GetUINT64(0x54, blok);
			outboundByte = converter.GetUINT64(0x5C, blok);
			outboundByteDup = converter.GetUINT64(0x64, blok);
			sws = converter.GetUINT64(0x6C, blok);
			inRetransmitMode = converter.GetUINT64(0x74, blok);
			recvWindowClosed = converter.GetUINT64(0x7C, blok);
			highestDepth = converter.GetUINT64(0x84, blok);
			sendSocket = converter.GetUINT64(0x8C, blok);
			rcvdSocket = converter.GetUINT64(0x94, blok);
			maxSendWindow = converter.GetUINT32(0x9C, blok);
			maxRecvWindow = converter.GetUINT32(0xA0, blok);
			endTime = converter.GetDTutc(0xA4, blok);
			endTime = endTime.AddSeconds(utcOffset);
			partitionId = converter.GetEBCDIC(0xAC, blok, 2);
			pik = converter.GetUINT16(0xAE, blok);
		}

		public TcpIpTerminationRecord(
			byte state,
			byte protocol,
			DateTime startTime,
			ushort localPort,
			ushort foreignPort,
			string foreignIp,
			byte flagAA,
			byte localCall,
			ulong retransmitted,
			ulong inboundIBBK,
			ulong inboundIBBKDup,
			ulong inboundByte,
			ulong inboundByteDup,
			ulong outboundIBBK,
			ulong outboundIBBKDup,
			ulong outboundByte,
			ulong outboundByteDup,
			ulong sws,
			ulong inRetransmitMode,
			ulong recvWindowClosed,
			ulong highestDepth,
			ulong sendSocket,
			ulong rcvdSocket,
			uint maxSendWindow,
			uint maxRecvWindow,
			DateTime endTime,
			string partitionId,
			ushort pik) {

			this.state = state;
			this.protocol = protocol;
			this.startTime = startTime;
			this.localPort = localPort;
			this.foreignPort = foreignPort;
			this.foreignIp = foreignIp;
			this.flagAA = flagAA;
			this.localCall = localCall;
			this.retransmitted = retransmitted;
			this.inboundIBBK = inboundIBBK;
			this.inboundIBBKDup = inboundIBBKDup;
			this.inboundByte = inboundByte;
			this.inboundByteDup = inboundByteDup;
			this.outboundIBBK = outboundIBBK;
			this.outboundIBBKDup = outboundIBBKDup;
			this.outboundByte = outboundByte;
			this.outboundByteDup = outboundByteDup;
			this.sws = sws;
			this.inRetransmitMode = inRetransmitMode;
			this.recvWindowClosed = recvWindowClosed;
			this.highestDepth = highestDepth;
			this.sendSocket = sendSocket;
			this.rcvdSocket = rcvdSocket;
			this.maxSendWindow = maxSendWindow;
			this.maxRecvWindow = maxRecvWindow;
			this.endTime = endTime;
			this.partitionId = partitionId;
			this.pik = pik;
		} 

		public string LocalCallFormatter(byte localCall) 
		{
			if (localCall == 0xFF)
				return "INT";
			else
				return "EXT";
		}

		public static byte LocalCallUnformatter(string localCall) 
		{
			if (localCall.Equals("EXT"))
				return 0x00;
			else
				return 0xFF;
		}

		public string ProtocolFormatter(byte protocol, byte flagAA) 
		{
			if (protocol == 1)
				return "ICMP";
			else if (protocol == 2)
				return "IGMP";
			else if (protocol == 6)
				return "TCP";
			else if (protocol == 17)
				return "UDP";
			else if(protocol == 254)
			{
				if (flagAA == 0x40)
					return "control";
				else if (flagAA == 0x20)
					return "client";
				else if (flagAA == 0x10)
					return "ftp";
				else if (flagAA == 0x8)
					return "telnet";
				else
					return "internal";
			}
			else if (protocol == 255)
				return "RAW";
			else
				return "Unknown";
		}

		public static byte ProtocolUnformatter(string protocol) 
		{
			if (protocol.Equals("ICMP"))
				return 1;
			else if (protocol.Equals("IGMP"))
				return 2;
			else if (protocol.Equals("TCP"))
				return 6;
			else if (protocol.Equals("UDP"))
				return 17;
			else if (protocol.Equals("control")
				|| protocol.Equals("client")
				|| protocol.Equals("ftp")
				|| protocol.Equals("telnet")
				|| protocol.Equals("internal"))
				return 254;
			else if (protocol.Equals("RAW"))
				return 255;
			else 
				return 0; // protocol cannot be determined
		}

		public static byte FlagAAUnformatter(string protocol) 
		{
			if (protocol.Equals("control"))
				return 0x40;
			else if (protocol.Equals("client"))
				return 0x020;
			else if (protocol.Equals("ftp"))
				return 0x10;
			else if (protocol.Equals("telnet"))
				return 0x8;
			else
				return 0x00; // flagAA cannot be determined
		}

		public string StateFormatter(byte state) 
		{
			if( state == 1)
				return "Listen";
			else if (state == 2)
				return "Syn Sent";
			else if (state == 3)
				return "Syn Received";
			else if (state == 4)
				return "Established";
			else if (state == 5)
				return "Fin Wait 1";
			else if (state == 6)
				return "Fin Wait 2";
			else if (state == 7)
				return "Close Wait";
			else if (state == 8)
				return "Last Ack";
			else if (state == 9)
				return "Time Wait";
			else if (state == 10)
				return "Closed";
			else 
				return "Unknown";
		}

		public static byte StateUnformatter(string state) 
		{
			if (state.Equals("Listen"))
				return 1;
			else if (state.Equals("Syn Sent"))
				return 2;
			else if (state.Equals("Syn Received"))
				return 3;
			else if (state.Equals("Established"))
				return 4;
			else if (state.Equals("Fin Wait 1"))
				return 5;
			else if (state.Equals("Fin Wait 2"))
				return 6;
			else if (state.Equals("Close Wait"))
				return 7;
			else if (state.Equals("Last Ack"))
				return 8;
			else if (state.Equals("Time Wait"))
				return 9;
			else if (state.Equals("Closed"))
				return 10;
			else // UNKNOWN
				return 0; // state cannot be determined
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

		public static string EfficiencyFormatter(float efficiency) 
		{
			float percent = efficiency * 100;
			return percent.ToString("n2") + "%";
		}

		public override string ToString() 
		{
			return StartTime.ToString().PadRight(22, ' ')
			+ "  " + EndTime.ToString().PadRight(22, ' ')
            + "  " + ProtocolFormatter(Protocol, FlagAA).PadRight(8, ' ')
            + "  " + StateFormatter(state).PadRight(12, ' ')
            + "  " + PartitionId.PadRight(3, ' ')
			+ "  " + LocalPort.ToString().PadRight(5 + 5, ' ')
			+ "  " + ForeignPort.ToString().PadRight(5 + 5, ' ')
			+ "  " + ForeignIp.ToString().PadRight(15, ' ')
			//Inbound
            + "  " + InboundByte.ToString().PadRight(20, ' ')
            + "  " + InboundIBBK.ToString().PadRight(20, ' ')
            + "  " + InboundByteDup.ToString().PadRight(20, ' ')
            + "  " + InboundIBBKDup.ToString().PadRight(20, ' ')
            + "  " + EfficiencyFormatter(InboundEfficiency).PadRight(6 + 7, ' ')
            //Outbound
            + "  " + OutboundByte.ToString().PadRight(20, ' ')
            + "  " + OutboundIBBK.ToString().PadRight(20, ' ')
            + "  " + OutboundByteDup.ToString().PadRight(20, ' ')
            + "  " + OutboundIBBKDup.ToString().PadRight(20, ' ')
            + "  " + EfficiencyFormatter(OutboundEfficiency).PadRight(6 + 8, ' ')
            //RECVs/SENDs
            + "  " + RcvdSocket.ToString().PadRight(20, ' ')
            + "  " + SendSocket.ToString().PadRight(20, ' ')
            + "  " + MaxRecvWindow.ToString().PadRight(10 + 3, ' ')
            + "  " + MaxSendWindow.ToString().PadRight(10 + 3, ' ')
            + "  " + RecvWindowClosed.ToString().PadRight(20, ' ')
            //Other
            + "  " + Retransmitted.ToString().PadRight(20, ' ')
            + "  " + InRetransmitMode.ToString().PadRight(20, ' ')            
            + "  " + HighestDepth.ToString().PadRight(20, ' ')			
            + "  " + Sws.ToString().PadRight(20, ' ');
			
			//+ "  " + LocalCallFormatter(localCall).PadRight(3 + 4, ' ')						
		}


		public static string ToString(
			DateTime endTime, 
			string partitionId,  
			string protocol,
			double localPort,
			string foreignIp,
			double foreignPort) 
		{
			return DateFormatter(endTime)
				+ " " + partitionId.PadRight(2, ' ')
				+ " " + protocol.PadRight(8, ' ')
				+ " " + localPort.ToString().PadRight(5, ' ')
				+ " " + (foreignIp + ":" + foreignPort).PadRight(21, ' ');
		}
			
		public string ToSummary() 
		{
			return DateFormatter(EndTime)
			 + " " + PartitionId.PadRight(2, ' ')
			 + " " + ProtocolFormatter(Protocol, FlagAA).PadRight(8, ' ')
			 + " " + LocalPort.ToString().PadRight(5, ' ')
			 + " " + (ForeignIp + ":" + ForeignPort).PadRight(21, ' ');
		}

	} // end of TcpIpTerminationRecord
}
