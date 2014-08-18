namespace csi.see.client1
{
    partial class AnalForgnIps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalForgnIps));
            this.vseDbDataSet1 = new csi.see.classlib1.DataSets.VseDbDataSet();
            this.dsetForgnIPs1 = new csi.see.client1.dsetForgnIPs();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.labelType = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.button1 = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statStart = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statEnd = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioBytes = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inTCPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inUDPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inICMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outTCPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outUDPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outICMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nonIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.misdirectedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refusedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.vseDbDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsetForgnIPs1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // vseDbDataSet1
            // 
            this.vseDbDataSet1.DataSetName = "VseDbDataSet";
            this.vseDbDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsetForgnIPs1
            // 
            this.dsetForgnIPs1.DataSetName = "dsetForgnIPs";
            this.dsetForgnIPs1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(538, 300);
            this.splitContainer1.SplitterDistance = 179;
            this.splitContainer1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelType,
            this.toolStripSeparator1,
            this.button1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(179, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // labelType
            // 
            this.labelType.ForeColor = System.Drawing.Color.Blue;
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(70, 22);
            this.labelType.Text = "IP Addresses";
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
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(0, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sort By";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 47);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.treeView1.Location = new System.Drawing.Point(0, 68);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(179, 232);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 68);
            this.panel1.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statStart,
            this.toolStripStatusLabel3,
            this.statEnd});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(355, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(101, 17);
            this.toolStripStatusLabel1.Text = "Analyzer Start Time";
            // 
            // statStart
            // 
            this.statStart.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.statStart.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statStart.Name = "statStart";
            this.statStart.Size = new System.Drawing.Size(29, 17);
            this.statStart.Text = "xxx";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel3.Text = "End Time";
            // 
            // statEnd
            // 
            this.statEnd.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.statEnd.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statEnd.Name = "statEnd";
            this.statEnd.Size = new System.Drawing.Size(29, 17);
            this.statEnd.Text = "xxx";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioBytes);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(147, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 40);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Display";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButton2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(55, 17);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(77, 20);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Datagrams";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioBytes
            // 
            this.radioBytes.AutoSize = true;
            this.radioBytes.Checked = true;
            this.radioBytes.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioBytes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBytes.Location = new System.Drawing.Point(3, 17);
            this.radioBytes.Name = "radioBytes";
            this.radioBytes.Size = new System.Drawing.Size(52, 20);
            this.radioBytes.TabIndex = 0;
            this.radioBytes.TabStop = true;
            this.radioBytes.Text = "Bytes";
            this.radioBytes.UseVisualStyleBackColor = true;
            this.radioBytes.CheckedChanged += new System.EventHandler(this.radioBytes_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(6, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP Address";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(129, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dTimeDataGridViewTextBoxColumn,
            this.inIPDataGridViewTextBoxColumn,
            this.inTCPDataGridViewTextBoxColumn,
            this.inUDPDataGridViewTextBoxColumn,
            this.inICMPDataGridViewTextBoxColumn,
            this.outIPDataGridViewTextBoxColumn,
            this.outTCPDataGridViewTextBoxColumn,
            this.outUDPDataGridViewTextBoxColumn,
            this.outICMPDataGridViewTextBoxColumn,
            this.nonIPDataGridViewTextBoxColumn,
            this.misdirectedDataGridViewTextBoxColumn,
            this.refusedDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "TrafficMain";
            this.dataGridView1.DataSource = this.dsetForgnIPs1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(355, 232);
            this.dataGridView1.TabIndex = 4;
            // 
            // dTimeDataGridViewTextBoxColumn
            // 
            this.dTimeDataGridViewTextBoxColumn.DataPropertyName = "DTime";
            this.dTimeDataGridViewTextBoxColumn.HeaderText = "Poll Time";
            this.dTimeDataGridViewTextBoxColumn.Name = "dTimeDataGridViewTextBoxColumn";
            this.dTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.dTimeDataGridViewTextBoxColumn.Width = 120;
            // 
            // inIPDataGridViewTextBoxColumn
            // 
            this.inIPDataGridViewTextBoxColumn.DataPropertyName = "InIP";
            this.inIPDataGridViewTextBoxColumn.HeaderText = "Inbound IP";
            this.inIPDataGridViewTextBoxColumn.Name = "inIPDataGridViewTextBoxColumn";
            this.inIPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inTCPDataGridViewTextBoxColumn
            // 
            this.inTCPDataGridViewTextBoxColumn.DataPropertyName = "InTCP";
            this.inTCPDataGridViewTextBoxColumn.HeaderText = "Inbound TCP";
            this.inTCPDataGridViewTextBoxColumn.Name = "inTCPDataGridViewTextBoxColumn";
            this.inTCPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inUDPDataGridViewTextBoxColumn
            // 
            this.inUDPDataGridViewTextBoxColumn.DataPropertyName = "InUDP";
            this.inUDPDataGridViewTextBoxColumn.HeaderText = "Inbound UDP";
            this.inUDPDataGridViewTextBoxColumn.Name = "inUDPDataGridViewTextBoxColumn";
            this.inUDPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inICMPDataGridViewTextBoxColumn
            // 
            this.inICMPDataGridViewTextBoxColumn.DataPropertyName = "InICMP";
            this.inICMPDataGridViewTextBoxColumn.HeaderText = "Inbound ICMP";
            this.inICMPDataGridViewTextBoxColumn.Name = "inICMPDataGridViewTextBoxColumn";
            this.inICMPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // outIPDataGridViewTextBoxColumn
            // 
            this.outIPDataGridViewTextBoxColumn.DataPropertyName = "OutIP";
            this.outIPDataGridViewTextBoxColumn.HeaderText = "Outbound IP";
            this.outIPDataGridViewTextBoxColumn.Name = "outIPDataGridViewTextBoxColumn";
            this.outIPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // outTCPDataGridViewTextBoxColumn
            // 
            this.outTCPDataGridViewTextBoxColumn.DataPropertyName = "OutTCP";
            this.outTCPDataGridViewTextBoxColumn.HeaderText = "Outbound TCP";
            this.outTCPDataGridViewTextBoxColumn.Name = "outTCPDataGridViewTextBoxColumn";
            this.outTCPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // outUDPDataGridViewTextBoxColumn
            // 
            this.outUDPDataGridViewTextBoxColumn.DataPropertyName = "OutUDP";
            this.outUDPDataGridViewTextBoxColumn.HeaderText = "Outbound UDP";
            this.outUDPDataGridViewTextBoxColumn.Name = "outUDPDataGridViewTextBoxColumn";
            this.outUDPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // outICMPDataGridViewTextBoxColumn
            // 
            this.outICMPDataGridViewTextBoxColumn.DataPropertyName = "OutICMP";
            this.outICMPDataGridViewTextBoxColumn.HeaderText = "Outbound ICMP";
            this.outICMPDataGridViewTextBoxColumn.Name = "outICMPDataGridViewTextBoxColumn";
            this.outICMPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nonIPDataGridViewTextBoxColumn
            // 
            this.nonIPDataGridViewTextBoxColumn.DataPropertyName = "NonIP";
            this.nonIPDataGridViewTextBoxColumn.HeaderText = "Non-IP Traffic";
            this.nonIPDataGridViewTextBoxColumn.Name = "nonIPDataGridViewTextBoxColumn";
            this.nonIPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // misdirectedDataGridViewTextBoxColumn
            // 
            this.misdirectedDataGridViewTextBoxColumn.DataPropertyName = "Misdirected";
            this.misdirectedDataGridViewTextBoxColumn.HeaderText = "Misdirected";
            this.misdirectedDataGridViewTextBoxColumn.Name = "misdirectedDataGridViewTextBoxColumn";
            this.misdirectedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // refusedDataGridViewTextBoxColumn
            // 
            this.refusedDataGridViewTextBoxColumn.DataPropertyName = "Refused";
            this.refusedDataGridViewTextBoxColumn.HeaderText = "Refused";
            this.refusedDataGridViewTextBoxColumn.Name = "refusedDataGridViewTextBoxColumn";
            this.refusedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // AnalForgnIps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AnalForgnIps";
            this.Size = new System.Drawing.Size(538, 300);
            ((System.ComponentModel.ISupportInitialize)(this.vseDbDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsetForgnIPs1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private csi.see.classlib1.DataSets.VseDbDataSet vseDbDataSet1;
        private dsetForgnIPs dsetForgnIPs1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel labelType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inTCPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inUDPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inICMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outTCPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outUDPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outICMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nonIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn misdirectedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refusedDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statStart;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel statEnd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioBytes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
