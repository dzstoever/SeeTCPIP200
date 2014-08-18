using SoftwareFX.ChartFX;
using System;
using System.Windows.Forms;
using System.Collections;

namespace csi.see.client1
{
	/// <summary>
	/// Summary description for SeeChartParams.
	/// </summary>
	public class SeeChartParams
	{
		public ChartTypes Type;
		public ArrayList SeriesList = new ArrayList();
		public ChartScales Yscale1 = ChartScales.None;
		public ChartScales Yscale2 = ChartScales.None;
		public ChartScales Yscale3 = ChartScales.None;
		public ChartScales Yscale4 = ChartScales.None;
		public int SeriesCount
		{
			get{return SeriesList.Count;}
		}
				
		public SeeChartParams()
		{}
	
		
		public static SeeSeriesOptions GetSeriesOptions(ChartSeries cSeries)
		{
			SeeSeriesOptions sOptions = null;
			switch(cSeries)
			{
				#region VSE
				case ChartSeries.Program_Checks:
					sOptions = new SeeSeriesOptions("VSE_Stats", cSeries.ToString(), "Program Checks", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Phase_Loads:
					sOptions = new SeeSeriesOptions("VSE_Stats", cSeries.ToString(), "Phase Loads", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Subchannel_Starts:
					sOptions = new SeeSeriesOptions("VSE_Stats", cSeries.ToString(), "Subchannel Starts", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Supervisor_Interrupts:
					sOptions = new SeeSeriesOptions("VSE_Stats", cSeries.ToString(), "SVC Interrupts", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.IO_Interrupts:
					sOptions = new SeeSeriesOptions("VSE_Stats", cSeries.ToString(), "IO Interrupts", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.External_Interrupts:
					sOptions = new SeeSeriesOptions("VSE_Stats", cSeries.ToString(), "EXT Interrupts", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Nof_Active_Tasks:
					sOptions = new SeeSeriesOptions("VSE_Summary", cSeries.ToString(), "VSE Tasks", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Nof_Allocated_Partitions:
					sOptions = new SeeSeriesOptions("VSE_Summary", cSeries.ToString(), "Allocated Partitions", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				#endregion
				#region CPU
				case ChartSeries.Dispatch_Cycles:
					sOptions = new SeeSeriesOptions("CPU_Stats", cSeries.ToString(), "Dispatch Cycles", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.NonVSE_sec:
					sOptions = new SeeSeriesOptions("CPU_Stats", cSeries.ToString(), "Non-VSE", Gallery.Bar, ChartScales.Percent, true, 1);
					break;
				case ChartSeries.Spin_sec:
					sOptions = new SeeSeriesOptions("CPU_Stats", cSeries.ToString(), "Spinning", Gallery.Bar, ChartScales.Percent, true, 1);
					break;
				case ChartSeries.Waiting_sec:
					sOptions = new SeeSeriesOptions("CPU_Stats", cSeries.ToString(), "Waiting", Gallery.Bar, ChartScales.Percent, true, 1);
					break;
				case ChartSeries.Busy_P_sec:
					sOptions = new SeeSeriesOptions("CPU_Stats", cSeries.ToString(), "Busy-Para", Gallery.Bar, ChartScales.Percent, true, 1);
					break;
				case ChartSeries.Busy_NonP_sec:
					sOptions = new SeeSeriesOptions("CPU_Stats", cSeries.ToString(), "Busy-NonP", Gallery.Bar, ChartScales.Percent, true, 1);
					break;
				#endregion
				#region TCP/IP
				case ChartSeries.FTP_Clients:
					sOptions = new SeeSeriesOptions("TCPIP_Clients", cSeries.ToString(), "Int-FTP Clients", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Telnet_Clients:
					sOptions = new SeeSeriesOptions("TCPIP_Clients", cSeries.ToString(), "Telnet Clients", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.LPR_Clients:
					sOptions = new SeeSeriesOptions("TCPIP_Clients", cSeries.ToString(), "LPR Clients", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.HTTP_Clients:
					sOptions = new SeeSeriesOptions("TCPIP_Clients", cSeries.ToString(), "HTTP Clients", Gallery.Lines, ChartScales.Count, false, 1);
					break;

				case ChartSeries.FTP_Daemons:
					sOptions = new SeeSeriesOptions("TCPIP_Daemons", cSeries.ToString(), "FTP Daemons", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Active_FTP_Daemons:
					sOptions = new SeeSeriesOptions("TCPIP_Daemons", cSeries.ToString(), "Active FTP Daemons", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Max_FTP_Daemons:
					sOptions = new SeeSeriesOptions("TCPIP_Daemons", cSeries.ToString(), "Max FTP Daemons", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Telnet_Daemons:
					sOptions = new SeeSeriesOptions("TCPIP_Daemons", cSeries.ToString(), "Telnet Daemons", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Active_Telnet_Daemons:
					sOptions = new SeeSeriesOptions("TCPIP_Daemons", cSeries.ToString(), "Active Telnet Daemons", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Max_Telnet_Daemons:
					sOptions = new SeeSeriesOptions("TCPIP_Daemons", cSeries.ToString(), "Max Telnet Daemons", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Active_Telnet_Buffers:
					sOptions = new SeeSeriesOptions("TCPIP_Daemons", cSeries.ToString(), "Active Telnet Buffers", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Max_Telnet_Buffers:
					sOptions = new SeeSeriesOptions("TCPIP_Daemons", cSeries.ToString(), "Max Telnet Buffers", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.LP_Daemons:
					sOptions = new SeeSeriesOptions("TCPIP_Daemons", cSeries.ToString(), "LP Daemons", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.HTTP_Daemons:
					sOptions = new SeeSeriesOptions("TCPIP_Daemons", cSeries.ToString(), "HTTP Daemons", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.SMTP_Daemons:
					sOptions = new SeeSeriesOptions("TCPIP_Daemons", cSeries.ToString(), "SMTP Daemons", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.POP3_Daemons:
					sOptions = new SeeSeriesOptions("TCPIP_Daemons", cSeries.ToString(), "POP3 Daemons", Gallery.Lines, ChartScales.Count, false, 1);
					break;

				case ChartSeries.Total_Dispatches:
					sOptions = new SeeSeriesOptions("TCPIP_Dispatcher", cSeries.ToString(), "Total Dispatches", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Active_Dispatches:
					sOptions = new SeeSeriesOptions("TCPIP_Dispatcher", cSeries.ToString(), "Active Dispatches", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Fixed_Dispatches:
					sOptions = new SeeSeriesOptions("TCPIP_Dispatcher", cSeries.ToString(), "Fixed Dispatches", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Quick_Dispatches:
					sOptions = new SeeSeriesOptions("TCPIP_Dispatcher", cSeries.ToString(), "Quick Dispatches", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Persistent_Dispatches:
					sOptions = new SeeSeriesOptions("TCPIP_Dispatcher", cSeries.ToString(), "Persistant Dispatches", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Complete_Dispatches:
					sOptions = new SeeSeriesOptions("TCPIP_Dispatcher", cSeries.ToString(), "Complete Dispatches", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Passed_Dispatches:
					sOptions = new SeeSeriesOptions("TCPIP_Dispatcher", cSeries.ToString(), "Passed Dispatches", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Total_Dispatcher_Time:
					sOptions = new SeeSeriesOptions("TCPIP_Dispatcher", cSeries.ToString(), "Dispatch Time(sec)", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Dispatcher_Waits:
					sOptions = new SeeSeriesOptions("TCPIP_Dispatcher", cSeries.ToString(), "Dispatcher Waits", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Storage_Releases:
					sOptions = new SeeSeriesOptions("TCPIP_Dispatcher", cSeries.ToString(), "Storage Releases", Gallery.Lines, ChartScales.Count, false, 1);
					break;

				case ChartSeries.TCP_Checksum_Errors:
					sOptions = new SeeSeriesOptions("TCPIP_Errors", cSeries.ToString(), "TCP Checksum Errors", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.IP_Checksum_Errors:
					sOptions = new SeeSeriesOptions("TCPIP_Errors", cSeries.ToString(), "IP Checksum Errors", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.UDP_Checksum_Errors:
					sOptions = new SeeSeriesOptions("TCPIP_Errors", cSeries.ToString(), "UDP Checksum Errors", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.ICMP_Checksum_Errors:
					sOptions = new SeeSeriesOptions("TCPIP_Errors", cSeries.ToString(), "ICMP Checksum Errors", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Datagram_Length_Errors:
					sOptions = new SeeSeriesOptions("TCPIP_Errors", cSeries.ToString(), "Datagram Length Errors", Gallery.Lines, ChartScales.Count, false, 1);
					break;

				case ChartSeries.Non_IP:
					sOptions = new SeeSeriesOptions("TCPIP_Other", cSeries.ToString(), "Non-IP", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.Miss_Routed_IP:
					sOptions = new SeeSeriesOptions("TCPIP_Other", cSeries.ToString(), "Miss-routed IP", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.Discarded_UDP:
					sOptions = new SeeSeriesOptions("TCPIP_Other", cSeries.ToString(), "Discarded UDP", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.Unsupported_ICMP:
					sOptions = new SeeSeriesOptions("TCPIP_Other", cSeries.ToString(), "Unsupported ICMP", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.Unsupported_IGMP:
					sOptions = new SeeSeriesOptions("TCPIP_Other", cSeries.ToString(), "Unsupported IGMP", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.Unsupported_Protocol:
					sOptions = new SeeSeriesOptions("TCPIP_Other", cSeries.ToString(), "Unsupported Protocol", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.Connect_Rejections:
					sOptions = new SeeSeriesOptions("TCPIP_Other", cSeries.ToString(), "Connect Rejections", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Inbound_TCP_Rejections:
					sOptions = new SeeSeriesOptions("TCPIP_Other", cSeries.ToString(), "TCP Rejections", Gallery.Lines, ChartScales.Count, false, 1);
					break;

				case ChartSeries.Nof_TCPIP_Connections:
					sOptions = new SeeSeriesOptions("TCPIP_Summary", cSeries.ToString(), "Active Connections", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Nof_TCPIP_PseudoTasks:
					sOptions = new SeeSeriesOptions("TCPIP_Summary", cSeries.ToString(), "Pseudo Tasks", Gallery.Lines, ChartScales.Count, false, 1);
					break;

				case ChartSeries.Int_FTP_Files_Sent:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "Int-FTP Files Sent", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Int_FTP_Files_Received:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "Int-FTP Files Rcvd", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Int_FTP_Bytes_Sent:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "Int-FTP Sent", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.Int_FTP_Bytes_Received:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "Int-FTP Rcvd", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.Telnet_Bytes_Sent:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "Telnet Sent", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.Telnet_Bytes_Received:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "Telnet Rcvd", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.TCP_Bytes_Sent:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "TCP Sent", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.TCP_Bytes_Received:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "TCP Rcvd", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.UDP_Bytes_Sent:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "UDP Sent", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.UDP_Bytes_Received:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "UDP Rcvd", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.IP_Bytes_Sent:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "IP Sent", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.IP_Bytes_Received:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "IP Rcvd", Gallery.Lines, ChartScales.Bytes, false, 1);
					break;
				case ChartSeries.Arps_In:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "Arps In", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Arp_Requests_Inbound:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "Arp Requests In", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Arp_Requests_Outbound:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "Arp Requests Out", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.Arp_Replies_Outbound:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "Arp Replies Out", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.IPNL3172_Blocks_Received:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "IPNL3172 Blocks Rcvd", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.IPNL3172_Blocks_Transmitted:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "IPNL3172 Blocks Trans", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.IPNL3172_Datagrams_Inbound:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "IPNL3172 Datagrams In", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				case ChartSeries.IPNL3172_Datagrams_Outbound:
					sOptions = new SeeSeriesOptions("TCPIP_Traffic", cSeries.ToString(), "IPNL3172 Datagrams Out", Gallery.Lines, ChartScales.Count, false, 1);
					break;
				#endregion
				#region Partitions 
				case ChartSeries.CPU_Time_sec:
					sOptions = new SeeSeriesOptions("Partition_Job_Step", cSeries.ToString(), "CPU Time", Gallery.Bar, ChartScales.Percent, true, 1);
					break;
				case ChartSeries.SIO_Count:
					sOptions = new SeeSeriesOptions("Partition_Job_Step", cSeries.ToString(), "SIO", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				#endregion
				#region Connections
				case ChartSeries.Inbound_Data:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "Dgrams Received", 
						Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Inbound_Bytes:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "Received", 
						Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.Inbound_Data_Dup:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "Dgram Duplicates", 
						Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Inbound_Bytes_Dup:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "Duplicates", 
						Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.Inbound_Eff:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "Inbound Efficiency", 
						Gallery.Lines, ChartScales.Percent, false, 1);
					break;
				
				case ChartSeries.Outbound_Data:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "Dgrams Sent", 
						Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Outbound_Bytes:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "Sent", 
						Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.Outbound_Data_Retr:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "Dgram Retransmits", 
						Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Outbound_Bytes_Retr:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "Retransmits", 
						Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.Outbound_Eff:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "Outbound Efficiency", 
						Gallery.Lines, ChartScales.Percent, false, 1);
					break;
				
				case ChartSeries.SWS_Count:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "SWS", 
						Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Recvs_Issued:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "RECVs Issued", 
						Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Sends_Issued:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "SENDs Issued", 
						Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Retransmits:
					sOptions = new SeeSeriesOptions("Connection_Stats", cSeries.ToString(), "Retransmits Issued", 
						Gallery.Bar, ChartScales.Count, true, 1);
					break;
				#endregion
				#region Foreign IPs
				case ChartSeries.TCP_Inbound_Bytes:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "TCP Received", Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.IP_Inbound_Bytes:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "IP Received", Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.UDP_Inbound_Bytes:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "UDP Received", Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.ICMP_Inbound_Bytes:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "ICMP Received", Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.ARP_Inbound_Bytes:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "ARP Received", Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.Misdirected_IP_Bytes:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "Misdirected IP", Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.NonIP_Bytes:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "Non-IP Received", Gallery.Bar, ChartScales.Bytes, true, 1);
					break;

				case ChartSeries.TCP_Outbound_Bytes:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "TCP Sent", Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.IP_Outbound_Bytes:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "IP Sent", Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.UDP_Outbound_Bytes:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "UDP Sent", Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.ICMP_Outbound_Bytes:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "ICMP Sent", Gallery.Bar, ChartScales.Bytes, true, 1);
					break;
				case ChartSeries.ARP_Outbound_Bytes:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "ARP Sent", Gallery.Bar, ChartScales.Bytes, true, 1);
					break;

				case ChartSeries.TCP_Inbound_Datagrams:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "TCP Received", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.IP_Inbound_Datagrams:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "IP Received", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.UDP_Inbound_Datagrams:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "UDP Received", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.ICMP_Inbound_Datagrams:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "ICMP Received", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.ARP_Inbound_Datagrams:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "ARP Received", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.Misdirected_IP_Datagrams:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "Misdirected IP", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.NonIP_Datagrams:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "Non-IP Received", Gallery.Bar, ChartScales.Count, true, 1);
					break;

				case ChartSeries.TCP_Outbound_Datagrams:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "TCP Sent", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.IP_Outbound_Datagrams:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "IP Sent", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.UDP_Outbound_Datagrams:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "UDP Sent", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.ICMP_Outbound_Datagrams:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "ICMP Sent", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				case ChartSeries.ARP_Outbound_Datagrams:
					sOptions = new SeeSeriesOptions("ForeignIP_Stats", cSeries.ToString(), "ARP Sent", Gallery.Bar, ChartScales.Count, true, 1);
					break;
				#endregion
				default:
					System.Diagnostics.Debug.WriteLine("Invalid ChartSeries in SeeChartParams.GetSeriesOptions()...");
					break;
			}
			return sOptions;
		}
		
		
		public static void AssignDefaultYaxisScales(out ChartScales y1, out ChartScales y2, out ChartScales y3,
			bool IncBytes, bool IncCount, bool IncPercent)
		{
			y1 = ChartScales.None;//Make sure initial values are None
			y2 = ChartScales.None;
			y3 = ChartScales.None;
			#region Assign Default Yaxis Scales
			if(IncBytes && !IncCount && !IncPercent)//Bytes Only
			{y1 = ChartScales.Bytes;}
			else if(IncCount && !IncBytes && !IncPercent)//Counts Only
			{y1 = ChartScales.Count;}
			else if(IncPercent && !IncBytes && !IncCount )//Percentage Only
			{y1 = ChartScales.Percent;}
			else if(IncBytes && IncCount && !IncPercent)//Bytes and Counts
			{
				y1 = ChartScales.Count;
				y2 = ChartScales.Bytes;
			}
			else if(IncBytes && IncPercent && !IncCount )//Bytes and Percentage
			{
				y1 = ChartScales.Percent;
				y2 = ChartScales.Bytes;
			}
			else if(IncCount && IncPercent && !IncBytes)//Counts and Percentage
			{
				y1 = ChartScales.Percent;
				y2 = ChartScales.Count;
			}
			else if(IncBytes && IncCount && IncPercent)//Bytes, Counts and Percentage
			{
				y1 = ChartScales.Percent;
				y2 = ChartScales.Count;
				y3 = ChartScales.Bytes;
			}
			#endregion
		}
				
		public void AddSeries(SeeSeriesOptions series)
		{
			series.SeriesIndex = SeriesList.Count;//Must do this before adding the series to the collection	
			SeriesList.Add(series);
		}

		public void AddSeries(string tableName, string columnName, string seriesName, 
			Gallery galleryType, ChartScales chartScale, bool stacked, int yaxisNum)
		{
			SeeSeriesOptions sOptions = new SeeSeriesOptions();
			sOptions.TableName = tableName;
			sOptions.ColumnName = columnName;
			sOptions.GalleryType = galleryType;
			sOptions.Stacked = stacked;
			sOptions.ChartScale = chartScale;//Bytes, Counts, Percentage
			sOptions.YaxisLabel = chartScale.ToString();
			sOptions.YaxisNumber = yaxisNum;
			sOptions.SeriesName = seriesName;//Must do this last
			sOptions.SeriesIndex = SeriesList.Count;//Must do this before adding the series to the collection
			SeriesList.Add(sOptions);
		}

		
		public void ClearSeriesAndYscales()
		{
			SeriesList.Clear();
			Yscale1 = ChartScales.None;
			Yscale2 = ChartScales.None;
			Yscale3 = ChartScales.None;
			Yscale4 = ChartScales.None;
		}
		
		
		public void ApplySeriesOptions(Chart chart)
		{
			foreach(SeeSeriesOptions sOptions in SeriesList)
			{
				Axis yaxis = chart.Axis[sOptions.YaxisIndex];		
				yaxis.Title.Text = sOptions.YaxisLabel;			//Label the y-axis
				chart.Series[sOptions.SeriesIndex].YAxis 
					= (YAxis)sOptions.YaxisIndex;				//Assign the series to the proper y-axis
				if(sOptions.ChartScale == ChartScales.Percent)	//Change the labels to percentages, if necessary
				{
					yaxis.LabelsFormat.Format = AxisFormat.Percentage;
					yaxis.DataFormat.Format = AxisFormat.Percentage;
					yaxis.DataFormat.Decimals = 5;
				}
				chart.Series[sOptions.SeriesIndex].Legend
					= sOptions.SeriesName;						
				chart.Series[sOptions.SeriesIndex].Gallery
					= sOptions.GalleryType;
				chart.Series[sOptions.SeriesIndex].Stacked
					= sOptions.Stacked;
				
			}

			
		}

		
	}

    public class SeeSeriesOptions : System.Windows.Forms.ListViewItem
    {

        private int yaxisNum;
        private string seriesName;
        public int SeriesIndex;
        public string TableName;
        public string ColumnName;
        public string YaxisLabel;
        public int YaxisIndex;//Use this to read the Yaxis Index
        public Gallery GalleryType;
        public ChartScales ChartScale;
        public bool Stacked;

        public string SeriesName
        {
            get { return seriesName; }
            set
            {
                seriesName = value;
                Text = value + " (" + YaxisLabel + ")";
            }
        }

        public int YaxisNumber//Use to set the Yaxis Number
        {
            get { return yaxisNum; }
            set
            {
                yaxisNum = value;
                switch (value)
                {
                    case 0://invalid
                        break;
                    case 1://Primary Yaxis
                        YaxisIndex = 0;
                        break;
                    case 2://Secondary Yaxis
                        YaxisIndex = 1;
                        break;
                    default://All other Yaxis
                        YaxisIndex = value;
                        break;
                }
            }
        }

        public SeeSeriesOptions()
        { }
        public SeeSeriesOptions(string tableName, string columnName, string seriesName,
            Gallery galleryType, ChartScales chartScale, bool stacked, int yaxisNum)
        {
            TableName = tableName;
            ColumnName = columnName;
            GalleryType = galleryType;
            Stacked = stacked;
            ChartScale = chartScale;//Bytes, Counts, Percentage
            YaxisLabel = chartScale.ToString();
            YaxisNumber = yaxisNum;
            SeriesName = seriesName;//Must do this last
        }


        /// <summary>
        /// Copies all members except this.SeriesIndex
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            //base.Clone ();
            return new SeeSeriesOptions(this.TableName, this.ColumnName, this.SeriesName,
                this.GalleryType, this.ChartScale, this.Stacked, this.yaxisNum);
        }


    }

    public enum ChartScales
    {
        None,
        Bytes,
        Count,
        Percent
    }

    public enum ChartTypes
    {
        Normal,
        Cpu_Activity,
        Cpu_Dispatcher,
        Part_Cpu,
        Part_Sio,
        Conn,
        ForIp
    }

    public enum ChartSeries
    {
        #region VSE
        Program_Checks,
        Phase_Loads,
        Subchannel_Starts,
        Supervisor_Interrupts,
        IO_Interrupts,
        External_Interrupts,
        Nof_Active_Tasks,
        Nof_Allocated_Partitions,
        #endregion
        #region CPU
        Dispatch_Cycles,
        NonVSE_sec,
        Spin_sec,
        Waiting_sec,
        Busy_P_sec,
        Busy_NonP_sec,
        #endregion
        #region TCP/IP
        FTP_Clients,
        Telnet_Clients,
        LPR_Clients,
        HTTP_Clients,

        FTP_Daemons,
        Active_FTP_Daemons,
        Max_FTP_Daemons,
        Telnet_Daemons,
        Active_Telnet_Daemons,
        Max_Telnet_Daemons,
        Active_Telnet_Buffers,
        Max_Telnet_Buffers,
        LP_Daemons,
        HTTP_Daemons,
        SMTP_Daemons,
        POP3_Daemons,

        Total_Dispatches,
        Active_Dispatches,
        Fixed_Dispatches,
        Quick_Dispatches,
        Persistent_Dispatches,
        Complete_Dispatches,
        Passed_Dispatches,
        Total_Dispatcher_Time,
        Dispatcher_Waits,
        Storage_Releases,

        TCP_Checksum_Errors,
        IP_Checksum_Errors,
        UDP_Checksum_Errors,
        ICMP_Checksum_Errors,
        Datagram_Length_Errors,

        Non_IP,
        Miss_Routed_IP,
        Discarded_UDP,
        Unsupported_ICMP,
        Unsupported_IGMP,
        Unsupported_Protocol,
        Connect_Rejections,
        Inbound_TCP_Rejections,

        Nof_TCPIP_Connections,
        Nof_TCPIP_PseudoTasks,

        Int_FTP_Files_Sent,
        Int_FTP_Files_Received,
        Int_FTP_Bytes_Sent,
        Int_FTP_Bytes_Received,
        Telnet_Bytes_Sent,
        Telnet_Bytes_Received,
        TCP_Bytes_Sent,
        TCP_Bytes_Received,
        UDP_Bytes_Sent,
        UDP_Bytes_Received,
        IP_Bytes_Sent,
        IP_Bytes_Received,
        Arps_In,
        Arp_Requests_Inbound,
        Arp_Requests_Outbound,
        Arp_Replies_Outbound,
        IPNL3172_Blocks_Received,
        IPNL3172_Blocks_Transmitted,
        IPNL3172_Datagrams_Inbound,
        IPNL3172_Datagrams_Outbound,
        #endregion
        #region Partitions
        CPU_Time_sec,
        SIO_Count,
        #endregion
        #region Connections
        //Inbound
        Inbound_Data,
        Inbound_Bytes,
        Inbound_Data_Dup,
        Inbound_Bytes_Dup,
        Inbound_Eff,
        //Outbound
        Outbound_Data,
        Outbound_Bytes,
        Outbound_Data_Retr,
        Outbound_Bytes_Retr,
        Outbound_Eff,
        //Other
        SWS_Count,
        Recvs_Issued,
        Sends_Issued,
        Retransmits,
        #endregion
        #region Foreign IPs
        TCP_Inbound_Bytes,
        IP_Inbound_Bytes,
        UDP_Inbound_Bytes,
        ICMP_Inbound_Bytes,
        ARP_Inbound_Bytes,
        Misdirected_IP_Bytes,
        NonIP_Bytes,

        TCP_Outbound_Bytes,
        IP_Outbound_Bytes,
        UDP_Outbound_Bytes,
        ICMP_Outbound_Bytes,
        ARP_Outbound_Bytes,

        TCP_Inbound_Datagrams,
        IP_Inbound_Datagrams,
        UDP_Inbound_Datagrams,
        ICMP_Inbound_Datagrams,
        ARP_Inbound_Datagrams,
        Misdirected_IP_Datagrams,
        NonIP_Datagrams,

        TCP_Outbound_Datagrams,
        IP_Outbound_Datagrams,
        UDP_Outbound_Datagrams,
        ICMP_Outbound_Datagrams,
        ARP_Outbound_Datagrams,


        #endregion
    }

    public enum VseDbTables
    {
        //PollBloks
        VSE_Summary,
        TCPIP_Summary,
        SeeServer_Summary,
        Link_Adapter,
        VSE_Stats,
        TCPIP_Dispatcher,
        TCPIP_Daemons,
        TCPIP_Clients,
        TCPIP_Traffic,
        TCPIP_Other,
        TCPIP_Errors,
        CPU_Stats,
        Partition_Job_Step,
        Connection_Stats,
        ForeignIP_Stats,
        Connection_BSDC,
        //RecordBloks
        TCPIP_Messages,
        Startup_Records,
        FTP_Records,
        Connection_Records,
        JobStep_Records
    }
}
