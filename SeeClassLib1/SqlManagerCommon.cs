using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace csi.see.classlib1
{
    public class SqlManagerCommon : SqlBase
    {
        public string BaseTableNameDefs = "SysDefs";
        public string BaseTableNameMess = "Messages";
        public string BaseTableNameComm = "Commands";
        public string BaseTableNamePara = "Parameters";
        public string BaseTableNameNote = "Notes";
        public string BaseTableNameExpo = "Expositions";

        public void AddTablesAll(string release)
        {
            ExecuteNonQuery(Connection, CREATETABLE_Defs);
            ExecuteNonQuery(Connection, CREATETABLE_Comm(release));
            ExecuteNonQuery(Connection, CREATEINDEX_CommFamily(release));
            ExecuteNonQuery(Connection, CREATEINDEX_CommShortcut(release));
            ExecuteNonQuery(Connection, CREATETABLE_Note(release));
            ExecuteNonQuery(Connection, CREATETABLE_Expo(release));
            ExecuteNonQuery(Connection, CREATETABLE_Para(release));
            ExecuteNonQuery(Connection, CREATEINDEX_ParaName(release));
            ExecuteNonQuery(Connection, CREATEINDEX_ParaShortcut(release));
            ExecuteNonQuery(Connection, CREATETABLE_Mess(release));
            ExecuteNonQuery(Connection, CREATEINDEX_MessFamily(release));
        }
        public void AddTable_Defs()
        { ExecuteNonQuery(Connection, CREATETABLE_Defs); }
        public void AddTable_Messages(string release)
        {
            ExecuteNonQuery(Connection, CREATETABLE_Mess(release));
            ExecuteNonQuery(Connection, CREATEINDEX_MessFamily(release));
        }
        public void AddTable_Commands(string release)
        {
            ExecuteNonQuery(Connection, CREATETABLE_Comm(release));
            ExecuteNonQuery(Connection, CREATEINDEX_CommFamily(release));
            ExecuteNonQuery(Connection, CREATEINDEX_CommShortcut(release));
        }
        public void AddTable_Parameters(string release)
        {
            ExecuteNonQuery(Connection, CREATETABLE_Para(release));
            ExecuteNonQuery(Connection, CREATEINDEX_ParaName(release));
            ExecuteNonQuery(Connection, CREATEINDEX_ParaShortcut(release));
        }
        public void AddTable_Notes(string release)
        { ExecuteNonQuery(Connection, CREATETABLE_Note(release)); }
        public void AddTable_Expositions(string release)
        { ExecuteNonQuery(Connection, CREATETABLE_Expo(release)); }
        #region Create Table Sql Statements
        public string CREATETABLE_Defs
        {
            get
            {
                StringBuilder sb = new StringBuilder("CREATE TABLE ");
                //Set the table name
                sb.Append(BaseTableNameDefs + "(");
                //Add columns
                sb.Append("DateCreated	    datetime, ");
                sb.Append("Name	            varchar(40), ");
                sb.Append("DbName		    varchar(45), ");
                sb.Append("IpAddress	    varchar(15), ");
                sb.Append("Port			    int, ");
                sb.Append("UserId		    varchar(20), ");
                sb.Append("Password		    varchar(20), ");
                sb.Append("UtcOffset	    int, ");
                sb.Append("StartPollTime	datetime, ");
                sb.Append("EndPollTime	    datetime, ");
                sb.Append("monOn		    bit, ");
                sb.Append("monCpu		    bit, ");
                sb.Append("monJobs		    bit, ");
                sb.Append("monIps		    bit, ");
                sb.Append("monBSDC		    bit, ");
                sb.Append("monConns		    bit, ");
                sb.Append("monFTPs		    bit, ");
                sb.Append("useConsole		bit, ");
                sb.Append("pollIntervalms	int, ");
                //Set the primary Key
                sb.Append("CONSTRAINT primkey PRIMARY KEY (Name));");

                return sb.ToString();
            }
        }
        public string CREATETABLE_Mess(string TcpIpRelease)
        {
            StringBuilder sb = new StringBuilder("CREATE TABLE ");
            //Set the table name
            sb.Append(BaseTableNameMess + TcpIpRelease + "(");
            //Add columns
            sb.Append("Name			    char(7) CONSTRAINT mcon1_" + TcpIpRelease + " NOT NULL, ");
            sb.Append("Family		    varchar(3) CONSTRAINT mcon2_" + TcpIpRelease + " NOT NULL, ");
            sb.Append("Summary		    varchar(512) CONSTRAINT mcon3_" + TcpIpRelease + " NOT NULL, ");
            sb.Append("Detail		    varchar(2048), ");
            sb.Append("AdminAction		varchar(1024), ");
            sb.Append("OperatorAction	varchar(1024), ");
            sb.Append("SystemAction		varchar(1024), ");
            //Set the primary Key
            sb.Append("CONSTRAINT mprim_" + TcpIpRelease + " PRIMARY KEY (Name));");

            return sb.ToString();
        }
        public string CREATEINDEX_MessFamily(string TcpIpRelease)
        {
            StringBuilder sb = new StringBuilder("CREATE INDEX mind1_" + TcpIpRelease + " ON ");
            //Set the table and column name
            sb.Append(BaseTableNameMess + TcpIpRelease + "(Family);");

            return sb.ToString();
        }
        public string CREATETABLE_Comm(string TcpIpRelease)
        {
            StringBuilder sb = new StringBuilder("CREATE TABLE ");
            //Set the table name
            sb.Append(BaseTableNameComm + TcpIpRelease + "(");
            //Add columns
            sb.Append("Name			varchar(32), ");
            sb.Append("Family		varchar(32), ");
            sb.Append("Shortcut		varchar(16), ");
            sb.Append("Syntax		varchar(4096), ");
            sb.Append("Description	varchar(4096), ");
            sb.Append("Example		varchar(4096), ");
            sb.Append("Related		varchar(4096), ");
            sb.Append("Deprecated	bit, ");
            //Set the primary Key
            sb.Append("CONSTRAINT cprim_" + TcpIpRelease + " PRIMARY KEY (Name));");

            return sb.ToString();
        }
        public string CREATEINDEX_CommFamily(string TcpIpRelease)
        {
            StringBuilder sb = new StringBuilder("CREATE INDEX cind1_" + TcpIpRelease + " ON ");
            //Set the table and column name
            sb.Append(BaseTableNameComm + TcpIpRelease + "(Family);");

            return sb.ToString();
        }
        public string CREATEINDEX_CommShortcut(string TcpIpRelease)
        {
            StringBuilder sb = new StringBuilder("CREATE INDEX cind2_" + TcpIpRelease + " ON ");
            //Set the table and column name
            sb.Append(BaseTableNameComm + TcpIpRelease + "(Shortcut);");

            return sb.ToString();
        }
        public string CREATETABLE_Note(string TcpIpRelease)
        {
            StringBuilder sb = new StringBuilder("CREATE TABLE ");
            //Set the table name
            sb.Append(BaseTableNameNote + TcpIpRelease + "(");
            //Add columns
            sb.Append("ID		        int identity(0,1), ");
            sb.Append("CommandName		varchar(32), ");
            sb.Append("Note		        varchar(4096), ");
            sb.Append("CONSTRAINT pprimN_" + TcpIpRelease + " PRIMARY KEY (ID, CommandName), ");
            sb.Append("CONSTRAINT pforgnN_" + TcpIpRelease + " FOREIGN KEY (CommandName) REFERENCES "
                + BaseTableNameComm + TcpIpRelease + "(Name));");

            return sb.ToString();
        }
        public string CREATETABLE_Expo(string TcpIpRelease)
        {
            StringBuilder sb = new StringBuilder("CREATE TABLE ");
            //Set the table name
            sb.Append(BaseTableNameExpo + TcpIpRelease + "(");
            //Add columns
            sb.Append("ID		        int identity(0,1), ");
            sb.Append("CommandName		varchar(32), ");
            sb.Append("Exposition		varchar(4096), ");
            sb.Append("CONSTRAINT pprimE_" + TcpIpRelease + " PRIMARY KEY (ID, CommandName), ");
            sb.Append("CONSTRAINT pforgnE_" + TcpIpRelease + " FOREIGN KEY (CommandName) REFERENCES "
                + BaseTableNameComm + TcpIpRelease + "(Name));");

            return sb.ToString();
        }
        public string CREATETABLE_Para(string TcpIpRelease)
        {
            StringBuilder sb = new StringBuilder("CREATE TABLE ");
            //Set the table name
            sb.Append(BaseTableNamePara + TcpIpRelease + "(");
            //Add columns
            sb.Append("CommandName		varchar(32), ");
            sb.Append("Name				varchar(32) CONSTRAINT pcon1_" + TcpIpRelease + " NOT NULL, ");
            sb.Append("Shortcut			varchar(16), ");
            sb.Append("Required			bit, ");
            sb.Append("Assigned			bit, ");
            sb.Append("Keyword			bit, ");
            sb.Append("Delimited		bit, ");
            sb.Append("Constraints		varchar(512), ");
            sb.Append("DefaultValue		varchar(64), ");
            sb.Append("Description		varchar(4096), ");
            //Set the foreign Key
            sb.Append("CONSTRAINT pprim_" + TcpIpRelease + " PRIMARY KEY (CommandName, Name), ");
            sb.Append("CONSTRAINT pforgn_" + TcpIpRelease + " FOREIGN KEY (CommandName) REFERENCES "
                + BaseTableNameComm + TcpIpRelease + "(Name));");

            return sb.ToString();
        }
        public string CREATEINDEX_ParaName(string TcpIpRelease)
        {
            StringBuilder sb = new StringBuilder("CREATE INDEX pind1_" + TcpIpRelease + " ON ");
            //Set the table and column name
            sb.Append(BaseTableNamePara + TcpIpRelease + "(Name);");

            return sb.ToString();
        }
        public string CREATEINDEX_ParaShortcut(string TcpIpRelease)
        {
            StringBuilder sb = new StringBuilder("CREATE INDEX mind1_" + TcpIpRelease + " ON ");
            //Set the table and column name
            sb.Append(BaseTableNamePara + TcpIpRelease + "(Shortcut);");

            return sb.ToString();
        }
        #endregion
        
    }
}
