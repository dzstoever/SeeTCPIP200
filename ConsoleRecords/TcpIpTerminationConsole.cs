using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
//using csi.seevse.MsdeDataAccess;

namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for PageableFtpTerminationConsole.
	/// </summary>
	public class TcpIpTerminationConsole : PageableConsole
	{
	
		public override ConsoleDispatcher Dispatcher 
		{
			set 
			{
				base.Dispatcher = value;
				//dispatcher.OnTcpIpTerminationReceived += new ConsoleDispatcher.OnMultiReceivedHandler(dispatcher_OnTcpIpTerminationReceived);
			}
		}

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TcpIpTerminationConsole()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			Title = "Connection Records";
			manager = new ManConnectionRecs();
			
			END_BANNER =	"--------------- END OF CONNECTION RECORDS ---------------";
			START_BANNER =	"-------------- START OF CONNECTION RECORDS --------------";
			Append(END_BANNER);
            rtbHeader.Text = "Start Time              End Time                Protocol  Final State   "
                + "PID  Local Port  Forgn Port  Forgn Ip         "
                + "Inbound Bytes         Inbound Datagrams     Inbound Bytes(dup)    Inbound Dgrams(dup)   Efficiency In  "
                + "Outbound Bytes        Outbound Datagrams    Outbound Bytes(retr)  Outbound Dgrams(retr) Efficiency Out  "
                + "RECVs Issued          SENDs Issued          Max RECV Size  Max SEND Size  "
                + "RECV Closed Count     Retransmits Issued    Times in Retransmit   "
                + "Highest Depth         SWS Count             ";
			//rtbHeader.Text = "End Time                 PID   Protocol Local Port Foreign IP"; 
			rtbConsole.RegisterToBeScrolled(rtbHeader);
		}

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

		#region IMPLEMENTATIONS (PageableConsole)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public override DataTable GetData(int start, int end) 
		{
			ConsoleDataSet.Connection_RecordsDataTable table = null;
			try 
			{
                table = (ConsoleDataSet.Connection_RecordsDataTable)((ManConnectionRecs)manager).GetIdRange(start, end);
			} 
			catch (System.Data.SqlClient.SqlException sqle)
			{
				Debug.WriteLine("SQL Exception - " + sqle.Message);
				Status = new StatusEventArgs(635, StatusEventArgs.SEVERE, sqle.Message);
			}

			return table;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="table"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public override string GetTextAt(DataTable table, int index) 
		{
			ConsoleDataSet.Connection_RecordsRow row = (ConsoleDataSet.Connection_RecordsRow) table.Rows[index];
			
			return FormatText(new TcpIpTerminationRecord(
				TcpIpTerminationRecord.StateUnformatter(row.Conn_State),
				TcpIpTerminationRecord.ProtocolUnformatter(row.Conn_Protocol),
				row.Conn_Start_Time,
				(ushort) row.Local_Port,
				(ushort) row.Foreign_Port,
				row.Foreign_IP,
				TcpIpTerminationRecord.FlagAAUnformatter(row.Conn_Protocol),
				TcpIpTerminationRecord.LocalCallUnformatter(row.INT_EXT),
				(ulong) row.Retransmits,
				(ulong) row.Inbound_Data,
				(ulong) row.Inbound_Data_Dup,
				(ulong) row.Inbound_Bytes,
				(ulong) row.Inbound_Bytes_Dup,
				(ulong) row.Outbound_Data,
				(ulong) row.Outbound_Data_Retr,
				(ulong) row.Outbound_Bytes,
				(ulong) row.Outbound_Bytes_Retr,
				(ulong) row.SWS_Count,
				(ulong) row.In_Retr_Mode,
				(ulong) row.Recv_Window_Closed,
				(ulong) row.Highest_Depth,
				(ulong) row.Sends_Issued,
				(ulong) row.Recvs_Issued,
				(uint) row.Max_Send_Window,
				(uint) row.Max_Recv_Window,
				row.Conn_End_Time,
				row.Conn_PID,
				0 /* not stored in DB */)).ToString(); 


			
			//return FormatText(TcpIpTerminationRecord.ToString(row.Conn_End_Time, row.Conn_PID, row.Conn_Protocol, row.Local_Port, row.Foreign_IP, row.Foreign_Port));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public override int GetLastIdIn(DataTable table) 
		{
			if (table.Rows.Count > 0)
				return ((ConsoleDataSet.Connection_RecordsRow) table.Rows[table.Rows.Count - 1]).Record_ID;
				//return ((ConsoleDataSet.FTP_RecordsRow) table.Rows[table.Rows.Count - 1]).Record_ID;
			else
				return 0;
		}
		#endregion

		public override string FormatText(object text) 
		{
			if (text is string) 
			{
				if (((string) text).StartsWith("-"))
					return @"\pard\qc\cf2\fs14 " + (string) text + @"\par";
				else 
					return @"\pard\cf1\fs16 " + (string) text + @"\par";
			} 
			else
				return @"\pard\cf1\fs16 " + text.ToString() + @"\par";
		}
		
		#region EVENT HANDLERS (Dispatcher)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="blok"></param>
		private void dispatcher_OnTcpIpTerminationReceived(ArrayList list, long utcOffset) 
		{
			if (this.InvokeRequired)
			{
				BeginInvoke(new ConsoleDispatcher.OnMultiReceivedHandler(dispatcher_OnTcpIpTerminationReceived),
					new object[] {list, utcOffset});
				return;
			}			

			// Update the console.
			if (active == true) {
				for (int i = 0; i < list.Count; i++)
					Append(new TcpIpTerminationRecord((byte[]) list[i], utcOffset).ToString());
			}
			//if (active == true) 
			//	Append(new TcpIpTerminationRecord(blok, utcOffset).ToSummary());
		}
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TcpIpTerminationConsole));
            this.SuspendLayout();
            // 
            // toolMain
            // 
            this.toolMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolMain.Size = new System.Drawing.Size(560, 28);
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
            this.rtbConsole.Size = new System.Drawing.Size(560, 360);
            // 
            // rtbHeader
            // 
            this.rtbHeader.Location = new System.Drawing.Point(0, 28);
            this.rtbHeader.Size = new System.Drawing.Size(560, 20);
            // 
            // TcpIpTerminationConsole
            // 
            this.DisplaySize = 24;
            this.Name = "TcpIpTerminationConsole";
            this.PageSize = 24;
            this.Size = new System.Drawing.Size(560, 408);
            this.ResumeLayout(false);

		}
		#endregion

        ///dzs
        public ManConnectionRecs Manager
        {
            get { return (ManConnectionRecs)base.manager; }
        }
        public void OnRecordReceived(TcpIpTerminationRecord record)
        {
            // Update the console.
            if (active == true)
            { Append(record.ToString()); }
            //if (active == true) 
            //	Append(new FtpTerminationRecord(blok, utcOffset).ToSummary());
        }
	}
}
