using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class CtlTcpipActivity : csi.see.client1.CtlAChart
    {
        public CtlTcpipActivity()
        { InitializeComponent(); }
        public CtlTcpipActivity(string name, string sqlConn, bool realTime)
        {
            InitializeComponent();
            chartA.ClearData();
            chartD.ClearData();
            //comboYaxis.Items.Add("Counts"); comboYaxis.Text = "Counts";                        
            TreeNode[] serNodes = FormatCharts(name, sqlConn, realTime,
                1, ChartTypes.Normal, new ChartSeries[]{
                ChartSeries.Nof_TCPIP_Connections,
                ChartSeries.Connect_Rejections,                
                ChartSeries.Inbound_TCP_Rejections,                
                ChartSeries.LPR_Clients,
                ChartSeries.Telnet_Clients,
                ChartSeries.FTP_Clients,
                ChartSeries.HTTP_Clients,
                ChartSeries.Storage_Releases,
                ChartSeries.Nof_TCPIP_PseudoTasks}, true);
            serView1.Nodes.AddRange(serNodes);
            //Hide series            
            serView1.Nodes[3].Checked = false;
            serView1.Nodes[4].Checked = false;
            serView1.Nodes[5].Checked = false;
            serView1.Nodes[6].Checked = false;
            serView1.Nodes[7].Checked = false;
            serView1.Nodes[8].Checked = false;
        }

        public override void AddData(DateTime dt)
        {
            base.AddData(dt);
        }
        
    }
}

