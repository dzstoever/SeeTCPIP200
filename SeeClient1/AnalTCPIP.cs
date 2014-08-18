using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class AnalTCPIP : csi.see.client1.BaseAnal
    {
        public AnalTCPIP()
        {
            InitializeComponent();
        }

        private CtlTcpipActivity ctlTcpip;
        private CtlErrors ctlErrors;

        public AnalTCPIP(string name, string sqlConnStr, bool realTime)
        {
            InitializeComponent();

            ctlTcpip = new CtlTcpipActivity(name, sqlConnStr, realTime);
            ctlTcpip.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(ctlTcpip);

            ctlErrors = new CtlErrors(name, sqlConnStr, realTime);
            ctlErrors.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(ctlErrors);            
        }

        public override void AddData(DateTime dt)
        {
            ctlTcpip.AddData(dt);
            ctlErrors.AddData(dt);
        }
    }
}

