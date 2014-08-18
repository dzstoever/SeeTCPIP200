using csi.see.classlib1;
using csi.see.classlib1.DataSets;
using csi.see.classlib1.DataSets.SeeCommonDataSetTableAdapters;
using nsoftware.IPWorks;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.Threading;
using System.Collections;
using System.Data;

namespace csi.see.service1
{
    public partial class ManageComm : Component
    {
        #region Constructor/Destructor
        public ManageComm()
        {
            InitializeComponent();
            construct();
        }
        public ManageComm(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            construct();
        }
        private void construct()
        {
            //ipportComm.Timeout = 1;
            ipportComm.Config("InBufferSize=17");	// 16 + linefeed
            ipportComm.Config("OutBufferSize=30");	// 29 + linefeed
            ipportComm.EOL = "\n";					// command responses must end with a linefeed
            ipportData.Config("InBufferSize=5000");
            OnError += new OnErrorDelegate(OnErrorHandler);
            _timerPOLL.Elapsed += new System.Timers.ElapsedEventHandler(timerPOLL_Elapsed);
            _timerPOLL.AutoReset = true;                                    
        }        
        //~ManageComm()
        //{ Disconnect(); }        
        #endregion

        /* public */
        #region static Members
        public static StatusEventArgs statDISCONNECTED = new StatusEventArgs(
            100, StatusEventArgs.NORMAL, "Disconnected");
        public static StatusEventArgs statREADY = new StatusEventArgs(
            110, StatusEventArgs.NORMAL, "Ready");
        //Polling
        public static StatusEventArgs statpCONNECT = new StatusEventArgs(
            101, StatusEventArgs.NORMAL, "Connecting on port 1...");
        public static StatusEventArgs statpLOGIN = new StatusEventArgs(
            101, StatusEventArgs.NORMAL, "Sending log in...");
        public static StatusEventArgs statpOPENDATA = new StatusEventArgs(
            101, StatusEventArgs.NORMAL, "Connecting on port 2...");
        public static StatusEventArgs statpHARTBEAT = new StatusEventArgs(
            101, StatusEventArgs.NORMAL, "Sending HARTBEAT...");
        public static StatusEventArgs statpISBLOKAL = new StatusEventArgs(
            101, StatusEventArgs.NORMAL, "Initializing IP data...");
        public static StatusEventArgs statpOPENCONSOLE = new StatusEventArgs(
            101, StatusEventArgs.NORMAL, "Connecting on port 3...");
        //Console
        public static StatusEventArgs statcSENDING_COMMAND = new StatusEventArgs(
           102, StatusEventArgs.NORMAL, "Sending...");
        public static StatusEventArgs statcEXECUTING_COMMAND = new StatusEventArgs(
           102, StatusEventArgs.NORMAL, "Executing Command...");
        #endregion
        #region Events
        public event OnErrorDelegate            OnError;
        //The following events should be handled elsewhere,
        //and are only thrown if an external handler is registered
        public event OnStatusDelegate           OnPollStatusChanged;
        public event OnStatusDelegate           OnConsoleStatusChanged;        
        public event OnReceivedDelegate         OnSeeVseStartupReceived;
        public event OnAllIpDataInDelegate      OnAllIpDataReceived;
        public event OnPollDataInDelegate       OnPollDataReceived;
        public event OnMultiReceivedDelegate    OnTcpIpTerminationReceived;
        public event OnMultiReceivedDelegate    OnFtpTerminationReceived;
        public event OnMultiReceivedDelegate    OnJobStepTerminationReceived;
        public event OnMultiReceivedDelegate    OnTcpIpMessageReceived;
        public event OnSentDelegate             OnCommandNotSent;
        public event OnSentDelegate             OnCommandSent;        
        public event OnReceivedDelegate         OnCommandProcessed;
        public event OnReceivedDelegate         OnTraceDataReceived;        
        #endregion
        #region Properties
        public string Name
        {
            get
            {
                if (_defRow != null) { return _defRow.Name; }
                else { return null; }
            }
        }
        public StatusEventArgs StatusPoll
        {
            get { return _statusPoll; }
            set
            {
                _statusPoll = value;
                if (OnPollStatusChanged != null && OnPollStatusChanged.GetInvocationList() != null)
                    OnPollStatusChanged(value);
            }
        }
        public StatusEventArgs StatusConsole
        {
            get { return _statusConsole; }
            set
            {
                _statusConsole = value;
                if (OnConsoleStatusChanged != null && OnConsoleStatusChanged.GetInvocationList() != null)
                    OnConsoleStatusChanged(value);
            }
        }        
        public bool IsPolling 
        { get { return _timerPOLL.Enabled; } }
        /// <summary>
        /// Get or set the Suspend property.  When true, the dispatcher is put
        /// into a suspended state and will not dispatch any new data to interested
        /// listeners.  The data from the server continues to be queued.  Otherwise,
        /// the dispatcher is ready to receive data from the server and forward it 
        /// on to any interested listeners.
        /// </summary>
        public bool SuspendConsole
        {
            get { return _suspend; }
            set { _suspend = value; }
        }
        public DateTime SessionStart
        { get { return _sessionStart; } }
        
        #endregion                
        #region Methods
        public void Startup(SeeCommonDataSet.SysDefsRow defRow)
        {
            _defRow = defRow;
            StatusPoll = statpCONNECT;
            try
            { ipportComm.Connect(defRow.IpAddress, defRow.Port); }
            catch (IPWorksException ipExc)
            { OnError(CommErrorType.Generic, "Port 1: " + ipExc.Message); }
        }
        public void GetTraceData()
        {
            //Debug.WriteLine("***GetTraceData()***");
            if (_POLLDATA.HandleDONE != null)//Needed to coordinate polls and traces
            { OnError(CommErrorType.TraceSkipped, "The server was busy. Couldn't get trace data."); }
            else
            {
                _POLLDATA.BytesExpectedTrace = -1;
                _POLLDATA.ClearQs();
                SendPollCommand(PollCommands.TRACIP01);
            }
        }
        public void GetAllIpData()
        {
            //Debug.WriteLine("***GetAllIps()***");
            if (_POLLDATA.HandleDONE != null)//Needed to coordinate polls and traces
            { OnError(CommErrorType.AllIpSkipped, "The server was busy. Couldn't get IP data."); 
              Thread.Sleep(3000);
              GetAllIpData();//Retry the ISBLOKAL command
            }
            else
            {
                _POLLDATA.BytesExpectedTrace = -1;
                _POLLDATA.ClearQs();
                SendPollCommand(PollCommands.ISBLOKAL);
            }
        }
        public void GetPollData()
        {
            //Debug.WriteLine("***RunPoll()***");
            if (_POLLDATA.HandleDONE != null)//Needed to coordinate polls and traces
            { OnError(CommErrorType.PollSkipped, "The server was busy. Couldn't get poll data."); }
            else
            {
                _commandQ.Clear();
                _commandQ.Enqueue(PollCommands.IVBLOK01);
                _commandQ.Enqueue(PollCommands.LKBLOK01);
                if (_defRow.monCpu) _commandQ.Enqueue(PollCommands.TDCPU001);
                if (_defRow.monJobs) _commandQ.Enqueue(PollCommands.GVVP1000);
                if (_defRow.monConns) _commandQ.Enqueue(PollCommands.CCBLOK02);
                if (_defRow.monIps) _commandQ.Enqueue(PollCommands.ISBLOK01);
                if (_defRow.monBSDC) _commandQ.Enqueue(PollCommands.RSOBLK01);
                _POLLDATA.BytesExpectedTrace = -1;
                _POLLDATA.ClearQs();
                SendPollCommand(PollCommands.SVSEINIT);	        // Start the poll, always send SVSEINIT
            }
        }
        public void StartPollTimer()
        {
            StopPollTimer();//Just in case
            _timerPOLL.Interval = _defRow.pollIntervalms;
            _timerPOLL.Start();
        }
        public void StopPollTimer()
        { if (_timerPOLL.Enabled) _timerPOLL.Stop(); }
        public void Disconnect()
        {
            StopPollTimer();
            if (ipportConsole.Connected) { ipportConsole.Disconnect(); }
            if (ipportData.Connected) { ipportData.Disconnect(); }
            if (ipportComm.Connected) { ipportComm.Disconnect(); }            
        }
        /// <summary>
        /// Send command to the server.
        /// </summary>
        /// <param name="data">Data to send to the server</param>
        public void SendTcpipCommand(String cmdTxt)
        {
            try
            {
                _tcpipCommandHandle = ThreadPool.RegisterWaitForSingleObject(
                        _eventCONSOLECOMMAND,                           //Register Wait Handle
                        new WaitOrTimerCallback(CallbackCONSOLECOMMAND),//Delegate/method to call when signaled
                        cmdTxt,                                         //Object passed to the delegate
                        msTcpipCommTimeout,                             //Timeout
                        true);
                StatusConsole = statcSENDING_COMMAND;
                ipportConsole.Send(BuildTcpIpCommand(cmdTxt));
                if (OnCommandSent != null && OnCommandSent.GetInvocationList() != null)
                    OnCommandSent(cmdTxt, DateTime.Now);
                StatusConsole = statcEXECUTING_COMMAND;
            }
            catch (nsoftware.IPWorks.IPWorksException ipExc)
            {
                if (OnCommandNotSent != null && OnCommandNotSent.GetInvocationList() != null)
                    OnCommandNotSent(ipExc.Message, DateTime.Now);
                StatusConsole = statREADY;
            }
        }
        #endregion

        /* private */
        #region Events
        private AutoResetEvent _eventRESPIN = new AutoResetEvent(false);
        private AutoResetEvent _eventCHECKDATA = new AutoResetEvent(false);
        private AutoResetEvent _eventALLIPSDONE = new AutoResetEvent(false);
        private AutoResetEvent _eventPOLLDONE = new AutoResetEvent(false);
        private AutoResetEvent _eventTRACEDONE = new AutoResetEvent(false);
        private AutoResetEvent _eventCONSOLECOMMAND = new AutoResetEvent(false);
        private RegisteredWaitHandle _tcpipCommandHandle;
        #endregion
        #region Constants
        private const int msRecheckData =       3000;   //3 sec
        private const int msResponseTimeout =   60000;  //1 min        
        private const int msAllIpsTimeout =     180000; //3 min
        private const int msPollTimeout =       180000; //3 min
        private const int msTraceTimeout =      180000; //3 min
        private const int msTcpipCommTimeout =  120000; //2 min 
        #endregion
        
        #region Members
        private SeeCommonDataSet.SysDefsRow _defRow;
        private DateTime _sessionStart;//Set when the startup record is received
        private System.Timers.Timer         _timerPOLL = new System.Timers.Timer();
        private byte[]                      _consoleToken;
        private string                      _bsdcPID;        
        private PollCommands                _currCommand;
        private Queue                       _commandQ = new Queue();        
        private ResponseState               _RESPONSE = new ResponseState();
        private PollDataState               _POLLDATA = new PollDataState();
        private ConsoleQueue    _queueConsole = new ConsoleQueue();
		private ArrayList       _TcpIpMessages = new ArrayList(30);
		private ArrayList       _FtpTerminationRecords = new ArrayList(30);
		private ArrayList       _ConnectionRecords = new ArrayList(30);
		private ArrayList       _JobStepRecords = new ArrayList(30);
        private bool            _suspend = false;
        
        private StatusEventArgs _statusPoll = statDISCONNECTED;
        private StatusEventArgs _statusConsole = statDISCONNECTED;       
        #endregion
        #region Methods
        /// <summary>
        /// Build a TCP/IP command to send to the server.
        /// </summary>        
        private byte[] BuildTcpIpCommand(string text)
        {
            byte[] command = new ASCIIEncoding().GetBytes(text + "\n");

            byte[] flags = new byte[4] { 0x54, 0x20, 0x20, 0x20 };
            int length = _consoleToken.Length + flags.Length + command.Length;
            byte[] lengthBE = System.BitConverter.GetBytes(Endian.Swap((uint)length));
            byte[] data = new byte[length + lengthBE.Length];
            int offset = 0;

            lengthBE.CopyTo(data, offset); offset += lengthBE.Length;
            _consoleToken.CopyTo(data, offset); offset += _consoleToken.Length;
            flags.CopyTo(data, offset); offset += flags.Length;
            command.CopyTo(data, offset);

            return data;
        }       
        /// <summary>
        /// Send the next poll command and register wait handles
        /// </summary>
        /// <param name="COMMAND"></param>
        private void SendPollCommand(PollCommands COMMAND)
        {
            _currCommand = COMMAND;
            string CmdTxt = "";
            #region
            switch (COMMAND)
            {
                case PollCommands.LOGIN:
                    CmdTxt = String.Format("LOGIN {0} {1}", _defRow.UserId, _defRow.Password) + "\n";
                    _RESPONSE.Handle = ThreadPool.RegisterWaitForSingleObject(
                        _eventRESPIN,                               //Register Wait Handle
                        new WaitOrTimerCallback(CallbackLOGIN),     //Delegate/method to call when signaled
                        COMMAND,                                    //Object passed to the delegate
                        msResponseTimeout,                          //Timeout
                        true);
                    break;
                case PollCommands.OPENDATA:
                    string verStr = "010500";
                    CmdTxt = "OPENDATA " + verStr + "\n";
                    _RESPONSE.Handle = ThreadPool.RegisterWaitForSingleObject(
                        _eventRESPIN,                               //Register Wait Handle
                        new WaitOrTimerCallback(CallbackOPENDATA),  //Delegate/method to call when signaled
                        COMMAND,                                    //Object passed to the delegate
                        msResponseTimeout,                          //Timeout
                        true);
                    break;
                case PollCommands.HARTBEAT:
                    CmdTxt = COMMAND.ToString() + "\n";
                    _RESPONSE.Handle = ThreadPool.RegisterWaitForSingleObject(
                        _eventRESPIN,                               //Register Wait Handle
                        new WaitOrTimerCallback(CallbackHARTBEAT),  //Delegate/method to call when signaled
                        COMMAND,                                    //Object passed to the delegate
                        msResponseTimeout,                          //Timeout
                        true);
                    break;
                case PollCommands.SVSEINIT:
                    CmdTxt = COMMAND.ToString() + "\n";
                    break;
                default:
                    CmdTxt = "GETDATA " + COMMAND.ToString() + "\n";
                    break;
            }
            #endregion
            if (COMMAND != PollCommands.LOGIN && COMMAND != PollCommands.OPENDATA && COMMAND != PollCommands.HARTBEAT)
            {
                if (COMMAND == PollCommands.TRACIP01)
                {
                    _POLLDATA.HandleDONE = ThreadPool.RegisterWaitForSingleObject(
                        _eventTRACEDONE,                           //Register Wait Handle
                        new WaitOrTimerCallback(CallbackTRACEDONE),//Delegate/method to call when signaled
                        COMMAND,                                    //Object passed to the delegate
                        msTraceTimeout,                            //Timeout
                        true);
                }
                else if (COMMAND == PollCommands.ISBLOKAL)
                {
                    _POLLDATA.HandleDONE = ThreadPool.RegisterWaitForSingleObject(
                        _eventALLIPSDONE,                           //Register Wait Handle
                        new WaitOrTimerCallback(CallbackALLIPSDONE),//Delegate/method to call when signaled
                        COMMAND,                                    //Object passed to the delegate
                        msAllIpsTimeout,                            //Timeout
                        true);
                }
                else
                {
                    _POLLDATA.HandleDONE = ThreadPool.RegisterWaitForSingleObject(
                        _eventPOLLDONE,                             //Register Wait Handle
                        new WaitOrTimerCallback(CallbackPOLLDONE),  //Delegate/method to call when signaled
                        COMMAND,                                    //Object passed to the delegate
                        msPollTimeout,                              //Timeout
                        true);
                }
            }

            if (ipportComm.Connected)
            {
                ipportComm.Send(Encoding.ASCII.GetBytes(CmdTxt));
                //Debug.WriteLine("Command Sent: " + COMMAND.ToString());
            }
        }
        /// <summary>
        /// Checks the first four bytes for the total Trace Length 
        /// Stores the length in _POLLDATA object and Enqueues all bytes
        /// </summary>
        /// <param name="blok">the bytes that contain the Trace Length, plus possible overflow</param>
        /// <returns>-1 if less than four bytes have been received, otherwise the length of the trace data</returns>
        private long StoreTraceLength(byte[] newBlok)
        {
            byte[] blok;
            if (_POLLDATA.DataQ.Count == 1)//get the previous blok, should never be greater than 1
            {//Combine into 1 blok
                byte[] prevBlok = (byte[])_POLLDATA.DataQ.Dequeue();
                int len = prevBlok.Length + newBlok.Length;
                blok = new byte[len];
                int i = 0;
                for (i = 0; i < prevBlok.Length; i++)
                { blok[i] = prevBlok[i]; }
                for (i = prevBlok.Length; i < len; i++)
                { blok[i] = newBlok[i]; }
            }
            else { blok = newBlok; }

            long traceLen = -1;
            if (blok.Length >= 4)
            {
                RawDataConverter converter = new RawDataConverter();
                traceLen = (long)converter.GetUINT32(0, blok);
            }
            _POLLDATA.DataQ.Enqueue(blok);
            return traceLen;
        }
        #endregion        
        #region Event Handlers (ipport)
        private void ipportComm_OnConnected(object sender, nsoftware.IPWorks.IpportConnectedEventArgs e)
        {
            //Debug.WriteLine(_defRow.Name +"\tPort 1: " + e.StatusCode.ToString() + ": " + e.Description);
            if (e.StatusCode != 0)
            {
                StatusPoll = statDISCONNECTED;
                OnError(CommErrorType.Port1, e.Description); 
            }                        
        }
        private void ipportComm_OnReadyToSend(object sender, nsoftware.IPWorks.IpportReadyToSendEventArgs e)
        {
            StatusPoll = statpLOGIN;
            SendPollCommand(PollCommands.LOGIN);
        }
        private void ipportComm_OnDisconnected(object sender, nsoftware.IPWorks.IpportDisconnectedEventArgs e)
        {
            StopPollTimer();//Just in case
            if (_defRow.monOn) { StatusPoll = statDISCONNECTED; }
            if (e.StatusCode != 0)
            { OnError(CommErrorType.Port1Disc, e.Description); }            
        }
        private void ipportComm_OnDataIn(object sender, nsoftware.IPWorks.IpportDataInEventArgs e)
        {
            //Debug.WriteLine(e.Text);
            if (_RESPONSE.Handle != null)//LOGIN, OPENDATA, HARTBEAT
            {
                _RESPONSE.e = e;
                _eventRESPIN.Set();//Execute the waiting method
            }
            else if (e.Text.StartsWith("FAIL") && _currCommand == PollCommands.TRACIP01)//Trace Failed
            {
                if (_POLLDATA.HandleWAIT != null) { _POLLDATA.HandleWAIT.Unregister(null); _POLLDATA.HandleWAIT = null; }// Stop future execution of the callback method
                if (_POLLDATA.HandleDONE != null) { _POLLDATA.HandleDONE.Unregister(null); _POLLDATA.HandleDONE = null; }// Stop future execution of the callback method 
                _POLLDATA.ClearQs();
                string description = "Capture failed! ";
                switch (e.Text)
                {
                    case "FAILTRACTDNZFAIL": description += "The buffer is not full.";
                        break;
                    default: description += e.Text;
                        break;
                }
                OnError(CommErrorType.TraceError, description);
            }
            else if (e.Text.StartsWith("FAIL") && _currCommand == PollCommands.ISBLOKAL)//AllIPs Failed
            {
                //switch(e.Text)
                //{
                    //case "FAILGISAZISBFAIL"://There are no ISBLOKs
                        //_eventALLIPSDONE.Set();//Proceed
                        //break;
                    //default://Try again
                        if (_POLLDATA.HandleWAIT != null) { _POLLDATA.HandleWAIT.Unregister(null); _POLLDATA.HandleWAIT = null; }// Stop future execution of the callback method
                        if (_POLLDATA.HandleDONE != null) { _POLLDATA.HandleDONE.Unregister(null); _POLLDATA.HandleDONE = null; }// Stop future execution of the callback method 
                        OnError(CommErrorType.PollCommand, "GetAllIPs failed! ("+e.Text+") Retrying...");
                        Thread.Sleep(30000);//delay                
                        GetAllIpData();//Retry the ISBLOKAL command
                        //break;
                //}                                            
            }
            else//GOOD POLL COMMAND, ISBLOKAL, OR TRACIP01, OR FAIL POLL COMMAND
            {
                //Ignore FAIL responses
                if (e.Text.StartsWith("GOOD") && e.Text.EndsWith("GOOD") && e.Text.Substring(8, 4) != "DONE")//Store the values
                {
                    CommandResponse response = new CommandResponse();
                    response.Text = _currCommand.ToString();
                    response.Count = Convert.ToInt32(e.Text.Substring(4, 4), 10);
                    response.Length = Convert.ToInt32(e.Text.Substring(8, 4), 10);
                    _POLLDATA.GoodQ.Enqueue(response);
                }
                else
                {
                    if (_RESPONSE.e.Text.Substring(4, 2) == "GR" && _RESPONSE.e.Text.StartsWith("GOOD"))//Store the BSDC PID
                    { _bsdcPID = _RESPONSE.e.Text.Substring(6, 2); }

                    //This will cause the callback method to run every 2 seconds
                    _POLLDATA.HandleWAIT = ThreadPool.RegisterWaitForSingleObject(
                                _eventCHECKDATA,                             //Register Wait Handle
                                new WaitOrTimerCallback(CallbackCHECKDATA),  //Delegate/method to call when signaled
                                null,                                        //Object passed to the delegate
                                msRecheckData,                               //Timeout
                                false);

                    _eventCHECKDATA.Set();//Check now                        
                }
            }
        }

        private void ipportData_OnConnected(object sender, nsoftware.IPWorks.IpportConnectedEventArgs e)
        {
            //Debug.WriteLine(_defRow.Name + "\tPort 2: " + e.StatusCode.ToString() + ": " + e.Description);
            if (e.StatusCode == 700)
            {//Wait 5 seconds and retry
                Thread.Sleep(3000);
                ipportData.Connected = true;
            }
            else if (e.StatusCode != 0)
            { OnError(CommErrorType.Port2, e.Description); }            
        }
        private void ipportData_OnReadyToSend(object sender, nsoftware.IPWorks.IpportReadyToSendEventArgs e)
        {
            StatusPoll = statpHARTBEAT;
            SendPollCommand(PollCommands.HARTBEAT);
        }
        private void ipportData_OnDisconnected(object sender, nsoftware.IPWorks.IpportDisconnectedEventArgs e)
        {
            if (e.StatusCode != 0)
            { OnError(CommErrorType.Port2Disc, e.Description); }                                   
        }
        private void ipportData_OnDataIn(object sender, nsoftware.IPWorks.IpportDataInEventArgs e)
        {
            if (_currCommand == PollCommands.TRACIP01 && _POLLDATA.BytesExpectedTrace == -1)
            { _POLLDATA.BytesExpectedTrace = StoreTraceLength(e.TextB); }
            else
            { _POLLDATA.DataQ.Enqueue(e.TextB); }
        }

        private void ipportConsole_OnConnected(object sender, IpportConnectedEventArgs e)
        {
            //Debug.WriteLine(_defRow.Name + "\tPort 3: " + e.StatusCode.ToString() + ": " + e.Description);
            if (e.StatusCode == 700)
            {//Wait 5 seconds and retry
                Thread.Sleep(3000);
                ipportConsole.Connected = true;
            }
            else if (e.StatusCode != 0)
            { OnError(CommErrorType.Port3, e.Description); }
        }
        private void ipportConsole_OnReadyToSend(object sender, IpportReadyToSendEventArgs e)
        {
            StatusConsole = statREADY;                                     
        }        
        private void ipportConsole_OnDisconnected(object sender, IpportDisconnectedEventArgs e)
        {
            StatusConsole = statDISCONNECTED;
            if (e.StatusCode != 0)
            { OnError(CommErrorType.Port3Disc, e.Description); }
        }
        private void ipportConsole_OnDataIn(object sender, IpportDataInEventArgs e)
        {
            _queueConsole.Enqueue(e.TextB);
            if (_suspend == true)// Do not fire received events (they will be accumulated).
                return;

            _TcpIpMessages.Clear();
            _ConnectionRecords.Clear();
            _FtpTerminationRecords.Clear();
            _JobStepRecords.Clear();
            RawDataConverter converter = new RawDataConverter();
            byte[] record;
            while ((record = (byte[])_queueConsole.Dequeue()) != null)
            {
                int type = converter.GetINT32(4, record);
                switch (type)
                {
                    case 1:
                        _sessionStart = converter.GetDTutc(16, record).AddSeconds(_defRow.UtcOffset);
                        if (OnSeeVseStartupReceived != null && OnSeeVseStartupReceived.GetInvocationList() != null)                            
                            OnSeeVseStartupReceived(record, _defRow.UtcOffset);
                        StatusPoll = statpISBLOKAL;
                        GetAllIpData();
                        break;
                    case 2: _FtpTerminationRecords.Add(record);
                        break;
                    case 3: _TcpIpMessages.Add(record);
                        break;
                    case 4: _ConnectionRecords.Add(record);
                        break;
                    case 5: _JobStepRecords.Add(record);
                        break;
                    default://Must be a command response
                        _eventCONSOLECOMMAND.Set();//Cancel the timeout
                        if (OnCommandProcessed != null && OnCommandProcessed.GetInvocationList() != null)
                            OnCommandProcessed(record, _defRow.UtcOffset);
                        break;
                }
            }
            if (_TcpIpMessages.Count > 0 && OnTcpIpMessageReceived != null && OnTcpIpMessageReceived.GetInvocationList() != null)
                OnTcpIpMessageReceived(new ArrayList(_TcpIpMessages), _defRow.UtcOffset);
            //should I let these accumulate?
            if (_FtpTerminationRecords.Count > 0 && OnFtpTerminationReceived != null && OnFtpTerminationReceived.GetInvocationList() != null)
                OnFtpTerminationReceived(new ArrayList(_FtpTerminationRecords), _defRow.UtcOffset);
            if (_ConnectionRecords.Count > 0 && OnTcpIpTerminationReceived != null && OnTcpIpTerminationReceived.GetInvocationList() != null)
                OnTcpIpTerminationReceived(new ArrayList(_ConnectionRecords), _defRow.UtcOffset);
            if (_JobStepRecords.Count > 0 && OnJobStepTerminationReceived != null && OnJobStepTerminationReceived.GetInvocationList() != null)
                OnJobStepTerminationReceived(new ArrayList(_JobStepRecords), _defRow.UtcOffset);
            
        }        

        #endregion
        #region Event Handlers
        private void timerPOLL_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        { GetPollData(); }        
        private void CallbackLOGIN(object state, bool timedOut)
        {
            if (_RESPONSE.Handle != null) { _RESPONSE.Handle.Unregister(null); _RESPONSE.Handle = null; }// Stop future execution of the callback method
            if (timedOut) { OnError(CommErrorType.Init, "LOGIN: Timed Out."); }
            else
            {
                //Stores the ConsoleToken
                if (_RESPONSE.e.Text.StartsWith("GOOD") && _RESPONSE.e.Text.EndsWith("GOOD"))
                {
                    if (_RESPONSE.e.Text[11] == '0')//User can not have the console
                    { _consoleToken = null; }
                    else
                    {//Save the Console Token
                        _consoleToken = new byte[4];
                        _consoleToken[0] = _RESPONSE.e.TextB[8];
                        _consoleToken[1] = _RESPONSE.e.TextB[9];
                        _consoleToken[2] = _RESPONSE.e.TextB[10];
                        _consoleToken[3] = _RESPONSE.e.TextB[11];
                    }
                    StatusPoll = statpOPENDATA;
                    SendPollCommand(PollCommands.OPENDATA);
                }
                else
                {
                    string loginMess = "Login failed! ";
                    switch (_RESPONSE.e.Text.Substring(4, 8))
                    {
                        case "LGINSAIN":
                            loginMess+= "User already logged in.";
                            break;
                        case "LGINALGI":
                            loginMess+= "User already logged in.";
                            break;
                        default:
                            loginMess+= _RESPONSE.e.Text.Substring(4, 8);
                            break;
                    }
                    OnError(CommErrorType.Login, loginMess);
                }                
            }
        }
        private void CallbackOPENDATA(object state, bool timedOut)
        {
            if (_RESPONSE.Handle != null) { _RESPONSE.Handle.Unregister(null); _RESPONSE.Handle = null; }// Stop future execution of the callback method
            if (timedOut) { OnError(CommErrorType.Init, "OPENDATA: Timed Out."); }
            else
            {
                //Connects to the data port
                if (_RESPONSE.e.Text.StartsWith("GOOD") && _RESPONSE.e.Text.EndsWith("GOOD"))
                {
                    try
                    {// Try to connect to the data port
                        int dataport = Convert.ToInt32(_RESPONSE.e.Text.Substring(4, 8), 16);
                        ipportData.Connect(ipportComm.RemoteHost, dataport);
                    }
                    catch (Exception exc)
                    { OnError(CommErrorType.Generic, "Port 2: " + exc.Message); }                                        
                }
                else if (_RESPONSE.e.Text.StartsWith("FAIL"))
                { OnError(CommErrorType.Init, "OPENDATA: " + _RESPONSE.e.Text); }                
            }
        }
        private void CallbackHARTBEAT(object state, bool timedOut)
        {
            if (_RESPONSE.Handle != null) { _RESPONSE.Handle.Unregister(null); _RESPONSE.Handle = null; }// Stop future execution of the callback method
            if (timedOut) { OnError(CommErrorType.Init, "HARTBEAT: Timed Out."); }
            else
            {
                if (_RESPONSE.e.Text.StartsWith("GOOD") && _RESPONSE.e.Text.EndsWith("GOOD"))
                {
                    int utcOff = Convert.ToInt32(_RESPONSE.e.Text.Substring(4, 8), 16);
                    if (_defRow.UtcOffset != utcOff)
                    {
                        _defRow.UtcOffset = utcOff;
                        SysDefsTableAdapter DefsAdapter = new SysDefsTableAdapter();
                        DefsAdapter.Update(_defRow);
                        //OnUtcOffsetChanged(utcOff);//Throws an event if the utc offset changes
                    }
                    StatusPoll = statpOPENCONSOLE;
                    try
                    { ipportConsole.Connect(ipportComm.RemoteHost, ipportComm.RemotePort - 2); }
                    catch (IPWorksException ipExc)
                    { OnError(CommErrorType.Generic, "Port 3: " + ipExc.Message); }                    
                }
                else if (_RESPONSE.e.Text.StartsWith("FAIL"))
                { OnError(CommErrorType.Init, "HARTBEAT: " + _RESPONSE.e.Text); }                
            }
        }
        
        private void CallbackCHECKDATA(object state, bool timedOut)
        {
            //if (timedOut) { Debug.WriteLine("CallbackCHECKDATA - TIMED OUT"); }
            //else { Debug.WriteLine("CallbackCHECKDATA - SIGNALED"); }

            if (_POLLDATA.BytesExpected>0 && _POLLDATA.BytesExpected == _POLLDATA.BytesReceived)
            {
                if (_currCommand == PollCommands.TRACIP01) { _eventTRACEDONE.Set(); }
                else if (_currCommand == PollCommands.ISBLOKAL) { _eventALLIPSDONE.Set(); }
                else { _eventPOLLDONE.Set(); }
            }
            else if (_POLLDATA.BytesExpected < _POLLDATA.BytesReceived)
            {
                if (_POLLDATA.HandleWAIT != null) { _POLLDATA.HandleWAIT.Unregister(null); _POLLDATA.HandleWAIT = null; }// Stop future execution of the callback method
                if (_POLLDATA.HandleDONE != null) { _POLLDATA.HandleDONE.Unregister(null); _POLLDATA.HandleDONE = null; }// Stop future execution of the callback method
                _POLLDATA.ClearQs();
                OnError(CommErrorType.Poll, "Data Overflow");
            }
            //check for more data every 2 seconds
        }
        private void CallbackALLIPSDONE(object state, bool timedOut)
        {
            if (_POLLDATA.HandleWAIT != null) { _POLLDATA.HandleWAIT.Unregister(null); _POLLDATA.HandleWAIT = null; }// Stop future execution of the callback method
            if (_POLLDATA.HandleDONE != null) { _POLLDATA.HandleDONE.Unregister(null); _POLLDATA.HandleDONE = null; }// Stop future execution of the callback method        
            //PollCommands COMMAND = (PollCommands)state;
            if (timedOut) { OnError(CommErrorType.Init, "ISBLOKAL: Timed Out."); }
            else
            {
                RawDataSet.ISBLOKDataTable rawTable = _POLLDATA.ProcessAllIps(_defRow.UtcOffset);
                
                if (OnAllIpDataReceived != null && OnAllIpDataReceived.GetInvocationList() != null)
                    OnAllIpDataReceived(rawTable);//The Poll Time should be set to the time sent with the Startup Record
                StatusPoll = statREADY;
                StartPollTimer();
                GetPollData();
            }
        }
        private void CallbackPOLLDONE(object state, bool timedOut)
        {
            if (_POLLDATA.HandleWAIT != null) { _POLLDATA.HandleWAIT.Unregister(null); _POLLDATA.HandleWAIT = null; }// Stop future execution of the callback method
            if (_POLLDATA.HandleDONE != null) { _POLLDATA.HandleDONE.Unregister(null); _POLLDATA.HandleDONE = null; }// Stop future execution of the callback method        
            //PollCommands COMMAND = (PollCommands)state;
            if (timedOut) { OnError(CommErrorType.Poll, "Poll : Timed Out."); }
            else
            {
                //Debug.WriteLine("CallbackPOLLDONE - SIGNALED");
                if (_commandQ.Count > 0)//Send the next command
                { SendPollCommand((PollCommands)_commandQ.Dequeue()); }
                else
                {
                    DateTime time;
                    RawDataSet rawData = _POLLDATA.ProcessData(out time, _defRow.UtcOffset);
                    //Debug.WriteLine(_defRow.Name + ": OnDataIn_POLLDATA");
                    if (OnPollDataReceived != null && OnPollDataReceived.GetInvocationList() != null)
                    OnPollDataReceived(rawData, time, _bsdcPID);
                }
            }
        }
        private void CallbackTRACEDONE(object state, bool timedOut)
        {
            if (_POLLDATA.HandleWAIT != null) { _POLLDATA.HandleWAIT.Unregister(null); _POLLDATA.HandleWAIT = null; }// Stop future execution of the callback method
            if (_POLLDATA.HandleDONE != null) { _POLLDATA.HandleDONE.Unregister(null); _POLLDATA.HandleDONE = null; }// Stop future execution of the callback method        
            //PollCommands COMMAND = (PollCommands)state;
            if (timedOut) { OnError(CommErrorType.TraceError, "Capture Failed! Timed Out."); }
            else
            {
                byte[] data = _POLLDATA.ProcessTrace(_defRow.UtcOffset);
                OnTraceDataReceived(data, _defRow.UtcOffset);
            }
        }
        private void CallbackCONSOLECOMMAND(object state, bool timedOut)
        {
            if (_tcpipCommandHandle != null) { _tcpipCommandHandle.Unregister(null); _tcpipCommandHandle = null; }// Stop future execution of the callback method        
            //string command = (string)state;
            StatusConsole = statREADY;
            if (timedOut) { OnError(CommErrorType.ConsoleComm, "Timed Out."); }
            //Responses are handled elsewhere
        }
        #endregion
        
        private void OnErrorHandler(CommErrorType type, string description)
        { Debug.WriteLine(Name + "\t_OnError\t" + type.ToString() + ": " + description); 
           //handle error elsewhere...
        }
        
    }

    public class ResponseState
    {
        public ResponseState(){}
        
        public RegisteredWaitHandle Handle;
        public IpportDataInEventArgs e;
    }   
    public class PollDataState
    {
        public PollDataState(){}
        
        public RegisteredWaitHandle HandleWAIT;
        public RegisteredWaitHandle HandleDONE;
        public Queue GoodQ = new Queue();
        public Queue DataQ = new Queue();
        public long BytesExpectedTrace = -1;
        public long BytesExpected
        {
            get
            {
                if (BytesExpectedTrace > -1) { return BytesExpectedTrace; }
                else
                {
                    long total = 0;
                    foreach (CommandResponse response in GoodQ)
                    {
                        long bytes = response.Count * response.Length;
                        total += bytes;
                    }
                    return total;
                }
            }
        }
        public long BytesReceived
        {
            get
            {
                long total = 0;
                foreach (byte[] array in DataQ)
                {
                    long bytes = array.LongLength;
                    total += bytes;
                }
                return total;
            }
        }
        
        public void ClearQs()
        {
            GoodQ.Clear();
            DataQ.Clear();
        }

        public byte[] ProcessTrace(int utcOffset)
        {
            CommandResponse response = (CommandResponse)GoodQ.Dequeue();//There should be one response
            byte[] rawData = new byte[BytesExpectedTrace];
            long allPos = 0;				//Keep track of position
            while (DataQ.Count > 0)	        //Copy all data into one array
            {
                byte[] bytes = (byte[])DataQ.Dequeue();
                bytes.CopyTo(rawData, allPos);
                allPos += bytes.Length;
            }

            /*RawDataConverter converter = new RawDataConverter();
            start = converter.GetDTutc(4, rawData);
            start = start.AddSeconds(Convert.ToDouble(utcOffset));
            int offsetEnd = (int)(BytesExpectedTrace-8);
            end = converter.GetDTutc(offsetEnd, rawData);
            end = end.AddSeconds(Convert.ToDouble(utcOffset));*/

            byte[] traceData = new byte[rawData.Length - 4];//4 length
            for (int i = 0; i < traceData.Length; i++)
            { traceData[i] = rawData[i + 4]; }//Skip the first 12

            return traceData;
        }
        public RawDataSet.ISBLOKDataTable ProcessAllIps(int utcOffset)
        {
            byte[] rawData = new byte[BytesReceived];
            long allPos = 0;				//Keep track of position
            #region Copy all data into one array
            while (DataQ.Count > 0)
            {
                byte[] bytes = (byte[])DataQ.Dequeue();
                bytes.CopyTo(rawData, allPos);
                allPos += bytes.Length;
            }
            #endregion
            ArrayList ISbloks = new ArrayList();
            allPos = 0;//Reset position in rawData
            #region Split data into bloks
            while (GoodQ.Count > 0)
            {
                CommandResponse response = (CommandResponse)GoodQ.Dequeue();
                if(response.Text == "ISBLOKAL")//Just in case, should never be anything else
                {
                    for (int blokCnt = 0; blokCnt < response.Count; blokCnt++)
                    {
                        byte[] blok = new byte[response.Length];
                        for (int blokPos = 0; blokPos < blok.Length; blokPos++)
                        {
                            blok[blokPos] = rawData[allPos];
                            allPos++;
                        }
                        ISbloks.Add(blok);
                    }
                }
            }
            #endregion
            RawDataSet.ISBLOKDataTable ipTable = new RawDataSet.ISBLOKDataTable();
            #region Add rows to the data table
            foreach (byte[] blok in ISbloks)
            {
                DataRow drow = ipTable.NewRow();
                FillRawRow("ISBLOK", blok, drow, Convert.ToDouble(utcOffset), 'E');//Force version E since we don't have and SVSEINIT yet                
                ipTable.Rows.Add(drow);
            }
            #endregion
            return ipTable;                        
        }
        public RawDataSet ProcessData(out DateTime pollTime, int utcOffset)
        {
            byte[] rawData = new byte[BytesReceived];
            long allPos = 0;				//Keep track of position
            #region Copy all data into one array
            while (DataQ.Count > 0)
            {
                byte[] bytes = (byte[])DataQ.Dequeue();
                bytes.CopyTo(rawData, allPos);
                allPos += bytes.Length;
            }
            #endregion
            byte[] SVblok = null;//null means no data
            byte[] IVblok = null;
            ArrayList LKbloks = new ArrayList();
            ArrayList TDbloks = new ArrayList();
            ArrayList GVbloks = new ArrayList();
            ArrayList CCbloks = new ArrayList();            
            ArrayList ISbloks = new ArrayList();
            ArrayList RSbloks = new ArrayList();
            allPos = 0;//Reset position in rawData
            #region Split data into bloks
            int blokPos = 0;//Position in current blok
            while (GoodQ.Count > 0)
            {
                CommandResponse response = (CommandResponse)GoodQ.Dequeue();
                switch (response.Text)
                {
                    case "SVSEINIT":
                        SVblok = new byte[response.Length];
                        for (blokPos = 0; blokPos < SVblok.Length; blokPos++)
                        {
                            SVblok[blokPos] = rawData[allPos];
                            allPos++;
                        }                        
                        break;
                    case "IVBLOK01":
                        IVblok = new byte[response.Length];
                        for (blokPos = 0; blokPos < IVblok.Length; blokPos++)
                        {
                            IVblok[blokPos] = rawData[allPos];
                            allPos++;
                        }
                        break;
                    default://multiple bloks
                        for (int i = 0; i < response.Count; i++)
                        {
                            byte[] blok = new byte[response.Length];
                            for (blokPos = 0; blokPos < blok.Length; blokPos++)
                            {
                                blok[blokPos] = rawData[allPos];
                                allPos++;
                            }
                            #region Add the blok to the proper collection
                            switch (response.Text)
                            {
                                case "LKBLOK01": LKbloks.Add(blok);
                                    break;
                                case "TDCPU001": TDbloks.Add(blok);
                                    break;
                                case "GVVP1000": GVbloks.Add(blok);
                                    break;
                                case "CCBLOK02": CCbloks.Add(blok);
                                    break;
                                case "ISBLOK01": ISbloks.Add(blok);
                                    break;
                                case "RSBLOK01": RSbloks.Add(blok);
                                    break;
                            }
                            #endregion
                        }
                        break;                    
                }                
            }
            #endregion
            RawDataSet pollDataset = new RawDataSet();
            RawDataConverter vseConvert = new RawDataConverter();
            /* pollTime for all data rows is set to the INIT time from SVSEINIT command */
            double utcOff = Convert.ToDouble(utcOffset);//use this to convert any other STCKs
            pollTime = vseConvert.GetDTutc((int)offSVSEINIT.SINTSTCK, SVblok).AddSeconds(utcOff);
            string version = vseConvert.GetEBCDIC((int)offSVSEINIT.SINTIVER, SVblok, 8).Trim();
            char[] verchars = version.ToCharArray();
            char ver = 'E';//force to E temporarily
            //char ver = verchars[verchars.Length - 1];//Use this to use different BLOK definitions(i.e. CCBLOK.CCPHASE)
            #region Add rows to the dataset
            #region SVSEINIT
            DataRow SVdrow = pollDataset.SVSEINIT.NewRow();
            SVdrow["Poll Time"] = pollTime;
            FillRawRow("SVSEINIT", SVblok, SVdrow, utcOff, ver);
            pollDataset.SVSEINIT.Rows.Add(SVdrow);
            #endregion
            #region IVBLOK
            DataRow IVdrow = pollDataset.IVBLOK.NewRow();
            IVdrow["Poll Time"] = pollTime;
            FillRawRow("IVBLOK", IVblok, IVdrow, utcOff, ver);
            pollDataset.IVBLOK.Rows.Add(IVdrow);
            #endregion
            #region LKBLOK
            foreach (byte[] block in LKbloks)
            {
                DataRow drow = pollDataset.LKBLOK.NewRow();
                drow["Poll Time"] = pollTime;
                FillRawRow("LKBLOK", block, drow, utcOff, ver);
                pollDataset.LKBLOK.Rows.Add(drow);
            }
            #endregion
            #region TDCPU
            foreach (byte[] block in TDbloks)
            {
                DataRow drow = pollDataset.TDCPU.NewRow();
                drow["Poll Time"] = pollTime;
                FillRawRow("TDCPU", block, drow, utcOff, ver);
                pollDataset.TDCPU.Rows.Add(drow);
            }
            #endregion
            #region GVVP
            foreach (byte[] block in GVbloks)
            {
                DataRow drow = pollDataset.GVVP.NewRow();
                drow["Poll Time"] = pollTime;
                FillRawRow("GVVP", block, drow, utcOff, ver);
                pollDataset.GVVP.Rows.Add(drow);
            }
            #endregion
            #region CCBLOK
            foreach (byte[] block in CCbloks)
            {
                DataRow drow = pollDataset.CCBLOK.NewRow();
                drow["Poll Time"] = pollTime;
                FillRawRow("CCBLOK", block, drow, utcOff, ver);
                pollDataset.CCBLOK.Rows.Add(drow);
            }
            #endregion            
            #region ISBLOK
            foreach (byte[] block in ISbloks)
            {
                DataRow drow = pollDataset.ISBLOK.NewRow();
                drow["Poll Time"] = pollTime;
                FillRawRow("ISBLOK", block, drow, utcOff, ver);
                pollDataset.ISBLOK.Rows.Add(drow);
            }
            #endregion
            #region RSBLOK
            foreach (byte[] block in RSbloks)
            {
                DataRow drow = pollDataset.RSBLOK.NewRow();
                drow["Poll Time"] = pollTime;
                FillRawRow("RSBLOK", block, drow, utcOff, ver);
                pollDataset.RSBLOK.Rows.Add(drow);
            }
            #endregion
            #endregion
            return pollDataset;
        }
        private void FillRawRow(string tablename, byte[] rowblok, DataRow drow, double utcOffset, char ver)
        {
            RawDataManager dataMgr = new RawDataManager();
            RawDataConverter dataConv = new RawDataConverter();
            ArrayList fields = null;
            #region Set the field parameters
            switch (tablename)
            {
                case "SVSEINIT":
                    fields = dataMgr.MakeFieldsSVSEINIT();
                    break;
                case "IVBLOK":
                    fields = dataMgr.MakeFieldsIVBLOK();
                    break;
                case "TDCPU":
                    fields = dataMgr.MakeFieldsTDCPU();
                    break;
                case "GVVP":
                    fields = dataMgr.MakeFieldsGVVP();
                    break;
                case "CCBLOK":
                    fields = dataMgr.MakeFieldsCCBLOK(ver);
                    break;
                case "LKBLOK":
                    fields = dataMgr.MakeFieldsLKBLOK();
                    break;
                case "ISBLOK":
                    fields = dataMgr.MakeFieldsISBLOK();
                    break;
                case "RSBLOK":
                    fields = dataMgr.MakeFieldsRSBLOK();
                    break;
            }
            #endregion
            #region Set the field arrays
            int[] fosets = (int[])fields[0];					// Get the array of field offsets
            RawDataTypes[] ftypes = (RawDataTypes[])fields[1];		// Get the array of field types
            int[] flengths = (int[])fields[2];					// Get the array of field lengths
            string[] fnames = (string[])fields[4];				// Get the array of internal(column) names
            #endregion
            #region Put the data into the rows
            int fcnt = 0;
            foreach (string fname in fnames)	// Set all other column values
            {
                switch (ftypes[fcnt])
                {
                    case RawDataTypes.STCK:
                        DateTime utcDT = dataConv.GetDTutc((int)fosets[fcnt], rowblok);
                        DateTime vseDT = utcDT.AddSeconds(utcOffset);
                        drow[fname] = vseDT;
                        break;
                    case RawDataTypes.BYTE:
                        drow[fname] = dataConv.GetBYTE((int)fosets[fcnt], rowblok);
                        break;
                    case RawDataTypes.UINT16:
                        drow[fname] = dataConv.GetUINT16((int)fosets[fcnt], rowblok);
                        break;
                    case RawDataTypes.UINT32:
                        drow[fname] = dataConv.GetUINT32((int)fosets[fcnt], rowblok);
                        break;
                    case RawDataTypes.UINT64:
                        drow[fname] = dataConv.GetUINT64((int)fosets[fcnt], rowblok);
                        break;
                    case RawDataTypes.INT32:
                        drow[fname] = dataConv.GetINT32((int)fosets[fcnt], rowblok);
                        break;
                    case RawDataTypes.EBCDIC:
                        drow[fname] = dataConv.GetEBCDIC((int)fosets[fcnt], rowblok, flengths[fcnt]);
                        break;
                    case RawDataTypes.HEX:
                        drow[fname] = dataConv.GetHEX((int)fosets[fcnt], rowblok, flengths[fcnt]);
                        break;
                    case RawDataTypes.IPADDR:
                        drow[fname] = dataConv.GetIPAD((int)fosets[fcnt], rowblok);
                        break;
                    case RawDataTypes.CPUID:
                        drow[fname] = dataConv.GetCPUID((int)fosets[fcnt], rowblok);
                        break;
                    case RawDataTypes.VRM:
                        drow[fname] = dataConv.GetVRM((int)fosets[fcnt], rowblok);
                        break;
                    default:
                        break;
                }
                fcnt++;
            }
            #endregion
        }
    }
    /// <summary>
    /// Represents a FIFO (first in - first out) queue to store variable length 
    /// records sent from a VSE record server.  The header for a record adheres
    /// to the following format:
    /// 
    /// 0000	SEELGREC DSECT
    ///	0000	SEELRECL DS		H			Record length, includes this field
    ///	0002			 DS		XL2			Reserved
    ///	0004	SEELGTYP DS		F			Record type
    ///	0008	SEELGEYE DS		CL4			Eye catcher (SVSE)
    ///	000A			 DS		XL2			Reserved
    ///	000C	SEELGVLN DS		H			Length of data in SEELGVDA area
    ///	0010	SEELGRHL EQU	*-SEELRECL	Length of record header
    ///	0010	SEELGVDA DS		0X			Start of variable data area
    ///		
    /// The variable data area SEELGVDA is unrestricted and can contain any data 
    /// in any format.  This generalized queue only recognizes record boundaries
    /// and makes no distinction to its actual contents.
    /// </summary>
    public class ConsoleQueue : ArrayList
    {
        #region MEMBER VARIABLES
        /// <summary>
        /// Length of the SEELRECL field (not the record length)
        /// </summary>
        private const int SEELRECL_LENGTH = 2;

        /// <summary>
        /// Converter used to convert the server records from EBCDIC-based to 
        /// ASCII-based. 
        /// </summary>
        private RawDataConverter converter;

        private int size;
        /// <summary>
        /// Get size property (in bytes) of the message queue. 
        /// </summary>
        public int Size
        {
            get { return size; }
        }
        #endregion

        #region CONSTRUCTORS AND DECONSTRUCTORS
        /// <summary>
        /// Create an instance of a generalized record queue.
        /// </summary>
        public ConsoleQueue()
        {
            converter = new RawDataConverter();
            size = 0; // Set initial size of the queue.
        }
        #endregion

        #region MEMBER METHODS
        /// <summary>
        /// Get the length of the next complete or partial record in the queue. 
        /// </summary>
        /// <returns>Record length if it can be determined; otherwise 0.</returns>	  
        private ushort GetRecordLength()
        {
            // When the size of the queue is less than the SEERECL_LENGTH, a
            // valid record length cannot be obtained.

            if (size < SEELRECL_LENGTH)
                return 0;

            // Peek the value of the next block from the queue.

            byte[] data = (byte[])this[0];

            // When the length of the block is less than the SEERECL_LENGTH, 
            // the block needs to be combined with the next block in the 
            // queue to obtain a valid record length.

            if (data.Length < SEELRECL_LENGTH)
            {
                byte[] block0 = (byte[])this[0];
                byte[] block1 = (byte[])this[1];
                data = new byte[block0.Length + block1.Length];
                block0.CopyTo(data, 0);
                block1.CopyTo(data, block0.Length);
                RemoveAt(0);
                this[0] = data;
            }

            return converter.GetUINT16(0, data);
        }

        /// <summary>
        /// Get the next complete record from the queue.
        /// </summary>
        /// <param name="length">Record length.</param>
        /// <returns>Record if it exists; otherwise null.</returns>

        private byte[] GetRecord()
        {
            int length = GetRecordLength();

            // Invalid record length - a record cannot be obtained.

            if (length <= 0)
                return null;

            // The entire record is currently not in the queue.

            if (size < length)
                return null;

            // A complete record has been determined to exist and can be built from 
            // the block entries in the queue.

            byte[] data = new byte[length];
            int i = 0;

            do
            {
                byte[] block = (byte[])this[0];

                // Remove the block and reduce the size of the queue.

                RemoveAt(0);
                size -= block.Length;

                // Add bytes from the block to complete the record.

                for (int j = 0; j < block.Length; i++, j++)
                {
                    if (i < length)
                        data[i] = block[j];
                    else
                    {
                        // More bytes exist in the block than needed to
                        // to complete the record.  A new block is created
                        // containing these extra bytes (part of the next
                        // record) and placed back on the front of the queue.

                        byte[] extra = new byte[block.Length - j];
                        for (int k = 0; k < extra.Length; j++, k++)
                            extra[k] = block[j];

                        if (extra.Length > 0)
                        {
                            Insert(0, extra);
                            size += extra.Length;
                        }
                    }
                }
            } while (i < length);

            return data;
        }

        /// <summary>
        /// Dequeue (get and remove) the next record from the message queue.
        /// </summary>
        /// <returns>Next record if one exists; otherwise null.</returns>
        public Object Dequeue()
        {
            return GetRecord();
        }

        /// <summary>
        /// Enqueue (add) a block of data that contains either a complete record, 
        /// multiple records or a partial record to the queue.
        /// </summary>
        /// <param name="data">Data to be added to the queue.</param>
        public void Enqueue(byte[] data)
        {
            Add(data);
            size += data.Length;
        }
        #endregion
    }
    /// <summary>
    /// Represents the details of a status event.
    /// </summary>
    public class StatusEventArgs
    {
        #region CONSTANTS
        public const int NORMAL = 0;
        public const int INFORMATION = 1;
        public const int WARNING = 5;
        public const int SEVERE = 10;
        #endregion

        #region Properties
        /// <summary>
        /// Get the code property.  The code can be used to identify a type
        /// of message even when the text is different
        /// </summary>
        private int code;
        public int Code { get { return code; } }

        /// <summary>
        /// Get the level property which indicates the severity of the message.
        /// </summary>
        private int level;
        public int Level { get { return level; } }

        /// <summary>
        /// Get the message property.
        /// </summary>
        private string message;
        public string Message { get { return message; } }

        /// <summary>
        /// Get the details property which may contain additional 
        /// informatation about the event.
        /// </summary>
        private string details;
        public string Details { get { return details; } }
        #endregion

        #region CONSTRUCTORS AND DECONSTRUCTORS
        /// <summary>
        /// Create an instance of a ConsoleEventArgs object.
        /// </summary>
        /// <param name="code">Message identification code.</param>
        /// <param name="level">Severity level.</param>
        /// <param name="message">Text of the message.</param>
        /// <param name="details">Addition message details.</param>
        public StatusEventArgs(int code, int level, string message, string details)
        {
            this.code = code;
            this.level = level;
            this.message = message;
            this.details = details;
        }

        /// <summary>
        /// Create an instance of a ConsoleEventArgs object.
        /// </summary>
        /// <param name="code">Message identification code.</param>
        /// <param name="level">Severity level.</param>
        /// <param name="message">Text of the message</param>
        public StatusEventArgs(int code, int level, string message) : this(code, level, message, null)
        { }
        #endregion
    }
    
    public delegate void OnErrorDelegate(CommErrorType type, string description);
    public delegate void OnStatusDelegate(StatusEventArgs statusEvent);
    public delegate void OnAllIpDataInDelegate(DataTable dtable);
    public delegate void OnPollDataInDelegate(DataSet dset, DateTime dt, string BsdcPID);
    public delegate void OnReceivedDelegate(byte[] blok, long utcOffset);
    public delegate void OnMultiReceivedDelegate(ArrayList list, long utcOffset);
    public delegate void OnSentDelegate(string data, DateTime time);
    public delegate void QueueDelegate(Queue goodQ, Queue dataQ);
}
