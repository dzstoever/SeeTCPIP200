using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class CtlTD_CPU : csi.see.client1.CtlAChart
    {
        public CtlTD_CPU()
        {
            InitializeComponent();
        }
        public CtlTD_CPU(string name, string sqlConn, bool realTime)
        {
            InitializeComponent();
            chartA.ClearData();
            chartD.ClearData();
            //dockableWindow1.Close();
            //comboYaxis.Items.Add("Percent"); comboYaxis.Text = "Percent";                        
            TreeNode[] serNodes = FormatCharts(name, sqlConn, realTime, 
                1, ChartTypes.Cpu_Activity, new ChartSeries[]{
                ChartSeries.Busy_NonP_sec,
                ChartSeries.Busy_P_sec,
                ChartSeries.Waiting_sec,
                ChartSeries.Spin_sec,    
                ChartSeries.NonVSE_sec}, false);                                                                
            //serView1.Nodes.AddRange(serNodes);
            //Hide series
            //serView1.Nodes[].Checked = false;          
        }

        public override void AddData(DateTime dt)
        {
            base.AddData(dt);
            //Update based on the stacked series
            serView1.Nodes.Clear();
            if (chartA.CHART.NSeries > 0)
            { serView1.Nodes.AddRange(GetSeries()); }                                    
        }
        
        protected override void serView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            object[] serAD = (object[])e.Node.Tag;
            SoftwareFX.ChartFX.SeriesAttributes seriesA = (SoftwareFX.ChartFX.SeriesAttributes)serAD[0];
            SoftwareFX.ChartFX.SeriesAttributes seriesD = (SoftwareFX.ChartFX.SeriesAttributes)serAD[1];            
            if (e.Node.Checked)
            { seriesA.Visible = true; seriesD.Visible = true; }
            else
            { seriesA.Visible = false; seriesD.Visible = false; }
        }
    }
}

