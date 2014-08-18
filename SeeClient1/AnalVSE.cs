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
    public partial class AnalVSE : BaseAnal
    {
        public AnalVSE()
        {
            InitializeComponent();            
        }

        private CtlVSE ctlVSE;

        public AnalVSE(string name, string sqlConnStr, bool realTime)
        {
            InitializeComponent();
            ctlVSE = new CtlVSE(name, sqlConnStr, realTime);            
            ctlVSE.Dock = DockStyle.Fill;
            Controls.Add(ctlVSE);                        
        }

        public override void AddData(DateTime dt)
        {
            ctlVSE.AddData(dt);            
        }
    }
}
