using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class CtlOutbound : csi.see.client1.CtlAChart
    {
        public CtlOutbound()
        {
            InitializeComponent();
        }
        public CtlOutbound(string name, string sqlConn, bool realTime)
        {
            InitializeComponent();
            chartA.ClearData();
            chartD.ClearData();
            //comboYaxis.Items.Add("Bytes"); comboYaxis.Text = "Bytes";                        
            TreeNode[] serNodes = FormatCharts(name, sqlConn, realTime,
                1, ChartTypes.Normal, new ChartSeries[]{
                ChartSeries.IP_Bytes_Sent,
                ChartSeries.TCP_Bytes_Sent,
                ChartSeries.UDP_Bytes_Sent,
                ChartSeries.Telnet_Bytes_Sent,
                ChartSeries.Int_FTP_Bytes_Sent}, false);
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

