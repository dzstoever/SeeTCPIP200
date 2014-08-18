using csi.see.classlib1;
using csi.see.classlib1.DataSets;
using csi.see.classlib1.DataSets.VseDbDataSetTableAdapters;
using csi.see.classlib1.DataSets.SeeCommonDataSetTableAdapters;
using ConsoleRecords;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace csi.see.client1
{
    public delegate void TraceDelegate(bool enabled, string description);

    public partial class ControlVseSystem : UserControl
    {
        private ControlConsole ctlConsole = new ControlConsole();//Dynamically added control
        private SqlManagerSystem _sqlMan = new SqlManagerSystem();
        private VseDbDataSet _vseDataSet = new VseDbDataSet();//This is for 'real-time' data
        private DateTime _sessionStart;
        public SqlManagerSystem SqlManager
        { get { return _sqlMan; } }
        public DateTime SessionStart
        { get { return _sessionStart; } }

        private event DateTimeDelegate PollDataRcvd;
        private event TraceDelegate TraceStatusChanged;
        public event UdpDelegate SendUdpBroadcast;
                        
        public ControlVseSystem()
        {
            InitializeComponent();
            //dockAnalyzers.Collapsed = true;
            ctlConsole.Dispatcher = new ConsoleDispatcher();
            ctlConsole.Name = "ctlConsole";
            ctlConsole.Dock = DockStyle.Fill;
            ctlConsole.SendTcpipCommand += new StringDelegate(ctlConsole_SendTcpipCommand);
            panelConsole.Controls.Add(ctlConsole);                        
            #region Set Summary Bindings
            see1.DataBindings.Add("Text", _vseDataSet.SeeServer_Summary,
                "PID");
            see2.DataBindings.Add("Text", _vseDataSet.SeeServer_Summary,
                "Job_Name");
            see3.DataBindings.Add("Text", _vseDataSet.SeeServer_Summary,
                "SeeServer_Start_Time");
            //see4 - SessionStartTime - update in OnAllIpDataRcvd
            time1.DataBindings.Add("Text", _vseDataSet.VSE_Summary,
               "Last_IPL_Time");
            time2.DataBindings.Add("Text", _vseDataSet.VSE_Summary,
                "Last_CpuReset_Time");           
            time3.DataBindings.Add("Text", _vseDataSet.TCPIP_Summary,
                "TCPIP_Start_Time");
            tcp1.DataBindings.Add("Text", _vseDataSet.TCPIP_Summary,
                "PID");
            tcp2.DataBindings.Add("Text", _vseDataSet.TCPIP_Summary,
                "Job_Name");
            tcp3.DataBindings.Add("Text", _vseDataSet.TCPIP_Summary,
                "IP_Address");            
            tcp4.DataBindings.Add("Text", _vseDataSet.TCPIP_Summary,
                "Release");
            tcp5.DataBindings.Add("Text", _vseDataSet.TCPIP_Summary,
                "License");
            tcp6.DataBindings.Add("Text", _vseDataSet.TCPIP_Summary,
                "Sys_ID");
            tcp7.DataBindings.Add("Text", _vseDataSet.TCPIP_Summary,
                "Nof_TCPIP_PseudoTasks");
            tcp8.DataBindings.Add("Text", _vseDataSet.TCPIP_Summary,
                "Nof_TCPIP_Connections");
            vse1.DataBindings.Add("Text", _vseDataSet.VSE_Summary,
                "Release");
            vse2.DataBindings.Add("Text", _vseDataSet.VSE_Summary,
                "Power_Node");
            vse3.DataBindings.Add("Text", _vseDataSet.VSE_Summary,
                "Power_Sys_ID");
            vse4.DataBindings.Add("Text", _vseDataSet.VSE_Summary,
                "Nof_Allocated_Partitions");
            //vse5 - ActivePartitions - update in OnPollDataRcvd
            vse6.DataBindings.Add("Text", _vseDataSet.VSE_Summary,
                "Nof_Cpus");
            vse7.DataBindings.Add("Text", _vseDataSet.VSE_Summary,
                "Nof_Active_Cpus");
            vse8.DataBindings.Add("Text", _vseDataSet.VSE_Summary,
                "Nof_Quiesced_Cpus");
            vse9.DataBindings.Add("Text", _vseDataSet.VSE_Summary,
                "Nof_TCPIP_Stacks");
            vse10.DataBindings.Add("Text", _vseDataSet.VSE_Summary,
                "Nof_Active_Tasks");            
            cpu1.DataBindings.Add("Text", _vseDataSet.VSE_Summary,
                "Cpu_ID");                                    
            #endregion
            infoUpdated.DataBindings.Add("Text", _vseDataSet.VSE_Summary,
                "Poll_Time");            
            TraceStatusChanged += new TraceDelegate(OnTraceStatusChanged);
            PollDataRcvd +=new DateTimeDelegate(UpdatePollMonitors);

        }
        public void Setup(string name)
        {
            string dbName = name.Replace(' ', '_');
            ctlConsole.Setup(dbName);
            _sqlMan.SetDb(dbName);

            btnConnect.ToolTipText = "This will manually try to initiate a connection and log on the server." + Environment.NewLine +
                "(The PC will automatically try to log on to the VSE every five minutes if it is disconnected"+
                " and 'Turned On' in the 'Systems Manager'.)";            
            
            showSummary.ToolTipText = "This will show/hide the 'System Summary' information.";
            
            showConsoleServer.ToolTipText = "This will display information about each session that is started"+
                " with the VSE server. A successful log on equates to the start of a sesson."+ Environment.NewLine +
                "(As long as the Windows service is running on this PC and the server is up"+
                " on the mainframe you will remain logged on and data will be collected.)";
            
            //showConsoleJobSteps.ToolTipText = "";
            //showConsoleFTP.ToolTipText = "";
            //showConsoleConnections.ToolTipText = "";
            btnNewAnalyzer.ToolTipText = "";
            btnCapture.ToolTipText = "";
            
            
        }

        public void OnCommError(CommErrorType type, string message)
        { 
            switch (type)
            {
                case CommErrorType.Port1:
                    OnDisconnected(message);
                    break;
                case CommErrorType.Login:
                    OnDisconnected(message);
                    MessageBox.Show(message, this.Name);
                    break;
               
                case CommErrorType.TraceError:
                    TraceStatusChanged(true, message);
                    break;
                case CommErrorType.TraceSkipped:
                    TraceStatusChanged(true, message);
                    break;
                default:
                    statMessage.Text = message+" ("+type+")";
                    break;
            }
             
        }                
        public void OnStatus(string description)
        { statMessage.Text = description; }
        public void OnOpenOff()
        {
            Parent.BackColor = Color.Gray;
            Parent.Parent.Refresh();//redraw the tabcontrol with new BackColor
            btnConnect.Visible = false;
            statConnected.Text = "Turned Off";
            statMessage.Text = "Use the 'Systems Manager' to turn on the monitor.";
            //tabReal.Controls.Remove(ctlReal);
            //tabControl1.TabPages.Remove(tabReal);
            //tabControl1.TabPages.Remove(tabConsole);
            
        }
        public void OnInitializing(string status)
        {
            Parent.BackColor = Color.Yellow;
            Parent.Parent.Refresh();//redraw the tabcontrol with new BackColor
            btnConnect.Visible = false;
            statConnected.Text = "Initializing...";
            statMessage.Text = status; 
        }
        public void OnConnected()
        {
            Parent.BackColor = Color.FromArgb(0, 0, 192);
            Parent.Parent.Refresh();//redraw the tabcontrol with new BackColor
            btnConnect.Visible = false;            
            statConnected.Text = "Connected";
            statMessage.Text = "Ready";
            ctlConsole.OnConnected();
            
            string serverVersion;
            DateTime sessionStartTime = LoadSessionStartup(out serverVersion);
            if (serverVersion == "01.05 F ")
            { TraceStatusChanged(true, ""); }
            else{ TraceStatusChanged(false, ""); }            
            OnAllIpDataRcvd(sessionStartTime);
        }
        private DateTime LoadSessionStartup(out string version)
        {
            version = "";
            DateTime startTime = DateTime.Now;

            ManStartupRecs man = new ManStartupRecs();
            man.SetDbName(Name.Replace(' ', '_'));
            int recordID = man.GetLastId();
            ConsoleDataSet.Startup_RecordsDataTable table = man.GetIdRange(recordID, recordID);
            if (table.Rows.Count == 1)
            {
                ConsoleDataSet.Startup_RecordsRow row = (ConsoleDataSet.Startup_RecordsRow)table.Rows[0];
                version = row.Program_Version;
                startTime = row.Start_Time;                
            }
            return startTime;
        }                
        public void OnDisconnected(string reason)
        {
            Parent.BackColor = Color.Maroon;
            Parent.Parent.Refresh();//redraw the tabcontrol with new BackColor
            btnConnect.Visible = true;
            statConnected.Text = "Disconnected";
            statMessage.Text = reason;

            ctlConsole.OnDisconnected();
            TraceStatusChanged(false, "");
        }
        public void OnTraceStatusChanged(bool enabled, string description)
        {
            btnCapture.Enabled = enabled;
            statTrace.Text = description;
        }
        public void OnTraceDataRcvd(DateTime time, string message)
        {
            statTrace.Text = "Trace data received.";
            SavePcapFile(message, time);
            TraceStatusChanged(true, "");
        }
        private void SavePcapFile(string tempFile, DateTime timestamp)
        {
            
            //saveFileDialog1.InitialDirectory = //Form1.PcapPath;//Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);           
            saveFileDialog1.FileName = timestamp.ToString("yyyy_MM_dd.HH_mm_ss.pcap");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selFilePath = saveFileDialog1.FileName;
                if (File.Exists(selFilePath)) { File.Delete(selFilePath); }
                File.Move(tempFile, selFilePath);
                try
                {//Try to start Wireshark or other .pcap application
                    Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = selFilePath;
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                }
                catch (System.ComponentModel.Win32Exception wExc)
                { MessageBox.Show(wExc.Message, "Could not display the trace"); }            
            }
            else { File.Delete(tempFile); }

            
        }        
        public void OnMessageRcvd(int lastID, int count)
        { ctlConsole.OnMessageRcvd(lastID, count); }        
        public void OnCommandNotSent(DateTime time, string message)
        {
            statMessage.Text = "";
            ctlConsole.OnCommandNotSent(time, message); 
        }
        public void OnCommandProcRcvd(DateTime time, string message)
        {
            statMessage.Text = "";
            ctlConsole.OnCommandProcRcvd(time, message); 
        }
        
        private void showSummary_Click(object sender, EventArgs e)
        {
            if (showSummary.Text == "Hide Summary")
            {
                showSummary.Image = imageList1.Images[5];//plus sign
                showSummary.Text = "Show Summary";
                panelTop.Visible = false;
            }
            else
            {
                showSummary.Image = imageList1.Images[4];//minus sign
                showSummary.Text = "Hide Summary";
                panelTop.Visible = true;
            }
        }
        private void ctlConsole_SendTcpipCommand(string cmdTxt)
        { SendUdpBroadcast(new UdpMessage(301, DateTime.Now, Name, cmdTxt)); }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            OnInitializing("Waiting for server to respond...");
            SendUdpBroadcast(new UdpMessage(300, DateTime.Now, Name, "Try Connect"));
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            OnTraceStatusChanged(false, "Reading packets...");
            SendUdpBroadcast(new UdpMessage(302, DateTime.Now, Name, "TRACIP01"));
        }
                        
        private Form GetConsoleForm(string title)
        {
            Form frmConsole = new Form();
            frmConsole.Text = Name + " - " + title;
            frmConsole.Icon = ParentForm.Icon;
            frmConsole.Size = new Size(800, 400);
            frmConsole.StartPosition = FormStartPosition.CenterScreen;
            frmConsole.FormBorderStyle = FormBorderStyle.Sizable;

            return frmConsole;
        }        
        SeeVseStartupConsole ConsoleServer = null;
        private void showConsoleServer_Click(object sender, EventArgs e)
        {
            ToolStripButton toolButton = (ToolStripButton)sender;
            if (ConsoleServer != null)//Show Console
            { ConsoleServer.ParentForm.Activate(); }
            else
            {//Create Console
                ConsoleServer = new SeeVseStartupConsole();
                ConsoleServer.Archive = SqlManager.DatabaseName;
                ConsoleServer.Dispatcher = new ConsoleDispatcher();//this is never even used...
                ConsoleServer.Dock = DockStyle.Fill;

                Form form = GetConsoleForm("Server Sessions");
                form.Controls.Add(ConsoleServer);
                form.FormClosing += new FormClosingEventHandler(frmConsoleServer_FormClosing);
                form.Show();

                toolButton.Image = imageList1.Images[7];//monitor icon
                toolButton.CheckState = CheckState.Checked;//Orange
            }
        }
        private void frmConsoleServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConsoleServer.Dispose();
            ConsoleServer = null;
            showConsoleServer.Image = imageList1.Images[6];//blue plus sign 
            showConsoleServer.CheckState = CheckState.Unchecked;//Control
        }
        JobStepTerminationConsole ConsoleJobSteps = null;
        private void showConsoleJobSteps_Click(object sender, EventArgs e)
        {
            ToolStripButton toolButton = (ToolStripButton)sender;
            if (ConsoleJobSteps != null)//Show Console
            { ConsoleJobSteps.ParentForm.Activate(); }
            else
            {//Create Console
                ConsoleJobSteps = new JobStepTerminationConsole();
                ConsoleJobSteps.Archive = SqlManager.DatabaseName;
                ConsoleJobSteps.Dispatcher = new ConsoleDispatcher();//this is never even used...
                ConsoleJobSteps.Dock = DockStyle.Fill;

                Form form = GetConsoleForm("End of Job Step Records");
                form.Controls.Add(ConsoleJobSteps);
                form.FormClosing += new FormClosingEventHandler(frmConsoleJobSteps_FormClosing);
                form.Show();

                toolButton.Image = imageList1.Images[7];//monitor icon
                toolButton.CheckState = CheckState.Checked;//Orange
            }
        }
        private void frmConsoleJobSteps_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConsoleJobSteps.Dispose();
            ConsoleJobSteps = null;
            showConsoleJobSteps.Image = imageList1.Images[6];//blue plus sign 
            showConsoleJobSteps.CheckState = CheckState.Unchecked;//Control
        }
        public void OnJobStepRecRcvd(int lastID, int count)
        {
            if (ConsoleJobSteps != null)
            {
                foreach (ConsoleDataSet.JobStep_RecordsRow row in
                    ConsoleJobSteps.Manager.GetIdRange(lastID - count + 1, lastID).Rows)
                {
                    ConsoleJobSteps.OnRecordReceived( new JobStepTerminationRecord
                        (row.Step_Name, 
                        row.Job_Name,
                        Convert.ToSingle(row.Duration_Sec),
                        Convert.ToSingle(row.Cpu_Time_Sec),
                        Convert.ToUInt64(row.Total_IO),
                        row.Step_Start_Time,
                        row.Step_End_Time,
                        row.PID
                        )
                    );                        
                }
            }
        }
        FtpTerminationConsole ConsoleFTP = null;
        private void showConsoleFTP_Click(object sender, EventArgs e)
        {
            ToolStripButton toolButton = (ToolStripButton)sender;
            if (ConsoleFTP != null)//Show Console
            { ConsoleFTP.ParentForm.Activate(); }
            else
            {//Create Console
                ConsoleFTP = new FtpTerminationConsole();
                ConsoleFTP.Archive = SqlManager.DatabaseName;
                ConsoleFTP.Dispatcher = new ConsoleDispatcher();//this is never even used...
                ConsoleFTP.Dock = DockStyle.Fill;

                Form form = GetConsoleForm("End of Ftp Sessions");                
                form.Controls.Add(ConsoleFTP);
                form.FormClosing += new FormClosingEventHandler(frmConsoleFTP_FormClosing);
                form.Show();

                toolButton.Image = imageList1.Images[7];//monitor icon
                toolButton.CheckState = CheckState.Checked;//Orange
            }
        }        
        private void frmConsoleFTP_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConsoleFTP.Dispose();
            ConsoleFTP = null;
            showConsoleFTP.Image = imageList1.Images[6];//blue plus sign 
            showConsoleFTP.CheckState = CheckState.Unchecked;//Control
        }
        public void OnFtpRecRcvd(int lastID, int count)
        {
            if (ConsoleFTP != null)
            {
                foreach (ConsoleDataSet.FTP_RecordsRow row in
                    ConsoleFTP.Manager.GetIdRange(lastID - count + 1, lastID).Rows)
                {
                    ConsoleFTP.OnRecordReceived(
                        new FtpTerminationRecord(
                        Convert.ToUInt16(row.Vse_Task_ID),
                        row.FTP_Node_Name,
                        row.General_Flag,
                        row.SSL_Flag,
                        row.FTP_User_ID,
                        Convert.ToUInt16(row.Files_Sent),
                        Convert.ToUInt16(row.Files_Received),
                        Convert.ToUInt16(row.Bytes_SentAcked),
                        Convert.ToUInt16(row.Bytes_Received),
                        row.Vse_IP,
                        Convert.ToUInt16(row.Vse_Port),
                        row.Client_IP,
                        Convert.ToUInt16(row.Client_Port),
                        row.Foreign_Data_IP,
                        row.Start_Time,
                        row.End_Time));
                }
            }
        }        
        TcpIpTerminationConsole ConsoleConnections = null;
        private void showConsoleConnections_Click(object sender, EventArgs e)
        {
            ToolStripButton toolButton = (ToolStripButton)sender;
            if (ConsoleConnections != null)//Show Console
            { ConsoleConnections.ParentForm.Activate(); }
            else
            {//Create Console
                ConsoleConnections = new TcpIpTerminationConsole();
                ConsoleConnections.Archive = SqlManager.DatabaseName;
                ConsoleConnections.Dispatcher = new ConsoleDispatcher();//this is never even used...
                ConsoleConnections.Dock = DockStyle.Fill;

                Form form = GetConsoleForm("End of Connection Records");
                form.Controls.Add(ConsoleConnections);
                form.FormClosing += new FormClosingEventHandler(frmConsoleConnections_FormClosing);
                form.Show();

                toolButton.Image = imageList1.Images[7];//monitor icon
                toolButton.CheckState = CheckState.Checked;//Orange
            }
        }        
        private void frmConsoleConnections_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConsoleConnections.Dispose();
            ConsoleConnections = null;
            showConsoleConnections.Image = imageList1.Images[6];//blue plus sign 
            showConsoleConnections.CheckState = CheckState.Unchecked;//Control
        }
        public void OnConnectRecRcvd(int lastID, int count)
        {
            byte byte0 = new byte();
            if (ConsoleConnections != null)
            {
                foreach (ConsoleDataSet.Connection_RecordsRow row in
                    ConsoleConnections.Manager.GetIdRange(lastID - count + 1, lastID).Rows)
                {
                    ConsoleConnections.OnRecordReceived( new TcpIpTerminationRecord
                        (
                        byte0, /* row.Conn_State = byte?*/
                        byte0, /* row.Conn_Protocol = byte?*/
                        row.Conn_Start_Time,
                        Convert.ToUInt16(row.Local_Port),
                        Convert.ToUInt16(row.Foreign_Port),
                        row.Foreign_IP,
                        byte0, /* flagAA */
                        byte0, /* localCall  = invalid in 15F*/
                        Convert.ToUInt64(row.Retransmits), 
                        Convert.ToUInt64(row.Inbound_Data), 
                        Convert.ToUInt64(row.Inbound_Data_Dup),
                        Convert.ToUInt64(row.Inbound_Bytes),
                        Convert.ToUInt64(row.Inbound_Bytes_Dup),
                        Convert.ToUInt64(row.Outbound_Data),
                        Convert.ToUInt64(row.Outbound_Data_Retr),
                        Convert.ToUInt64(row.Outbound_Bytes),
                        Convert.ToUInt64(row.Outbound_Bytes_Retr),
                        Convert.ToUInt64(row.SWS_Count),
                        Convert.ToUInt64(row.In_Retr_Mode),
                        Convert.ToUInt64(row.Recv_Window_Closed),
                        Convert.ToUInt64(row.Highest_Depth),
                        Convert.ToUInt64(row.Sends_Issued),
                        Convert.ToUInt64(row.Recvs_Issued),
                        Convert.ToUInt32(row.Max_Send_Window),
                        Convert.ToUInt32(row.Max_Recv_Window),
                        row.Conn_End_Time,
                        row.Conn_PID,
                        0 /* pik */
                        )
                    );                        
                }
            }
        }

        ArrayList ActivePollMonitors = new ArrayList();//Keep a list of open analyzers
        private void btnNewAnalyzer_Click(object sender, EventArgs e)
        {
            DialogNewAnalyzer dlgNew = new DialogNewAnalyzer();
            if (dlgNew.ShowDialog() == DialogResult.OK)
            {
                bool realTime = false;
                DateTime[] times;
                #region Get the 10 most recent times or the selected historical times
                if (dlgNew.IsHistorical)
                { times = SqlManager.GetPollTimes(dlgNew.StartTime, dlgNew.EndTime); }
                else //Display recent activity
                { times = SqlManager.GetLast10PollTimes(SessionStart); realTime = true; }
                #endregion
                if (times.Length < 1 && dlgNew.IsHistorical)
                { MessageBox.Show("There is no data in the selected time range.", "SeeTCP/IP Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    ArrayList selAnalyzers = dlgNew.GetSelectedAnalyzers();
                    if (selAnalyzers.Count < 1)
                    { MessageBox.Show("You did not select an analyzer.", "SeeTCP/IP Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else
                    {
                        foreach (PrebuiltAnalyzers analType in selAnalyzers)
                        {//Create form to house the analyzer and open it
                            Form frmAnal = new Form();
                            #region Setup frmAnal
                            frmAnal.Text = Name + " - ";
                            frmAnal.Icon = ParentForm.Icon;
                            frmAnal.Size = new Size(600, 600);
                            frmAnal.FormBorderStyle = FormBorderStyle.Sizable;
                            #endregion
                            BaseAnal analyzer = null;
                            switch (analType)
                            {
                                #region Set frmAnal.Text and create proper analyzer control
                                case PrebuiltAnalyzers.VSE:
                                    frmAnal.Text += "VSE Activity";
                                    analyzer = new AnalVSE(Name, SqlManager.ConnectionString, realTime);
                                    break;
                                case PrebuiltAnalyzers.CPU:
                                    frmAnal.Text += "CPU Utilization";
                                    analyzer = new AnalCPU(Name, SqlManager.ConnectionString, realTime);
                                    break;
                                case PrebuiltAnalyzers.TD:
                                    frmAnal.Text += "Turbo Dispatcher";
                                    analyzer = new AnalTD(Name, SqlManager.ConnectionString, realTime);
                                    break;
                                case PrebuiltAnalyzers.SIOs:
                                    frmAnal.Text += "SIO Counts";
                                    analyzer = new AnalSIO(Name, SqlManager.ConnectionString, realTime);
                                    break;
                                case PrebuiltAnalyzers.TCPIP:
                                    frmAnal.Text += "TCP/IP Stack";
                                    analyzer = new AnalTCPIP(Name, SqlManager.ConnectionString, realTime);
                                    break;
                                case PrebuiltAnalyzers.InOut:
                                    frmAnal.Text += "TCP/IP Traffic";
                                    analyzer = new AnalInOut(Name, SqlManager.ConnectionString, realTime);
                                    break;
                                case PrebuiltAnalyzers.ForgnIps:
                                    frmAnal.Text += "TCP/IP Foreign IPs";
                                    analyzer = new AnalForgnIps(Name, SqlManager.DatabaseName, realTime);
                                    break;
                                case PrebuiltAnalyzers.Conns:
                                    frmAnal.Text += "TCP/IP Connections";
                                    analyzer = new AnalConns(Name, SqlManager.DatabaseName, realTime);
                                    break;
                                //case PrebuiltAnalyzers.BSDC:
                                    //frmAnal.Text += "BSDC Connections";
                                    //break;
                                //case PrebuiltAnalyzers.FTPs:
                                    //break;

                                #endregion
                            }
                            if (analyzer != null)
                            {
                                #region
                                Array.Sort(times);//Sort times in ascending order  
                                if (analType == PrebuiltAnalyzers.ForgnIps)
                                {
                                    if (times.Length > 0)
                                    {
                                        AnalForgnIps fIPanalyzer = (AnalForgnIps)analyzer;
                                        fIPanalyzer.SetTimeRange(times[0], times[times.Length - 1]);
                                    }
                                }
                                else if (analType == PrebuiltAnalyzers.Conns)
                                {
                                    if (times.Length > 0)
                                    {
                                        AnalConns cAnalyzer = (AnalConns)analyzer;
                                        cAnalyzer.SetTimeRange(times[0], times[times.Length - 1], times);
                                        /*
                                        if (dlgNew.IsHistorical)
                                        { cAnalyzer.SetTimeRange(times[0], times[times.Length - 1], times); }
                                        else { cAnalyzer.SetTimeRange(times[times.Length - 1], times[times.Length - 1], times); }
                                        */
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < times.Length; i++)
                                    { UpdateAnalyzer(times[i], analyzer); }
                                    analyzer.InvokeCrossTabUpdate(); /*Need for PJS - call every time - just in case */
                                }
                                
                                analyzer.Dock = DockStyle.Fill;
                                frmAnal.Controls.Add(analyzer);
                                if (!dlgNew.IsHistorical)
                                {
                                    ActivePollMonitors.Add(frmAnal);//Add only objects that derive from BaseAnal                
                                    frmAnal.FormClosing += new FormClosingEventHandler(analyzer_FormClosing);
                                }
                                frmAnal.Show();
                                #endregion
                            }
                            else
                            { frmAnal.Dispose(); }
                        }
                    }
                } 

            }

        }        
        
        public void OnAllIpDataRcvd(DateTime startTime)
        {
            //This event will always happen when the system opens
            //The time will be equal to the last session start time
            _sessionStart = startTime;
            see4.Text = startTime.ToString();
            showConsoleServer.Enabled = true;
            showConsoleJobSteps.Enabled = true;
            showConsoleFTP.Enabled = true;
            showConsoleConnections.Enabled = true;
            btnNewAnalyzer.Enabled = true;
            btnCapture.Enabled = true;
            //int ipCnt = _sqlMan.Fill_AllIps(_vseDataSet, startTime, true);
            //Console.WriteLine("All IP Count = " + ipCnt.ToString());
        }
        public void OnPollDataRcvd(DateTime pollTime)
        {
            int summCnt = _sqlMan.Fill_Poll(_vseDataSet, pollTime, true);//summCnt should be 1\
            int actStepCnt = _vseDataSet.Partition_Job_Step.Rows.Count;
            vse5.Text = actStepCnt.ToString();//Update summary information
            PollDataRcvd(pollTime);
        }
        private void UpdatePollMonitors(DateTime dt)
        {
            foreach (object o in ActivePollMonitors)
            {
                Form frmMon = (Form)o;
                foreach (UserControl control in frmMon.Controls)
                {
                    if (control.GetType().IsSubclassOf(Type.GetType("csi.see.client1.BaseAnal")))
                    {
                        BaseAnal analyzer = (BaseAnal)control;
                        analyzer.AddData(dt);
                    }
                    //else if (control.GetType().IsSubclassOf(Type.GetType("ConsoleRecords.PageableConsole")))
                    //{}                    
                }
            }

        }
        private void UpdateAnalyzer(DateTime dt, BaseAnal analyzer)
        { analyzer.AddData(dt); }
        /// <summary>
        /// Remove from active monitor list 
        /// </summary>
        void analyzer_FormClosing(object sender, FormClosingEventArgs e)
        { ActivePollMonitors.Remove(sender); }
    }

    public class VseSystemsCollection : CollectionBase
    {
        public int Add(ControlVseSystem item) { return List.Add(item); }
        public void Insert(int index, ControlVseSystem item) { List.Insert(index, item); }
        public void Remove(ControlVseSystem item) { List.Remove(item); }
        public bool Contains(ControlVseSystem item) { return List.Contains(item); }
        public int IndexOf(ControlVseSystem item) { return List.IndexOf(item); }
        public void CopyTo(ControlVseSystem[] array, int index) { List.CopyTo(array, index); }

        public ControlVseSystem this[int index]
        {
            get { return (ControlVseSystem)List[index]; }
            set { List[index] = value; }
        }

        public ControlVseSystem GetByName(string name)
        {
            foreach (ControlVseSystem item in List)
            { if (item.Name == name) return item; }
            return null;//The name supplied does not exist
        }
        public void Remove(string name)
        {
            ControlVseSystem item = GetByName(name);
            List.Remove(item);
        }
        public bool Contains(string name)
        {
            ControlVseSystem item = GetByName(name);
            return List.Contains(item);
        }
        public int IndexOf(string name)
        {
            ControlVseSystem item = GetByName(name);
            return List.IndexOf(item);
        }
    }
}
