namespace csi.see.client1
{
    partial class CtlAADisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            TD.SandDock.DockContainer dockContainer1;
            this.dockableWindow1 = new TD.SandDock.DockableWindow();
            this.serView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sandDockManager1 = new TD.SandDock.SandDockManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            dockContainer1 = new TD.SandDock.DockContainer();
            dockContainer1.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockContainer1
            // 
            //dockContainer1.Controls.Add(this.dockableWindow1);
            dockContainer1.Dock = System.Windows.Forms.DockStyle.Right;
            dockContainer1.LayoutSystem = new TD.SandDock.SplitLayoutSystem(176, 388, System.Windows.Forms.Orientation.Horizontal, new TD.SandDock.LayoutSystemBase[] {
            ((TD.SandDock.LayoutSystemBase)(new TD.SandDock.ControlLayoutSystem(176, 388, new TD.SandDock.DockControl[] {
                        ((TD.SandDock.DockControl)(this.dockableWindow1))}, this.dockableWindow1)))});
            dockContainer1.Location = new System.Drawing.Point(348, 0);
            dockContainer1.Manager = this.sandDockManager1;
            dockContainer1.Name = "dockContainer1";
            dockContainer1.Size = new System.Drawing.Size(180, 388);
            dockContainer1.TabIndex = 0;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.AllowClose = false;
            this.dockableWindow1.BackColor = System.Drawing.SystemColors.Window;
            this.dockableWindow1.BorderStyle = TD.SandDock.Rendering.BorderStyle.SunkenThin;
            this.dockableWindow1.Controls.Add(this.serView1);
            this.dockableWindow1.Controls.Add(this.panel2);
            this.dockableWindow1.Guid = new System.Guid("96d91e95-3c5c-4948-83cf-3b138c803d30");
            this.dockableWindow1.Location = new System.Drawing.Point(4, 20);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Size = new System.Drawing.Size(176, 346);
            this.dockableWindow1.TabIndex = 0;
            this.dockableWindow1.Text = "Options";
            // 
            // serView1
            // 
            this.serView1.CheckBoxes = true;
            this.serView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serView1.Location = new System.Drawing.Point(1, 43);
            this.serView1.Name = "serView1";
            this.serView1.Size = new System.Drawing.Size(174, 302);
            this.serView1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.panel2.Size = new System.Drawing.Size(174, 42);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(174, 22);
            this.panel3.TabIndex = 34;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Totals (Absolute)",
            "Interval (Delta)"});
            this.comboBox1.Location = new System.Drawing.Point(42, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 21);
            this.comboBox1.TabIndex = 40;
            this.comboBox1.Text = "Interval (Delta)";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 22);
            this.label1.TabIndex = 39;
            this.label1.Text = "Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(0, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 19);
            this.label6.TabIndex = 33;
            this.label6.Text = "Show / Hide";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // sandDockManager1
            // 
            this.sandDockManager1.DockSystemContainer = this;
            this.sandDockManager1.OwnerForm = null;
            this.sandDockManager1.Renderer = new TD.SandDock.Rendering.EverettRenderer();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 388);
            this.panel1.TabIndex = 5;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 30000;
            this.toolTip1.InitialDelay = 250;
            this.toolTip1.ReshowDelay = 100;
            // 
            // CtlAADisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Controls.Add(dockContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CtlAADisplay";
            this.Size = new System.Drawing.Size(528, 388);
            dockContainer1.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TD.SandDock.SandDockManager sandDockManager1;
        private System.Windows.Forms.Label label6;
        protected TD.SandDock.DockableWindow dockableWindow1;
        protected System.Windows.Forms.TreeView serView1;
        protected System.Windows.Forms.Panel panel2;
        protected internal System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel3;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ComboBox comboBox1;



    }
}
