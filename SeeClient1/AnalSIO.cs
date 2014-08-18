using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class AnalSIO : csi.see.client1.BaseAnal
    {
        public AnalSIO()
        {
            InitializeComponent();
        }

        private CtlJobs_SIO ctlSIO;

        public AnalSIO(string name, string sqlConnStr, bool realTime)
        {
            InitializeComponent();
            ctlSIO = new CtlJobs_SIO(name, sqlConnStr, realTime);
            ctlSIO.Dock = DockStyle.Fill;
            Controls.Add(ctlSIO);                        
        }

        public override void AddData(DateTime dt)
        {
            ctlSIO.AddData(dt);            
        }
        public override void InvokeCrossTabUpdate()
        {
            ctlSIO.InvokeCrossTabUpdate();
        }
    }
}

