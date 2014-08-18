using System;
using System.Data;
using System.Collections;

namespace csi.see.classlib1
{
	public class RawDataManager
	{
        /// <summary>
        /// Creates ArrayLists defining the raw data bloks returned by SVSESRVR, as follows:
        /// [0] = Offset
        /// [1] = RawDataType - see enums
        /// [2] = Feild length
        /// [3] = Friendly name
        /// [4] = Internal name
        /// </summary>
		public RawDataManager()
		{}
		
		#region ArrayList members returned by MakeFields... 
		
		#endregion
		//Poll Bloks
		public ArrayList MakeFieldsSVSEINIT()
		{
			int fieldcnt = 37;
			ArrayList fields = new ArrayList(5);
			#region Initialize the arrays
			int[]			varosets =		new int[fieldcnt];
			RawDataTypes[]	vartypes =		new RawDataTypes[fieldcnt];
			int[]			varlengths =	new int[fieldcnt];
			string[]		friendlynames = new string[fieldcnt];
			string[]		internalnames = new string[fieldcnt];
			#endregion
			#region Set the data parameters
			int fcnt = 0;
			varosets	[fcnt] = (int)offSVSEINIT.SINTSTCK;
			vartypes		[fcnt] = RawDataTypes.STCK;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Poll Time STCK";
			internalnames	[fcnt] = offSVSEINIT.SINTSTCK.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTFLG1;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "European Date Flag";
			internalnames	[fcnt] = offSVSEINIT.SINTFLG1.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTGMT0;
			vartypes		[fcnt] = RawDataTypes.INT32;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "UTC Offset (sec)";
			internalnames	[fcnt] = offSVSEINIT.SINTGMT0.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTVIPL;
			vartypes		[fcnt] = RawDataTypes.STCK;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "IPL Time";
			internalnames	[fcnt] = offSVSEINIT.SINTVIPL.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTVVER;
			vartypes		[fcnt] = RawDataTypes.VRM;
			varlengths		[fcnt] = 3;
			friendlynames	[fcnt] = "VSE Release";
			internalnames	[fcnt] = offSVSEINIT.SINTVVER.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTPNAM;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Power Node Name";
			internalnames	[fcnt] = offSVSEINIT.SINTPNAM.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTPSID;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "Power SysID";
			internalnames	[fcnt] = offSVSEINIT.SINTPSID.ToString();
			fcnt++;
			//CPU fields
			varosets	[fcnt] = (int)offSVSEINIT.SINTVCPU;
			vartypes		[fcnt] = RawDataTypes.CPUID;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "CPU ID";
			internalnames	[fcnt] = offSVSEINIT.SINTVCPU.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTCRTM;
			vartypes		[fcnt] = RawDataTypes.STCK;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "CPU Reset Time";
			internalnames	[fcnt] = offSVSEINIT.SINTCRTM.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTCPUN;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "# of CPUs";
			internalnames	[fcnt] = offSVSEINIT.SINTCPUN.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTCPUA;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "Active CPUs";
			internalnames	[fcnt] = offSVSEINIT.SINTCPUA.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTCPUQ;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "Quiesced CPUs";
			internalnames	[fcnt] = offSVSEINIT.SINTCPUQ.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTICNT;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "# of TCP/IP Stacks";
			internalnames	[fcnt] = offSVSEINIT.SINTICNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTIPID;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "TCP/IP PID";
			internalnames	[fcnt] = offSVSEINIT.SINTIPID.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTIJNM;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "TCP/IP Job Name";
			internalnames	[fcnt] = offSVSEINIT.SINTIJNM.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTISDT;
			vartypes		[fcnt] = RawDataTypes.STCK;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "TCP/IP Start Time";
			internalnames	[fcnt] = offSVSEINIT.SINTISDT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTIPAD;
			vartypes		[fcnt] = RawDataTypes.IPADDR;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "TCP/IP Address";
			internalnames	[fcnt] = offSVSEINIT.SINTIPAD.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTISID;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "TCP/IP SysID";
			internalnames	[fcnt] = offSVSEINIT.SINTISID.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTIVER;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "TCP/IP Release";
			internalnames	[fcnt] = offSVSEINIT.SINTIVER.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTIIBM;
			vartypes		[fcnt] = RawDataTypes.HEX;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "TCP/IP License";
			internalnames	[fcnt] = offSVSEINIT.SINTIIBM.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTCPRT;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "Console Port";
			internalnames	[fcnt] = offSVSEINIT.SINTCPRT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTSPID;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "SeeVSE PID";
			internalnames	[fcnt] = offSVSEINIT.SINTSPID.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTSJNM;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "SeeVSE Job Name";
			internalnames	[fcnt] = offSVSEINIT.SINTSJNM.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTSTIM;
			vartypes		[fcnt] = RawDataTypes.STCK;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "SeeVSE Start Time";
			internalnames	[fcnt] = offSVSEINIT.SINTSTIM.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTSVER;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "SeeVSE Release";
			internalnames	[fcnt] = offSVSEINIT.SINTSVER.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTPCHK;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Program Checks";
			internalnames	[fcnt] = offSVSEINIT.SINTPCHK.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTPHLD;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Phase Loads";
			internalnames	[fcnt] = offSVSEINIT.SINTPHLD.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTEXTI;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "External Interrupts";
			internalnames	[fcnt] = offSVSEINIT.SINTEXTI.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTSVCI;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "SVC Interrupts";
			internalnames	[fcnt] = offSVSEINIT.SINTSVCI.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTSSCH;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "I/O Subchannel Starts";
			internalnames	[fcnt] = offSVSEINIT.SINTSSCH.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTIOIN;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "I/O Interrupts";
			internalnames	[fcnt] = offSVSEINIT.SINTIOIN.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTNTSK;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "Max # of Tasks";
			internalnames	[fcnt] = offSVSEINIT.SINTNTSK.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTATSK;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "# of Active Tasks";
			internalnames	[fcnt] = offSVSEINIT.SINTATSK.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTNPRT;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "Max # of Partitions";
			internalnames	[fcnt] = offSVSEINIT.SINTNPRT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTAPRT;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "# of Allocated Partitions";
			internalnames	[fcnt] = offSVSEINIT.SINTAPRT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTNCCA;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "# of TCP/IP Connections";
			internalnames	[fcnt] = offSVSEINIT.SINTNCCA.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSVSEINIT.SINTNTCS;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "# of TCP/IP Pseudo Tasks";
			internalnames	[fcnt] = offSVSEINIT.SINTNTCS.ToString();
			#endregion
			#region Add the data arrays to a collection
			fields.Add(varosets);
			fields.Add(vartypes);
			fields.Add(varlengths);
			fields.Add(friendlynames);
			fields.Add(internalnames);
			#endregion		
			return fields;
		}	
		public ArrayList MakeFieldsIVBLOK()
		{
			int fieldcnt = 59;
			ArrayList fields = new ArrayList(5);
			#region Initialize the arrays
			int[]			varosets =		new int[fieldcnt];
			RawDataTypes[]		vartypes =		new RawDataTypes[fieldcnt];
			int[]			varlengths =	new int[fieldcnt];
			string[]		friendlynames = new string[fieldcnt];
			string[]		internalnames = new string[fieldcnt];
			#endregion
			#region Set the data parameters - dispatch
			int fcnt = 0; 
			varosets	[fcnt] = (int)offIVBLOK.V2DSPCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Total Dispatches";
			internalnames	[fcnt] = offIVBLOK.V2DSPCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2ACTCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Active Dispatches";
			internalnames	[fcnt] = offIVBLOK.V2ACTCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2FXDCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Fixed Dispatches";
			internalnames	[fcnt] = offIVBLOK.V2FXDCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2QUICNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Quick Dispatches";
			internalnames	[fcnt] = offIVBLOK.V2QUICNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2PERCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Persistant Dispatches";
			internalnames	[fcnt] = offIVBLOK.V2PERCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2COMCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Complete Dispatches";
			internalnames	[fcnt] = offIVBLOK.V2COMCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2PASCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Passed Dispatches";
			internalnames	[fcnt] = offIVBLOK.V2PASCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.WAITCNTR;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Dispatcher Waits";
			internalnames	[fcnt] = offIVBLOK.WAITCNTR.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2TOTIME;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Dispatch Time (us)";
			internalnames	[fcnt] = offIVBLOK.V2TOTIME.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.CUSHONRE;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Storage Releases";
			internalnames	[fcnt] = offIVBLOK.CUSHONRE.ToString();
			#endregion
			#region Set the data parameters - daemons
			fcnt++; 
			varosets	[fcnt] = (int)offIVBLOK.FTPCOUNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "INT-FTP Daemons";
			internalnames	[fcnt] = offIVBLOK.FTPCOUNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2FTPACT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Active FTPD";
			internalnames	[fcnt] = offIVBLOK.V2FTPACT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2FTPMAX;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Max FTPD";
			internalnames	[fcnt] = offIVBLOK.V2FTPMAX.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.TELCOUNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Telnet Daemons";
			internalnames	[fcnt] = offIVBLOK.TELCOUNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2TLNACT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Active TelnetD";
			internalnames	[fcnt] = offIVBLOK.V2TLNACT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2TLNMAX;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Max TelnetD";
			internalnames	[fcnt] = offIVBLOK.V2TLNMAX.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2TLNBAC;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Active Telnet Buffers";
			internalnames	[fcnt] = offIVBLOK.V2TLNBAC.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2TLNBMX;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Max Telnet Buffers";
			internalnames	[fcnt] = offIVBLOK.V2TLNBMX.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.LPDCOUNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "LP Daemons";
			internalnames	[fcnt] = offIVBLOK.LPDCOUNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.HTTCOUNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "HTTP Daemons";
			internalnames	[fcnt] = offIVBLOK.HTTCOUNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2SMTPCT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "SMTP Daemons";
			internalnames	[fcnt] = offIVBLOK.V2SMTPCT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2POP3CT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "POP3 Daemons";
			internalnames	[fcnt] = offIVBLOK.V2POP3CT.ToString();
			#endregion
			#region Set the data parameters - clients
			fcnt++; 
			varosets	[fcnt] = (int)offIVBLOK.FTPVICNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "INT-FTP Sessions";
			internalnames	[fcnt] = offIVBLOK.FTPVICNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.TELVICNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Telnet Sessions";
			internalnames	[fcnt] = offIVBLOK.TELVICNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.LPDVICNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "LPR Requests";
			internalnames	[fcnt] = offIVBLOK.LPDVICNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.HTTVICNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "HTTP Requests";
			internalnames	[fcnt] = offIVBLOK.HTTVICNT.ToString();
			#endregion
			#region Set the data parameters - data
			fcnt++; 
			varosets	[fcnt] = (int)offIVBLOK.FILESCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "INT-FTP Files Sent";
			internalnames	[fcnt] = offIVBLOK.FILESCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.FILERCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "INT-FTP Files Received";
			internalnames	[fcnt] = offIVBLOK.FILERCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.DATASCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "INT-FTP Bytes Sent";
			internalnames	[fcnt] = offIVBLOK.DATASCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.DATARCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "INT-FTP Bytes Received";
			internalnames	[fcnt] = offIVBLOK.DATARCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.TERMSCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Telnet Bytes Sent";
			internalnames	[fcnt] = offIVBLOK.TERMSCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.TERMRCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Telnet Bytes Received";
			internalnames	[fcnt] = offIVBLOK.TERMRCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.TCPSCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "TCP Bytes Sent";
			internalnames	[fcnt] = offIVBLOK.TCPSCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.TCPRCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "TCP Bytes Received";
			internalnames	[fcnt] = offIVBLOK.TCPRCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.UDPSCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "UDP Bytes Sent";
			internalnames	[fcnt] = offIVBLOK.UDPSCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.UDPRCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "UDP Bytes Received";
			internalnames	[fcnt] = offIVBLOK.UDPRCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.IPSCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "IP Bytes Sent";
			internalnames	[fcnt] = offIVBLOK.IPSCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.IPRCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "IP Bytes Received";
			internalnames	[fcnt] = offIVBLOK.IPRCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.ARPIPCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "ARPs In";
			internalnames	[fcnt] = offIVBLOK.ARPIPCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.PROC6CNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "ARP Inbound Requests";
			internalnames	[fcnt] = offIVBLOK.PROC6CNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.PROC4CNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "ARP Outbound Requests";
			internalnames	[fcnt] = offIVBLOK.PROC4CNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.PROC5CNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "ARP Outbound Replies";
			internalnames	[fcnt] = offIVBLOK.PROC5CNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.PROC0CNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Received Blocks(IPNL3172)";
			internalnames	[fcnt] = offIVBLOK.PROC0CNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.PROC2CNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Transmitted Blocks(IPNL3172)";
			internalnames	[fcnt] = offIVBLOK.PROC2CNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.PROC1CNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Inbound Datagrams(IPNL3172)";
			internalnames	[fcnt] = offIVBLOK.PROC1CNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.PROC3CNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Outbound Datagrams(IPNL3172)";
			internalnames	[fcnt] = offIVBLOK.PROC3CNT.ToString();
			#endregion
			#region Set the data parameters - other
			fcnt++; 
			varosets	[fcnt] = (int)offIVBLOK.NONIPCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Non-IP Count";
			internalnames	[fcnt] = offIVBLOK.NONIPCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.MISIPCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Misdirected IP";
			internalnames	[fcnt] = offIVBLOK.MISIPCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2CTUDP;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Discarded UDP";
			internalnames	[fcnt] = offIVBLOK.V2CTUDP.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2CTICMP;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Unsupported ICMP";
			internalnames	[fcnt] = offIVBLOK.V2CTICMP.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2CTIGMP;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Unsupported IGMP";
			internalnames	[fcnt] = offIVBLOK.V2CTIGMP.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2CTIP;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Unsupported Protocol";
			internalnames	[fcnt] = offIVBLOK.V2CTIP.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2CTREJ;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Connect Rejections";
			internalnames	[fcnt] = offIVBLOK.V2CTREJ.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.REFVICNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Inbound Rejections";
			internalnames	[fcnt] = offIVBLOK.REFVICNT.ToString();
			#endregion
			#region Set the data parameters - errors
			fcnt++; 
			varosets	[fcnt] = (int)offIVBLOK.V2CTTCHK;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "TCP Checksum Errors";
			internalnames	[fcnt] = offIVBLOK.V2CTTCHK.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2CTICHK;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "IP Checksum Errors";
			internalnames	[fcnt] = offIVBLOK.V2CTICHK.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2CTUCHK;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "UDP Checksum Errors";
			internalnames	[fcnt] = offIVBLOK.V2CTUCHK.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2CTCCHK;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "ICMP Checksum Errors";
			internalnames	[fcnt] = offIVBLOK.V2CTCCHK.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offIVBLOK.V2CTLENE;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Datagram Length Errors";
			internalnames	[fcnt] = offIVBLOK.V2CTLENE.ToString();
			#endregion
			#region Add the data arrays to a collection
			fields.Add(varosets);
			fields.Add(vartypes);
			fields.Add(varlengths);
			fields.Add(friendlynames);
			fields.Add(internalnames);
			#endregion
			return fields;
		}
		public ArrayList MakeFieldsTDCPU()
		{
			int fieldcnt = 7;
			ArrayList fields = new ArrayList(5);
			#region Initialize the arrays
			int[]			varosets =		new int[fieldcnt];
			RawDataTypes[]		vartypes =		new RawDataTypes[fieldcnt];
			int[]			varlengths =	new int[fieldcnt];
			string[]		friendlynames = new string[fieldcnt];
			string[]		internalnames = new string[fieldcnt];
			#endregion
			#region Set the data parameters
			int fcnt = 0;
			varosets	[fcnt] = (int)offTDCPU.TUCPUID;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "CPU Id";
			internalnames	[fcnt] = offTDCPU.TUCPUID.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offTDCPU.TUCPUFLG;
			vartypes		[fcnt] = RawDataTypes.HEX;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "Status Code";
			internalnames	[fcnt] = offTDCPU.TUCPUFLG.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offTDCPU.TUCPUDCY;
			vartypes		[fcnt] = RawDataTypes.UINT32;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Dispatch Cycles";
			internalnames	[fcnt] = offTDCPU.TUCPUDCY.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offTDCPU.TUCPUTIM;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Total Time (us)";
			internalnames	[fcnt] = offTDCPU.TUCPUTIM.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offTDCPU.TUCPUNP;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Busy[Non-P](us)";
			internalnames	[fcnt] = offTDCPU.TUCPUNP.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offTDCPU.TUCPUSPN;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Spin (us)";
			internalnames	[fcnt] = offTDCPU.TUCPUSPN.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offTDCPU.TUCPUALB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Allbound (us)";
			internalnames	[fcnt] = offTDCPU.TUCPUALB.ToString();
			#endregion
			#region Add the data arrays to a collection
			fields.Add(varosets);
			fields.Add(vartypes);
			fields.Add(varlengths);
			fields.Add(friendlynames);
			fields.Add(internalnames);
			#endregion
			return fields;//return the collection
		}				
		public ArrayList MakeFieldsGVVP()
		{
			int fieldcnt = 9;
			ArrayList fields = new ArrayList(5);
			#region Initialize the arrays
			int[]			varosets =		new int[fieldcnt];
			RawDataTypes[]		vartypes =		new RawDataTypes[fieldcnt];
			int[]			varlengths =	new int[fieldcnt];
			string[]		friendlynames = new string[fieldcnt];
			string[]		internalnames = new string[fieldcnt];
			#endregion
			#region Set the data parameters
			int fcnt = 0;
			varosets	[fcnt] = (int)offGVVP.GVVPPTID;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "PID";
			internalnames	[fcnt] = offGVVP.GVVPPTID.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offGVVP.GVVPPWRN;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Power Job Name";
			internalnames	[fcnt] = offGVVP.GVVPPWRN.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offGVVP.GVVPJBNM;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "VSE Job Name";
			internalnames	[fcnt] = offGVVP.GVVPJBNM.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offGVVP.GVVPJSTM;
			vartypes		[fcnt] = RawDataTypes.STCK;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Job Start Time";
			internalnames	[fcnt] = offGVVP.GVVPJSTM.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offGVVP.GVVPSTEP;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Step Name";
			internalnames	[fcnt] = offGVVP.GVVPSTEP.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offGVVP.GVVPSSTM;
			vartypes		[fcnt] = RawDataTypes.STCK;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Step Start Time";
			internalnames	[fcnt] = offGVVP.GVVPSSTM.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offGVVP.GVVPSIOS;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "SIO Count";
			internalnames	[fcnt] = offGVVP.GVVPSIOS.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offGVVP.GVVPCPUT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "CPU Time (16us)";
			internalnames	[fcnt] = offGVVP.GVVPCPUT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offGVVP.GVVPPRTY;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "Priority";
			internalnames	[fcnt] = offGVVP.GVVPPRTY.ToString();
			#endregion
			#region Add the data arrays to a collection
			fields.Add(varosets);
			fields.Add(vartypes);
			fields.Add(varlengths);
			fields.Add(friendlynames);
			fields.Add(internalnames);
			#endregion
			return fields;
		}			
		public ArrayList MakeFieldsCCBLOK(char ver)
		{
			int fieldcnt = 26;
            if (ver == 'F')
            { fieldcnt += 1; }//CCPHASE Added
			ArrayList fields = new ArrayList(5);
			#region Initialize the arrays
			int[]			varosets =		new int[fieldcnt];
			RawDataTypes[]		vartypes =		new RawDataTypes[fieldcnt];
			int[]			varlengths =	new int[fieldcnt];
			string[]		friendlynames = new string[fieldcnt];
			string[]		internalnames = new string[fieldcnt];
			#endregion
			#region Set the data parameters
			int fcnt = 0;
			varosets	[fcnt] = (int)offCCBLOK.CCLOPORT;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "Local Port";
			internalnames	[fcnt] = offCCBLOK.CCLOPORT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCFOPORT;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "Forgn Port";
			internalnames	[fcnt] = offCCBLOK.CCFOPORT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCFOIP;
			vartypes		[fcnt] = RawDataTypes.IPADDR;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "Forgn IP";
			internalnames	[fcnt] = offCCBLOK.CCFOIP.ToString();
			fcnt++;
			
			varosets	[fcnt] = (int)offCCBLOK.CCFLAGAA;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "FlagAA";
			internalnames	[fcnt] = offCCBLOK.CCFLAGAA.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCLOCAL;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "FlagINT";
			internalnames	[fcnt] = offCCBLOK.CCLOCAL.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCPROTO;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "Protocol";
			internalnames	[fcnt] = offCCBLOK.CCPROTO.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCSTATE;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "State";
			internalnames	[fcnt] = offCCBLOK.CCSTATE.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.PID;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "PID";
			internalnames	[fcnt] = offCCBLOK.PID.ToString();
			fcnt++;
            if (ver == 'F')
            {
                varosets[fcnt] = (int)offCCBLOK.CCPHASE;
                vartypes[fcnt] = RawDataTypes.EBCDIC;
                varlengths[fcnt] = 8;
                friendlynames[fcnt] = "Phase Name";
                internalnames[fcnt] = offCCBLOK.CCPHASE.ToString();
                fcnt++;
            }
            varosets	[fcnt] = (int)offCCBLOK.CCIDENT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Start Time";
			internalnames	[fcnt] = offCCBLOK.CCIDENT.ToString();
			fcnt++;

			
			varosets	[fcnt] = (int)offCCBLOK.CCIBCNTI;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Inbound Datagrams";
			internalnames	[fcnt] = offCCBLOK.CCIBCNTI.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCIBDUPI;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Inbound Datagrams Dup";
			internalnames	[fcnt] = offCCBLOK.CCIBDUPI.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCBTCNTI;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Inbound Bytes";
			internalnames	[fcnt] = offCCBLOK.CCBTCNTI.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCBTDUPI;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Inbound Bytes Dup";
			internalnames	[fcnt] = offCCBLOK.CCBTDUPI.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCIBCNTO;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Outbound Datagrams";
			internalnames	[fcnt] = offCCBLOK.CCIBCNTO.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCIBDUPO;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Outbound Datagrams Retr";
			internalnames	[fcnt] = offCCBLOK.CCIBDUPO.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCBTCNTO;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Outbound Bytes";
			internalnames	[fcnt] = offCCBLOK.CCBTCNTO.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCBTDUPO;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Outbound Bytes Retr";
			internalnames	[fcnt] = offCCBLOK.CCBTDUPO.ToString();
			fcnt++;

			varosets	[fcnt] = (int)offCCBLOK.CCRETMOD;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "In Retransmit Mode";
			internalnames	[fcnt] = offCCBLOK.CCRETMOD.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCRETCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Retransmits";
			internalnames	[fcnt] = offCCBLOK.CCRETCNT.ToString();
			fcnt++;
			
			varosets	[fcnt] = (int)offCCBLOK.CCSOSCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Sends Issued";
			internalnames	[fcnt] = offCCBLOK.CCSOSCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCSORCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Recvs Issued";
			internalnames	[fcnt] = offCCBLOK.CCSORCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCDEPMAX;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Highest Depth";
			internalnames	[fcnt] = offCCBLOK.CCDEPMAX.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCMAXWND;
			vartypes		[fcnt] = RawDataTypes.UINT32;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "Max Send Window";
			internalnames	[fcnt] = offCCBLOK.CCMAXWND.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCRWINSZ;
			vartypes		[fcnt] = RawDataTypes.UINT32;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "Max Recv Window";
			internalnames	[fcnt] = offCCBLOK.CCRWINSZ.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCRWCCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Recv Window Closed";
			internalnames	[fcnt] = offCCBLOK.CCRWCCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offCCBLOK.CCSWSCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "SWS Count";
			internalnames	[fcnt] = offCCBLOK.CCSWSCNT.ToString();
			fcnt++;
			
			#endregion
			#region Add the data arrays to a collection
			fields.Add(varosets);
			fields.Add(vartypes);
			fields.Add(varlengths);
			fields.Add(friendlynames);
			fields.Add(internalnames);
			#endregion
			return fields;
		}
	    public ArrayList MakeFieldsLKBLOK()
		{
			int fieldcnt = 7;
			ArrayList fields = new ArrayList(5);
			#region Initialize the arrays
			int[]			varosets =		new int[fieldcnt];
			RawDataTypes[]	vartypes =		new RawDataTypes[fieldcnt];
			int[]			varlengths =	new int[fieldcnt];
			string[]		friendlynames = new string[fieldcnt];
			string[]		internalnames = new string[fieldcnt];
			#endregion
			#region Set the data parameters	
			int fcnt=0;
			varosets	[fcnt] = (int)offLKBLOK.LKBLKTYP;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "Block Type";
			internalnames	[fcnt] = offLKBLOK.LKBLKTYP.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offLKBLOK.LKNODE;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 16;
			friendlynames	[fcnt] = "Link ID";
			internalnames	[fcnt] = offLKBLOK.LKNODE.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offLKBLOK.LKTYPE;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 5;
			friendlynames	[fcnt] = "Link Type";
			internalnames	[fcnt] = offLKBLOK.LKTYPE.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offLKBLOK.LKIPADDR;
			vartypes		[fcnt] = RawDataTypes.IPADDR;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "IP Address";
			internalnames	[fcnt] = offLKBLOK.LKIPADDR.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offLKBLOK.LKCUU;
			vartypes		[fcnt] = RawDataTypes.HEX;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "CUU Name";
			internalnames	[fcnt] = offLKBLOK.LKCUU.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offLKBLOK.LKCUU2;
			vartypes		[fcnt] = RawDataTypes.HEX;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "Alternate CUU";
			internalnames	[fcnt] = offLKBLOK.LKCUU2.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offLKBLOK.LKMTU;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "MTU Size";
			internalnames	[fcnt] = offLKBLOK.LKMTU.ToString();
			#endregion
			#region Add the data arrays to a collection
			fields.Add(varosets);
			fields.Add(vartypes);
			fields.Add(varlengths);
			fields.Add(friendlynames);
			fields.Add(internalnames);
			#endregion
			return fields;
		}
		public ArrayList MakeFieldsISBLOK()
		{
			int fieldcnt = 28;
			ArrayList fields = new ArrayList(5);
			#region Initialize the arrays
			int[]			varosets =		new int[fieldcnt];
			RawDataTypes[]	vartypes =		new RawDataTypes[fieldcnt];
			int[]			varlengths =	new int[fieldcnt];
			string[]		friendlynames = new string[fieldcnt];
			string[]		internalnames = new string[fieldcnt];
			#endregion
			#region Set the data parameters	
			int fcnt=0;
			varosets	[fcnt] = (int)offISBLOK.ISIPADDR;
			vartypes		[fcnt] = RawDataTypes.IPADDR;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "IP Address";
			internalnames	[fcnt] = offISBLOK.ISIPADDR.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISREFUSE;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "Refuse Flag";
			internalnames	[fcnt] = offISBLOK.ISREFUSE.ToString();
			fcnt++;
			#region Datagrams
			varosets	[fcnt] = (int)offISBLOK.ISMISIP;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Misdirected IP Datagrams";
			internalnames	[fcnt] = offISBLOK.ISMISIP.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISNONIP;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Non-IP Datagrams";
			internalnames	[fcnt] = offISBLOK.ISNONIP.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISARPIN;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "ARP Inbound Datagrams";
			internalnames	[fcnt] = offISBLOK.ISARPIN.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISARPOU;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "ARP Outbound Datagrams";
			internalnames	[fcnt] = offISBLOK.ISARPOU.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISICMIN;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "ICMP Inbound Datagrams";
			internalnames	[fcnt] = offISBLOK.ISICMIN.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISICMOU;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "ICMP Outbound Datagrams";
			internalnames	[fcnt] = offISBLOK.ISICMOU.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISIPIN;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "IP Inbound Datagrams";
			internalnames	[fcnt] = offISBLOK.ISIPIN.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISIPOU;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "IP Outbound Datagrams";
			internalnames	[fcnt] = offISBLOK.ISIPOU.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISTCPIN;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "TCP Inbound Datagrams";
			internalnames	[fcnt] = offISBLOK.ISTCPIN.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISTCPOU;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "TCP Outbound Datagrams";
			internalnames	[fcnt] = offISBLOK.ISTCPOU.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISUDPIN;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "UDP Inbound Datagrams";
			internalnames	[fcnt] = offISBLOK.ISUDPIN.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISUDPOU;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "UDP Outbound Datagrams";
			internalnames	[fcnt] = offISBLOK.ISUDPOU.ToString();
			fcnt++;
			#endregion
			#region Bytes
			varosets	[fcnt] = (int)offISBLOK.ISMISIPB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Misdirected IP Bytes";
			internalnames	[fcnt] = offISBLOK.ISMISIPB.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISNONIPB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Non-IP Bytes";
			internalnames	[fcnt] = offISBLOK.ISNONIPB.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISARPINB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "ARP Inbound Bytes";
			internalnames	[fcnt] = offISBLOK.ISARPINB.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISARPOUB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "ARP Outbound Bytes";
			internalnames	[fcnt] = offISBLOK.ISARPOUB.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISICMINB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "ICMP Inbound Bytes";
			internalnames	[fcnt] = offISBLOK.ISICMINB.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISICMOUB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "ICMP Outbound Bytes";
			internalnames	[fcnt] = offISBLOK.ISICMOUB.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISIPINB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "IP Inbound Bytes";
			internalnames	[fcnt] = offISBLOK.ISIPINB.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISIPOUB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "IP Outbound Bytes";
			internalnames	[fcnt] = offISBLOK.ISIPOUB.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISTCPINB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "TCP Inbound Bytes";
			internalnames	[fcnt] = offISBLOK.ISTCPINB.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISTCPOUB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "TCP Outbound Bytes";
			internalnames	[fcnt] = offISBLOK.ISTCPOUB.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISUDPINB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "UDP Inbound Bytes";
			internalnames	[fcnt] = offISBLOK.ISUDPINB.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISUDPOUB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "UDP Outbound Bytes";
			internalnames	[fcnt] = offISBLOK.ISUDPOUB.ToString();
			fcnt++;
			#endregion
			varosets	[fcnt] = (int)offISBLOK.ISREFIN;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Refused Bytes";
			internalnames	[fcnt] = offISBLOK.ISREFIN.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offISBLOK.ISREFINB;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Refused Datagrams";
			internalnames	[fcnt] = offISBLOK.ISREFINB.ToString();
			#endregion
			#region Add the data arrays to a collection
			fields.Add(varosets);
			fields.Add(vartypes);
			fields.Add(varlengths);
			fields.Add(friendlynames);
			fields.Add(internalnames);
			#endregion
			return fields;
		}
        public ArrayList MakeFieldsRSBLOK()
        {
            int fieldcnt = 17;
            ArrayList fields = new ArrayList(5);
            #region Initialize the arrays
            int[] varosets = new int[fieldcnt];
            RawDataTypes[] vartypes = new RawDataTypes[fieldcnt];
            int[] varlengths = new int[fieldcnt];
            string[] friendlynames = new string[fieldcnt];
            string[] internalnames = new string[fieldcnt];
            #endregion
            #region Set the data parameters
            int fcnt = 0;
            varosets[fcnt] = (int)offRSBLOK.RSOCLOCK;
            vartypes[fcnt] = RawDataTypes.STCK;
            varlengths[fcnt] = 8;
            friendlynames[fcnt] = "Time of Day";
            internalnames[fcnt] = offRSBLOK.RSOCLOCK.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOCCIDN;
            vartypes[fcnt] = RawDataTypes.UINT64;
            varlengths[fcnt] = 8;
            friendlynames[fcnt] = "Connection ID";
            internalnames[fcnt] = offRSBLOK.RSOCCIDN.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSODESC;
            vartypes[fcnt] = RawDataTypes.HEX;
            varlengths[fcnt] = 4;
            friendlynames[fcnt] = "Socket Descriptor";
            internalnames[fcnt] = offRSBLOK.RSODESC.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOQUEUE;
            vartypes[fcnt] = RawDataTypes.UINT32;
            varlengths[fcnt] = 4;
            friendlynames[fcnt] = "Queue Depth";
            internalnames[fcnt] = offRSBLOK.RSOQUEUE.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOIPAD;
            vartypes[fcnt] = RawDataTypes.IPADDR;
            varlengths[fcnt] = 4;
            friendlynames[fcnt] = "Forgn IP";
            internalnames[fcnt] = offRSBLOK.RSOIPAD.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOLIPAD;
            vartypes[fcnt] = RawDataTypes.IPADDR;
            varlengths[fcnt] = 4;
            friendlynames[fcnt] = "Local IP";
            internalnames[fcnt] = offRSBLOK.RSOLIPAD.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOPORT;
            vartypes[fcnt] = RawDataTypes.UINT16;
            varlengths[fcnt] = 2;
            friendlynames[fcnt] = "Forgn Port";
            internalnames[fcnt] = offRSBLOK.RSOPORT.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOLPORT;
            vartypes[fcnt] = RawDataTypes.UINT16;
            varlengths[fcnt] = 2;
            friendlynames[fcnt] = "Local Port";
            internalnames[fcnt] = offRSBLOK.RSOLPORT.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOBASE;
            vartypes[fcnt] = RawDataTypes.HEX;
            varlengths[fcnt] = 4;
            friendlynames[fcnt] = "Base Socket Address";
            internalnames[fcnt] = offRSBLOK.RSOBASE.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOTRNID;
            vartypes[fcnt] = RawDataTypes.EBCDIC;
            varlengths[fcnt] = 4;
            friendlynames[fcnt] = "CICS ID";
            internalnames[fcnt] = offRSBLOK.RSOTRNID.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOTASKN;
            vartypes[fcnt] = RawDataTypes.UINT32;
            varlengths[fcnt] = 4;
            friendlynames[fcnt] = "CICS Task";
            internalnames[fcnt] = offRSBLOK.RSOTASKN.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOSOCKN;
            vartypes[fcnt] = RawDataTypes.UINT32;
            varlengths[fcnt] = 4;
            friendlynames[fcnt] = "Socket Number";
            internalnames[fcnt] = offRSBLOK.RSOSOCKN.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOSOCK;
            vartypes[fcnt] = RawDataTypes.HEX;
            varlengths[fcnt] = 4;
            friendlynames[fcnt] = "Socket Address";
            internalnames[fcnt] = offRSBLOK.RSOSOCK.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOFLAG;
            vartypes[fcnt] = RawDataTypes.BYTE;
            varlengths[fcnt] = 1;
            friendlynames[fcnt] = "Flag 1";
            internalnames[fcnt] = offRSBLOK.RSOFLAG.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOOPT;
            vartypes[fcnt] = RawDataTypes.BYTE;
            varlengths[fcnt] = 1;
            friendlynames[fcnt] = "Socket Opt";
            internalnames[fcnt] = offRSBLOK.RSOOPT.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOFLAG2;
            vartypes[fcnt] = RawDataTypes.BYTE;
            varlengths[fcnt] = 1;
            friendlynames[fcnt] = "Flag 2";
            internalnames[fcnt] = offRSBLOK.RSOFLAG2.ToString();
            fcnt++;
            varosets[fcnt] = (int)offRSBLOK.RSOTYPE;
            vartypes[fcnt] = RawDataTypes.BYTE;
            varlengths[fcnt] = 1;
            friendlynames[fcnt] = "Type";
            internalnames[fcnt] = offRSBLOK.RSOTYPE.ToString();
            fcnt++;
            #endregion
            #region Add the data arrays to a collection
            fields.Add(varosets);
            fields.Add(vartypes);
            fields.Add(varlengths);
            fields.Add(friendlynames);
            fields.Add(internalnames);
            #endregion
            return fields;
        }		
		//Record Bloks
		public ArrayList MakeFieldsSTRT()
		{
			int fieldcnt = 4;
			ArrayList fields = new ArrayList(5);
			#region Initialize the arrays
			int[]			varosets =		new int[fieldcnt];
			RawDataTypes[]	vartypes =		new RawDataTypes[fieldcnt];
			int[]			varlengths =	new int[fieldcnt];
			string[]		friendlynames = new string[fieldcnt];
			string[]		internalnames = new string[fieldcnt];
			#endregion
			#region Set the data parameters	
			int fcnt=0;
			varosets	[fcnt] = (int)offSTRT.STRTCTOD;
			vartypes		[fcnt] = RawDataTypes.STCK;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Start Time";
			internalnames	[fcnt] = offSTRT.STRTCTOD.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSTRT.STRTCPUI;
			vartypes		[fcnt] = RawDataTypes.CPUID;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Cpu ID";
			internalnames	[fcnt] = offSTRT.STRTCPUI.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSTRT.STRTPROG;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Program ID";
			internalnames	[fcnt] = offSTRT.STRTPROG.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offSTRT.STRTVERS;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Program Version";
			internalnames	[fcnt] = offSTRT.STRTVERS.ToString();
			#endregion
			#region Add the data arrays to a collection
			fields.Add(varosets);
			fields.Add(vartypes);
			fields.Add(varlengths);
			fields.Add(friendlynames);
			fields.Add(internalnames);
			#endregion
			return fields;
		}
	    public ArrayList MakeFieldsT002()
		{
			int fieldcnt = 16;//(int)RawDataBloks.LKBLOK;
			ArrayList fields = new ArrayList(5);
			#region Initialize the arrays
			int[]			varosets =		new int[fieldcnt];
			RawDataTypes[]	vartypes =		new RawDataTypes[fieldcnt];
			int[]			varlengths =	new int[fieldcnt];
			string[]		friendlynames = new string[fieldcnt];
			string[]		internalnames = new string[fieldcnt];
			#endregion
			#region Set the data parameters	
			int fcnt=0;
			varosets	[fcnt] = (int)offT002.FTNODE;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 16;
			friendlynames	[fcnt] = "FTP Node Name";
			internalnames	[fcnt] = offT002.FTNODE.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTACUSER;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 16;
			friendlynames	[fcnt] = "FTP User ID";
			internalnames	[fcnt] = offT002.FTACUSER.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTBXSNTA;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Bytes Sent/Acked";
			internalnames	[fcnt] = offT002.FTBXSNTA.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTBXRCVC;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Bytes Received";
			internalnames	[fcnt] = offT002.FTBXRCVC.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTBXSTIM;
			vartypes		[fcnt] = RawDataTypes.STCK;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Start Time";
			internalnames	[fcnt] = offT002.FTBXSTIM.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTBXTREP;
			vartypes		[fcnt] = RawDataTypes.STCK;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "End Time";
			internalnames	[fcnt] = offT002.FTBXTREP.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTBXFIRC;
			vartypes		[fcnt] = RawDataTypes.UINT32;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "Files Received";
			internalnames	[fcnt] = offT002.FTBXFIRC.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTBXFISC;
			vartypes		[fcnt] = RawDataTypes.UINT32;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "Files Sent";
			internalnames	[fcnt] = offT002.FTBXFISC.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTLIPADR;
			vartypes		[fcnt] = RawDataTypes.IPADDR;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "Vse IP Address";
			internalnames	[fcnt] = offT002.FTLIPADR.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTACIPAD;
			vartypes		[fcnt] = RawDataTypes.IPADDR;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "Client IP Address";
			internalnames	[fcnt] = offT002.FTACIPAD.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTPORT;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "Vse Port";
			internalnames	[fcnt] = offT002.FTPORT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTACPORT;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "Client Port";
			internalnames	[fcnt] = offT002.FTACPORT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTBXTID;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "Vse Task ID";
			internalnames	[fcnt] = offT002.FTBXTID.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTSSLFLG;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "SSL Flag";
			internalnames	[fcnt] = offT002.FTSSLFLG.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTFLAG02;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "General Purpose Flag";
			internalnames	[fcnt] = offT002.FTFLAG02.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT002.FTBXFDIP;
			vartypes		[fcnt] = RawDataTypes.IPADDR;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "Foreign Data IP Address";
			internalnames	[fcnt] = offT002.FTBXFDIP.ToString();
			#endregion
			#region Add the data arrays to a collection
			fields.Add(varosets);
			fields.Add(vartypes);
			fields.Add(varlengths);
			fields.Add(friendlynames);
			fields.Add(internalnames);
			#endregion
			return fields;
		}
		public ArrayList MakeFieldsT003()
		{
			int fieldcnt = 1;//(int)RawDataBloks.LKBLOK;
			ArrayList fields = new ArrayList(5);
			#region Initialize the arrays
			int[]			varosets =		new int[fieldcnt];
			RawDataTypes[]	vartypes =		new RawDataTypes[fieldcnt];
			int[]			varlengths =	new int[fieldcnt];
			string[]		friendlynames = new string[fieldcnt];
			string[]		internalnames = new string[fieldcnt];
			#endregion
			#region Set the data parameters	
			int fcnt=0;
			varosets	[fcnt] = (int)offT003.T003MSGT;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Message Text";
			internalnames	[fcnt] = offT003.T003MSGT.ToString();
			#endregion
			#region Add the data arrays to a collection
			fields.Add(varosets);
			fields.Add(vartypes);
			fields.Add(varlengths);
			fields.Add(friendlynames);
			fields.Add(internalnames);
			#endregion
			return fields;
		}
		public ArrayList MakeFieldsT004()
		{
			int fieldcnt = 27;
			ArrayList fields = new ArrayList(5);
			#region Initialize the arrays
			int[]			varosets =		new int[fieldcnt];
			RawDataTypes[]		vartypes =		new RawDataTypes[fieldcnt];
			int[]			varlengths =	new int[fieldcnt];
			string[]		friendlynames = new string[fieldcnt];
			string[]		internalnames = new string[fieldcnt];
			#endregion
			#region Set the data parameters
			int fcnt = 0;
			varosets	[fcnt] = (int)offT004.CCLOPORT;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "Local Port";
			internalnames	[fcnt] = offT004.CCLOPORT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCFOPORT;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "Forgn Port";
			internalnames	[fcnt] = offT004.CCFOPORT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCFOIP;
			vartypes		[fcnt] = RawDataTypes.IPADDR;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "Forgn IP";
			internalnames	[fcnt] = offT004.CCFOIP.ToString();
			fcnt++;
			
			varosets	[fcnt] = (int)offT004.CCFLAGAA;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "FlagAA";
			internalnames	[fcnt] = offT004.CCFLAGAA.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCLOCAL;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "FlagINT";
			internalnames	[fcnt] = offT004.CCLOCAL.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCPROTO;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "Protocol";
			internalnames	[fcnt] = offT004.CCPROTO.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCSTATE;
			vartypes		[fcnt] = RawDataTypes.BYTE;
			varlengths		[fcnt] = 1;
			friendlynames	[fcnt] = "State";
			internalnames	[fcnt] = offT004.CCSTATE.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.PID;
			vartypes		[fcnt] = RawDataTypes.EBCDIC;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "PID";
			internalnames	[fcnt] = offT004.PID.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCIDENT;
			vartypes		[fcnt] = RawDataTypes.STCK;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Start Time";
			internalnames	[fcnt] = offT004.CCIDENT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCIDEND;
			vartypes		[fcnt] = RawDataTypes.STCK;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "End Time";
			internalnames	[fcnt] = offT004.CCIDEND.ToString();
			fcnt++;
			
			varosets	[fcnt] = (int)offT004.CCIBCNTI;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Inbound Datagrams";
			internalnames	[fcnt] = offT004.CCIBCNTI.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCIBDUPI;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Inbound Datagrams Dup";
			internalnames	[fcnt] = offT004.CCIBDUPI.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCBTCNTI;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Inbound Bytes";
			internalnames	[fcnt] = offT004.CCBTCNTI.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCBTDUPI;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Inbound Bytes Dup";
			internalnames	[fcnt] = offT004.CCBTDUPI.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCIBCNTO;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Outbound Datagrams";
			internalnames	[fcnt] = offT004.CCIBCNTO.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCIBDUPO;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Outbound Datagrams Retr";
			internalnames	[fcnt] = offT004.CCIBDUPO.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCBTCNTO;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Outbound Bytes";
			internalnames	[fcnt] = offT004.CCBTCNTO.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCBTDUPO;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Outbound Bytes Retr";
			internalnames	[fcnt] = offT004.CCBTDUPO.ToString();
			fcnt++;

			varosets	[fcnt] = (int)offT004.CCRETMOD;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "In Retransmit Mode";
			internalnames	[fcnt] = offT004.CCRETMOD.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCRETCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Retransmits";
			internalnames	[fcnt] = offT004.CCRETCNT.ToString();
			fcnt++;
			
			varosets	[fcnt] = (int)offT004.CCSOSCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Sends Issued";
			internalnames	[fcnt] = offT004.CCSOSCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCSORCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Recvs Issued";
			internalnames	[fcnt] = offT004.CCSORCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCDEPMAX;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Highest Depth";
			internalnames	[fcnt] = offT004.CCDEPMAX.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCMAXWND;
			vartypes		[fcnt] = RawDataTypes.UINT32;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "Max Send Window";
			internalnames	[fcnt] = offT004.CCMAXWND.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCRWINSZ;
			vartypes		[fcnt] = RawDataTypes.UINT32;
			varlengths		[fcnt] = 4;
			friendlynames	[fcnt] = "Max Recv Window";
			internalnames	[fcnt] = offT004.CCRWINSZ.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCRWCCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "Recv Window Closed";
			internalnames	[fcnt] = offT004.CCRWCCNT.ToString();
			fcnt++;
			varosets	[fcnt] = (int)offT004.CCSWSCNT;
			vartypes		[fcnt] = RawDataTypes.UINT64;
			varlengths		[fcnt] = 8;
			friendlynames	[fcnt] = "SWS Count";
			internalnames	[fcnt] = offT004.CCSWSCNT.ToString();
			fcnt++;
			/*
			varosets	[fcnt] = (int)offT004.PIK;
			vartypes		[fcnt] = RawDataTypes.UINT16;
			varlengths		[fcnt] = 2;
			friendlynames	[fcnt] = "PIK";
			internalnames	[fcnt] = offT004.PIK.ToString();
			fcnt++;
			*/
			#endregion
			#region Add the data arrays to a collection
			fields.Add(varosets);
			fields.Add(vartypes);
			fields.Add(varlengths);
			fields.Add(friendlynames);
			fields.Add(internalnames);
			#endregion
			return fields;
		}
        /// <summary>
        /// Creates a strongly typed DataSet.
        /// </summary>
        /// <returns>A dataset containing all raw data tables</returns>
        public DataSet CreateRawDataSet(char ver)
        {
            DataSet dset = new DataSet("RawDataSet");

            AddTable(dset, "SVSEINIT", MakeFieldsSVSEINIT(), true);
            AddTable(dset, "IVBLOK", MakeFieldsIVBLOK(), true);
            AddTable(dset, "TDCPU", MakeFieldsTDCPU(), true);
            AddTable(dset, "GVVP", MakeFieldsGVVP(), true);
            AddTable(dset, "CCBLOK", MakeFieldsCCBLOK(ver), true);
            AddTable(dset, "LKBLOK", MakeFieldsLKBLOK(), true);
            AddTable(dset, "ISBLOK", MakeFieldsISBLOK(), true);
            AddTable(dset, "RSBLOK", MakeFieldsRSBLOK(), true);
            AddTable(dset, "STRT", MakeFieldsSTRT(), false);
            AddTable(dset, "T002", MakeFieldsT002(), false);
            AddTable(dset, "T003", MakeFieldsT003(), false);
            AddTable(dset, "T004", MakeFieldsT004(), false);

            return dset;

        }
		
		private void AddTable(DataSet dset, string tableName, ArrayList feilds, bool poll)
		{
			DataTable table = new DataTable(tableName);//Create an empty table with the appropriate name
			dset.Tables.Add(table);//Add the new table to the dataset
			if(poll)
			{table.Columns.Add(new DataColumn("Poll Time",System.Type.GetType("System.DateTime")));}//Add "Poll Time" column
			
			string[]		names = (string[])feilds[4];
			RawDataTypes[]	types = (RawDataTypes[])feilds[1]; 
			
			for(int i=0; i<names.Length; i++)
			{								 
				string dataTypeStr = "";
				RawDataTypes type = (RawDataTypes)types[i];
				#region Set the dataTypeStr
				switch(type)
				{
					case RawDataTypes.STCK:
						dataTypeStr = "System.DateTime";
						break;
					case RawDataTypes.BYTE:
						dataTypeStr = "System.Byte";
						break;
					case RawDataTypes.UINT16:
						dataTypeStr = "System.UInt16";
						break;
					case RawDataTypes.UINT32:
						dataTypeStr = "System.UInt32";
						break;
					case RawDataTypes.UINT64:
						dataTypeStr = "System.UInt64";
						break;
					case RawDataTypes.INT32:
						dataTypeStr = "System.Int32";
						break;
					default:// All other types are strings
						dataTypeStr = "System.String";
						break;
				}
				#endregion
				DataColumn col = new DataColumn(names[i],System.Type.GetType(dataTypeStr));
				table.Columns.Add(col);//Add the new column to the table
			}
					
		}
                
	}

    public struct CommandResponse
    {
        public string Text;
        public int Count;
        public int Length;
    }

    public enum PollCommands : int
    {
        LOGIN,
        OPENDATA,
        HARTBEAT,
        SVSEINIT,
        TDCPU001,
        IVBLOK01,
        GVVP1000,
        CCBLOK02,
        RSOBLK01,
        LKBLOK01,
        ISBLOK01,
        ISBLOKAL,
        TRACIP01
    }

    public enum RawDataTypes : int
    {
        STCK = 0,		// (8 byte) STCK utc			-> convert to a DateTime object
        UINT64 = 1,		// (8 byte) unsigned integer	-> convert to a ulong object
        UINT32 = 2,		// (4 byte) unsigned integer	-> convert to a uint object
        UINT16 = 3,		// (2 byte) unsigned integer	-> convert to a ushort object
        INT32 = 4,		// (4 byte) unsigned integer	-> convert to a uint object
        HEX = 5,		// (2 byte) hex string(0-F)		-> convert to a string object
        BYTE = 6,		// (1 byte) an 8bit byte		-> convert to a byte object
        EBCDIC = 7,		// (varies) ebcdic string		-> convert to an ascii string object		
        IPADDR = 8,		// (4 byte) ip address			-> format as '255.255.255.255' string object	
        CPUID = 9,		// (8 byte) vse cpuid			-> format as '00000000 000000000' string object
        VRM = 10		// (3 byte) vse version/release -> format as 'VV.RR'(.MM is omitted) string object
    }
    public enum RawDataBloks : int
    {					//= number of fields in the table
        SVSEINIT = 0,	//= 37,
        IVBLOK = 1,	    //= 59,
        TDCPU = 2,	    //= 7,
        GVVP = 3,	    //= 9,
        CCBLOK = 4,	    //= 17, 
        LKBLOK = 5,	    //= 7
        ISBLOK = 6,
        RSBLOK = 7,
        STRT = 101,	//Startup Record
        T002 = 102,	//FTP Termination
        T003 = 103,	//TCP/IP Message
        T004 = 104	//Connection Termination
    }

    public enum offSVSEINIT : int
    {
        /*TCP/IP info			= 6*/
        SINTIPID = 0x0,
        SINTIJNM = 0x2,
        SINTISDT = 0xA,
        SINTIPAD = 0x12,
        SINTISID = 0x16,
        SINTIVER = 0x18,
        /*VSE info				= 7 */
        SINTVCPU = 0x20,
        SINTVIPL = 0x28,
        SINTVVER = 0x30,
        SINTIIBM = 0x33,
        SINTICNT = 0x34,
        SINTPSID = 0x36,
        SINTPNAM = 0x37,
        /*SeeVSE(SVSESRVR) info = 10*/
        SINTFLG1 = 0x3f,// '80' = European date format
        SINTSPID = 0x40,
        SINTSJNM = 0x42,
        SINTSTIM = 0x4A,
        SINTSVER = 0x52,
        SINTCPRT = 0x5A,
        SINTATSK = 0x5C,// VSE HIGHEST SUBTASK
        SINTNTSK = 0x5E,// VSE NUMBER OF SUBTASKS SUPPORTED
        SINTNPRT = 0x60,// VSE NUMBER OF PARTITIONS
        SINTAPRT = 0x62,
        /*Time offset			= 1*/
        SINTGMT0 = 0x64,
        /*System Info			= 6*/
        SINTSSCH = 0x68,
        SINTIOIN = 0x70,
        SINTPCHK = 0x78,
        SINTEXTI = 0x80,
        SINTPHLD = 0x88,
        SINTSVCI = 0x90,
        /*CPU info - COMMON		= 5*/
        SINTCPUN = 0x98,
        SINTCPUA = 0x99,
        SINTCPUQ = 0x9A,
        //UNUSED = 0x9B
        SINTCRTM = 0x9C,
        SINTSTCK = 0xA4,
        SINTNCCA = 0xAC,
        SINTNTCS = 0xAE
    }
    public enum offIVBLOK : int
    {
        #region Not Used
        /*
		#region info = 4 doubled in SVSEINIT
		IVTCPVER =	0x0,	//TCP/IP version number+ service pack letter
		IVSYSID =	0x8,	//System Identifier
		IVIVPIK =	0xA,	//PID of TCP/IP partition
		IVIPADDR =	0xC,	//IP Address of host
		#endregion
		NONSVC7 =	0x18,	//?
		NONSVC7P =	0x20,	//?
		PROC7CNT =	0x1F0,	//Reserved for future use
		PROC8CNT =	0x1F8,	//Reserved for future use
		PROC9CNT =	0x200,	//Reserved for future use
		*/
        #endregion
        #region dispatch = 10
        V2DSPCNT = 0x128,	//Dispatches
        V2ACTCNT = 0x130,	//Active Dispatches 
        V2FXDCNT = 0x138,	//Fixed Dispatches
        V2QUICNT = 0x140,	//Quick Dispatches
        V2PERCNT = 0x148,	//Persistent Dispatches
        V2COMCNT = 0x150,	//Complete Dispatches
        V2PASCNT = 0x158,	//Passed Dispatches
        V2TOTIME = 0x160,	//Total Dispatcher Time
        WAITCNTR = 0x10,	//Dispatcher Waits
        CUSHONRE = 0x208,	//Storage Releases
        #endregion
        #region daemons = 12
        FTPCOUNT = 0x28,	//FTP Daemons
        V2FTPACT = 0xE8,	//Current Active FTP Daemons
        V2FTPMAX = 0xF0,	//Maximum Active FTP Daemons since being up
        TELCOUNT = 0x30,	//Telnet Daemons
        V2TLNACT = 0x108,	//Current Active Telnet Daemons
        V2TLNMAX = 0x110,	//Maximum Active Telnet Daemons since being up
        V2TLNBAC = 0x118,	//Current Active Telnet Buffers
        V2TLNBMX = 0x120,	//Maximum Active Telnet Buffers since being up
        LPDCOUNT = 0x38,	//LP Daemons
        HTTCOUNT = 0x40,	//HTTP Daemons
        V2SMTPCT = 0x210,	//SMTP Daemons
        V2POP3CT = 0x218,	//POP3 Daemons
        #endregion
        #region clients = 4
        FTPVICNT = 0x48,	//FTP Clients
        TELVICNT = 0x50,	//Telnet Clients
        LPDVICNT = 0x58,	//LPR Clients
        HTTVICNT = 0x60,	//HTTP Clients
        #endregion
        #region data = 20
        FILESCNT = 0x70,	//Internal FTP Files Sent
        FILERCNT = 0x78,	//Internal FTP Files Received
        DATASCNT = 0x80,	//Internal FTP Bytes Sent
        DATARCNT = 0x88,	//Internal FTP Bytes Received
        TERMSCNT = 0x90,	//Telnet Bytes Sent
        TERMRCNT = 0x98,	//Telnet Bytes Received
        TCPSCNT = 0xA0,	//TCP Bytes Sent
        TCPRCNT = 0xA8,	//TCP Bytes Received
        UDPSCNT = 0xB0,	//UDP Bytes Sent
        UDPRCNT = 0xB8,	//UDP Bytes Received
        IPSCNT = 0xC0,	//IP Bytes Sent
        IPRCNT = 0xC8,	//IP Bytes Received
        ARPIPCNT = 0xE0,	//Arps In
        PROC6CNT = 0x1E8,	//Arp Inbound Requests
        PROC4CNT = 0x1D8,	//Arp Outbound Requests
        PROC5CNT = 0x1E0,	//Arp Outbound Replies
        PROC0CNT = 0x1B8,	//IPNL3172 Received Blocks 
        PROC2CNT = 0x1C8,	//IPNL3172 Transmitted Blocks 
        PROC1CNT = 0x1C0,	//IPNL3172 Inbound Datagrams 
        PROC3CNT = 0x1D0,	//IPNL3172 Outbound Datagrams
        #endregion
        #region other = 8
        NONIPCNT = 0xD0,	//Non-IP
        MISIPCNT = 0xD8,	//Miss routed IP
        V2CTUDP = 0x168,	//Discarded UDP
        V2CTICMP = 0x170,	//Unsupported ICMP 	
        V2CTIGMP = 0x178,	//Unsupported IGMP
        V2CTIP = 0x180,	//Unsupported Protocol
        V2CTREJ = 0x188,	//Connect Rejections		
        REFVICNT = 0x68,	//Inbound TCP Rejections
        #endregion
        #region errors = 5
        V2CTTCHK = 0x190,	//TCP Checksum Errors
        V2CTICHK = 0x198,	//IP Checksum Errors
        V2CTUCHK = 0x1A0,	//UDP Checksum Errors
        V2CTCCHK = 0x1A8,	//ICMP Checksum Errors
        V2CTLENE = 0x1B0	//Datagram Length Errors
        #endregion
    }
    public enum offTDCPU : int
    {
        /*CPU info - SPECIFIC for each CPU*/
        TUCPUID = 0x0,
        TUCPUFLG = 0x2,
        TUCPUTIM = 0x4,
        TUCPUNP = 0xC,
        TUCPUSPN = 0x14,
        TUCPUALB = 0x1C,
        TUCPUDCY = 0x24
    }
    public enum offGVVP : int
    {
        /*Partition Info*/
        GVVPPWRN = 0x0,
        GVVPJBNM = 0x8,
        GVVPSTEP = 0x10,
        GVVPJSTM = 0x18,
        GVVPSSTM = 0x20,
        GVVPCPUT = 0x28,
        GVVPSIOS = 0x30,
        GVVPPTID = 0x38,
        GVVPPRTY = 0x3A
    }
    public enum offCCBLOK : int
    {
        /*Connection info*/
        CCSTATE = 0x0,
        CCPROTO = 0x1,
        CCIDENT = 0x2,
        CCLOPORT = 0xA,
        CCFOPORT = 0xC,
        CCFOIP = 0xE,
        CCFLAGAA = 0x12,
        CCLOCAL = 0x13,
        CCRETCNT = 0x14,
        CCIBCNTI = 0x1C,
        CCIBDUPI = 0x24,
        CCBTCNTI = 0x2C,
        CCBTDUPI = 0x34,
        CCIBCNTO = 0x3C,
        CCIBDUPO = 0x44,
        CCBTCNTO = 0x4C,
        CCBTDUPO = 0x54,
        CCSWSCNT = 0x5C,
        CCRETMOD = 0x64,
        CCRWCCNT = 0x6C,
        CCDEPMAX = 0x74,
        CCSOSCNT = 0x7C,
        CCSORCNT = 0x84,
        CCMAXWND = 0x8C,
        CCRWINSZ = 0x90,
        PID = 0x94,
        //PIK = 0x96//Partition ID Key - useless
        CCPHASE = 0x98
    }
    public enum offLKBLOK : int
    {
        /*Link info*/
        LKMTU = 0x0,
        LKNODE = 0x2,
        LKTYPE = 0x12,
        LKCUU = 0x17,
        LKIPADDR = 0x19,
        LKBLKTYP = 0x1D,
        LKCUU2 = 0x1E
    }
    public enum offISBLOK : int
    {
        ISIPADDR = 0x0,
        ISREFUSE = 0x4,
        ISMISIP = 0x98,
        ISNONIP = 0xA0,
        ISARPIN = 0xA8,
        ISARPOU = 0xB0,
        ISICMIN = 0xB8,
        ISICMOU = 0xC0,
        ISIPIN = 0xC8,
        ISIPOU = 0xD0,
        ISTCPIN = 0xD8,
        ISTCPOU = 0xE0,
        ISUDPIN = 0xE8,
        ISUDPOU = 0xF0,
        ISMISIPB = 0xF8,
        ISNONIPB = 0x100,
        ISARPINB = 0x108,
        ISARPOUB = 0x110,
        ISICMINB = 0x118,
        ISICMOUB = 0x120,
        ISIPINB = 0x128,
        ISIPOUB = 0x130,
        ISTCPINB = 0x138,
        ISTCPOUB = 0x140,
        ISUDPINB = 0x148,
        ISUDPOUB = 0x150,
        ISREFIN = 0x1B0,
        ISREFINB = 0x1B8,
    }
    public enum offRSBLOK : int
    {
        /*Additional Connection info*/
        RSOCLOCK = 0,
        RSOCCIDN = 0x8,
        RSODESC = 0x10,
        RSOQUEUE = 0x14,
        RSOIPAD = 0x18,
        RSOLIPAD = 0x1C,
        RSOPORT = 0x20,
        RSOLPORT = 0x22,
        RSOBASE = 0x24,
        RSOTRNID = 0x28,
        RSOTASKN = 0x2C,
        RSOSOCKN = 0x30,
        RSOSOCK = 0x34,
        RSOFLAG = 0x38,
        RSOOPT = 0x39,
        RSOFLAG2 = 0x3A,
        RSOTYPE = 0x3B,
    }

    public enum offSTRT : int
    {
        STRTCTOD = 0x12,
        STRTCPUI = 0x1A,
        STRTPROG = 0x22,
        STRTVERS = 0x2A,
    }
    public enum offT002 : int
    {
        FTNODE = 0x12,
        FTACUSER = 0x22,
        FTBXSNTA = 0x32,
        FTBXRCVC = 0x3A,
        FTBXSTIM = 0x42,
        FTBXTREP = 0x4A,
        FTBXFIRC = 0x52,
        FTBXFISC = 0x56,
        FTLIPADR = 0x5A,
        FTACIPAD = 0x5E,
        FTPORT = 0x62,
        FTACPORT = 0x64,
        FTBXTID = 0x66,
        FTSSLFLG = 0x68,
        FTFLAG02 = 0x69,
        FTBXFDIP = 0x6A,

    }
    public enum offT003 : int
    {
        T003MSGT = 0x12,
    }
    public enum offT004 : int
    {
        /*Connection info*/
        CCSTATE = 0,
        CCPROTO = 1,
        CCIDENT = 2,
        CCLOPORT = 10,
        CCFOPORT = 12,
        CCFOIP = 14,
        CCFLAGAA = 18,
        CCLOCAL = 19,
        CCRETCNT = 20,
        CCIBCNTI = 28,
        CCIBDUPI = 36,
        CCBTCNTI = 44,
        CCBTDUPI = 52,
        CCIBCNTO = 60,
        CCIBDUPO = 68,
        CCBTCNTO = 76,
        CCBTDUPO = 84,
        CCSWSCNT = 92,
        CCRETMOD = 100,
        CCRWCCNT = 108,
        CCDEPMAX = 116,
        CCSOSCNT = 124,
        CCSORCNT = 132,
        CCMAXWND = 140,
        CCRWINSZ = 144,
        CCIDEND = 148,
        PID = 156,
        PIK = 158,

    }

}
