using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;
using csi.see.classlib1;
using csi.see.classlib1.DataSets;

namespace csi.see.client1
{
	/// <summary>
	/// Summary description for AConsoleRecords.
	/// </summary>
	public class AConsoleRecords : System.ComponentModel.Component
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AConsoleRecords(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public AConsoleRecords()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		public virtual void SetDbName(string dbname)
		{
			Debug.WriteLine("AConsoleRecords.SetDbName...Not Implemented.");
		}
		public virtual int GetLastId()
		{
			Debug.WriteLine("AConsoleRecords.GetLastId...Not Implemented.");
			return 0;
		}
	}

    public class ConsoleStartupRecords : AConsoleRecords
    {
        VseDbDataSet.Startup_RecordsDataTable _table =
            new VseDbDataSet.Startup_RecordsDataTable();
        #region SqlClient
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlCommandLastID;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private System.Data.SqlClient.SqlCommand sqlSELECTbyID;
        private System.Data.SqlClient.SqlCommand sqlSELECTbyDT;
        private System.Data.SqlClient.SqlCommand sqlCommandMinDT;
        private System.Data.SqlClient.SqlCommand sqlCommandMaxDT;
        #endregion
        private System.Data.SqlClient.SqlConnection sqlConnection2;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ConsoleStartupRecords(System.ComponentModel.IContainer container)
        {
            ///
            /// Required for Windows.Forms Class Composition Designer support
            ///
            container.Add(this);
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ConsoleStartupRecords()
        {
            ///
            /// Required for Windows.Forms Class Composition Designer support
            ///
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlCommandLastID = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSELECTbyID = new System.Data.SqlClient.SqlCommand();
            this.sqlSELECTbyDT = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandMinDT = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandMaxDT = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "workstation id=DANSDELL;packet size=4096;integrated security=SSPI;data source=\"DA" +
                "NSDELL\\SEEVSE\";persist security info=True;initial catalog=VseDb";
            // 
            // sqlCommandLastID
            // 
            this.sqlCommandLastID.CommandText = "SELECT MAX(Record_ID) AS Expr1 FROM Startup_Records";
            this.sqlCommandLastID.Connection = this.sqlConnection1;
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT Record_ID, Start_Time, Cpu_ID, Program_ID, Program_Version FROM Startup_Re" +
                "cords WHERE (Record_ID >= @FirstID AND Record_ID <= @LastID)";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FirstID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = @"INSERT INTO Startup_Records(Start_Time, Cpu_ID, Program_ID, Program_Version) VALUES (@Start_Time, @Cpu_ID, @Program_ID, @Program_Version); SELECT Record_ID, Start_Time, Cpu_ID, Program_ID, Program_Version FROM Startup_Records WHERE (Program_ID = @Program_ID) AND (Record_ID = @@IDENTITY) AND (Start_Time = @Start_Time)";
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Start_Time", System.Data.SqlDbType.DateTime, 8, "Start_Time"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cpu_ID", System.Data.SqlDbType.VarChar, 17, "Cpu_ID"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Program_ID", System.Data.SqlDbType.VarChar, 8, "Program_ID"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Program_Version", System.Data.SqlDbType.VarChar, 8, "Program_Version"));
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = @"UPDATE Startup_Records SET Start_Time = @Start_Time, Cpu_ID = @Cpu_ID, Program_ID = @Program_ID, Program_Version = @Program_Version WHERE (Program_ID = @Original_Program_ID) AND (Record_ID = @Original_Record_ID) AND (Start_Time = @Original_Start_Time) AND (Cpu_ID = @Original_Cpu_ID OR @Original_Cpu_ID IS NULL AND Cpu_ID IS NULL) AND (Program_Version = @Original_Program_Version OR @Original_Program_Version IS NULL AND Program_Version IS NULL); SELECT Record_ID, Start_Time, Cpu_ID, Program_ID, Program_Version FROM Startup_Records WHERE (Program_ID = @Program_ID) AND (Record_ID = @Record_ID) AND (Start_Time = @Start_Time)";
            this.sqlUpdateCommand1.Connection = this.sqlConnection2;
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Start_Time", System.Data.SqlDbType.DateTime, 8, "Start_Time"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cpu_ID", System.Data.SqlDbType.VarChar, 17, "Cpu_ID"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Program_ID", System.Data.SqlDbType.VarChar, 8, "Program_ID"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Program_Version", System.Data.SqlDbType.VarChar, 8, "Program_Version"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Program_ID", System.Data.SqlDbType.VarChar, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Program_ID", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Record_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Record_ID", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Start_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Start_Time", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cpu_ID", System.Data.SqlDbType.VarChar, 17, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cpu_ID", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Program_Version", System.Data.SqlDbType.VarChar, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Program_Version", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Record_ID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = @"DELETE FROM Startup_Records WHERE (Program_ID = @Original_Program_ID) AND (Record_ID = @Original_Record_ID) AND (Start_Time = @Original_Start_Time) AND (Cpu_ID = @Original_Cpu_ID OR @Original_Cpu_ID IS NULL AND Cpu_ID IS NULL) AND (Program_Version = @Original_Program_Version OR @Original_Program_Version IS NULL AND Program_Version IS NULL)";
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Program_ID", System.Data.SqlDbType.VarChar, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Program_ID", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Record_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Record_ID", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Start_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Start_Time", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cpu_ID", System.Data.SqlDbType.VarChar, 17, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cpu_ID", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Program_Version", System.Data.SqlDbType.VarChar, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Program_Version", System.Data.DataRowVersion.Original, null));
            // 
            // sqlDataAdapter1
            // 
            this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Startup_Records", new System.Data.Common.DataColumnMapping[] {
																																																						 new System.Data.Common.DataColumnMapping("Record_ID", "Record_ID"),
																																																						 new System.Data.Common.DataColumnMapping("Start_Time", "Start_Time"),
																																																						 new System.Data.Common.DataColumnMapping("Cpu_ID", "Cpu_ID"),
																																																						 new System.Data.Common.DataColumnMapping("Program_ID", "Program_ID"),
																																																						 new System.Data.Common.DataColumnMapping("Program_Version", "Program_Version")})});
            this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlSELECTbyID
            // 
            this.sqlSELECTbyID.CommandText = "SELECT Startup_Records.* FROM Startup_Records WHERE (Record_ID >= @FirstID) AND (" +
                "Record_ID <= @LastID)";
            this.sqlSELECTbyID.Connection = this.sqlConnection1;
            this.sqlSELECTbyID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FirstID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            this.sqlSELECTbyID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            // 
            // sqlSELECTbyDT
            // 
            this.sqlSELECTbyDT.CommandText = "SELECT Startup_Records.* FROM Startup_Records WHERE (Start_Time >= @StartTime AND" +
                " Start_Time <= @EndTime)";
            this.sqlSELECTbyDT.Connection = this.sqlConnection1;
            this.sqlSELECTbyDT.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartTime", System.Data.SqlDbType.DateTime, 8, "Start_Time"));
            this.sqlSELECTbyDT.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndTime", System.Data.SqlDbType.DateTime, 8, "Start_Time"));
            // 
            // sqlCommandMinDT
            // 
            this.sqlCommandMinDT.CommandText = "SELECT MIN(Start_Time) AS Expr1 FROM Startup_Records";
            this.sqlCommandMinDT.Connection = this.sqlConnection1;
            // 
            // sqlCommandMaxDT
            // 
            this.sqlCommandMaxDT.CommandText = "SELECT MAX(Start_Time) AS Expr1 FROM Startup_Records";
            this.sqlCommandMaxDT.Connection = this.sqlConnection1;
            // 
            // sqlConnection2
            // 
            this.sqlConnection2.ConnectionString = "workstation id=DANSDELL;packet size=4096;integrated security=SSPI;data source=\"DA" +
                "NSDELL\\SEEVSE\";persist security info=True;initial catalog=VseDb";

        }
        #endregion

        public override void SetDbName(string dbname)
        {
            //SqlStrings sqlStr = new SqlStrings(dbname);
            sqlConnection1.ConnectionString = SqlManagerSystem.BuildConnection(dbname).ConnectionString;
            sqlConnection2.ConnectionString = SqlManagerSystem.BuildConnection(dbname).ConnectionString;
            _table.Columns["Record_ID"].AutoIncrementSeed = GetLastId() + 1;
        }


        public override int GetLastId()
        {
            int LastId = 0;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                object obj = sqlCommandLastID.ExecuteScalar();
                if (obj != System.DBNull.Value)
                { LastId = (int)obj; }
            }
            catch (System.NullReferenceException nullExc)
            {
                Debug.WriteLine(nullExc.ToString());
                return 0;
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }
            return LastId;
        }

        public VseDbDataSet.Startup_RecordsDataTable GetIdRange(int firstId, int lastId)
        {
            VseDbDataSet.Startup_RecordsDataTable startTable = new VseDbDataSet.Startup_RecordsDataTable();
            sqlSELECTbyID.Parameters["@FirstID"].Value = firstId;
            sqlSELECTbyID.Parameters["@LastID"].Value = lastId;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                sqlDataAdapter1.SelectCommand = sqlSELECTbyID;
                sqlDataAdapter1.Fill(startTable);
                sqlDataAdapter1.SelectCommand = sqlSelectCommand1;
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }
            return startTable;
        }

        /// <summary>
        /// Must call this before GetMaxDT()
        /// </summary>
        /// <returns></returns>
        public DateTime GetMinDT()
        {
            DateTime DT = System.Windows.Forms.DateTimePicker.MinDateTime;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                object obj = sqlCommandMinDT.ExecuteScalar();
                if (obj != System.DBNull.Value)
                { DT = (DateTime)obj; }
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }
            return DT;
        }

        public DateTime GetMaxDT()
        {
            DateTime DT = System.Windows.Forms.DateTimePicker.MaxDateTime;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                object obj = sqlCommandMaxDT.ExecuteScalar();
                if (obj != System.DBNull.Value)
                { DT = (DateTime)obj; }
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }
            return DT;
        }

        public void GetDateRange(DateTime firstTime, DateTime lastTime, VseDbDataSet dset)
        {
            using (Cursor pCursor = Cursor.Current)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    System.Threading.Monitor.Enter(sqlDataAdapter1);//Lock the sqlconnection
                    sqlSELECTbyDT.Parameters["@StartTime"].Value = firstTime;
                    sqlSELECTbyDT.Parameters["@EndTime"].Value = lastTime;

                    sqlDataAdapter1.SelectCommand = sqlSELECTbyDT;
                    sqlDataAdapter1.Fill(dset);
                    sqlDataAdapter1.SelectCommand = sqlSelectCommand1;
                }
                finally
                {
                    if (sqlConnection1.State != ConnectionState.Closed)
                    { sqlConnection1.Close(); }
                    System.Threading.Monitor.Exit(sqlDataAdapter1);//Unlock the sqlconnection
                    Cursor.Current = pCursor;
                }
            }

        }


        public void AddRecord(VseDbDataSet.Startup_RecordsRow startRow)
        {
            try
            {
                VseDbDataSet.Startup_RecordsRow row = _table.NewStartup_RecordsRow();
                row.ItemArray = startRow.ItemArray;//Copy the values	
                _table.AddStartup_RecordsRow(row);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
                throw;//rethrow the same exception
            }
        }

        public void UpdateDb()
        {
            try
            {
                System.Threading.Monitor.Enter(sqlDataAdapter1);//Lock the dataadapter
                if (sqlConnection2.State == ConnectionState.Closed)
                { sqlConnection2.Open(); }

                sqlDataAdapter1.Update(_table);
                _table.Rows.Clear();

            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
                throw;//rethrow the same exception
            }
            finally
            {
                if (sqlConnection2.State != ConnectionState.Closed)
                { sqlConnection2.Close(); }
                System.Threading.Monitor.Exit(sqlDataAdapter1);//Unlock the dataadapter
            }
        }

    }

    public class ConsoleConnectionRecords : AConsoleRecords
    {
        VseDbDataSet.Connection_RecordsDataTable _table =
            new VseDbDataSet.Connection_RecordsDataTable();
        #region SqlClient
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlCommandLastID;
        private System.Data.SqlClient.SqlCommand sqlSELECTbyID;
        private System.Data.SqlClient.SqlCommand sqlSELECTbyDT;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private System.Data.SqlClient.SqlCommand sqlCommandMinDT;
        private System.Data.SqlClient.SqlCommand sqlCommandMaxDT;
        #endregion
        private System.Data.SqlClient.SqlConnection sqlConnection2;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ConsoleConnectionRecords(System.ComponentModel.IContainer container)
        {
            ///
            /// Required for Windows.Forms Class Composition Designer support
            ///
            container.Add(this);
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ConsoleConnectionRecords()
        {
            ///
            /// Required for Windows.Forms Class Composition Designer support
            ///
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlCommandLastID = new System.Data.SqlClient.SqlCommand();
            this.sqlSELECTbyID = new System.Data.SqlClient.SqlCommand();
            this.sqlSELECTbyDT = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommandMinDT = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandMaxDT = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "workstation id=DANSDELL;packet size=4096;integrated security=SSPI;data source=\"DA" +
                "NSDELL\\SEEVSE\";persist security info=True;initial catalog=VseDb";
            // 
            // sqlCommandLastID
            // 
            this.sqlCommandLastID.CommandText = "SELECT MAX(Record_ID) AS Expr1 FROM Connection_Records";
            this.sqlCommandLastID.Connection = this.sqlConnection1;
            // 
            // sqlSELECTbyID
            // 
            this.sqlSELECTbyID.CommandText = "SELECT Connection_Records.* FROM Connection_Records WHERE (Record_ID <= @LastID) " +
                "AND (Record_ID >= @FirstID)";
            this.sqlSELECTbyID.Connection = this.sqlConnection1;
            this.sqlSELECTbyID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            this.sqlSELECTbyID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FirstID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            // 
            // sqlSELECTbyDT
            // 
            this.sqlSELECTbyDT.CommandText = "SELECT Connection_Records.* FROM Connection_Records WHERE (Conn_End_Time >= @Star" +
                "tTime) AND (Conn_End_Time <= @EndTime)";
            this.sqlSELECTbyDT.Connection = this.sqlConnection1;
            this.sqlSELECTbyDT.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartTime", System.Data.SqlDbType.DateTime, 8, "Conn_End_Time"));
            this.sqlSELECTbyDT.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndTime", System.Data.SqlDbType.DateTime, 8, "Conn_End_Time"));
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = @"SELECT Record_ID, Conn_PID, Local_Port, Foreign_Port, Foreign_IP, Conn_Start_Time, Conn_End_Time, INT_EXT, Conn_State, Conn_Protocol, Highest_Depth, Max_Send_Window, Max_Recv_Window, Recv_Window_Closed, SWS_Count, Inbound_Data, Inbound_Bytes, Inbound_Data_Dup, Inbound_Bytes_Dup, Inbound_Eff, Outbound_Data, Outbound_Bytes, Outbound_Data_Retr, Outbound_Bytes_Retr, Outbound_Eff, Recvs_Issued, Sends_Issued, Retransmits, In_Retr_Mode FROM Connection_Records";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = "INSERT INTO Connection_Records(Conn_PID, Local_Port, Foreign_Port, Foreign_IP, Co" +
                "nn_Start_Time, Conn_End_Time, INT_EXT, Conn_State, Conn_Protocol, Highest_Depth," +
                " Max_Send_Window, Max_Recv_Window, Recv_Window_Closed, SWS_Count, Inbound_Data, " +
                "Inbound_Bytes, Inbound_Data_Dup, Inbound_Bytes_Dup, Inbound_Eff, Outbound_Data, " +
                "Outbound_Bytes, Outbound_Data_Retr, Outbound_Bytes_Retr, Outbound_Eff, Recvs_Iss" +
                "ued, Sends_Issued, Retransmits, In_Retr_Mode) VALUES (@Conn_PID, @Local_Port, @F" +
                "oreign_Port, @Foreign_IP, @Conn_Start_Time, @Conn_End_Time, @INT_EXT, @Conn_Stat" +
                "e, @Conn_Protocol, @Highest_Depth, @Max_Send_Window, @Max_Recv_Window, @Recv_Win" +
                "dow_Closed, @SWS_Count, @Inbound_Data, @Inbound_Bytes, @Inbound_Data_Dup, @Inbou" +
                "nd_Bytes_Dup, @Inbound_Eff, @Outbound_Data, @Outbound_Bytes, @Outbound_Data_Retr" +
                ", @Outbound_Bytes_Retr, @Outbound_Eff, @Recvs_Issued, @Sends_Issued, @Retransmit" +
                "s, @In_Retr_Mode); SELECT Record_ID, Conn_PID, Local_Port, Foreign_Port, Foreign" +
                "_IP, Conn_Start_Time, Conn_End_Time, INT_EXT, Conn_State, Conn_Protocol, Highest" +
                "_Depth, Max_Send_Window, Max_Recv_Window, Recv_Window_Closed, SWS_Count, Inbound" +
                "_Data, Inbound_Bytes, Inbound_Data_Dup, Inbound_Bytes_Dup, Inbound_Eff, Outbound" +
                "_Data, Outbound_Bytes, Outbound_Data_Retr, Outbound_Bytes_Retr, Outbound_Eff, Re" +
                "cvs_Issued, Sends_Issued, Retransmits, In_Retr_Mode FROM Connection_Records WHER" +
                "E (Conn_End_Time = @Conn_End_Time) AND (Conn_Start_Time = @Conn_Start_Time) AND " +
                "(Foreign_IP = @Foreign_IP) AND (Foreign_Port = @Foreign_Port) AND (Local_Port = " +
                "@Local_Port) AND (Record_ID = @@IDENTITY)";
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Conn_PID", System.Data.SqlDbType.VarChar, 2, "Conn_PID"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Local_Port", System.Data.SqlDbType.Float, 8, "Local_Port"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Foreign_Port", System.Data.SqlDbType.Float, 8, "Foreign_Port"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Foreign_IP", System.Data.SqlDbType.VarChar, 15, "Foreign_IP"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Conn_Start_Time", System.Data.SqlDbType.DateTime, 8, "Conn_Start_Time"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Conn_End_Time", System.Data.SqlDbType.DateTime, 8, "Conn_End_Time"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@INT_EXT", System.Data.SqlDbType.VarChar, 3, "INT_EXT"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Conn_State", System.Data.SqlDbType.VarChar, 12, "Conn_State"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Conn_Protocol", System.Data.SqlDbType.VarChar, 8, "Conn_Protocol"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Highest_Depth", System.Data.SqlDbType.Float, 8, "Highest_Depth"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Max_Send_Window", System.Data.SqlDbType.Float, 8, "Max_Send_Window"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Max_Recv_Window", System.Data.SqlDbType.Float, 8, "Max_Recv_Window"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Recv_Window_Closed", System.Data.SqlDbType.Float, 8, "Recv_Window_Closed"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SWS_Count", System.Data.SqlDbType.Float, 8, "SWS_Count"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Inbound_Data", System.Data.SqlDbType.Float, 8, "Inbound_Data"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Inbound_Bytes", System.Data.SqlDbType.Float, 8, "Inbound_Bytes"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Inbound_Data_Dup", System.Data.SqlDbType.Float, 8, "Inbound_Data_Dup"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Inbound_Bytes_Dup", System.Data.SqlDbType.Float, 8, "Inbound_Bytes_Dup"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Inbound_Eff", System.Data.SqlDbType.Float, 8, "Inbound_Eff"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Outbound_Data", System.Data.SqlDbType.Float, 8, "Outbound_Data"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Outbound_Bytes", System.Data.SqlDbType.Float, 8, "Outbound_Bytes"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Outbound_Data_Retr", System.Data.SqlDbType.Float, 8, "Outbound_Data_Retr"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Outbound_Bytes_Retr", System.Data.SqlDbType.Float, 8, "Outbound_Bytes_Retr"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Outbound_Eff", System.Data.SqlDbType.Float, 8, "Outbound_Eff"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Recvs_Issued", System.Data.SqlDbType.Float, 8, "Recvs_Issued"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Sends_Issued", System.Data.SqlDbType.Float, 8, "Sends_Issued"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Retransmits", System.Data.SqlDbType.Float, 8, "Retransmits"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@In_Retr_Mode", System.Data.SqlDbType.Float, 8, "In_Retr_Mode"));
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = "UPDATE Connection_Records SET Conn_PID = @Conn_PID, Local_Port = @Local_Port, For" +
                "eign_Port = @Foreign_Port, Foreign_IP = @Foreign_IP, Conn_Start_Time = @Conn_Sta" +
                "rt_Time, Conn_End_Time = @Conn_End_Time, INT_EXT = @INT_EXT, Conn_State = @Conn_" +
                "State, Conn_Protocol = @Conn_Protocol, Highest_Depth = @Highest_Depth, Max_Send_" +
                "Window = @Max_Send_Window, Max_Recv_Window = @Max_Recv_Window, Recv_Window_Close" +
                "d = @Recv_Window_Closed, SWS_Count = @SWS_Count, Inbound_Data = @Inbound_Data, I" +
                "nbound_Bytes = @Inbound_Bytes, Inbound_Data_Dup = @Inbound_Data_Dup, Inbound_Byt" +
                "es_Dup = @Inbound_Bytes_Dup, Inbound_Eff = @Inbound_Eff, Outbound_Data = @Outbou" +
                "nd_Data, Outbound_Bytes = @Outbound_Bytes, Outbound_Data_Retr = @Outbound_Data_R" +
                "etr, Outbound_Bytes_Retr = @Outbound_Bytes_Retr, Outbound_Eff = @Outbound_Eff, R" +
                "ecvs_Issued = @Recvs_Issued, Sends_Issued = @Sends_Issued, Retransmits = @Retran" +
                "smits, In_Retr_Mode = @In_Retr_Mode WHERE (Conn_End_Time = @Original_Conn_End_Ti" +
                "me) AND (Conn_Start_Time = @Original_Conn_Start_Time) AND (Foreign_IP = @Origina" +
                "l_Foreign_IP) AND (Foreign_Port = @Original_Foreign_Port) AND (Local_Port = @Ori" +
                "ginal_Local_Port) AND (Record_ID = @Original_Record_ID) AND (Conn_PID = @Origina" +
                "l_Conn_PID OR @Original_Conn_PID IS NULL AND Conn_PID IS NULL) AND (Conn_Protoco" +
                "l = @Original_Conn_Protocol OR @Original_Conn_Protocol IS NULL AND Conn_Protocol" +
                " IS NULL) AND (Conn_State = @Original_Conn_State OR @Original_Conn_State IS NULL" +
                " AND Conn_State IS NULL) AND (Highest_Depth = @Original_Highest_Depth OR @Origin" +
                "al_Highest_Depth IS NULL AND Highest_Depth IS NULL) AND (INT_EXT = @Original_INT" +
                "_EXT OR @Original_INT_EXT IS NULL AND INT_EXT IS NULL) AND (In_Retr_Mode = @Orig" +
                "inal_In_Retr_Mode OR @Original_In_Retr_Mode IS NULL AND In_Retr_Mode IS NULL) AN" +
                "D (Inbound_Bytes = @Original_Inbound_Bytes OR @Original_Inbound_Bytes IS NULL AN" +
                "D Inbound_Bytes IS NULL) AND (Inbound_Bytes_Dup = @Original_Inbound_Bytes_Dup OR" +
                " @Original_Inbound_Bytes_Dup IS NULL AND Inbound_Bytes_Dup IS NULL) AND (Inbound" +
                "_Data = @Original_Inbound_Data OR @Original_Inbound_Data IS NULL AND Inbound_Dat" +
                "a IS NULL) AND (Inbound_Data_Dup = @Original_Inbound_Data_Dup OR @Original_Inbou" +
                "nd_Data_Dup IS NULL AND Inbound_Data_Dup IS NULL) AND (Inbound_Eff = @Original_I" +
                "nbound_Eff OR @Original_Inbound_Eff IS NULL AND Inbound_Eff IS NULL) AND (Max_Re" +
                "cv_Window = @Original_Max_Recv_Window OR @Original_Max_Recv_Window IS NULL AND M" +
                "ax_Recv_Window IS NULL) AND (Max_Send_Window = @Original_Max_Send_Window OR @Ori" +
                "ginal_Max_Send_Window IS NULL AND Max_Send_Window IS NULL) AND (Outbound_Bytes =" +
                " @Original_Outbound_Bytes OR @Original_Outbound_Bytes IS NULL AND Outbound_Bytes" +
                " IS NULL) AND (Outbound_Bytes_Retr = @Original_Outbound_Bytes_Retr OR @Original_" +
                "Outbound_Bytes_Retr IS NULL AND Outbound_Bytes_Retr IS NULL) AND (Outbound_Data " +
                "= @Original_Outbound_Data OR @Original_Outbound_Data IS NULL AND Outbound_Data I" +
                "S NULL) AND (Outbound_Data_Retr = @Original_Outbound_Data_Retr OR @Original_Outb" +
                "ound_Data_Retr IS NULL AND Outbound_Data_Retr IS NULL) AND (Outbound_Eff = @Orig" +
                "inal_Outbound_Eff OR @Original_Outbound_Eff IS NULL AND Outbound_Eff IS NULL) AN" +
                "D (Recv_Window_Closed = @Original_Recv_Window_Closed OR @Original_Recv_Window_Cl" +
                "osed IS NULL AND Recv_Window_Closed IS NULL) AND (Recvs_Issued = @Original_Recvs" +
                "_Issued OR @Original_Recvs_Issued IS NULL AND Recvs_Issued IS NULL) AND (Retrans" +
                "mits = @Original_Retransmits OR @Original_Retransmits IS NULL AND Retransmits IS" +
                " NULL) AND (SWS_Count = @Original_SWS_Count OR @Original_SWS_Count IS NULL AND S" +
                "WS_Count IS NULL) AND (Sends_Issued = @Original_Sends_Issued OR @Original_Sends_" +
                "Issued IS NULL AND Sends_Issued IS NULL); SELECT Record_ID, Conn_PID, Local_Port" +
                ", Foreign_Port, Foreign_IP, Conn_Start_Time, Conn_End_Time, INT_EXT, Conn_State," +
                " Conn_Protocol, Highest_Depth, Max_Send_Window, Max_Recv_Window, Recv_Window_Clo" +
                "sed, SWS_Count, Inbound_Data, Inbound_Bytes, Inbound_Data_Dup, Inbound_Bytes_Dup" +
                ", Inbound_Eff, Outbound_Data, Outbound_Bytes, Outbound_Data_Retr, Outbound_Bytes" +
                "_Retr, Outbound_Eff, Recvs_Issued, Sends_Issued, Retransmits, In_Retr_Mode FROM " +
                "Connection_Records WHERE (Conn_End_Time = @Conn_End_Time) AND (Conn_Start_Time =" +
                " @Conn_Start_Time) AND (Foreign_IP = @Foreign_IP) AND (Foreign_Port = @Foreign_P" +
                "ort) AND (Local_Port = @Local_Port) AND (Record_ID = @Record_ID)";
            this.sqlUpdateCommand1.Connection = this.sqlConnection2;
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Conn_PID", System.Data.SqlDbType.VarChar, 2, "Conn_PID"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Local_Port", System.Data.SqlDbType.Float, 8, "Local_Port"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Foreign_Port", System.Data.SqlDbType.Float, 8, "Foreign_Port"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Foreign_IP", System.Data.SqlDbType.VarChar, 15, "Foreign_IP"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Conn_Start_Time", System.Data.SqlDbType.DateTime, 8, "Conn_Start_Time"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Conn_End_Time", System.Data.SqlDbType.DateTime, 8, "Conn_End_Time"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@INT_EXT", System.Data.SqlDbType.VarChar, 3, "INT_EXT"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Conn_State", System.Data.SqlDbType.VarChar, 12, "Conn_State"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Conn_Protocol", System.Data.SqlDbType.VarChar, 8, "Conn_Protocol"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Highest_Depth", System.Data.SqlDbType.Float, 8, "Highest_Depth"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Max_Send_Window", System.Data.SqlDbType.Float, 8, "Max_Send_Window"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Max_Recv_Window", System.Data.SqlDbType.Float, 8, "Max_Recv_Window"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Recv_Window_Closed", System.Data.SqlDbType.Float, 8, "Recv_Window_Closed"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SWS_Count", System.Data.SqlDbType.Float, 8, "SWS_Count"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Inbound_Data", System.Data.SqlDbType.Float, 8, "Inbound_Data"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Inbound_Bytes", System.Data.SqlDbType.Float, 8, "Inbound_Bytes"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Inbound_Data_Dup", System.Data.SqlDbType.Float, 8, "Inbound_Data_Dup"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Inbound_Bytes_Dup", System.Data.SqlDbType.Float, 8, "Inbound_Bytes_Dup"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Inbound_Eff", System.Data.SqlDbType.Float, 8, "Inbound_Eff"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Outbound_Data", System.Data.SqlDbType.Float, 8, "Outbound_Data"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Outbound_Bytes", System.Data.SqlDbType.Float, 8, "Outbound_Bytes"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Outbound_Data_Retr", System.Data.SqlDbType.Float, 8, "Outbound_Data_Retr"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Outbound_Bytes_Retr", System.Data.SqlDbType.Float, 8, "Outbound_Bytes_Retr"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Outbound_Eff", System.Data.SqlDbType.Float, 8, "Outbound_Eff"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Recvs_Issued", System.Data.SqlDbType.Float, 8, "Recvs_Issued"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Sends_Issued", System.Data.SqlDbType.Float, 8, "Sends_Issued"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Retransmits", System.Data.SqlDbType.Float, 8, "Retransmits"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@In_Retr_Mode", System.Data.SqlDbType.Float, 8, "In_Retr_Mode"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Conn_End_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Conn_End_Time", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Conn_Start_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Conn_Start_Time", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Foreign_IP", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Foreign_IP", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Foreign_Port", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Foreign_Port", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Local_Port", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Local_Port", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Record_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Record_ID", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Conn_PID", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Conn_PID", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Conn_Protocol", System.Data.SqlDbType.VarChar, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Conn_Protocol", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Conn_State", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Conn_State", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Highest_Depth", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Highest_Depth", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_INT_EXT", System.Data.SqlDbType.VarChar, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "INT_EXT", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_In_Retr_Mode", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "In_Retr_Mode", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Inbound_Bytes", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Inbound_Bytes", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Inbound_Bytes_Dup", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Inbound_Bytes_Dup", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Inbound_Data", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Inbound_Data", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Inbound_Data_Dup", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Inbound_Data_Dup", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Inbound_Eff", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Inbound_Eff", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Max_Recv_Window", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Max_Recv_Window", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Max_Send_Window", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Max_Send_Window", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Outbound_Bytes", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Outbound_Bytes", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Outbound_Bytes_Retr", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Outbound_Bytes_Retr", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Outbound_Data", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Outbound_Data", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Outbound_Data_Retr", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Outbound_Data_Retr", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Outbound_Eff", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Outbound_Eff", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Recv_Window_Closed", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Recv_Window_Closed", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Recvs_Issued", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Recvs_Issued", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Retransmits", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Retransmits", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SWS_Count", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SWS_Count", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Sends_Issued", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Sends_Issued", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Record_ID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "DELETE FROM Connection_Records WHERE (Conn_End_Time = @Original_Conn_End_Time) AN" +
                "D (Conn_Start_Time = @Original_Conn_Start_Time) AND (Foreign_IP = @Original_Fore" +
                "ign_IP) AND (Foreign_Port = @Original_Foreign_Port) AND (Local_Port = @Original_" +
                "Local_Port) AND (Record_ID = @Original_Record_ID) AND (Conn_PID = @Original_Conn" +
                "_PID OR @Original_Conn_PID IS NULL AND Conn_PID IS NULL) AND (Conn_Protocol = @O" +
                "riginal_Conn_Protocol OR @Original_Conn_Protocol IS NULL AND Conn_Protocol IS NU" +
                "LL) AND (Conn_State = @Original_Conn_State OR @Original_Conn_State IS NULL AND C" +
                "onn_State IS NULL) AND (Highest_Depth = @Original_Highest_Depth OR @Original_Hig" +
                "hest_Depth IS NULL AND Highest_Depth IS NULL) AND (INT_EXT = @Original_INT_EXT O" +
                "R @Original_INT_EXT IS NULL AND INT_EXT IS NULL) AND (In_Retr_Mode = @Original_I" +
                "n_Retr_Mode OR @Original_In_Retr_Mode IS NULL AND In_Retr_Mode IS NULL) AND (Inb" +
                "ound_Bytes = @Original_Inbound_Bytes OR @Original_Inbound_Bytes IS NULL AND Inbo" +
                "und_Bytes IS NULL) AND (Inbound_Bytes_Dup = @Original_Inbound_Bytes_Dup OR @Orig" +
                "inal_Inbound_Bytes_Dup IS NULL AND Inbound_Bytes_Dup IS NULL) AND (Inbound_Data " +
                "= @Original_Inbound_Data OR @Original_Inbound_Data IS NULL AND Inbound_Data IS N" +
                "ULL) AND (Inbound_Data_Dup = @Original_Inbound_Data_Dup OR @Original_Inbound_Dat" +
                "a_Dup IS NULL AND Inbound_Data_Dup IS NULL) AND (Inbound_Eff = @Original_Inbound" +
                "_Eff OR @Original_Inbound_Eff IS NULL AND Inbound_Eff IS NULL) AND (Max_Recv_Win" +
                "dow = @Original_Max_Recv_Window OR @Original_Max_Recv_Window IS NULL AND Max_Rec" +
                "v_Window IS NULL) AND (Max_Send_Window = @Original_Max_Send_Window OR @Original_" +
                "Max_Send_Window IS NULL AND Max_Send_Window IS NULL) AND (Outbound_Bytes = @Orig" +
                "inal_Outbound_Bytes OR @Original_Outbound_Bytes IS NULL AND Outbound_Bytes IS NU" +
                "LL) AND (Outbound_Bytes_Retr = @Original_Outbound_Bytes_Retr OR @Original_Outbou" +
                "nd_Bytes_Retr IS NULL AND Outbound_Bytes_Retr IS NULL) AND (Outbound_Data = @Ori" +
                "ginal_Outbound_Data OR @Original_Outbound_Data IS NULL AND Outbound_Data IS NULL" +
                ") AND (Outbound_Data_Retr = @Original_Outbound_Data_Retr OR @Original_Outbound_D" +
                "ata_Retr IS NULL AND Outbound_Data_Retr IS NULL) AND (Outbound_Eff = @Original_O" +
                "utbound_Eff OR @Original_Outbound_Eff IS NULL AND Outbound_Eff IS NULL) AND (Rec" +
                "v_Window_Closed = @Original_Recv_Window_Closed OR @Original_Recv_Window_Closed I" +
                "S NULL AND Recv_Window_Closed IS NULL) AND (Recvs_Issued = @Original_Recvs_Issue" +
                "d OR @Original_Recvs_Issued IS NULL AND Recvs_Issued IS NULL) AND (Retransmits =" +
                " @Original_Retransmits OR @Original_Retransmits IS NULL AND Retransmits IS NULL)" +
                " AND (SWS_Count = @Original_SWS_Count OR @Original_SWS_Count IS NULL AND SWS_Cou" +
                "nt IS NULL) AND (Sends_Issued = @Original_Sends_Issued OR @Original_Sends_Issued" +
                " IS NULL AND Sends_Issued IS NULL)";
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Conn_End_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Conn_End_Time", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Conn_Start_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Conn_Start_Time", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Foreign_IP", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Foreign_IP", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Foreign_Port", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Foreign_Port", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Local_Port", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Local_Port", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Record_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Record_ID", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Conn_PID", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Conn_PID", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Conn_Protocol", System.Data.SqlDbType.VarChar, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Conn_Protocol", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Conn_State", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Conn_State", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Highest_Depth", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Highest_Depth", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_INT_EXT", System.Data.SqlDbType.VarChar, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "INT_EXT", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_In_Retr_Mode", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "In_Retr_Mode", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Inbound_Bytes", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Inbound_Bytes", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Inbound_Bytes_Dup", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Inbound_Bytes_Dup", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Inbound_Data", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Inbound_Data", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Inbound_Data_Dup", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Inbound_Data_Dup", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Inbound_Eff", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Inbound_Eff", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Max_Recv_Window", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Max_Recv_Window", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Max_Send_Window", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Max_Send_Window", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Outbound_Bytes", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Outbound_Bytes", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Outbound_Bytes_Retr", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Outbound_Bytes_Retr", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Outbound_Data", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Outbound_Data", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Outbound_Data_Retr", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Outbound_Data_Retr", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Outbound_Eff", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Outbound_Eff", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Recv_Window_Closed", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Recv_Window_Closed", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Recvs_Issued", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Recvs_Issued", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Retransmits", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Retransmits", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SWS_Count", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SWS_Count", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Sends_Issued", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Sends_Issued", System.Data.DataRowVersion.Original, null));
            // 
            // sqlDataAdapter1
            // 
            this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Connection_Records", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("Record_ID", "Record_ID"),
																																																							new System.Data.Common.DataColumnMapping("Conn_PID", "Conn_PID"),
																																																							new System.Data.Common.DataColumnMapping("Local_Port", "Local_Port"),
																																																							new System.Data.Common.DataColumnMapping("Foreign_Port", "Foreign_Port"),
																																																							new System.Data.Common.DataColumnMapping("Foreign_IP", "Foreign_IP"),
																																																							new System.Data.Common.DataColumnMapping("Conn_Start_Time", "Conn_Start_Time"),
																																																							new System.Data.Common.DataColumnMapping("Conn_End_Time", "Conn_End_Time"),
																																																							new System.Data.Common.DataColumnMapping("INT_EXT", "INT_EXT"),
																																																							new System.Data.Common.DataColumnMapping("Conn_State", "Conn_State"),
																																																							new System.Data.Common.DataColumnMapping("Conn_Protocol", "Conn_Protocol"),
																																																							new System.Data.Common.DataColumnMapping("Highest_Depth", "Highest_Depth"),
																																																							new System.Data.Common.DataColumnMapping("Max_Send_Window", "Max_Send_Window"),
																																																							new System.Data.Common.DataColumnMapping("Max_Recv_Window", "Max_Recv_Window"),
																																																							new System.Data.Common.DataColumnMapping("Recv_Window_Closed", "Recv_Window_Closed"),
																																																							new System.Data.Common.DataColumnMapping("SWS_Count", "SWS_Count"),
																																																							new System.Data.Common.DataColumnMapping("Inbound_Data", "Inbound_Data"),
																																																							new System.Data.Common.DataColumnMapping("Inbound_Bytes", "Inbound_Bytes"),
																																																							new System.Data.Common.DataColumnMapping("Inbound_Data_Dup", "Inbound_Data_Dup"),
																																																							new System.Data.Common.DataColumnMapping("Inbound_Bytes_Dup", "Inbound_Bytes_Dup"),
																																																							new System.Data.Common.DataColumnMapping("Inbound_Eff", "Inbound_Eff"),
																																																							new System.Data.Common.DataColumnMapping("Outbound_Data", "Outbound_Data"),
																																																							new System.Data.Common.DataColumnMapping("Outbound_Bytes", "Outbound_Bytes"),
																																																							new System.Data.Common.DataColumnMapping("Outbound_Data_Retr", "Outbound_Data_Retr"),
																																																							new System.Data.Common.DataColumnMapping("Outbound_Bytes_Retr", "Outbound_Bytes_Retr"),
																																																							new System.Data.Common.DataColumnMapping("Outbound_Eff", "Outbound_Eff"),
																																																							new System.Data.Common.DataColumnMapping("Recvs_Issued", "Recvs_Issued"),
																																																							new System.Data.Common.DataColumnMapping("Sends_Issued", "Sends_Issued"),
																																																							new System.Data.Common.DataColumnMapping("Retransmits", "Retransmits"),
																																																							new System.Data.Common.DataColumnMapping("In_Retr_Mode", "In_Retr_Mode")})});
            this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlCommandMinDT
            // 
            this.sqlCommandMinDT.CommandText = "SELECT MIN(Conn_End_Time) AS Expr1 FROM Connection_Records";
            this.sqlCommandMinDT.Connection = this.sqlConnection1;
            // 
            // sqlCommandMaxDT
            // 
            this.sqlCommandMaxDT.CommandText = "SELECT MAX(Conn_End_Time) AS Expr1 FROM Connection_Records";
            this.sqlCommandMaxDT.Connection = this.sqlConnection1;
            // 
            // sqlConnection2
            // 
            this.sqlConnection2.ConnectionString = "workstation id=DANSDELL;packet size=4096;integrated security=SSPI;data source=\"DA" +
                "NSDELL\\SEEVSE\";persist security info=True;initial catalog=VseDb";

        }
        #endregion

        public override void SetDbName(string dbname)
        {
            //SqlStrings sqlStr = new SqlStrings(dbname);
            sqlConnection1.ConnectionString = SqlManagerSystem.BuildConnection(dbname).ConnectionString;
            sqlConnection2.ConnectionString = SqlManagerSystem.BuildConnection(dbname).ConnectionString;
            _table.Columns["Record_ID"].AutoIncrementSeed = GetLastId() + 1;
        }


        public override int GetLastId()
        {
            int LastId = 0;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                object obj = sqlCommandLastID.ExecuteScalar();
                if (obj != System.DBNull.Value)
                { LastId = (int)obj; }
            }
            catch (System.NullReferenceException nullExc)
            {
                Debug.WriteLine(nullExc.ToString());
                return 0;
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }
            return LastId;
        }

        public VseDbDataSet.Connection_RecordsDataTable GetIdRange(int firstId, int lastId)
        {
            VseDbDataSet.Connection_RecordsDataTable connTable = new VseDbDataSet.Connection_RecordsDataTable();
            sqlSELECTbyID.Parameters["@FirstID"].Value = firstId;
            sqlSELECTbyID.Parameters["@LastID"].Value = lastId;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                sqlDataAdapter1.SelectCommand = sqlSELECTbyID;
                sqlDataAdapter1.Fill(connTable);
                sqlDataAdapter1.SelectCommand = sqlSelectCommand1;
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }

            return connTable;
        }


        public DateTime GetMinDT()
        {
            DateTime DT = System.Windows.Forms.DateTimePicker.MinDateTime;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                object obj = sqlCommandMinDT.ExecuteScalar();
                if (obj != System.DBNull.Value)
                { DT = (DateTime)obj; }
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }
            return DT;
        }

        public DateTime GetMaxDT()
        {
            DateTime DT = System.Windows.Forms.DateTimePicker.MaxDateTime;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                object obj = sqlCommandMaxDT.ExecuteScalar();
                if (obj != System.DBNull.Value)
                { DT = (DateTime)obj; }
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }
            return DT;
        }

        public void GetDateRange(DateTime firstTime, DateTime lastTime, VseDbDataSet dset)
        {
            using (Cursor pCursor = Cursor.Current)
            {
                Cursor.Current = Cursors.WaitCursor;
                sqlSELECTbyDT.Parameters["@StartTime"].Value = firstTime;
                sqlSELECTbyDT.Parameters["@EndTime"].Value = lastTime;
                try
                {
                    System.Threading.Monitor.Enter(sqlDataAdapter1);//Lock the sqlconnection
                    if (sqlConnection1.State == ConnectionState.Closed)
                    { sqlConnection1.Open(); }
                    sqlDataAdapter1.SelectCommand = sqlSELECTbyDT;
                    sqlDataAdapter1.Fill(dset);
                    sqlDataAdapter1.SelectCommand = sqlSelectCommand1;
                }
                finally
                {
                    if (sqlConnection1.State != ConnectionState.Closed)
                    { sqlConnection1.Close(); }
                    System.Threading.Monitor.Exit(sqlDataAdapter1);//Unlock the sqlconnection
                    Cursor.Current = pCursor;
                }
            }

        }


        public void AddRecord(VseDbDataSet.Connection_RecordsRow connRow)
        {
            try
            {
                VseDbDataSet.Connection_RecordsRow row = _table.NewConnection_RecordsRow();
                row.ItemArray = connRow.ItemArray;//Copy the values	
                _table.AddConnection_RecordsRow(row);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
                throw;//rethrow the same exception
            }
        }

        public void UpdateDb()
        {
            try
            {
                System.Threading.Monitor.Enter(sqlDataAdapter1);//Lock the dataadapter
                if (sqlConnection2.State == ConnectionState.Closed)
                { sqlConnection2.Open(); }

                sqlDataAdapter1.Update(_table);
                _table.Rows.Clear();

            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
                throw;//rethrow the same exception
            }
            finally
            {
                if (sqlConnection2.State != ConnectionState.Closed)
                { sqlConnection2.Close(); }
                System.Threading.Monitor.Exit(sqlDataAdapter1);//Unlock the dataadapter
            }
        }

    }

    public class ConsoleFtpRecords : AConsoleRecords
    {
        VseDbDataSet.FTP_RecordsDataTable _table =
            new VseDbDataSet.FTP_RecordsDataTable();
        #region SqlClient
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlCommandLastID;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private System.Data.SqlClient.SqlCommand sqlSELECTbyID;
        private System.Data.SqlClient.SqlCommand sqlSELECTbyDT;
        private System.Data.SqlClient.SqlCommand sqlCommandMinDT;
        private System.Data.SqlClient.SqlCommand sqlCommandMaxDT;
        #endregion
        private System.Data.SqlClient.SqlConnection sqlConnection2;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ConsoleFtpRecords(System.ComponentModel.IContainer container)
        {
            ///
            /// Required for Windows.Forms Class Composition Designer support
            ///
            container.Add(this);
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ConsoleFtpRecords()
        {
            ///
            /// Required for Windows.Forms Class Composition Designer support
            ///
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlCommandLastID = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSELECTbyID = new System.Data.SqlClient.SqlCommand();
            this.sqlSELECTbyDT = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandMinDT = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandMaxDT = new System.Data.SqlClient.SqlCommand();
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "workstation id=DANSDELL;packet size=4096;integrated security=SSPI;data source=\"DA" +
                "NSDELL\\SEEVSE\";persist security info=True;initial catalog=VseDb";
            // 
            // sqlCommandLastID
            // 
            this.sqlCommandLastID.CommandText = "SELECT MAX(Record_ID) AS Expr1 FROM FTP_Records";
            this.sqlCommandLastID.Connection = this.sqlConnection1;
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = @"SELECT Record_ID, FTP_Node_Name, FTP_User_ID, Bytes_SentAcked, Bytes_Received, Start_Time, End_Time, Files_Received, Files_Sent, Vse_IP, Client_IP, Vse_Port, Client_Port, Vse_Task_ID, SSL_Flag, General_Flag, Foreign_Data_IP FROM FTP_Records WHERE (Record_ID >= @FirstID AND Record_ID <= @LastID)";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FirstID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = @"INSERT INTO FTP_Records(FTP_Node_Name, FTP_User_ID, Bytes_SentAcked, Bytes_Received, Start_Time, End_Time, Files_Received, Files_Sent, Vse_IP, Client_IP, Vse_Port, Client_Port, Vse_Task_ID, SSL_Flag, General_Flag, Foreign_Data_IP) VALUES (@FTP_Node_Name, @FTP_User_ID, @Bytes_SentAcked, @Bytes_Received, @Start_Time, @End_Time, @Files_Received, @Files_Sent, @Vse_IP, @Client_IP, @Vse_Port, @Client_Port, @Vse_Task_ID, @SSL_Flag, @General_Flag, @Foreign_Data_IP); SELECT Record_ID, FTP_Node_Name, FTP_User_ID, Bytes_SentAcked, Bytes_Received, Start_Time, End_Time, Files_Received, Files_Sent, Vse_IP, Client_IP, Vse_Port, Client_Port, Vse_Task_ID, SSL_Flag, General_Flag, Foreign_Data_IP FROM FTP_Records WHERE (Record_ID = @@IDENTITY) AND (Start_Time = @Start_Time)";
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FTP_Node_Name", System.Data.SqlDbType.VarChar, 16, "FTP_Node_Name"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FTP_User_ID", System.Data.SqlDbType.VarChar, 16, "FTP_User_ID"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Bytes_SentAcked", System.Data.SqlDbType.Float, 8, "Bytes_SentAcked"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Bytes_Received", System.Data.SqlDbType.Float, 8, "Bytes_Received"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Start_Time", System.Data.SqlDbType.DateTime, 8, "Start_Time"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@End_Time", System.Data.SqlDbType.DateTime, 8, "End_Time"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Files_Received", System.Data.SqlDbType.Float, 8, "Files_Received"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Files_Sent", System.Data.SqlDbType.Float, 8, "Files_Sent"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Vse_IP", System.Data.SqlDbType.VarChar, 15, "Vse_IP"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Client_IP", System.Data.SqlDbType.VarChar, 15, "Client_IP"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Vse_Port", System.Data.SqlDbType.Int, 4, "Vse_Port"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Client_Port", System.Data.SqlDbType.Int, 4, "Client_Port"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Vse_Task_ID", System.Data.SqlDbType.Int, 4, "Vse_Task_ID"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SSL_Flag", System.Data.SqlDbType.TinyInt, 1, "SSL_Flag"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@General_Flag", System.Data.SqlDbType.TinyInt, 1, "General_Flag"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Foreign_Data_IP", System.Data.SqlDbType.VarChar, 15, "Foreign_Data_IP"));
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = "UPDATE FTP_Records SET FTP_Node_Name = @FTP_Node_Name, FTP_User_ID = @FTP_User_ID" +
                ", Bytes_SentAcked = @Bytes_SentAcked, Bytes_Received = @Bytes_Received, Start_Ti" +
                "me = @Start_Time, End_Time = @End_Time, Files_Received = @Files_Received, Files_" +
                "Sent = @Files_Sent, Vse_IP = @Vse_IP, Client_IP = @Client_IP, Vse_Port = @Vse_Po" +
                "rt, Client_Port = @Client_Port, Vse_Task_ID = @Vse_Task_ID, SSL_Flag = @SSL_Flag" +
                ", General_Flag = @General_Flag, Foreign_Data_IP = @Foreign_Data_IP WHERE (Record" +
                "_ID = @Original_Record_ID) AND (Start_Time = @Original_Start_Time) AND (Bytes_Re" +
                "ceived = @Original_Bytes_Received OR @Original_Bytes_Received IS NULL AND Bytes_" +
                "Received IS NULL) AND (Bytes_SentAcked = @Original_Bytes_SentAcked OR @Original_" +
                "Bytes_SentAcked IS NULL AND Bytes_SentAcked IS NULL) AND (Client_IP = @Original_" +
                "Client_IP OR @Original_Client_IP IS NULL AND Client_IP IS NULL) AND (Client_Port" +
                " = @Original_Client_Port OR @Original_Client_Port IS NULL AND Client_Port IS NUL" +
                "L) AND (End_Time = @Original_End_Time OR @Original_End_Time IS NULL AND End_Time" +
                " IS NULL) AND (FTP_Node_Name = @Original_FTP_Node_Name OR @Original_FTP_Node_Nam" +
                "e IS NULL AND FTP_Node_Name IS NULL) AND (FTP_User_ID = @Original_FTP_User_ID OR" +
                " @Original_FTP_User_ID IS NULL AND FTP_User_ID IS NULL) AND (Files_Received = @O" +
                "riginal_Files_Received OR @Original_Files_Received IS NULL AND Files_Received IS" +
                " NULL) AND (Files_Sent = @Original_Files_Sent OR @Original_Files_Sent IS NULL AN" +
                "D Files_Sent IS NULL) AND (Foreign_Data_IP = @Original_Foreign_Data_IP OR @Origi" +
                "nal_Foreign_Data_IP IS NULL AND Foreign_Data_IP IS NULL) AND (General_Flag = @Or" +
                "iginal_General_Flag OR @Original_General_Flag IS NULL AND General_Flag IS NULL) " +
                "AND (SSL_Flag = @Original_SSL_Flag OR @Original_SSL_Flag IS NULL AND SSL_Flag IS" +
                " NULL) AND (Vse_IP = @Original_Vse_IP OR @Original_Vse_IP IS NULL AND Vse_IP IS " +
                "NULL) AND (Vse_Port = @Original_Vse_Port OR @Original_Vse_Port IS NULL AND Vse_P" +
                "ort IS NULL) AND (Vse_Task_ID = @Original_Vse_Task_ID OR @Original_Vse_Task_ID I" +
                "S NULL AND Vse_Task_ID IS NULL); SELECT Record_ID, FTP_Node_Name, FTP_User_ID, B" +
                "ytes_SentAcked, Bytes_Received, Start_Time, End_Time, Files_Received, Files_Sent" +
                ", Vse_IP, Client_IP, Vse_Port, Client_Port, Vse_Task_ID, SSL_Flag, General_Flag," +
                " Foreign_Data_IP FROM FTP_Records WHERE (Record_ID = @Record_ID) AND (Start_Time" +
                " = @Start_Time)";
            this.sqlUpdateCommand1.Connection = this.sqlConnection2;
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FTP_Node_Name", System.Data.SqlDbType.VarChar, 16, "FTP_Node_Name"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FTP_User_ID", System.Data.SqlDbType.VarChar, 16, "FTP_User_ID"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Bytes_SentAcked", System.Data.SqlDbType.Float, 8, "Bytes_SentAcked"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Bytes_Received", System.Data.SqlDbType.Float, 8, "Bytes_Received"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Start_Time", System.Data.SqlDbType.DateTime, 8, "Start_Time"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@End_Time", System.Data.SqlDbType.DateTime, 8, "End_Time"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Files_Received", System.Data.SqlDbType.Float, 8, "Files_Received"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Files_Sent", System.Data.SqlDbType.Float, 8, "Files_Sent"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Vse_IP", System.Data.SqlDbType.VarChar, 15, "Vse_IP"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Client_IP", System.Data.SqlDbType.VarChar, 15, "Client_IP"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Vse_Port", System.Data.SqlDbType.Int, 4, "Vse_Port"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Client_Port", System.Data.SqlDbType.Int, 4, "Client_Port"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Vse_Task_ID", System.Data.SqlDbType.Int, 4, "Vse_Task_ID"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SSL_Flag", System.Data.SqlDbType.TinyInt, 1, "SSL_Flag"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@General_Flag", System.Data.SqlDbType.TinyInt, 1, "General_Flag"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Foreign_Data_IP", System.Data.SqlDbType.VarChar, 15, "Foreign_Data_IP"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Record_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Record_ID", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Start_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Start_Time", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Bytes_Received", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Bytes_Received", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Bytes_SentAcked", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Bytes_SentAcked", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Client_IP", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Client_IP", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Client_Port", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Client_Port", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_End_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "End_Time", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FTP_Node_Name", System.Data.SqlDbType.VarChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FTP_Node_Name", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FTP_User_ID", System.Data.SqlDbType.VarChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FTP_User_ID", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Files_Received", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Files_Received", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Files_Sent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Files_Sent", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Foreign_Data_IP", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Foreign_Data_IP", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_General_Flag", System.Data.SqlDbType.TinyInt, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "General_Flag", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SSL_Flag", System.Data.SqlDbType.TinyInt, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SSL_Flag", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Vse_IP", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vse_IP", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Vse_Port", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vse_Port", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Vse_Task_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vse_Task_ID", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Record_ID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            // 
            // sqlConnection2
            // 
            this.sqlConnection2.ConnectionString = "workstation id=DANSDELL;packet size=4096;integrated security=SSPI;data source=\"DA" +
                "NSDELL\\SEEVSE\";persist security info=True;initial catalog=VseDb";
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "DELETE FROM FTP_Records WHERE (Record_ID = @Original_Record_ID) AND (Start_Time =" +
                " @Original_Start_Time) AND (Bytes_Received = @Original_Bytes_Received OR @Origin" +
                "al_Bytes_Received IS NULL AND Bytes_Received IS NULL) AND (Bytes_SentAcked = @Or" +
                "iginal_Bytes_SentAcked OR @Original_Bytes_SentAcked IS NULL AND Bytes_SentAcked " +
                "IS NULL) AND (Client_IP = @Original_Client_IP OR @Original_Client_IP IS NULL AND" +
                " Client_IP IS NULL) AND (Client_Port = @Original_Client_Port OR @Original_Client" +
                "_Port IS NULL AND Client_Port IS NULL) AND (End_Time = @Original_End_Time OR @Or" +
                "iginal_End_Time IS NULL AND End_Time IS NULL) AND (FTP_Node_Name = @Original_FTP" +
                "_Node_Name OR @Original_FTP_Node_Name IS NULL AND FTP_Node_Name IS NULL) AND (FT" +
                "P_User_ID = @Original_FTP_User_ID OR @Original_FTP_User_ID IS NULL AND FTP_User_" +
                "ID IS NULL) AND (Files_Received = @Original_Files_Received OR @Original_Files_Re" +
                "ceived IS NULL AND Files_Received IS NULL) AND (Files_Sent = @Original_Files_Sen" +
                "t OR @Original_Files_Sent IS NULL AND Files_Sent IS NULL) AND (Foreign_Data_IP =" +
                " @Original_Foreign_Data_IP OR @Original_Foreign_Data_IP IS NULL AND Foreign_Data" +
                "_IP IS NULL) AND (General_Flag = @Original_General_Flag OR @Original_General_Fla" +
                "g IS NULL AND General_Flag IS NULL) AND (SSL_Flag = @Original_SSL_Flag OR @Origi" +
                "nal_SSL_Flag IS NULL AND SSL_Flag IS NULL) AND (Vse_IP = @Original_Vse_IP OR @Or" +
                "iginal_Vse_IP IS NULL AND Vse_IP IS NULL) AND (Vse_Port = @Original_Vse_Port OR " +
                "@Original_Vse_Port IS NULL AND Vse_Port IS NULL) AND (Vse_Task_ID = @Original_Vs" +
                "e_Task_ID OR @Original_Vse_Task_ID IS NULL AND Vse_Task_ID IS NULL)";
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Record_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Record_ID", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Start_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Start_Time", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Bytes_Received", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Bytes_Received", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Bytes_SentAcked", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Bytes_SentAcked", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Client_IP", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Client_IP", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Client_Port", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Client_Port", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_End_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "End_Time", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FTP_Node_Name", System.Data.SqlDbType.VarChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FTP_Node_Name", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FTP_User_ID", System.Data.SqlDbType.VarChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FTP_User_ID", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Files_Received", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Files_Received", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Files_Sent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Files_Sent", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Foreign_Data_IP", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Foreign_Data_IP", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_General_Flag", System.Data.SqlDbType.TinyInt, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "General_Flag", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SSL_Flag", System.Data.SqlDbType.TinyInt, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SSL_Flag", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Vse_IP", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vse_IP", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Vse_Port", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vse_Port", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Vse_Task_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vse_Task_ID", System.Data.DataRowVersion.Original, null));
            // 
            // sqlDataAdapter1
            // 
            this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "FTP_Records", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("Record_ID", "Record_ID"),
																																																					 new System.Data.Common.DataColumnMapping("FTP_Node_Name", "FTP_Node_Name"),
																																																					 new System.Data.Common.DataColumnMapping("FTP_User_ID", "FTP_User_ID"),
																																																					 new System.Data.Common.DataColumnMapping("Bytes_SentAcked", "Bytes_SentAcked"),
																																																					 new System.Data.Common.DataColumnMapping("Bytes_Received", "Bytes_Received"),
																																																					 new System.Data.Common.DataColumnMapping("Start_Time", "Start_Time"),
																																																					 new System.Data.Common.DataColumnMapping("End_Time", "End_Time"),
																																																					 new System.Data.Common.DataColumnMapping("Files_Received", "Files_Received"),
																																																					 new System.Data.Common.DataColumnMapping("Files_Sent", "Files_Sent"),
																																																					 new System.Data.Common.DataColumnMapping("Vse_IP", "Vse_IP"),
																																																					 new System.Data.Common.DataColumnMapping("Client_IP", "Client_IP"),
																																																					 new System.Data.Common.DataColumnMapping("Vse_Port", "Vse_Port"),
																																																					 new System.Data.Common.DataColumnMapping("Client_Port", "Client_Port"),
																																																					 new System.Data.Common.DataColumnMapping("Vse_Task_ID", "Vse_Task_ID"),
																																																					 new System.Data.Common.DataColumnMapping("SSL_Flag", "SSL_Flag"),
																																																					 new System.Data.Common.DataColumnMapping("General_Flag", "General_Flag"),
																																																					 new System.Data.Common.DataColumnMapping("Foreign_Data_IP", "Foreign_Data_IP")})});
            this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlSELECTbyID
            // 
            this.sqlSELECTbyID.CommandText = "SELECT FTP_Records.* FROM FTP_Records WHERE (Record_ID >= @FirstID) AND (Record_I" +
                "D <= @LastID)";
            this.sqlSELECTbyID.Connection = this.sqlConnection1;
            this.sqlSELECTbyID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FirstID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            this.sqlSELECTbyID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            // 
            // sqlSELECTbyDT
            // 
            this.sqlSELECTbyDT.CommandText = "SELECT FTP_Records.* FROM FTP_Records WHERE (End_Time >= @StartTime) AND (End_Tim" +
                "e <= @EndTime)";
            this.sqlSELECTbyDT.Connection = this.sqlConnection1;
            this.sqlSELECTbyDT.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartTime", System.Data.SqlDbType.DateTime, 8, "End_Time"));
            this.sqlSELECTbyDT.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndTime", System.Data.SqlDbType.DateTime, 8, "End_Time"));
            // 
            // sqlCommandMinDT
            // 
            this.sqlCommandMinDT.CommandText = "SELECT MIN(End_Time) AS Expr1 FROM FTP_Records";
            this.sqlCommandMinDT.Connection = this.sqlConnection1;
            // 
            // sqlCommandMaxDT
            // 
            this.sqlCommandMaxDT.CommandText = "SELECT MAX(End_Time) AS Expr1 FROM FTP_Records";
            this.sqlCommandMaxDT.Connection = this.sqlConnection1;

        }
        #endregion

        public override void SetDbName(string dbname)
        {
            //SqlStrings sqlStr = new SqlStrings(dbname);
            sqlConnection1.ConnectionString = SqlManagerSystem.BuildConnection(dbname).ConnectionString;
            sqlConnection2.ConnectionString = SqlManagerSystem.BuildConnection(dbname).ConnectionString;
            _table.Columns["Record_ID"].AutoIncrementSeed = GetLastId() + 1;
        }


        public override int GetLastId()
        {
            int LastId = 0;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                object obj = sqlCommandLastID.ExecuteScalar();
                if (obj != System.DBNull.Value)
                { LastId = (int)obj; }
            }
            catch (System.NullReferenceException nullExc)
            {
                Debug.WriteLine(nullExc.ToString());
                return 0;
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }
            return LastId;
        }

        public VseDbDataSet.FTP_RecordsDataTable GetIdRange(int firstId, int lastId)
        {
            VseDbDataSet.FTP_RecordsDataTable ftpTable = new VseDbDataSet.FTP_RecordsDataTable();
            sqlSELECTbyID.Parameters["@FirstID"].Value = firstId;
            sqlSELECTbyID.Parameters["@LastID"].Value = lastId;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                sqlDataAdapter1.SelectCommand = sqlSELECTbyID;
                sqlDataAdapter1.Fill(ftpTable);
                sqlDataAdapter1.SelectCommand = sqlSelectCommand1;
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }

            return ftpTable;
        }


        public DateTime GetMinDT()
        {
            DateTime DT = System.Windows.Forms.DateTimePicker.MinDateTime;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                object obj = sqlCommandMinDT.ExecuteScalar();
                if (obj != System.DBNull.Value)
                { DT = (DateTime)obj; }
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }
            return DT;
        }

        public DateTime GetMaxDT()
        {
            DateTime DT = System.Windows.Forms.DateTimePicker.MaxDateTime;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                object obj = sqlCommandMaxDT.ExecuteScalar();
                if (obj != System.DBNull.Value)
                { DT = (DateTime)obj; }
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }
            return DT;
        }

        public void GetDateRange(DateTime firstTime, DateTime lastTime, VseDbDataSet dset)
        {
            using (Cursor pCursor = Cursor.Current)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    System.Threading.Monitor.Enter(sqlDataAdapter1);//Lock the sqlconnection
                    if (sqlConnection1.State == ConnectionState.Closed)
                    { sqlConnection1.Open(); }
                    sqlSELECTbyDT.Parameters["@StartTime"].Value = firstTime;
                    sqlSELECTbyDT.Parameters["@EndTime"].Value = lastTime;

                    sqlDataAdapter1.SelectCommand = sqlSELECTbyDT;
                    sqlDataAdapter1.Fill(dset);
                    sqlDataAdapter1.SelectCommand = sqlSelectCommand1;
                }
                finally
                {
                    if (sqlConnection1.State != ConnectionState.Closed)
                    { sqlConnection1.Close(); }
                    Cursor.Current = pCursor;
                    System.Threading.Monitor.Exit(sqlDataAdapter1);//Unlock the sqlconnection
                }
            }

        }


        public void AddRecord(VseDbDataSet.FTP_RecordsRow ftpRow)
        {
            try
            {
                VseDbDataSet.FTP_RecordsRow row = _table.NewFTP_RecordsRow();
                row.ItemArray = ftpRow.ItemArray;//Copy the values	
                _table.AddFTP_RecordsRow(row);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
                throw;//rethrow the same exception
            }
        }

        public void UpdateDb()
        {
            try
            {
                System.Threading.Monitor.Enter(sqlDataAdapter1);//Lock the dataadapter
                if (sqlConnection2.State == ConnectionState.Closed)
                { sqlConnection2.Open(); }

                sqlDataAdapter1.Update(_table);
                _table.Rows.Clear();

            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
                throw;//rethrow the same exception
            }
            finally
            {
                if (sqlConnection2.State != ConnectionState.Closed)
                { sqlConnection2.Close(); }
                System.Threading.Monitor.Exit(sqlDataAdapter1);//Unlock the dataadapter
            }
        }

    }

    public class ConsoleJobStepRecords : AConsoleRecords
    {
        VseDbDataSet.JobStep_RecordsDataTable _table =
            new VseDbDataSet.JobStep_RecordsDataTable();
        #region SqlClient
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlConnection sqlConnection2;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private System.Data.SqlClient.SqlCommand sqlSELECTbyID;
        private System.Data.SqlClient.SqlCommand sqlSELECTbyDT;
        private System.Data.SqlClient.SqlCommand sqlCommandLastID;
        private System.Data.SqlClient.SqlCommand sqlCommandMinDT;
        private System.Data.SqlClient.SqlCommand sqlCommandMaxDT;
        #endregion
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ConsoleJobStepRecords(System.ComponentModel.IContainer container)
        {
            ///
            /// Required for Windows.Forms Class Composition Designer support
            ///
            container.Add(this);
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ConsoleJobStepRecords()
        {
            ///
            /// Required for Windows.Forms Class Composition Designer support
            ///
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlCommandLastID = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
            this.sqlSELECTbyID = new System.Data.SqlClient.SqlCommand();
            this.sqlSELECTbyDT = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandMinDT = new System.Data.SqlClient.SqlCommand();
            this.sqlCommandMaxDT = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "workstation id=DANSDELL;packet size=4096;integrated security=SSPI;data source=\"DA" +
                "NSDELL\\SEEVSE\";persist security info=True;initial catalog=VseDb";
            // 
            // sqlCommandLastID
            // 
            this.sqlCommandLastID.CommandText = "SELECT MAX(Record_ID) AS Expr1 FROM JobStep_Records";
            this.sqlCommandLastID.Connection = this.sqlConnection1;
            // 
            // sqlConnection2
            // 
            this.sqlConnection2.ConnectionString = "workstation id=DANSDELL;packet size=4096;integrated security=SSPI;data source=\"DA" +
                "NSDELL\\SEEVSE\";persist security info=True;initial catalog=VseDb";
            // 
            // sqlSELECTbyID
            // 
            this.sqlSELECTbyID.CommandText = "SELECT JobStep_Records.* FROM JobStep_Records WHERE (Record_ID >= @FirstID) AND (" +
                "Record_ID <= @LastID)";
            this.sqlSELECTbyID.Connection = this.sqlConnection1;
            this.sqlSELECTbyID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FirstID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            this.sqlSELECTbyID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            // 
            // sqlSELECTbyDT
            // 
            this.sqlSELECTbyDT.CommandText = "SELECT JobStep_Records.* FROM JobStep_Records WHERE (Step_End_Time >= @StartTime)" +
                " AND (Step_End_Time <= @EndTime)";
            this.sqlSELECTbyDT.Connection = this.sqlConnection1;
            this.sqlSELECTbyDT.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartTime", System.Data.SqlDbType.DateTime, 8, "Step_End_Time"));
            this.sqlSELECTbyDT.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndTime", System.Data.SqlDbType.DateTime, 8, "Step_End_Time"));
            // 
            // sqlCommandMinDT
            // 
            this.sqlCommandMinDT.CommandText = "SELECT MIN(Step_End_Time) AS Expr1 FROM JobStep_Records";
            this.sqlCommandMinDT.Connection = this.sqlConnection1;
            // 
            // sqlCommandMaxDT
            // 
            this.sqlCommandMaxDT.CommandText = "SELECT MAX(Step_End_Time) AS Expr1 FROM JobStep_Records";
            this.sqlCommandMaxDT.Connection = this.sqlConnection1;
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT Record_ID, PID, Job_Name, Step_Name, Step_Start_Time, Step_End_Time, Durat" +
                "ion_Sec, Cpu_Time_Sec, Total_IO FROM JobStep_Records";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = @"INSERT INTO JobStep_Records(PID, Job_Name, Step_Name, Step_Start_Time, Step_End_Time, Duration_Sec, Cpu_Time_Sec, Total_IO) VALUES (@PID, @Job_Name, @Step_Name, @Step_Start_Time, @Step_End_Time, @Duration_Sec, @Cpu_Time_Sec, @Total_IO); SELECT Record_ID, PID, Job_Name, Step_Name, Step_Start_Time, Step_End_Time, Duration_Sec, Cpu_Time_Sec, Total_IO FROM JobStep_Records WHERE (Job_Name = @Job_Name) AND (Record_ID = @@IDENTITY) AND (Step_Name = @Step_Name) AND (Step_Start_Time = @Step_Start_Time)";
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PID", System.Data.SqlDbType.VarChar, 2, "PID"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Job_Name", System.Data.SqlDbType.VarChar, 8, "Job_Name"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Step_Name", System.Data.SqlDbType.VarChar, 8, "Step_Name"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Step_Start_Time", System.Data.SqlDbType.DateTime, 8, "Step_Start_Time"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Step_End_Time", System.Data.SqlDbType.DateTime, 8, "Step_End_Time"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Duration_Sec", System.Data.SqlDbType.Float, 8, "Duration_Sec"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cpu_Time_Sec", System.Data.SqlDbType.Float, 8, "Cpu_Time_Sec"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Total_IO", System.Data.SqlDbType.Float, 8, "Total_IO"));
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = @"UPDATE JobStep_Records SET PID = @PID, Job_Name = @Job_Name, Step_Name = @Step_Name, Step_Start_Time = @Step_Start_Time, Step_End_Time = @Step_End_Time, Duration_Sec = @Duration_Sec, Cpu_Time_Sec = @Cpu_Time_Sec, Total_IO = @Total_IO WHERE (Job_Name = @Original_Job_Name) AND (Record_ID = @Original_Record_ID) AND (Step_Name = @Original_Step_Name) AND (Step_Start_Time = @Original_Step_Start_Time) AND (Cpu_Time_Sec = @Original_Cpu_Time_Sec OR @Original_Cpu_Time_Sec IS NULL AND Cpu_Time_Sec IS NULL) AND (Duration_Sec = @Original_Duration_Sec OR @Original_Duration_Sec IS NULL AND Duration_Sec IS NULL) AND (PID = @Original_PID OR @Original_PID IS NULL AND PID IS NULL) AND (Step_End_Time = @Original_Step_End_Time OR @Original_Step_End_Time IS NULL AND Step_End_Time IS NULL) AND (Total_IO = @Original_Total_IO OR @Original_Total_IO IS NULL AND Total_IO IS NULL); SELECT Record_ID, PID, Job_Name, Step_Name, Step_Start_Time, Step_End_Time, Duration_Sec, Cpu_Time_Sec, Total_IO FROM JobStep_Records WHERE (Job_Name = @Job_Name) AND (Record_ID = @Record_ID) AND (Step_Name = @Step_Name) AND (Step_Start_Time = @Step_Start_Time)";
            this.sqlUpdateCommand1.Connection = this.sqlConnection2;
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PID", System.Data.SqlDbType.VarChar, 2, "PID"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Job_Name", System.Data.SqlDbType.VarChar, 8, "Job_Name"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Step_Name", System.Data.SqlDbType.VarChar, 8, "Step_Name"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Step_Start_Time", System.Data.SqlDbType.DateTime, 8, "Step_Start_Time"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Step_End_Time", System.Data.SqlDbType.DateTime, 8, "Step_End_Time"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Duration_Sec", System.Data.SqlDbType.Float, 8, "Duration_Sec"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cpu_Time_Sec", System.Data.SqlDbType.Float, 8, "Cpu_Time_Sec"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Total_IO", System.Data.SqlDbType.Float, 8, "Total_IO"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Job_Name", System.Data.SqlDbType.VarChar, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Job_Name", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Record_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Record_ID", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Step_Name", System.Data.SqlDbType.VarChar, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Step_Name", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Step_Start_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Step_Start_Time", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cpu_Time_Sec", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cpu_Time_Sec", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Duration_Sec", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Duration_Sec", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PID", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PID", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Step_End_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Step_End_Time", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Total_IO", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Total_IO", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Record_ID", System.Data.SqlDbType.Int, 4, "Record_ID"));
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = @"DELETE FROM JobStep_Records WHERE (Job_Name = @Original_Job_Name) AND (Record_ID = @Original_Record_ID) AND (Step_Name = @Original_Step_Name) AND (Step_Start_Time = @Original_Step_Start_Time) AND (Cpu_Time_Sec = @Original_Cpu_Time_Sec OR @Original_Cpu_Time_Sec IS NULL AND Cpu_Time_Sec IS NULL) AND (Duration_Sec = @Original_Duration_Sec OR @Original_Duration_Sec IS NULL AND Duration_Sec IS NULL) AND (PID = @Original_PID OR @Original_PID IS NULL AND PID IS NULL) AND (Step_End_Time = @Original_Step_End_Time OR @Original_Step_End_Time IS NULL AND Step_End_Time IS NULL) AND (Total_IO = @Original_Total_IO OR @Original_Total_IO IS NULL AND Total_IO IS NULL)";
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Job_Name", System.Data.SqlDbType.VarChar, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Job_Name", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Record_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Record_ID", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Step_Name", System.Data.SqlDbType.VarChar, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Step_Name", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Step_Start_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Step_Start_Time", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cpu_Time_Sec", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cpu_Time_Sec", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Duration_Sec", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Duration_Sec", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PID", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PID", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Step_End_Time", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Step_End_Time", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Total_IO", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Total_IO", System.Data.DataRowVersion.Original, null));
            // 
            // sqlDataAdapter1
            // 
            this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "JobStep_Records", new System.Data.Common.DataColumnMapping[] {
																																																						 new System.Data.Common.DataColumnMapping("Record_ID", "Record_ID"),
																																																						 new System.Data.Common.DataColumnMapping("PID", "PID"),
																																																						 new System.Data.Common.DataColumnMapping("Job_Name", "Job_Name"),
																																																						 new System.Data.Common.DataColumnMapping("Step_Name", "Step_Name"),
																																																						 new System.Data.Common.DataColumnMapping("Step_Start_Time", "Step_Start_Time"),
																																																						 new System.Data.Common.DataColumnMapping("Step_End_Time", "Step_End_Time"),
																																																						 new System.Data.Common.DataColumnMapping("Duration_Sec", "Duration_Sec"),
																																																						 new System.Data.Common.DataColumnMapping("Cpu_Time_Sec", "Cpu_Time_Sec"),
																																																						 new System.Data.Common.DataColumnMapping("Total_IO", "Total_IO")})});
            this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;

        }
        #endregion

        public override void SetDbName(string dbname)
        {
            //SqlStrings sqlStr = new SqlStrings(dbname);
            sqlConnection1.ConnectionString = SqlManagerSystem.BuildConnection(dbname).ConnectionString;
            sqlConnection2.ConnectionString = SqlManagerSystem.BuildConnection(dbname).ConnectionString;
            _table.Columns["Record_ID"].AutoIncrementSeed = GetLastId() + 1;
        }


        public override int GetLastId()
        {
            int LastId = 0;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                object obj = sqlCommandLastID.ExecuteScalar();
                if (obj != System.DBNull.Value)
                { LastId = (int)obj; }
            }
            catch (System.NullReferenceException nullExc)
            {
                Debug.WriteLine(nullExc.ToString());
                return 0;
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }
            return LastId;
        }

        public VseDbDataSet.JobStep_RecordsDataTable GetIdRange(int firstId, int lastId)
        {
            VseDbDataSet.JobStep_RecordsDataTable jsTable = new VseDbDataSet.JobStep_RecordsDataTable();
            sqlSELECTbyID.Parameters["@FirstID"].Value = firstId;
            sqlSELECTbyID.Parameters["@LastID"].Value = lastId;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                sqlDataAdapter1.SelectCommand = sqlSELECTbyID;
                sqlDataAdapter1.Fill(jsTable);
                sqlDataAdapter1.SelectCommand = sqlSelectCommand1;
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }

            return jsTable;
        }


        public DateTime GetMinDT()
        {
            DateTime DT = System.Windows.Forms.DateTimePicker.MinDateTime;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                object obj = sqlCommandMinDT.ExecuteScalar();
                if (obj != System.DBNull.Value)
                { DT = (DateTime)obj; }
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }
            return DT;
        }

        public DateTime GetMaxDT()
        {
            DateTime DT = System.Windows.Forms.DateTimePicker.MaxDateTime;
            try
            {
                System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
                if (sqlConnection1.State == ConnectionState.Closed)
                { sqlConnection1.Open(); }
                object obj = sqlCommandMaxDT.ExecuteScalar();
                if (obj != System.DBNull.Value)
                { DT = (DateTime)obj; }
            }
            finally
            {
                if (sqlConnection1.State != ConnectionState.Closed)
                { sqlConnection1.Close(); }
                System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
            }
            return DT;
        }

        public void GetDateRange(DateTime firstTime, DateTime lastTime, VseDbDataSet dset)
        {
            using (Cursor pCursor = Cursor.Current)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    System.Threading.Monitor.Enter(sqlDataAdapter1);//Lock the sqlconnection
                    if (sqlConnection1.State == ConnectionState.Closed)
                    { sqlConnection1.Open(); }
                    sqlSELECTbyDT.Parameters["@StartTime"].Value = firstTime;
                    sqlSELECTbyDT.Parameters["@EndTime"].Value = lastTime;

                    sqlDataAdapter1.SelectCommand = sqlSELECTbyDT;
                    sqlDataAdapter1.Fill(dset);
                    sqlDataAdapter1.SelectCommand = sqlSelectCommand1;
                }
                finally
                {
                    if (sqlConnection1.State != ConnectionState.Closed)
                    { sqlConnection1.Close(); }
                    System.Threading.Monitor.Exit(sqlDataAdapter1);//Unlock the sqlconnection
                    Cursor.Current = pCursor;
                }
            }

        }


        public void AddRecord(VseDbDataSet.JobStep_RecordsRow stepRow)
        {
            try
            {
                VseDbDataSet.JobStep_RecordsRow row = _table.NewJobStep_RecordsRow();
                row.ItemArray = stepRow.ItemArray;//Copy the values	
                _table.AddJobStep_RecordsRow(row);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
                throw;//rethrow the same exception
            }
        }

        public void UpdateDb()
        {
            try
            {
                System.Threading.Monitor.Enter(sqlDataAdapter1);//Lock the dataadapter
                if (sqlConnection2.State == ConnectionState.Closed)
                { sqlConnection2.Open(); }

                sqlDataAdapter1.Update(_table);
                _table.Rows.Clear();

            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
                throw;//rethrow the same exception
            }
            finally
            {
                if (sqlConnection2.State != ConnectionState.Closed)
                { sqlConnection2.Close(); }
                System.Threading.Monitor.Exit(sqlDataAdapter1);//Unlock the dataadapter
            }
        }

    }
}
