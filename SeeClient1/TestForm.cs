using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using csi.see.classlib1;
using csi.see.classlib1.DataSets;


namespace csi.see.client1
{
    public partial class TestForm : Form
    {
        DateTime startDT = new DateTime(2008, 11, 13, 0, 0, 0);
        DateTime endDT = new DateTime(2008, 11, 14, 0, 0, 0);
        SqlManagerSystem sqlMan = new SqlManagerSystem();

        public TestForm()
        {
            InitializeComponent();            
            sqlMan.SetDb("LCTEST");
            comboBox1.Items.AddRange(IpXSLT.GetAvailableTransforms());
            comboBox1.DisplayMember = "DisplayText";
            comboBox1.ValueMember = "XslFilePath";
            comboBox1.Text = "IP Address";
            /*
            bindingSource1.DataSource = vseDbDataSet1;
            bindingSource1.DataMember = "ForeignIP_Stats";
            */            
        }
        private void TestForm_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = startDT.ToString();
            richTextBox2.Text = endDT.ToString();
            FillIpListFromRange(startDT, endDT);
            //Fill a full dataset
            int recCnt = sqlMan.Fill_ForgnIpStatsByRange(
                vseDbDataSet1, true, startDT, endDT);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    FillIpListFromRange(startDT, endDT);
                    break;
                case 1:
                    FillIpListFromRangeSort("IP_Inbound_Bytes", "IP_Inbound_Datagrams");
                    break;
                case 2:
                    FillIpListFromRangeSort("IP_Outbound_Bytes", "IP_Outbound_Datagrams");
                    break;
                default:
                    break;
            }

        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Level == 0)
            { 
                string ipAddress = treeView1.SelectedNode.Text;
                richTextBox3.Text = ipAddress;
                ChangeDataSource(ipAddress, radioBytes.Checked);
            }
        }
        private void radioBytes_CheckedChanged(object sender, EventArgs e)
        {
            string ipAddress = treeView1.SelectedNode.Text;
            ChangeDataSource(ipAddress, radioBytes.Checked);
            /*if (radioBytes.Checked)
            { }
            else
            { }*/
        }
        
        private void ChangeDataSource(string ipAddr, bool scaleBytes)
        {
            string filterExp = @"IP_Address = '_ip_'";
            filterExp = filterExp.Replace("_ip_", ipAddr);
            string sortExp = "Poll_Time ASC";
            
            DataRow[] rows = vseDbDataSet1.ForeignIP_Stats.Select(filterExp, sortExp);
            //string ip = (string)rows[0]["IP_Address"];
            //baseChartAbs1.FormatChart(ip,false);
            dsetForgnIPs dsetFIPs = new dsetForgnIPs();
            dsetFIPs.TrafficMain.Rows.Clear();
            foreach (DataRow row in rows)
            {
                VseDbDataSet.ForeignIP_StatsRow fRow = (VseDbDataSet.ForeignIP_StatsRow)row;
                dsetForgnIPs.TrafficMainRow tRow = dsetFIPs.TrafficMain.NewTrafficMainRow();
                tRow.DTime = fRow.Poll_Time;
                if (scaleBytes)
                {
                    tRow.InIP = fRow.IP_Inbound_Bytes;
                    tRow.InTCP = fRow.TCP_Inbound_Bytes;
                    tRow.InUDP = fRow.UDP_Inbound_Bytes;
                    tRow.InICMP = fRow.ICMP_Inbound_Bytes;
                }
                else
                {
                    tRow.InIP = fRow.IP_Inbound_Datagrams;
                    tRow.InTCP = fRow.TCP_Inbound_Datagrams;
                    tRow.InUDP = fRow.UDP_Inbound_Datagrams;
                    tRow.InICMP = fRow.ICMP_Inbound_Datagrams;
                }                                
                dsetFIPs.TrafficMain.AddTrafficMainRow(tRow);
            }

            dataGridView1.DataSource = dsetFIPs.TrafficMain;
            //baseChartAbs1.SetDataSource(dsetFIPs.TrafficMain);
        }

        private void WriteForgnIpXmlDoc()
        {
            /*Fills an datatable with all records in the DT range and writes the XML 
           int recCnt = sqlMan.Fill_ForgnIpStatsByRange(vseDbDataSet1, true, startDT, endDT);
           string fPath = IpXSLT.XslFolderPath + "ForgnIpStats.xml";
           vseDbDataSet1.ForeignIP_Stats.WriteXml(fPath);
           */
        }
        private void FillIpListFromRange(DateTime start, DateTime end)
        {
            treeView1.Nodes.Clear();
            VseDbDataSet.ForeignIP_StatsDataTable distinctIPs = new VseDbDataSet.ForeignIP_StatsDataTable();
            distinctIPs = sqlMan.Fill_DistinctIpStatsByRange(start, end);            
            foreach (VseDbDataSet.ForeignIP_StatsRow fIpRow in distinctIPs.Rows)
            {
                string ipText = (string)fIpRow["IP_Address"];
                
                TreeNode tNode = new TreeNode(ipText);
                treeView1.Nodes.Add(tNode);
            }
        }
        private void FillIpListFromRangeSort(string colBytes, string colDgrams)
        {
            treeView1.Nodes.Clear();
            string selMAX = @"SELECT MAX(xcolx) from dbo.ForeignIP_Stats where IP_Address = 'xipx'";
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = SqlManagerSystem.BuildConnection("LCTEST").ConnectionString;
            SqlCommand sqlComm = new SqlCommand(selMAX, sqlConn);
            try
            {
                VseDbDataSet.ForeignIP_StatsDataTable distinctIPs = new VseDbDataSet.ForeignIP_StatsDataTable();
                distinctIPs = sqlMan.Fill_DistinctIpStatsByRange(startDT, endDT);
                sqlConn.Open();
                foreach (VseDbDataSet.ForeignIP_StatsRow fIpRow in distinctIPs.Rows)
                {
                    string ipText = (string)fIpRow["IP_Address"];
                    string sel0 = selMAX.Replace("xipx", ipText);//base SELECT 
                    string sel1 = sel0.Replace("xcolx", colBytes);
                    sqlComm.CommandText = sel1;//SELECT maximum byte count in timespan
                    double maxBytes = (double)sqlComm.ExecuteScalar();
                    string sel2 = sel0.Replace("xcolx", colDgrams);
                    sqlComm.CommandText = sel2;//SELECT maximum datagram count in timespan
                    double maxDgrams = (double)sqlComm.ExecuteScalar();
                    fIpRow[colBytes] = maxBytes;
                    fIpRow[colDgrams] = maxDgrams;
                }
                string selOver0 = colBytes + " > '0'";//Filter out 0 values
                string sortDESC = colBytes + " DESC";//Order descending
                DataRow[] maxRows = distinctIPs.Select(selOver0, sortDESC);
                foreach (DataRow row in maxRows)
                {
                    string ipText = (string)row["IP_Address"];
                    double kbytes = (double)row[colBytes] / 1024;
                    double dgrams = (double)row[colDgrams];
                    string bText = kbytes.ToString("N0") + " KB";//remove decimals
                    string dText = dgrams.ToString("N0") + " dgrams";//remove decimals
                    
                    TreeNode tNode = new TreeNode(ipText);
                    tNode.Nodes.Add(bText + " / " + dText);
                    treeView1.Nodes.Add(tNode);
                }
            }
            catch (Exception exc)
            { Console.WriteLine(exc.Message); }
            finally
            { if (sqlConn.State != ConnectionState.Closed) sqlConn.Close(); }
 
        }

        

        

        
    }

    
}