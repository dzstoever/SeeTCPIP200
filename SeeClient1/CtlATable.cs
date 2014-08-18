using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class CtlATable : csi.see.client1.CtlAADisplay
    {
        public CtlATable()
        {
            InitializeComponent();
        }

        private DataGridTableStyle CreateTableStyle(string MappingName, string ListName)
        {
            DataGridTableStyle Tstyle = new DataGridTableStyle();
            #region Common
            Tstyle.HeaderForeColor = Color.FromArgb(0, 0, 192);
            Tstyle.AlternatingBackColor = Color.WhiteSmoke;
            Tstyle.PreferredColumnWidth = 100;
            Tstyle.ReadOnly = true;
            Tstyle.MappingName = MappingName;

            if (ListName.StartsWith("ListConn"))
            {//Common Feilds
                Tstyle.GridColumnStyles.Add(AddColumnStyle("Conn_PID", "PID", 50, false));
                Tstyle.GridColumnStyles.Add(AddColumnStyle("Local_Port", "Local Port", 75, false));
                Tstyle.GridColumnStyles.Add(AddColumnStyle("Foreign_Port", "Forgn Port", 75, false));
                Tstyle.GridColumnStyles.Add(AddColumnStyle("Foreign_IP", "Forgn IP", 110, false));
            }
            else if (ListName.StartsWith("ListForIp"))
            {//Common Feild
                Tstyle.GridColumnStyles.Add(AddColumnStyle("IP_Address", "IP Address", 110, false));
            }
            #endregion

            switch (ListName)
            {
                #region Specific
                case "ListCpu":
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("CPU_ID", "CPUID", 50, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("CPU_State", "State", 60, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Dispatch_Cycles", "Dispatch Cycles", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Busy_NonP_sec", "Busy-NonP (sec)", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Busy_P_sec", "Busy-P (sec)", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Waiting_sec", "Waiting (sec)", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Spin_sec", "Spinning (sec)", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("NonVSE_sec", "Non-VSE (sec)", 0, false));
                    break;
                case "ListPartition":
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Partition_ID", "PID", 50, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Power_Job_Name", "Power Name", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("VSE_Job_Name", "Job Name", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("VSE_Step_Name", "Step Name", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Job_Start_Time", "Job Start Time", 125, true));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Step_Start_Time", "Step Start Time", 125, true));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("CPU_Time_sec", "CPU Time (sec)", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("SIO_Count", "SIO Count", 75, false));
                    break;
                case "ListForIpBytesIn":
                    //Tstyle.GridColumnStyles.Add(AddColumnStyle("Total_Inbound_Bytes",	"Total=IP???",			0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("IP_Inbound_Bytes", "IP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("TCP_Inbound_Bytes", "TCP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("UDP_Inbound_Bytes", "UDP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("ICMP_Inbound_Bytes", "ICMP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("ARP_Inbound_Bytes", "ARP", 75, false));

                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Misdirected_IP_Bytes", "Misdirected IP", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("NonIP_Bytes", "Non-IP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Refused_Bytes", "Refused", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Refuse_Flag", "Refuse Flag", 75, false));
                    break;
                case "ListForIpBytesOut":
                    //Tstyle.GridColumnStyles.Add(AddColumnStyle("Total_Outbound_Bytes",	"Total=IP???",			0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("IP_Outbound_Bytes", "IP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("TCP_Outbound_Bytes", "TCP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("UDP_Outbound_Bytes", "UDP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("ICMP_Outbound_Bytes", "ICMP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("ARP_Outbound_Bytes", "ARP", 75, false));
                    break;
                case "ListForIpDataIn":
                    //Tstyle.GridColumnStyles.Add(AddColumnStyle("Total_Inbound_Datagrams",	"Total=IP???",			0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("IP_Inbound_Datagrams", "IP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("TCP_Inbound_Datagrams", "TCP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("UDP_Inbound_Datagrams", "UDP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("ICMP_Inbound_Datagrams", "ICMP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("ARP_Inbound_Datagrams", "ARP", 75, false));

                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Misdirected_IP_Datagrams", "Misdirected IP", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("NonIP_Datagrams", "Non-IP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Refused_Datagrams", "Refused", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Refuse_Flag", "Refuse Flag", 75, false));
                    break;
                case "ListForIpDataOut":
                    //Tstyle.GridColumnStyles.Add(AddColumnStyle("Total_Outbound_Datagrams",	"Total=IP???",			0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("IP_Outbound_Datagrams", "IP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("TCP_Outbound_Datagrams", "TCP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("UDP_Outbound_Datagrams", "UDP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("ICMP_Outbound_Datagrams", "ICMP", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("ARP_Outbound_Datagrams", "ARP", 75, false));
                    break;
                case "ListConnState":
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Conn_Start_Time", "Start Time", 125, true));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("INT_EXT", "INT/EXT", 60, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Conn_State", "State", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Conn_Protocol", "Protocol", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Highest_Depth", "Highest Depth", 0, false));
                    break;
                case "ListConnWindow":
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Max_Send_Window", "Max SEND Size", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Max_Recv_Window", "Max RECV Size", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Recv_Window_Closed", "RECV Closed", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("SWS_Count", "SWS Count", 0, false));
                    break;
                case "ListConnSocket":
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Recvs_Issued", "RECVs Issued", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Sends_Issued", "SENDs Issued", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Retransmits", "Retransmits", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("In_Retr_Mode", "Times in Retrans", 105, false));
                    break;
                case "ListConnInbound":
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Inbound_Data", "Datagrams", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Inbound_Bytes", "Bytes", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Inbound_Data_Dup", "Dgrams(Dup)", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Inbound_Bytes_Dup", "Bytes(Dup)", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Inbound_Eff", "Efficiency", 75, false));
                    break;
                case "ListConnOutbound":
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Outbound_Data", "Datagrams", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Outbound_Bytes", "Bytes", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Outbound_Data_Retr", "Dgrams(Retr)", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Outbound_Bytes_Retr", "Bytes(Retr)", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Outbound_Eff", "Efficiency", 75, false));
                    break;
                case "ListLink":
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Type", "Link/Adapter", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Link_ID", "ID", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Define_Type", "Type", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("MTU", "MTU", 50, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("IP_Address", "IP Address", 110, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("CUU_Name", "CUU Name", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Alternate_CUU", "Alternate CUU", 0, false));
                    break;
                #endregion
                case "bsdcConnections":
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Conn_State", "State", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Conn_Start_Time", "Start Time", 125, true));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Foreign_Port", "Forgn Port", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Foreign_IP", "Forgn IP", 110, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Recvs_Issued", "RECVs Issued", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Sends_Issued", "SENDs Issued", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Retransmits", "Retransmits", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Inbound_Bytes", "Inbound Bytes", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Outbound_Bytes", "Outbound Bytes", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Recv_Window_Closed", "RECV Closed", 0, false));
                    break;
                case "bsdcDescription":
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Description", "Description", 600, false));
                    break;
                case "ListBSDC":
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Sock_Number", "Sock #", 60, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("bsdcType", "Type", 50, false));
                    //AddColumnStyle("CCBLOK_ID", "Connection ID", 200, false);
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Conn_Start", "TOD (Start Time)", 125, true));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Store_Clock", "TOD (Last Activity)", 125, true));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Local_IP", "Local IP", 110, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Local_Port", "Local Port", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Foreign_Port", "Forgn Port", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Foreign_IP", "Forgn IP", 110, false));
                    DataGridTextBoxColumn cs1 = AddColumnStyle("Flag_1", "Flag 1", 50, false);
                    DataGridTextBoxColumn cs2 = AddColumnStyle("Flag_2", "Flag 2", 50, false);
                    DataGridTextBoxColumn cs3 = AddColumnStyle("Sock_Options", "Option", 50, false);
                    cs1.Format = "X2";//display hex
                    cs2.Format = "X2";
                    cs3.Format = "X2";
                    Tstyle.GridColumnStyles.Add(cs1);
                    Tstyle.GridColumnStyles.Add(cs2);
                    Tstyle.GridColumnStyles.Add(cs3);
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("CICS_Task", "CICS Task", 75, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("CICS_Trans_ID", "CICS ID", 60, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Sock_Addr", "Sock Address", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Base_Sock_Addr", "Base Address", 0, false));
                    Tstyle.GridColumnStyles.Add(AddColumnStyle("Sock_Descriptor", "Sock Descriptor", 0, false));


                    break;
                default:
                    //Debug.WriteLine("Invalid ListName in Control1Overview.CreateTableStyle...");
                    break;
            }
            return Tstyle;
        }
        private DataGridTextBoxColumn AddColumnStyle(string colName, string header, int width, bool isDateTime)
        {
            DataGridTextBoxColumn colStyle = new DataGridTextBoxColumn();
            colStyle.MappingName = colName;
            colStyle.HeaderText = header;
            if (width > 0)//Otherwise use the TableStyle.PreferredWidth
            { colStyle.Width = width; }

            if (isDateTime)
            { colStyle.Format = "MM/dd/yy HH:mm:ss"; }
            else if (header == "Efficiency")
            { colStyle.Format = "P2"; }//2 decimal places - percent
            else if (header.EndsWith("(sec)"))
            { colStyle.Format = "F3"; }//3 decimal places

            return colStyle;
        }
    }
}

