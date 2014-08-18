//using csi.seevse.MsdeDataAccess;
using csi.see.classlib1.DataSets;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace csi.see.client1
{
	/// <summary>
	/// Summary description for BaseRecordTable.
	/// </summary>
	public class BaseRecordTable : System.Windows.Forms.UserControl
	{
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
        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseRecordTable));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mHide = new System.Windows.Forms.MenuItem();
            this.mShowAll = new System.Windows.Forms.MenuItem();
            this.vseDbDataset1 = new csi.see.classlib1.DataSets.VseDbDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MsgNoRecords = new System.Windows.Forms.Label();
            this.LOAD = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.PrintTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vseDbDataset1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mHide,
            this.mShowAll});
            // 
            // mHide
            // 
            this.mHide.Index = 0;
            this.mHide.Text = "&Hide Column";
            this.mHide.Click += new System.EventHandler(this.mHide_Click);
            // 
            // mShowAll
            // 
            this.mShowAll.Index = 1;
            this.mShowAll.Text = "&Show All Columns";
            this.mShowAll.Click += new System.EventHandler(this.mShowAll_Click);
            // 
            // vseDbDataset1
            // 
            this.vseDbDataset1.DataSetName = "VseDbDataSet";
            this.vseDbDataset1.Locale = new System.Globalization.CultureInfo("en-US");
            this.vseDbDataset1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(640, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.MsgNoRecords);
            this.panel1.Controls.Add(this.LOAD);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(4, 391);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(640, 36);
            this.panel1.TabIndex = 9;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "MM/dd/yyyy  HH:mm:ss";
            this.dateTimePicker2.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateTimePicker2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(380, 4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(184, 21);
            this.dateTimePicker2.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(352, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "To";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM/dd/yyyy  HH:mm:ss";
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(168, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(184, 21);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(88, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 28;
            this.label3.Text = "End Time";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(80, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 24);
            this.label2.TabIndex = 27;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MsgNoRecords
            // 
            this.MsgNoRecords.ForeColor = System.Drawing.Color.Red;
            this.MsgNoRecords.Location = new System.Drawing.Point(0, 0);
            this.MsgNoRecords.Name = "MsgNoRecords";
            this.MsgNoRecords.Size = new System.Drawing.Size(88, 30);
            this.MsgNoRecords.TabIndex = 26;
            this.MsgNoRecords.Text = "No Records Available";
            this.MsgNoRecords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MsgNoRecords.Visible = false;
            // 
            // LOAD
            // 
            this.LOAD.BackColor = System.Drawing.SystemColors.Control;
            this.LOAD.Dock = System.Windows.Forms.DockStyle.Left;
            this.LOAD.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOAD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LOAD.ImageIndex = 1;
            this.LOAD.ImageList = this.imageList1;
            this.LOAD.Location = new System.Drawing.Point(12, 4);
            this.LOAD.Name = "LOAD";
            this.LOAD.Size = new System.Drawing.Size(68, 24);
            this.LOAD.TabIndex = 25;
            this.LOAD.Text = "Load";
            this.LOAD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LOAD.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(8, 24);
            this.label5.TabIndex = 24;
            // 
            // dataGrid1
            // 
            this.dataGrid1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.White;
            this.dataGrid1.CaptionText = "No Data Available (Count = 0)";
            this.dataGrid1.ContextMenu = this.contextMenu1;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(4, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(640, 391);
            this.dataGrid1.TabIndex = 10;
            this.dataGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGrid1_MouseUp);
            // 
            // PrintTable
            // 
            this.PrintTable.BackColor = System.Drawing.Color.Silver;
            this.PrintTable.ImageIndex = 0;
            this.PrintTable.ImageList = this.imageList1;
            this.PrintTable.Location = new System.Drawing.Point(4, 22);
            this.PrintTable.Name = "PrintTable";
            this.PrintTable.Size = new System.Drawing.Size(36, 24);
            this.PrintTable.TabIndex = 11;
            this.PrintTable.UseVisualStyleBackColor = false;
            // 
            // BaseRecordTable
            // 
            this.Controls.Add(this.PrintTable);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BaseRecordTable";
            this.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Size = new System.Drawing.Size(648, 450);
            ((System.ComponentModel.ISupportInitialize)(this.vseDbDataset1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        
        #region MEMBERS
        private VseDbDataSet vseDbDataset1;
		DataTable _table;// = new DataTable();
		ConsoleStartupRecords		recordsSTRT = null;
		ConsoleFtpRecords			recordsT002 = null;
		ConsoleConnectionRecords	recordsT004 = null;
		ConsoleJobStepRecords		recordsT005 = null;
        #region
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label MsgNoRecords;
		private System.Windows.Forms.Button LOAD;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button PrintTable;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mHide;
		private System.Windows.Forms.MenuItem mShowAll;
        #endregion
        #endregion
        private System.ComponentModel.IContainer components;

		public BaseRecordTable(string dbName, string type)
		{
			InitializeComponent();// This call is required by the Windows.Forms Form Designer.
			//VseDbDataSet vseDbDataset1  = new VseDbDataSet();
			DateTime minDT = DateTimePicker.MinDateTime;
			DateTime maxDT = DateTimePicker.MaxDateTime;
			#region Set Type
			if(type == "STRT")
			{
				label3.Text = "Start Time";
				label4.Text = "   See - Session Startup Records";
				_table = vseDbDataset1.Startup_Records;
				AddStyleSTRT();
				recordsSTRT = new ConsoleStartupRecords();
				recordsSTRT.SetDbName(dbName);
				minDT = recordsSTRT.GetMinDT();
				maxDT = recordsSTRT.GetMaxDT();
				LOAD.Click+=new EventHandler(LOADSTRT_Click);
			}
			else if(type == "T002")
			{
				label4.Text = "   FTP - End of Session Records";
				_table = vseDbDataset1.FTP_Records;
				DataColumn aggSSL = new DataColumn();
				aggSSL.DataType = System.Type.GetType("System.String");
				aggSSL.ColumnName = "FlagSSL";
				aggSSL.DefaultValue = "False";
				//64 = 0x40 = SSL Client
				//128 =  0x80 = SSL Server
				aggSSL.Expression = "IIF(SSL_Flag=128 OR SSL_Flag=64, 'True', 'False')";    
				_table.Columns.Add(aggSSL);// Add columns to DataTable.

				DataColumn aggFlag2 = new DataColumn();
				aggFlag2.DataType = System.Type.GetType("System.String");
				aggFlag2.ColumnName = "Flag2";
				aggFlag2.DefaultValue = "INT-FTP";
				//64 = 0x40 = FTPBATCH
				aggFlag2.Expression = "IIF(General_Flag=64, 'FTPBATCH', 'INT-FTP')";    
				_table.Columns.Add(aggFlag2);// Add columns to DataTable.

				AddStyleT002();
				recordsT002 = new ConsoleFtpRecords();
				recordsT002.SetDbName(dbName);
				minDT = recordsT002.GetMinDT();
				maxDT = recordsT002.GetMaxDT();
				LOAD.Click+=new EventHandler(LOADT002_Click);
			}
			else if(type == "T004")
			{
				label4.Text = "   Connection - Termination Records";
				_table = vseDbDataset1.Connection_Records;
				AddStyleT004();
				recordsT004 = new ConsoleConnectionRecords();
				recordsT004.SetDbName(dbName);
				minDT = recordsT004.GetMinDT();
				maxDT = recordsT004.GetMaxDT();
				LOAD.Click+=new EventHandler(LOADT004_Click);
			}
			else if(type == "T005")
			{
				label4.Text = "   Job - End of Step Records";
				_table = vseDbDataset1.JobStep_Records;
				AddStyleT005();
				recordsT005 = new ConsoleJobStepRecords();
				recordsT005.SetDbName(dbName);
				minDT = recordsT005.GetMinDT();
				maxDT = recordsT005.GetMaxDT();
				LOAD.Click+=new EventHandler(LOADT005_Click);
			}
			#endregion
			
			dataGrid1.DataSource = _table;
			if(minDT == DateTimePicker.MinDateTime)
			{
				MsgNoRecords.Visible = true;
				dateTimePicker1.Enabled = false;
				dateTimePicker2.Enabled = false;
			}
			else
			{
				if(minDT.Ticks == maxDT.Ticks)
				{maxDT = maxDT.AddSeconds(1);}
				dateTimePicker1.MaxDate = maxDT;
				dateTimePicker2.MaxDate = maxDT;
				dateTimePicker2.Value = maxDT;
				dateTimePicker1.MinDate = minDT;
				dateTimePicker2.MinDate = minDT;
				dateTimePicker1.Value = minDT;
			}

		}

		private void ApplyStyleBase(DataGridTableStyle Tstyle)
		{
			Tstyle.HeaderForeColor = Color.FromArgb(0,0,192);
			Tstyle.AlternatingBackColor = Color.WhiteSmoke;
			Tstyle.PreferredColumnWidth = 100;
			Tstyle.ReadOnly = true;
			Tstyle.MappingName = _table.TableName;
		}
        private DataGridTextBoxColumn AddColumnStyle(string colName, string header, int width, bool isDateTime)
        {
            DataGridTextBoxColumn colStyle = new DataGridTextBoxColumn();
            colStyle.MappingName = colName;
            colStyle.HeaderText = header;
            if (width > 0)//Otherwise use the TableStyle.PreferredWidth
            { colStyle.Width = width; }

            if (isDateTime)
            { colStyle.Format = "MM/dd/yy HH:mm:ss"; }
            else if (header.EndsWith("(sec)"))
            { colStyle.Format = "F3"; }//3 decimal places
            else if (header.StartsWith("Efficiency"))
            { colStyle.Format = "P2"; }//2 decimal places - percent

            return colStyle;
        }
        private void AddStyleSTRT()
		{
			DataGridTableStyle Tstyle = new DataGridTableStyle();
			ApplyStyleBase(Tstyle);
			DataGridColumnStyle[] colStyles = new DataGridColumnStyle[4]{
																			AddColumnStyle("Program_ID",		"Program ID",	0, false),
																			AddColumnStyle("Program_Version",	"Version",		75, false),
																			AddColumnStyle("Cpu_ID",			"CPU ID",		125, false),
																			AddColumnStyle("Start_Time",		"Start Time",	125, true),
			};
			Tstyle.GridColumnStyles.AddRange(colStyles);
			dataGrid1.TableStyles.Add(Tstyle);
		}
		private void AddStyleT002()
		{
			DataGridTableStyle Tstyle = new DataGridTableStyle();
			ApplyStyleBase(Tstyle);
			DataGridColumnStyle[] colStyles = new DataGridColumnStyle[16]{
						
																			 AddColumnStyle("Vse_Task_ID",		"Task ID",		55, false),	
																			 AddColumnStyle("FTP_Node_Name",	"Node Name",	140, false),
																			 AddColumnStyle("FTP_User_ID",		"User ID",		0, false),
																			 
																			 AddColumnStyle("Vse_IP",			"VSE IP",		0, false),
																			 AddColumnStyle("Vse_Port",			"VSE Port",		75, false),
																			 AddColumnStyle("Client_Port",		"Client Port",	75, false),
																			 AddColumnStyle("Client_IP",		"Client IP",	0, false),
																			 AddColumnStyle("Foreign_Data_IP",	"Forgn Data IP",0, false),

																			 AddColumnStyle("Files_Sent",		"Files Sent",	0, false),
																			 AddColumnStyle("Files_Received",	"Files Rcvd",	0, false),
																			 AddColumnStyle("Bytes_SentAcked",	"Bytes Sent",	0, false),
																			 AddColumnStyle("Bytes_Received",	"Bytes Rcvd",	0, false),

																			 //AddColumnStyle("General_Flag",		"Flag Val",		50, false),
																			 AddColumnStyle("Flag2",			"Type",			75, false),
																			 //AddColumnStyle("SSL_Flag",			"SSL Val",		50, false),
																			 AddColumnStyle("FlagSSL",			"SSL",			50, false),
																				
																			 AddColumnStyle("Start_Time",		"Start Time",	125, true),
																			 AddColumnStyle("End_Time",			"End Time",		125, true),
																			 
			};
			Tstyle.GridColumnStyles.AddRange(colStyles);
			dataGrid1.TableStyles.Add(Tstyle);
		}
		private void AddStyleT004()
		{
			DataGridTableStyle Tstyle = new DataGridTableStyle();
			ApplyStyleBase(Tstyle);
			DataGridColumnStyle[] colStyles = new DataGridColumnStyle[28]{
				
																			 AddColumnStyle("Conn_PID",				"PID",			40, false),
																			 AddColumnStyle("Local_Port",			"Local Port",	75, false),
																			 AddColumnStyle("Foreign_Port",			"Forgn Port",	75, false),
																			 AddColumnStyle("Foreign_IP",			"Forgn IP",		0, false),
			
																			 AddColumnStyle("Inbound_Data",			"Dgrams In",		0, false),
																			 AddColumnStyle("Inbound_Bytes",		"Bytes In",			0, false),
																			 AddColumnStyle("Inbound_Data_Dup",		"Dgrams In(Dup)",	0, false),
																			 AddColumnStyle("Inbound_Bytes_Dup",	"Bytes In(Dup)",	0, false),
																			 AddColumnStyle("Inbound_Eff",			"Efficiency In",	0, false),
			
																			 AddColumnStyle("Outbound_Data",		"Dgrams Out",		0, false),
																			 AddColumnStyle("Outbound_Bytes",		"Bytes Out",		0, false),
																			 AddColumnStyle("Outbound_Data_Retr",	"Dgrams Out(Retr)",	105, false),
																			 AddColumnStyle("Outbound_Bytes_Retr",	"Bytes Out(Retr)",	0, false),
																			 AddColumnStyle("Outbound_Eff",			"Efficiency Out",	0, false),
			
																			 AddColumnStyle("Recvs_Issued",			"RECVs Issued",		0, false),
																			 AddColumnStyle("Max_Recv_Window",		"Max RECV Size",	0, false),
																			 AddColumnStyle("Recv_Window_Closed",	"RECV Closed",		0, false),
																			 AddColumnStyle("Sends_Issued",			"SENDs Issued",		0, false),
																			 AddColumnStyle("Max_Send_Window",		"Max SEND Size",	0, false),
																			 AddColumnStyle("Retransmits",			"Retrans Issued",	0, false),
																			 AddColumnStyle("In_Retr_Mode",			"Times in Retrans",	105, false),
			
																			 AddColumnStyle("Highest_Depth",		"Highest Depth",	0, false),
																			 AddColumnStyle("SWS_Count",			"SWS Count",		0, false),
			
																			 AddColumnStyle("Conn_Protocol",		"Protocol",			75, false),
																			 AddColumnStyle("INT_EXT",				"INT/EXT",			60, false),
																			 AddColumnStyle("Conn_State",			"State",			75, false),

																			 AddColumnStyle("Conn_Start_Time",		"Start Time",	125, true),
																			 AddColumnStyle("Conn_End_Time",		"End Time",		125, true),
			};
			Tstyle.GridColumnStyles.AddRange(colStyles);
			dataGrid1.TableStyles.Add(Tstyle);
		}
		private void AddStyleT005()
		{
			DataGridTableStyle Tstyle = new DataGridTableStyle();
			ApplyStyleBase(Tstyle);
			DataGridColumnStyle[] colStyles = new DataGridColumnStyle[8]{
																			 AddColumnStyle("PID",				"PID",				40, false),	
																			 AddColumnStyle("Job_Name",			"Job Name",			0, false),																
																			 AddColumnStyle("Step_Name",		"Step Name",		0, false),
																			 AddColumnStyle("Cpu_Time_Sec",		"CPU time(sec)",	0, false),
																			 AddColumnStyle("Total_IO",			"I/O Count",		0, false),
																			 AddColumnStyle("Duration_Sec",		"Duration(sec)",	0, false),														
																			 AddColumnStyle("Step_Start_Time",	"Start Time",		125, true),
																			 AddColumnStyle("Step_End_Time",	"End Time",			125, true),
																			 
			};
			Tstyle.GridColumnStyles.AddRange(colStyles);
			dataGrid1.TableStyles.Add(Tstyle);
		}
		
		private void LOADSTRT_Click(object sender, System.EventArgs e)
		{
			//MessageBox.Show("Load -> STRT");
			_table.Rows.Clear();
			recordsSTRT.GetDateRange(dateTimePicker1.Value, dateTimePicker2.Value, vseDbDataset1);
			dataGrid1.CaptionText = dateTimePicker1.Text +"  To  "+ dateTimePicker2.Text
				+"  (Count = "+_table.Rows.Count.ToString()+")";
		}
		private void LOADT002_Click(object sender, System.EventArgs e)
		{
			//MessageBox.Show("Load -> T002");
			_table.Rows.Clear();
			recordsT002.GetDateRange(dateTimePicker1.Value, dateTimePicker2.Value, vseDbDataset1);
			dataGrid1.CaptionText = dateTimePicker1.Text +"  To  "+ dateTimePicker2.Text
				+"  (Count = "+_table.Rows.Count.ToString()+")";
		}
		private void LOADT004_Click(object sender, System.EventArgs e)
		{
			//MessageBox.Show("Load -> T004");
			_table.Rows.Clear();
			recordsT004.GetDateRange(dateTimePicker1.Value, dateTimePicker2.Value, vseDbDataset1);
			dataGrid1.CaptionText = dateTimePicker1.Text +"  To  "+ dateTimePicker2.Text
				+"  (Count = "+_table.Rows.Count.ToString()+")";
		}
		private void LOADT005_Click(object sender, System.EventArgs e)
		{
			//MessageBox.Show("Load -> T005");
			_table.Rows.Clear();
			recordsT005.GetDateRange(dateTimePicker1.Value, dateTimePicker2.Value, vseDbDataset1);
			dataGrid1.CaptionText = dateTimePicker1.Text +"  To  "+ dateTimePicker2.Text
				+"  (Count = "+_table.Rows.Count.ToString()+")";
		}
		private void PrintTable_Click(object sender, System.EventArgs e)
		{
			DialogPrint frmPrint = new DialogPrint(label4.Text, dataGrid1);
			frmPrint.ShowDialog(this);
		}

		private int _colClickInd = -1;
		private void dataGrid1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				DataGrid.HitTestInfo hitInfo = dataGrid1.HitTest(e.X,e.Y);
				if(hitInfo.Type == DataGrid.HitTestType.ColumnHeader ||hitInfo.Type == DataGrid.HitTestType.Cell)
				{_colClickInd = hitInfo.Column;}
				else
				{_colClickInd = -1;}
			}
		}		
		private void mHide_Click(object sender, System.EventArgs e)
		{
			if(_colClickInd > -1)
			{
				dataGrid1.TableStyles[0].GridColumnStyles.RemoveAt(_colClickInd);
			}
		}
		private void mShowAll_Click(object sender, System.EventArgs e)
		{
			dataGrid1.TableStyles.Clear();
			switch(_table.TableName)
			{
				case "Startup_Records":
					AddStyleSTRT();
					break;
				case "FTP_Records":
					AddStyleT002();
					break;
				case "Connection_Records":
					AddStyleT004();
					break;
				case "JobStep_Records":
					AddStyleT005();
					break;
			}
			
		}		


		
	}
}
