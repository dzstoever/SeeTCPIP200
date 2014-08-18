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
using System.Collections;

namespace csi.see.client1
{
    public partial class AnalConns : csi.see.client1.BaseAnal
    {
        SqlManagerSystem sqlMan = new SqlManagerSystem();
        DateTime startDT = DateTime.Now;
        DateTime endDT = DateTime.Now;
        ArrayList timesList;

        public AnalConns()
        { InitializeComponent(); }

        public AnalConns(string name, string dbName, bool realTime)
        {
            InitializeComponent();
            sqlMan.SetDb(dbName);
            statStart.Text = startDT.ToString();
            statEnd.Text = endDT.ToString();
            if (!realTime)
            { 
                button1.Visible = false;
                labelType.Text = "Historical";
            }
            else{labelType.Text = "Recent Activity";}
        }

        public void SetTimeRange(DateTime start, DateTime end, DateTime[] times)
        {
            timesList = new ArrayList(times);
            startDT = start;
            endDT = end;
            statStart.Text = startDT.ToString();
            statEnd.Text = endDT.ToString();
            //Load the treeview
            FillConnListFromRange(startDT, endDT);
            //Fill a full dataset
            //int recCnt = sqlMan.Fill_ConnStatsByRange(
                //vseDbDataSet1, true, startDT, endDT);
        }
        
        public override void AddData(DateTime dt)
        {            
            endDT = dt;            
            statEnd.Text = endDT.ToString();
            //DateTime start = (DateTime)timesList[1];
            //FillConnListFromRange(startDT, endDT);
            //Update timesList
            timesList.Add(dt);

            if (treeView1.SelectedNode.Level == 1)
            {//Add any new rows for the current connection
                object oTag = treeView1.SelectedNode.Tag;
                VseDbDataSet.Connection_StatsRow partialRow = (VseDbDataSet.Connection_StatsRow)oTag;
                float localPort = Convert.ToSingle(partialRow.Local_Port);
                float forgnPort = Convert.ToSingle(partialRow.Foreign_Port);
                string forgnIp = partialRow.Foreign_IP;
                DateTime connStart = partialRow.Conn_Start_Time;

                DataTable nTable = sqlMan.Get_ConnStatsByParams(vseDbDataSet1, true, 
                    dt, dt,
                    localPort, forgnPort, forgnIp, connStart);
                if (nTable.Rows.Count > 0)
                {
                    foreach (VseDbDataSet.Connection_StatsRow cRow in nTable.Rows)
                    {
                        dsetConns.TrafficStatsRow tRow = dsetConns1.TrafficStats.NewTrafficStatsRow();
                        tRow.Dtime = cRow.Poll_Time;
                        tRow.Connection_State = cRow.Conn_State;
                        tRow.Start_Time = cRow.Conn_Start_Time;
                        tRow.Inbound_Bytes = cRow.Inbound_Bytes;
                        tRow.Outbound_Bytes = cRow.Outbound_Bytes;
                        tRow.Inbound_Datagrams = cRow.Inbound_Data;
                        tRow.Outbound_Datagrams = cRow.Outbound_Data;
                        tRow.Receives_Issues = cRow.Recvs_Issued;
                        tRow.Sends_Issued = cRow.Sends_Issued;
                        tRow.Max_Receive_Window = cRow.Max_Recv_Window;
                        tRow.Max_Send_Window = cRow.Max_Send_Window;
                        tRow.Nof_Times_Receive_Window_Closed = cRow.Recv_Window_Closed;
                        tRow.Nof_Times_in_Retransmit = cRow.In_Retr_Mode;
                        tRow.Retransmits = cRow.Retransmits;
                        tRow.SWS_Count = cRow.SWS_Count;

                        dsetConns1.TrafficStats.AddTrafficStatsRow(tRow);
                    }
                    dataGridView1.DataSource = dsetConns1.TrafficStats;
                }
            }

        }

        private void FillConnListFromRange(DateTime start, DateTime end)
        {
            treeView1.Nodes.Clear();
            //Distinct local ports
            VseDbDataSet.Connection_StatsDataTable distinctLocalPorts = new VseDbDataSet.Connection_StatsDataTable();
            distinctLocalPorts = sqlMan.Fill_DistinctLocalPortsByRange(start, end);
            //Distinct connection records
            //SELECT DISTINCT Local_Port, Foreign_Port, Foreign_IP, Conn_Start_Time 
            VseDbDataSet.Connection_StatsDataTable distinctConns = new VseDbDataSet.Connection_StatsDataTable();
            distinctConns = sqlMan.Fill_DistinctConnStatsByRange(start, end);

            string selBase = "Local_Port = 'portnum'";
            foreach (VseDbDataSet.Connection_StatsRow lRow in distinctLocalPorts.Rows)
            {
                string sPort = lRow.Local_Port.ToString("F0");
                TreeNode tNode = new TreeNode(sPort);
                
                string selPort = selBase.Replace("portnum", sPort);
                DataRow[] cRows = distinctConns.Select(selPort);                
                foreach (VseDbDataSet.Connection_StatsRow cRow in cRows)
                {
                    #region build child nodes
                    //double localPort = (double)cRow["Local_Port"];
                    double forgnPort = (double)cRow["Foreign_Port"];
                    //string lPort = localPort.ToString("F0");
                    string fPort = forgnPort.ToString("F0");
                    string fIp = (string)cRow["Foreign_IP"];
                    DateTime startTime = (DateTime)cRow["Conn_Start_Time"];
                    string sTime = startTime.ToString();

                    StringBuilder sb = new StringBuilder(fPort);                    
                    sb.Append(" : ");
                    sb.Append(fIp);
                    sb.Append(" (");
                    sb.Append(sTime);
                    sb.Append(")");
                    string cDisplay = sb.ToString();
                    TreeNode cNode = new TreeNode(cDisplay);
                    cNode.Tag = cRow;
                    tNode.Nodes.Add(cNode);
                    
                    #endregion
                }
                treeView1.Nodes.Add(tNode);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Level == 1)
            {//Load the rows for this connection
                object oTag = treeView1.SelectedNode.Tag;
                VseDbDataSet.Connection_StatsRow partialRow = (VseDbDataSet.Connection_StatsRow)oTag;
                tbConnStart.Text = partialRow.Conn_Start_Time.ToString();
                tbForeignIP.Text = partialRow.Foreign_IP;
                tbForeignPort.Text = partialRow.Foreign_Port.ToString("F0");
                tbLocalPort.Text = partialRow.Local_Port.ToString("F0");
                
                
                float localPort = Convert.ToSingle(partialRow.Local_Port);
                float forgnPort = Convert.ToSingle(partialRow.Foreign_Port);
                string forgnIp = partialRow.Foreign_IP;
                DateTime connStart = partialRow.Conn_Start_Time;
                int cCnt = sqlMan.Fill_ConnStatsByParams(vseDbDataSet1, true, startDT, endDT,
                    localPort, forgnPort, forgnIp, connStart);
                if (cCnt > 0)
                {                    
                    string pid = (string)vseDbDataSet1.Connection_Stats[0]["Conn_PID"];
                    tbPID.Text = pid;
                    //string phase = (string)vseDbDataSet1.Connection_Stats[0]["Conn_Phase"];
                    //tbPhase.Text = phase;
                }
                dsetConns1.TrafficStats.Rows.Clear();
                foreach (VseDbDataSet.Connection_StatsRow cRow in vseDbDataSet1.Connection_Stats.Rows)
                {
                    dsetConns.TrafficStatsRow tRow = dsetConns1.TrafficStats.NewTrafficStatsRow(); 
                    tRow.Dtime = cRow.Poll_Time;
                    tRow.Connection_State = cRow.Conn_State;
                    tRow.Start_Time = cRow.Conn_Start_Time;
                    tRow.Inbound_Bytes = cRow.Inbound_Bytes;
                    tRow.Outbound_Bytes = cRow.Outbound_Bytes;
                    tRow.Inbound_Datagrams = cRow.Inbound_Data;
                    tRow.Outbound_Datagrams = cRow.Outbound_Data;
                    tRow.Receives_Issues = cRow.Recvs_Issued;
                    tRow.Sends_Issued = cRow.Sends_Issued;
                    tRow.Max_Receive_Window = cRow.Max_Recv_Window;
                    tRow.Max_Send_Window = cRow.Max_Send_Window;
                    tRow.Nof_Times_Receive_Window_Closed = cRow.Recv_Window_Closed;
                    tRow.Nof_Times_in_Retransmit = cRow.In_Retr_Mode;
                    tRow.Retransmits = cRow.Retransmits;
                    tRow.SWS_Count = cRow.SWS_Count;

                    dsetConns1.TrafficStats.AddTrafficStatsRow(tRow);
                }
                dataGridView1.DataSource = dsetConns1.TrafficStats;
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillConnListFromRange(startDT, endDT);
        }

        
    }
}

