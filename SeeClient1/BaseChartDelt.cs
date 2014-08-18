using SoftwareFX.ChartFX;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace csi.see.client1
{
	/// <summary>
	/// Summary description for BaseChartDelt.
	/// </summary>
	public class BaseChartDelt : System.Windows.Forms.UserControl
	{
        public static string DateTimeFormat
        {
            get { return "M/d/yy HH:mm:ss"; }
        }
        public static string DateFormat
        {
            get { return "M/d/yy"; }
        }
        public static string TimeFormat
        {
            get { return "HH:mm:ss"; }
        }
		#region MEMBERS
		public SeeChartParams	_chartParams = new SeeChartParams();
		public string			_templateName;
		private bool			_realTime = true;
		private int				_yaxisCount;
		private int				_highrank = 0;
		private DateTime		_currDT;
		private Queue			_ctTimeQ = null;
										
		private DateTime	_prevDT;		
		private double		_prevSecSinceReset;//Use with PJS
		private object[]	_prevVals = null;
		private Hashtable	_prevCpuVals = null;
		private Hashtable	_prevParts = null;			
		private Hashtable	_prevJobs = null;
		private Hashtable	_prevSteps = null;
			
		bool Eff  = false;
		private Hashtable	_prevConnForgnIP = null;
		private Hashtable	_prevConnForgnIPport = null;
		private Hashtable	_prevConnPID = null;
		private Hashtable	_prevConnLocalPort = null;
		
		bool firstForIp = true;//Use this for foreign ips
		//private Hashtable	_prevForgnIP = null;
		#endregion
		#region Designer MEMBERS

        private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.NumericUpDown numericUpDown6;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown numericUpDown5;
		private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonUpdateForgnIP;
		private System.Windows.Forms.Button buttonUpdatePJS;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonUpdateConn;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton8;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.NumericUpDown numericUpDown4;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown3;
		private System.Windows.Forms.Label label10;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlCommandConnPID;
		private System.Data.SqlClient.SqlCommand sqlCommandConnForgnIPport;
		private System.Data.SqlClient.SqlCommand sqlCommandCPU;
		private System.Data.SqlClient.SqlCommand sqlCommandTD;
		private System.Data.SqlClient.SqlCommand sqlCommandConnForgnIP;
		private System.Data.SqlClient.SqlCommand sqlCommandPartCPU;
		private System.Data.DataSet dataSet1;
		private System.Data.DataTable dataTable1;
		private System.Data.DataTable dataTable2;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Data.DataColumn dataColumn3;
		private System.Data.DataColumn dataColumn12;
		private System.Data.DataColumn dataColumn51;
		private System.Data.DataTable dataTable3;
		private System.Data.DataColumn dataColumn4;
		private System.Data.DataColumn dataColumn5;
		private System.Data.DataColumn dataColumn6;
		private System.Data.DataColumn dataColumn15;
		private System.Data.DataColumn dataColumn52;
		private System.Data.DataTable dataTable4;
		private System.Data.DataColumn dataColumn7;
		private System.Data.DataColumn dataColumn8;
		private System.Data.DataColumn dataColumn9;
		private System.Data.DataColumn dataColumn16;
		private System.Data.DataColumn dataColumn53;
		private System.Data.DataTable dataTable5;
		private System.Data.DataColumn dataColumn10;
		private System.Data.DataColumn dataColumn11;
		private System.Data.DataColumn dataColumn13;
		private System.Data.DataColumn dataColumn14;
		private System.Data.DataColumn dataColumn49;
		private System.Data.DataTable dataTable14;
		private System.Data.DataTable dataTable15;
		private System.Data.DataTable dataTable16;
		private System.Data.DataTable dataTable17;
		private System.Data.DataTable dataTable6;
		private System.Data.DataColumn dataColumn17;
		private System.Data.DataColumn dataColumn18;
		private System.Data.DataColumn dataColumn19;
		private System.Data.DataColumn dataColumn20;
		private System.Data.DataColumn dataColumn55;
		private System.Data.DataTable dataTable7;
		private System.Data.DataColumn dataColumn21;
		private System.Data.DataColumn dataColumn22;
		private System.Data.DataColumn dataColumn23;
		private System.Data.DataColumn dataColumn24;
		private System.Data.DataColumn dataColumn56;
		private System.Data.DataTable dataTable8;
		private System.Data.DataColumn dataColumn25;
		private System.Data.DataColumn dataColumn26;
		private System.Data.DataColumn dataColumn27;
		private System.Data.DataColumn dataColumn28;
		private System.Data.DataColumn dataColumn57;
		private System.Data.DataTable dataTable9;
		private System.Data.DataColumn dataColumn29;
		private System.Data.DataColumn dataColumn30;
		private System.Data.DataColumn dataColumn31;
		private System.Data.DataColumn dataColumn32;
		private System.Data.DataColumn dataColumn58;
		private System.Data.DataTable dataTable12;
		private System.Data.DataColumn dataColumn45;
		private System.Data.DataColumn dataColumn46;
		private System.Data.DataColumn dataColumn47;
		private System.Data.DataColumn dataColumn48;
		private System.Data.DataColumn dataColumn50;
		private System.Data.SqlClient.SqlCommand sqlCommand1;
		private System.Data.SqlClient.SqlCommand sqlCommandConnLocalPort;
		private System.Data.SqlClient.SqlCommand sqlCommandPartSIO;
		private System.Windows.Forms.Panel panelPartOptions;
		private System.Windows.Forms.Panel panelConnOptions;
		private System.Windows.Forms.Panel panelForgnIpOptions;
		private SoftwareFX.ChartFX.Chart chart1;
		private System.Data.DataTable dataTable21;
		private System.Data.DataTable dataTable22;
		private System.Data.DataTable dataTable23;
		private System.Data.DataColumn dataColumn61;
		private System.Data.DataColumn dataColumn62;
		private System.Data.DataColumn dataColumn63;
		private System.Data.DataColumn dataColumn64;
		private System.Data.DataColumn dataColumn65;
		private System.Data.DataColumn dataColumn66;
		private System.Data.DataColumn dataColumn67;
		private System.Data.DataColumn dataColumn68;
		private System.Data.DataColumn dataColumn69;
		private System.Data.DataColumn dataColumn70;
		private System.Data.SqlClient.SqlCommand sqlCommandForgnIP;
		#endregion
		
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		#region PROPERTIES
		public bool ShowToolbar
		{
			set{chart1.ToolBar = value;}
		}
		public string TemplateName
		{
			get
			{return _templateName;}
			set
			{
				chart1.Titles[0].Text = value;
				chart1.Titles[1].Text = "(Delta)";
				_templateName = value;
			}
		}
		public string SqlConnectString
		{
			get{return sqlConnection1.ConnectionString;}
			set{sqlConnection1.ConnectionString = value;}
		}
		#endregion
		
		public BaseChartDelt()
		{
			InitializeComponent();// This call is required by the Windows.Forms Form Designer.
			
            
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseChartDelt));
            SoftwareFX.ChartFX.Borders.GradientBackground gradientBackground1 = new SoftwareFX.ChartFX.Borders.GradientBackground();
            SoftwareFX.ChartFX.Borders.ImageBorder imageBorder1 = new SoftwareFX.ChartFX.Borders.ImageBorder(SoftwareFX.ChartFX.Borders.ImageBorderType.Embed);
            SoftwareFX.ChartFX.TitleDockable titleDockable1 = new SoftwareFX.ChartFX.TitleDockable();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandCPU = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandPartCPU = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandPartSIO = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandTD = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandConnForgnIPport = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandConnForgnIP = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandConnLocalPort = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandConnPID = new System.Data.SqlClient.SqlCommand();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn51 = new System.Data.DataColumn();
            this.dataTable3 = new System.Data.DataTable();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataColumn52 = new System.Data.DataColumn();
            this.dataTable4 = new System.Data.DataTable();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn53 = new System.Data.DataColumn();
            this.dataTable5 = new System.Data.DataTable();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn49 = new System.Data.DataColumn();
            this.dataTable14 = new System.Data.DataTable();
            this.dataTable15 = new System.Data.DataTable();
            this.dataTable16 = new System.Data.DataTable();
            this.dataTable17 = new System.Data.DataTable();
            this.dataTable6 = new System.Data.DataTable();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn18 = new System.Data.DataColumn();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn55 = new System.Data.DataColumn();
            this.dataTable7 = new System.Data.DataTable();
            this.dataColumn21 = new System.Data.DataColumn();
            this.dataColumn22 = new System.Data.DataColumn();
            this.dataColumn23 = new System.Data.DataColumn();
            this.dataColumn24 = new System.Data.DataColumn();
            this.dataColumn56 = new System.Data.DataColumn();
            this.dataTable8 = new System.Data.DataTable();
            this.dataColumn25 = new System.Data.DataColumn();
            this.dataColumn26 = new System.Data.DataColumn();
            this.dataColumn27 = new System.Data.DataColumn();
            this.dataColumn28 = new System.Data.DataColumn();
            this.dataColumn57 = new System.Data.DataColumn();
            this.dataTable9 = new System.Data.DataTable();
            this.dataColumn29 = new System.Data.DataColumn();
            this.dataColumn30 = new System.Data.DataColumn();
            this.dataColumn31 = new System.Data.DataColumn();
            this.dataColumn32 = new System.Data.DataColumn();
            this.dataColumn58 = new System.Data.DataColumn();
            this.dataTable12 = new System.Data.DataTable();
            this.dataColumn45 = new System.Data.DataColumn();
            this.dataColumn46 = new System.Data.DataColumn();
            this.dataColumn47 = new System.Data.DataColumn();
            this.dataColumn48 = new System.Data.DataColumn();
            this.dataColumn50 = new System.Data.DataColumn();
            this.dataTable21 = new System.Data.DataTable();
            this.dataTable22 = new System.Data.DataTable();
            this.dataColumn61 = new System.Data.DataColumn();
            this.dataColumn62 = new System.Data.DataColumn();
            this.dataColumn63 = new System.Data.DataColumn();
            this.dataColumn64 = new System.Data.DataColumn();
            this.dataColumn65 = new System.Data.DataColumn();
            this.dataTable23 = new System.Data.DataTable();
            this.dataColumn66 = new System.Data.DataColumn();
            this.dataColumn67 = new System.Data.DataColumn();
            this.dataColumn68 = new System.Data.DataColumn();
            this.dataColumn69 = new System.Data.DataColumn();
            this.dataColumn70 = new System.Data.DataColumn();
            this.panelPartOptions = new System.Windows.Forms.Panel();
            this.buttonUpdatePJS = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panelConnOptions = new System.Windows.Forms.Panel();
            this.buttonUpdateConn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.panelForgnIpOptions = new System.Windows.Forms.Panel();
            this.buttonUpdateForgnIP = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.chart1 = new SoftwareFX.ChartFX.Chart();
            this.sqlCommandForgnIP = new System.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable23)).BeginInit();
            this.panelPartOptions.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panelConnOptions.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.panelForgnIpOptions.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "workstation id=DANSDELL;packet size=4096;integrated security=SSPI;data source=\"DA" +
                "NSDELL\\SEEVSE\";persist security info=False;initial catalog=VseDb";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.Connection = this.sqlConnection1;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pollTime", System.Data.SqlDbType.DateTime, 8, "Poll_Time")});
            // 
            // sqlCommandCPU
            // 
            this.sqlCommandCPU.CommandText = resources.GetString("sqlCommandCPU.CommandText");
            this.sqlCommandCPU.Connection = this.sqlConnection1;
            this.sqlCommandCPU.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pollTime", System.Data.SqlDbType.DateTime, 8, "Poll_Time")});
            // 
            // sqlCommandPartCPU
            // 
            this.sqlCommandPartCPU.CommandText = resources.GetString("sqlCommandPartCPU.CommandText");
            this.sqlCommandPartCPU.Connection = this.sqlConnection1;
            this.sqlCommandPartCPU.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pollTime", System.Data.SqlDbType.DateTime, 8, "Poll_Time")});
            // 
            // sqlCommandPartSIO
            // 
            this.sqlCommandPartSIO.CommandText = "SELECT Poll_Time, Partition_ID, VSE_Job_Name, VSE_Step_Name, Job_Start_Time, Step" +
                "_Start_Time, SIO_Count FROM Partition_Job_Step WHERE (Poll_Time = @pollTime) ORD" +
                "ER BY SIO_Count DESC";
            this.sqlCommandPartSIO.Connection = this.sqlConnection1;
            this.sqlCommandPartSIO.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pollTime", System.Data.SqlDbType.DateTime, 8, "Poll_Time")});
            // 
            // sqlCommandTD
            // 
            this.sqlCommandTD.CommandText = "SELECT Poll_Time, CPU_ID, CPU_State, Dispatch_Cycles FROM CPU_Stats WHERE (Poll_T" +
                "ime = @pollTime) ORDER BY CPU_ID";
            this.sqlCommandTD.Connection = this.sqlConnection1;
            this.sqlCommandTD.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pollTime", System.Data.SqlDbType.DateTime, 8, "Poll_Time")});
            // 
            // sqlCommandConnForgnIPport
            // 
            this.sqlCommandConnForgnIPport.CommandText = "SELECT Foreign_IP, Foreign_Port FROM Connection_Stats WHERE (Poll_Time = @pollTim" +
                "e)";
            this.sqlCommandConnForgnIPport.Connection = this.sqlConnection1;
            this.sqlCommandConnForgnIPport.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pollTime", System.Data.SqlDbType.DateTime, 8, "Poll_Time")});
            // 
            // sqlCommandConnForgnIP
            // 
            this.sqlCommandConnForgnIP.CommandText = "SELECT Foreign_IP FROM Connection_Stats WHERE (Poll_Time = @pollTime)";
            this.sqlCommandConnForgnIP.Connection = this.sqlConnection1;
            this.sqlCommandConnForgnIP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pollTime", System.Data.SqlDbType.DateTime, 8, "Poll_Time")});
            // 
            // sqlCommandConnLocalPort
            // 
            this.sqlCommandConnLocalPort.CommandText = "SELECT Local_Port FROM Connection_Stats WHERE (Poll_Time = @pollTime)";
            this.sqlCommandConnLocalPort.Connection = this.sqlConnection1;
            this.sqlCommandConnLocalPort.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pollTime", System.Data.SqlDbType.DateTime, 8, "Poll_Time")});
            // 
            // sqlCommandConnPID
            // 
            this.sqlCommandConnPID.CommandText = "SELECT Conn_PID FROM Connection_Stats WHERE (Poll_Time = @pollTime)";
            this.sqlCommandConnPID.Connection = this.sqlConnection1;
            this.sqlCommandConnPID.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pollTime", System.Data.SqlDbType.DateTime, 8, "Poll_Time")});
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable2,
            this.dataTable3,
            this.dataTable4,
            this.dataTable5,
            this.dataTable14,
            this.dataTable15,
            this.dataTable16,
            this.dataTable17,
            this.dataTable6,
            this.dataTable7,
            this.dataTable8,
            this.dataTable9,
            this.dataTable12,
            this.dataTable21,
            this.dataTable22,
            this.dataTable23});
            // 
            // dataTable1
            // 
            this.dataTable1.TableName = "rawPJS";
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn12,
            this.dataColumn51});
            this.dataTable2.TableName = "Partitions";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
            this.dataColumn1.ColumnName = "prevDT";
            this.dataColumn1.DataType = typeof(System.DateTime);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Key";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Value";
            this.dataColumn3.DataType = typeof(double);
            // 
            // dataColumn12
            // 
            this.dataColumn12.AllowDBNull = false;
            this.dataColumn12.ColumnName = "Rank";
            this.dataColumn12.DataType = typeof(int);
            // 
            // dataColumn51
            // 
            this.dataColumn51.ColumnName = "newDT";
            this.dataColumn51.DataType = typeof(System.DateTime);
            // 
            // dataTable3
            // 
            this.dataTable3.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn15,
            this.dataColumn52});
            this.dataTable3.TableName = "Jobs";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "prevDT";
            this.dataColumn4.DataType = typeof(System.DateTime);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Key";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "Value";
            this.dataColumn6.DataType = typeof(double);
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "Rank";
            this.dataColumn15.DataType = typeof(int);
            // 
            // dataColumn52
            // 
            this.dataColumn52.ColumnName = "newDT";
            this.dataColumn52.DataType = typeof(System.DateTime);
            // 
            // dataTable4
            // 
            this.dataTable4.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn16,
            this.dataColumn53});
            this.dataTable4.TableName = "Steps";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "prevDT";
            this.dataColumn7.DataType = typeof(System.DateTime);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "Key";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "Value";
            this.dataColumn9.DataType = typeof(double);
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "Rank";
            this.dataColumn16.DataType = typeof(int);
            // 
            // dataColumn53
            // 
            this.dataColumn53.ColumnName = "newDT";
            this.dataColumn53.DataType = typeof(System.DateTime);
            // 
            // dataTable5
            // 
            this.dataTable5.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn13,
            this.dataColumn14,
            this.dataColumn49});
            this.dataTable5.TableName = "DisplayPJS";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "prevDT";
            this.dataColumn10.DataType = typeof(System.DateTime);
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "Key";
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "Value";
            this.dataColumn13.DataType = typeof(double);
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "Rank";
            this.dataColumn14.DataType = typeof(int);
            // 
            // dataColumn49
            // 
            this.dataColumn49.ColumnName = "newDT";
            // 
            // dataTable14
            // 
            this.dataTable14.TableName = "connForgnIP";
            // 
            // dataTable15
            // 
            this.dataTable15.TableName = "connForgnIPport";
            // 
            // dataTable16
            // 
            this.dataTable16.TableName = "connPID";
            // 
            // dataTable17
            // 
            this.dataTable17.TableName = "connLocalPort";
            // 
            // dataTable6
            // 
            this.dataTable6.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn17,
            this.dataColumn18,
            this.dataColumn19,
            this.dataColumn20,
            this.dataColumn55});
            this.dataTable6.TableName = "ConnForgnIP";
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "prevDT";
            this.dataColumn17.DataType = typeof(System.DateTime);
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "Key";
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "Value";
            this.dataColumn19.DataType = typeof(double);
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "Rank";
            this.dataColumn20.DataType = typeof(int);
            // 
            // dataColumn55
            // 
            this.dataColumn55.ColumnName = "newDT";
            this.dataColumn55.DataType = typeof(System.DateTime);
            // 
            // dataTable7
            // 
            this.dataTable7.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn21,
            this.dataColumn22,
            this.dataColumn23,
            this.dataColumn24,
            this.dataColumn56});
            this.dataTable7.TableName = "ConnForgnIPport";
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "prevDT";
            this.dataColumn21.DataType = typeof(System.DateTime);
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "Key";
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "Value";
            this.dataColumn23.DataType = typeof(double);
            // 
            // dataColumn24
            // 
            this.dataColumn24.ColumnName = "Rank";
            this.dataColumn24.DataType = typeof(int);
            // 
            // dataColumn56
            // 
            this.dataColumn56.ColumnName = "newDT";
            this.dataColumn56.DataType = typeof(System.DateTime);
            // 
            // dataTable8
            // 
            this.dataTable8.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn25,
            this.dataColumn26,
            this.dataColumn27,
            this.dataColumn28,
            this.dataColumn57});
            this.dataTable8.TableName = "ConnPID";
            // 
            // dataColumn25
            // 
            this.dataColumn25.ColumnName = "prevDT";
            this.dataColumn25.DataType = typeof(System.DateTime);
            // 
            // dataColumn26
            // 
            this.dataColumn26.ColumnName = "Key";
            // 
            // dataColumn27
            // 
            this.dataColumn27.ColumnName = "Value";
            this.dataColumn27.DataType = typeof(double);
            // 
            // dataColumn28
            // 
            this.dataColumn28.ColumnName = "Rank";
            this.dataColumn28.DataType = typeof(int);
            // 
            // dataColumn57
            // 
            this.dataColumn57.ColumnName = "newDT";
            this.dataColumn57.DataType = typeof(System.DateTime);
            // 
            // dataTable9
            // 
            this.dataTable9.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn29,
            this.dataColumn30,
            this.dataColumn31,
            this.dataColumn32,
            this.dataColumn58});
            this.dataTable9.TableName = "ConnLocalPort";
            // 
            // dataColumn29
            // 
            this.dataColumn29.ColumnName = "prevDT";
            this.dataColumn29.DataType = typeof(System.DateTime);
            // 
            // dataColumn30
            // 
            this.dataColumn30.ColumnName = "Key";
            // 
            // dataColumn31
            // 
            this.dataColumn31.ColumnName = "Value";
            this.dataColumn31.DataType = typeof(double);
            // 
            // dataColumn32
            // 
            this.dataColumn32.ColumnName = "Rank";
            this.dataColumn32.DataType = typeof(int);
            // 
            // dataColumn58
            // 
            this.dataColumn58.ColumnName = "newDT";
            this.dataColumn58.DataType = typeof(System.DateTime);
            // 
            // dataTable12
            // 
            this.dataTable12.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn45,
            this.dataColumn46,
            this.dataColumn47,
            this.dataColumn48,
            this.dataColumn50});
            this.dataTable12.TableName = "DisplayConn";
            // 
            // dataColumn45
            // 
            this.dataColumn45.ColumnName = "prevDT";
            this.dataColumn45.DataType = typeof(System.DateTime);
            // 
            // dataColumn46
            // 
            this.dataColumn46.ColumnName = "Key";
            // 
            // dataColumn47
            // 
            this.dataColumn47.ColumnName = "Value";
            this.dataColumn47.DataType = typeof(double);
            // 
            // dataColumn48
            // 
            this.dataColumn48.ColumnName = "Rank";
            this.dataColumn48.DataType = typeof(int);
            // 
            // dataColumn50
            // 
            this.dataColumn50.ColumnName = "newDT";
            // 
            // dataTable21
            // 
            this.dataTable21.TableName = "rawForgnIP";
            // 
            // dataTable22
            // 
            this.dataTable22.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn61,
            this.dataColumn62,
            this.dataColumn63,
            this.dataColumn64,
            this.dataColumn65});
            this.dataTable22.TableName = "ForgnIP";
            // 
            // dataColumn61
            // 
            this.dataColumn61.ColumnName = "prevDT";
            this.dataColumn61.DataType = typeof(System.DateTime);
            // 
            // dataColumn62
            // 
            this.dataColumn62.ColumnName = "Key";
            // 
            // dataColumn63
            // 
            this.dataColumn63.ColumnName = "Value";
            this.dataColumn63.DataType = typeof(double);
            // 
            // dataColumn64
            // 
            this.dataColumn64.ColumnName = "Rank";
            this.dataColumn64.DataType = typeof(int);
            // 
            // dataColumn65
            // 
            this.dataColumn65.ColumnName = "newDT";
            this.dataColumn65.DataType = typeof(System.DateTime);
            // 
            // dataTable23
            // 
            this.dataTable23.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn66,
            this.dataColumn67,
            this.dataColumn68,
            this.dataColumn69,
            this.dataColumn70});
            this.dataTable23.TableName = "DisplayForgnIP";
            // 
            // dataColumn66
            // 
            this.dataColumn66.ColumnName = "prevDT";
            this.dataColumn66.DataType = typeof(System.DateTime);
            // 
            // dataColumn67
            // 
            this.dataColumn67.ColumnName = "Key";
            // 
            // dataColumn68
            // 
            this.dataColumn68.ColumnName = "Value";
            this.dataColumn68.DataType = typeof(double);
            // 
            // dataColumn69
            // 
            this.dataColumn69.ColumnName = "Rank";
            this.dataColumn69.DataType = typeof(int);
            // 
            // dataColumn70
            // 
            this.dataColumn70.ColumnName = "newDT";
            // 
            // panelPartOptions
            // 
            this.panelPartOptions.BackColor = System.Drawing.SystemColors.Window;
            this.panelPartOptions.Controls.Add(this.buttonUpdatePJS);
            this.panelPartOptions.Controls.Add(this.panel3);
            this.panelPartOptions.Controls.Add(this.label3);
            this.panelPartOptions.Controls.Add(this.panel1);
            this.panelPartOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelPartOptions.Location = new System.Drawing.Point(492, 0);
            this.panelPartOptions.Name = "panelPartOptions";
            this.panelPartOptions.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.panelPartOptions.Size = new System.Drawing.Size(84, 458);
            this.panelPartOptions.TabIndex = 45;
            this.panelPartOptions.Visible = false;
            // 
            // buttonUpdatePJS
            // 
            this.buttonUpdatePJS.BackColor = System.Drawing.SystemColors.Control;
            this.buttonUpdatePJS.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonUpdatePJS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdatePJS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonUpdatePJS.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonUpdatePJS.Location = new System.Drawing.Point(0, 188);
            this.buttonUpdatePJS.Name = "buttonUpdatePJS";
            this.buttonUpdatePJS.Size = new System.Drawing.Size(80, 23);
            this.buttonUpdatePJS.TabIndex = 47;
            this.buttonUpdatePJS.Text = "Apply";
            this.buttonUpdatePJS.UseVisualStyleBackColor = false;
            this.buttonUpdatePJS.Click += new System.EventHandler(this.buttonUpdatePJS_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButton3);
            this.panel3.Controls.Add(this.radioButton2);
            this.panel3.Controls.Add(this.radioButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel3.Location = new System.Drawing.Point(0, 108);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.panel3.Size = new System.Drawing.Size(80, 80);
            this.panel3.TabIndex = 46;
            // 
            // radioButton3
            // 
            this.radioButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton3.Location = new System.Drawing.Point(4, 48);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(76, 24);
            this.radioButton3.TabIndex = 11;
            this.radioButton3.Text = "Steps";
            this.radioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton2
            // 
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton2.Location = new System.Drawing.Point(4, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 24);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.Text = "Jobs";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton1.Location = new System.Drawing.Point(4, 0);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 24);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Partitions";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(0, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 45;
            this.label3.Text = "Group By";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 84);
            this.panel1.TabIndex = 44;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDown2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.Location = new System.Drawing.Point(0, 57);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(80, 21);
            this.numericUpDown2.TabIndex = 34;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(0, 41);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.panel5.Size = new System.Drawing.Size(80, 16);
            this.panel5.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "To";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDown1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(0, 20);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(80, 21);
            this.numericUpDown1.TabIndex = 30;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Display";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelConnOptions
            // 
            this.panelConnOptions.BackColor = System.Drawing.SystemColors.Window;
            this.panelConnOptions.Controls.Add(this.buttonUpdateConn);
            this.panelConnOptions.Controls.Add(this.panel2);
            this.panelConnOptions.Controls.Add(this.label2);
            this.panelConnOptions.Controls.Add(this.panel9);
            this.panelConnOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelConnOptions.Location = new System.Drawing.Point(408, 0);
            this.panelConnOptions.Name = "panelConnOptions";
            this.panelConnOptions.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.panelConnOptions.Size = new System.Drawing.Size(84, 458);
            this.panelConnOptions.TabIndex = 46;
            this.panelConnOptions.Visible = false;
            // 
            // buttonUpdateConn
            // 
            this.buttonUpdateConn.BackColor = System.Drawing.SystemColors.Control;
            this.buttonUpdateConn.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonUpdateConn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateConn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonUpdateConn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonUpdateConn.Location = new System.Drawing.Point(0, 228);
            this.buttonUpdateConn.Name = "buttonUpdateConn";
            this.buttonUpdateConn.Size = new System.Drawing.Size(80, 23);
            this.buttonUpdateConn.TabIndex = 46;
            this.buttonUpdateConn.Text = "Apply";
            this.buttonUpdateConn.UseVisualStyleBackColor = false;
            this.buttonUpdateConn.Click += new System.EventHandler(this.buttonUpdateConn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton7);
            this.panel2.Controls.Add(this.radioButton6);
            this.panel2.Controls.Add(this.radioButton5);
            this.panel2.Controls.Add(this.radioButton8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel2.Location = new System.Drawing.Point(0, 108);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.panel2.Size = new System.Drawing.Size(80, 120);
            this.panel2.TabIndex = 45;
            // 
            // radioButton7
            // 
            this.radioButton7.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radioButton7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton7.Location = new System.Drawing.Point(4, 88);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(76, 24);
            this.radioButton7.TabIndex = 38;
            this.radioButton7.Tag = "PID";
            this.radioButton7.Text = "PID";
            this.radioButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton6
            // 
            this.radioButton6.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radioButton6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton6.Location = new System.Drawing.Point(4, 56);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(76, 32);
            this.radioButton6.TabIndex = 37;
            this.radioButton6.Tag = "Foreign_IP, Foreign_Port";
            this.radioButton6.Text = "Forgn IP: Port";
            this.radioButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton5
            // 
            this.radioButton5.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radioButton5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton5.Location = new System.Drawing.Point(4, 32);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(76, 24);
            this.radioButton5.TabIndex = 36;
            this.radioButton5.Tag = "Foreign_IP";
            this.radioButton5.Text = "Forgn IP";
            this.radioButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton8
            // 
            this.radioButton8.Checked = true;
            this.radioButton8.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radioButton8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton8.Location = new System.Drawing.Point(4, 0);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(76, 32);
            this.radioButton8.TabIndex = 35;
            this.radioButton8.TabStop = true;
            this.radioButton8.Tag = "Local_Port";
            this.radioButton8.Text = "Local Port";
            this.radioButton8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(0, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 44;
            this.label2.Text = "Group By";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.numericUpDown4);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.numericUpDown3);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(80, 84);
            this.panel9.TabIndex = 43;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDown4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown4.Location = new System.Drawing.Point(0, 57);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(80, 21);
            this.numericUpDown4.TabIndex = 34;
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown4.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label1);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel10.Location = new System.Drawing.Point(0, 41);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.panel10.Size = new System.Drawing.Size(80, 16);
            this.panel10.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "To";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDown3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown3.Location = new System.Drawing.Point(0, 20);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(80, 21);
            this.numericUpDown3.TabIndex = 30;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Display";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelForgnIpOptions
            // 
            this.panelForgnIpOptions.BackColor = System.Drawing.SystemColors.Window;
            this.panelForgnIpOptions.Controls.Add(this.buttonUpdateForgnIP);
            this.panelForgnIpOptions.Controls.Add(this.panel13);
            this.panelForgnIpOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelForgnIpOptions.Location = new System.Drawing.Point(324, 0);
            this.panelForgnIpOptions.Name = "panelForgnIpOptions";
            this.panelForgnIpOptions.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.panelForgnIpOptions.Size = new System.Drawing.Size(84, 458);
            this.panelForgnIpOptions.TabIndex = 47;
            this.panelForgnIpOptions.Visible = false;
            // 
            // buttonUpdateForgnIP
            // 
            this.buttonUpdateForgnIP.BackColor = System.Drawing.SystemColors.Control;
            this.buttonUpdateForgnIP.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonUpdateForgnIP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateForgnIP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonUpdateForgnIP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonUpdateForgnIP.Location = new System.Drawing.Point(0, 84);
            this.buttonUpdateForgnIP.Name = "buttonUpdateForgnIP";
            this.buttonUpdateForgnIP.Size = new System.Drawing.Size(80, 23);
            this.buttonUpdateForgnIP.TabIndex = 32;
            this.buttonUpdateForgnIP.Text = "Apply";
            this.buttonUpdateForgnIP.UseVisualStyleBackColor = false;
            this.buttonUpdateForgnIP.Click += new System.EventHandler(this.buttonUpdateForgnIP_Click);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.numericUpDown6);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.numericUpDown5);
            this.panel13.Controls.Add(this.label12);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(80, 84);
            this.panel13.TabIndex = 31;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDown6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown6.Location = new System.Drawing.Point(0, 57);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown6.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(80, 21);
            this.numericUpDown6.TabIndex = 34;
            this.numericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown6.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label11);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel14.Location = new System.Drawing.Point(0, 41);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.panel14.Size = new System.Drawing.Size(80, 16);
            this.panel14.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 16);
            this.label11.TabIndex = 32;
            this.label11.Text = "To";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDown5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown5.Location = new System.Drawing.Point(0, 20);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(80, 21);
            this.numericUpDown5.TabIndex = 30;
            this.numericUpDown5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown5.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "Display";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chart1
            // 
            this.chart1.AxesStyle = SoftwareFX.ChartFX.AxesStyle.Frame3D;
            this.chart1.AxisX.Gridlines = true;
            this.chart1.AxisX.Title.Text = "Time";
            this.chart1.AxisY.AlternateColor = System.Drawing.Color.White;
            this.chart1.AxisY.LabelsFormat.Decimals = 0;
            this.chart1.AxisY.Title.Text = "Count";
            gradientBackground1.Type = SoftwareFX.ChartFX.Borders.GradientType.BackwardDiagonal;
            this.chart1.BackObject = gradientBackground1;
            this.chart1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            imageBorder1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            imageBorder1.Type = SoftwareFX.ChartFX.Borders.ImageBorderType.Embed;
            this.chart1.BorderObject = imageBorder1;
            this.chart1.DataEditorObj.BackColorDataAlternate = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chart1.DesignTimeData = "C:\\Program Files\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.chart1.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.chart1.InsideColor = System.Drawing.Color.White;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.MarkerSize = ((short)(4));
            this.chart1.Name = "chart1";
            this.chart1.NSeries = 3;
            this.chart1.NValues = 10;
            this.chart1.Palette = "Default.ChartFX6";
            this.chart1.SerLegBox = true;
            this.chart1.Size = new System.Drawing.Size(324, 458);
            this.chart1.TabIndex = 48;
            titleDockable1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            titleDockable1.Text = "Title";
            titleDockable1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.chart1.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable1});
            this.chart1.ToolBar = true;
            // 
            // sqlCommandForgnIP
            // 
            this.sqlCommandForgnIP.CommandText = "SELECT IP_Address FROM ForeignIP_Stats WHERE (Poll_Time = @pollTime) ORDER BY IP_" +
                "Address";
            this.sqlCommandForgnIP.Connection = this.sqlConnection1;
            this.sqlCommandForgnIP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pollTime", System.Data.SqlDbType.DateTime, 8, "Poll_Time")});
            // 
            // BaseChartDelt
            // 
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panelForgnIpOptions);
            this.Controls.Add(this.panelConnOptions);
            this.Controls.Add(this.panelPartOptions);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BaseChartDelt";
            this.Size = new System.Drawing.Size(576, 458);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable23)).EndInit();
            this.panelPartOptions.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panelConnOptions.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.panelForgnIpOptions.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
        public SoftwareFX.ChartFX.Chart CHART
        {
            get { return chart1; }
        }
		#region METHODS
		private string CreateXlabel(DateTime start, DateTime end)
		{
			string xlabel =	start.ToString(DateTimeFormat)
				+ Environment.NewLine + " - " + end.ToString(DateTimeFormat)
				+ Environment.NewLine + " ";
			/*
			string xlabel =	start.ToString(FormMain.DateFormat)
			+ Environment.NewLine+ start.ToString(FormMain.TimeFormat) + " - " + end.ToString(FormMain.TimeFormat)
			+ Environment.NewLine + " ";
			*/
			return xlabel;
		}
		public void FormatChart(string Name, bool RealTime)
		{
            /* Removing items causes ChartFX to recalculate indexes */
            #region Remove Toolbar buttons/commands
            #region Personalized Charts
            for (int cnt = 0; cnt < 3; cnt++)
            {//Remove "Load My Chart","Save My Chart",spacer
                chart1.Commands[(int)CommandID.PersonalizedOptions].RemoveSubCommand(0);
            }
            #endregion
            #region Gallery
            chart1.Commands[(int)CommandID.Gallery].RemoveSubCommand(5);//Remove gallery type
            for (int cnt = 0; cnt < 5; cnt++)
            {//Remove 5 gallery types
                chart1.Commands[(int)CommandID.Gallery].RemoveSubCommand(9);
            }
            for (int cnt = 0; cnt < 4; cnt++)
            {//Remove 5 gallery types
                chart1.Commands[(int)CommandID.Gallery].RemoveSubCommand(10);
            }
            #endregion
            chart1.ToolBarObj.RemoveAt(18);//Remove zoom button
            chart1.ToolBarObj.RemoveAt(5);//Remove antialiasing button
            #endregion
            #region Add Toolbar commands
            //int nPictCheck =chart1.Commands.AddPicture(imageList1.Images[0]);
            // -1 = Check mark
            chart1.Commands.AddCommand(1);//X axis "Scroll Bar"
            chart1.Commands[1].Style = CommandStyle.TwoState;
            chart1.Commands[1].Text = "Scroll Bar";
            chart1.Commands[1].Picture = -1;
            chart1.Commands[1].Checked = false;

            chart1.Commands.AddCommand(2);//Y-axis "Start at Zero"
            chart1.Commands[2].Style = CommandStyle.TwoState;
            chart1.Commands[2].Text = "Start at Zero";
            chart1.Commands[2].Picture = -1;
            chart1.Commands[2].Checked = true;

            chart1.Commands.AddCommand(3);//Y-axis "Multi-Pane"
            chart1.Commands[3].Style = CommandStyle.TwoState;
            chart1.Commands[3].Text = "Multi-Pane";
            chart1.Commands[3].Picture = -1;
            chart1.Commands[3].Checked = false;

            chart1.Commands[(int)CommandID.AxesSettings].InsertSubCommands(1, 6);//Insert X-axis command
            chart1.Commands[(int)CommandID.AxesSettings].SubCommandID[6] = 1;
            chart1.Commands[(int)CommandID.AxesSettings].InsertSubCommands(2, 3);//Insert Y-axis commands
            chart1.Commands[(int)CommandID.AxesSettings].SubCommandID[3] = 2;
            chart1.Commands[(int)CommandID.AxesSettings].SubCommandID[4] = 3;
            #endregion
            chart1.UserCommand += new CommandUIEventHandler(chart1_UserCommand);
            chart1.ToolBarObj.InsertAt(0, 1);//Insert the File menu on the Toolbar
            chart1.ToolBarObj[0] = (int)CommandID.File;
            chart1.Commands[(int)CommandID.File].Text = "Options";//Change 'File' to 'Options'
            chart1.Commands[(int)CommandID.File].RemoveSubCommand(0);//Remove the Open chart command
            chart1.Commands[(int)CommandID.DataEditor].Text = "Data View";

            //chart1.DataEditorObj.XValuesAsHeaders = true;
			TemplateName = Name;
            chart1.Printer.Orientation = SoftwareFX.ChartFX.Orientation.Landscape;
			//chart1.AxisX.LabelAngle = 90;
            chart1.AxisX.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chart1.AxisX.LabelsFormat.Format = AxisFormat.DateTime;
			if(RealTime)
			{
				_realTime = true;
				//chart1.ToolBar = false;
				chart1.RealTimeSettings.Style = RealTimeStyle.NoWaitArrow;
				chart1.RealTimeSettings.BufferSize = 10;
			}
			else
			{
				_realTime = false;
				chart1.DataSourceSettings.DataType[0] = DataType.Label;		//["Start Time"]
				chart1.DataSourceSettings.DataType[1] = DataType.NotUsed;	//["End Time"]
				chart1.DataSourceSettings.DataType[2] = DataType.Label;		//["End Label"]
			}
		}
		
		public void ApplySeriesOptions(ChartTypes type, int yaxisCnt)
		{
			_chartParams.Type = type;
            _yaxisCount = yaxisCnt;
			#region Set y-axis options			
			if(yaxisCnt>2){_yaxisCount++;}
			for(int ycnt=0; ycnt<_yaxisCount; ycnt++)
			{
				if(ycnt!=2)//Skip X axis
				{
					Axis axisY = chart1.Axis[ycnt];
					axisY.Position = AxisPosition.Near;
					axisY.LabelsFormat.Decimals = 0;
					axisY.ForceZero = true;
                    axisY.AlternateColor = Color.WhiteSmoke;
                    axisY.Interlaced = true;					
                    axisY.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				}
			}
			if(_yaxisCount>1)
			{
				chart1.Commands[3].Checked = true;
				YaxisMultipaneChanged(true);//Use multiple panes by default
			}
			#endregion
			_chartParams.ApplySeriesOptions(chart1);
            //Use 3D Cylinders by default
            chart1.Chart3D = true;
            chart1.Gallery = Gallery.Bar;
            chart1.CylSides = 100;
			if(_chartParams.Type == ChartTypes.Normal)
			{
                SetNormalSeriesSql();                
            }
			else if(_chartParams.Type == ChartTypes.Cpu_Activity)
			{
				//chart1.Gallery = Gallery.Bar;
				chart1.Stacked = Stacked.Normal;//Makes sure the series legend is ordered top to bottom to match the stacked order
			}
			else if(_chartParams.Type == ChartTypes.Part_Cpu || _chartParams.Type == ChartTypes.Part_Sio)
			{
				#region Partitions
				panelPartOptions.Visible = true;
				//chart1.Gallery = Gallery.Bar;
				chart1.Stacked = Stacked.Normal;
				SqlDataAdapter sqlAdapter = new SqlDataAdapter();
				if(_chartParams.Type == ChartTypes.Part_Cpu)
				{
					chart1.AxisY.DataFormat.Format = AxisFormat.Percentage;
					chart1.AxisY.LabelsFormat.Format = AxisFormat.Percentage;
					chart1.AxisY.DataFormat.Decimals = 4;
					chart1.AxisY.LabelsFormat.Decimals = 4;
					sqlAdapter.SelectCommand = sqlCommandPartCPU;
				}
				else
				{sqlAdapter.SelectCommand = sqlCommandPartSIO;}
				
				DataTable tableSteps = sqlAdapter.FillSchema(dataSet1.Tables["rawPJS"],SchemaType.Mapped);
				UpdateCrossTabDataProvider("DisplayPJS", new DataRow[0]);
				#endregion
			}
			else if(_chartParams.Type == ChartTypes.Conn)
			{
				SeeSeriesOptions sOption = (SeeSeriesOptions)_chartParams.SeriesList[0];
				SetConnSeriesSql(sOption);//Set the series to chart
				chart1.Titles[1].Text = sOption.SeriesName + " (Delta)";
				#region Connections
				panelConnOptions.Visible = true;
				//chart1.Gallery = Gallery.Bar;
				chart1.Stacked = Stacked.Normal;
				
				sqlCommandConnForgnIP.CommandText+=		" GROUP BY Foreign_IP";
				sqlCommandConnForgnIPport.CommandText+=	" GROUP BY Foreign_IP, Foreign_Port";
				sqlCommandConnPID.CommandText+=			" GROUP BY Conn_PID";
				sqlCommandConnLocalPort.CommandText+=	" GROUP BY Local_Port";
				
				SqlDataAdapter sqlAdapter = new SqlDataAdapter();
				sqlAdapter.SelectCommand = sqlCommandConnForgnIP;
				sqlAdapter.FillSchema(dataSet1.Tables["connForgnIP"],SchemaType.Mapped);
				sqlAdapter.SelectCommand = sqlCommandConnForgnIPport;
				sqlAdapter.FillSchema(dataSet1.Tables["connForgnIPport"],SchemaType.Mapped);
				sqlAdapter.SelectCommand = sqlCommandConnPID;
				sqlAdapter.FillSchema(dataSet1.Tables["connPID"],SchemaType.Mapped);
				sqlAdapter.SelectCommand = sqlCommandConnLocalPort;
				sqlAdapter.FillSchema(dataSet1.Tables["connLocalPort"],SchemaType.Mapped);
				
				UpdateCrossTabDataProvider("DisplayConn", new DataRow[0]);
				#endregion
			}
			else if(_chartParams.Type == ChartTypes.ForIp)
			{
				SeeSeriesOptions sOption = (SeeSeriesOptions)_chartParams.SeriesList[0];
				SetForgnIpSeriesSql(sOption);//Set the series to chart
				chart1.Titles[1].Text = sOption.SeriesName + " (Delta)";
				#region Foreign IP
				panelForgnIpOptions.Visible = true;
				//chart1.Gallery = Gallery.Bar;
				chart1.Stacked = Stacked.Normal;
				
				SqlDataAdapter sqlAdapter = new SqlDataAdapter();
				sqlAdapter.SelectCommand = sqlCommandForgnIP;
				sqlAdapter.FillSchema(dataSet1.Tables["rawForgnIP"],SchemaType.Mapped);
				
				UpdateCrossTabDataProvider("DisplayForgnIP", new DataRow[0]);
				#endregion
			}
		}
		
		
		public string SetNormalSeriesSql()
		{
			#region Build the sql statement
			/*
			SqlSELECT "SELECT tablename0.Poll_Time, tablenameX.columnname, tablenameX.columnname"+
					  "FROM tablename0"+ 
					  "INNER JOIN tablenameX ON tablename0.Poll_Time = tablenameX.Poll_Time"+
					  "INNER JOIN tablenameX ON tablename0.Poll_Time = tablenameX.Poll_Time"+
					  "WHERE (tablename0.Poll_Time = @pollTime)"
			*/
			string sqlSELECT =	"SELECT tablename0.Poll_Time, ";
			string sqlFROM =	"FROM tablename0";
			string sqlINNERJOINs = "";
			string sqlWHERE =	" WHERE (tablename0.Poll_Time = @pollTime)";
			//string sqlORDER =	" ORDER BY tablename0.Poll_Time";
			
			ArrayList SourceTables = new ArrayList();
			string TableName0 = "";
			int sCnt = 0;
			foreach(SeeSeriesOptions sOptions in _chartParams.SeriesList)
			{
				if(sCnt==0)
				{
					TableName0 = sOptions.TableName;
					sqlSELECT = sqlSELECT.Replace("tablename0",TableName0);
					sqlFROM = sqlFROM.Replace("tablename0",TableName0);
					sqlWHERE = sqlWHERE.Replace("tablename0",TableName0);
					//sqlORDER = sqlORDER.Replace("tablename0",TableName0);
				}	
				if(sOptions.TableName!=TableName0 && !SourceTables.Contains(sOptions.TableName))
				{//Add INNER JOIN statement for additional tables
					string sqlINNER =	" INNER JOIN tablenameX ON tablename0.Poll_Time = tablenameX.Poll_Time";
					sqlINNER = sqlINNER.Replace("tablename0",TableName0);
					sqlINNER = sqlINNER.Replace("tablenameX",sOptions.TableName);
					sqlINNERJOINs += sqlINNER;
				}
				string sqlTableColumn = sOptions.TableName+"."+sOptions.ColumnName+", ";
				sqlSELECT += sqlTableColumn;//Add each series to be returned by the SELECT
				SourceTables.Add(sOptions.TableName);//Keep track of included tables
				sCnt++;
			}
			sqlSELECT = sqlSELECT.Remove(sqlSELECT.Length-2,1);//Remove the last comma
			sqlCommand1.CommandText = sqlSELECT + sqlFROM + sqlINNERJOINs + sqlWHERE;
			#endregion
			return sqlCommand1.CommandText;
		}
			
		private void SetConnSeriesSql(SeeSeriesOptions series)
		{
			
			if(series.ColumnName.EndsWith("_Eff"))
			{
				Eff = true;
				sqlCommandConnForgnIP.CommandText = sqlCommandConnForgnIP.CommandText.Replace			("FROM", ", avg("+series.ColumnName+") FROM");	
				sqlCommandConnForgnIPport.CommandText = sqlCommandConnForgnIPport.CommandText.Replace	("FROM", ", avg("+series.ColumnName+") FROM");	
				sqlCommandConnPID.CommandText = sqlCommandConnPID.CommandText.Replace					("FROM", ", avg("+series.ColumnName+") FROM");	
				sqlCommandConnLocalPort.CommandText = sqlCommandConnLocalPort.CommandText.Replace		("FROM", ", avg("+series.ColumnName+") FROM");	
			}
			else
			{
				sqlCommandConnForgnIP.CommandText = sqlCommandConnForgnIP.CommandText.Replace			("FROM", ", sum("+series.ColumnName+") FROM");	
				sqlCommandConnForgnIPport.CommandText = sqlCommandConnForgnIPport.CommandText.Replace	("FROM", ", sum("+series.ColumnName+") FROM");	
				sqlCommandConnPID.CommandText = sqlCommandConnPID.CommandText.Replace					("FROM", ", sum("+series.ColumnName+") FROM");	
				sqlCommandConnLocalPort.CommandText = sqlCommandConnLocalPort.CommandText.Replace		("FROM", ", sum("+series.ColumnName+") FROM");	
			}
			
		}
		
		private void SetForgnIpSeriesSql(SeeSeriesOptions series)
		{
			sqlCommandForgnIP.CommandText = sqlCommandForgnIP.CommandText.Replace("FROM", ", "+series.ColumnName+" FROM");
		}
		
		
		private void LoadWithRanks(DateTime pollTime, Hashtable hash, string tablename)
		{
			double[] vals = new double[hash.Count];
			string[] keys = new string[hash.Count];
			hash.Values.CopyTo(vals,0);	//Split the hash table into 2 arrays
			hash.Keys.CopyTo(keys,0);
			Array.Sort(vals, keys);		//Put the arrays into ascending order
			
			if(hash.Count > _highrank)
			{
				_highrank = hash.Count;//Use highrank to set the max on the numeric up/down controls
				if(_chartParams.Type == ChartTypes.Part_Cpu || _chartParams.Type == ChartTypes.Part_Sio)
				{
					numericUpDown1.Maximum = Convert.ToDecimal(_highrank);
					numericUpDown2.Maximum = Convert.ToDecimal(_highrank);
					if(numericUpDown2.Maximum < 10){numericUpDown2.Value = numericUpDown2.Maximum;}
				}
				if(_chartParams.Type == ChartTypes.Conn)
				{
					numericUpDown3.Maximum = Convert.ToDecimal(_highrank);
					numericUpDown4.Maximum = Convert.ToDecimal(_highrank);
					if(numericUpDown4.Maximum < 10){numericUpDown4.Value = numericUpDown4.Maximum;}
				}
				if(_chartParams.Type == ChartTypes.ForIp)
				{
					numericUpDown5.Maximum = Convert.ToDecimal(_highrank);
					numericUpDown6.Maximum = Convert.ToDecimal(_highrank);
					if(numericUpDown6.Maximum < 10){numericUpDown6.Value = numericUpDown6.Maximum;}
				}
			}

			int rank = hash.Count;
			dataSet1.Tables[tablename].BeginLoadData();
			for(int cnt=0; cnt<hash.Count; cnt++)
			{//Add the rows with the appropriate rank
				dataSet1.Tables[tablename].Rows.Add(
					new object[5]{_prevDT,keys[cnt],vals[cnt],rank,pollTime});
				rank--;//Decrement the rank
			}
			dataSet1.Tables[tablename].EndLoadData();
		}

		private DataRow[] GetRowsFromRank(int lowrank, int highrank, string tablename)
		{
			//int botRank = rank-10;
			string selExpr = "Rank <= "+highrank.ToString()+ " AND Rank >= "+lowrank.ToString();
			string selSort = "Rank ASC";
			DataRow[] rows = dataSet1.Tables[tablename].Select(selExpr,selSort);
			return rows;
		}
		
		private void RemoveRows(DateTime dt, string tablename)
		{
			try
			{
				string selExpr = "Key LIKE '*'";//Select all rows
				string selSort = "prevDT ASC";//In ascending order by time
				DataRow[] rows = dataSet1.Tables[tablename].Select(selExpr,selSort);
				foreach(DataRow row in rows)
				{
					if((DateTime)row["prevDT"] == dt)
					{row.Delete();}
					else
					{break;}//Leave the loop once the first date group is removed
				}
			}
			catch(Exception exc)
			{Debug.WriteLine(exc.ToString());}
			/*Doesn't work?
			string selExpr = "DateTime = #"+dt.ToString()+"#";
			string selSort = "DateTime ASC";
			DataRow[] rows = dataSet1.Tables["Partitions"].Select(selExpr,selSort,DataViewRowState.Added);
			foreach(DataRow row in rows)
			{row.Delete();}
			*/
		}
		
		
		public void ClearData()
		{
			chart1.ClearData(ClearDataFlag.Values);
			//chart1.ClearData(ClearDataFlag.Data);
		}
		public void SetReportDataSource(DataTable dataTable)
		{
			chart1.DataSource = dataTable;
		}
	
			#endregion
		#region EVENT HANDLERS
		private void XaxisScollChanged(bool Checked)
		{
			if(Checked){chart1.Scrollable = true;}
			else{chart1.Scrollable = false;}
		}

		private void YaxisForceZeroChanged(bool Checked)
		{
			if(Checked)
			{
				for(int ycnt=0; ycnt<_yaxisCount; ycnt++)
				{
					if(ycnt!=2)//Skip X axis
					{chart1.Axis[ycnt].ForceZero = true;}
				}
			}
			else
			{
				for(int ycnt=0; ycnt<_yaxisCount; ycnt++)
				{
					if(ycnt!=2)//Skip X axis
					{chart1.Axis[ycnt].ForceZero = false;}
				}
			}
			chart1.RecalcScale();
		}

		private void YaxisMultipaneChanged(bool Checked)
		{
			if(Checked)
			{
				#region Assign each axis to individual pane
				int PaneCnt = 0;
				for(int ycnt=0; ycnt<_yaxisCount; ycnt++)
				{
					if(ycnt!=2)//Skip X axis
					{
						chart1.Axis[ycnt].Pane = PaneCnt;
						PaneCnt++;
					}
				}
				#endregion
				#region Set equal proportions
				int PaneProp = 0;
				switch(PaneCnt)
				{
					case 1:
						PaneProp = 100;
						break;
					case 2:
						PaneProp = 50;
						break;
					case 3:
						PaneProp = 33;
						break;
					case 4:
						PaneProp = 25;
						break;
					case 5:
						PaneProp = 20;
						break;
					case 6:
						PaneProp = 16;
						break;
					default:
						break;
				}
				for(int pCnt=0; pCnt<PaneCnt; pCnt++)
				{chart1.Panes[pCnt].Proportion = PaneProp;}
				#endregion
			}
			else
			{
				#region Assign each axis back to Pane[0]
				for(int ycnt=0; ycnt<_yaxisCount; ycnt++)
				{
					if(ycnt!=2)//Skip X axis
					{
						if(chart1.Axis[ycnt].Visible)
						{chart1.Axis[ycnt].Pane = 0;}
					}
				}
				#endregion
				#region Give Pane[0] 100% proportion
				this.chart1.Panes[5].Proportion = 0;
				this.chart1.Panes[4].Proportion = 0;
				this.chart1.Panes[3].Proportion = 0;
				this.chart1.Panes[2].Proportion = 0;
				this.chart1.Panes[1].Proportion = 0;
				this.chart1.Panes[0].Proportion = 100;
				#endregion
			}
		}

		private void chart1_UserCommand(object sender, SoftwareFX.ChartFX.CommandUIEventArgs e)
		{
			Command command = (Command)chart1.Commands[e.ID];
			switch(e.ID)
			{
				case 1://X-axis - "Scroll Bar"
					XaxisScollChanged(command.Checked);
					break;
				case 2://Y-axis - "Start at Zero");
					YaxisForceZeroChanged(command.Checked);
					break;
				case 3://Y-axis - "Multipane");
					YaxisMultipaneChanged(command.Checked);
					break;
				default:
					Debug.WriteLine("CommandID = " + e.ID.ToString()+ " Unhandled event.");
					break;
			}
		}
		
		#endregion
		#region Update EVENT HANDLERS
		public void DataBaseUpdatedHandler(DateTime dt)
		{
			_currDT = dt;
			if(_realTime)
			{chart1.SuspendLayout();}
			SqlDataReader sqlReader = null;//Update real-time values
			try
			{
				sqlConnection1.Open();
				if(_chartParams.Type == ChartTypes.Normal)
				{
					#region Normal
					sqlCommand1.Parameters["@pollTime"].Value = dt;
					sqlReader = sqlCommand1.ExecuteReader(CommandBehavior.CloseConnection);
					if(sqlReader.HasRows)
					{
						while(sqlReader.Read()) 
						{
							object[] seriesVals = new object[sqlReader.FieldCount];
							int valCnt = sqlReader.GetValues(seriesVals);
							UpdateRealTimeVals(seriesVals);//All series should be in one row
						}
					}
					#endregion
				}	
				else if(_chartParams.Type == ChartTypes.Cpu_Activity)
				{
					#region Cpu Activity
					ArrayList cpuList = new ArrayList();
					sqlCommandCPU.Parameters["@pollTime"].Value = dt;
					sqlReader = sqlCommandCPU.ExecuteReader(CommandBehavior.CloseConnection);
					if(sqlReader.HasRows)
					{
						while(sqlReader.Read()) 
						{
							object[] cpuVals = new object[sqlReader.FieldCount];
							int valCnt = sqlReader.GetValues(cpuVals);
							string cpuState =	(string)cpuVals[2];
							if(cpuState == "Active")
							{cpuList.Add(cpuVals);}
						}
					}
					UpdateRealTimeListCPU(cpuList);//The sqlcommand must be ordered correctly
					#endregion
				}
				else if(_chartParams.Type == ChartTypes.Cpu_Dispatcher)
				{
					#region Cpu Dispatcher
					ArrayList cpuList = new ArrayList();
					sqlCommandTD.Parameters["@pollTime"].Value = dt;
					sqlReader = sqlCommandTD.ExecuteReader(CommandBehavior.CloseConnection);
					if(sqlReader.HasRows)
					{
						while(sqlReader.Read()) 
						{
							object[] cpuVals = new object[sqlReader.FieldCount];
							int valCnt = sqlReader.GetValues(cpuVals);
							string cpuState =	(string)cpuVals[2];
							if(cpuState == "Active")
							{cpuList.Add(cpuVals);}
						}
					}
					UpdateRealTimeListTD(cpuList);
					#endregion
				}
				else if(_chartParams.Type == ChartTypes.Part_Cpu || _chartParams.Type == ChartTypes.Part_Sio)
				{
					#region Partitions
					dataSet1.Tables["rawPJS"].Clear();
					SqlDataAdapter sqlAdapter = new SqlDataAdapter();
					if(_chartParams.Type == ChartTypes.Part_Cpu)
					{
						sqlCommandPartCPU.Parameters["@pollTime"].Value = dt;
						sqlAdapter.SelectCommand = sqlCommandPartCPU;
					}
					else //Partitions_SIO
					{
						sqlCommandPartSIO.Parameters["@pollTime"].Value = dt;
						sqlAdapter.SelectCommand = sqlCommandPartSIO;
					}
					int StepCnt = sqlAdapter.Fill(dataSet1.Tables["rawPJS"]);
					UpdateRealTimeListPartitions(dt);
					#endregion
				}
				else if(_chartParams.Type == ChartTypes.Conn)
				{
					#region Connections
					#region Clear raw connTables
					dataSet1.Tables["connForgnIP"].Clear();
					dataSet1.Tables["connForgnIPport"].Clear();
					dataSet1.Tables["connPID"].Clear();
					dataSet1.Tables["connLocalPort"].Clear();
					#endregion
					#region Set command parameters
					sqlCommandConnForgnIP.Parameters["@pollTime"].Value = dt;
					sqlCommandConnForgnIPport.Parameters["@pollTime"].Value = dt;
					sqlCommandConnPID.Parameters["@pollTime"].Value = dt;
					sqlCommandConnLocalPort.Parameters["@pollTime"].Value = dt;
					#endregion
					#region Fill raw connTables
					SqlDataAdapter sqlAdapter = new SqlDataAdapter();
					sqlAdapter.SelectCommand = sqlCommandConnForgnIP;
					sqlAdapter.Fill(dataSet1.Tables["connForgnIP"]);
					sqlAdapter.SelectCommand = sqlCommandConnForgnIPport;
					sqlAdapter.Fill(dataSet1.Tables["connForgnIPport"]);
					sqlAdapter.SelectCommand = sqlCommandConnPID;
					sqlAdapter.Fill(dataSet1.Tables["connPID"]);
					sqlAdapter.SelectCommand = sqlCommandConnLocalPort;
					sqlAdapter.Fill(dataSet1.Tables["connLocalPort"]);
					#endregion
					UpdateRealTimeListConnections(dt);
					#endregion
				}
				else if(_chartParams.Type == ChartTypes.ForIp)
				{
					if(firstForIp)
					{
						firstForIp = false;
						if(_ctTimeQ == null)
						{
							_ctTimeQ = new Queue(11);
							_ctTimeQ.Enqueue(dt);//Keep track of the dates stored
						}
					}//There is no previous time yet
					else
					{UpdateRealTimeListForgnIPs(dt);}
				}	
			}
			finally
			{
				if(_realTime)
				{chart1.ResumeLayout(true);}
				
				if(sqlReader != null){sqlReader.Close();}
				else{sqlConnection1.Close();}

				_prevDT = dt;//Update the global previous time
			}
		}

		public void UpdateRealTimeVals(object[] newVals)
		{
			if(_prevVals == null)
			{
				_prevVals = new object[newVals.Length];
				newVals.CopyTo(_prevVals,0);
			}
			else
			{
				//DateTime prevDT = (DateTime)_prevVals[0];
				//DateTime newDT = (DateTime)newVals[0];
				int valCnt = newVals.Length - 1;//The first value is always a DateTime, not a series value
				
				chart1.OpenData(COD.Values | COD.AddPoints,_chartParams.SeriesCount,1);
				for(int cnt=0; cnt<valCnt; cnt++)
				{
					double deltVal = Convert.ToDouble(newVals[cnt+1]) - 
						Convert.ToDouble(_prevVals[cnt+1]);
					if(deltVal<0)
					{deltVal = 0;}//Don't allow negative values
					chart1.Value[cnt,0] = deltVal;
				}
				chart1.Legend[0] = CreateXlabel(_prevDT,_currDT);
				chart1.CloseData(COD.Values | COD.RealTimeScroll);

				newVals.CopyTo(_prevVals,0);//Do this last
			}
		}
		
		#region UpdateCpu
		public void UpdateRealTimeListCPU(ArrayList ActiveCpuList)
		{
			if(_prevCpuVals == null)
			{_prevCpuVals = new Hashtable(ActiveCpuList.Count);}
			if(_prevCpuVals.Count == 0)//There is no previous values
			{
				chart1.OpenData(COD.Values,5*ActiveCpuList.Count,0);
				short cpuID = 0;//This will be updated each time thru the loop
				int cpuCnt = 0;//This will be incremented each time thru the loop
				foreach(object[] seriesVals in ActiveCpuList)
				{
					cpuID = Convert.ToInt16((double)seriesVals[1]);
					string cpuLabel = "cpu"+cpuID.ToString();
					#region Apply series option for multiple cpu's
					if(cpuCnt==0)
					{
						chart1.Series[0].Color = Color.Purple;
						chart1.Series[1].Color = Color.Red;
						chart1.Series[2].Color = Color.Yellow;
						chart1.Series[3].Color = Color.LightGreen;	
						chart1.Series[4].Color = Color.Blue;
					}
					else
					{
						chart1.Series[(5*cpuCnt)].Gallery = chart1.Series[0].Gallery;
						chart1.Series[(5*cpuCnt)].Stacked = chart1.Series[0].Stacked;
						chart1.Series[(5*cpuCnt)].Color = chart1.Series[0].Color;
						chart1.Series[(5*cpuCnt)].YAxis = chart1.Series[0].YAxis;
						chart1.Series[1+(5*cpuCnt)].Gallery = chart1.Series[1].Gallery;
						chart1.Series[1+(5*cpuCnt)].Stacked = chart1.Series[1].Stacked;
						chart1.Series[1+(5*cpuCnt)].Color = chart1.Series[1].Color;
						chart1.Series[1+(5*cpuCnt)].YAxis = chart1.Series[1].YAxis;
						chart1.Series[2+(5*cpuCnt)].Gallery = chart1.Series[2].Gallery;
						chart1.Series[2+(5*cpuCnt)].Stacked = chart1.Series[2].Stacked;
						chart1.Series[2+(5*cpuCnt)].Color = chart1.Series[2].Color;
						chart1.Series[2+(5*cpuCnt)].YAxis = chart1.Series[2].YAxis;
						chart1.Series[3+(5*cpuCnt)].Gallery = chart1.Series[3].Gallery;
						chart1.Series[3+(5*cpuCnt)].Stacked = chart1.Series[3].Stacked;
						chart1.Series[3+(5*cpuCnt)].Color = chart1.Series[3].Color;
						chart1.Series[3+(5*cpuCnt)].YAxis = chart1.Series[3].YAxis;
						chart1.Series[4+(5*cpuCnt)].Gallery = chart1.Series[4].Gallery;
						chart1.Series[4+(5*cpuCnt)].Stacked = chart1.Series[4].Stacked;
						chart1.Series[4+(5*cpuCnt)].Color = chart1.Series[4].Color;
						chart1.Series[4+(5*cpuCnt)].YAxis = chart1.Series[4].YAxis;
					}
					#endregion
					#region Assign legend labels
					chart1.Series[(5*cpuCnt)].Legend = cpuLabel+" Spinning";
					chart1.Series[1+(5*cpuCnt)].Legend = cpuLabel+" Busy(NonP)";
					chart1.Series[2+(5*cpuCnt)].Legend = cpuLabel+" Busy(Para)";
					chart1.Series[3+(5*cpuCnt)].Legend = cpuLabel+" Waiting";
					chart1.Series[4+(5*cpuCnt)].Legend = cpuLabel+" Non-VSE";
					#endregion
					#region Store the previous values
					CpuUsage cpuUsage = new CpuUsage();
					cpuUsage.dateTime = _currDT;
					cpuUsage.secSinceReset = Convert.ToDouble(seriesVals[3]);
					cpuUsage.secSpin = Convert.ToDouble(seriesVals[4]);
					cpuUsage.secNonp = Convert.ToDouble(seriesVals[5]);
					cpuUsage.secPara = Convert.ToDouble(seriesVals[6]);
					cpuUsage.secWait = Convert.ToDouble(seriesVals[7]);
					cpuUsage.secOver = Convert.ToDouble(seriesVals[8]);
					/*
					cpuUsage.secSinceReset = cpuUsage.secSpin + cpuUsage.secNonp + cpuUsage.secPara + cpuUsage.secWait + cpuUsage.secOver;
					double secSinceResetActual = Convert.ToDouble(seriesVals[3]);
					double error = secSinceResetActual - cpuUsage.secSinceReset;
					Debug.WriteLine("Error(Actual - Sum)= "+ error.ToString());
					*/
					_prevCpuVals.Add(cpuID,cpuUsage);
					#endregion
					cpuCnt++;
				}
				chart1.CloseData(COD.Values);
			}
			else
			{
				chart1.OpenData(COD.Values | COD.AddPoints,5*ActiveCpuList.Count,1);
				short cpuID = 0;	//This will be updated each time thru the loop
				int cpuCnt = 0;		//This will be incremented each time thru the loop
				foreach(object[] seriesVals in ActiveCpuList)
				{	
					CpuUsage currUsage = new CpuUsage();
					//currUsage.dateTime = (DateTime)seriesVals[0];
					cpuID = Convert.ToInt16((double)seriesVals[1]);
					//seriesVals[2] = state
					currUsage.secSinceReset = Convert.ToDouble(seriesVals[3]);
					currUsage.secSpin = Convert.ToDouble(seriesVals[4]);
					currUsage.secNonp = Convert.ToDouble(seriesVals[5]);
					currUsage.secPara = Convert.ToDouble(seriesVals[6]);
					currUsage.secWait = Convert.ToDouble(seriesVals[7]);
					currUsage.secOver = Convert.ToDouble(seriesVals[8]);
					if(_prevCpuVals.ContainsKey(cpuID))
					{
						CpuUsage prevUsage = (CpuUsage)_prevCpuVals[cpuID];//Get the previous values
						double[] percVals = CalculateCpuVals(prevUsage, currUsage);
						#region Add values to chart *Must add in this order
						chart1.Value[5*cpuCnt, 0] =	percVals[0];//percSpin;
						chart1.Value[1+(5*cpuCnt), 0] = percVals[1];//percNonp;
						chart1.Value[2+(5*cpuCnt), 0] = percVals[2];//percPara;
						chart1.Value[3+(5*cpuCnt), 0] = percVals[3];//percWait;
						chart1.Value[4+(5*cpuCnt), 0] = percVals[4];//percOver;
						#endregion
						_prevCpuVals[cpuID] = currUsage;//Update the previous values
					}
					else
					{
						_prevCpuVals.Add(cpuID,currUsage);//Add new previous values
					}
					cpuCnt++;
				}
				chart1.Legend[0] = CreateXlabel(_prevDT,_currDT);//Display 24 Hour Clock
				chart1.CloseData(COD.Values | COD.RealTimeScroll);
			}
		}

		public double[] CalculateCpuVals(CpuUsage prevUsage, CpuUsage currUsage)
		{
			#region Calculate values
			double deltSpin = currUsage.secSpin - prevUsage.secSpin;
			if(deltSpin<0){deltSpin=0;}//Don't allow negatives
			double deltNonp = currUsage.secNonp - prevUsage.secNonp;
			if(deltNonp<0){deltNonp=0;}
			double deltPara = currUsage.secPara - prevUsage.secPara;
			if(deltPara<0){deltPara=0;}
			double deltWait = currUsage.secWait - prevUsage.secWait;
			if(deltWait<0){deltWait=0;}
			double deltOver = currUsage.secOver - prevUsage.secOver;
			if(deltOver<0){deltOver=0;}
			double deltSinceReset = deltSpin + deltNonp + deltPara + deltWait + deltOver;
			//double deltSinceReset = secSinceReset - prevUsage.secSinceReset;This adds a %error
			double percSpin = deltSpin/deltSinceReset;
			double percNonp = deltNonp/deltSinceReset;
			double percPara = deltPara/deltSinceReset;
			double percWait = deltWait/deltSinceReset;
			double percOver = deltOver/deltSinceReset;
			#endregion
			return new double[5]{percSpin,percNonp,percPara,percWait,percOver};
		}

		public void SetMultipleCpuOptions(int cpuCnt)
		{	
			for(int cnt=0; cnt<cpuCnt; cnt++)
			{	
				chart1.Series[(5*cnt)].Color = Color.Purple;
				chart1.Series[(5*cnt)].Gallery = Gallery.Bar;
				chart1.Series[(5*cnt)].Stacked = true;

				chart1.Series[1+(5*cnt)].Color = Color.Red;
				chart1.Series[1+(5*cnt)].Gallery = Gallery.Bar;
				chart1.Series[1+(5*cnt)].Stacked = true;

				chart1.Series[2+(5*cnt)].Color = Color.Yellow;
				chart1.Series[2+(5*cnt)].Gallery = Gallery.Bar;
				chart1.Series[2+(5*cnt)].Stacked = true;

				chart1.Series[3+(5*cnt)].Color = Color.LightGreen;	
				chart1.Series[3+(5*cnt)].Gallery = Gallery.Bar;
				chart1.Series[3+(5*cnt)].Stacked = true;

				chart1.Series[4+(5*cnt)].Color = Color.Blue;
				chart1.Series[4+(5*cnt)].Gallery = Gallery.Bar;
				chart1.Series[4+(5*cnt)].Stacked = true;
			}
		}

		public void UpdateRealTimeListTD(ArrayList ActiveCpuList)
		{
			if(_prevCpuVals == null)
			{_prevCpuVals = new Hashtable(ActiveCpuList.Count);}
			if(_prevCpuVals.Count == 0)//There is no previous values
			{
				chart1.OpenData(COD.Values,ActiveCpuList.Count,0);
				short cpuID = 0;//This will be updated each time thru the loop
				int cpuCnt = 0;//This will be incremented each time thru the loop
				foreach(object[] seriesVals in ActiveCpuList)
				{
					cpuID = Convert.ToInt16((double)seriesVals[1]);
					string cpuLabel = "cpu"+cpuID.ToString();
					chart1.Series[cpuCnt].Legend = cpuLabel+ " Dispatch Cycles";
					double tdCycles = Convert.ToDouble(seriesVals[3]);
					_prevCpuVals.Add(cpuID,tdCycles);					
					cpuCnt++;
				}
				chart1.CloseData(COD.Values);
			}
			else
			{
				chart1.OpenData(COD.Values | COD.AddPoints,ActiveCpuList.Count,1);
				short cpuID = 0;//Placeholder value, will be updated each time thru the loop
				int cpuCnt = 0;
				foreach(object[] seriesVals in ActiveCpuList)
				{
					cpuID = Convert.ToInt16((double)seriesVals[1]);
					double newCycles = Convert.ToDouble(seriesVals[3]);
					if(_prevCpuVals.ContainsKey(cpuID))
					{
						double prevCycles = (double)_prevCpuVals[cpuID];//Get the previous values
						double deltCycles = newCycles - prevCycles;
						chart1.Value[cpuCnt, 0] = deltCycles;
						_prevCpuVals[cpuID] = newCycles;//Update the previous values
					}
					else
					{
						_prevCpuVals.Add(cpuID,newCycles);
					}
					cpuCnt++;
				}
				chart1.Legend[0] = CreateXlabel(_prevDT,_currDT);//Display 24 Hour Clock
				chart1.CloseData(COD.Values | COD.RealTimeScroll);
			}
			
		}

		#endregion
		#region UpdatePJS
		public void UpdateRealTimeListPartitions(DateTime pollTime)
		{
			Hashtable partHash = new Hashtable();
			Hashtable jobHash = new Hashtable();
			Hashtable stepHash = new Hashtable();
			string dtFormat = "M/d/yy HH:mm";//For series legend
			double secSinceReset = 0;
			if(_chartParams.Type == ChartTypes.Part_Cpu)
			{
				if(dataSet1.Tables["rawPJS"].Rows.Count>0)
				{secSinceReset = (double)dataSet1.Tables["rawPJS"].Rows[0]["Sec_since_CpuReset"];}
			}
			foreach(DataRow pRow in dataSet1.Tables["rawPJS"].Rows)
			{
				double val = 0;
				if(_chartParams.Type == ChartTypes.Part_Cpu)
				{val = (double)pRow["CPU_Time_sec"];}
				else //Partitions_SIO
				{val = (double)pRow["SIO_Count"];}
				if(val > 0)
				{
					#region Create PJS Keys
					DateTime jobStartDT = (DateTime)pRow["Job_Start_Time"];
					DateTime stepStartDT = (DateTime)pRow["Step_Start_Time"];
					string partKey = (string)pRow["Partition_ID"];
					string jobKey = (string)pRow["Partition_ID"]+Environment.NewLine
						+(string)pRow["VSE_Job_Name"]+Environment.NewLine
						+jobStartDT.ToString(dtFormat);
					string stepKey = (string)pRow["Partition_ID"]+"-"+(string)pRow["VSE_Job_Name"]+Environment.NewLine
						//+jobStartDT.ToString(dtFormat)+Environment.NewLine
						+(string)pRow["VSE_Step_Name"]+Environment.NewLine//Needs to be in the middle to be visible in the data editor
						+stepStartDT.ToString(dtFormat);
					#endregion
					#region Load Hashtables
					//Add to Partitions
					if(!partHash.ContainsKey(partKey))
					{partHash.Add(partKey,val);}
					else
					{
						double newVal = (double)partHash[partKey] + val;//Keep a running sum
						partHash[partKey] = newVal;
					}
					//Add to Jobs
					if(!jobHash.ContainsKey(jobKey))
					{jobHash.Add(jobKey,val);}
					else
					{
						double newVal = (double)jobHash[jobKey] + val;//Keep a running sum
						jobHash[jobKey] = newVal;
					}
					//Add to Steps
					stepHash.Add(stepKey,val);
					#endregion
				}
			}
			if(_realTime)
			{
				#region Keep track of the dates stored
				if(_ctTimeQ == null)
				{_ctTimeQ = new Queue(11);}
			
				if(_ctTimeQ.Count < 11)
				{_ctTimeQ.Enqueue(pollTime);}//Put new time at end of Q
				else
				{
					DateTime firstTime = (DateTime)_ctTimeQ.Dequeue();//Remove the first time
					RemoveRows(firstTime, "Partitions");
					RemoveRows(firstTime, "Jobs");
					RemoveRows(firstTime, "Steps");
					_ctTimeQ.Enqueue(pollTime);//Put new time at end of Q
				}
				#endregion
			}
			#region Initialize collections for previous data
			if(_prevParts == null)
			{
				_prevParts = new Hashtable();
				_prevJobs = new Hashtable();
				_prevSteps = new Hashtable();
			}
			#endregion
			#region Load new data into tables
			if(_prevParts.Count > 0)
			{
				Hashtable partHashDelt = new Hashtable(partHash.Count);
				Hashtable jobHashDelt = new Hashtable(jobHash.Count);
				Hashtable stepHashDelt = new Hashtable(stepHash.Count);
				if(_chartParams.Type == ChartTypes.Part_Cpu)
				{
					#region Calculate delta CPU vals
					double deltRes = secSinceReset - _prevSecSinceReset;
					foreach(DictionaryEntry Entry in partHash)
					{
						if(_prevParts.ContainsKey(Entry.Key))
						{
							double prevVal = (double)_prevParts[Entry.Key];
							double newVal = (double)Entry.Value;
							double deltVal = newVal - prevVal;
							double val = deltVal/deltRes;//% of cpu usage
							if(val>0)
							{partHashDelt.Add(Entry.Key,val);}
						}
					}
					foreach(DictionaryEntry Entry in jobHash)
					{
						if(_prevJobs.ContainsKey(Entry.Key))
						{
							double prevVal = (double)_prevJobs[Entry.Key];
							double newVal = (double)Entry.Value;
							double deltVal = newVal - prevVal;
							double val = deltVal/deltRes;//% of cpu usage
							if(val>0)
							{jobHashDelt.Add(Entry.Key,val);}
						}
					}
					foreach(DictionaryEntry Entry in stepHash)
					{
						if(_prevSteps.ContainsKey(Entry.Key))
						{
							double prevVal = (double)_prevSteps[Entry.Key];
							double newVal = (double)Entry.Value;
							double deltVal = newVal - prevVal;
							double val = deltVal/deltRes;//% of cpu usage
							if(val>0)
							{stepHashDelt.Add(Entry.Key,val);}
						}
					}
					#endregion
				}
				else //Partitions_SIO
				{
					#region Calculate delta SIO vals
					foreach(DictionaryEntry Entry in partHash)
					{
						if(_prevParts.ContainsKey(Entry.Key))
						{
							double val = (double)Entry.Value - (double)_prevParts[Entry.Key];
							if(val>0)
							{partHashDelt.Add(Entry.Key,val);}
						}
					}
					foreach(DictionaryEntry Entry in jobHash)
					{
						if(_prevJobs.ContainsKey(Entry.Key))
						{
							double val = (double)Entry.Value - (double)_prevJobs[Entry.Key];
							if(val>0)
							{jobHashDelt.Add(Entry.Key,val);}
						}
					}
					foreach(DictionaryEntry Entry in stepHash)
					{
						if(_prevSteps.ContainsKey(Entry.Key))
						{
							double val = (double)Entry.Value - (double)_prevSteps[Entry.Key];
							if(val>0)
							{stepHashDelt.Add(Entry.Key,val);}
						}
					}
					#endregion
				}
				LoadWithRanks(pollTime, partHashDelt, "Partitions");
				LoadWithRanks(pollTime, jobHashDelt,  "Jobs");
				LoadWithRanks(pollTime, stepHashDelt, "Steps");
				_prevParts.Clear();
				_prevJobs.Clear();
				_prevSteps.Clear();
				if(_realTime)
				{InvokeUpdatePJS();}
			}
			#endregion
			#region Update previous values
			foreach(DictionaryEntry Entry in partHash)
			{_prevParts.Add(Entry.Key,Entry.Value);}
			foreach(DictionaryEntry Entry in jobHash)
			{_prevJobs.Add(Entry.Key,Entry.Value);}
			foreach(DictionaryEntry Entry in stepHash)
			{_prevSteps.Add(Entry.Key,Entry.Value);}
			_prevSecSinceReset = secSinceReset;
			#endregion
		}
		
		public void InvokeUpdatePJS()
		{
			InvokeOnClick(buttonUpdatePJS,null);
		}

		private void buttonUpdatePJS_Click(object sender, System.EventArgs e)
		{
			int selLowRank = Convert.ToInt32(numericUpDown1.Value);
			int selHighRank = Convert.ToInt32(numericUpDown2.Value);;
			string selType = "";
			if(radioButton1.Checked){selType = "Partitions";}
			else if(radioButton2.Checked){selType = "Jobs";}
			else if(radioButton3.Checked){selType = "Steps";}
			DataRow[] selRows = GetRowsFromRank(selLowRank,selHighRank,selType);
			UpdateCrossTabDataProvider("DisplayPJS", selRows);
		}
		
		
		#endregion
		#region UpdateConn
		private void UpdateRealTimeListConnections(DateTime pollTime)
		{
			Hashtable forIPHash = new Hashtable();
			Hashtable forIPportHash = new Hashtable();
			Hashtable pidHash = new Hashtable();
			Hashtable lportHash = new Hashtable();	
			#region Load Hashtables
			foreach(DataRow row in dataSet1.Tables["connForgnIP"].Rows)
			{
				if(row[1].GetType() != Type.GetType("System.DBNull"))
				{forIPHash.Add(row[0],row[1]);}
			}
			foreach(DataRow row in dataSet1.Tables["connForgnIPport"].Rows)
			{
				if(row[2].GetType() != Type.GetType("System.DBNull"))
				{
					string forIP =(string)row[0];
					double fport =(double)row[1];
					string forIPport = forIP+":"+fport.ToString();
					forIPportHash.Add(forIPport,row[2]);
				}
			}
			foreach(DataRow row in dataSet1.Tables["connPID"].Rows)
			{
				if(row[1].GetType() != Type.GetType("System.DBNull"))
				{pidHash.Add(row[0],row[1]);}
			}
			foreach(DataRow row in dataSet1.Tables["connLocalPort"].Rows)
			{
				if(row[1].GetType() != Type.GetType("System.DBNull"))
				{
					double lport =(double)row[0];
					lportHash.Add(lport.ToString(),row[1]);
				}
			}
			
			#endregion
			if(_realTime)
			{
				#region Keep track of the dates stored
				if(_ctTimeQ == null)
				{_ctTimeQ = new Queue(11);}
				if(_ctTimeQ.Count < 11)
				{_ctTimeQ.Enqueue(pollTime);}//Put new time at end of Q
				else
				{
					DateTime firstTime = (DateTime)_ctTimeQ.Dequeue();//Remove the first time
					RemoveRows(firstTime, "ConnID");
					RemoveRows(firstTime, "ConnForgnIP");
					RemoveRows(firstTime, "ConnForgnIPport");
					RemoveRows(firstTime, "ConnPID");
					RemoveRows(firstTime, "ConnLocalPort");
					RemoveRows(firstTime, "ConnProtocol");
					RemoveRows(firstTime, "ConnState");
					_ctTimeQ.Enqueue(pollTime);//Put new time at end of Q
				}
				#endregion
			}
			#region Initialize collections for previous data
			if(_prevConnForgnIP == null)
			{
				_prevConnForgnIP = new Hashtable();
				_prevConnForgnIPport = new Hashtable();
				_prevConnPID = new Hashtable();
				_prevConnLocalPort = new Hashtable();
			}
			#endregion
			#region Load new data into tables
			if(_prevConnForgnIP.Count > 0)
			{
				Hashtable forIPHashDelt = new Hashtable(forIPHash.Count);
				Hashtable forIPportHashDelt = new Hashtable(forIPportHash.Count);
				Hashtable pidHashDelt = new Hashtable(pidHash.Count);
				Hashtable lportHashDelt = new Hashtable(lportHash.Count);
				
				#region Calculate delta vals
				
				foreach(DictionaryEntry Entry in forIPHash)
				{
					if(this._prevConnForgnIP.ContainsKey(Entry.Key))
					{
						double val = (double)Entry.Value - (double)_prevConnForgnIP[Entry.Key];
						if(val>0 || Eff)//Efficiency can have a negative change
						{forIPHashDelt.Add(Entry.Key,val);}
					}
				}
				foreach(DictionaryEntry Entry in forIPportHash)
				{
					if(this._prevConnForgnIPport.ContainsKey(Entry.Key))
					{
						double val = (double)Entry.Value - (double)_prevConnForgnIPport[Entry.Key];
						if(val>0 || Eff)
						{forIPportHashDelt.Add(Entry.Key,val);}
					}
				}
				foreach(DictionaryEntry Entry in pidHash)
				{
					if(this._prevConnPID.ContainsKey(Entry.Key))
					{
						double val = (double)Entry.Value - (double)_prevConnPID[Entry.Key];
						if(val>0 || Eff)
						{pidHashDelt.Add(Entry.Key,val);}
					}
				}
				foreach(DictionaryEntry Entry in lportHash)
				{
					if(this._prevConnLocalPort.ContainsKey(Entry.Key))
					{
						double val = (double)Entry.Value - (double)_prevConnLocalPort[Entry.Key];
						if(val>0 || Eff)
						{lportHashDelt.Add(Entry.Key,val);}
					}
				}
				
				#endregion
				
				LoadWithRanks(pollTime, forIPHashDelt,		"ConnForgnIP");
				LoadWithRanks(pollTime, forIPportHashDelt,	"ConnForgnIPport");
				LoadWithRanks(pollTime, pidHashDelt,		"ConnPID");
				LoadWithRanks(pollTime, lportHashDelt,		"ConnLocalPort");
				
				
				_prevConnForgnIP.Clear();
				_prevConnForgnIPport.Clear();
				_prevConnPID.Clear();
				_prevConnLocalPort.Clear();
				
				if(_realTime)
				{InvokeUpdateConn();}
			}
			#endregion
			#region Update previous values
			
			foreach(DictionaryEntry Entry in forIPHash)
			{_prevConnForgnIP.Add(Entry.Key,Entry.Value);}
			foreach(DictionaryEntry Entry in forIPportHash)
			{_prevConnForgnIPport.Add(Entry.Key,Entry.Value);}
			foreach(DictionaryEntry Entry in pidHash)
			{_prevConnPID.Add(Entry.Key,Entry.Value);}
			foreach(DictionaryEntry Entry in lportHash)
			{_prevConnLocalPort.Add(Entry.Key,Entry.Value);}
			
			#endregion	
		}

		public void InvokeUpdateConn()
		{
			InvokeOnClick(buttonUpdateConn,new EventArgs());
		}

		private void buttonUpdateConn_Click(object sender, System.EventArgs e)
		{
			int selLowRank = Convert.ToInt32(numericUpDown3.Value);
			int selHighRank = Convert.ToInt32(numericUpDown4.Value);;
			string tname = "";
			if(radioButton5.Checked)	{tname = "ConnForgnIP";}
			else if(radioButton6.Checked)	{tname = "ConnForgnIPport";}
			else if(radioButton7.Checked)	{tname = "ConnPID";}
			else if(radioButton8.Checked)	{tname = "ConnLocalPort";}
			DataRow[] selRows = GetRowsFromRank(selLowRank,selHighRank,tname);
			UpdateCrossTabDataProvider("DisplayConn", selRows);
		}

		#endregion
		#region UpdateForgnIP
		private Hashtable FillForgnIpHash(DateTime dt)
		{
			Hashtable ipHash = new Hashtable();
			try
			{
				if(sqlConnection1.State != ConnectionState.Open)
				{sqlConnection1.Open();}
				
				dataSet1.Tables["rawForgnIP"].Clear();
				sqlCommandForgnIP.Parameters["@pollTime"].Value = dt;
				SqlDataAdapter sqlAdapter = new SqlDataAdapter();
				sqlAdapter.SelectCommand = sqlCommandForgnIP;
				sqlAdapter.Fill(dataSet1.Tables["rawForgnIP"]);

				foreach(DataRow row in dataSet1.Tables["rawForgnIP"].Rows)
				{ipHash.Add(row[0],row[1]);}
			}
			finally
			{
				if(sqlConnection1.State == ConnectionState.Open)
				{sqlConnection1.Close();}
			}

			return ipHash;
		}
		private void UpdateRealTimeListForgnIPs(DateTime pollTime)
		{
			if(_realTime)
			{
				#region Keep track of the dates stored
				if(_ctTimeQ == null)
				{_ctTimeQ = new Queue(11);}
				if(_ctTimeQ.Count < 11)
				{_ctTimeQ.Enqueue(pollTime);}//Put new time at end of Q
				else
				{
					DateTime firstTime = (DateTime)_ctTimeQ.Dequeue();//Remove the first time
					RemoveRows(firstTime, "ForgnIP");
					_ctTimeQ.Enqueue(pollTime);//Put new time at end of Q
				}
				#endregion
			}
			
			Hashtable prevIpHash = FillForgnIpHash(_prevDT);
			Hashtable currIpHash = FillForgnIpHash(pollTime);
			
			Hashtable ipHashDelt = new Hashtable(currIpHash.Count);
			foreach(DictionaryEntry Entry in currIpHash)
			{
				if(prevIpHash.ContainsKey(Entry.Key))
				{
					double val = 0;
					if(!Entry.Value.Equals(System.DBNull.Value) && !prevIpHash[Entry.Key].Equals(System.DBNull.Value))
					{val = (double)Entry.Value - (double)prevIpHash[Entry.Key];}
					if(val>0)
					{ipHashDelt.Add(Entry.Key,val);}
				}
				//else//This ip address has activity for the first time
				//{ipHashDelt.Add(Entry.Key,(double)Entry.Value);}
			}	
			
			LoadWithRanks(pollTime, ipHashDelt,	"ForgnIP");
				
			if(_realTime)
			{InvokeUpdateForgnIP();}			
			
		}

		public void InvokeUpdateForgnIP()
		{
			InvokeOnClick(buttonUpdateForgnIP,null);
		}

		private void buttonUpdateForgnIP_Click(object sender, System.EventArgs e)
		{
			int selLowRank = Convert.ToInt32(numericUpDown5.Value);
			int selHighRank = Convert.ToInt32(numericUpDown6.Value);
			DataRow[] selRows = GetRowsFromRank(selLowRank,selHighRank,"ForgnIP");
			UpdateCrossTabDataProvider("DisplayForgnIP", selRows);
		}
	
		#endregion
		private void UpdateCrossTabDataProvider(string tablename, DataRow[] rows)
		{
			dataSet1.Tables[tablename].Clear();
			foreach(DataRow row in rows)
			{
				object[] itemArray = row.ItemArray;
				
				DateTime endDT = (DateTime)itemArray[4];//Format the end label as a time string
				itemArray[4] = endDT.ToString(DateTimeFormat)+Environment.NewLine+" ";
				//itemArray[4] = endDT.ToString("HH:mm")+Environment.NewLine+" ";

				dataSet1.Tables[tablename].Rows.Add(itemArray);
			}

			SoftwareFX.ChartFX.Data.DataTableProvider cfxDT = new SoftwareFX.ChartFX.Data.DataTableProvider();
			cfxDT.DataTable = dataSet1.Tables[tablename];
			// Crosstab Settings
			SoftwareFX.ChartFX.Data.CrosstabDataProvider cfxCT = new SoftwareFX.ChartFX.Data.CrosstabDataProvider();
			cfxCT.DataType[0] = SoftwareFX.ChartFX.Data.CrosstabDataType.RowHeading;
			cfxCT.DataType[1] = SoftwareFX.ChartFX.Data.CrosstabDataType.ColumnHeading;
			cfxCT.DataType[2] = SoftwareFX.ChartFX.Data.CrosstabDataType.Value;
			cfxCT.DataType[3] = SoftwareFX.ChartFX.Data.CrosstabDataType.NotUsed;
			cfxCT.DataType[4] = SoftwareFX.ChartFX.Data.CrosstabDataType.RowHeading;
			cfxCT.DataSource = cfxDT;
			cfxCT.DateFormat = DateTimeFormat;
			cfxCT.Separator = Environment.NewLine + " - ";
			//cfxCT.DateFormat = "M/dd/yy"+Environment.NewLine+"HH:mm";//Include date with the first label
			//cfxCT.Separator = " - ";//+Environment.NewLine;
			
			chart1.DataSourceSettings.DataSource = cfxCT;

            CrossTabSeriesChanged();
		}

        public event csi.see.classlib1.EmptyDelegate CrossTabSeriesChanged;
		#endregion
	}

	public struct CpuUsage
	{
		public DateTime dateTime;
		public double secSinceReset;
		public double secSpin;
		public double secNonp;
		public double secPara;
		public double secWait;
		public double secOver;
	}
}
