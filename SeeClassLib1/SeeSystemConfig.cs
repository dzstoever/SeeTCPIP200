using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.AccessControl;

namespace csi.see.classlib1
{
    public class SeeSystemConfig
    {
        
        public SeeSystemConfig(){ 
        }
        /*The following properties are placeholders as there is no reference
         * to the projects containing the settings */
        public int UdpPort1
        {
            get { return 0; }
            set { }
        }
        public int UdpPort2
        {
            get { return 0; }
            set { }
        }
        public string DbDirectory{
            get { return ""; }
            set { }
        }
        public string PcapDirectory{
            get { return ""; }
            set { }
        }
        
        /*The sql connection strings can be modified here */
        public string SqlConnStrMaster{
            get { return Properties.Settings.Default.sqlConnect_master; }
            set { Properties.Settings.Default.sqlConnect_master = value;
                    Properties.Settings.Default.Save();}
        }
        public string SqlConnStrCommon{
            get { return Properties.Settings.Default.sqlConnect_common; }
            set { Properties.Settings.Default.sqlConnect_common = value;
                    Properties.Settings.Default.Save();}
        }

        public static bool GrantModifyAccessToFolder(string windowsAccountUserName, string folderName)
        {
            DirectoryInfo directory = null;
            DirectorySecurity directorySecurity = null;
            FileSystemAccessRule rule = null;

            try
            {

                if (windowsAccountUserName.Length < 1) { return false; }
                if (folderName.Length < 1) { return false; }
                if (!Directory.Exists(folderName)) { return false; }

                directory = new DirectoryInfo(folderName);

                directorySecurity = directory.GetAccessControl();

                rule = new FileSystemAccessRule(windowsAccountUserName,
                                                FileSystemRights.Modify,
                                                InheritanceFlags.None |
                                                InheritanceFlags.ContainerInherit |
                                                InheritanceFlags.ObjectInherit,
                                                PropagationFlags.None,
                                                AccessControlType.Allow);

                directorySecurity.SetAccessRule(rule);

                directory.SetAccessControl(directorySecurity);

                return true;

            }
            catch (Exception)
            { throw; }
        }
        
        /* Implemented in FormConfig
        public bool CheckForSqlServers(out string message)
        {
            bool result = false;
            message = "success";
            try
            {
                result = true;
            }
            catch(Exception exc)
            {
                message = exc.Message; 
            }
            return result;
        }

        public bool CheckForSqlConnection(out string message)
        {
            bool result = false;
            message = "success";
            try
            {
                result = true;
            }
            catch (Exception exc)
            {
                message = exc.Message;
            }
            return result;
        }
        */

    }

   
}
