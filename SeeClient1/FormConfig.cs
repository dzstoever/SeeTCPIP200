using csi.see.classlib1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ServiceProcess;

namespace csi.see.client1
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }


        

        //private string defSqlStrMaster = //This is the default sql connection string 
        //    @"Integrated Security=True;Persist Security Info=False;Pooling=False;Data Source=.\SQLEXPRESS;Initial Catalog=master";
        private string currSqlStrMaster = "";//hold the current setting
        
        private SqlConnectionStringBuilder sqlConnBuilder;
        private SeeSystemConfig seeSysConfig = new SeeSystemConfig();


        public string SqlStrMaster
        {
            get { return seeSysConfig.SqlConnStrMaster; }
        }
        
        private void FormConfig_Load(object sender, EventArgs e)
        {
            currSqlStrMaster = seeSysConfig.SqlConnStrMaster;
            sqlConnBuilder = new SqlConnectionStringBuilder(currSqlStrMaster);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Server Name = " + sqlConnBuilder.DataSource);
            sb.AppendLine("Use Windows Authentication = " + sqlConnBuilder.IntegratedSecurity.ToString());
            if (!sqlConnBuilder.IntegratedSecurity)
            {
                sb.AppendLine("User = " + sqlConnBuilder.UserID);
                sb.AppendLine("Password = " + sqlConnBuilder.Password);
            }
            textBox1.Text = sb.ToString();
            FillSqlServerList();            
        }

        private void radioLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLogin.Checked)
            {
                tbName.Enabled = true;
                tbPassword.Enabled = true;
            }
            else
            {
                tbName.Enabled = false;
                tbPassword.Enabled = false;
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {            
            FillSqlServerList();            
        }

        private void btnCheckSqlServer_Click(object sender, EventArgs e)
        {
            sqlConnBuilder.DataSource = comboBox1.Text;
            if (radioWindowsAuth.Checked)
            {
                sqlConnBuilder.IntegratedSecurity = true;
                sqlConnBuilder.UserID = "";
                sqlConnBuilder.Password = "";
            }
            else
            {
                sqlConnBuilder.IntegratedSecurity = false;
                sqlConnBuilder.UserID = tbName.Text;
                sqlConnBuilder.Password = tbPassword.Text;
            }
            
            SqlConnection sqlConn = new SqlConnection(sqlConnBuilder.ConnectionString);            
            Cursor pCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;        
                sqlConn.Open();
                testStatusLabel.Text = "Test Succeeded for '" + sqlConnBuilder.DataSource + "'";
                btnSave.Enabled = true;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
                testStatusLabel.Text = "Test Failed for '" + sqlConnBuilder.DataSource + "'";
                btnSave.Enabled = false;
            }
            finally
            {
                if (sqlConn.State != ConnectionState.Closed)
                { sqlConn.Close(); }
            }
            
        }        

        private void btnCheckServiceStatus_Click(object sender, EventArgs e)
        {
            try
            {
                statService.Text = "Service(" +serviceController1.ServiceName+") is "+serviceController1.Status.ToString();                
            }
            catch (InvalidOperationException)
            {
                statService.Text = "Required service is not installed.";
            }
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            Cursor pCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (serviceController1.Status != ServiceControllerStatus.Stopped)
                {
                    statService.Text = "Stopping the service...";
                    StopService(20);
                    statService.Text = "Service(" + serviceController1.ServiceName + ") is " + serviceController1.Status.ToString();
                }
            }
            catch (InvalidOperationException)
            {
                statService.Text = "Required service is not installed.";
            }
            finally
            {
                Cursor.Current = pCursor;
            }
        }
        
        private void btnStartService_Click(object sender, EventArgs e)
        {
            Cursor pCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (serviceController1.Status != ServiceControllerStatus.Running)
                {
                    statService.Text = "Initializing...starting required service";
                    StartService(20);
                    statService.Text = "Service(" +serviceController1.ServiceName+") is "+serviceController1.Status.ToString();
                }
            }
            catch (InvalidOperationException)
            {
                statService.Text = "Required service is not installed";
            }
            finally
            {
                Cursor.Current = pCursor;
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            sqlConnBuilder.DataSource = comboBox1.Text;
            string newSqlStrMaster = sqlConnBuilder.ConnectionString;//this is the new setting
            sqlConnBuilder.InitialCatalog = "SeeCommon";
            string newSqlStrCommon = sqlConnBuilder.ConnectionString;
            
            seeSysConfig.SqlConnStrMaster = newSqlStrMaster;//This saves the new setting
            seeSysConfig.SqlConnStrCommon = newSqlStrCommon;//This saves the new setting
       
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Server Name = " + sqlConnBuilder.DataSource);
            sb.AppendLine("Use Windows Authentication = " + sqlConnBuilder.IntegratedSecurity.ToString());
            if (!sqlConnBuilder.IntegratedSecurity)
            {
                sb.AppendLine("User = " + sqlConnBuilder.UserID);
                sb.AppendLine("Password = " + sqlConnBuilder.Password);
            }
            sb.AppendLine("");
            sb.AppendLine("Please restart service(SeeTCPIP4VSE) from Control Panel,"); 
            sb.AppendLine("or reboot machine for the new setting to take effect.");
            MessageBox.Show(sb.ToString(), "Setting Saved");
            /*statService.Text = "Restarting service...";
            Cursor pCursor = Cursor.Current;
            using (Cursor.Current = Cursors.WaitCursor)
            {
                StopService(20);
                StartService(20);
            }
            Cursor.Current = pCursor;
            */
            this.Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillSqlServerList()
        {
            comboBox1.Items.Clear();
            Cursor pCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //SqlDataSourceEnumerator is a class in .net framework that gets the available instances of SQL Server within the local network.
                /*
                 The DataTable returned as 4 colunms such as :-
                    * ServerName
                    * InstanceName
                    * IsClustered
                    * Version
                 */
                DataTable dt = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
                foreach (DataRow row in dt.Rows)
                {
                    string server = row[0].ToString();
                    string instance = row[1].ToString();
                    comboBox1.Items.Add(server + @"\" + instance);
                }
                if (this.comboBox1.Items.Count > 0)
                { this.comboBox1.SelectedIndex = 0; }
                //else
                //{ this.comboBox1.Text = "<No available SQL Servers>"; }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = pCursor;
            }
        }

        private void StartService(int sec)
        {
            try
            {
                if (serviceController1.Status == ServiceControllerStatus.Paused)
                { serviceController1.Continue(); }
                else { serviceController1.Start(); }
                serviceController1.WaitForStatus(ServiceControllerStatus.Running,
                    new TimeSpan(0, 0, sec));//Timeout after sec                
            }//catch (TimeoutException tExc)
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + Environment.NewLine + Environment.NewLine +
                    "You can attempt to start the service using the Control Panel.",
                    "SeeTCP/IP for VSE - required service failed to start", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.Exit();
            }
        }

        private void StopService(int sec)
        {
            try
            {
                serviceController1.Stop(); 
                serviceController1.WaitForStatus(ServiceControllerStatus.Stopped,
                    new TimeSpan(0, 0, sec));//Timeout after sec                
            }//catch (TimeoutException tExc)
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + Environment.NewLine + Environment.NewLine +
                    "You can attempt to stop the service using the Control Panel.",
                    "SeeTCP/IP for VSE - required service failed to stop", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }
    }
}