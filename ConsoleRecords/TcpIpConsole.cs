using csi.see.classlib1;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Timers;
//using csi.util;
//using csi.seevse.MsdeDataAccess;
using System.Runtime.InteropServices;


namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for PageableTcpIpConsole.
	/// </summary>
	public class TcpIpConsole : PageableConsole
	{
        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TcpIpConsole));
            this.pnlCommand = new System.Windows.Forms.Panel();
            this.comboCommand = new System.Windows.Forms.ComboBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.lblCommand = new System.Windows.Forms.Label();
            this.pnlCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolMain
            // 
            this.toolMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolMain.Size = new System.Drawing.Size(550, 28);
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            this.images.Images.SetKeyName(3, "");
            this.images.Images.SetKeyName(4, "");
            this.images.Images.SetKeyName(5, "");
            this.images.Images.SetKeyName(6, "");
            this.images.Images.SetKeyName(7, "");
            this.images.Images.SetKeyName(8, "");
            // 
            // rtbConsole
            // 
            this.rtbConsole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rtbConsole.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbConsole.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rtbConsole.Location = new System.Drawing.Point(2, 48);
            this.rtbConsole.Size = new System.Drawing.Size(550, 269);
            // 
            // rtbHeader
            // 
            this.rtbHeader.Location = new System.Drawing.Point(0, 28);
            this.rtbHeader.Size = new System.Drawing.Size(550, 20);
            // 
            // pnlCommand
            // 
            this.pnlCommand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCommand.Controls.Add(this.comboCommand);
            this.pnlCommand.Controls.Add(this.buttonSend);
            this.pnlCommand.Controls.Add(this.lblCommand);
            this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommand.Enabled = false;
            this.pnlCommand.Location = new System.Drawing.Point(2, 317);
            this.pnlCommand.Name = "pnlCommand";
            this.pnlCommand.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlCommand.Size = new System.Drawing.Size(550, 35);
            this.pnlCommand.TabIndex = 5;
            // 
            // comboCommand
            // 
            this.comboCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboCommand.Location = new System.Drawing.Point(22, 5);
            this.comboCommand.MaxDropDownItems = 10;
            this.comboCommand.Name = "comboCommand";
            this.comboCommand.Size = new System.Drawing.Size(464, 21);
            this.comboCommand.TabIndex = 3;
            this.comboCommand.SelectedIndexChanged += new System.EventHandler(this.comboCommand_SelectedIndexChanged);
            this.comboCommand.Leave += new System.EventHandler(this.comboCommand_Leave);
            this.comboCommand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboCommand_MouseDown);
            this.comboCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboCommand_KeyPress);
            this.comboCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboCommand_KeyDown);
            this.comboCommand.TextChanged += new System.EventHandler(this.comboCommand_TextChanged);
            // 
            // buttonSend
            // 
            this.buttonSend.AutoSize = true;
            this.buttonSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.Location = new System.Drawing.Point(486, 5);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(60, 21);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // lblCommand
            // 
            this.lblCommand.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCommand.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommand.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCommand.Location = new System.Drawing.Point(0, 5);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(22, 21);
            this.lblCommand.TabIndex = 0;
            this.lblCommand.Text = ">";
            this.lblCommand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TcpIpConsole
            // 
            this.Controls.Add(this.pnlCommand);
            this.DisplaySize = 15;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TcpIpConsole";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.PageSize = 15;
            this.Size = new System.Drawing.Size(552, 352);
            this.Tag = "";
            this.Controls.SetChildIndex(this.pnlCommand, 0);
            this.Controls.SetChildIndex(this.rtbConsole, 0);
            this.pnlCommand.ResumeLayout(false);
            this.pnlCommand.PerformLayout();
            this.ResumeLayout(false);

        }
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region MEMBER VARIABLES
        private CommandCenter commandCenter;		
		private MessageCenter messageCenter;
        private System.Timers.Timer keyPressedTimer;
        private Panel pnlCommand;
        private Label lblCommand;
        private Button buttonSend;
        private ComboBox comboCommand;        
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		#region CONSTRUCTORS AND DECONSTRUCTORS
		public TcpIpConsole()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
            manager = new ManTcpipMessages();
            Title = "TCP/IP Messages";
            END_BANNER = "--------------- END OF TCP/IP MESSAGES ---------------";
            START_BANNER = "-------------- START OF TCP/IP MESSAGES --------------";
            rtbHeader.Text = "Time               Message";
            rtbConsole.RegisterToBeScrolled(rtbHeader);
            rtbConsole.DoubleClick += new EventHandler(rtbConsole_DoubleClick);
            pnlCommand.Enabled = false;            
            SendTcpipCommand += new StringDelegate(TcpIpConsole_SendTcpipCommand);
            cmnuRightClick.MenuItems.Add("Clear History",new EventHandler(ClearHistory_Click));

            
		}
        //dzs
        string _dbName;
        public void Setup(string dbName, CommandCenter cCenter, MessageCenter mCenter)
        {
            _dbName = dbName;
            manager.SetDbName(dbName);
            messageCenter = mCenter;
            commandCenter = cCenter;
            commandCenter.OnCommandChanged += new CommandCenter.OnCommandChangedHandler(commandCenter_OnCommandChanged);            
        }

        

        #endregion
        #region IMPLEMENTATIONS (PageableConsole)
        public override DataTable GetData(int start, int end)
        {
            ConsoleDataSet.TCPIP_MessagesDataTable table = null;

            try
            {
                table = ((ManTcpipMessages)manager).GetIdRange(start, end);
            }
            catch (System.Data.SqlClient.SqlException sqle)
            {
                Debug.WriteLine("SQL Exception: " + sqle.Message);
                Status = new StatusEventArgs(635, StatusEventArgs.SEVERE, sqle.Message);
            }

            return table;
        }
        public override string GetTextAt(DataTable table, int index)
        {
            ConsoleDataSet.TCPIP_MessagesRow row = (ConsoleDataSet.TCPIP_MessagesRow)table.Rows[index];

            if (row.Message_Text.StartsWith(">") || row.Message_Text.StartsWith("-"))
                return FormatText(row.Message_Text);
            else
                return FormatText(new TcpIpMessage(row.Message_Text));
        }
        public override int GetLastIdIn(DataTable table)
        {
            if (table.Rows.Count > 0)
                return ((ConsoleDataSet.TCPIP_MessagesRow)table.Rows[table.Rows.Count - 1]).Message_ID;
            else
                return 0;
        }
        
        public override string FormatText(object message)
        {
            if (message is TcpIpMessage)
                return FormatTcpIpMessage(message);
            else if (message is string)
            {
                if (((string)message).StartsWith("-"))
                    return @"\pard\qc\cf2\fs14 " + message + @"\par";
                else if (((string)message).StartsWith("> "))
                    return @"\pard\b\cf1\fs16 " + message + @"\b0\par";
                else if (((string)message).Length == 0)
                    return @"\pard\qc\cf1\fs16 " + message + @"\par";
                else
                    return FormatTcpIpMessage(new TcpIpMessage((string)message));
            }
            else
                return "*** UNEXPECTED VALUE ***";
        }
        private string FormatTcpIpMessage(object message)
        {
            TcpIpMessage tcpIpMessage = (TcpIpMessage)message;
            string text;
            if (tcpIpMessage.TaskId != null)
            {
                if (tcpIpMessage.Code != null)
                    text = tcpIpMessage.TaskId + " " + tcpIpMessage.Code + " " + tcpIpMessage.Message;
                else
                    text = tcpIpMessage.TaskId + " " + tcpIpMessage.Message;
            }
            else
            {
                if (tcpIpMessage.Code != null)
                    text = tcpIpMessage.Code + " " + tcpIpMessage.Message;
                else
                    text = tcpIpMessage.Message;
            }

            text = Rtf.ReplaceControlCodes(text);

            if (tcpIpMessage.Code != null && tcpIpMessage.Code.EndsWith("W"))
                return @"\pard\cf1\fs16 " + tcpIpMessage.DateFormatter(tcpIpMessage.TimeStamp) + @" \cf4 " + text + @"\par";
            else if (tcpIpMessage.Code != null && tcpIpMessage.Code.EndsWith("E"))
                return @"\pard\b\cf1\fs16 " + tcpIpMessage.DateFormatter(tcpIpMessage.TimeStamp) + @" \cf3 " + text + @"\b0\par";

            string x = @"\pard\cf1\fs16 " + tcpIpMessage.DateFormatter(tcpIpMessage.TimeStamp) + " " + text + @"\par";

            return @"\pard\cf1\fs16 " + tcpIpMessage.DateFormatter(tcpIpMessage.TimeStamp) + " " + text + @"\par";
        }
        #endregion

        protected bool processing = false;
        public bool ignoreLookup = false;
        public CommandCenter CommandCenter
        {
            get { return commandCenter; }
        }
        public MessageCenter MessageCenter
        {
            get { return messageCenter; }
        }
        public String Command
        {
            get { return comboCommand.Text; }
            set { comboCommand.Text = value; }
        }

        public delegate void OnCommandStartedHandler();
        public delegate void OnCommandChangedHandler(object sender, string command);
        public event OnCommandStartedHandler OnCommandStarted;
		public event OnCommandChangedHandler OnCommandChanged;
        
        private delegate void FocusCommandLineDelegate();
        public void FocusCommandLine()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new FocusCommandLineDelegate(FocusCommandLine),
                    new object[] { });
                return;
            }

            pnlCommand.Enabled = true;
            comboCommand.Focus();
        }
        private delegate void UnhighlightTextDelegate();
        private void UnhighlightText()
        {
            comboCommand.SelectionStart = comboCommand.Text.Length;
            comboCommand.SelectionLength = 0;
        }
        private delegate void LookupDelegate();
        private void Lookup()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new LookupDelegate(Lookup),
                    new object[] { });
                return;
            }

            TcpIpCommand command = commandCenter.Parse(comboCommand.Text);
            if (command != null)
            {
                if (commandCenter.TcpIpCommand == null || command.Name.Equals(commandCenter.TcpIpCommand.Name) == false)
                    commandCenter.TcpIpCommand = command;

            }
            else
                commandCenter.TcpIpCommand = null;

        }
        private void keyPressedTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ignoreLookup = false;
            Lookup();
        }
                
        private void commandCenter_OnCommandChanged(string command)
        {
            if (pnlCommand.Enabled == true)
            {
                ignoreLookup = true;
                comboCommand.Text = command;
                ignoreLookup = false;
            }
        }
        private void rtbConsole_DoubleClick(object sender, EventArgs e)
        { messageCenter.Lookup(SelectedText); }
        private void SetCursorPos(ComboBox cb, int x, int y)
        {
            cb.Select(cb.Text.Length, 0);
            /* Commented out because SendMessage unbalances the call stack
            IntPtr edit = FindWindowEx(cb.Handle, new IntPtr(0), null, null);

            POINT pt = new POINT();
            pt.x = x;
            pt.y = y;

            IntPtr index = SendMessage(edit, EM_CHARFROMPOS, new IntPtr(0), pt);
            if (index.ToInt32() != -1)
                cb.SelectionStart = index.ToInt32();*/
        }
        #region No longer used - unbalances the call stack
        /* 
        private const int EM_CHARFROMPOS = 0x00D7;
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public System.Int32 x;
            public System.Int32 y;
        }
        [DllImport("user32.Dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, POINT lParam);
        [DllImport("user32.Dll", CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);
        */
        #endregion

        #region EVENT HANDLERS (Command Line)
        private void comboCommand_TextChanged(object sender, System.EventArgs e)
        {
            if (ignoreLookup == false)
            {
                TcpIpCommand command = commandCenter.Parse(comboCommand.Text);
                if (command != null)
                {
                    if (commandCenter.TcpIpCommand == null || command.Name.Equals(commandCenter.TcpIpCommand.Name) == false)
                        commandCenter.TcpIpCommand = command;

                }
                else { commandCenter.TcpIpCommand = null; }
            }


            if (OnCommandChanged != null && OnCommandChanged.GetInvocationList() != null)
                OnCommandChanged(sender, comboCommand.Text);
        }
        private void comboCommand_SelectedIndexChanged(object sender, System.EventArgs e)
        { BeginInvoke(new UnhighlightTextDelegate(UnhighlightText)); }
        private void comboCommand_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        { SetCursorPos(comboCommand, e.X, e.Y); }
        private void comboCommand_Leave(object sender, System.EventArgs e)
        { comboCommand.SelectionLength = 0; }
        private void comboCommand_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string text = comboCommand.Text;
            if (e.Shift && e.KeyCode.GetHashCode() == Keys.Left.GetHashCode())
            {
                int start;
                int pos = comboCommand.SelectionStart;

                if (e.Control)
                {
                    comboCommand.Text = text.Remove(0, pos);
                    e.Handled = true;
                    return;
                }

                if (pos == 0) { start = 0; }
                else
                {
                    start = text.LastIndexOf(",", pos - 1, pos);
                    if (start < 0) { start = 0; }
                }

                int end = comboCommand.Text.IndexOf(",", pos);
                if (end < 0) { end = text.Length; }

                int count = end - start;
                if (count > 0)
                {
                    comboCommand.Text = text.Remove(start, count);
                    comboCommand.SelectionStart = pos < comboCommand.Text.Length ? pos : comboCommand.Text.Length;
                }
                e.Handled = true;
                return;
            }
            else if (e.Shift && e.KeyCode.GetHashCode() == Keys.Right.GetHashCode())
            {

                /*string[] items = treeCommand1.GetCommandsStartsWith(text);
                if (items.Length == 1 && items[0].Equals(text.ToUpper()) == false)
                {
                    if (items[0].IndexOf(" ") < 0) { comboCommand.Text = items[0] + " "; }
                    else { comboCommand.Text = items[0]; }
                    comboCommand.SelectionStart = comboCommand.Text.Length;
                }
                else
                {*/
                if (text.Length > 0)
                {
                    text = comboCommand.Text;
                    while (text.EndsWith(","))
                    { text = text.Substring(0, text.Length - 1); }

                    string next = commandCenter.NextAvailable(comboCommand.Text);
                    if (next.Length > 0)
                    {
                        if (text.IndexOf(" ") < 0) { text += " "; }

                        comboCommand.Text = text + next;
                        comboCommand.SelectionStart = comboCommand.Text.Length;
                    }
                }
                //}

                e.Handled = true;
                return;
            }
            else
            {
                FireActionEvent(sender, e);
                if (PagingKeyHandler(e.KeyCode, e.Shift, e.Control, e.Alt) == true)
                    e.Handled = true;
            }

        }
        private void comboCommand_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' && comboCommand.SelectionStart == 0)
            {// Do not allow a space character to be added as the first character of the command line.
                e.Handled = true;
                return;
            }
            else if (e.KeyChar == 0x0D)
            {
                if (processing == true)
                {
                    e.Handled = true;
                    return;
                }
                else { processing = true; }

                SendCommand();
                e.Handled = true;  // suppresses event that causes the beep
            }
            else
            {
                if (comboCommand.Text.Length == 0)
                {
                    if (OnCommandStarted != null && OnCommandStarted.GetInvocationList() != null)
                    { OnCommandStarted(); }
                }

            }

            ignoreLookup = true;
            if (keyPressedTimer != null) { keyPressedTimer.Stop(); }
            if (commandCenter.TcpIpCommand == null) { keyPressedTimer = new System.Timers.Timer(1000); }
            else { keyPressedTimer = new System.Timers.Timer(500); }
            keyPressedTimer.AutoReset = false;
            keyPressedTimer.Elapsed += new System.Timers.ElapsedEventHandler(keyPressedTimer_Elapsed);
            keyPressedTimer.Start();
        }
        #endregion
        #region EVENT HANDLERS (Dispatcher)		
        public override ConsoleDispatcher Dispatcher
        {
            set
            {
                base.Dispatcher = value;
                dispatcher.OnCommandSent += new ConsoleDispatcher.OnSentHandler(dispatcher_OnCommandSent);
                dispatcher.OnCommandProcessedReceived += new ConsoleDispatcher.OnReceivedHandler(dispatcher_OnCommandProcessedReceived);
                dispatcher.OnTcpIpMessageReceived += new ConsoleDispatcher.OnMultiReceivedHandler(dispatcher_OnTcpIpMessagesReceived);                
            }
        }
        //dzs
        public void OnConnected(int code, string description)
        { dispatcher_OnConnected(code, description); }
        public void OnDisconnected(int code, string description)
        { dispatcher_OnDisconnected(code, description); }               
        protected override void dispatcher_OnConnected(int code, String description) 
		{
			if (this.InvokeRequired)
			{
				BeginInvoke(new ConsoleDispatcher.ConnectionHandler(dispatcher_OnConnected),
					new object[] {code, description});
				return;
			}			

			base.dispatcher_OnConnected(code, description);
			if (code == 0) 
			{
				processing = false;
				pnlCommand.Enabled = true;
				comboCommand.Focus();
                rtbConsole.Enabled = true;
			}
		}
		protected override void dispatcher_OnDisconnected(int code, String description) 
		{
			if (this.InvokeRequired)
			{
				BeginInvoke(new ConsoleDispatcher.ConnectionHandler(dispatcher_OnDisconnected),
					new object[] {code, description});
				return;
			}			

			base.dispatcher_OnDisconnected(code, description);			
            pnlCommand.Enabled = false;
            rtbConsole.Enabled = false;
		}
                
        private void dispatcher_OnCommandSent(string data, DateTime time, long localOffset, long remoteOffset)
        {
            if (Active == true)//Only append the command if you are at the End of the Console i.e Active
            {
                if (rtbConsole.Lines.Length >= PageSize)
                {
                    rtbConsole.Clear();
                    Append(END_BANNER);
                }
                else { Append(data, true); }
                Current++;
            }
        }
        private void dispatcher_OnCommandProcessedReceived(byte[] blok, long utcOffset) 
		{
			//RawDataConverter converter = new RawDataConverter();
			//if (blok != null) { string description = converter.GetEBCDIC(4, blok, 4); }
			processing = false;			
		}
        private void dispatcher_OnTcpIpMessageReceived(byte[] blok, long utcOffset)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new ConsoleDispatcher.OnReceivedHandler(dispatcher_OnTcpIpMessageReceived),
                    new object[] { blok, utcOffset });
                return;
            }

            if (active == true)
            {
                TcpIpMessage message = new TcpIpMessage(blok);
                Append(message);
            }
        }
        private void dispatcher_OnTcpIpMessagesReceived(ArrayList list, long utcOffset)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new ConsoleDispatcher.OnMultiReceivedHandler(dispatcher_OnTcpIpMessagesReceived),
                    new object[] { new ArrayList(list), utcOffset });
                return;
            }

            bool ActiveLocked = true;
            // Update the console.
            if (Active == true && ActiveLocked == true)
            {
                int x = PageSize - (rtbConsole.Lines.Length);
                if (list.Count < x)
                {
                    Append(list, true);
                    Current += list.Count;
                    rtbConsole.Refresh();
                    return;
                }

                while (list.Count > 0)
                {
                    x = PageSize - rtbConsole.Lines.Length;
                    while (list.Count > 0)
                    {
                        if (x == 0)
                        {
                            System.Threading.Thread.Sleep(250);
                            rtbConsole.Clear();
                            Append(END_BANNER);
                            x = PageSize - (rtbConsole.Lines.Length);
                        }

                        if (list.Count < x)
                        {
                            Append(list, true);
                            Current += list.Count;
                            list.Clear();
                        }
                        else
                        {
                            Append(list.GetRange(0, x), true);
                            Current += x;
                            list.RemoveRange(0, x);
                        }
                        rtbConsole.Refresh();

                        x = PageSize - (rtbConsole.Lines.Length);

                    }
                }
            }
            else if (Active == true)
            {
                if (rtbConsole.Lines.Length >= PageSize)
                {
                    Active = false;
                    endOfConsole = false;
                    Append(list.GetRange(0, 1), false);

                    Current++;

                }
                else
                {
                    int x = PageSize - (rtbConsole.Lines.Length - 1);

                    if (list.Count < x)
                    {
                        Append(list, true);
                        Current += list.Count;
                    }
                    else
                    {
                        Active = false;
                        endOfConsole = false;

                        Append(list.GetRange(0, x), false);
                        Current += x;
                        //ArrayList y = list.GetRange(0, x);
                    }

                }
            }
        }

		#endregion
		
        //dzs
        public event StringDelegate SendTcpipCommand;
        public void OnTcpipMessageRcvd(int lastID, int count)
        {
            //Debug.WriteLine("OnTcpipMessageRcvd");
            processing = false;
            if (Active)//Only append the message if you are at the End of the Console i.e Active
            {
                int firstID = lastID - count + 1;
                AppendNewMessages(firstID, lastID);
            }

        }
        /*public void OnTcpipCommandFailed(DateTime time, string message)
        { //Append(message); 
            //Debug.WriteLine("OnTcpipCommandFailed");
            processing = false;
            if (Active == true)//Only append the message if you are at the End of the Console i.e Active
            {
                if (rtbConsole.Lines.Length >= PageSize)
                {
                    rtbConsole.Clear();
                    Append(END_BANNER);
                }
                else { Append(message, true); }
                Current++;
            }
        }*/
        private void SendCommand()
        {
            String text = comboCommand.Text.Trim();
            if (text != "")
            {
                comboCommand.Focus();
                bool duplicate = false;
                for (int i = 0; i < comboCommand.Items.Count; i++)
                {
                    if (text.Equals(comboCommand.Items[i]))
                    {
                        duplicate = true;
                        break;
                    }
                }
                if (duplicate == false) { comboCommand.Items.Insert(0, text); }
                comboCommand.Text = "";

                dispatcher_OnCommandSent("> " + text, DateTime.Now, 0, 0);//Echo it to the screen
                SendTcpipCommand(text);//Throw a public event                                        
            }
        }
        private void AppendNewMessages(int firstId, int lastId)
        {
            ConsoleDataSet.TCPIP_MessagesDataTable mTable = (ConsoleDataSet.TCPIP_MessagesDataTable)GetData(firstId, lastId);
            foreach (ConsoleDataSet.TCPIP_MessagesRow mRow in mTable)
            {
                TcpIpMessage tcpipMess = new TcpIpMessage(mRow.Message_Text);
                Append(tcpipMess);
            }
        }        
        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendCommand();
        }
        private void TcpIpConsole_SendTcpipCommand(string cmdTxt){ }//Avoid null exceptions
        private void ClearHistory_Click(object sender, EventArgs e)
        {
            SqlManagerSystem manSys = new SqlManagerSystem();
            manSys.SetDb(_dbName);
            manSys.ClearTCIP_Messages();

            rtbConsole.Clear();
            rtbConsole.AppendText("Messages Cleared.");
            Page(new DataTable(), true, true);//Add start and end banners            
        }
				                        
	} // end of TcpIpConsole
}
