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
	/// Represents a console for viewing SeeVSE startup records.
	/// </summary>
	public class SeeVseStartupConsole : PageableConsole
	{
		#region MEMBER VARIABLES		
		/// <summary>
		///	Message dispatcher for receiving SeeVSE startup records.
		/// </summary>
		
		public override ConsoleDispatcher Dispatcher 
		{
			set 
			{
				base.Dispatcher = value;
				//dispatcher.OnSeeVseStartupReceived += new ConsoleDispatcher.OnReceivedHandler(dispatcher_OnSeeVseStartupReceived);
			}
		}
				
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		
		#region CONSTRUCTORS AND DECONSTRUCTORS
		/// <summary>
		/// Create an instance of a SeeVseStartupConsole.
		/// </summary>
		public SeeVseStartupConsole()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			Title = "See VSE Startup Records";
			manager = new ManStartupRecs();
			END_BANNER =   "--------------- END OF SEEVSE STARTUP RECORDS ---------------";
			START_BANNER = "-------------- START OF SEEVSE STARTUP RECORDS --------------";
			Append(END_BANNER);
			rtbHeader.Text = "CPU ID             Program ID  Version   Start Time";
			rtbConsole.RegisterToBeScrolled(rtbHeader);

            
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
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


		#region IMPLEMENTATIONS (PageableConsole)
		public override DataTable GetData(int start, int end) 
		{
			ConsoleDataSet.Startup_RecordsDataTable table = null;

			try 
			{
				table = ((ManStartupRecs) manager).GetIdRange(start, end);
			}
			catch (System.Data.SqlClient.SqlException sqle)
			{
				Debug.WriteLine("SQL Exception - " + sqle.Message);
				Status = new StatusEventArgs(635, StatusEventArgs.SEVERE, sqle.Message);
			}

			return table;
		}

		public override string GetTextAt(DataTable table, int index) 
		{
			ConsoleDataSet.Startup_RecordsRow row = (ConsoleDataSet.Startup_RecordsRow) table.Rows[index];

			return FormatText(new SeeVseStartupRecord(
			 row.Start_Time, 
			 row.Cpu_ID, 
			 row.Program_ID, 
			 row.Program_Version));
		}
		
		public override int GetLastIdIn(DataTable table) 
		{
			if (table.Rows.Count > 0)
				return ((ConsoleDataSet.Startup_RecordsRow) table.Rows[table.Rows.Count - 1]).Record_ID;
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
		/// Handler for OnSeeVseStartupReceived events received from the 
		/// dispatcher.
		/// </summary>
		/// <param name="blok"></param>
		/// <param name="utcOffset"></param>
		private void dispatcher_OnSeeVseStartupReceived(
			byte[] blok, long utcOffset) 
		{
			// OnSeeVseStartupReceived events do not occur on the main thread
			// and therefore this method needs to be called again on the main 
			// thread to prevent threading issues.
			if (this.InvokeRequired)
			{
				BeginInvoke(new ConsoleDispatcher.OnReceivedHandler(
					dispatcher_OnSeeVseStartupReceived),
					new object[] {blok, utcOffset}
				);
				return;
			}			

			// Update the console.

			if (active == true) 
			{	
				SeeVseStartupRecord record =  new SeeVseStartupRecord(blok, utcOffset);
				
				Append(record.ToString());
//				Font boldFont = new Font(Font, FontStyle.Bold);
				
				//rtbConsole.Clear();
//				AppendText(boldFont, Color.Blue, "Started at: "); 
//				AppendText(Font, Color.Black, record.StartTime + "\n");
//				AppendText(boldFont, Color.Blue, "    CPU Serial Number: ");
//				AppendText(Font, Color.Black, record.CpuId + "\n");
//				AppendText(boldFont, Color.Blue, "    Program ID:        "); 
//				AppendText(Font, Color.Black, record.ProgramId + "\n");
//				AppendText(boldFont, Color.Blue, "    Program Version:   "); 
//				AppendText(Font, Color.Black, record.ProgramVersion + "\n");
//				AppendText(Font, Color.Black, "\n");
			}
		}
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeeVseStartupConsole));
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
            // images
            // 
            //this.images.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            //this.images.ImageSize = new System.Drawing.Size(16, 16);
            //this.images.ImageStream = null;
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
            // SeeVseStartupConsole
            // 
            this.DisplaySize = 24;
            this.Name = "SeeVseStartupConsole";
            this.PageSize = 24;
            this.Size = new System.Drawing.Size(728, 408);
            this.ResumeLayout(false);

		}
		#endregion

        ///dzs
        public ManStartupRecs Manager
        {
            get { return (ManStartupRecs)base.manager; }
        }
        public void OnRecordReceived(SeeVseStartupRecord record)
        {
            // Update the console.
            if (active == true)
            { Append(record.ToString()); }
            //if (active == true) 
            //	Append(new FtpTerminationRecord(blok, utcOffset).ToSummary());
        }
	} // end of SeeVseStartupConsole
}
