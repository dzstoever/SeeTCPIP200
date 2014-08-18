using SoftwareFX.ChartFX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csi.see.client1
{
    public partial class CtlAChart : csi.see.client1.CtlAADisplay
    {
        public BaseChartAbs chartA = new BaseChartAbs();
        public BaseChartDelt chartD = new BaseChartDelt();
        public CtlAChart()
        {
            InitializeComponent();
            chartA.Dock = DockStyle.Fill;
            chartD.Dock = DockStyle.Fill;
            panel1.Controls.Add(chartA);
            panel1.Controls.Add(chartD);
            //chartA.Visible = false;//Delta is the default

            chartA.CrossTabSeriesChanged += new csi.see.classlib1.EmptyDelegate(chart_CrossTabSeriesChanged);
            chartD.CrossTabSeriesChanged += new csi.see.classlib1.EmptyDelegate(chart_CrossTabSeriesChanged);
        }

        void chart_CrossTabSeriesChanged()
        {
            serView1.Nodes.Clear();
            if (chartA.CHART.NSeries > 0)
            { serView1.Nodes.AddRange(GetSeries()); }
        }

        public void InvokeCrossTabUpdate()
        {
            if (chartA._chartParams.Type == ChartTypes.Part_Cpu || chartA._chartParams.Type == ChartTypes.Part_Sio)
            { chartA.InvokeUpdatePJS(); chartD.InvokeUpdatePJS(); }
            else if (chartA._chartParams.Type == ChartTypes.Conn)
            { chartA.InvokeUpdateConn(); chartD.InvokeUpdateConn(); }
            else if (chartA._chartParams.Type == ChartTypes.ForIp)
            { chartA.InvokeUpdateForgnIP(); chartD.InvokeUpdateForgnIP(); }
        }
        public TreeNode[] FormatCharts(string name, string sqlConn, bool RealTime, int yAxisCnt, ChartTypes chType, ChartSeries[] chSeries, bool showAbs)
        {
            chartA.Visible = showAbs; 
            chartD.Visible = !showAbs;
            if (showAbs) { comboBox1.Text = comboBox1.Items[0].ToString(); }//Totals(Absolute)
            else { comboBox1.Text = comboBox1.Items[1].ToString(); }//Interval(Delta)
            
            FormatChart(chartA, name, sqlConn, RealTime, yAxisCnt, chType, chSeries);
            return FormatChart(chartD, name, sqlConn, RealTime, yAxisCnt, chType, chSeries);
        }

        private void FormatChart(BaseChartAbs chart, string name, string sqlConn, bool RealTime, int yAxisCnt, ChartTypes chType, ChartSeries[] chSeries)
        {            
            chart.FormatChart(name, RealTime);
            chart.SqlConnectString = sqlConn;
            foreach (ChartSeries series in chSeries)
            {
                SeeSeriesOptions serOpt = SeeChartParams.GetSeriesOptions(series);
                chart._chartParams.AddSeries(serOpt);                
            }
            chart.ApplySeriesOptions(chType, yAxisCnt);                        
        }
        private TreeNode[] FormatChart(BaseChartDelt chart, string name, string sqlConn, bool RealTime, int yAxisCnt, ChartTypes chType, ChartSeries[] chSeries)
        {
            chart.FormatChart(name, RealTime);
            chart.SqlConnectString = sqlConn;
            TreeNode[] tNodes = new TreeNode[chSeries.Length];
            int tCnt = 0;
            foreach (ChartSeries series in chSeries)
            {
                SeeSeriesOptions serOpt = SeeChartParams.GetSeriesOptions(series);
                chart._chartParams.AddSeries(serOpt);
                TreeNode tNode = new TreeNode(serOpt.SeriesName);
                tNode.Tag = serOpt; tNode.Checked = true;
                tNodes[tCnt] = tNode;
                tCnt++;
            }
            chart.ApplySeriesOptions(chType, yAxisCnt);
            
            return tNodes;
        }

        protected TreeNode[] GetSeries()
        {
            TreeNode[] tNodes = null;
            int serCnt = 0;
            /*if (comboBox1.SelectedIndex == 0)//Delta is selected
            {
                serCnt = chartD.CHART.NSeries;
                tNodes = new TreeNode[serCnt];
                for (int i = 0; i < serCnt; i++)
                {
                    TreeNode tNode = new TreeNode(chartD.CHART.Series[i].Legend);
                    object[] serAD = new object[2];
                    serAD[0] = chartA.CHART.Series[i];
                    serAD[1] = chartD.CHART.Series[i];
                    tNode.Tag = serAD;
                    tNode.Checked = chartA.CHART.Series[i].Visible;
                    tNodes[i] = tNode;
                }
                return tNodes;
            }
            else
            {*/
                serCnt = chartA.CHART.NSeries;
                tNodes = new TreeNode[serCnt];
                for (int i = 0; i < serCnt; i++)
                {
                    TreeNode tNode = new TreeNode(chartA.CHART.Series[i].Legend);
                    object[] serAD = new object[2];
                    serAD[0] = chartA.CHART.Series[i];
                    serAD[1] = chartD.CHART.Series[i];
                    tNode.Tag = serAD;
                    tNode.Checked = chartA.CHART.Series[i].Visible;
                    tNodes[i] = tNode;
                }
                return tNodes;
            //}
        }

        protected virtual void serView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            SeeSeriesOptions serOpt = (SeeSeriesOptions)e.Node.Tag;
            if (e.Node.Checked) 
            {
                chartA.CHART.Series[serOpt.SeriesIndex].Visible = true;
                chartD.CHART.Series[serOpt.SeriesIndex].Visible = true;            
            }
            else 
            {
                chartA.CHART.Series[serOpt.SeriesIndex].Visible = false;
                chartD.CHART.Series[serOpt.SeriesIndex].Visible = false;            
            }
        }
        private void comboXaxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cBox = (ComboBox)sender;
            if (cBox.SelectedIndex == 0){ chartD.Visible = false; chartA.Visible = true; }
            else { chartA.Visible = false; chartD.Visible = true; }
        }

        public virtual void AddData(DateTime dt)
        {
            chartA.DataBaseUpdatedHandler(dt);
            chartD.DataBaseUpdatedHandler(dt);
        }                
    }
}

