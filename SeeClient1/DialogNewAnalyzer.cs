using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class DialogNewAnalyzer : Form
    {
        public DialogNewAnalyzer()
        {
            InitializeComponent();
        }

        public bool IsHistorical
        {
            get
            {
                if (radioHistory.Checked) { return true; }
                else { return false; }
            }
        }
        public DateTime StartTime
        {
            get { return dateTimePicker1.Value; }
        }
        public DateTime EndTime
        {
            get { return dateTimePicker2.Value; }
        }

        public ArrayList GetSelectedAnalyzers()
        {
            ArrayList list = new ArrayList();
            if (cb00.Checked) { list.Add(PrebuiltAnalyzers.VSE); }
            if (cb01.Checked) { list.Add(PrebuiltAnalyzers.CPU); }
            if (cb02.Checked) { list.Add(PrebuiltAnalyzers.TD); }
            if (cb03.Checked) { list.Add(PrebuiltAnalyzers.SIOs); }
            if (cb04.Checked) { list.Add(PrebuiltAnalyzers.TCPIP); }
            if (cb05.Checked) { list.Add(PrebuiltAnalyzers.InOut); }
            if (cb06.Checked) { list.Add(PrebuiltAnalyzers.ForgnIps); }
            if (cb07.Checked) { list.Add(PrebuiltAnalyzers.Conns); }
            //if (cb08.Checked) { list.Add(PrebuiltAnalyzers.BSDC); }                                                
            //if (cb09.Checked) { list.Add(PrebuiltAnalyzers.FTPs); }                                                

            return list;
        }

        private void radioHistory_CheckedChanged(object sender, EventArgs e)
        {
            if (radioHistory.Checked)
            { panelDTs.Enabled = true; }
            else
            { panelDTs.Enabled = false; }
        }
    }

    public enum PrebuiltAnalyzers:int
    {
        VSE = 0,
        CPU = 1,
        TD = 2,
        SIOs = 3,        
        TCPIP = 4,
        InOut = 5,
        ForgnIps = 6,
        Conns = 7,                
        BSDC = 8,
        FTPs  = 9,                
    }
}