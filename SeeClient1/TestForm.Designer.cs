namespace csi.see.client1
{
    partial class TestForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.dsetForgnIPs1 = new csi.see.client1.dsetForgnIPs();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioBytes = new System.Windows.Forms.RadioButton();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.vseDbDataSet1 = new csi.see.classlib1.DataSets.VseDbDataSet();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsetForgnIPs1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vseDbDataSet1)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(572, 440);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.treeView1.Location = new System.Drawing.Point(0, 44);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(206, 396);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(206, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sort by";
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(362, 336);
            this.dataGridView1.TabIndex = 2;
            // 
            // dTimeDataGridViewTextBoxColumn
            // 
            this.dTimeDataGridViewTextBoxColumn.DataPropertyName = "DTime";
            this.dTimeDataGridViewTextBoxColumn.HeaderText = "Poll Time";
            this.dTimeDataGridViewTextBoxColumn.Name = "dTimeDataGridViewTextBoxColumn";
            this.dTimeDataGridViewTextBoxColumn.ReadOnly = true;
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
            // dsetForgnIPs1
            // 
            this.dsetForgnIPs1.DataSetName = "dsetForgnIPs";
            this.dsetForgnIPs1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.richTextBox3);
            this.panel1.Controls.Add(this.richTextBox2);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 104);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioBytes);
            this.groupBox1.Location = new System.Drawing.Point(109, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 38);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(97, 16);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(107, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Datagram Counts";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioBytes
            // 
            this.radioBytes.AutoSize = true;
            this.radioBytes.Checked = true;
            this.radioBytes.Location = new System.Drawing.Point(8, 16);
            this.radioBytes.Name = "radioBytes";
            this.radioBytes.Size = new System.Drawing.Size(82, 17);
            this.radioBytes.TabIndex = 0;
            this.radioBytes.TabStop = true;
            this.radioBytes.Text = "Byte Counts";
            this.radioBytes.UseVisualStyleBackColor = true;
            this.radioBytes.CheckedChanged += new System.EventHandler(this.radioBytes_CheckedChanged);
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox3.Location = new System.Drawing.Point(103, 40);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(259, 20);
            this.richTextBox3.TabIndex = 3;
            this.richTextBox3.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(103, 20);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(259, 20);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(103, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(259, 20);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel2.Size = new System.Drawing.Size(103, 104);
            this.panel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(0, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "IP Address";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(0, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "End Time";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Start Time";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(362, 440);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // vseDbDataSet1
            // 
            this.vseDbDataSet1.DataSetName = "VseDbDataSet";
            this.vseDbDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 440);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsetForgnIPs1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vseDbDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private csi.see.classlib1.DataSets.VseDbDataSet vseDbDataSet1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioBytes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dsetForgnIPs dsetForgnIPs1;
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
    }
}