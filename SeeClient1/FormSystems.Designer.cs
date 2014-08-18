namespace csi.see.client1
{
    partial class FormSystems
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
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label userIdLabel;
            System.Windows.Forms.Label portLabel;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label ipAddressLabel;
            System.Windows.Forms.Label startPollTimeLabel;
            System.Windows.Forms.Label endPollTimeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSystems));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.sysDefsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seeCommonDataSet = new csi.see.classlib1.DataSets.SeeCommonDataSet();
            this.sysDefsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnChangeName = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.msTextBox = new System.Windows.Forms.TextBox();
            this.dbNameTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.ipAddressTextBox = new System.Windows.Forms.TextBox();
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.monOnCheckBox = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBoxMonitor = new System.Windows.Forms.GroupBox();
            this.labelContinuous = new System.Windows.Forms.Label();
            this.panelStartEnd = new System.Windows.Forms.Panel();
            this.endPollTimeDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.startPollTimeDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radioStartEnd = new System.Windows.Forms.RadioButton();
            this.radioContinuous = new System.Windows.Forms.RadioButton();
            this.nameListBox = new System.Windows.Forms.ListBox();
            passwordLabel = new System.Windows.Forms.Label();
            userIdLabel = new System.Windows.Forms.Label();
            portLabel = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ipAddressLabel = new System.Windows.Forms.Label();
            startPollTimeLabel = new System.Windows.Forms.Label();
            endPollTimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sysDefsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seeCommonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDefsBindingNavigator)).BeginInit();
            this.sysDefsBindingNavigator.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxMonitor.SuspendLayout();
            this.panelStartEnd.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordLabel
            // 
            passwordLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            passwordLabel.ForeColor = System.Drawing.Color.Blue;
            passwordLabel.Location = new System.Drawing.Point(6, 120);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(110, 13);
            passwordLabel.TabIndex = 10;
            passwordLabel.Text = "Password:";
            passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // userIdLabel
            // 
            userIdLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            userIdLabel.ForeColor = System.Drawing.Color.Blue;
            userIdLabel.Location = new System.Drawing.Point(6, 95);
            userIdLabel.Name = "userIdLabel";
            userIdLabel.Size = new System.Drawing.Size(110, 13);
            userIdLabel.TabIndex = 9;
            userIdLabel.Text = "User Id:";
            userIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // portLabel
            // 
            portLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            portLabel.ForeColor = System.Drawing.Color.Blue;
            portLabel.Location = new System.Drawing.Point(6, 70);
            portLabel.Name = "portLabel";
            portLabel.Size = new System.Drawing.Size(110, 13);
            portLabel.TabIndex = 8;
            portLabel.Text = "TCP Port:";
            portLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.ForeColor = System.Drawing.Color.Blue;
            label6.Location = new System.Drawing.Point(129, 166);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(53, 13);
            label6.TabIndex = 12;
            label6.Text = "hh:mm:ss";
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.Blue;
            label1.Location = new System.Drawing.Point(5, 145);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(110, 13);
            label1.TabIndex = 11;
            label1.Text = "Poll Interval:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ipAddressLabel
            // 
            ipAddressLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ipAddressLabel.ForeColor = System.Drawing.Color.Blue;
            ipAddressLabel.Location = new System.Drawing.Point(9, 26);
            ipAddressLabel.Name = "ipAddressLabel";
            ipAddressLabel.Size = new System.Drawing.Size(107, 13);
            ipAddressLabel.TabIndex = 7;
            ipAddressLabel.Text = "Domain/IP Address:";
            ipAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startPollTimeLabel
            // 
            startPollTimeLabel.Location = new System.Drawing.Point(3, 6);
            startPollTimeLabel.Name = "startPollTimeLabel";
            startPollTimeLabel.Size = new System.Drawing.Size(63, 13);
            startPollTimeLabel.TabIndex = 0;
            startPollTimeLabel.Text = "Start Time:";
            startPollTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // endPollTimeLabel
            // 
            endPollTimeLabel.Location = new System.Drawing.Point(4, 32);
            endPollTimeLabel.Name = "endPollTimeLabel";
            endPollTimeLabel.Size = new System.Drawing.Size(62, 13);
            endPollTimeLabel.TabIndex = 1;
            endPollTimeLabel.Text = "End Time:";
            endPollTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBox1
            // 
            this.listBox1.DisplayMember = "Name";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(-158, -13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(144, 264);
            this.listBox1.TabIndex = 48;
            // 
            // sysDefsBindingSource
            // 
            this.sysDefsBindingSource.DataMember = "SysDefs";
            this.sysDefsBindingSource.DataSource = this.seeCommonDataSet;
            this.sysDefsBindingSource.CurrentChanged += new System.EventHandler(this.sysDefsBindingSource_CurrentChanged);
            this.sysDefsBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.sysDefsBindingSource_ListChanged);
            // 
            // seeCommonDataSet
            // 
            this.seeCommonDataSet.DataSetName = "SeeCommonDataSet";
            this.seeCommonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sysDefsBindingNavigator
            // 
            this.sysDefsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.sysDefsBindingNavigator.BindingSource = this.sysDefsBindingSource;
            this.sysDefsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.sysDefsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.sysDefsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorDeleteItem,
            this.toolStripSeparator1,
            this.btnChangeName});
            this.sysDefsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.sysDefsBindingNavigator.MoveFirstItem = null;
            this.sysDefsBindingNavigator.MoveLastItem = null;
            this.sysDefsBindingNavigator.MoveNextItem = null;
            this.sysDefsBindingNavigator.MovePreviousItem = null;
            this.sysDefsBindingNavigator.Name = "sysDefsBindingNavigator";
            this.sysDefsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.sysDefsBindingNavigator.Size = new System.Drawing.Size(439, 25);
            this.sysDefsBindingNavigator.TabIndex = 0;
            this.sysDefsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(48, 22);
            this.bindingNavigatorAddNewItem.Text = "New";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.btnChangeName_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(58, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnChangeName
            // 
            this.btnChangeName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnChangeName.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeName.Image")));
            this.btnChangeName.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(78, 22);
            this.btnChangeName.Text = "Change Name";
            this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonOK);
            this.panel3.Controls.Add(this.buttonCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 222);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(439, 33);
            this.panel3.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(10, 5);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(353, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // msTextBox
            // 
            this.msTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysDefsBindingSource, "pollIntervalms", true));
            this.msTextBox.Location = new System.Drawing.Point(328, 243);
            this.msTextBox.Name = "msTextBox";
            this.msTextBox.Size = new System.Drawing.Size(85, 21);
            this.msTextBox.TabIndex = 3;
            // 
            // dbNameTextBox
            // 
            this.dbNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysDefsBindingSource, "DbName", true));
            this.dbNameTextBox.Location = new System.Drawing.Point(10, 243);
            this.dbNameTextBox.Name = "dbNameTextBox";
            this.dbNameTextBox.Size = new System.Drawing.Size(168, 21);
            this.dbNameTextBox.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // portTextBox
            // 
            this.portTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysDefsBindingSource, "Port", true));
            this.portTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTextBox.Location = new System.Drawing.Point(122, 67);
            this.portTextBox.MaxLength = 5;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(85, 21);
            this.portTextBox.TabIndex = 2;
            this.portTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.portTextBox_Validating);
            this.portTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // ipAddressTextBox
            // 
            this.ipAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysDefsBindingSource, "IpAddress", true));
            this.ipAddressTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressTextBox.Location = new System.Drawing.Point(9, 41);
            this.ipAddressTextBox.MaxLength = 1000;
            this.ipAddressTextBox.Name = "ipAddressTextBox";
            this.ipAddressTextBox.Size = new System.Drawing.Size(198, 21);
            this.ipAddressTextBox.TabIndex = 1;
            this.ipAddressTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ipAddressTextBox_Validating);
            this.ipAddressTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysDefsBindingSource, "UserId", true));
            this.userIdTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIdTextBox.Location = new System.Drawing.Point(122, 92);
            this.userIdTextBox.MaxLength = 20;
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.Size = new System.Drawing.Size(85, 21);
            this.userIdTextBox.TabIndex = 3;
            this.userIdTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysDefsBindingSource, "Password", true));
            this.passwordTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(122, 117);
            this.passwordTextBox.MaxLength = 20;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(85, 21);
            this.passwordTextBox.TabIndex = 4;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(459, 323);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ipAddressTextBox);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(label6);
            this.groupBox1.Controls.Add(this.passwordTextBox);
            this.groupBox1.Controls.Add(this.monOnCheckBox);
            this.groupBox1.Controls.Add(ipAddressLabel);
            this.groupBox1.Controls.Add(passwordLabel);
            this.groupBox1.Controls.Add(userIdLabel);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(portLabel);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.portTextBox);
            this.groupBox1.Controls.Add(this.userIdTextBox);
            this.groupBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysDefsBindingSource, "Name", true));
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(206, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 3);
            this.groupBox1.Size = new System.Drawing.Size(222, 193);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysDefsBindingSource, "Name", true));
            this.nameTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(7, 1);
            this.nameTextBox.MaxLength = 40;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 21);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.Visible = false;
            this.nameTextBox.Validated += new System.EventHandler(this.nameTextBox_Validated);
            this.nameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.nameTextBox_Validating);
            this.nameTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // monOnCheckBox
            // 
            this.monOnCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.monOnCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.sysDefsBindingSource, "monOn", true));
            this.monOnCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monOnCheckBox.ForeColor = System.Drawing.Color.Blue;
            this.monOnCheckBox.Location = new System.Drawing.Point(155, 26);
            this.monOnCheckBox.Name = "monOnCheckBox";
            this.monOnCheckBox.Size = new System.Drawing.Size(52, 16);
            this.monOnCheckBox.TabIndex = 6;
            this.monOnCheckBox.Text = "On";
            this.monOnCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "  HH:mm:ss";
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(122, 142);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(84, 21);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // groupBoxMonitor
            // 
            this.groupBoxMonitor.Controls.Add(this.labelContinuous);
            this.groupBoxMonitor.Controls.Add(this.panelStartEnd);
            this.groupBoxMonitor.Controls.Add(this.radioStartEnd);
            this.groupBoxMonitor.Controls.Add(this.radioContinuous);
            this.groupBoxMonitor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMonitor.ForeColor = System.Drawing.Color.Blue;
            this.groupBoxMonitor.Location = new System.Drawing.Point(210, 259);
            this.groupBoxMonitor.Name = "groupBoxMonitor";
            this.groupBoxMonitor.Size = new System.Drawing.Size(258, 100);
            this.groupBoxMonitor.TabIndex = 49;
            this.groupBoxMonitor.TabStop = false;
            this.groupBoxMonitor.Text = "Monitor Settings";
            this.groupBoxMonitor.Visible = false;
            // 
            // labelContinuous
            // 
            this.labelContinuous.Location = new System.Drawing.Point(44, 22);
            this.labelContinuous.Name = "labelContinuous";
            this.labelContinuous.Size = new System.Drawing.Size(63, 13);
            this.labelContinuous.TabIndex = 6;
            this.labelContinuous.Text = "Continuous";
            this.labelContinuous.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelContinuous.Visible = false;
            // 
            // panelStartEnd
            // 
            this.panelStartEnd.Controls.Add(this.endPollTimeDateTimePicker1);
            this.panelStartEnd.Controls.Add(this.startPollTimeDateTimePicker1);
            this.panelStartEnd.Controls.Add(startPollTimeLabel);
            this.panelStartEnd.Controls.Add(endPollTimeLabel);
            this.panelStartEnd.Enabled = false;
            this.panelStartEnd.Location = new System.Drawing.Point(43, 42);
            this.panelStartEnd.Name = "panelStartEnd";
            this.panelStartEnd.Size = new System.Drawing.Size(160, 52);
            this.panelStartEnd.TabIndex = 0;
            this.panelStartEnd.Visible = false;
            // 
            // endPollTimeDateTimePicker1
            // 
            this.endPollTimeDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sysDefsBindingSource, "EndPollTime", true));
            this.endPollTimeDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endPollTimeDateTimePicker1.Location = new System.Drawing.Point(68, 28);
            this.endPollTimeDateTimePicker1.Name = "endPollTimeDateTimePicker1";
            this.endPollTimeDateTimePicker1.ShowUpDown = true;
            this.endPollTimeDateTimePicker1.Size = new System.Drawing.Size(90, 21);
            this.endPollTimeDateTimePicker1.TabIndex = 3;
            // 
            // startPollTimeDateTimePicker1
            // 
            this.startPollTimeDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sysDefsBindingSource, "StartPollTime", true));
            this.startPollTimeDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startPollTimeDateTimePicker1.Location = new System.Drawing.Point(68, 2);
            this.startPollTimeDateTimePicker1.Name = "startPollTimeDateTimePicker1";
            this.startPollTimeDateTimePicker1.ShowUpDown = true;
            this.startPollTimeDateTimePicker1.Size = new System.Drawing.Size(89, 21);
            this.startPollTimeDateTimePicker1.TabIndex = 2;
            // 
            // radioStartEnd
            // 
            this.radioStartEnd.Location = new System.Drawing.Point(28, 44);
            this.radioStartEnd.Name = "radioStartEnd";
            this.radioStartEnd.Size = new System.Drawing.Size(18, 17);
            this.radioStartEnd.TabIndex = 5;
            this.radioStartEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioStartEnd.UseVisualStyleBackColor = true;
            this.radioStartEnd.Visible = false;
            // 
            // radioContinuous
            // 
            this.radioContinuous.Checked = true;
            this.radioContinuous.Location = new System.Drawing.Point(28, 20);
            this.radioContinuous.Name = "radioContinuous";
            this.radioContinuous.Size = new System.Drawing.Size(81, 18);
            this.radioContinuous.TabIndex = 4;
            this.radioContinuous.TabStop = true;
            this.radioContinuous.Text = "Continuous";
            this.radioContinuous.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.radioContinuous.UseVisualStyleBackColor = true;
            this.radioContinuous.Visible = false;
            // 
            // nameListBox
            // 
            this.nameListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nameListBox.DataSource = this.sysDefsBindingSource;
            this.nameListBox.DisplayMember = "Name";
            this.nameListBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameListBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nameListBox.FormattingEnabled = true;
            this.nameListBox.ItemHeight = 16;
            this.nameListBox.Location = new System.Drawing.Point(10, 25);
            this.nameListBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.nameListBox.Name = "nameListBox";
            this.nameListBox.ScrollAlwaysVisible = true;
            this.nameListBox.Size = new System.Drawing.Size(190, 196);
            this.nameListBox.TabIndex = 50;
            this.nameListBox.ValueMember = "Name";
            // 
            // FormSystems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(439, 255);
            this.Controls.Add(this.nameListBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.sysDefsBindingNavigator);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBoxMonitor);
            this.Controls.Add(this.dbNameTextBox);
            this.Controls.Add(this.msTextBox);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSystems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Systems Manager";
            ((System.ComponentModel.ISupportInitialize)(this.sysDefsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seeCommonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDefsBindingNavigator)).EndInit();
            this.sysDefsBindingNavigator.ResumeLayout(false);
            this.sysDefsBindingNavigator.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxMonitor.ResumeLayout(false);
            this.panelStartEnd.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private csi.see.classlib1.DataSets.SeeCommonDataSet seeCommonDataSet;
        private System.Windows.Forms.BindingSource sysDefsBindingSource;
        private System.Windows.Forms.BindingNavigator sysDefsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox ipAddressTextBox;
        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox dbNameTextBox;
        private System.Windows.Forms.CheckBox monOnCheckBox;
        private System.Windows.Forms.ToolStripButton btnChangeName;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox msTextBox;
        private System.Windows.Forms.GroupBox groupBoxMonitor;
        private System.Windows.Forms.Label labelContinuous;
        private System.Windows.Forms.Panel panelStartEnd;
        private System.Windows.Forms.DateTimePicker endPollTimeDateTimePicker1;
        private System.Windows.Forms.DateTimePicker startPollTimeDateTimePicker1;
        private System.Windows.Forms.RadioButton radioStartEnd;
        private System.Windows.Forms.RadioButton radioContinuous;
        private System.Windows.Forms.ListBox nameListBox;
    }
}