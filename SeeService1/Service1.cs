using csi.see.classlib1;
using csi.see.classlib1.DataSets;
using csi.see.classlib1.DataSets.SeeCommonDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace csi.see.service1
{
    public partial class Service1 : ServiceBase
    {
        public static string PcapPath;
        public static string DatabasePath;
        public static void WriteAppLogInfo(string text, int eventID)
        { EventLog.WriteEntry("SeeService1", text, EventLogEntryType.Information, eventID); }
        public static void WriteAppLogWarning(string text, int eventID)
        { EventLog.WriteEntry("SeeService1", text, EventLogEntryType.Warning, eventID); }
        public static void WriteAppLogError(string text, int eventID)
        { EventLog.WriteEntry("SeeService1", text, EventLogEntryType.Error, eventID); }
        
        private int _clientCnt = 0;//Keep track of the number of SeeClients running
        private bool _broadcast = false;//Don't broadcast unless there is a client running
        private UdpBroadcaster UdpBroadcast1 = new UdpBroadcaster();
        private void SendUdpBroadcast(UdpMessage message)
        {
            Service1.WriteAppLogInfo("Service1->> " + UdpMessage.Convert(message), message.Type);
            if (_broadcast) 
            {
                Debug.WriteLine(message.Type.ToString() + ": " + message.Info);
                UdpBroadcast1.Send(message); 
            }
        }
        private void UdpBroadcast1_MessageRcvd(UdpMessage message)
        {
            Service1.WriteAppLogInfo("Service1<<- " + UdpMessage.Convert(message), message.Type);
            //Decode message
            switch (message.Type)
            {
                case 200://App Started
                    if (_clientCnt < 0) { _clientCnt = 0; }//Just in case we got negative
                    _clientCnt++;
                    _broadcast = true;
                    if (SystemsCollection.Count == 0)
                    { SendUdpBroadcast(new UdpMessage(10, DateTime.Now, "control", "No Systems")); }
                    else
                    { foreach (ManageSystem sys in SystemsCollection) { SendSysOpenMessage(sys); } }
                    break;
                case 201://App Closed
                    _clientCnt--;
                    if (_clientCnt < 1) { _clientCnt = 0; }//Just in case we got negative
                    if (_clientCnt == 0) { _broadcast = false; }
                    break;
                case 210://System Added
                    FillSysDefsTable();//This will pick up any changes in the database
                    CreateNewSystem(message.Recipient);
                    break;
                case 211://System Deleted
                    RemoveSystem(message.Recipient);
                    break;
                case 212://System Modified
                    FillSysDefsTable();
                    ModifySystem(message.Recipient, message.Info, true);
                    break;
                case 300://Try Startup
                    ModifySystem(message.Recipient, message.Recipient, false);//This will retry the startup
                    break;
                case 301://Send a TCPIP Command
                    SendTcpipCommand(message.Recipient, message.Info);
                    break;
                case 302://Send a TCPIP Command
                    SendForTrace(message.Recipient, message.Info);
                    break;
                case 400://Change Sql Server setting
                    ChangeSqlSetting(message.Info);
                    break;
            }
            
        }
        
        public Service1()
        {
            InitializeComponent();
            string CommonPath = Application.CommonAppDataPath.Remove(Application.CommonAppDataPath.Length - Application.ProductVersion.Length, Application.ProductVersion.Length);
            DatabasePath = CommonPath + Properties.Settings.Default.FOLDERDB + @"\";
            PcapPath = CommonPath + Properties.Settings.Default.FOLDERPCAP + @"\";
            string currentUserAccount = System.Environment.UserName;
            try
            {                
                if (!Directory.Exists(DatabasePath)) 
                { 
                    Directory.CreateDirectory(DatabasePath);
                    SeeSystemConfig.GrantModifyAccessToFolder
                        (currentUserAccount, DatabasePath);      
                }
                if (!Directory.Exists(PcapPath)) 
                { 
                    Directory.CreateDirectory(PcapPath);
                    SeeSystemConfig.GrantModifyAccessToFolder
                        (currentUserAccount, PcapPath);       
                }
                UdpBroadcast1.SetPorts(Properties.Settings.Default.UDPSEND, Properties.Settings.Default.UDPRECV);
                UdpBroadcast1.MessageRcvd += new UdpDelegate(UdpBroadcast1_MessageRcvd);
                controlTimer.AutoReset = true;
                controlTimer.Elapsed += new System.Timers.ElapsedEventHandler(controlTimer_Elapsed);
            }
            catch (Exception exc)
            { WriteAppLogError(exc.ToString(), 10000); }
        }

        public void StartforDebug()
        {
            Debug.Indent();
            OnStart(null); 
        }        
        protected override void OnStart(string[] args)
        {
            //This service is set in the ProjectInstaller as a dependant on MSSQL$SQLEXPRESS
            //This service is set to start automatically after reboot
            try
            {            
                #region Check for database(SeeCommon) - attach to sql server if necessary
                
                SqlBase sqlBase = new SqlBase();
                sqlBase.SetDb("SeeCommon");
                //Database .mdf and .ldf files are copied to the application directory as part of installation
                //Copy the files and attach the database to the server
                WriteAppLogInfo("Service Starting: Master Connection string = " + Environment.NewLine +
                    sqlBase.MasterConnectionString + Environment.NewLine +
                    "SeeCommon Connection string = " + Environment.NewLine +
                    sqlBase.ConnectionString, 1111);                
                if (!sqlBase.IsDbRegistered())
                {
                    string datFilePath1 = Application.StartupPath + @"\SeeCommon.mdf";
                    string logFilePath1 = Application.StartupPath + @"\SeeCommon_log.ldf";
                    string datFilePath2 = DatabasePath + "SeeCommon.mdf";                    
                    string logFilePath2 = DatabasePath + "SeeCommon_log.ldf";
                    File.Copy(datFilePath1, datFilePath2, true);
                    File.Copy(logFilePath1, logFilePath2, true);                
                    sqlBase.ExAttachDB(datFilePath2, logFilePath2, "SeeCommon");                    
                    sqlBase.Connection.Open();//Test the connection or fail
                }

                #endregion
                int sysCnt = FillSysDefsTable();     //Get the currently defined systems
                foreach (SeeCommonDataSet.SysDefsRow defRow in DefsTable)
                { CreateNewSystem(defRow, true); }
                SendUdpBroadcast(new UdpMessage(1, DateTime.Now, "All", "Service Started"));
                controlTimer.Start();   //This timer checks for broken connections                
            }
            catch (Exception exc)
            { WriteAppLogError(exc.Message + Environment.NewLine + exc.ToString(), 10000); }            
        }        
        protected override void OnStop()
        {
            //base.Stop();???
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
        protected override void  OnPause()
        {
 	        base.OnPause();
            
        }     
        protected override void OnContinue()
        {
            base.OnContinue();
            
        }
        protected override void OnShutdown()
        {
            base.OnShutdown();
        }
                
        private SeeCommonDataSet.SysDefsDataTable DefsTable = new SeeCommonDataSet.SysDefsDataTable();
        private ManageSystemsCollection SystemsCollection = new ManageSystemsCollection();
        private System.Timers.Timer controlTimer = new System.Timers.Timer(300000);//Sync up every 5 min
        
        private void controlTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UdpMessage udpMess = new UdpMessage(0, DateTime.Now, "All", "control");
            SendUdpBroadcast(udpMess);
            //Check for broken connections & clients that are turned off and still connected
            foreach (ManageSystem sys in SystemsCollection)
            {
                if (sys.IsMonitorOn && sys.Status == ManageComm.statDISCONNECTED)
                { sys.TurnOnMonitor(); }
                else if (!sys.IsMonitorOn && sys.Status != ManageComm.statDISCONNECTED)
                { sys.TurnOffMonitor(); }
            }
        }

        #region Methods
        private int FillSysDefsTable()
        {
            SysDefsTableAdapter DefsAdapter = new SysDefsTableAdapter();
            DefsAdapter.ClearBeforeFill = false;//must stay false or the rows referenced by the systems are deleted
            return DefsAdapter.Fill(DefsTable);            
        }
        private SeeCommonDataSet.SysDefsRow GetSysDefRow(string name)
        {
            string expr = "Name = '" + name + "'";
            DataRow[] rows = DefsTable.Select(expr);//This will grab the row
            if (rows.Length == 1)//There should be one and only one
            { return (SeeCommonDataSet.SysDefsRow)rows[0]; }
            else { return null; } 
        }
        private void RemoveSysDefRow(string name)
        {
            SeeCommonDataSet.SysDefsRow defRow = GetSysDefRow(name);
            if (defRow != null)
            {
                DefsTable.RemoveSysDefsRow(defRow);

                //SysDefsTableAdapter DefsAdapter = new SysDefsTableAdapter();
                //DefsAdapter.Update(defRow);
            }            
        }
        
        private void CreateNewSystem(string name)
        {
            SeeCommonDataSet.SysDefsRow defRow = GetSysDefRow(name);
            if (defRow != null) { CreateNewSystem(defRow, true); }
        }
        private void CreateNewSystem(SeeCommonDataSet.SysDefsRow defRow, bool sendOpen)
        {            
            SqlManagerSystem sqlSys = new SqlManagerSystem();
            sqlSys.SetDb(defRow.DbName, DatabasePath);
            bool dbAvailable = sqlSys.IsDbRegistered();
            if (!dbAvailable)//Create database if necessary
            { dbAvailable = CreateSysDatabase(defRow.DbName); }
            if (dbAvailable) //Only start monitoring if the database is available
            {
                ManageSystem sys = new ManageSystem(defRow);//Database must be available before creating this object
                SystemsCollection.Add(sys);//Add to the collection                
                if (sys.IsMonitorOn) { ThreadPool.QueueUserWorkItem(new WaitCallback(TurnOnMonitor), sys); }
                Thread.Sleep(1000);
                if (sendOpen) { SendSysOpenMessage(sys); }
            }
            
            
        }
        private void RemoveSystem(string name)
        { 
            RemoveFromCollection(name);
            SeeCommonDataSet.SysDefsRow defRow = GetSysDefRow(name);
            if (defRow != null)
            {
                if (DropDatabase(defRow.DbName))
                { FillSysDefsTable(); }//now the row should be gone                
            }
        }        
        private void ModifySystem(string origName, string currName, bool sendOpen)
        {
            ManageSystem sys = SystemsCollection.GetByName(origName);
            RemoveFromCollection(sys);//remove old system               
            
            SeeCommonDataSet.SysDefsRow defRow = GetSysDefRow(currName);
            if (defRow != null)
            {
                if (origName != currName)
                { RenameDatabase(origName.Replace(' ', '_'), currName.Replace(' ', '_')); }
                CreateNewSystem(defRow, sendOpen); }//this should start(or stop)polling with new settings               
        }
        
        private void TurnOnMonitor(object state)
        {
            ManageSystem sys = (ManageSystem)state;
            TurnOnMonitor(sys);
        }
        private void TurnOnMonitor(ManageSystem sys)
        {
            sys.SendUdpBroadcast += new UdpDelegate(SendUdpBroadcast);//Service1 will dispatch the udp broadcasts
            sys.TurnOnMonitor();//commented out for debugging
        }

        private void RemoveFromCollection(string name)
        {
            ManageSystem sys = SystemsCollection.GetByName(name);
            if (sys != null) { RemoveFromCollection(sys); }            
        }
        private void RemoveFromCollection(ManageSystem sys)
        {
            sys.TurnOffMonitor();
            SystemsCollection.Remove(sys);
            sys.Dispose();            
        }

        private bool CreateSysDatabase(string dbName)
        {
            bool success = false;
            try
            {
                SqlManagerSystem sqlMan = new SqlManagerSystem();
                sqlMan.SetDb(dbName, DatabasePath);
                sqlMan.ExCreateDB();
                sqlMan.AddTables();
                success = true;
            }
            catch (System.Data.SqlClient.SqlException sqlExc)//CreateFailed
            { SendUdpBroadcast(new UdpMessage(151, DateTime.Now, dbName.Replace('_', ' '), sqlExc.Message)); }
            
            return success;
        }
        private bool RenameDatabase(string oldDbName, string newDbName)
        {
            bool success = false;
            try
            {
                SqlManagerSystem sqlMan = new SqlManagerSystem();
                sqlMan.SetDb(oldDbName, DatabasePath);
                sqlMan.ExRenameDB(newDbName);
                success = true;
            }
            catch (System.Data.SqlClient.SqlException sqlExc)//RenameFailed
            { SendUdpBroadcast(new UdpMessage(152, DateTime.Now, oldDbName.Replace('_', ' '), sqlExc.Message)); }
                                
            return success;
        }
        private bool DropDatabase(string dbName)
        {
            bool success = false;
            try
            {
                SqlManagerSystem sqlMan = new SqlManagerSystem();
                sqlMan.SetDb(dbName, DatabasePath);
                if (sqlMan.IsDbRegistered())
                { sqlMan.ExDropDB(); }
                success = true;
            }
            catch (System.Data.SqlClient.SqlException sqlExc)//DropFailed
            { SendUdpBroadcast(new UdpMessage(153, DateTime.Now, dbName.Replace('_', ' '), sqlExc.Message)); }
            
            return success;
        }

        private void SendSysOpenMessage(ManageSystem sys)
        {
            string info = "Off";
            if (sys.IsMonitorOn) { info = sys.Status.Message; }
            SendUdpBroadcast(new UdpMessage(11, DateTime.Now, sys.Name, "Open-" + info));
        }
        private void SendTcpipCommand(string name, string cmdTxt)
        {
            ManageSystem sys = SystemsCollection.GetByName(name);
            sys.SendTcpipCommand(cmdTxt);
            
        }
        private void SendForTrace(string name, string cmdName)
        {
            ManageSystem sys = SystemsCollection.GetByName(name);
            sys.SendForTrace(cmdName);

        }

        #endregion

        private void ChangeSqlSetting(string connStringMaster)
        {
            SqlConnectionStringBuilder sqlConnBuilder = new SqlConnectionStringBuilder(connStringMaster);
            SeeSystemConfig seeConfig = new SeeSystemConfig();
            seeConfig.SqlConnStrMaster = sqlConnBuilder.ConnectionString;//save master string
            sqlConnBuilder.InitialCatalog = "SeeCommon";
            seeConfig.SqlConnStrCommon = sqlConnBuilder.ConnectionString;//save SeeCommon string
            
            this.Stop();
        }

    }
    
}
