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
	/// Summary description for ConsoleJobStepRecords.
	/// </summary>
	public class ManJobStepRecs : ManageRecs
	{
		ConsoleDataSet.JobStep_RecordsDataTable _table = 
			new ConsoleDataSet.JobStep_RecordsDataTable();
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
		private System.ComponentModel.Container components = null;
		public ManJobStepRecs(System.ComponentModel.IContainer container)
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
		public ManJobStepRecs()
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
		public ConsoleDataSet.JobStep_RecordsDataTable GetIdRange(int firstId, int lastId)
		{
			ConsoleDataSet.JobStep_RecordsDataTable jsTable = new ConsoleDataSet.JobStep_RecordsDataTable();
			sqlSELECTbyID.Parameters["@FirstID"].Value = firstId;
			sqlSELECTbyID.Parameters["@LastID"].Value = lastId;
			try
			{
				System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
				if(sqlConnection1.State == ConnectionState.Closed)
				{sqlConnection1.Open();}
				sqlDataAdapter1.SelectCommand = sqlSELECTbyID;
				sqlDataAdapter1.Fill(jsTable);
				sqlDataAdapter1.SelectCommand = sqlSelectCommand1;
			}
			finally
			{
				if(sqlConnection1.State != ConnectionState.Closed)
				{sqlConnection1.Close();}
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
					if(sqlConnection1.State == ConnectionState.Closed)
					{sqlConnection1.Open();}
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
		public void AddRecord(ConsoleDataSet.JobStep_RecordsRow stepRow)
		{
			try
			{
				ConsoleDataSet.JobStep_RecordsRow row = _table.NewJobStep_RecordsRow();
				row.ItemArray = stepRow.ItemArray;//Copy the values	
				_table.AddJobStep_RecordsRow(row);
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
