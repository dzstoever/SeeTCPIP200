using csi.see.classlib1;
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;

namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for ConsoleStartupRecords.
	/// </summary>
	public class ManStartupRecs : ManageRecs
	{
		ConsoleDataSet.Startup_RecordsDataTable _table = 
			new ConsoleDataSet.Startup_RecordsDataTable();
		#region SqlClient
		private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlConnection sqlConnection2;
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
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
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
        public ManStartupRecs(System.ComponentModel.IContainer container)
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
		public ManStartupRecs()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            SqlBase sqlBase = new SqlBase();
            sqlBase.SetDb(dbname);
            sqlConnection1.ConnectionString = sqlBase.ConnectionString;
            sqlConnection2.ConnectionString = sqlBase.ConnectionString;
			_table.Columns["Record_ID"].AutoIncrementSeed = GetLastId() + 1;
		}
		public override int GetLastId()
		{
			int LastId = 0;
			try
			{
				System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
				if(sqlConnection1.State == ConnectionState.Closed)
				{sqlConnection1.Open();}
				object obj = sqlCommandLastID.ExecuteScalar();
				if(obj != System.DBNull.Value)
				{LastId = (int)obj;}
			}
			catch(System.NullReferenceException nullExc)
			{
				Debug.WriteLine(nullExc.ToString());
				return 0;
			}
			finally
			{
				if(sqlConnection1.State != ConnectionState.Closed)
				{sqlConnection1.Close();}
				System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
			}
			return LastId;
		}
		public ConsoleDataSet.Startup_RecordsDataTable GetIdRange(int firstId, int lastId)
		{
			ConsoleDataSet.Startup_RecordsDataTable startTable = new ConsoleDataSet.Startup_RecordsDataTable();
			sqlSELECTbyID.Parameters["@FirstID"].Value = firstId;
			sqlSELECTbyID.Parameters["@LastID"].Value = lastId;
			try
			{
				System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
				if(sqlConnection1.State == ConnectionState.Closed)
				{sqlConnection1.Open();}
				sqlDataAdapter1.SelectCommand = sqlSELECTbyID;
				sqlDataAdapter1.Fill(startTable);
				sqlDataAdapter1.SelectCommand = sqlSelectCommand1;
			}
			finally
			{
				if(sqlConnection1.State != ConnectionState.Closed)
				{sqlConnection1.Close();}
				System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
			}
			return startTable;
		}
	    public DateTime GetMinDT()
		{
			DateTime DT = System.Windows.Forms.DateTimePicker.MinDateTime;
			try
			{
				System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
				if(sqlConnection1.State == ConnectionState.Closed)
				{sqlConnection1.Open();}
				object obj = sqlCommandMinDT.ExecuteScalar();
				if(obj != System.DBNull.Value)
				{DT = (DateTime)obj;}
			}
			finally
			{
				if(sqlConnection1.State != ConnectionState.Closed)
				{sqlConnection1.Close();}
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
				if(sqlConnection1.State == ConnectionState.Closed)
				{sqlConnection1.Open();}
				object obj = sqlCommandMaxDT.ExecuteScalar();
				if(obj != System.DBNull.Value)
				{DT = (DateTime)obj;}
			}
			finally
			{
				if(sqlConnection1.State != ConnectionState.Closed)
				{sqlConnection1.Close();}
				System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
			}
			return DT;
		}
        public void GetDateRange(DateTime firstTime, DateTime lastTime, ConsoleDataSet dset)
		{
			using(Cursor pCursor = Cursor.Current)
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
					if(sqlConnection1.State != ConnectionState.Closed)
					{sqlConnection1.Close();}
					System.Threading.Monitor.Exit(sqlDataAdapter1);//Unlock the sqlconnection
					Cursor.Current = pCursor;
				}
			}
			
		}
	    public void AddRecord(ConsoleDataSet.Startup_RecordsRow startRow)
		{
			try
			{
				ConsoleDataSet.Startup_RecordsRow row = _table.NewStartup_RecordsRow();
				row.ItemArray = startRow.ItemArray;//Copy the values	
				_table.AddStartup_RecordsRow(row);
			}
			catch(Exception exc)
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
				if(sqlConnection2.State == ConnectionState.Closed)
				{sqlConnection2.Open();}

				sqlDataAdapter1.Update(_table);
				_table.Rows.Clear();

			}
			catch(Exception exc)
			{
				Debug.WriteLine(exc.ToString());
				throw;//rethrow the same exception
			}
			finally
			{
				if(sqlConnection2.State != ConnectionState.Closed)
				{sqlConnection2.Close();}
				System.Threading.Monitor.Exit(sqlDataAdapter1);//Unlock the dataadapter
			}
		}

	}
}
