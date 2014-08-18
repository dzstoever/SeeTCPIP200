namespace csi.see.client1
{
    partial class ControlConsole
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
            TD.SandDock.DockContainer dockContainer2;
            TD.SandDock.DockContainer dockContainer1;
            this.dockableWindow1 = new TD.SandDock.DockableWindow();
            this.commandCenter1 = new ConsoleRecords.CommandCenter();
            this.sandDockManager1 = new TD.SandDock.SandDockManager();
            this.dockableWindow2 = new TD.SandDock.DockableWindow();
            this.messageCenter1 = new ConsoleRecords.MessageCenter();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tcpIpConsole1 = new ConsoleRecords.TcpIpConsole();
            dockContainer2 = new TD.SandDock.DockContainer();
            dockContainer1 = new TD.SandDock.DockContainer();
            dockContainer2.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            dockContainer1.SuspendLayout();
            this.dockableWindow2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockContainer2
            // 
            dockContainer2.Controls.Add(this.dockableWindow1);
            dockContainer2.Dock = System.Windows.Forms.DockStyle.Left;
            dockContainer2.LayoutSystem = new TD.SandDock.SplitLayoutSystem(250, 600, System.Windows.Forms.Orientation.Horizontal, new TD.SandDock.LayoutSystemBase[] {
            ((TD.SandDock.LayoutSystemBase)(new TD.SandDock.ControlLayoutSystem(250, 600, new TD.SandDock.DockControl[] {
                        ((TD.SandDock.DockControl)(this.dockableWindow1))}, this.dockableWindow1)))});
            dockContainer2.Location = new System.Drawing.Point(0, 0);
            dockContainer2.Manager = this.sandDockManager1;
            dockContainer2.Name = "dockContainer2";
            dockContainer2.Size = new System.Drawing.Size(254, 600);
            dockContainer2.TabIndex = 1;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.BorderStyle = TD.SandDock.Rendering.BorderStyle.RaisedThin;
            this.dockableWindow1.Controls.Add(this.commandCenter1);
            this.dockableWindow1.Guid = new System.Guid("b4bca99c-0d63-4389-ae87-04ec33ddc73e");
            this.dockableWindow1.Location = new System.Drawing.Point(0, 20);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Size = new System.Drawing.Size(250, 558);
            this.dockableWindow1.TabIndex = 0;
            this.dockableWindow1.Text = "Commands";
            // 
            // commandCenter1
            // 
            this.commandCenter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandCenter1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandCenter1.Location = new System.Drawing.Point(1, 1);
            this.commandCenter1.Name = "commandCenter1";
            this.commandCenter1.Release = null;
            this.commandCenter1.Size = new System.Drawing.Size(248, 556);
            this.commandCenter1.TabIndex = 0;
            this.commandCenter1.TcpIpCommand = null;
            // 
            // sandDockManager1
            // 
            this.sandDockManager1.BorderStyle = TD.SandDock.Rendering.BorderStyle.RaisedThick;
            this.sandDockManager1.DockSystemContainer = this;
            this.sandDockManager1.OwnerForm = null;
            this.sandDockManager1.Renderer = new TD.SandDock.Rendering.EverettRenderer();
            // 
            // dockContainer1
            // 
            dockContainer1.Controls.Add(this.dockableWindow2);
            dockContainer1.Dock = System.Windows.Forms.DockStyle.Right;
            dockContainer1.LayoutSystem = new TD.SandDock.SplitLayoutSystem(250, 600, System.Windows.Forms.Orientation.Horizontal, new TD.SandDock.LayoutSystemBase[] {
            ((TD.SandDock.LayoutSystemBase)(new TD.SandDock.ControlLayoutSystem(250, 600, new TD.SandDock.DockControl[] {
                        ((TD.SandDock.DockControl)(this.dockableWindow2))}, this.dockableWindow2)))});
            dockContainer1.Location = new System.Drawing.Point(546, 0);
            dockContainer1.Manager = this.sandDockManager1;
            dockContainer1.Name = "dockContainer1";
            dockContainer1.Size = new System.Drawing.Size(254, 600);
            dockContainer1.TabIndex = 3;
            // 
            // dockableWindow2
            // 
            this.dockableWindow2.BorderStyle = TD.SandDock.Rendering.BorderStyle.SunkenThin;
            this.dockableWindow2.Controls.Add(this.messageCenter1);
            this.dockableWindow2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dockableWindow2.Guid = new System.Guid("2f4e3e7a-7a31-48cd-8dad-6de9c02405bd");
            this.dockableWindow2.Location = new System.Drawing.Point(4, 20);
            this.dockableWindow2.Name = "dockableWindow2";
            this.dockableWindow2.Size = new System.Drawing.Size(250, 558);
            this.dockableWindow2.TabIndex = 1;
            this.dockableWindow2.Text = "Message Codes";
            // 
            // messageCenter1
            // 
            this.messageCenter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageCenter1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageCenter1.Location = new System.Drawing.Point(1, 1);
            this.messageCenter1.Message = null;
            this.messageCenter1.Name = "messageCenter1";
            this.messageCenter1.Release = null;
            this.messageCenter1.Size = new System.Drawing.Size(248, 556);
            this.messageCenter1.TabIndex = 0;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.statusStrip2.Location = new System.Drawing.Point(254, 0);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(292, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 48;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(277, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "TCP/IP Console";
            // 
            // tcpIpConsole1
            // 
            this.tcpIpConsole1.Active = true;
            this.tcpIpConsole1.Archive = null;
            this.tcpIpConsole1.BackColor = System.Drawing.SystemColors.Control;
            this.tcpIpConsole1.Command = "";
            this.tcpIpConsole1.DisplaySize = 33;
            this.tcpIpConsole1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcpIpConsole1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcpIpConsole1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tcpIpConsole1.Location = new System.Drawing.Point(254, 22);
            this.tcpIpConsole1.Name = "tcpIpConsole1";
            this.tcpIpConsole1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tcpIpConsole1.PageSize = 33;
            this.tcpIpConsole1.Size = new System.Drawing.Size(292, 578);
            this.tcpIpConsole1.TabIndex = 49;
            this.tcpIpConsole1.Tag = "";
            // 
            // ControlConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcpIpConsole1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(dockContainer2);
            this.Controls.Add(dockContainer1);
            this.Name = "ControlConsole";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.ConsoleControl_Load);
            dockContainer2.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            dockContainer1.ResumeLayout(false);
            this.dockableWindow2.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TD.SandDock.SandDockManager sandDockManager1;
        private TD.SandDock.DockableWindow dockableWindow1;
        private TD.SandDock.DockableWindow dockableWindow2;
        private ConsoleRecords.MessageCenter messageCenter1;
        private ConsoleRecords.CommandCenter commandCenter1;
        private ConsoleRecords.TcpIpConsole tcpIpConsole1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}
