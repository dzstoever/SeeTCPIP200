using csi.see.classlib1;
using csi.see.classlib1.DataSets;
using csi.see.classlib1.DataSets.SeeCommonDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Data.SqlClient;

namespace csi.see.client1
{
    public partial class FormSystems : Form
    {
        public event StringDelegate SysAdded;
        public event StringDelegate SysDeleted;
        public event StringStringDelegate SysModified;

        public FormSystems()
        {
            InitializeComponent();
            #region Set value defaults
            seeCommonDataSet.SysDefs.DateCreatedColumn.DefaultValue = DateTime.Now;
            seeCommonDataSet.SysDefs.DbNameColumn.DefaultValue = "New";
            seeCommonDataSet.SysDefs.NameColumn.DefaultValue = "New";
            seeCommonDataSet.SysDefs.IpAddressColumn.DefaultValue = "255.255.255.255";
            seeCommonDataSet.SysDefs.PortColumn.DefaultValue = 5450;
            seeCommonDataSet.SysDefs.UserIdColumn.DefaultValue = "$SEEVSE1";
            seeCommonDataSet.SysDefs.PasswordColumn.DefaultValue = "$SEEVSE1";
            seeCommonDataSet.SysDefs.UtcOffsetColumn.DefaultValue = 0;
            seeCommonDataSet.SysDefs.StartPollTimeColumn.DefaultValue = _midnight;// Continuous
            seeCommonDataSet.SysDefs.EndPollTimeColumn.DefaultValue = _midnight;
            seeCommonDataSet.SysDefs.monOnColumn.DefaultValue = true;
            seeCommonDataSet.SysDefs.monCpuColumn.DefaultValue = true;
            seeCommonDataSet.SysDefs.monJobsColumn.DefaultValue = true;
            seeCommonDataSet.SysDefs.monIpsColumn.DefaultValue = true;
            seeCommonDataSet.SysDefs.monBSDCColumn.DefaultValue = true;
            seeCommonDataSet.SysDefs.monConnsColumn.DefaultValue = true;
            seeCommonDataSet.SysDefs.monFTPsColumn.DefaultValue = true;
            seeCommonDataSet.SysDefs.useConsoleColumn.DefaultValue = true;
            seeCommonDataSet.SysDefs.pollIntervalmsColumn.DefaultValue = 300000;//5 min 
            #endregion
            #region Set tool tips
            toolTip1.SetToolTip(nameTextBox, "Assign a unique name for each system." + Environment.NewLine +
                "The name must be 40 characters or less and can not contain special characters.");
            toolTip1.SetToolTip(ipAddressTextBox, "The IP address for the TCP/IP stack to monitor." + Environment.NewLine +
                "If you enter a domain name, it will be resolved to an IP address.");
            toolTip1.SetToolTip(portTextBox, "The port number on which the mainframe server is listening for connections. The default is 5450." + Environment.NewLine + 
                "The mainframe will use 3 sequential TCP ports for communications." + Environment.NewLine +
                "(The other two ports will be one less than this value. i.e. 5450, 5449, 5448)");
            toolTip1.SetToolTip(userIdTextBox, "The user id used to log on to the mainframe server. The default is $SEEVSE1.");
            toolTip1.SetToolTip(passwordTextBox, "The password used to log on to the mainframe server. The default is $SEEVSE1.");
            toolTip1.SetToolTip(monOnCheckBox, "Use this to start or stop monitoring the system." + Environment.NewLine +
                "This will not shutdown the mainframe server.");
            string monTip = "Monitor settings control when and how often TCP/IP data is sampled." + Environment.NewLine +
                "Poll Interval - how often to update the system information.";// +Environment.NewLine +
                //"Continuous - monitor the system 24 hours a day." + Environment.NewLine +
                //"Start/End Time - only monitor the system between these times.";
            toolTip1.SetToolTip(groupBoxMonitor, monTip);
            toolTip1.SetToolTip(dateTimePicker1, monTip);
            toolTip1.SetToolTip(panelStartEnd, monTip);
            toolTip1.SetToolTip(startPollTimeDateTimePicker1, monTip);
            toolTip1.SetToolTip(endPollTimeDateTimePicker1, monTip);
            #endregion
            #region Fill the dataset 
            SysDefsTableAdapter defsAdapter = new SysDefsTableAdapter();
            //defsAdapter.Fill(seeCommonDataSet.SysDefs);
            //if (DefsTable != null) { DefsTable = null; }
            /*This is much faster */
            SeeCommonDataSet.SysDefsDataTable DefsTable = defsAdapter.GetData();
            foreach (SeeCommonDataSet.SysDefsRow sRow in DefsTable)            
            {
                SeeCommonDataSet.SysDefsRow nwRow = seeCommonDataSet.SysDefs.NewSysDefsRow();
                nwRow.ItemArray = sRow.ItemArray;
                seeCommonDataSet.SysDefs.AddSysDefsRow(nwRow);
            }
            #endregion
            seeCommonDataSet.SysDefs.AcceptChanges();//Now all the RowStates are current
        }

        private DateTime _midnight = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        private SeeCommonDataSet.SysDefsRow CurrentDefRow
        {
            get
            {
                if (sysDefsBindingSource.Current == null)
                { return null; }
                else
                {
                    DataRowView drView = (DataRowView)sysDefsBindingSource.Current;
                    return (SeeCommonDataSet.SysDefsRow)drView.Row;
                }
            }
        }        
        
        private void SetIntervalPicker(int millaseconds)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, millaseconds);
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, 1, 1, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
        private bool IsBlankLine(string str)
        {
            bool isBlank = true;
            foreach (char ch in str.ToCharArray())
            { if (ch != ' ') { isBlank = false; } }
            return isBlank;
        }

        /// <summary>
        /// Remove leading and trailing spaces
        /// </summary>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            tbox.Text = tbox.Text.Trim();
        }                        
        private void btnChangeName_Click(object sender, EventArgs e)
        {
            nameTextBox.Visible = true;
            nameTextBox.Focus();
            nameTextBox.SelectAll();
        }        
        private void nameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (CurrentDefRow != null)
            {
                bool anyChars = false;
                #region Check for special characters
                char[] chars = nameTextBox.Text.ToCharArray();
                int chIndex = 0;
                foreach (char ch in chars)
                {
                    if (!System.Char.IsLetterOrDigit(ch) && ch != ' ')//This is not a letter, digit, or space
                    {
                        nameTextBox.Text = nameTextBox.Text.Remove(chIndex, 1);//Remove the character
                        anyChars = true;
                    }
                    else
                    { chIndex++; }
                }
                #endregion
                if (anyChars)
                {//Special characters are removed
                    errorProvider1.SetError(nameTextBox, "System names can only contain letters, digits, and spaces.");
                    e.Cancel = true;
                }
                else if (IsBlankLine(nameTextBox.Text))
                {//Reset the text
                    nameTextBox.Text = CurrentDefRow.Name;
                    nameTextBox.Focus();
                    nameTextBox.SelectAll();
                }
                else
                {
                    try
                    { sysDefsBindingSource.EndEdit(); }//Check for a duplicate name
                    catch (ConstraintException)
                    {
                        errorProvider1.SetError(nameTextBox, nameTextBox.Text + Environment.NewLine +
                            "The system already exists. You must choose a unique name.");
                        e.Cancel = true;
                    }

                }                    
            }
        }
        private void nameTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.Clear(); //clear the error
            nameTextBox.Visible = false;
            //dbNameTextBox.Text = nameTextBox.Text.Replace(' ', '_');//Assign the database name
            //If the name changes the database name will be changed on save?
        }
        private void ipAddressTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (CurrentDefRow != null)
            {
                try
                {//Is this a valid IP Address
                    IPAddress ipaddr = IPAddress.Parse(ipAddressTextBox.Text);//parse the string into an IP address
                    ipAddressTextBox.Text = ipaddr.ToString();
                    errorProvider1.Clear();//clear the error
                }
                catch (Exception)
                {
                    try
                    {//Is this a valid host domain
                        IPHostEntry iphost = Dns.GetHostEntry(ipAddressTextBox.Text);
                        IPAddress ipaddr = iphost.AddressList[0];
                        ipAddressTextBox.Text = ipaddr.ToString();
                        errorProvider1.Clear();//clear the error
                    }
                    catch (Exception exDns)
                    {
                        errorProvider1.SetError(ipAddressTextBox, exDns.Message);
                        e.Cancel = true;
                    }
                }
            }
        }
        private void portTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (CurrentDefRow != null)
            {
                try
                {
                    int portnum = Convert.ToInt32(portTextBox.Text);//convert the string to an integer
                    if (portnum < 1 || portnum > 65536)//check that it is a valid port number 
                    {
                        errorProvider1.SetError(portTextBox, "An invalid port number was specified.");//set an error
                        e.Cancel = true;
                    }
                    else
                    { errorProvider1.Clear(); }//Clear the error
                }
                catch (Exception exPort)
                {
                    errorProvider1.SetError(portTextBox, exPort.Message);
                    e.Cancel = true;
                }
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int intervalms = Convert.ToInt32(dateTimePicker1.Value.TimeOfDay.TotalMilliseconds);
            msTextBox.Text = intervalms.ToString();//This changes the value 
        }
               
        private void sysDefsBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                DialogResult result = MessageBox.Show("All data will be lost." + Environment.NewLine + "Are you sure you want to remove this system?", 
                    "Remove System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                foreach (SeeCommonDataSet.SysDefsRow defRow in seeCommonDataSet.SysDefs)
                {
                    if (defRow.RowState == DataRowState.Deleted)
                    {
                        defRow.RejectChanges();//Get the original data back
                        if (result == DialogResult.Yes)
                        {
                            SysDeleted((string)defRow["Name", DataRowVersion.Original]);//Notify the service                                                        
                            defRow.Delete();//Now delete the row
                            SysDefsTableAdapter defsAdapter = new SysDefsTableAdapter();
                            defsAdapter.Update(defRow);//Update the database            
                        }                        
                        break;
                    }
                }
                InvokeOnClick(buttonOK, new EventArgs());//Save any other changes and close
            }
            
            if (sysDefsBindingSource.List.Count > 0) 
            { groupBox1.Enabled = true; nameTextBox.Enabled = true; }
            else { groupBox1.Enabled = false; nameTextBox.Enabled = false; }            
        }
        private void sysDefsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            nameTextBox.Focus(); nameTextBox.SelectAll();
            if (CurrentDefRow != null)
            {
                if (CurrentDefRow.StartPollTime == CurrentDefRow.EndPollTime) { radioContinuous.Checked = true; }//Poll continuously
                SetIntervalPicker(CurrentDefRow.pollIntervalms);//Keep the picker in sync with the DataRow
            }
        }
       
        private void buttonOK_Click(object sender, EventArgs e)
        {
            sysDefsBindingSource.EndEdit();//Make sure changes get saved
            SysDefsTableAdapter defsAdapter = new SysDefsTableAdapter();
            //Perform database operations, and dispatch changes to the service
            foreach (SeeCommonDataSet.SysDefsRow defRow in seeCommonDataSet.SysDefs)
            {
                if (defRow.RowState == DataRowState.Added)
                {
                    defRow.DateCreated = DateTime.Now;
                    defRow.DbName = defRow.Name.Replace(' ', '_');//Set the database name
                    defsAdapter.Update(defRow);//Update the database            
                    SysAdded(defRow.Name);//Notify the service
                }                
                else if (defRow.RowState == DataRowState.Modified) 
                {
                    string origName = (string)defRow["Name", DataRowVersion.Original];
                    string currName = (string)defRow["Name", DataRowVersion.Current];
                    if (origName != currName)
                    { defRow.DbName = currName.Replace(' ', '_'); }//Update the database name                    
                    defsAdapter.Update(defRow);//Update the database            
                    SysModified(origName, currName);//Notify the service
                }
            }                        
        }

        private void radioContinuous_CheckedChanged(object sender, EventArgs e)
        {
            if (radioContinuous.Checked)
            { panelStartEnd.Enabled = false; labelContinuous.Enabled = true; }
            else
            { panelStartEnd.Enabled = true; labelContinuous.Enabled = false; }
        }

        
                                            
    }
}