using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class CtlInbound : csi.see.client1.CtlAChart
    {
        public CtlInbound()
        {
            InitializeComponent();
        }
        public CtlInbound(string name, string sqlConn, bool realTime)
        {
            InitializeComponent();
            chartA.ClearData();
            chartD.ClearData();
            //comboYaxis.Items.Add("Bytes"); comboYaxis.Text = "Bytes";
            TreeNode[] serNodes = FormatCharts(name, sqlConn, realTime,
                1, ChartTypes.Normal, new ChartSeries[]{                
                ChartSeries.IP_Bytes_Received,
                ChartSeries.TCP_Bytes_Received,
                ChartSeries.UDP_Bytes_Received,
                ChartSeries.Telnet_Bytes_Received,
                ChartSeries.Int_FTP_Bytes_Received}, false);
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

