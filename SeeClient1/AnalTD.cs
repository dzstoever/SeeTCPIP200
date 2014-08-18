using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class AnalTD : csi.see.client1.BaseAnal
    {
        public AnalTD()
        {
            InitializeComponent();
        }

        private CtlTD ctlTD;
       

        public AnalTD(string name, string sqlConnStr, bool realTime)
        {
            InitializeComponent();

            ctlTD = new CtlTD(name, sqlConnStr, realTime);
            ctlTD.Dock = DockStyle.Fill;
            
            Controls.Add(ctlTD);

            
        }

        public override void AddData(DateTime dt)
        {
            ctlTD.AddData(dt);            
        }
    }
}

