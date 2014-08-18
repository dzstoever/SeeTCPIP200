using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace csi.see.classlib1
{
    public class SqlBase
    {
        public static SqlConnection BuildConnection(string dbName)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder
                (Properties.Settings.Default.sqlConnect_master);
            scsb.InitialCatalog = dbName;

            return new SqlConnection(scsb.ConnectionString);
        }

        public SqlConnection Connection
        {
            get { return _connection; }
        }
        public string ConnectionString
        { get { return _connection.ConnectionString; } }
        public string MasterConnectionString
        { get { return _connMaster.ConnectionString; } }
        public string InstanceName
        {
            get { return _connection.DataSource; }
        }
        public string DatabaseName
        {
            get { return _connection.Database; }
        }
        public string MdfFilePath
        {
            get
            {
                if (_dataPath != null)
                { return _dataPath + DatabaseName + ".mdf"; }
                else
                { return null; }
            }
        }
        public string LdfFilePath
        {
            get
            {
                if (MdfFilePath == null) { return null; }
                else { return MdfFilePath.Replace(".mdf", "_log.ldf"); }
            }
        }

        public SqlBase() { _connMaster = new SqlConnection(Properties.Settings.Default.sqlConnect_master); }
        /// <summary>
        /// This will use the sql connection string stored in the settings file
        /// </summary>
        /// <param name="dbName">replaces 'master' as the Initial Catalog</param>
        public virtual void SetDb(string dbName)
        { _connection = BuildConnection(dbName); }
        /// <summary>
        /// This will use the sql connection string stored in the settings file
        /// </summary>
        /// <param name="dbName">replaces 'master' as the Initial Catalog</param>
        /// <param name="dataPath">physical path to the .mdf file</param>
        public virtual void SetDb(string dbName, string dataPath)
        {
            _connection = BuildConnection(dbName);
            _dataPath = dataPath;
        }
        /// <summary>
        /// Uses the specified sql connection
        /// </summary>
        public virtual void SetDb(SqlConnection sqlConnection)
        {
            _connection = sqlConnection;
        }
        /// <summary>
        /// Uses the specified sql connection
        /// </summary>
        /// <param name="dataPath">physical path to the .mdf file</param>
        public virtual void SetDb(SqlConnection sqlConnection, string dataPath)
        {
            _connection = sqlConnection;
            _dataPath = dataPath;
        }

        public bool IsDbRegistered()
        {
            bool dbRegistered = false;
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand(SELECTDBNAMES, _connMaster);
            try
            {
                _connMaster.Open();
                reader = command.ExecuteReader();
                while (reader.Read())//Read each result row
                {
                    string name = reader.GetString(0);
                    if (DatabaseName == name)
                    { dbRegistered = true; }
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (_connMaster.State != ConnectionState.Closed) { _connMaster.Close(); }
            }

            return dbRegistered;
        }
        public int ExecuteNonQuery(SqlConnection connect, string commandString)
        {
            int rowsAffected = 0;
            SqlCommand command = new SqlCommand(commandString, connect);
            try
            {
                connect.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            finally
            {
                if (connect != null && connect.State != ConnectionState.Closed)
                { connect.Close(); }
            }
            return rowsAffected;
        }
        public object ExecuteScalar(SqlConnection connect, string commandString)
        {
            object scalar = null;
            SqlCommand command = new SqlCommand(commandString, connect);
            try
            {
                connect.Open();
                scalar = command.ExecuteScalar();
            }
            finally
            {
                if (connect != null && connect.State != ConnectionState.Closed)
                { connect.Close(); }
            }
            return scalar;
        }

        public int ExRenameDB(string newName)
        {
            if (IsDbRegistered())
            {
                //Must change physical name, then logical name, then database name
                string changephysicalMdf = String.Format("ALTER DATABASE " + DatabaseName + //, FILENAME = ' new_path/os_file_name ' )
                    " MODIFY FILE ( NAME = {0}, FILENAME = '{1}' )", DatabaseName + "_dat", _dataPath + newName + ".mdf");
                string changephysicalLdf = String.Format("ALTER DATABASE " + DatabaseName +
                    " MODIFY FILE ( NAME = {0}, FILENAME = '{1}' )", DatabaseName + "_log", _dataPath + newName + "_log.ldf");
                string changelogicalMdf = String.Format("ALTER DATABASE " + DatabaseName +
                    " MODIFY FILE ( NAME = {0}, NEWNAME = {1} )", DatabaseName + "_dat", newName + "_dat");
                string changelogicalLdf = String.Format("ALTER DATABASE " + DatabaseName +
                    " MODIFY FILE ( NAME = {0}, NEWNAME = {1} )", DatabaseName + "_log", newName + "_log");
                string renameDb = "ALTER DATABASE " + DatabaseName + " MODIFY NAME = " + newName;
                ExecuteNonQuery(_connMaster, changephysicalMdf);
                ExecuteNonQuery(_connMaster, changephysicalLdf);
                ExecuteNonQuery(_connMaster, changelogicalMdf);
                ExecuteNonQuery(_connMaster, changelogicalLdf);
                ExecuteNonQuery(_connMaster, renameDb);

                ExecuteNonQuery(_connMaster, DETACHDB(newName));
                //Rename the physical file, delete the old log file
                string newMdfFilePath = _dataPath + newName + ".mdf";
                //string newLdfFilePath = _dataPath + newName + ".ldf";
                File.Move(MdfFilePath, newMdfFilePath);
                File.Delete(LdfFilePath);//, newLdfFilePath);
                return ExecuteNonQuery(_connMaster, ATTACHDB(newMdfFilePath, newName));
            }
            else return -2;

        }
        public int ExDropDB()
        {
            ExecuteNonQuery(_connMaster, SETSINGLEUSERWITHROLLBACK);//Set single user
            return ExecuteNonQuery(_connMaster, DROPDB);
        }
        public int ExAttachDB()
        {
            ExecuteNonQuery(_connMaster, ATTACHDB());
            return ExecuteNonQuery(_connMaster, SETAUTOCLOSEFALSE);
        }
        public int ExAttachDB(string mdfFilePath, string ldfFilePath, string dbName)
        {
            string createForAttach = String.Format("CREATE DATABASE {0} ON (FILENAME = '{1}') " //, dbName,mdfFilePath);
                 + "LOG ON (FILENAME = '{2}') FOR ATTACH",dbName ,mdfFilePath, ldfFilePath);            
            ExecuteNonQuery(_connMaster, createForAttach);
            //string sp_changedbowner = @"EXEC sp_changedbowner @loginame='.\Administrator', @map=false";
            //ExecuteNonQuery(_connMaster, sp_changedbowner);
            /*
            ExecuteNonQuery(_connMaster, ATTACHDB(mdfFilePath, dbName));
            string changephysicalMdf = String.Format("ALTER DATABASE {0} MODIFY FILE ( NAME = {1}, FILENAME = '{2}' )", dbName, dbName+"_dat", mdfFilePath);
            string changephysicalLdf = String.Format("ALTER DATABASE {0} MODIFY FILE ( NAME = {1}, FILENAME = '{2}' )", dbName, dbName+"_log", ldfFilePath);
            ExecuteNonQuery(_connMaster, changephysicalMdf);
            ExecuteNonQuery(_connMaster, changephysicalLdf);*/
            
            return ExecuteNonQuery(_connMaster, SETAUTOCLOSEFALSE);
        }
        public int ExDetachDB()
        {
            if (IsDbRegistered())
            { return ExecuteNonQuery(_connMaster, DETACHDB()); }
            else return -2;
        }
        public int ExDropTable(string tblName)
        {
            return ExecuteNonQuery(_connection, DROPTABLE(tblName));
        }
        public int ExAddColumn(string dbName, string tblName, string colName, Type type, int length)
        {
            return ExecuteNonQuery(_connection, ALTERADDCOLUMN(tblName, colName, type, length));
        }
        public int ExDropColumn(string dbName, string tblName, string colName)
        {
            return ExecuteNonQuery(_connection, ALTERDROPCOLUMN(tblName, colName));
        }
        public virtual int ExCreateDB()
        {
            ExecuteNonQuery(_connMaster, CREATEDB);
            return ExecuteNonQuery(_connMaster, SETAUTOCLOSEFALSE);
        }       

        private SqlConnection _connMaster;
        private SqlConnection _connection;
        private string _dataPath = null;

        //private string RENAMEDB(string newName)
        //{ return String.Format("EXEC sp_renamedb '{0}', '{1}'", DatabaseName, newName); }
        private string SETAUTOCLOSEFALSE
        { get { return @"EXEC sp_dboption '" + DatabaseName + @"', 'autoclose', 'false'"; } }
        private string CREATEDB
        {
            get
            {
                if (_dataPath == null)
                { return String.Format("CREATE DATABASE {0}", DatabaseName); }
                else
                {
                    return String.Format("CREATE DATABASE {0} " +
                        "ON ( NAME = '{1}'," + @"FILENAME = '{2}') " +
                        "LOG ON ( NAME = '{3}'," + @"FILENAME = '{4}')",
                        DatabaseName,
                        DatabaseName + "_dat", MdfFilePath, //Logical Name, Physical Path
                        DatabaseName + "_log", LdfFilePath);//Logical Name, Physical Path
                }
                /*
                return String.Format("CREATE DATABASE {0} " +
                    "ON ( NAME = '{1}'," +
                    @"FILENAME = '{2}') " +
                    "LOG ON ( NAME = '{3}'," +
                    @"FILENAME = '{4}')",
                    _dbName, _dbName + "_dat", _dbDataPath, _dbName + "_log", _dbLogPath);
                 */
            }
        }
        private string SETSINGLEUSERWITHROLLBACK
        { get { return "ALTER DATABASE " + DatabaseName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE"; } }
        private string DROPDB
        { get { return String.Format("DROP DATABASE {0}", DatabaseName); } }
        private string ATTACHDB()
        {
            return String.Format("EXEC sp_attach_single_file_db @dbname='{0}', @physname='{1}'",
                    DatabaseName, MdfFilePath);
        }
        private string ATTACHDB(string mdfFilePath, string newName)
        {
            return String.Format("EXEC sp_attach_single_file_db @dbname='{0}', @physname='{1}'",
                    newName, mdfFilePath);
        }
        private string DETACHDB()
        { return String.Format("EXEC sp_detach_db '{0}'", DatabaseName); }
        private string DETACHDB(string dbName)
        { return String.Format("EXEC sp_detach_db '{0}'", dbName); }
        private string DROPTABLE(string tblName)
        { return String.Format("DROP TABLE {0}", tblName); }
        /// <summary>
        ///  Use to add a missing column to an existing table
        /// </summary>
        /// <param name="tablename">database table name</param>
        /// <param name="columnname">missing column name</param>
        /// <param name="type">missing column data type - will convert to an sql type string</param>
        /// <param name="length">the varchar(len) to use if it is a string</param></param>
        /// <returns>Sql command string to add the new column to the table</returns>
        private string ALTERADDCOLUMN(string tblName, string colName, Type type, int length)
        {
            string datatype;
            if (type == Type.GetType("System.DateTime"))
            { datatype = "datetime"; }
            else if (type == Type.GetType("System.String"))
            { datatype = "varchar(" + length.ToString() + ")"; }
            else if (type == Type.GetType("System.Boolean"))
            { datatype = "bit"; }
            else//This must me a number - Store as float
            { datatype = "float"; }

            return String.Format("ALTER TABLE {0} ADD COLUMN {1} {2}", tblName, colName, datatype);
        }
        private string ALTERDROPCOLUMN(string tblName, string colName)
        {
            return String.Format("ALTER TABLE {0} DROP COLUMN {1}", tblName, colName);
        }

        private string SELECTDBNAMES
        { get { return "SELECT name FROM sysdatabases"; } }
        private string SELECTFILEPATH
        {
            get
            {
                return String.Format("SELECT filename FROM sysdatabases WHERE (name = {0})", DatabaseName);
                //string dbPath = (string)sql_SELECTFileName.ExecuteScalar();
            }
        }
    }
}
