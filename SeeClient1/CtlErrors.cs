using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class CtlErrors : csi.see.client1.CtlAChart
    {
        public CtlErrors()
        {
            InitializeComponent();
        }
        public CtlErrors(string name, string sqlConn, bool realTime)
        {
            InitializeComponent();
            chartA.ClearData();
            chartD.ClearData();
            //comboYaxis.Items.Add("Counts"); comboYaxis.Text = "Counts";
            TreeNode[] serNodes = FormatCharts(name, sqlConn, realTime,
                1, ChartTypes.Normal, new ChartSeries[]{
                ChartSeries.IP_Checksum_Errors,
                ChartSeries.TCP_Checksum_Errors,
                ChartSeries.UDP_Checksum_Errors,
                ChartSeries.ICMP_Checksum_Errors,
                ChartSeries.Datagram_Length_Errors}, true);
            serView1.Nodes.AddRange(serNodes);
            //Hide series
            //serView1.Nodes[].Checked = false;            
        }

        public override void AddData(DateTime dt)
        {
            base.AddData(dt);
        }
    }
}

