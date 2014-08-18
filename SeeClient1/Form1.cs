using csi.see.classlib1;
using csi.see.classlib1.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.ServiceProcess;

namespace csi.see.client1
{
    public partial class Form1 : Form
    {
        public static string PcapPath;//this is a temporary location for .pcap files
        public static string DatabasePath;//this is the location for all database files
        public static void WriteAppLogInfo(string text, int eventID)
        {
            EventLog.WriteEntry("SeeClient1", text, EventLogEntryType.Information, eventID); 
        }
        public static void WriteAppLogWarning(string text, int eventID)
        {
            EventLog.WriteEntry("SeeClient1", text, EventLogEntryType.Warning, eventID); 
        }
        public static void WriteAppLogError(string text, int eventID)
        {
            EventLog.WriteEntry("SeeClient1", text, EventLogEntryType.Error, eventID); 
        }

        private UdpBroadcaster UdpBroadcast1 = new UdpBroadcaster();
        private void SendUdpBroadcast(UdpMessage message)
        {
            UdpBroadcast1.Send(message);
            WriteAppLogInfo("Udp Form1->> " + UdpMessage.Convert(message), message.Type);            
        }
        private void UdpBroadcast1_MessageRcvd(UdpMessage message)
        {
            if (!this.IsDisposed)//Ignore UDP message if form is disposed
            {
                //Debug.WriteLine("Udp Form1<<- " + UdpMessage.Convert(message));                
                WriteAppLogInfo("Udp Form1<<- " + UdpMessage.Convert(message), message.Type);
                if (message.Type < 100)//This is for everyone
                {
                    #region Decode message and notify application
                    switch (message.Type)
                    {
                        /*case 0://Control
                            break;
                        case 1://Service Started
                            break;
                        case 2://Service Stopped
                            break;
                        */
                        case 10://Init No Systems
                            if (!this.IsDisposed)
                            { Invoke(new EmptyDelegate(NotifyNoSystems)); }
                            break;
                        case 11://Init Open System
                            if (!this.IsDisposed)
                            { Invoke(new ObjectDelegate(OpenSystem), new object[1] { message }); }
                            break;
                    }
                    #endregion
                }
                else//Dispatch based on message.Recipient == Name
                {
                    if (!this.IsDisposed)
                    { Invoke(new ObjectDelegate(DispatchSysMessage), new object[1] { message }); }
                }
            }
        }
        private void DispatchSysMessage(object obj)
        {
            UdpMessage message = (UdpMessage)obj;
            ControlVseSystem vseSys = _vseSystems.GetByName(message.Recipient);
            if (vseSys == null) { missedMessages.Add(message); }//In case the system is still being opened
            else
            {
                switch (message.Type)
                {
                    case 100: vseSys.OnDisconnected(message.Info);
                        break;
                    case 101: vseSys.OnStatus(message.Info);
                        break;
                    case 102: vseSys.OnStatus(message.Info);
                        break;
                    case 110: vseSys.OnConnected();
                        break;
                    case 120: int count; int lastID = DecodeUdpLastID(out count, message.Info);
                        vseSys.OnMessageRcvd(lastID, count);
                        break;
                    case 121: vseSys.OnCommandNotSent(message.Timestamp, message.Info); 
                        break;
                    case 122: vseSys.OnCommandProcRcvd(message.Timestamp, message.Info);
                        break;
                    case 130: vseSys.OnPollDataRcvd(message.Timestamp);  
                        break;
                    case 131: int count2; int lastID2 = DecodeUdpLastID(out count2, message.Info);
                        vseSys.OnConnectRecRcvd(lastID2, count2);                                               
                        break;
                    case 132: int count3; int lastID3 = DecodeUdpLastID(out count3, message.Info);
                        vseSys.OnFtpRecRcvd(lastID3, count3);
                        break;
                    case 133: int count4; int lastID4 = DecodeUdpLastID(out count4, message.Info);
                        vseSys.OnJobStepRecRcvd(lastID4, count4);
                        break;
                    case 140: vseSys.OnTraceDataRcvd(message.Timestamp, message.Info); 
                        break;                    
                    case 151:
                        RemoveSystem(message.Recipient);
                        MessageBox.Show(message.Info, "Sql Error");         //Create Database Error
                        break;
                    case 152: MessageBox.Show(message.Info, "Sql Error");   //Rename Database Error
                        break;
                    case 153: MessageBox.Show(message.Info, "Sql Error");   //Drop Database Error
                        break;
                    default://Communication Error = 100XX 
                        vseSys.OnCommError((CommErrorType)message.Type, message.Info);
                        break;                                        
                    
                }
 
            }
        }
        private int DecodeUdpLastID(out int count, string info)
        {
            string[] messParts = info.Split(new char[1] { '-' }, 3);
            count = Convert.ToInt32(messParts[2]);
            return Convert.ToInt32(messParts[1]);
        }
       
        private ArrayList missedMessages = new ArrayList();
        private VseSystemsCollection _vseSystems = new VseSystemsCollection();
             
        public Form1()
        {
            InitializeComponent();
            Text = Text + " ("+AboutBox1.AssemblyVersion+")";
#if DEBUG
            Debug.Indent();
            #region Check for logs
            //EventLog.DeleteEventSource("SeeClient1");
            //EventLog.DeleteEventSource("SeeService1");
            //EventLog.CreateEventSource("SeeService1", "SeeTCPIP");
            //EventLog.CreateEventSource("SeeClient1", "SeeTCPIP");
            EventLog[] logs = EventLog.GetEventLogs();
            Debug.WriteLine("---Event Logs---");
            foreach (EventLog log in logs)
            { Debug.WriteLine(log.Log); }                      
            Debug.WriteLine("---Sources registered---");
            string[] srcNames = new string[3]{"SeeTCPIP4VSE","SeeService1","SeeClient1"};
            foreach (string srcName in srcNames)
            {
                string logName = EventLog.LogNameFromSourceName(srcName, ".");
                if (EventLog.SourceExists(srcName))
                { Debug.WriteLine(srcName + " registered to " + logName); }
            }
            Debug.WriteLine("---End of Event Logs---");
            #endregion           
            csi.see.service1.Service1 service = new csi.see.service1.Service1();
            service.StartforDebug();
#endif
            string CommonPath = Application.CommonAppDataPath.Remove(Application.CommonAppDataPath.Length - Application.ProductVersion.Length, Application.ProductVersion.Length);
            DatabasePath = CommonPath + Properties.Settings.Default.FOLDERDB + @"\";
            PcapPath = CommonPath + Properties.Settings.Default.FOLDERPCAP + @"\";
            try
            {                
                UdpBroadcast1.SetPorts(Properties.Settings.Default.UDPSEND, Properties.Settings.Default.UDPRECV);
                UdpBroadcast1.MessageRcvd += new UdpDelegate(UdpBroadcast1_MessageRcvd);
                udp1.Text = Properties.Settings.Default.UDPSEND.ToString();
                udp2.Text = Properties.Settings.Default.UDPRECV.ToString();
            }
            catch (Exception exc)
            {
                udp1.Text = "FAIL";
                udp2.Text = "FAIL";
                MessageBox.Show("Udp communication failed!" + Environment.NewLine +
                    exc.Message, "SeeTCP/IP Error");
            }
            finally
            { status1.Text = ""; }
            
        }
        bool sendOpen = true;
        private void Form1_Activated(object sender, EventArgs e)
        {            
            if (sendOpen)
            {                
                sendOpen = false;
                this.Refresh();
                System.Threading.Thread.Sleep(300);
#if !DEBUG                
                try
                {

                    if (serviceController1.Status != ServiceControllerStatus.Running)
                    {
                        status1.Text = "Initializing...starting required service";
                        //status1.Refresh();
                        StartService(20);//Exits the Application if service won't start                    
                        status1.Text = "";

                    }
                }
                catch (InvalidOperationException invExc)
                {
                    MessageBox.Show(invExc.Message, "Required service is not installed.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
#endif
                UdpMessage message = new UdpMessage(200, DateTime.Now, "control", "AppStarted");
                SendUdpBroadcast(message);
                                
            }
            
        }        
        private void StartService(int sec)
        {
            try
            {
                if (serviceController1.Status == ServiceControllerStatus.Paused)
                { serviceController1.Continue(); }
                else { serviceController1.Start(); }
                serviceController1.WaitForStatus(ServiceControllerStatus.Running, 
                    new TimeSpan(0, 0, sec));//Timeout after sec                
            }//catch (TimeoutException tExc)
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + Environment.NewLine + Environment.NewLine +
                    "You can attempt to start the service using the Control Panel.",
                    "SeeTCP/IP for VSE - required service failed to start", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }            
        }
        
        private void menuExit_Click(object sender, EventArgs e)
        { Application.Exit(); }
        private void menuSystemsManager_Click(object sender, EventArgs e)
        {
            FormSystems frmDefs = new FormSystems();
            frmDefs.SysAdded += new StringDelegate(frmDefs_SysAdded);
            frmDefs.SysDeleted += new StringDelegate(frmDefs_SysDeleted);
            frmDefs.SysModified += new StringStringDelegate(frmDefs_SysModified);
            frmDefs.ShowDialog();
            
            //frmDefs.Dispose();
        }
        private void frmDefs_SysAdded(string sysName)
        {
            SendUdpBroadcast(new UdpMessage(210, DateTime.Now, sysName, "System Added")); 
            //service will send back an Open- message           
        }
        private void frmDefs_SysDeleted(string sysName)
        {
            RemoveSystem(sysName);            
            SendUdpBroadcast(new UdpMessage(211, DateTime.Now, sysName, "System Deleted"));             
        }
        private void frmDefs_SysModified(string origName, string currName)
        { 
            SendUdpBroadcast(new UdpMessage(212, DateTime.Now, origName, currName));
            RemoveSystem(origName);//Remove the old version, service will restart with new settings and notify
        }

        private void NotifyNoSystems()
        {
            //label1.Visible = false;
            //this.Refresh();
            menuSystemsManager_Click(null, null);
            //MessageBox.Show("Choose 'Systems Manager' from the Application menu to add new systems.",
            //"No Systems Defined", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void OpenSystem(object obj)
        {
            UdpMessage message = (UdpMessage)obj;
            //label1.Visible = true;
            status1.Text = "Initializing..." + message.Recipient;
            TD.SandDock.TabPage sysTab = new TD.SandDock.TabPage(message.Recipient);
            tabControl1.TabPages.Add(sysTab);//tabControl1 now contains sysTab
            this.Refresh();

            ControlVseSystem vseSys = new ControlVseSystem();
            vseSys.Name = message.Recipient;
            vseSys.Setup(message.Recipient);//Sets the database name for the console, also sets the statName.Text                    
            vseSys.Dock = DockStyle.Fill;
            vseSys.SendUdpBroadcast += new UdpDelegate(SendUdpBroadcast);
            sysTab.Controls.Add(vseSys);    //sysTab contains VseSystemControl

            if (message.Info == "Open-Off")
            { vseSys.OnOpenOff(); }
            else if (message.Info == "Open-Disconnected")
            { vseSys.OnDisconnected(""); }
            else if (message.Info == "Open-Ready")
            { vseSys.OnConnected(); }
            else//Must be initializing
            { vseSys.OnInitializing(message.Info.TrimStart(new char[5] { 'O', 'p', 'e', 'n', '-' })); }

            _vseSystems.Add(vseSys);//Add to the collection of defined systems                
            #region Make sure we didn't miss any messages
            object[] mMessages = missedMessages.ToArray();
            foreach (UdpMessage mMess in mMessages)
            {
                if (mMess.Recipient == message.Recipient)
                {
                    missedMessages.Remove(mMess);
                    UdpBroadcast1_MessageRcvd(mMess);
                }
            }
            #endregion
            status1.Text = "";
            //label1.Visible = false;
            this.Refresh();
        }
        private void CreateSystem(string name)
        {
            ControlVseSystem vseSysOpen = _vseSystems.GetByName(name);
            if (vseSysOpen == null)
            {
                ControlVseSystem vseSys = new ControlVseSystem();
                vseSys.Name = name;
                //vseSys.SetName(name);
                vseSys.Dock = DockStyle.Fill;
                vseSys.SendUdpBroadcast += new UdpDelegate(SendUdpBroadcast);
                _vseSystems.Add(vseSys);//Add to the collection of defined systems

                TD.SandDock.TabPage sysTab = new TD.SandDock.TabPage(name);
                sysTab.Controls.Add(vseSys);//sysTab now contains vseSys
                tabControl1.TabPages.Add(sysTab);//tabControl1 now contains sysTab            
            }
        }
        private void RemoveSystem(string name)
        {
            ControlVseSystem vseSys = _vseSystems.GetByName(name);
            if (vseSys != null)
            {
                _vseSystems.Remove(vseSys);
                tabControl1.TabPages.Remove((TD.SandDock.TabPage)vseSys.Parent);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void howToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestForm tForm = new TestForm();
            tForm.Show();
        }

        private void menuConfiguration_Click(object sender, EventArgs e)
        {
            FormConfig frmConfig = new FormConfig();
            DialogResult result = frmConfig.ShowDialog();
            if (result == DialogResult.OK)
            {
                string sqlStrMaster = frmConfig.SqlStrMaster;
                UdpMessage udpMess = new UdpMessage(400, DateTime.Now, "All",
                    sqlStrMaster);
                SendUdpBroadcast(udpMess);
            }
        }        
        
    }
}