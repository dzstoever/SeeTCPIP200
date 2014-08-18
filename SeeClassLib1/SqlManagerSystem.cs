using csi.see.classlib1;
using csi.see.classlib1.DataSets;
using csi.see.classlib1.DataSets.VseDbDataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace csi.see.classlib1
{
    public class SqlManagerSystem : SqlBase
    {
        #region SqlAdapters
        Connection_BSDCTableAdapter     adapt0 = new Connection_BSDCTableAdapter();        
        Connection_StatsTableAdapter    adapt1 = new Connection_StatsTableAdapter();
        CPU_StatsTableAdapter           adapt2 = new CPU_StatsTableAdapter();        
        ForeignIP_StatsTableAdapter     adapt3 = new ForeignIP_StatsTableAdapter();        
        Link_AdapterTableAdapter        adapt4 = new Link_AdapterTableAdapter();
        Partition_Job_StepTableAdapter  adapt5 = new Partition_Job_StepTableAdapter();
        SeeServer_SummaryTableAdapter   adapt6 = new SeeServer_SummaryTableAdapter();        
        TCPIP_ClientsTableAdapter       adapt7 = new TCPIP_ClientsTableAdapter();
        TCPIP_DaemonsTableAdapter       adapt8 = new TCPIP_DaemonsTableAdapter();
        TCPIP_DispatcherTableAdapter    adapt9 = new TCPIP_DispatcherTableAdapter();
        TCPIP_ErrorsTableAdapter        adapt10 = new TCPIP_ErrorsTableAdapter();
        TCPIP_OtherTableAdapter         adapt11 = new TCPIP_OtherTableAdapter();
        TCPIP_SummaryTableAdapter       adapt12 = new TCPIP_SummaryTableAdapter();
        TCPIP_TrafficTableAdapter       adapt13 = new TCPIP_TrafficTableAdapter();
        VSE_StatsTableAdapter           adapt14 = new VSE_StatsTableAdapter();
        VSE_SummaryTableAdapter         adapt15 = new VSE_SummaryTableAdapter();

        ForeignIP_AllTableAdapter       adapt16 = new ForeignIP_AllTableAdapter();
        TCPIP_MessagesTableAdapter      adapt17 = new TCPIP_MessagesTableAdapter();
        Startup_RecordsTableAdapter     adapt18 = new Startup_RecordsTableAdapter();
        Connection_RecordsTableAdapter  adapt19 = new Connection_RecordsTableAdapter();
        FTP_RecordsTableAdapter         adapt20 = new FTP_RecordsTableAdapter();
        JobStep_RecordsTableAdapter     adapt21 = new JobStep_RecordsTableAdapter();

        Connection_Stats_by_LocalPortTableAdapter adapt22 = new Connection_Stats_by_LocalPortTableAdapter();


        #endregion
        private void SetAdapterConnections(SqlConnection connection)
        {
            adapt0.Connection = connection;
            adapt1.Connection = connection;
            adapt2.Connection = connection;
            adapt3.Connection = connection;
            adapt4.Connection = connection;
            adapt5.Connection = connection;
            adapt6.Connection = connection;
            adapt7.Connection = connection;
            adapt8.Connection = connection;
            adapt9.Connection = connection;
            adapt10.Connection = connection;
            adapt11.Connection = connection;
            adapt12.Connection = connection;
            adapt13.Connection = connection;
            adapt14.Connection = connection;
            adapt15.Connection = connection;
            adapt16.Connection = connection;
            adapt17.Connection = connection;
            adapt18.Connection = connection;
            adapt19.Connection = connection;
            adapt20.Connection = connection;
            adapt21.Connection = connection;

            adapt22.Connection = connection;
        }

        public override void SetDb(string dbName)
        {
            base.SetDb(dbName);
            SetAdapterConnections(base.Connection);
        }
        public override void SetDb(string dbName, string dataPath)
        {
            base.SetDb(dbName, dataPath);
            SetAdapterConnections(base.Connection);
        }
        public override void SetDb(SqlConnection sqlConnection)
        {
            base.SetDb(sqlConnection);
            SetAdapterConnections(base.Connection);
        }
        public override void SetDb(SqlConnection sqlConnection, string dataPath)
        {
            base.SetDb(sqlConnection, dataPath);
            SetAdapterConnections(base.Connection);
        }

        #region Create Table Sql Statements
        //Poll Tables
        private string CREATETABLE_VSE_Summary
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE VSE_Summary(");
                sb.Append("Poll_Time				datetime, ");

                sb.Append("Last_IPL_Time			datetime, ");
                sb.Append("Last_CpuReset_Time		datetime, ");
                sb.Append("Sec_since_IPL			float, ");
                sb.Append("Sec_since_CpuReset		float, ");
                sb.Append("Cpu_ID					char(17), ");
                sb.Append("Release					char(5), ");
                sb.Append("Power_Sys_ID				char(1), ");
                sb.Append("Power_Node				char(8), ");
                sb.Append("European_Dates			bit, ");
                sb.Append("Time_Zone_Offset			float, ");
                sb.Append("Nof_Cpus					float, ");
                sb.Append("Nof_Active_Cpus			float, ");
                sb.Append("Nof_Quiesced_Cpus		float, ");
                sb.Append("MaxNof_Tasks				float, ");
                sb.Append("Nof_Active_Tasks			float, ");
                sb.Append("MaxNof_Partitions		float, ");
                sb.Append("Nof_Allocated_Partitions	float, ");
                sb.Append("Nof_TCPIP_Stacks			float, ");
                sb.Append("CONSTRAINT PK_VSE_Summary PRIMARY KEY (Poll_Time));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_TCPIP_Summary
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE TCPIP_Summary(");
                sb.Append("Poll_Time				datetime, ");

                sb.Append("TCPIP_Start_Time			datetime, ");
                sb.Append("Sys_ID					char(2), ");
                sb.Append("PID						char(2), ");
                sb.Append("Job_Name					char(8), ");
                sb.Append("Release					varchar(8), ");
                sb.Append("License					char(3), ");
                sb.Append("IP_Address				varchar(15), ");
                sb.Append("Console_Port				float, ");
                sb.Append("Nof_TCPIP_Connections	float, ");
                sb.Append("Nof_TCPIP_PseudoTasks	float, ");
                sb.Append("CONSTRAINT PK_TCPIP_Summary PRIMARY KEY (Poll_Time));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_SeeServer_Summary
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE SeeServer_Summary(");
                sb.Append("Poll_Time				datetime, ");

                sb.Append("SeeServer_Start_Time		datetime, ");
                sb.Append("PID						char(2), ");
                sb.Append("Job_Name					char(8), ");
                sb.Append("Release					varchar(8), ");
                sb.Append("CONSTRAINT PK_SeeServer_Summary PRIMARY KEY (Poll_Time));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_Link_Adapter
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE Link_Adapter(");
                sb.Append("Poll_Time				datetime, ");

                sb.Append("Type						varchar(7), ");
                sb.Append("Link_ID					varchar(16), ");
                sb.Append("Define_Type				varchar(5), ");
                sb.Append("MTU						float, ");
                sb.Append("CUU_Name					char(4), ");
                sb.Append("Alternate_CUU			char(4), ");
                sb.Append("IP_Address				varchar(15), ");
                sb.Append("CONSTRAINT PK_Link_Adapter PRIMARY KEY (Poll_Time, Link_ID, Define_Type));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_VSE_Stats
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE VSE_Stats(");
                sb.Append("Poll_Time				datetime, ");

                sb.Append("Program_Checks				float, ");
                sb.Append("Phase_Loads					float, ");
                sb.Append("Subchannel_Starts			float, ");
                sb.Append("Supervisor_Interrupts		float, ");
                sb.Append("IO_Interrupts				float, ");
                sb.Append("External_Interrupts			float, ");
                sb.Append("CONSTRAINT PK_VSE_Stats PRIMARY KEY (Poll_Time));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_TCPIP_Dispatcher
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE TCPIP_Dispatcher(");
                sb.Append("Poll_Time				datetime, ");

                sb.Append("Total_Dispatches			float, ");
                sb.Append("Active_Dispatches		float, ");
                sb.Append("Fixed_Dispatches			float, ");
                sb.Append("Quick_Dispatches			float, ");
                sb.Append("Persistent_Dispatches	float, ");
                sb.Append("Complete_Dispatches		float, ");
                sb.Append("Passed_Dispatches		float, ");
                sb.Append("Total_Dispatcher_Time	float, ");
                sb.Append("Dispatcher_Waits			float, ");
                sb.Append("Storage_Releases			float, ");
                sb.Append("CONSTRAINT PK_TCPIP_Dispatcher PRIMARY KEY (Poll_Time));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_TCPIP_Daemons
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE TCPIP_Daemons(");
                sb.Append("Poll_Time				datetime, ");

                sb.Append("FTP_Daemons				float, ");
                sb.Append("Active_FTP_Daemons		float, ");
                sb.Append("Max_FTP_Daemons			float, ");
                sb.Append("Telnet_Daemons			float, ");
                sb.Append("Active_Telnet_Daemons	float, ");
                sb.Append("Max_Telnet_Daemons		float, ");
                sb.Append("Active_Telnet_Buffers	float, ");
                sb.Append("Max_Telnet_Buffers		float, ");
                sb.Append("LP_Daemons				float, ");
                sb.Append("HTTP_Daemons				float, ");
                sb.Append("SMTP_Daemons				float, ");
                sb.Append("POP3_Daemons				float, ");
                sb.Append("CONSTRAINT PK_TCPIP_Daemons PRIMARY KEY (Poll_Time));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_TCPIP_Clients
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE TCPIP_Clients(");
                sb.Append("Poll_Time				datetime, ");

                sb.Append("FTP_Clients				float, ");
                sb.Append("Telnet_Clients			float, ");
                sb.Append("LPR_Clients				float, ");
                sb.Append("HTTP_Clients				float, ");
                sb.Append("CONSTRAINT PK_TCPIP_Clients PRIMARY KEY (Poll_Time));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_TCPIP_Traffic
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE TCPIP_Traffic(");
                sb.Append("Poll_Time				datetime, ");

                sb.Append("Int_FTP_Files_Sent		float, ");
                sb.Append("Int_FTP_Files_Received	float, ");
                sb.Append("Int_FTP_Bytes_Sent		float, ");
                sb.Append("Int_FTP_Bytes_Received	float, ");
                sb.Append("Telnet_Bytes_Sent		float, ");
                sb.Append("Telnet_Bytes_Received	float, ");
                sb.Append("TCP_Bytes_Sent			float, ");
                sb.Append("TCP_Bytes_Received		float, ");
                sb.Append("UDP_Bytes_Sent			float, ");
                sb.Append("UDP_Bytes_Received		float, ");
                sb.Append("IP_Bytes_Sent			float, ");
                sb.Append("IP_Bytes_Received		float, ");
                sb.Append("Arps_In					float, ");
                sb.Append("Arp_Requests_Inbound		float, ");
                sb.Append("Arp_Requests_Outbound	float, ");
                sb.Append("Arp_Replies_Outbound		float, ");
                sb.Append("IPNL3172_Blocks_Received		float, ");
                sb.Append("IPNL3172_Blocks_Transmitted	float, ");
                sb.Append("IPNL3172_Datagrams_Inbound	float, ");
                sb.Append("IPNL3172_Datagrams_Outbound	float, ");
                sb.Append("CONSTRAINT PK_TCPIP_Traffic PRIMARY KEY (Poll_Time));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_TCPIP_Other
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE TCPIP_Other(");
                sb.Append("Poll_Time				datetime , ");
                sb.Append("Non_IP					float, ");
                sb.Append("Miss_Routed_IP			float, ");
                sb.Append("Discarded_UDP			float, ");
                sb.Append("Unsupported_ICMP			float, ");
                sb.Append("Unsupported_IGMP			float, ");
                sb.Append("Unsupported_Protocol		float, ");
                sb.Append("Connect_Rejections		float, ");
                sb.Append("Inbound_TCP_Rejections	float, ");
                sb.Append("CONSTRAINT PK_TCPIP_Other PRIMARY KEY (Poll_Time));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_TCPIP_Errors
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE TCPIP_Errors(");
                sb.Append("Poll_Time				datetime, ");

                sb.Append("TCP_Checksum_Errors		float, ");
                sb.Append("IP_Checksum_Errors		float, ");
                sb.Append("UDP_Checksum_Errors		float, ");
                sb.Append("ICMP_Checksum_Errors		float, ");
                sb.Append("Datagram_Length_Errors	float, ");
                sb.Append("CONSTRAINT PK_TCPIP_Errors PRIMARY KEY (Poll_Time));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_CPU_Stats
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE CPU_Stats(");
                sb.Append("Poll_Time			datetime , ");

                sb.Append("CPU_ID				float, ");
                sb.Append("CPU_State			varchar(8), ");
                sb.Append("Dispatch_Cycles		float, ");
                sb.Append("NonVSE_sec			float, ");
                sb.Append("Spin_sec				float, ");
                sb.Append("Waiting_sec			float, ");
                sb.Append("Busy_P_sec			float, ");
                sb.Append("Busy_NonP_sec		float, ");
                sb.Append("CONSTRAINT PK_CPU_Stats PRIMARY KEY (Poll_Time, CPU_ID));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_Partition_Job_Step
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE Partition_Job_Step(");
                sb.Append("Poll_Time				datetime, ");

                sb.Append("Partition_ID				char(2), ");
                sb.Append("Power_Job_Name			char(8), ");
                sb.Append("VSE_Job_Name				char(8), ");
                sb.Append("VSE_Step_Name			char(8), ");
                sb.Append("Job_Start_Time			datetime, ");
                sb.Append("Step_Start_Time			datetime, ");
                sb.Append("CPU_Time_sec				float, ");
                sb.Append("SIO_Count				float, ");
                sb.Append("Priority					float, ");
                sb.Append("CONSTRAINT PK_Partition_Job_Step PRIMARY KEY (Poll_Time, Partition_ID, Power_Job_Name, VSE_Job_Name, VSE_Step_Name, Job_Start_Time, Step_Start_Time));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_Connection_Stats
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE Connection_Stats(");
                sb.Append("Poll_Time			datetime, ");
                //ID fields
                sb.Append("Conn_PID				char(2), ");
                sb.Append("Conn_Phase		    varchar(8), ");
                sb.Append("Local_Port			float, ");
                sb.Append("Foreign_Port			float, ");
                sb.Append("Foreign_IP			varchar(15), ");
                //State
                sb.Append("CCIDENT				float, ");
                sb.Append("Conn_Start_Time		datetime, ");
                sb.Append("INT_EXT				char(3), ");
                sb.Append("Conn_State			varchar(12), ");
                sb.Append("Conn_Protocol		varchar(8), ");
                sb.Append("Highest_Depth		float, ");
                //Window
                sb.Append("Max_Send_Window		float, ");
                sb.Append("Max_Recv_Window		float, ");
                sb.Append("Recv_Window_Closed	float, ");
                sb.Append("SWS_Count			float, ");
                //Inbound
                sb.Append("Inbound_Data			float, ");//Datagrams
                sb.Append("Inbound_Bytes		float, ");//Bytes
                sb.Append("Inbound_Data_Dup		float, ");//Dgrams(Dup)
                sb.Append("Inbound_Bytes_Dup	float, ");//Bytes(Dup)
                sb.Append("Inbound_Eff			float, ");//Efficiency

                //Outbound
                sb.Append("Outbound_Data		float, ");//Datagrams
                sb.Append("Outbound_Bytes		float, ");//Bytes
                sb.Append("Outbound_Data_Retr	float, ");//Dgrams(Retr)
                sb.Append("Outbound_Bytes_Retr	float, ");//Bytes(Retr)
                sb.Append("Outbound_Eff			float, ");//Efficiency

                //RECVs/SENDs
                sb.Append("Recvs_Issued			float, ");
                sb.Append("Sends_Issued			float, ");
                sb.Append("Retransmits			float, ");
                sb.Append("In_Retr_Mode			float, ");

                sb.Append("CONSTRAINT PK_Connection_Stats PRIMARY KEY (Poll_Time, Local_Port, Foreign_Port, Foreign_IP, CCIDENT));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_ForeignIP_Stats
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE ForeignIP_Stats(");
                sb.Append("Poll_Time					datetime , ");

                sb.Append("IP_Address					varchar(15), ");
                sb.Append("Refuse_Flag					bit, ");
                sb.Append("Misdirected_IP_Datagrams		float, ");
                sb.Append("NonIP_Datagrams				float, ");
                sb.Append("ARP_Inbound_Datagrams		float, ");
                sb.Append("ARP_Outbound_Datagrams		float, ");
                sb.Append("ICMP_Inbound_Datagrams		float, ");
                sb.Append("ICMP_Outbound_Datagrams		float, ");
                sb.Append("IP_Inbound_Datagrams			float, ");
                sb.Append("IP_Outbound_Datagrams		float, ");
                sb.Append("TCP_Inbound_Datagrams		float, ");
                sb.Append("TCP_Outbound_Datagrams		float, ");
                sb.Append("UDP_Inbound_Datagrams		float, ");
                sb.Append("UDP_Outbound_Datagrams		float, ");
                //sb.Append("Total_Inbound_Datagrams		float, ");
                //sb.Append("Total_Outbound_Datagrams		float, ");
                sb.Append("Misdirected_IP_Bytes			float, ");
                sb.Append("NonIP_Bytes					float, ");
                sb.Append("ARP_Inbound_Bytes			float, ");
                sb.Append("ARP_Outbound_Bytes			float, ");
                sb.Append("ICMP_Inbound_Bytes			float, ");
                sb.Append("ICMP_Outbound_Bytes			float, ");
                sb.Append("IP_Inbound_Bytes				float, ");
                sb.Append("IP_Outbound_Bytes			float, ");
                sb.Append("TCP_Inbound_Bytes			float, ");
                sb.Append("TCP_Outbound_Bytes			float, ");
                sb.Append("UDP_Inbound_Bytes			float, ");
                sb.Append("UDP_Outbound_Bytes			float, ");
                //sb.Append("Total_Inbound_Bytes			float, ");
                //sb.Append("Total_Outbound_Bytes			float, ");
                sb.Append("Refused_Bytes				float, ");
                sb.Append("Refused_Datagrams			float, ");
                sb.Append("CONSTRAINT PK_ForeignIP_Stats PRIMARY KEY (Poll_Time, IP_Address));");

                return sb.ToString();
            }

        }
        private string CREATETABLE_ForeignIP_All
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE ForeignIP_All(");
                sb.Append("Poll_Time					datetime , ");

                sb.Append("IP_Address					varchar(15), ");
                sb.Append("Refuse_Flag					bit, ");
                sb.Append("Misdirected_IP_Datagrams		float, ");
                sb.Append("NonIP_Datagrams				float, ");
                sb.Append("ARP_Inbound_Datagrams		float, ");
                sb.Append("ARP_Outbound_Datagrams		float, ");
                sb.Append("ICMP_Inbound_Datagrams		float, ");
                sb.Append("ICMP_Outbound_Datagrams		float, ");
                sb.Append("IP_Inbound_Datagrams			float, ");
                sb.Append("IP_Outbound_Datagrams		float, ");
                sb.Append("TCP_Inbound_Datagrams		float, ");
                sb.Append("TCP_Outbound_Datagrams		float, ");
                sb.Append("UDP_Inbound_Datagrams		float, ");
                sb.Append("UDP_Outbound_Datagrams		float, ");
                //sb.Append("Total_Inbound_Datagrams		float, ");
                //sb.Append("Total_Outbound_Datagrams		float, ");
                sb.Append("Misdirected_IP_Bytes			float, ");
                sb.Append("NonIP_Bytes					float, ");
                sb.Append("ARP_Inbound_Bytes			float, ");
                sb.Append("ARP_Outbound_Bytes			float, ");
                sb.Append("ICMP_Inbound_Bytes			float, ");
                sb.Append("ICMP_Outbound_Bytes			float, ");
                sb.Append("IP_Inbound_Bytes				float, ");
                sb.Append("IP_Outbound_Bytes			float, ");
                sb.Append("TCP_Inbound_Bytes			float, ");
                sb.Append("TCP_Outbound_Bytes			float, ");
                sb.Append("UDP_Inbound_Bytes			float, ");
                sb.Append("UDP_Outbound_Bytes			float, ");
                //sb.Append("Total_Inbound_Bytes			float, ");
                //sb.Append("Total_Outbound_Bytes			float, ");
                sb.Append("Refused_Bytes				float, ");
                sb.Append("Refused_Datagrams			float, ");
                sb.Append("CONSTRAINT PK_ForeignIP_All PRIMARY KEY (Poll_Time, IP_Address));");

                return sb.ToString();
            }

        }
        private string CREATETABLE_Connection_BSDC
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE Connection_BSDC(");
                sb.Append("Poll_Time			datetime, ");

                sb.Append("Store_Clock		    datetime, ");
                sb.Append("CCBLOK_ID			float, ");
                sb.Append("Sock_Descriptor		char(8), ");
                sb.Append("Queue_Depth			float, ");
                sb.Append("Foreign_IP			varchar(15), ");
                sb.Append("Local_IP			    varchar(15), ");
                sb.Append("Foreign_Port			float, ");
                sb.Append("Local_Port			float, ");

                sb.Append("Base_Sock_Addr	    char(8), ");
                sb.Append("CICS_Trans_ID		char(4), ");
                sb.Append("CICS_Task	        float, ");
                sb.Append("Sock_Number		    float, ");
                sb.Append("Sock_Addr		    char(8), ");
                sb.Append("Flag_1		        tinyint, ");//tinyint = 1 byte
                sb.Append("Sock_Options	        tinyint, ");
                sb.Append("Flag_2			    tinyint, ");
                sb.Append("Type			        tinyint, ");
                sb.Append("PID			        char(2), ");

                sb.Append("CONSTRAINT PK_Connection_BSDC PRIMARY KEY (Poll_Time, Sock_Number, Sock_Addr));");

                return sb.ToString();
            }
        }
        //Console Tables
        private string CREATETABLE_TCPIP_Messages
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE TCPIP_Messages(");
                sb.Append("Message_ID		int identity, ");
                sb.Append("Time_Stamp		datetime, ");
                sb.Append("Message_Text		varchar(255), ");
                sb.Append("CONSTRAINT PK_TCPIP_Messages PRIMARY KEY (Message_ID));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_Startup_Records
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE Startup_Records(");
                sb.Append("Record_ID		int identity, ");
                sb.Append("Start_Time		datetime, ");
                sb.Append("Cpu_ID			char(17), ");
                sb.Append("Program_ID		char(8), ");
                sb.Append("Program_Version	char(8), ");
                sb.Append("CONSTRAINT PK_Startup_Records PRIMARY KEY (Record_ID, Start_Time, Program_ID));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_FTP_Records
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE FTP_Records(");
                sb.Append("Record_ID			int identity, ");
                sb.Append("FTP_Node_Name		varchar(16), ");
                sb.Append("FTP_User_ID			varchar(16), ");
                sb.Append("Bytes_SentAcked		float, ");
                sb.Append("Bytes_Received		float, ");
                sb.Append("Start_Time			datetime, ");
                sb.Append("End_Time				datetime, ");
                sb.Append("Files_Received		float, ");
                sb.Append("Files_Sent			float, ");
                sb.Append("Vse_IP				varchar(15), ");
                sb.Append("Client_IP			varchar(15), ");
                sb.Append("Vse_Port				int, ");
                sb.Append("Client_Port			int, ");
                sb.Append("Vse_Task_ID			int, ");
                sb.Append("SSL_Flag				tinyint, ");
                sb.Append("General_Flag			tinyint, ");
                sb.Append("Foreign_Data_IP		varchar(15), ");
                sb.Append("CONSTRAINT PrimKey PRIMARY KEY (Record_ID));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_Connection_Records
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE Connection_Records(");
                sb.Append("Record_ID			int identity, ");
                //ID fields
                sb.Append("Conn_PID				char(2), ");
                sb.Append("Local_Port			float, ");
                sb.Append("Foreign_Port			float, ");
                sb.Append("Foreign_IP			varchar(15), ");
                //State
                sb.Append("Conn_Start_Time		datetime, ");
                sb.Append("Conn_End_Time		datetime, ");
                sb.Append("INT_EXT				char(3), ");
                sb.Append("Conn_State			varchar(12), ");
                sb.Append("Conn_Protocol		varchar(8), ");
                sb.Append("Highest_Depth		float, ");
                //Window
                sb.Append("Max_Send_Window		float, ");
                sb.Append("Max_Recv_Window		float, ");
                sb.Append("Recv_Window_Closed	float, ");
                sb.Append("SWS_Count			float, ");
                //Inbound
                sb.Append("Inbound_Data			float, ");//Datagrams
                sb.Append("Inbound_Bytes		float, ");//Bytes
                sb.Append("Inbound_Data_Dup		float, ");//Dgrams(Dup)
                sb.Append("Inbound_Bytes_Dup	float, ");//Bytes(Dup)
                sb.Append("Inbound_Eff			float, ");//Efficiency

                //Outbound
                sb.Append("Outbound_Data		float, ");//Datagrams
                sb.Append("Outbound_Bytes		float, ");//Bytes
                sb.Append("Outbound_Data_Retr	float, ");//Dgrams(Retr)
                sb.Append("Outbound_Bytes_Retr	float, ");//Bytes(Retr)
                sb.Append("Outbound_Eff			float, ");//Efficiency

                //RECVs/SENDs
                sb.Append("Recvs_Issued			float, ");
                sb.Append("Sends_Issued			float, ");
                sb.Append("Retransmits			float, ");
                sb.Append("In_Retr_Mode			float, ");

                sb.Append("CONSTRAINT PK_Connection_Records PRIMARY KEY (Record_ID, Local_Port, Foreign_Port, Foreign_IP, Conn_Start_Time, Conn_End_Time));");

                return sb.ToString();
            }
        }
        private string CREATETABLE_JobStep_Records
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE JobStep_Records(");
                sb.Append("Record_ID		int identity, ");

                sb.Append("PID				char(2), ");
                sb.Append("Job_Name			varchar(8), ");
                sb.Append("Step_Name		varchar(8), ");

                //sb.Append("Job_Start_Date	datetime, ");
                sb.Append("Step_Start_Time	datetime, ");
                sb.Append("Step_End_Time	datetime, ");

                sb.Append("Duration_Sec		float, ");
                sb.Append("Cpu_Time_Sec		float, ");
                sb.Append("Total_IO			float, ");

                sb.Append("CONSTRAINT PK_JobStep_Records PRIMARY KEY (Record_ID, Job_Name, Step_Name, Step_Start_Time));");

                return sb.ToString();
            }
        }
        #endregion
        public void AddTables()
        {
            ExecuteNonQuery(Connection, CREATETABLE_Connection_BSDC);
            ExecuteNonQuery(Connection, CREATETABLE_Connection_Records);
            ExecuteNonQuery(Connection, CREATETABLE_Connection_Stats);
            ExecuteNonQuery(Connection, CREATETABLE_CPU_Stats);
            ExecuteNonQuery(Connection, CREATETABLE_ForeignIP_All);
            ExecuteNonQuery(Connection, CREATETABLE_ForeignIP_Stats);
            ExecuteNonQuery(Connection, CREATETABLE_FTP_Records);
            ExecuteNonQuery(Connection, CREATETABLE_JobStep_Records);
            ExecuteNonQuery(Connection, CREATETABLE_Link_Adapter);
            ExecuteNonQuery(Connection, CREATETABLE_Partition_Job_Step);
            ExecuteNonQuery(Connection, CREATETABLE_SeeServer_Summary);
            ExecuteNonQuery(Connection, CREATETABLE_Startup_Records);
            ExecuteNonQuery(Connection, CREATETABLE_TCPIP_Clients);
            ExecuteNonQuery(Connection, CREATETABLE_TCPIP_Daemons);
            ExecuteNonQuery(Connection, CREATETABLE_TCPIP_Dispatcher);
            ExecuteNonQuery(Connection, CREATETABLE_TCPIP_Errors);
            ExecuteNonQuery(Connection, CREATETABLE_TCPIP_Messages);
            ExecuteNonQuery(Connection, CREATETABLE_TCPIP_Other);
            ExecuteNonQuery(Connection, CREATETABLE_TCPIP_Summary);
            ExecuteNonQuery(Connection, CREATETABLE_TCPIP_Traffic);
            ExecuteNonQuery(Connection, CREATETABLE_VSE_Stats);
            ExecuteNonQuery(Connection, CREATETABLE_VSE_Summary);
        }        
        
        public void ClearTCIP_Messages()
        {
            /* Must drop and recreate so the RecordID feild starts at 1 */
            ExDropTable("TCPIP_Messages");
            ExecuteNonQuery(Connection, CREATETABLE_TCPIP_Messages);
        }
        private DateTime[] ExtractPollTimes(VseDbDataSet.VSE_SummaryDataTable vTable)
        {
            DateTime[] times = new DateTime[vTable.Count];
            int i = 0;
            foreach (VseDbDataSet.VSE_SummaryRow vRow in vTable.Rows)
            {
                times[i] = vRow.Poll_Time;
                i++;
            }
            return times;
        }
        public DateTime[] GetPollTimes(DateTime startAt, DateTime endAt)        
        {
            DateTime[] times = new DateTime[0];
            try
            {
                return ExtractPollTimes(adapt15.GetPollTimeDataBy(startAt, endAt));
            }
            catch (Exception exc)
            {//Do nothing
                System.Diagnostics.Debug.WriteLine(exc.ToString());
                return times;
            }
                     
                
        }
        public int FillPollTimes(VseDbDataSet.VSE_SummaryDataTable table, DateTime startAt, DateTime endAt)
        { return adapt15.FillPollTimeBy(table, startAt, endAt); }
        public DateTime[] GetLast10PollTimes(DateTime sessionStart)
        {
            //Must be between 1/1/1753 12:00:00 AM and 12/31/9999 11:59:59 PM. 
            DateTime[] times = new DateTime[0];
            try
            {
                return ExtractPollTimes(adapt15.GetDataByLast10(sessionStart));
            }
            catch(Exception exc)
            {//Do nothing
                System.Diagnostics.Debug.WriteLine(exc.ToString());
                return times;
            }
            
        }

        public int Fill_AllIps(VseDbDataSet dataSet, DateTime time, bool clearBeforeFill)
        {
            adapt16.ClearBeforeFill = clearBeforeFill;
            return adapt16.FillBy(dataSet.ForeignIP_All, time);
        }
        public int Fill_Poll(VseDbDataSet dataSet, DateTime time, bool clearBeforeFill)
        {
            adapt0.ClearBeforeFill = clearBeforeFill;
            adapt1.ClearBeforeFill = clearBeforeFill;
            adapt2.ClearBeforeFill = clearBeforeFill;
            adapt3.ClearBeforeFill = clearBeforeFill;
            adapt4.ClearBeforeFill = clearBeforeFill;
            adapt5.ClearBeforeFill = clearBeforeFill;
            adapt6.ClearBeforeFill = clearBeforeFill;
            adapt7.ClearBeforeFill = clearBeforeFill;
            adapt8.ClearBeforeFill = clearBeforeFill;
            adapt9.ClearBeforeFill = clearBeforeFill;
            adapt10.ClearBeforeFill = clearBeforeFill;
            adapt11.ClearBeforeFill = clearBeforeFill;
            adapt12.ClearBeforeFill = clearBeforeFill;
            adapt13.ClearBeforeFill = clearBeforeFill;
            adapt14.ClearBeforeFill = clearBeforeFill;
            adapt15.ClearBeforeFill = clearBeforeFill;

            adapt0.FillBy(dataSet.Connection_BSDC, time);
            adapt1.FillBy(dataSet.Connection_Stats, time);
            adapt2.FillBy(dataSet.CPU_Stats, time);
            adapt3.FillBy(dataSet.ForeignIP_Stats, time);
            adapt4.FillBy(dataSet.Link_Adapter, time);
            adapt5.FillBy(dataSet.Partition_Job_Step, time);
            adapt6.FillBy(dataSet.SeeServer_Summary, time);
            adapt7.FillBy(dataSet.TCPIP_Clients, time);
            adapt8.FillBy(dataSet.TCPIP_Daemons, time);
            adapt9.FillBy(dataSet.TCPIP_Dispatcher, time);
            adapt10.FillBy(dataSet.TCPIP_Errors, time);
            adapt11.FillBy(dataSet.TCPIP_Other, time);
            adapt12.FillBy(dataSet.TCPIP_Summary, time);
            adapt13.FillBy(dataSet.TCPIP_Traffic, time);
            adapt14.FillBy(dataSet.VSE_Stats, time);
            return adapt15.FillBy(dataSet.VSE_Summary, time);

            //adapt18.FillBy(dataSet.Startup_Records);
            //adapt19.FillBy(dataSet.Connection_Records);
            //adapt20.FillBy(dataSet.FTP_Records);
            //adapt21.FillBy(dataSet.JobStep_Records);
            
        }        

        public int Fill_ForgnIpStatsByRange(VseDbDataSet dataSet, bool clearBeforeFill,
            DateTime start, DateTime end)
        {
            TimeSpan OneSecond = new TimeSpan(0,0,1);
            DateTime DtStart = start - OneSecond;
            DateTime DtEnd = end + OneSecond;
            adapt3.ClearBeforeFill = clearBeforeFill;
            int recs = adapt3.FillByTimeRange(dataSet.ForeignIP_Stats, DtStart, DtEnd);
            return recs;
        }
        public VseDbDataSet.ForeignIP_StatsDataTable Fill_DistinctIpStatsByRange(DateTime start, DateTime end)
        {
            TimeSpan OneSecond = new TimeSpan(0, 0, 1);
            DateTime DtStart = start - OneSecond;
            DateTime DtEnd = end + OneSecond;

            VseDbDataSet dset = new VseDbDataSet();
            dset.EnforceConstraints = false;
            adapt3.FillDistinctByTimeRange(dset.ForeignIP_Stats, DtStart, DtEnd);


            return dset.ForeignIP_Stats;
            
        }

        public int Fill_Conn(VseDbDataSet dataSet, bool clearBeforeFill)
        {
            adapt1.ClearBeforeFill = clearBeforeFill;
            adapt19.ClearBeforeFill = clearBeforeFill;

            int cntStats = adapt1.Fill(dataSet.Connection_Stats);
            int cntRecs = adapt19.Fill(dataSet.Connection_Records);
            return cntStats;
        }

        public int Fill_ConnStatsByRange(VseDbDataSet dataSet, bool clearBeforeFill,
            DateTime start, DateTime end)
        {
            TimeSpan OneSecond = new TimeSpan(0, 0, 1);
            DateTime DtStart = start - OneSecond;
            DateTime DtEnd = end + OneSecond;
            adapt1.ClearBeforeFill = clearBeforeFill;
            int recs = adapt1.FillByTimeRange(dataSet.Connection_Stats, DtStart, DtEnd);
            return recs;
        }
        public VseDbDataSet.Connection_StatsDataTable Fill_DistinctConnStatsByRange(DateTime start, DateTime end)
        {
            TimeSpan OneSecond = new TimeSpan(0, 0, 1);
            DateTime DtStart = start - OneSecond;
            DateTime DtEnd = end + OneSecond;

            VseDbDataSet dset = new VseDbDataSet();
            dset.EnforceConstraints = false;
            adapt1.FillDistinctByTimeRange(dset.Connection_Stats, DtStart, DtEnd);

            return dset.Connection_Stats;

        }
        public VseDbDataSet.Connection_StatsDataTable Fill_DistinctLocalPortsByRange(DateTime start, DateTime end)
        {
            TimeSpan OneSecond = new TimeSpan(0, 0, 1);
            DateTime DtStart = start - OneSecond;
            DateTime DtEnd = end + OneSecond;

            VseDbDataSet dset = new VseDbDataSet();
            dset.EnforceConstraints = false;
            adapt1.FillDistinctLocalPortByRange(dset.Connection_Stats, DtStart, DtEnd);

            return dset.Connection_Stats;

        }
        public int Fill_ConnStatsByParams(VseDbDataSet dataSet, bool clearBeforeFill,
            DateTime start, DateTime end, float lport, float fport, string fip, DateTime conn_start_time)
        {
            TimeSpan OneSecond = new TimeSpan(0, 0, 1);
            DateTime DtStart = start - OneSecond;
            DateTime DtEnd = end + OneSecond;
            adapt1.ClearBeforeFill = clearBeforeFill;
            int recs = adapt1.FillBy1(dataSet.Connection_Stats, DtStart, DtEnd,
                lport, fport, fip, conn_start_time);
            return recs;
        }

        public VseDbDataSet.Connection_StatsDataTable Get_ConnStatsByParams(VseDbDataSet dataSet, bool clearBeforeFill,
            DateTime start, DateTime end, float lport, float fport, string fip, DateTime conn_start_time)
        {
            TimeSpan OneSecond = new TimeSpan(0, 0, 1);
            DateTime DtStart = start - OneSecond;
            DateTime DtEnd = end + OneSecond;
            adapt1.ClearBeforeFill = clearBeforeFill;
            VseDbDataSet.Connection_StatsDataTable dtable = adapt1.GetDataBy1(DtStart, DtEnd,
                lport, fport, fip, conn_start_time);
            return dtable;
        }
        
    }
}
