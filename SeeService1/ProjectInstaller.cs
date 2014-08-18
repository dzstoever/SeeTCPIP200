using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Windows.Forms;

namespace csi.see.service1
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
        private string _logName = "SeeTCPIP";
        private void ProjectInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            //Add custom log, register sources - "SeeService1" and "SeeClient1"
            try
            {
                //EventSourceCreationData eventData = new EventSourceCreationData("SeeService1", "SeeTCPIP");
                //EventLogInstaller eventInstall = new EventLogInstaller();                
                EventLog.CreateEventSource("SeeService1", _logName);
                EventLog.CreateEventSource("SeeClient1", _logName);                
                EventLog log = new EventLog(_logName);                
                log.MaximumKilobytes = 1024;
                log.ModifyOverflowPolicy(OverflowAction.OverwriteAsNeeded, 0);
                //log.RegisterDisplayName//How do I set a description for the log?
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error creating event log", 
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
        }
        private void ProjectInstaller_AfterUninstall(object sender, InstallEventArgs e)
        {
            //Deletes the file that contains the log's contents
            //Accesses the registry and removes the registration for all 
            //event sources that were registered for that log.
            try
            {
                EventLog.DeleteEventSource("SeeClient1");
                EventLog.DeleteEventSource("SeeService1");
                EventLog.Delete(_logName); 
            }
            catch (Exception exc)
            { 
                MessageBox.Show(exc.Message, "Could not remove event log",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
            
        }
    }
}