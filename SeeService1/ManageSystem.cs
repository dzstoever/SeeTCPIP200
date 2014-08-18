using csi.see.classlib1;
using csi.see.classlib1.DataSets;
using csi.see.classlib1.DataSets.VseDbDataSetTableAdapters;
using ConsoleRecords;
using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace csi.see.service1
{
    public partial class ManageSystem : Component
    {
        #region Constructor/Destructor
        public ManageSystem(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            construct();
        }
        public ManageSystem()
        {
            InitializeComponent();
            construct();
        }
        public ManageSystem(SeeCommonDataSet.SysDefsRow defRow)
        {
            InitializeComponent();
            _defRow = defRow;
            _name = defRow.Name;
            dataArchiver1 = new DataArchiver(defRow.DbName);
            _sqlConnection = SqlBase.BuildConnection(_defRow.DbName);
            #region Set sqlAdapter Connections
            fAdapter.Connection = _sqlConnection;
            adapter1.Connection = _sqlConnection;
            adapter2.Connection = _sqlConnection;
            adapter3.Connection = _sqlConnection;
            adapter4.Connection = _sqlConnection;
            adapter5.Connection = _sqlConnection;
            adapter6.Connection = _sqlConnection;
            adapter7.Connection = _sqlConnection;
            adapter8.Connection = _sqlConnection;
            adapter9.Connection = _sqlConnection;
            adapter10.Connection = _sqlConnection;
            adapter11.Connection = _sqlConnection;
            adapter12.Connection = _sqlConnection;
            adapter13.Connection = _sqlConnection;
            adapter14.Connection = _sqlConnection;
            adapter15.Connection = _sqlConnection;
            adapter16.Connection = _sqlConnection;            
            #endregion
            construct();
        }
        private void construct()
        {
            manageComm1.OnError += new OnErrorDelegate(manageComm1_OnError);
            manageComm1.OnPollStatusChanged += new OnStatusDelegate(manageComm1_OnPollStatusChanged);
            manageComm1.OnConsoleStatusChanged += new OnStatusDelegate(manageComm1_OnConsoleStatusChanged);
            manageComm1.OnCommandNotSent += new OnSentDelegate(manageComm1_OnCommandNotSent);
            manageComm1.OnCommandSent += new OnSentDelegate(manageComm1_OnCommandSent);
            manageComm1.OnCommandProcessed+=new OnReceivedDelegate(manageComm1_OnCommandProcessed);            
            manageComm1.OnTcpIpMessageReceived += new OnMultiReceivedDelegate(manageComm1_OnTcpIpMessageReceived);
            manageComm1.OnSeeVseStartupReceived += new OnReceivedDelegate(manageComm1_OnSeeVseStartupReceived);
            manageComm1.OnTcpIpTerminationReceived += new OnMultiReceivedDelegate(manageComm1_OnTcpIpTerminationReceived);
            manageComm1.OnFtpTerminationReceived += new OnMultiReceivedDelegate(manageComm1_OnFtpTerminationReceived);
            manageComm1.OnJobStepTerminationReceived += new OnMultiReceivedDelegate(manageComm1_OnJobStepTerminationReceived);
            manageComm1.OnAllIpDataReceived += new OnAllIpDataInDelegate(manageComm1_OnAllIpDataReceived);
            manageComm1.OnPollDataReceived += new OnPollDataInDelegate(manageComm1_OnPollDataReceived);
            manageComm1.OnTraceDataReceived += new OnReceivedDelegate(manageComm1_OnTraceDataReceived);
        }
        //~ManageSystem()
        //{ TurnOffMonitor(); }
        #endregion

        /* public */
        public event UdpDelegate SendUdpBroadcast;
        #region Properties
        public string Name { get { return _name; } }        
        public StatusEventArgs Status { get { return manageComm1.StatusPoll; } }
        public bool IsMonitorOn { get { return _defRow.monOn; } }
        public bool IsPolling { get { return manageComm1.IsPolling; } }
        #endregion
        #region Methods
        public void TurnOnMonitor()
        { manageComm1.Startup(_defRow); }
        public void TurnOffMonitor()
        { manageComm1.Disconnect(); }
        public void SendTcpipCommand(string cmdTxt)
        { manageComm1.SendTcpipCommand(cmdTxt); }//This is triggered by a Udp 301 message
        public void SendForTrace(string cmdName)
        { manageComm1.GetTraceData(); }//This is triggered by a Udp 302 message
        #endregion

        /* private */
        #region Members
        private ManageComm manageComm1 = new ManageComm();
        private DataArchiver dataArchiver1 = null;      //writes console records to the database
        private SqlConnection _sqlConnection = null;    //writes poll data to the database
        #region sqlAdapters for poll data
        ForeignIP_AllTableAdapter fAdapter = new ForeignIP_AllTableAdapter();
        Connection_BSDCTableAdapter adapter1 = new Connection_BSDCTableAdapter();
        Connection_StatsTableAdapter adapter2 = new Connection_StatsTableAdapter();
        CPU_StatsTableAdapter adapter3 = new CPU_StatsTableAdapter();
        ForeignIP_StatsTableAdapter adapter4 = new ForeignIP_StatsTableAdapter();
        Link_AdapterTableAdapter adapter5 = new Link_AdapterTableAdapter();
        Partition_Job_StepTableAdapter adapter6 = new Partition_Job_StepTableAdapter();
        SeeServer_SummaryTableAdapter adapter7 = new SeeServer_SummaryTableAdapter();
        TCPIP_ClientsTableAdapter adapter8 = new TCPIP_ClientsTableAdapter();
        TCPIP_DaemonsTableAdapter adapter9 = new TCPIP_DaemonsTableAdapter();
        TCPIP_DispatcherTableAdapter adapter10 = new TCPIP_DispatcherTableAdapter();
        TCPIP_ErrorsTableAdapter adapter11 = new TCPIP_ErrorsTableAdapter();
        TCPIP_OtherTableAdapter adapter12 = new TCPIP_OtherTableAdapter();
        TCPIP_SummaryTableAdapter adapter13 = new TCPIP_SummaryTableAdapter();
        TCPIP_TrafficTableAdapter adapter14 = new TCPIP_TrafficTableAdapter();
        VSE_StatsTableAdapter adapter15 = new VSE_StatsTableAdapter();
        VSE_SummaryTableAdapter adapter16 = new VSE_SummaryTableAdapter();
        #endregion
        private SeeCommonDataSet.SysDefsRow _defRow;    
        private string _name;                           //This can not be a reference, in case the row gets deleted            
        #endregion
        #region Methods
        private VseDbDataSet.ForeignIP_AllDataTable ConvertAllIpData(RawDataSet.ISBLOKDataTable rawTable, DateTime sessionStart)
        {
            VseDbDataSet vsedbData = new VseDbDataSet();
            vsedbData.EnforceConstraints = false;//Ignore primary key violations, etc...
            /* Add Data to the disconnected dataset */
            foreach (RawDataSet.ISBLOKRow isrow in rawTable.Rows)
            {
                if (isrow.ISIPIN + isrow.ISIPOU > 0)//Skip addresses with no IP Activity
                {
                    #region Set values
                    VseDbDataSet.ForeignIP_AllRow dbIsRow = vsedbData.ForeignIP_All.NewForeignIP_AllRow();
                    dbIsRow.Poll_Time = sessionStart;                    
                    dbIsRow.IP_Address = isrow.ISIPADDR;
                    bool refuse = false;
                    #region ISREFUSE
                    byte bISREFUSE = isrow.ISREFUSE;
                    if (bISREFUSE == 255)//'FF'
                    { refuse = true; }
                    #endregion
                    dbIsRow.Refuse_Flag = refuse;
                    dbIsRow.Misdirected_IP_Datagrams = isrow.ISMISIP;
                    dbIsRow.NonIP_Datagrams = isrow.ISNONIP;
                    dbIsRow.ARP_Inbound_Datagrams = isrow.ISARPIN;
                    dbIsRow.ARP_Outbound_Datagrams = isrow.ISARPOU;
                    dbIsRow.ICMP_Inbound_Datagrams = isrow.ISICMIN;
                    dbIsRow.ICMP_Outbound_Datagrams = isrow.ISICMOU;
                    dbIsRow.IP_Inbound_Datagrams = isrow.ISIPIN;
                    dbIsRow.IP_Outbound_Datagrams = isrow.ISIPOU;
                    dbIsRow.TCP_Inbound_Datagrams = isrow.ISTCPIN;
                    dbIsRow.TCP_Outbound_Datagrams = isrow.ISTCPOU;
                    dbIsRow.UDP_Inbound_Datagrams = isrow.ISUDPIN;
                    dbIsRow.UDP_Outbound_Datagrams = isrow.ISUDPOU;

                    dbIsRow.Misdirected_IP_Bytes = isrow.ISMISIPB;
                    dbIsRow.NonIP_Bytes = isrow.ISNONIPB;
                    dbIsRow.ARP_Inbound_Bytes = isrow.ISARPINB;
                    dbIsRow.ARP_Outbound_Bytes = isrow.ISARPOUB;
                    dbIsRow.ICMP_Inbound_Bytes = isrow.ISICMINB;
                    dbIsRow.ICMP_Outbound_Bytes = isrow.ISICMOUB;
                    dbIsRow.IP_Inbound_Bytes = isrow.ISIPINB;
                    dbIsRow.IP_Outbound_Bytes = isrow.ISIPOUB;
                    dbIsRow.TCP_Inbound_Bytes = isrow.ISTCPINB;
                    dbIsRow.TCP_Outbound_Bytes = isrow.ISTCPOUB;
                    dbIsRow.UDP_Inbound_Bytes = isrow.ISUDPINB;
                    dbIsRow.UDP_Outbound_Bytes = isrow.ISUDPOUB;

                    dbIsRow.Refused_Datagrams = isrow.ISREFIN;
                    dbIsRow.Refused_Bytes = isrow.ISREFINB;
                    #endregion                    
                    try
                    { vsedbData.ForeignIP_All.AddForeignIP_AllRow(dbIsRow); }
                    catch (ConstraintException cExc)
                    { Debug.WriteLine(cExc.Message); }
                }
                //else { Debug.WriteLine("(ISBLOKAL)No Ip Activity for " + isrow.ISIPADDR); }
            }

            try { vsedbData.EnforceConstraints = true; }//Now check for constraint violations
            catch (ConstraintException cExc)
            {
                Debug.WriteLine(cExc.ToString());
                Service1.WriteAppLogError(cExc.ToString(), 1000);
            }
            return vsedbData.ForeignIP_All;
        }
        private VseDbDataSet ConvertPollData(RawDataSet pollData, DateTime pollTime, string BsdcPID)
        {
            VseDbDataSet vsedbData = new VseDbDataSet();
            //vsedbData.EnforceConstraints = false;//Ignore primary key violations, etc...
            RawDataConverter vseConvert = new RawDataConverter();//Use for any conversions needed
            RawDataSet.SVSEINITRow svrow = (RawDataSet.SVSEINITRow)pollData.SVSEINIT.Rows[0];
            #region Calculate needed values from the SVSEINITRow
            double vseoffsetSec = Convert.ToDouble((int)svrow.SINTGMT0);
            DateTime resetTime = (DateTime)svrow.SINTCRTM;
            DateTime iplTime = (DateTime)svrow.SINTVIPL;
            TimeSpan wallspanReset = pollTime.Subtract(resetTime);//new TimeSpan(pollTime.Ticks - resetTime.Ticks);
            TimeSpan wallspanIPL = pollTime.Subtract(iplTime);//new TimeSpan(pollTime.Ticks - iplTime.Ticks);
            float secSinceReset = Convert.ToSingle(wallspanReset.TotalSeconds);
            float secSinceIPL = Convert.ToSingle(wallspanIPL.TotalSeconds);
            #endregion
            /* Add Data to the disconnected dataset */
            #region VSE_Summary
            bool euroDates = false;
            #region SINTFLG1
            byte euroFlag = svrow.SINTFLG1;
            if (euroFlag == 0x80) { euroDates = true; }
            #endregion
            VseDbDataSet.VSE_SummaryRow dbVsummRow = vsedbData.VSE_Summary.NewVSE_SummaryRow();
            dbVsummRow.Poll_Time = pollTime;
            dbVsummRow.Last_IPL_Time = iplTime;
            dbVsummRow.Last_CpuReset_Time = resetTime;
            dbVsummRow.Sec_since_IPL = secSinceIPL;
            dbVsummRow.Sec_since_CpuReset = secSinceReset;
            dbVsummRow.Cpu_ID = svrow.SINTVCPU;
            dbVsummRow.Release = svrow.SINTVVER;
            dbVsummRow.Power_Sys_ID = svrow.SINTPSID;
            dbVsummRow.Power_Node = svrow.SINTPNAM;
            dbVsummRow.European_Dates = euroDates;
            dbVsummRow.Time_Zone_Offset = vseoffsetSec;
            dbVsummRow.Nof_Cpus = svrow.SINTCPUN;
            dbVsummRow.Nof_Active_Cpus = svrow.SINTCPUA;
            dbVsummRow.Nof_Quiesced_Cpus = svrow.SINTCPUQ;
            dbVsummRow.MaxNof_Tasks = svrow.SINTNTSK;
            dbVsummRow.Nof_Active_Tasks = svrow.SINTATSK;
            dbVsummRow.MaxNof_Partitions = svrow.SINTNPRT;
            dbVsummRow.Nof_Allocated_Partitions = svrow.SINTAPRT;
            dbVsummRow.Nof_TCPIP_Stacks = svrow.SINTICNT;
            vsedbData.VSE_Summary.AddVSE_SummaryRow(dbVsummRow);
            #endregion
            #region VSE_Stats
            VseDbDataSet.VSE_StatsRow dbVstatsRow = vsedbData.VSE_Stats.NewVSE_StatsRow();
            dbVstatsRow.Poll_Time = pollTime;
            dbVstatsRow.Program_Checks = svrow.SINTPCHK;
            dbVstatsRow.Phase_Loads = svrow.SINTPHLD;
            dbVstatsRow.Subchannel_Starts = svrow.SINTSSCH;
            dbVstatsRow.Supervisor_Interrupts = svrow.SINTSVCI;
            dbVstatsRow.IO_Interrupts = svrow.SINTIOIN;
            dbVstatsRow.External_Interrupts = svrow.SINTEXTI;
            vsedbData.VSE_Stats.AddVSE_StatsRow(dbVstatsRow);
            #endregion
            #region TCPIP_Summary
            string licCsiIbm = "";
            #region SINTIBM
            string licenseCode = svrow.SINTIIBM;//Hex String
            if (licenseCode == "00") { licCsiIbm = "CSI"; }
            else if (licenseCode == "FF") { licCsiIbm = "IBM"; }
            #endregion
            VseDbDataSet.TCPIP_SummaryRow dbTsRow = vsedbData.TCPIP_Summary.NewTCPIP_SummaryRow();
            dbTsRow.Poll_Time = pollTime;
            dbTsRow.TCPIP_Start_Time = svrow.SINTISDT;
            dbTsRow.Sys_ID = svrow.SINTISID;
            dbTsRow.PID = svrow.SINTIPID;
            dbTsRow.Job_Name = svrow.SINTIJNM;
            dbTsRow.Release = svrow.SINTIVER;
            dbTsRow.License = licCsiIbm;
            dbTsRow.IP_Address = svrow.SINTIPAD;
            dbTsRow.Console_Port = svrow.SINTCPRT;
            dbTsRow.Nof_TCPIP_Connections = svrow.SINTNCCA;
            dbTsRow.Nof_TCPIP_PseudoTasks = svrow.SINTNTCS;
            vsedbData.TCPIP_Summary.AddTCPIP_SummaryRow(dbTsRow);
            #endregion
            #region SeeServer_Summary
            VseDbDataSet.SeeServer_SummaryRow dbSvRow = vsedbData.SeeServer_Summary.NewSeeServer_SummaryRow();
            dbSvRow.Poll_Time = pollTime;
            dbSvRow.SeeServer_Start_Time = svrow.SINTSTIM;
            dbSvRow.PID = svrow.SINTSPID;
            dbSvRow.Job_Name = svrow.SINTSJNM;
            dbSvRow.Release = svrow.SINTSVER;
            vsedbData.SeeServer_Summary.AddSeeServer_SummaryRow(dbSvRow);
            #endregion
            RawDataSet.IVBLOKRow ivrow = (RawDataSet.IVBLOKRow)pollData.IVBLOK.Rows[0];
            float dispatchtimeSec = Convert.ToSingle(ivrow.V2TOTIME) / 4096;
            #region TCPIP_Clients
            VseDbDataSet.TCPIP_ClientsRow dbTclRow = vsedbData.TCPIP_Clients.NewTCPIP_ClientsRow();
            dbTclRow.Poll_Time = pollTime;
            dbTclRow.FTP_Clients = ivrow.FTPVICNT;
            dbTclRow.Telnet_Clients = ivrow.TELVICNT;
            dbTclRow.LPR_Clients = ivrow.LPDVICNT;
            dbTclRow.HTTP_Clients = ivrow.HTTVICNT;
            vsedbData.TCPIP_Clients.AddTCPIP_ClientsRow(dbTclRow);
            #endregion
            #region TCPIP_Daemons
            VseDbDataSet.TCPIP_DaemonsRow dbTdaRow = vsedbData.TCPIP_Daemons.NewTCPIP_DaemonsRow();
            dbTdaRow.Poll_Time = pollTime;
            dbTdaRow.FTP_Daemons = ivrow.FTPCOUNT;
            dbTdaRow.Active_FTP_Daemons = ivrow.V2FTPACT;
            dbTdaRow.Max_FTP_Daemons = ivrow.V2FTPMAX;
            dbTdaRow.Telnet_Daemons = ivrow.TELCOUNT;
            dbTdaRow.Active_Telnet_Daemons = ivrow.V2TLNACT;
            dbTdaRow.Max_Telnet_Daemons = ivrow.V2TLNMAX;
            dbTdaRow.Active_Telnet_Buffers = ivrow.V2TLNBAC;
            dbTdaRow.Max_Telnet_Buffers = ivrow.V2TLNBMX;
            dbTdaRow.LP_Daemons = ivrow.LPDCOUNT;
            dbTdaRow.HTTP_Daemons = ivrow.HTTCOUNT;
            dbTdaRow.SMTP_Daemons = ivrow.V2SMTPCT;
            dbTdaRow.POP3_Daemons = ivrow.V2POP3CT;
            vsedbData.TCPIP_Daemons.AddTCPIP_DaemonsRow(dbTdaRow);
            #endregion
            #region TCPIP_Dispatcher
            VseDbDataSet.TCPIP_DispatcherRow dbTdiRow = vsedbData.TCPIP_Dispatcher.NewTCPIP_DispatcherRow();
            dbTdiRow.Poll_Time = pollTime;
            dbTdiRow.Total_Dispatches = ivrow.V2DSPCNT;
            dbTdiRow.Active_Dispatches = ivrow.V2ACTCNT;
            dbTdiRow.Fixed_Dispatches = ivrow.V2FXDCNT;
            dbTdiRow.Quick_Dispatches = ivrow.V2QUICNT;
            dbTdiRow.Persistent_Dispatches = ivrow.V2PERCNT;
            dbTdiRow.Complete_Dispatches = ivrow.V2COMCNT;
            dbTdiRow.Passed_Dispatches = ivrow.V2PASCNT;
            dbTdiRow.Total_Dispatcher_Time = dispatchtimeSec;
            dbTdiRow.Dispatcher_Waits = ivrow.WAITCNTR;
            dbTdiRow.Storage_Releases = ivrow.CUSHONRE;
            vsedbData.TCPIP_Dispatcher.AddTCPIP_DispatcherRow(dbTdiRow);
            #endregion
            #region TCPIP_Errors
            VseDbDataSet.TCPIP_ErrorsRow dbTerRow = vsedbData.TCPIP_Errors.NewTCPIP_ErrorsRow();
            dbTerRow.Poll_Time = pollTime;
            dbTerRow.TCP_Checksum_Errors = ivrow.V2CTTCHK;
            dbTerRow.IP_Checksum_Errors = ivrow.V2CTICHK;
            dbTerRow.UDP_Checksum_Errors = ivrow.V2CTUCHK;
            dbTerRow.ICMP_Checksum_Errors = ivrow.V2CTCCHK;
            dbTerRow.Datagram_Length_Errors = ivrow.V2CTLENE;
            vsedbData.TCPIP_Errors.AddTCPIP_ErrorsRow(dbTerRow);
            #endregion
            #region TCPIP_Other
            VseDbDataSet.TCPIP_OtherRow dbTotRow = vsedbData.TCPIP_Other.NewTCPIP_OtherRow();
            dbTotRow.Poll_Time = pollTime;
            dbTotRow.Non_IP = ivrow.NONIPCNT;
            dbTotRow.Miss_Routed_IP = ivrow.MISIPCNT;
            dbTotRow.Discarded_UDP = ivrow.V2CTUDP;
            dbTotRow.Unsupported_ICMP = ivrow.V2CTICMP;
            dbTotRow.Unsupported_IGMP = ivrow.V2CTIGMP;
            dbTotRow.Unsupported_Protocol = ivrow.V2CTIP;
            dbTotRow.Connect_Rejections = ivrow.V2CTREJ;
            dbTotRow.Inbound_TCP_Rejections = ivrow.REFVICNT;
            vsedbData.TCPIP_Other.AddTCPIP_OtherRow(dbTotRow);
            #endregion
            #region TCPIP_Traffic
            VseDbDataSet.TCPIP_TrafficRow dbTtrRow = vsedbData.TCPIP_Traffic.NewTCPIP_TrafficRow();
            dbTtrRow.Poll_Time = pollTime;
            dbTtrRow.Int_FTP_Files_Sent = ivrow.FILESCNT;
            dbTtrRow.Int_FTP_Files_Received = ivrow.FILERCNT;
            dbTtrRow.Int_FTP_Bytes_Sent = ivrow.DATASCNT;
            dbTtrRow.Int_FTP_Bytes_Received = ivrow.DATARCNT;
            dbTtrRow.Telnet_Bytes_Sent = ivrow.TERMSCNT;
            dbTtrRow.Telnet_Bytes_Received = ivrow.TERMRCNT;
            dbTtrRow.TCP_Bytes_Sent = ivrow.TCPSCNT;
            dbTtrRow.TCP_Bytes_Received = ivrow.TCPRCNT;
            dbTtrRow.UDP_Bytes_Sent = ivrow.UDPSCNT;
            dbTtrRow.UDP_Bytes_Received = ivrow.UDPRCNT;
            dbTtrRow.IP_Bytes_Sent = ivrow.IPSCNT;
            dbTtrRow.IP_Bytes_Received = ivrow.IPRCNT;
            dbTtrRow.Arps_In = ivrow.ARPIPCNT;
            dbTtrRow.Arp_Requests_Inbound = ivrow.PROC6CNT;
            dbTtrRow.Arp_Requests_Outbound = ivrow.PROC4CNT;
            dbTtrRow.Arp_Replies_Outbound = ivrow.PROC5CNT;
            dbTtrRow.IPNL3172_Blocks_Received = ivrow.PROC0CNT;
            dbTtrRow.IPNL3172_Blocks_Transmitted = ivrow.PROC2CNT;
            dbTtrRow.IPNL3172_Datagrams_Inbound = ivrow.PROC1CNT;
            dbTtrRow.IPNL3172_Datagrams_Outbound = ivrow.PROC3CNT;
            vsedbData.TCPIP_Traffic.AddTCPIP_TrafficRow(dbTtrRow);
            #endregion

            #region CPU_Stats
            foreach (RawDataSet.TDCPURow tdrow in pollData.TDCPU.Rows)
            {
                #region Set values
                string tdstate = "Inactive";
                #region TUCPUFLG
                string StatusCode = tdrow.TUCPUFLG;//Hex string
                if (StatusCode == "40")
                { tdstate = "Active"; }
                else if (StatusCode == "02")
                { tdstate = "Quiesced"; }
                #endregion
                #region TUCPUTIM
                float dTcpuSec = 0;
                float dNonpSec = 0;
                float dSpinSec = 0;
                float dAllbSec = 0;
                float nonvseSec = 0;
                float busypSec = 0;
                if (StatusCode == "40")
                {
                    dTcpuSec = Convert.ToSingle(tdrow.TUCPUTIM) / 62500;//Convert from 16us units to seconds
                    dNonpSec = Convert.ToSingle(tdrow.TUCPUNP) / 62500;
                    dSpinSec = Convert.ToSingle(tdrow.TUCPUSPN) / 62500;
                    dAllbSec = Convert.ToSingle(tdrow.TUCPUALB) / 62500;
                    nonvseSec = secSinceReset - dTcpuSec - dSpinSec - dAllbSec;
                    busypSec = dTcpuSec - dNonpSec;
                    if (nonvseSec < 0) { nonvseSec = 0; }//Set to zero if any calculated time is negative
                    if (busypSec < 0) { busypSec = 0; }
                }
                #endregion
                VseDbDataSet.CPU_StatsRow dbTdRow = vsedbData.CPU_Stats.NewCPU_StatsRow();
                dbTdRow.Poll_Time = pollTime;
                dbTdRow.CPU_ID = tdrow.TUCPUID;
                dbTdRow.CPU_State = tdstate;
                dbTdRow.Dispatch_Cycles = tdrow.TUCPUDCY;
                dbTdRow.NonVSE_sec = nonvseSec;
                dbTdRow.Spin_sec = dSpinSec;
                dbTdRow.Waiting_sec = dAllbSec;
                dbTdRow.Busy_P_sec = busypSec;
                dbTdRow.Busy_NonP_sec = dNonpSec;
                #endregion                
                try
                { vsedbData.CPU_Stats.AddCPU_StatsRow(dbTdRow); }
                catch (ConstraintException cExc)
                { Debug.WriteLine(cExc.Message); }
            }
            #endregion
            #region Partition_Job_Step
            foreach (RawDataSet.GVVPRow gvrow in pollData.GVVP.Rows)
            {
                #region Set values
                float cputime16us = Convert.ToSingle(gvrow.GVVPCPUT);
                float cputimeSec = cputime16us / 62500;//Convert from 16us units to seconds
                VseDbDataSet.Partition_Job_StepRow dbGvRow = vsedbData.Partition_Job_Step.NewPartition_Job_StepRow();
                dbGvRow.Poll_Time = pollTime;
                dbGvRow.Partition_ID = gvrow.GVVPPTID;
                dbGvRow.Power_Job_Name = gvrow.GVVPPWRN;
                dbGvRow.VSE_Job_Name = gvrow.GVVPJBNM;
                dbGvRow.VSE_Step_Name = gvrow.GVVPSTEP;
                dbGvRow.Job_Start_Time = gvrow.GVVPJSTM;
                dbGvRow.Step_Start_Time = gvrow.GVVPSSTM;
                dbGvRow.CPU_Time_sec = cputimeSec;
                dbGvRow.SIO_Count = gvrow.GVVPSIOS;
                dbGvRow.Priority = gvrow.GVVPPRTY;
                #endregion                
                try
                { vsedbData.Partition_Job_Step.AddPartition_Job_StepRow(dbGvRow); }
                catch (ConstraintException cExc)
                { Debug.WriteLine(cExc.Message); }
            }
            #endregion
            #region Link_Adapter
            foreach (RawDataSet.LKBLOKRow lkrow in pollData.LKBLOK.Rows)
            {
                #region Set values
                string blktype = "Unknown";
                #region Set the "Type" value
                if (lkrow.LKBLKTYP == 0)
                { blktype = "Link"; }
                else if (lkrow.LKBLKTYP == 1)
                { blktype = "Adapter"; }
                #endregion
                VseDbDataSet.Link_AdapterRow dbLkRow = vsedbData.Link_Adapter.NewLink_AdapterRow();
                dbLkRow.Poll_Time = pollTime;
                dbLkRow.Type = blktype;
                dbLkRow.Link_ID = lkrow.LKNODE;
                dbLkRow.Define_Type = lkrow.LKTYPE;
                dbLkRow.MTU = lkrow.LKMTU;
                dbLkRow.CUU_Name = lkrow.LKCUU;
                dbLkRow.Alternate_CUU = lkrow.LKCUU2;
                dbLkRow.IP_Address = lkrow.LKIPADDR;
                #endregion
                try
                { vsedbData.Link_Adapter.AddLink_AdapterRow(dbLkRow); }
                catch (ConstraintException cExc)
                { Debug.WriteLine(cExc.Message); }
            }
            #endregion
            #region Connection_Stats
            foreach (RawDataSet.CCBLOKRow ccrow in pollData.CCBLOK.Rows)
            {
                if (ccrow.CCIDENT > 0)//Skip addresses with identifier
                {
                    #region Set values
                    string ccintext = "";//Set the "INT_EXT" value - invalid in 15F
                    string ccstate = "---";	//Set the "Conn_State" value
                    string ccproto = "---";	//Set the "Conn_Protocol" value
                    float InbEff = 0;
                    float OutbEff = 0;
                    #region CCLOCAL - invalid in 15F
                    //byte bCCLOCAL = ccrow.CCLOCAL;
                    //if (bCCLOCAL == 0xFF) { ccintext = "INT"; }
                    //else { ccintext = "EXT"; }
                    #endregion
                    #region CCSTATE
                    byte bCCSTATE = ccrow.CCSTATE;
                    if (bCCSTATE == 1)
                    { ccstate = "Listen"; }
                    else if (bCCSTATE == 2)
                    { ccstate = "Syn Sent"; }
                    else if (bCCSTATE == 3)
                    { ccstate = "Syn Received"; }
                    else if (bCCSTATE == 4)
                    { ccstate = "Established"; }
                    else if (bCCSTATE == 5)
                    { ccstate = "Fin Wait 1"; }
                    else if (bCCSTATE == 6)
                    { ccstate = "Fin Wait 2"; }
                    else if (bCCSTATE == 7)
                    { ccstate = "Close Wait"; }
                    else if (bCCSTATE == 8)
                    { ccstate = "Last Ack"; }
                    else if (bCCSTATE == 9)
                    { ccstate = "Time Wait"; }
                    else if (bCCSTATE == 10)
                    { ccstate = "Closed"; }
                    #endregion
                    #region CCPROTO
                    byte bCCPROTO = ccrow.CCPROTO;
                    if (bCCPROTO == 1)
                    { ccproto = "ICMP"; }
                    else if (bCCPROTO == 2)
                    { ccproto = "IGMP"; }
                    else if (bCCPROTO == 6)
                    { ccproto = "TCP"; }
                    else if (bCCPROTO == 17)
                    { ccproto = "UDP"; }
                    else if (bCCPROTO == 254)
                    {
                        byte bCCFLAGAA = ccrow.CCFLAGAA;
                        if (bCCFLAGAA == 0x40)
                        { ccproto = "control"; }
                        else if (bCCFLAGAA == 0x20)
                        { ccproto = "client"; }
                        else if (bCCFLAGAA == 0x10)
                        { ccproto = "ftp"; }
                        else if (bCCFLAGAA == 0x8)
                        { ccproto = "telnet"; }
                        else
                        { ccproto = "internal"; }
                    }
                    else if (bCCPROTO == 255)
                    { ccproto = "RAW"; }
                    else
                    { ccproto = "unknown"; }
                    #endregion
                    #region Efficiency
                    /*The efficiency rating indicates that ratio of
				*%       data bytes to the actual bytes traversing the network.
				*%       For example, an efficiency of 75% indicates that
				*%       25% of your network resource was consumed by overhead
				*%       while this connection was communicating.*/
                    float InData = Convert.ToSingle(ccrow.CCIBCNTI);
                    float InDataDup = Convert.ToSingle(ccrow.CCIBDUPI);
                    float InBytes = Convert.ToSingle(ccrow.CCBTCNTI);
                    float InBytesDup = Convert.ToSingle(ccrow.CCBTDUPI);
                    float InActual = 40 * (InData + InDataDup) + InBytes + InBytesDup;
                    if (InActual > 0 && InBytes > 0)
                    { InbEff = InBytes / InActual; }

                    float OutData = Convert.ToSingle(ccrow.CCIBCNTO);
                    float OutDataDup = Convert.ToSingle(ccrow.CCIBDUPO);
                    float OutBytes = Convert.ToSingle(ccrow.CCBTCNTO);
                    float OutBytesDup = Convert.ToSingle(ccrow.CCBTDUPO);
                    float OutActual = 40 * (OutData + OutDataDup) + OutBytes + OutBytesDup;
                    if (OutActual > 0 && OutBytes > 0)
                    { OutbEff = OutBytes / OutActual; }

                    #endregion
                    VseDbDataSet.Connection_StatsRow dbCcRow = vsedbData.Connection_Stats.NewConnection_StatsRow();
                    dbCcRow.Poll_Time = pollTime;
                    
                    dbCcRow.Conn_PID = ccrow.PID;
                    //if (!Convert.IsDBNull(ccrow.CCPHASE))
                    dbCcRow.Conn_Phase = ccrow.CCPHASE; 
                    dbCcRow.Local_Port = ccrow.CCLOPORT;
                    dbCcRow.Foreign_Port = ccrow.CCFOPORT;
                    dbCcRow.Foreign_IP = ccrow.CCFOIP;
                    dbCcRow.CCIDENT = ccrow.CCIDENT;
                    dbCcRow.Conn_Start_Time = vseConvert.ConvertSTCKtoDTutc(ccrow.CCIDENT).AddSeconds(vseoffsetSec);
                    dbCcRow.INT_EXT = ccintext;
                    dbCcRow.Conn_State = ccstate;
                    dbCcRow.Conn_Protocol = ccproto;
                    dbCcRow.Highest_Depth = ccrow.CCDEPMAX;
                    dbCcRow.Max_Send_Window = ccrow.CCMAXWND;
                    dbCcRow.Max_Recv_Window = ccrow.CCRWINSZ;
                    dbCcRow.Recv_Window_Closed = ccrow.CCRWCCNT;
                    dbCcRow.SWS_Count = ccrow.CCSWSCNT;

                    dbCcRow.Inbound_Data = ccrow.CCIBCNTI;
                    dbCcRow.Inbound_Bytes = ccrow.CCBTCNTI;
                    dbCcRow.Inbound_Data_Dup = ccrow.CCIBDUPI;
                    dbCcRow.Inbound_Bytes_Dup = ccrow.CCBTDUPI;
                    if (InbEff > 0) { dbCcRow.Inbound_Eff = InbEff; }

                    dbCcRow.Outbound_Data = ccrow.CCIBCNTO;
                    dbCcRow.Outbound_Bytes = ccrow.CCBTCNTO;
                    dbCcRow.Outbound_Data_Retr = ccrow.CCIBDUPO;
                    dbCcRow.Outbound_Bytes_Retr = ccrow.CCBTDUPO;
                    if (OutbEff > 0) { dbCcRow.Outbound_Eff = OutbEff; }

                    dbCcRow.Recvs_Issued = ccrow.CCSORCNT;
                    dbCcRow.Sends_Issued = ccrow.CCSOSCNT;
                    dbCcRow.Retransmits = ccrow.CCRETCNT;
                    dbCcRow.In_Retr_Mode = ccrow.CCRETMOD;
                    #endregion
                    try
                    { vsedbData.Connection_Stats.AddConnection_StatsRow(dbCcRow); }
                    catch (ConstraintException cExc)
                    { Debug.WriteLine(cExc.Message); }
                }
            }
            #endregion
            #region Connection_BSDC
            foreach (RawDataSet.RSBLOKRow rsrow in pollData.RSBLOK.Rows)
            {
                #region Set values
                VseDbDataSet.Connection_BSDCRow dbRsRow = vsedbData.Connection_BSDC.NewConnection_BSDCRow();
                dbRsRow.Poll_Time = pollTime;
                dbRsRow.PID = BsdcPID;
                dbRsRow.Store_Clock = rsrow.RSOCLOCK;//Does this need a utcOffset?
                dbRsRow.CCBLOK_ID = rsrow.RSOCCIDN;
                dbRsRow.Sock_Descriptor = rsrow.RSODESC;
                dbRsRow.Queue_Depth = rsrow.RSOQUEUE;
                dbRsRow.Foreign_IP = rsrow.RSOIPAD;
                dbRsRow.Local_IP = rsrow.RSOLIPAD;
                dbRsRow.Foreign_Port = rsrow.RSOPORT;
                dbRsRow.Local_Port = rsrow.RSOLPORT;
                dbRsRow.Base_Sock_Addr = rsrow.RSOBASE;
                dbRsRow.CICS_Trans_ID = rsrow.RSOTRNID;
                dbRsRow.CICS_Task = rsrow.RSOTASKN;
                dbRsRow.Sock_Number = rsrow.RSOSOCKN;
                dbRsRow.Sock_Addr = rsrow.RSOSOCK;
                dbRsRow.Flag_1 = rsrow.RSOFLAG;
                dbRsRow.Sock_Options = rsrow.RSOOPT;
                dbRsRow.Flag_2 = rsrow.RSOFLAG2;
                dbRsRow.Type = rsrow.RSOTYPE;
                #endregion
                try
                { vsedbData.Connection_BSDC.AddConnection_BSDCRow(dbRsRow); }
                catch (ConstraintException cExc)
                { Debug.WriteLine(cExc.Message); }
            }
            #endregion
            #region ForeignIP_Stats
            foreach (RawDataSet.ISBLOKRow isrow in pollData.ISBLOK.Rows)
            {
                if (isrow.ISIPIN + isrow.ISIPOU > 0)//Skip addresses with no IP Activity
                {
                    #region Set values
                    VseDbDataSet.ForeignIP_StatsRow dbIsRow = vsedbData.ForeignIP_Stats.NewForeignIP_StatsRow();
                    dbIsRow.Poll_Time = pollTime;                    
                    dbIsRow.IP_Address = isrow.ISIPADDR;
                    bool refuse = false;
                    #region ISREFUSE
                    byte bISREFUSE = isrow.ISREFUSE;
                    if (bISREFUSE == 255)//'FF'
                    { refuse = true; }
                    #endregion
                    dbIsRow.Refuse_Flag = refuse;
                    dbIsRow.Misdirected_IP_Datagrams = isrow.ISMISIP;
                    dbIsRow.NonIP_Datagrams = isrow.ISNONIP;
                    dbIsRow.ARP_Inbound_Datagrams = isrow.ISARPIN;
                    dbIsRow.ARP_Outbound_Datagrams = isrow.ISARPOU;
                    dbIsRow.ICMP_Inbound_Datagrams = isrow.ISICMIN;
                    dbIsRow.ICMP_Outbound_Datagrams = isrow.ISICMOU;
                    dbIsRow.IP_Inbound_Datagrams = isrow.ISIPIN;
                    dbIsRow.IP_Outbound_Datagrams = isrow.ISIPOU;
                    dbIsRow.TCP_Inbound_Datagrams = isrow.ISTCPIN;
                    dbIsRow.TCP_Outbound_Datagrams = isrow.ISTCPOU;
                    dbIsRow.UDP_Inbound_Datagrams = isrow.ISUDPIN;
                    dbIsRow.UDP_Outbound_Datagrams = isrow.ISUDPOU;

                    dbIsRow.Misdirected_IP_Bytes = isrow.ISMISIPB;
                    dbIsRow.NonIP_Bytes = isrow.ISNONIPB;
                    dbIsRow.ARP_Inbound_Bytes = isrow.ISARPINB;
                    dbIsRow.ARP_Outbound_Bytes = isrow.ISARPOUB;
                    dbIsRow.ICMP_Inbound_Bytes = isrow.ISICMINB;
                    dbIsRow.ICMP_Outbound_Bytes = isrow.ISICMOUB;
                    dbIsRow.IP_Inbound_Bytes = isrow.ISIPINB;
                    dbIsRow.IP_Outbound_Bytes = isrow.ISIPOUB;
                    dbIsRow.TCP_Inbound_Bytes = isrow.ISTCPINB;
                    dbIsRow.TCP_Outbound_Bytes = isrow.ISTCPOUB;
                    dbIsRow.UDP_Inbound_Bytes = isrow.ISUDPINB;
                    dbIsRow.UDP_Outbound_Bytes = isrow.ISUDPOUB;

                    dbIsRow.Refused_Datagrams = isrow.ISREFIN;
                    dbIsRow.Refused_Bytes = isrow.ISREFINB;
                    #endregion
                    try
                    { vsedbData.ForeignIP_Stats.AddForeignIP_StatsRow(dbIsRow); }
                    catch (ConstraintException cExc)
                    { Debug.WriteLine(cExc.Message); }
                }
                //else { Debug.WriteLine("(ISBLOK01)No Ip Activity for " + isrow.ISIPADDR); }
            }
            #endregion
            /*try { vsedbData.EnforceConstraints = true; }//Now check for constraint violations
            catch (ConstraintException cExc)
            { Debug.WriteLine(cExc.ToString()); }*/
            return vsedbData;
        }
        #endregion
        #region Event Handlers
        private void manageComm1_OnError(CommErrorType type, string description)
        {
            //Notify anyone listening...
            int typeCode = (int)type;
            SendUdpBroadcast(new UdpMessage(typeCode, DateTime.Now, _name, description));
            //Take some silent action...
            if (type == CommErrorType.Port2 || type == CommErrorType.Port3 ||
                type == CommErrorType.Init || type == CommErrorType.Poll)
            {//Restart
                manageComm1.Disconnect();
                manageComm1.Startup(_defRow);
            }
            else if (type == CommErrorType.Login)
            {
                Service1.WriteAppLogWarning("Login FAIL", 9999);
                manageComm1.Disconnect(); 
            }

            /* Service does NOTHING
                 * Generic
                 * Port1
                 * Port1Disc
                 * Port2Disc
                 * Port3Disc                
                 * PollSkipped
                 * PollCommand
                 * TraceError
                 * TraceSkipped
                 * ConsoleComm
                */
        }
        /* Trace */
        private void manageComm1_OnTraceDataReceived(byte[] blok, long utcOffset)
        {
            Debug.WriteLine("\tOnTraceDataReceived: " + _name);            
            //Process...
            string tempFilePath = Service1.PcapPath + "seetemp.pcap";//PcapPath is set in the application settings
            ManageTrace mTrace = new ManageTrace();
            uint snaplen;//max length of captured packets, could be used to limit packet size in Pcap file
            mTrace.WriteFile(mTrace.ProcessPackets(blok, out snaplen, false), snaplen, Convert.ToInt32(utcOffset), tempFilePath);
            SendUdpBroadcast(new UdpMessage(140, DateTime.Now, _name, tempFilePath));//+ Filename 
        }
        /* Init */
        private void manageComm1_OnSeeVseStartupReceived(byte[] blok, long utcOffset)
        {
            Debug.WriteLine("\tOnSeeVseStartupReceived: " + _name);
            RecStartup record = new RecStartup(blok, utcOffset);
            dataArchiver1.CacheSeeVseStartupRecord(record);
            int recID = dataArchiver1.UpdateArchive(1);//SEEVSE_STARTUP_TYPE
            //SendUdpBroadcast(new UdpMessage(, record.StartTime, _name, recID.ToString()));//Send message with the ID of the new record
            
        }
        private void manageComm1_OnAllIpDataReceived(DataTable dtable)
        {
            Debug.WriteLine("\tOnAllIpDataReceived: " + _name);
            RawDataSet.ISBLOKDataTable rawTable = (RawDataSet.ISBLOKDataTable)dtable;
            if (rawTable.Rows.Count > 0)    //We got at least 1 row
            {   /* All rows in the IP_All table are stored with the session Startup Time */
                VseDbDataSet.ForeignIP_AllDataTable fTable = ConvertAllIpData(rawTable, manageComm1.SessionStart);
                fAdapter.Update(fTable);//Update the database                
            }
            //SendUdpBroadcast(new UdpMessage(, _sessionStart, _name, "DataIn-AllIps"));
        }
        /* Console */
        private void manageComm1_OnTcpIpMessageReceived(ArrayList list, long utcOffset)
        {
            //Debug.WriteLine("\tOnTcpIpMessageReceived: " + _name);
            for (int i = 0; i < list.Count; i++)
            { dataArchiver1.CacheTcpIpMessage(TcpIpMessage.GetTimeStamp((byte[])list[i]), TcpIpMessage.GetMessage((byte[])list[i])); }
            if (list.Count > 0)
            {
                int lastID = dataArchiver1.UpdateArchive(3);//TCPIP_MESSAGE_TYPE
                string messInfo = "Messages-" + lastID.ToString() + "-" + list.Count.ToString();//last ID and the number of lines in the message
                SendUdpBroadcast(new UdpMessage(120, DateTime.Now, _name, messInfo));//Send UDP 
            }
        }
        private void manageComm1_OnCommandNotSent(string reason, DateTime time)
        { SendUdpBroadcast(new UdpMessage(121, time, _name, reason)); }
        private void manageComm1_OnCommandSent(string command, DateTime time)
        {
            Debug.WriteLine("\tOnCommandSent: " + command);
            string cmdArchive = "> " + command;
            dataArchiver1.CacheCommandSent(time, cmdArchive);//This sentAt time is the pc local time and basically useless
            dataArchiver1.UpdateArchive(3);//TCPIP_MESSAGE_TYPE            
        }        
        private void manageComm1_OnCommandProcessed(byte[] blok, long utcOffset)
        {
            //Debug.WriteLine("\tOnCommandProcessed: " + _name);
            RawDataConverter converter = new RawDataConverter();
            ushort length = (ushort)(converter.GetUINT16(0, blok) - 4);
            string response = converter.GetEBCDIC(4, blok, (int)length);
            if (response.StartsWith("FAIL"))
            {//Store it like a message                
                DateTime timestamp = DateTime.UtcNow.AddSeconds(Convert.ToDouble(utcOffset));//timestamp reflects pc time
                string description = "IPN349E Command Failed.";//Default generic message
                if (length > 0){ description = converter.GetEBCDIC(8, blok, blok.Length - 8); }
                string tcpipMess = timestamp.ToString("yyyyMMdd hhmmss.ff") + " " + description;
                dataArchiver1.CacheTcpIpMessage(timestamp, tcpipMess);
                int lastID = dataArchiver1.UpdateArchive(3);//TCPIP_MESSAGE_TYPE
                string messInfo = "Messages-" + lastID.ToString() + "-1";//last ID and the number of lines in the message
                SendUdpBroadcast(new UdpMessage(120, DateTime.Now, _name, messInfo));//Send UDP
            }
            SendUdpBroadcast(new UdpMessage(122, DateTime.Now, _name, response));                        
        }
        /* Polling */
        private void manageComm1_OnPollDataReceived(DataSet dset, DateTime dt, string BsdcPID)
        {
            //Debug.WriteLine("\tOnPollDataReceived: " + _name);
            RawDataSet pollData = (RawDataSet)dset;
            VseDbDataSet vseData = ConvertPollData(pollData, dt, BsdcPID);
            #region Update the database
            adapter1.Update(vseData.Connection_BSDC);
            adapter2.Update(vseData.Connection_Stats);
            adapter3.Update(vseData.CPU_Stats);
            adapter4.Update(vseData.ForeignIP_Stats);
            adapter5.Update(vseData.Link_Adapter);
            adapter6.Update(vseData.Partition_Job_Step);
            adapter7.Update(vseData.SeeServer_Summary);
            adapter8.Update(vseData.TCPIP_Clients);
            adapter9.Update(vseData.TCPIP_Daemons);
            adapter10.Update(vseData.TCPIP_Dispatcher);
            adapter11.Update(vseData.TCPIP_Errors);
            adapter12.Update(vseData.TCPIP_Other);
            adapter13.Update(vseData.TCPIP_Summary);
            adapter14.Update(vseData.TCPIP_Traffic);
            adapter15.Update(vseData.VSE_Stats);
            adapter16.Update(vseData.VSE_Summary);
            #endregion
            SendUdpBroadcast(new UdpMessage(130, dt, _name, "DataIn-Poll"));             
        }
        private void manageComm1_OnTcpIpTerminationReceived(ArrayList list, long utcOffset)
        {
            //Debug.WriteLine("\tOnTcpipTerminationReceived: " + _name);
            for (int i = 0; i < list.Count; i++)
            { dataArchiver1.CacheTcpIpTerminationRecord(new RecConnection((byte[])list[i], utcOffset)); }
            if(list.Count > 0)
            {
                int lastID = dataArchiver1.UpdateArchive(4);//CONNECTION_TYPE
                string messInfo = "ConnectRecs-" + lastID.ToString() + "-" + list.Count.ToString();//last ID and the number of records
                SendUdpBroadcast(new UdpMessage(131, DateTime.Now, _name, messInfo));
            }
        }
        private void manageComm1_OnFtpTerminationReceived(ArrayList list, long utcOffset)
        {
            //Debug.WriteLine("\tOnFtpTerminationReceived: " + _name);
            for (int i = 0; i < list.Count; i++)
            { dataArchiver1.CacheFtpTerminationRecord(new RecFtp((byte[])list[i], utcOffset)); }
            if(list.Count > 0)
            {
                int lastID = dataArchiver1.UpdateArchive(2);//FTP_TERMINATION_TYPE
                string messInfo = "FtpRecs-" + lastID.ToString() + "-" + list.Count.ToString();//last ID and the number of records
                SendUdpBroadcast(new UdpMessage(132, DateTime.Now, _name, messInfo));
            }
        }
        private void manageComm1_OnJobStepTerminationReceived(ArrayList list, long utcOffset)
        {
            //Debug.WriteLine("\tOnJobStepTerminationReceived: " + _name);
            for (int i = 0; i < list.Count; i++)
            { dataArchiver1.CacheJobStepTerminationRecord(new RecJobStep((byte[])list[i])); }
            if(list.Count > 0)
            {
                int lastID = dataArchiver1.UpdateArchive(5);//JOB_STEP_TERMINATION_TYPE
                string messInfo = "JobStepRecs-" + lastID.ToString() + "-" + list.Count.ToString();//last ID and the number of records
                SendUdpBroadcast(new UdpMessage(133, DateTime.Now, _name, messInfo));
            }
        }                       
        //Status
        private void manageComm1_OnConsoleStatusChanged(StatusEventArgs statusEvent)
        {
            //Debug.WriteLine("\tOnConsoleStatusChanged...\t" + statusEvent.Message + ": " + _name);            
            if (statusEvent.Code == 102)//Ignore Disconnect(100) and Ready(110) messages
            { SendUdpBroadcast(new UdpMessage(statusEvent.Code, DateTime.Now, _name, statusEvent.Message)); }
        }
        private void manageComm1_OnPollStatusChanged(StatusEventArgs statusEvent)
        {
            //Debug.WriteLine("\tOnPollStatusChanged...\t" + statusEvent.Message + ": " + _name);
            /*switch (statusEvent.Code)
            {
                case 100://Disconnected                    
                    break;
                case 110://Ready
                    break;
                default:
                    break;
            }*/
            SendUdpBroadcast(new UdpMessage(statusEvent.Code, DateTime.Now, _name, statusEvent.Message));
        }
        
        #endregion
                     
    }

    public class ManageSystemsCollection : CollectionBase
    {
        public int Add(ManageSystem item) { return List.Add(item); }
        public void Insert(int index, ManageSystem item) { List.Insert(index, item); }
        public void Remove(ManageSystem item) { List.Remove(item); }
        public bool Contains(ManageSystem item) { return List.Contains(item); }
        public int IndexOf(ManageSystem item) { return List.IndexOf(item); }
        public void CopyTo(ManageSystem[] array, int index) { List.CopyTo(array, index); }

        public ManageSystem this[int index]
        {
            get { return (ManageSystem)List[index]; }
            set { List[index] = value; }
        }

        public ManageSystem GetByName(string name)
        {
            foreach (ManageSystem item in List)
            { if (item.Name == name) return item; }
            return null;//The name supplied does not exist
        }
        public void Remove(string name) 
        {
            ManageSystem item = GetByName(name);
            List.Remove(item); 
        }
        public bool Contains(string name) 
        {
            ManageSystem item = GetByName(name);
            return List.Contains(item); 
        }
        public int IndexOf(string name) 
        {
            ManageSystem item = GetByName(name);
            return List.IndexOf(item); 
        }
    }

}
