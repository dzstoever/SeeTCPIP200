using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class AnalCPU : csi.see.client1.BaseAnal
    {
        public AnalCPU()
        {
            InitializeComponent();
        }

        private CtlTD_CPU ctlTD_CPU;
        private CtlJobs_CPU ctlJobs_CPU;

        public AnalCPU(string name, string sqlConnStr, bool realTime)
        {
            InitializeComponent();

            ctlTD_CPU = new CtlTD_CPU(name, sqlConnStr, realTime);
            ctlTD_CPU.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(ctlTD_CPU);

            ctlJobs_CPU = new CtlJobs_CPU(name, sqlConnStr, realTime);
            ctlJobs_CPU.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(ctlJobs_CPU);            
        }

        public override void AddData(DateTime dt)
        {
            ctlTD_CPU.AddData(dt);
            ctlJobs_CPU.AddData(dt);
        }

        public override void InvokeCrossTabUpdate()
        {
            ctlJobs_CPU.InvokeCrossTabUpdate();
        }
    }
}

