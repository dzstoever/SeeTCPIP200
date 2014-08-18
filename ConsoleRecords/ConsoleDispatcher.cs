using csi.see.classlib1;
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Timers;

namespace ConsoleRecords
{
	/// <summary>
	/// Represents a record dispatcher.  The dispatcher is built upon a TCP/IP
	/// socket in which it can send and receive data.  When a record is 
	/// received, the dispatcher determines the specific type of record and 
	/// notifies any interested listener. 
	/// </summary>
	/// <remarks>
	/// 20060212 P. McClain		initial version
	/// </remarks>
	
	public class ConsoleDispatcher : System.ComponentModel.Component
	{
        public event OnSentHandler OnCommandSent;
        public event OnReceivedHandler OnCommandProcessedReceived;
        public event OnMultiReceivedHandler OnTcpIpMessageReceived;
        
        public event OnReceivedHandler OnSeeVseStartupReceived;
        public event OnMultiReceivedHandler OnFtpTerminationReceived;        
        public event OnMultiReceivedHandler OnTcpIpTerminationReceived;
        public event OnMultiReceivedHandler OnJobStepTerminationReceived;        
        
        
        #region CLASS VARIABLES
		/// <summary>
		/// Status indicates the connection has been lost.
		/// </summary>
		public static ConsoleEventArgs CONNECTION_LOST = new ConsoleEventArgs(104, ConsoleEventArgs.NORMAL, "Connection Lost");
		/// <summary>
		/// Status indicates the connection has been disconnected.
		/// </summary>
		public static ConsoleEventArgs DISCONNECTED = new ConsoleEventArgs(101, ConsoleEventArgs.NORMAL, "No Connection");
		/// <summary>
		/// Status indicates the connection is ready.
		/// </summary>
		public static ConsoleEventArgs READY = new ConsoleEventArgs(100, ConsoleEventArgs.NORMAL, "Ready");
		/// <summary>
		/// Status indicates a command is being sent.
		/// </summary>
		public static ConsoleEventArgs SENDING_COMMAND = new ConsoleEventArgs(102, ConsoleEventArgs.NORMAL, "Sending ...");
		/// <summary>
		/// Status indicates a command could not be sent.
		/// </summary>
		public static ConsoleEventArgs COMMAND_NOT_SENT = new ConsoleEventArgs(103, ConsoleEventArgs.SEVERE, "Command Not Sent");		
		/// <summary>
		/// Status indicates a command was not specified (i.e. blank)
		/// </summary>
		public static ConsoleEventArgs COMMAND_NOT_SPECIFIED = new ConsoleEventArgs(104, ConsoleEventArgs.SEVERE, "No Command Specified");
		/// <summary>
		/// Status indicate a command is exectuting.
		/// </summary>
		public static ConsoleEventArgs EXECUTING_COMMAND = new ConsoleEventArgs(105, ConsoleEventArgs.NORMAL, "Executing ...");
		/// <summary>
		/// Status indicates the connection (unestablished) is waiting to connect.
		/// </summary>
		public static ConsoleEventArgs WAITING_TO_CONNECT = new ConsoleEventArgs(53, ConsoleEventArgs.NORMAL, "Waiting to Connect ...");
		/// <summary>
		/// Flag to indicate a successful connection was established.
		/// </summary>
		public const int SUCCESSFUL_CONNECTION = 0;

		public const int SEEVSE_STARTUP_TYPE = 1;
		public const int FTP_TERMINATION_TYPE = 2;
		public const int TCPIP_MESSAGE_TYPE = 3;
		public const int CONNECTION_TYPE = 4;
		public const int JOB_STEP_TERMINATION_TYPE = 5;
		public const int COMMAND_SENT_TYPE = 0;
		#endregion
				
		#region MEMBER VARIABLES
		private nsoftware.IPWorks.Ipport connection;
		private ConsoleQueue queue = new ConsoleQueue();
		private RawDataConverter converter = new RawDataConverter();
				
		private byte[] token = new byte[4];
		/// <summary>
		/// Get or set the security token.  
		/// The token prefixes all commands sent to the server as a minimal 
		/// security measure.  The token is validated by the server and 
		/// the command can either be processed or rejected.  
		/// </summary>
		public byte[] Token 
		{
			get { return token; }
			set { value.CopyTo(token, 0); }
		}

		private ConsoleEventArgs status;
		/// <summary>
		/// Status of the message dispatcher.
		/// </summary>
		protected ConsoleEventArgs Status 
		{
			get { return status; }
			set 
			{ 
				status = value;
				if (OnStatusChanged != null && OnStatusChanged.GetInvocationList() != null)
					OnStatusChanged(status);
			}
		}
				
		private String reconnectionTimer;
		/// <summary>
		/// Reconnection timer.
		/// </summary>
		protected String ReconnectionTimer 
		{
			get { return reconnectionTimer; }
			set 
			{
				reconnectionTimer = value;
				if (TimerChanged != null && TimerChanged.GetInvocationList() != null)
					TimerChanged(reconnectionTimer);
			}
		}

		private long utcOffset;
		/// <summary>
		/// Offset from coordiated universal time.
		/// </summary>
		public long UtcOffset 
		{
			get { return utcOffset; }
			set { utcOffset = value; }
		}

		private int retry;
		/// <summary>
		/// 
		/// </summary>
		public int Retry 
		{
			get { return retry; }
			set { retry = value; }
		}
		
		private int interval;
		/// <summary>
		/// 
		/// </summary>
		public int Interval 
		{
			get { return interval; }
			set { interval = value; }
		}

		private bool suspend;
		/// <summary>
		/// Get or set the Suspend property.  When true, the dispatcher is put
		/// into a suspended state and will not dispatch any new data to interested
		/// listeners.  The data from the server continues to be queued.  Otherwise,
		/// the dispatcher is ready to receive data from the server and forward it 
		/// on to any interested listeners.
		/// </summary>
		public bool Suspend 
		{
			get { return suspend; }
			set { suspend = value; }
				//connection.AcceptData = !value;
				//suspend = value; }
		}

		private ArrayList TcpIpMessages = new ArrayList(30);
		private ArrayList FtpTerminationRecords = new ArrayList(30);
		private ArrayList ConnectionRecords = new ArrayList(30);
		private ArrayList JobStepRecords = new ArrayList(30);

		private System.ComponentModel.IContainer components;
		#endregion

		#region EVENTS THROWN
		public event StringDelegate TimerChanged;
		public event OnStatusChangedHandler OnStatusChanged;

		public event ConnectionHandler OnConnected;
		public event ConnectionHandler OnDisconnected;
        
		public delegate void OnStatusChangedHandler(ConsoleEventArgs status);
		public delegate void ConnectionHandler(int code, String description);
		public delegate void OnReceivedHandler(byte[] blok, long utcOffset);
		public delegate void OnMultiReceivedHandler(ArrayList list, long utcOffset);
		public delegate void OnSentHandler(string data, DateTime time, long localOffset, long remoteOffset);
		#endregion
		
		#region CONSTRUCTORS and DECONSTRUCTORS
       /// <summary>
		/// 
		/// </summary>
		/// <param name="container"></param>
		public ConsoleDispatcher(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();            
		}

		/// <summary>
		/// Create an instance of a message dispatcher.  Upon creation, message
		/// events are suspended and will not occur until the suspend property 
		/// is set to false.  
		/// </summary>
		public ConsoleDispatcher()
		{ InitializeComponent(); }

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.connection = new nsoftware.IPWorks.Ipport(this.components);
			// 
			// connection
			// 
			this.connection.About = "";
			this.connection.EOL = "";
			this.connection.EOLB = new System.Byte[0];
			this.connection.FirewallPort = 1080;
			this.connection.FirewallType = nsoftware.IPWorks.IpportFirewallTypes.fwNone;
			this.connection.OnConnected += new nsoftware.IPWorks.Ipport.OnConnectedHandler(this.connection_OnConnected);
			this.connection.OnError += new nsoftware.IPWorks.Ipport.OnErrorHandler(this.connection_OnError);
			this.connection.OnConnectionStatus += new nsoftware.IPWorks.Ipport.OnConnectionStatusHandler(this.connection_OnConnectionStatus);
			this.connection.OnDisconnected += new nsoftware.IPWorks.Ipport.OnDisconnectedHandler(this.connection_OnDisconnected);
			this.connection.OnDataIn += new nsoftware.IPWorks.Ipport.OnDataInHandler(this.connection_OnDataIn);
			this.connection.OnReadyToSend += new nsoftware.IPWorks.Ipport.OnReadyToSendHandler(this.connection_OnReadyToSend);
		}
		#endregion

		#region MEMBER METHODS
		/// <summary>
		/// Build a TCP/IP command to send to the server.  The command adheres
		/// to the following format:
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private byte[] BuildTcpIpCommand(string text) 
		{
			byte[] command = new ASCIIEncoding().GetBytes(text + "\n");	

			byte[] flags = new byte[4] { 0x54, 0x20, 0x20, 0x20 };
			int length = token.Length + flags.Length + command.Length;
			byte[] lengthBE = System.BitConverter.GetBytes(Endian.Swap((uint) length));
			byte[] data = new byte[length + lengthBE.Length];
			int offset = 0;
			
			lengthBE.CopyTo(data, offset); offset += lengthBE.Length;
			token.CopyTo(data, offset); offset += token.Length;
			flags.CopyTo(data, offset); offset += flags.Length;
			command.CopyTo(data, offset);

			return data;
		}
		/// <summary>
		/// Send data (command) to the server.
		/// </summary>
		/// <param name="data">Data to send to the server</param>
		public void Send(String data) 
		{
			// Do not send a blank command.
			if (data.Length == 0) 
			{ 
				if (OnCommandProcessedReceived != null && OnCommandProcessedReceived.GetInvocationList() != null)
					OnCommandProcessedReceived(null, utcOffset);	

				Status = COMMAND_NOT_SPECIFIED;
				return;
			}

			try 
			{
				byte[] command = BuildTcpIpCommand(data);
							
				DateTime utcNow = DateTime.UtcNow;
				long localOffset = DateTime.Now.Second - utcNow.Second;
								
				Status = SENDING_COMMAND;
				connection.Send(command);
				if (OnCommandSent != null && OnCommandSent.GetInvocationList() != null)
                    OnCommandSent("> " + data, DateTime.UtcNow, localOffset, utcOffset);
				Status = EXECUTING_COMMAND;
			} 
			catch (nsoftware.IPWorks.IPWorksException ipwe) 
			{
				Debug.WriteLine("Command not sent " + ipwe.Message);
 
				if (OnCommandProcessedReceived != null && OnCommandProcessedReceived.GetInvocationList() != null)
					OnCommandProcessedReceived(null, utcOffset);	

				Status = COMMAND_NOT_SENT;
			}
		}
		
        /// <summary>
		/// Connect (open) a socket to a TCP/IP message server.
		/// </summary>
		/// <param name="host">Host (name or IP address) of the message server</param>
		/// <param name="port">"Port number of the message server</param>			
		public void Connect(String host, int port) 
		{
			try {
				connection.RemoteHost = host;
				connection.RemotePort = port;							
				
				// Ignore if the socket is already connected.
				if (connection.Connected == true)
					return; //connection.Connected = false;
			
				Status = new ConsoleEventArgs(50, ConsoleEventArgs.NORMAL, "Connecting to " + host + ":" + port);							
			
				// Asynchronously open a socket connection to the server.
				connection.Connected = true;
			} 
			catch (nsoftware.IPWorks.IPWorksException ipwe) 
			{
				Debug.WriteLine("Error Ignored " + ipwe.Message);
			}
		}
		/// <summary>
		/// Disconnect (close) a socket to a TCPIP message server.
		/// </summary>
		public void Disconnect() 
		{
			connection.Connected = false;	
		}		
		/// <summary>
		/// Determine whether the dispatcher is connected to the server.
		/// </summary>
		/// <returns>true if connected; false otherwise.</returns>
		public bool IsConnected() { return connection.Connected; }
		#endregion

		#region EVENT HANDLERS (IPPort Component)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void connection_OnConnected(object sender, nsoftware.IPWorks.IpportConnectedEventArgs e)
		{
			if (e.StatusCode == 0) 
			{
				Status = new ConsoleEventArgs(51, ConsoleEventArgs.NORMAL, "Connected to " + connection.RemoteHost + ":" + connection.RemotePort);
				Status = READY;
			}
            else
            {
                Status = DISCONNECTED;
                
            }

			if (OnConnected != null && OnConnected.GetInvocationList() != null)
				OnConnected(e.StatusCode, e.Description);	
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void connection_OnConnectionStatus(object sender, nsoftware.IPWorks.IpportConnectionStatusEventArgs e)
		{
			//Debug.WriteLine("connection status = " + + e.StatusCode + " " + e.Description);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void connection_OnDataIn(object sender, nsoftware.IPWorks.IpportDataInEventArgs e)
		{
			queue.Enqueue(e.TextB);
			
			if (Suspend == true) // Do not fire received events (they will be accumulated).
				return;

			TcpIpMessages.Clear();
			ConnectionRecords.Clear();
			FtpTerminationRecords.Clear();
			JobStepRecords.Clear();

			byte[] record;
			
			while ((record = (byte[]) queue.Dequeue()) != null) 
			{
				int type = converter.GetINT32(4, record);
				
				if (type == 1) // SeeVSE startup record
				{				
					if (OnSeeVseStartupReceived != null 
						&& OnSeeVseStartupReceived.GetInvocationList() != null)
						OnSeeVseStartupReceived(record, utcOffset);
				} 
				else if (type == 2) // TCP/IP FTP session termination
				{ 
					FtpTerminationRecords.Add(record);
									} 
				else if (type == 3) // TCP/IP message
				{
					TcpIpMessages.Add(record);				
				}
				else if (type == 4) // TCP/IP connection termination record
				{
					ConnectionRecords.Add(record);
				} 
				else if (type == JOB_STEP_TERMINATION_TYPE) 
				{
					JobStepRecords.Add(record);
				}
				else  // TCP/IP command parse response
				{
					ushort length = (ushort) (converter.GetUINT16(0, record) - 4);
					String message;
					
					if (length > 0)
					{
						message = converter.GetEBCDIC(4, record, (int) length);
						if (message.StartsWith("GOOD"))
						{
							if (OnCommandProcessedReceived != null
								&& OnCommandProcessedReceived.GetInvocationList() != null)
								OnCommandProcessedReceived(record, utcOffset);	

							Status = READY;;
						} 
						else if (message.StartsWith("FAIL")) 
						{
							if (OnCommandProcessedReceived.GetInvocationList() != null)
								OnCommandProcessedReceived(record, utcOffset);
													
							if (message.Length > 8) 
								Status = new ConsoleEventArgs(701, ConsoleEventArgs.SEVERE, "Command Failed: " + message.Substring(8));
							else
								Status = new ConsoleEventArgs(701, ConsoleEventArgs.SEVERE, "Command failed");
						}
						else 
						{
							Debug.WriteLine("Invalid Data" + message);
							Debug.WriteLine("Clearing the message queue.");
							queue.Clear(); // /Clear queue to prevent other invalid messages.
						}
					}
				}
			}

			if (TcpIpMessages.Count > 0) 
			{
				if (OnTcpIpMessageReceived != null
				 && OnTcpIpMessageReceived.GetInvocationList() != null)
					OnTcpIpMessageReceived(new ArrayList(TcpIpMessages), utcOffset);
			}

			if (FtpTerminationRecords.Count > 0) 
			{
				if (OnFtpTerminationReceived != null
					&& OnFtpTerminationReceived.GetInvocationList() != null)
					OnFtpTerminationReceived(new ArrayList(FtpTerminationRecords), utcOffset);
			}

			if (ConnectionRecords.Count > 0) 
			{
				if (OnTcpIpTerminationReceived != null 
					&& OnTcpIpTerminationReceived.GetInvocationList() != null)
					OnTcpIpTerminationReceived(new ArrayList(ConnectionRecords), utcOffset);
			}

			if (JobStepRecords.Count > 0) 
			{
				if (OnJobStepTerminationReceived != null 
					&& OnJobStepTerminationReceived.GetInvocationList() != null)
					OnJobStepTerminationReceived(new ArrayList(JobStepRecords), utcOffset);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void connection_OnDisconnected(object sender, nsoftware.IPWorks.IpportDisconnectedEventArgs e)
		{
			if (OnDisconnected != null && OnDisconnected.GetInvocationList() != null)
				OnDisconnected(e.StatusCode, e.Description);

            if (e.StatusCode != 0)
            { Status = CONNECTION_LOST; }
            else { Status = DISCONNECTED; }
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void connection_OnError(object sender, nsoftware.IPWorks.IpportErrorEventArgs ipwe)
		{
			Debug.WriteLine("Unhandled socket error " + ipwe.Description);
		}

		private void connection_OnReadyToSend(object sender, nsoftware.IPWorks.IpportReadyToSendEventArgs ipw)
		{ }
		#endregion
		
	} //end of ConsoleDispatcher

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
    /// 
    /// Revision History 20060212 P. McClain	Initial version 
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
    } // end of RecordQueue

    /// <summary>
    /// Represents the details of a status event.
    /// </summary>
    public class ConsoleEventArgs
    {
        #region MEMBER CONSTANTS
        public const int NORMAL = 0;
        public const int INFORMATION = 1;
        public const int WARNING = 5;
        public const int SEVERE = 10;
        #endregion

        #region MEMBER PROPERTIES
        /// <summary>
        /// Get the code property.  The code can be used to identify a type
        /// of message even when the text is different
        /// 
        /// </summary>
        private int code;
        public int Code { get { return code; } }

        /// <summary>
        /// Get the level property which indicates the severity of the 
        /// message.
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
        public ConsoleEventArgs(int code, int level, string message, string details)
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
        public ConsoleEventArgs(int code, int level, string message)
            : this(code, level, message, null)
        {
        }
        #endregion
    } // end of ConsoleEventArgs
}
