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
	/// Summary description for JobStepTerminationConsole.
	/// </summary>
	public class JobStepTerminationConsole : PageableConsole
	{
		public override ConsoleDispatcher Dispatcher 
		{
			set 
			{
				base.Dispatcher = value;
				//dispatcher.OnJobStepTerminationReceived += new ConsoleDispatcher.OnMultiReceivedHandler(dispatcher_OnJobStepTerminationReceived);
			}
		}

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public JobStepTerminationConsole()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			Title = "Job Step Termination Records";
			manager = new ManJobStepRecs();
			
			END_BANNER =	"--------------- END OF JOB STEP TERMINATION RECORDS ---------------";
			START_BANNER =	"-------------- START OF JOB STEP TERMINATION RECORDS --------------";
			Append(END_BANNER);

            rtbHeader.Text = "Start Time              End Time                PID  Job Name  Step Name  Duration(sec)  CPU Time(sec)  I/O Count      ";
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

		#region IMPLEMENTATIONS (PageableConsole)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public override DataTable GetData(int start, int end) 
		{
			ConsoleDataSet.JobStep_RecordsDataTable table = null;
			try 
			{
				table = (ConsoleDataSet.JobStep_RecordsDataTable) ((ManJobStepRecs) manager).GetIdRange(start, end);
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
			ConsoleDataSet.JobStep_RecordsRow row = (ConsoleDataSet.JobStep_RecordsRow) table.Rows[index];
			
			return FormatText(new JobStepTerminationRecord(
			 row.Step_Name, 
			 row.Job_Name, 
			 (float) row.Duration_Sec, 
			 (float) row.Cpu_Time_Sec, 
			 (ulong) row.Total_IO, 
			 row.Step_Start_Time, 
			 row.Step_End_Time, 
			 row.PID).ToString());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public override int GetLastIdIn(DataTable table) 
		{
			if (table.Rows.Count > 0)
				return ((ConsoleDataSet.JobStep_RecordsRow) table.Rows[table.Rows.Count - 1]).Record_ID;
			else
				return 0;
		}
		#endregion
		#region EVENT HANDLERS (Dispatcher)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="blok"></param>
		private void dispatcher_OnJobStepTerminationReceived(ArrayList list, long utcOffset) 
		{
			if (this.InvokeRequired)
			{
				BeginInvoke(new ConsoleDispatcher.OnMultiReceivedHandler(dispatcher_OnJobStepTerminationReceived),
					new object[] {list, utcOffset});
				return;
			}			

			// Update the console.
			if (active == true) 
			{
				for (int i = 0; i < list.Count; i++)
					Append(new JobStepTerminationRecord((byte[]) list[i]).ToString());
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobStepTerminationConsole));
            this.SuspendLayout();
            // 
            // toolMain
            // 
            this.toolMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolMain.Size = new System.Drawing.Size(664, 28);
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
            // 
            // rtbHeader
            // 
            this.rtbHeader.Location = new System.Drawing.Point(0, 28);
            this.rtbHeader.Size = new System.Drawing.Size(664, 20);
            // 
            // JobStepTerminationConsole
            // 
            this.DisplaySize = 39;
            this.Name = "JobStepTerminationConsole";
            this.PageSize = 39;
            this.ResumeLayout(false);

		}
		#endregion

        ///dzs
        public ManJobStepRecs Manager
        {
            get { return (ManJobStepRecs)base.manager; }
        }
        public void OnRecordReceived(JobStepTerminationRecord record)
        {
            // Update the console.
            if (active == true)
            { Append(record.ToString()); }
            //if (active == true) 
            //	Append(new FtpTerminationRecord(blok, utcOffset).ToSummary());
        }
	}
}
