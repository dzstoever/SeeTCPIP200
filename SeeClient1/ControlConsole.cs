using csi.see.classlib1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ConsoleRecords;

namespace csi.see.client1
{
    public partial class ControlConsole : UserControl
    {
        private ConsoleDispatcher dispatcher;
        public ConsoleDispatcher Dispatcher
        { set { dispatcher = value; } }
        public event StringDelegate SendTcpipCommand;

        public ControlConsole()
        {
            InitializeComponent();
            
            dispatcher = new ConsoleDispatcher();
            dispatcher.Suspend = false;//This and everything else is from the old ConsoleWorkstation                        
            tcpIpConsole1.Dispatcher = dispatcher;
            tcpIpConsole1.SendTcpipCommand += new StringDelegate(tcpIpConsole1_SendTcpipCommand);
            messageCenter1.OnMessageChanged += new MessageCenter.OnMessageChangedHandler(messageCenter1_OnMessageChanged);
        }

        void tcpIpConsole1_SendTcpipCommand(string cmdTxt)
        {
            SendTcpipCommand(cmdTxt);//Relay the command
            this.Cursor = Cursors.WaitCursor;
        }

        private void ConsoleControl_Load(object sender, EventArgs e)
        {
            dockableWindow1.Collapsed = true;
            dockableWindow2.Collapsed = true;
            dockableWindow1.AllowClose = false;
            dockableWindow2.AllowClose = false;
            commandCenter1.Release = "15E";
            messageCenter1.Release = "15E";

        }
        private void messageCenter1_OnMessageChanged(TcpIpMessageCode code)
        {
            if (code != null && dockableWindow2.IsOpen == false)
            {
                dockableWindow2.Open();
                dockableWindow2.Activate();
                dockableWindow2.Collapsed = false;
            }
        }

        public void Setup(string dbName)
        {
            tcpIpConsole1.Setup(dbName, commandCenter1, messageCenter1);            
        }
        
        public void OnConnected()
        { tcpIpConsole1.OnConnected(0, "Connected"); }
        public void OnDisconnected()
        { tcpIpConsole1.OnDisconnected(0, "Disconnected"); }
        public void OnMessageRcvd(int lastID, int count)
        { tcpIpConsole1.OnTcpipMessageRcvd(lastID, count); }        
        public void OnCommandNotSent(DateTime time, string reason)
        {
            this.Cursor = Cursors.Default;
            MessageBox.Show(reason, "Send Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void OnCommandProcRcvd(DateTime time, string description)
        {
            this.Cursor = Cursors.Default;            
        }

        
    }
}
