using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using csi.see.classlib1;
using System.Data.SqlClient;

namespace csi.see.client1
{
    public partial class zConnections : UserControl
    {
        public zConnections()
        {
            InitializeComponent();
        }
        public zConnections(string name, string sqlConn)
        {
            InitializeComponent();

            SqlManagerSystem sqlMan = new SqlManagerSystem();
            sqlMan.SetDb(new SqlConnection(sqlConn));
            int connRecCnt = sqlMan.Fill_Conn(vseDbDataSet, true);
            
        }
    }
}
