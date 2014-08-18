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
	public class FtpTerminationConsole : PageableConsole
	{
	
		public override ConsoleDispatcher Dispatcher 
		{
			set 
			{
				base.Dispatcher = value;
				//dispatcher.OnFtpTerminationReceived += new ConsoleDispatcher.OnMultiReceivedHandler
                    //(dispatcher_OnFtpTerminationReceived);
			}
		}

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FtpTerminationConsole()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			Title = "FTP Session Termination Records";
			manager = new ManFtpRecs();
			
			END_BANNER =	"--------------- END OF FTP TERMINATION RECORDS ---------------";
			START_BANNER =	"-------------- START OF FTP TERMINATION RECORDS --------------";
			Append(END_BANNER);
            rtbHeader.Text = "Start Time              End Time                Task ID  Node Name         User ID           VSE IP           VSE Port  Forgn Port   Forgn IP         Forgn Data IP    Files Sent  Files Rcvd  Bytes Sent            Bytes Rcvd            Type      SSL    ";
			//rtbHeader.Text = "Task ID  Node Name         Type      SSL    User ID           Files Sent  Files Rcvd  Bytes Sent            Bytes Rcvd            VSE IP           VSE Port  Client IP        Client Port  Forgn Data IP    Start Time             End Time";
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
			ConsoleDataSet.FTP_RecordsDataTable table = null;

			try 
			{
				table = ((ManFtpRecs) manager).GetIdRange(start, end);
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
			ConsoleDataSet.FTP_RecordsRow row = (ConsoleDataSet.FTP_RecordsRow) table.Rows[index];
			
			return FormatText(new FtpTerminationRecord(
			  (ushort) row.Vse_Task_ID,
			  row.FTP_Node_Name,
			  row.General_Flag,
			  row.SSL_Flag,
			  row.FTP_User_ID,
			  (uint) row.Files_Sent,
			  (uint) row.Files_Received,
			  (ulong) row.Bytes_SentAcked,
			  (ulong) row.Bytes_Received,
			  row.Vse_IP,
			  (ushort) row.Vse_Port,
			  row.Client_IP,
			  (ushort) row.Client_Port,
			  row.Foreign_Data_IP,
			  row.Start_Time,
			  row.End_Time));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public override int GetLastIdIn(DataTable table) 
		{
			if (table.Rows.Count > 0)
				//return ((ConsoleDataSet.TCPIP_MessagesRow) table.Rows[table.Rows.Count - 1]).Message_ID;
				return ((ConsoleDataSet.FTP_RecordsRow) table.Rows[table.Rows.Count - 1]).Record_ID;
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
			} else
				return @"\pard\cf1\fs16 " + text.ToString() + @"\par";
		}
		
		#region EVENT HANDLERS (Dispatcher)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="blok"></param>
		private void dispatcher_OnFtpTerminationReceived(ArrayList list, long utcOffset) 
		{
			if (this.InvokeRequired)
			{
				BeginInvoke(new ConsoleDispatcher.OnMultiReceivedHandler(dispatcher_OnFtpTerminationReceived),
					new object[] {list, utcOffset});
				return;
			}			

			// Update the console.
			
			if (active == true) 
			{
				for (int i = 0; i < list.Count; i++)
					Append(new FtpTerminationRecord((byte[]) list[i], utcOffset).ToString());
			}

			//if (active == true) 
			//	Append(new FtpTerminationRecord(blok, utcOffset).ToSummary());
		}

        
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FtpTerminationConsole));
            this.SuspendLayout();
            // 
            // toolMain
            // 
            this.toolMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolMain.Size = new System.Drawing.Size(728, 28);
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
            this.rtbConsole.Size = new System.Drawing.Size(728, 360);
            // 
            // rtbHeader
            // 
            this.rtbHeader.Location = new System.Drawing.Point(0, 28);
            this.rtbHeader.Size = new System.Drawing.Size(728, 20);
            // 
            // FtpTerminationConsole
            // 
            this.DisplaySize = 24;
            this.Name = "FtpTerminationConsole";
            this.PageSize = 24;
            this.Size = new System.Drawing.Size(728, 408);
            this.ResumeLayout(false);

		}
		#endregion

        ///dzs
        public ManFtpRecs Manager
        {
            get { return (ManFtpRecs)base.manager; }
        }
        public void OnRecordReceived(FtpTerminationRecord record)
        {
            // Update the console.
            if (active == true)
            { Append(record.ToString()); }
            //if (active == true) 
            //	Append(new FtpTerminationRecord(blok, utcOffset).ToSummary());
        }

	} // end of FtpTerminationConsole
}
