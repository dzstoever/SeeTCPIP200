using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class CtlVSE : csi.see.client1.CtlAChart
    {
        public CtlVSE()
        {
            InitializeComponent();
        }
        public CtlVSE(string name, string sqlConn, bool realTime)
        {
            InitializeComponent();
            chartA.ClearData();
            chartD.ClearData();
            //comboYaxis.Items.Add("Counts"); comboYaxis.Text = "Counts";
            TreeNode[] serNodes = FormatCharts(name, sqlConn, realTime,
                1, ChartTypes.Normal, new ChartSeries[]{
                ChartSeries.Nof_Allocated_Partitions,
                ChartSeries.Nof_Active_Tasks,
                ChartSeries.Program_Checks,
                ChartSeries.Phase_Loads,
                ChartSeries.Subchannel_Starts,
                ChartSeries.Supervisor_Interrupts,
                ChartSeries.IO_Interrupts,
                ChartSeries.External_Interrupts}, true);
            serView1.Nodes.AddRange(serNodes);
            //Hide series
            serView1.Nodes[3].Checked = false;
            serView1.Nodes[4].Checked = false;
            serView1.Nodes[5].Checked = false;
            serView1.Nodes[6].Checked = false;
            serView1.Nodes[7].Checked = false;            
        }

        public override void AddData(DateTime dt)
        {
            base.AddData(dt);
        }
    }
}

