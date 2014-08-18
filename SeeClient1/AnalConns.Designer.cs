namespace csi.see.client1
{
    partial class AnalConns
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalConns));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsetConns1 = new csi.see.client1.dsetConns();
            this.dtimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.connectionStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vseDbDataSet1 = new csi.see.classlib1.DataSets.VseDbDataSet();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.labelType = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.button1 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtimeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.connectionStateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inboundBytesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outboundBytesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inboundDatagramsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outboundDatagramsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivesIssuesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sendsIssuedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxReceiveWindowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxSendWindowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nofTimesReceiveWindowClosedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nofTimesInRetransmitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retransmitsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sWSCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPID = new System.Windows.Forms.TextBox();
            this.tbConnStart = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbForeignIP = new System.Windows.Forms.TextBox();
            this.tbForeignPort = new System.Windows.Forms.TextBox();
            this.tbLocalPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statStart = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statEnd = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsetConns1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vseDbDataSet1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "TrafficStats";
            this.bindingSource1.DataSource = this.dsetConns1;
            // 
            // dsetConns1
            // 
            this.dsetConns1.DataSetName = "dsetConns";
            this.dsetConns1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtimeDataGridViewTextBoxColumn
            // 
            this.dtimeDataGridViewTextBoxColumn.DataPropertyName = "Dtime";
            this.dtimeDataGridViewTextBoxColumn.HeaderText = "Poll Time";
            this.dtimeDataGridViewTextBoxColumn.Name = "dtimeDataGridViewTextBoxColumn";
            this.dtimeDataGridViewTextBoxColumn.Width = 120;
            // 
            // connectionStateDataGridViewTextBoxColumn
            // 
            this.connectionStateDataGridViewTextBoxColumn.DataPropertyName = "Connection State";
            this.connectionStateDataGridViewTextBoxColumn.HeaderText = "Connection State";
            this.connectionStateDataGridViewTextBoxColumn.Name = "connectionStateDataGridViewTextBoxColumn";
            // 
            // vseDbDataSet1
            // 
            this.vseDbDataSet1.DataSetName = "VseDbDataSet";
            this.vseDbDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(734, 300);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 62);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(205, 238);
            this.treeView1.TabIndex = 17;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(0, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "  - Foreign Port:IP (Start Time)";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(0, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "+ Local Port";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelType,
            this.toolStripSeparator1,
            this.button1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(205, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // labelType
            // 
            this.labelType.ForeColor = System.Drawing.Color.Blue;
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(66, 22);
            this.labelType.Text = "Connections";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // button1
            // 
            this.button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 22);
            this.button1.Text = "Refresh List";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtimeDataGridViewTextBoxColumn1,
            this.connectionStateDataGridViewTextBoxColumn1,
            this.inboundBytesDataGridViewTextBoxColumn,
            this.outboundBytesDataGridViewTextBoxColumn,
            this.inboundDatagramsDataGridViewTextBoxColumn,
            this.outboundDatagramsDataGridViewTextBoxColumn,
            this.receivesIssuesDataGridViewTextBoxColumn,
            this.sendsIssuedDataGridViewTextBoxColumn,
            this.maxReceiveWindowDataGridViewTextBoxColumn,
            this.maxSendWindowDataGridViewTextBoxColumn,
            this.nofTimesReceiveWindowClosedDataGridViewTextBoxColumn,
            this.nofTimesInRetransmitDataGridViewTextBoxColumn,
            this.retransmitsDataGridViewTextBoxColumn,
            this.sWSCountDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(525, 210);
            this.dataGridView1.TabIndex = 13;
            // 
            // dtimeDataGridViewTextBoxColumn1
            // 
            this.dtimeDataGridViewTextBoxColumn1.DataPropertyName = "Dtime";
            this.dtimeDataGridViewTextBoxColumn1.HeaderText = "Poll Time";
            this.dtimeDataGridViewTextBoxColumn1.Name = "dtimeDataGridViewTextBoxColumn1";
            this.dtimeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dtimeDataGridViewTextBoxColumn1.Width = 120;
            // 
            // connectionStateDataGridViewTextBoxColumn1
            // 
            this.connectionStateDataGridViewTextBoxColumn1.DataPropertyName = "Connection State";
            this.connectionStateDataGridViewTextBoxColumn1.HeaderText = "Connection State";
            this.connectionStateDataGridViewTextBoxColumn1.Name = "connectionStateDataGridViewTextBoxColumn1";
            this.connectionStateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // inboundBytesDataGridViewTextBoxColumn
            // 
            this.inboundBytesDataGridViewTextBoxColumn.DataPropertyName = "Inbound Bytes";
            this.inboundBytesDataGridViewTextBoxColumn.HeaderText = "Inbound Bytes";
            this.inboundBytesDataGridViewTextBoxColumn.Name = "inboundBytesDataGridViewTextBoxColumn";
            this.inboundBytesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // outboundBytesDataGridViewTextBoxColumn
            // 
            this.outboundBytesDataGridViewTextBoxColumn.DataPropertyName = "Outbound Bytes";
            this.outboundBytesDataGridViewTextBoxColumn.HeaderText = "Outbound Bytes";
            this.outboundBytesDataGridViewTextBoxColumn.Name = "outboundBytesDataGridViewTextBoxColumn";
            this.outboundBytesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inboundDatagramsDataGridViewTextBoxColumn
            // 
            this.inboundDatagramsDataGridViewTextBoxColumn.DataPropertyName = "Inbound Datagrams";
            this.inboundDatagramsDataGridViewTextBoxColumn.HeaderText = "Inbound Datagrams";
            this.inboundDatagramsDataGridViewTextBoxColumn.Name = "inboundDatagramsDataGridViewTextBoxColumn";
            this.inboundDatagramsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // outboundDatagramsDataGridViewTextBoxColumn
            // 
            this.outboundDatagramsDataGridViewTextBoxColumn.DataPropertyName = "Outbound Datagrams";
            this.outboundDatagramsDataGridViewTextBoxColumn.HeaderText = "Outbound Datagrams";
            this.outboundDatagramsDataGridViewTextBoxColumn.Name = "outboundDatagramsDataGridViewTextBoxColumn";
            this.outboundDatagramsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // receivesIssuesDataGridViewTextBoxColumn
            // 
            this.receivesIssuesDataGridViewTextBoxColumn.DataPropertyName = "Receives Issues";
            this.receivesIssuesDataGridViewTextBoxColumn.HeaderText = "Receives Issues";
            this.receivesIssuesDataGridViewTextBoxColumn.Name = "receivesIssuesDataGridViewTextBoxColumn";
            this.receivesIssuesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sendsIssuedDataGridViewTextBoxColumn
            // 
            this.sendsIssuedDataGridViewTextBoxColumn.DataPropertyName = "Sends Issued";
            this.sendsIssuedDataGridViewTextBoxColumn.HeaderText = "Sends Issued";
            this.sendsIssuedDataGridViewTextBoxColumn.Name = "sendsIssuedDataGridViewTextBoxColumn";
            this.sendsIssuedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maxReceiveWindowDataGridViewTextBoxColumn
            // 
            this.maxReceiveWindowDataGridViewTextBoxColumn.DataPropertyName = "Max Receive Window";
            this.maxReceiveWindowDataGridViewTextBoxColumn.HeaderText = "Max Receive Window";
            this.maxReceiveWindowDataGridViewTextBoxColumn.Name = "maxReceiveWindowDataGridViewTextBoxColumn";
            this.maxReceiveWindowDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maxSendWindowDataGridViewTextBoxColumn
            // 
            this.maxSendWindowDataGridViewTextBoxColumn.DataPropertyName = "Max Send Window";
            this.maxSendWindowDataGridViewTextBoxColumn.HeaderText = "Max Send Window";
            this.maxSendWindowDataGridViewTextBoxColumn.Name = "maxSendWindowDataGridViewTextBoxColumn";
            this.maxSendWindowDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nofTimesReceiveWindowClosedDataGridViewTextBoxColumn
            // 
            this.nofTimesReceiveWindowClosedDataGridViewTextBoxColumn.DataPropertyName = "Nof Times Receive Window Closed";
            this.nofTimesReceiveWindowClosedDataGridViewTextBoxColumn.HeaderText = "# of Times Recv Window Closed";
            this.nofTimesReceiveWindowClosedDataGridViewTextBoxColumn.Name = "nofTimesReceiveWindowClosedDataGridViewTextBoxColumn";
            this.nofTimesReceiveWindowClosedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nofTimesInRetransmitDataGridViewTextBoxColumn
            // 
            this.nofTimesInRetransmitDataGridViewTextBoxColumn.DataPropertyName = "Nof Times in Retransmit";
            this.nofTimesInRetransmitDataGridViewTextBoxColumn.HeaderText = "# of Times in Retransmit";
            this.nofTimesInRetransmitDataGridViewTextBoxColumn.Name = "nofTimesInRetransmitDataGridViewTextBoxColumn";
            this.nofTimesInRetransmitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // retransmitsDataGridViewTextBoxColumn
            // 
            this.retransmitsDataGridViewTextBoxColumn.DataPropertyName = "Retransmits";
            this.retransmitsDataGridViewTextBoxColumn.HeaderText = "Retransmits";
            this.retransmitsDataGridViewTextBoxColumn.Name = "retransmitsDataGridViewTextBoxColumn";
            this.retransmitsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sWSCountDataGridViewTextBoxColumn
            // 
            this.sWSCountDataGridViewTextBoxColumn.DataPropertyName = "SWS Count";
            this.sWSCountDataGridViewTextBoxColumn.HeaderText = "SWS Count";
            this.sWSCountDataGridViewTextBoxColumn.Name = "sWSCountDataGridViewTextBoxColumn";
            this.sWSCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 68);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Details";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tbPID, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbConnStart, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbForeignIP, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbForeignPort, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbLocalPort, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(469, 47);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbPID
            // 
            this.tbPID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbPID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPID.Location = new System.Drawing.Point(413, 21);
            this.tbPID.Name = "tbPID";
            this.tbPID.ReadOnly = true;
            this.tbPID.Size = new System.Drawing.Size(54, 21);
            this.tbPID.TabIndex = 16;
            this.tbPID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbConnStart
            // 
            this.tbConnStart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbConnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConnStart.Location = new System.Drawing.Point(273, 21);
            this.tbConnStart.Name = "tbConnStart";
            this.tbConnStart.ReadOnly = true;
            this.tbConnStart.Size = new System.Drawing.Size(134, 21);
            this.tbConnStart.TabIndex = 13;
            this.tbConnStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(273, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Connection Start Time";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(413, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "PID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbForeignIP
            // 
            this.tbForeignIP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbForeignIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbForeignIP.Location = new System.Drawing.Point(153, 21);
            this.tbForeignIP.Name = "tbForeignIP";
            this.tbForeignIP.ReadOnly = true;
            this.tbForeignIP.Size = new System.Drawing.Size(114, 21);
            this.tbForeignIP.TabIndex = 7;
            this.tbForeignIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbForeignPort
            // 
            this.tbForeignPort.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbForeignPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbForeignPort.Location = new System.Drawing.Point(78, 21);
            this.tbForeignPort.Name = "tbForeignPort";
            this.tbForeignPort.ReadOnly = true;
            this.tbForeignPort.Size = new System.Drawing.Size(69, 21);
            this.tbForeignPort.TabIndex = 6;
            this.tbForeignPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbLocalPort
            // 
            this.tbLocalPort.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbLocalPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLocalPort.Location = new System.Drawing.Point(3, 21);
            this.tbLocalPort.Name = "tbLocalPort";
            this.tbLocalPort.ReadOnly = true;
            this.tbLocalPort.Size = new System.Drawing.Size(69, 21);
            this.tbLocalPort.TabIndex = 5;
            this.tbLocalPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(153, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Foreign IP Address";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(78, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Foreign Port";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Local Port";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statStart,
            this.toolStripStatusLabel3,
            this.statEnd});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(525, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(101, 17);
            this.toolStripStatusLabel1.Text = "Analyzer Start Time";
            // 
            // statStart
            // 
            this.statStart.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.statStart.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statStart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statStart.Name = "statStart";
            this.statStart.Size = new System.Drawing.Size(36, 17);
            this.statStart.Text = "None";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel3.Text = "End Time";
            // 
            // statEnd
            // 
            this.statEnd.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.statEnd.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statEnd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statEnd.Name = "statEnd";
            this.statEnd.Size = new System.Drawing.Size(36, 17);
            this.statEnd.Text = "None";
            // 
            // AnalConns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AnalConns";
            this.Size = new System.Drawing.Size(734, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsetConns1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vseDbDataSet1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private csi.see.classlib1.DataSets.VseDbDataSet vseDbDataSet1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private dsetConns dsetConns1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn connectionStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbPID;
        private System.Windows.Forms.TextBox tbConnStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbForeignIP;
        private System.Windows.Forms.TextBox tbForeignPort;
        private System.Windows.Forms.TextBox tbLocalPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statStart;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel statEnd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtimeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn connectionStateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn inboundBytesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outboundBytesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inboundDatagramsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outboundDatagramsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivesIssuesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sendsIssuedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxReceiveWindowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxSendWindowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nofTimesReceiveWindowClosedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nofTimesInRetransmitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn retransmitsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sWSCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel labelType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton button1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
