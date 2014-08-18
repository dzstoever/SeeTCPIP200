using csi.see.classlib1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class AnalInOut : BaseAnal
    {
        public AnalInOut()
        {
            InitializeComponent();            
        }

        private CtlInbound ctlIn;
        private CtlOutbound ctlOut;

        public AnalInOut(string name, string sqlConnStr, bool realTime)
        {
            InitializeComponent();

            ctlIn = new CtlInbound(name, sqlConnStr, realTime);
            ctlIn.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(ctlIn);

            ctlOut = new CtlOutbound(name, sqlConnStr, realTime);            
            ctlOut.Dock = DockStyle.Fill;            
            splitContainer1.Panel2.Controls.Add(ctlOut);            
        }

        public override void AddData(DateTime dt)
        {
            ctlIn.AddData(dt);
            ctlOut.AddData(dt);
        }
    }
}
