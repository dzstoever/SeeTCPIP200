using csi.see.classlib1;
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;

namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for ConsoleTcpipMessages.
	/// </summary>
	public class ManTcpipMessages : ManageRecs
	{
		ConsoleDataSet.TCPIP_MessagesDataTable _table = 
			new ConsoleRecords.ConsoleDataSet.TCPIP_MessagesDataTable();
		#region SqlClient
		private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlConnection sqlConnection2;
		private System.Data.SqlClient.SqlCommand sqlCommandLastID;
		private System.Data.SqlClient.SqlCommand sqlSELECTbyID;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		#endregion
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
        public ManTcpipMessages(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();
            //SetDbName("SeeCommon");
            
		}
		public ManTcpipMessages()
		{
			InitializeComponent();/// Required for Windows.Forms Class Composition Designer support
            //SetDbName("SeeCommon");                                  
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
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=DANSDELL;packet size=4096;integrated security=SSPI;data source=\"DA" +
				"NSDELL\\SEEVSE\";persist security info=True;initial catalog=VseDb";
			// 
			// sqlCommandLastID
			// 
			this.sqlCommandLastID.CommandText = "SELECT MAX(Message_ID) AS Expr1 FROM TCPIP_Messages";
			this.sqlCommandLastID.Connection = this.sqlConnection1;
			// 
			// sqlSELECTbyID
			// 
			this.sqlSELECTbyID.CommandText = "SELECT TCPIP_Messages.* FROM TCPIP_Messages WHERE (Message_ID >= @FirstID) AND (M" +
				"essage_ID <= @LastID)";
			this.sqlSELECTbyID.Connection = this.sqlConnection1;
			this.sqlSELECTbyID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FirstID", System.Data.SqlDbType.Int, 4, "Message_ID"));
			this.sqlSELECTbyID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastID", System.Data.SqlDbType.Int, 4, "Message_ID"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT Message_ID, Time_Stamp, Message_Text FROM TCPIP_Messages";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO TCPIP_Messages(Time_Stamp, Message_Text) VALUES (@Time_Stamp, @Messag" +
				"e_Text); SELECT Message_ID, Time_Stamp, Message_Text FROM TCPIP_Messages WHERE (" +
				"Message_ID = @@IDENTITY)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Time_Stamp", System.Data.SqlDbType.DateTime, 8, "Time_Stamp"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Message_Text", System.Data.SqlDbType.VarChar, 255, "Message_Text"));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE TCPIP_Messages SET Time_Stamp = @Time_Stamp, Message_Text = @Message_Text WHERE (Message_ID = @Original_Message_ID) AND (Message_Text = @Original_Message_Text OR @Original_Message_Text IS NULL AND Message_Text IS NULL) AND (Time_Stamp = @Original_Time_Stamp OR @Original_Time_Stamp IS NULL AND Time_Stamp IS NULL); SELECT Message_ID, Time_Stamp, Message_Text FROM TCPIP_Messages WHERE (Message_ID = @Message_ID)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection2;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Time_Stamp", System.Data.SqlDbType.DateTime, 8, "Time_Stamp"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Message_Text", System.Data.SqlDbType.VarChar, 255, "Message_Text"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Message_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Message_ID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Message_Text", System.Data.SqlDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Message_Text", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Time_Stamp", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Time_Stamp", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Message_ID", System.Data.SqlDbType.Int, 4, "Message_ID"));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM TCPIP_Messages WHERE (Message_ID = @Original_Message_ID) AND (Message_Text = @Original_Message_Text OR @Original_Message_Text IS NULL AND Message_Text IS NULL) AND (Time_Stamp = @Original_Time_Stamp OR @Original_Time_Stamp IS NULL AND Time_Stamp IS NULL)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Message_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Message_ID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Message_Text", System.Data.SqlDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Message_Text", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Time_Stamp", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Time_Stamp", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "TCPIP_Messages", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("Message_ID", "Message_ID"),
																																																						new System.Data.Common.DataColumnMapping("Time_Stamp", "Time_Stamp"),
																																																						new System.Data.Common.DataColumnMapping("Message_Text", "Message_Text")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
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
            _table.Columns["Message_ID"].AutoIncrementSeed = GetLastId() + 1;
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
		public ConsoleDataSet.TCPIP_MessagesDataTable GetIdRange(int firstId, int lastId)
		{
			ConsoleDataSet.TCPIP_MessagesDataTable messageTable = new ConsoleDataSet.TCPIP_MessagesDataTable();
			sqlSELECTbyID.Parameters["@FirstID"].Value = firstId;
			sqlSELECTbyID.Parameters["@LastID"].Value = lastId;
			try
			{
				System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
				
				if(sqlConnection1.State == ConnectionState.Closed)
				{sqlConnection1.Open();}
				sqlDataAdapter1.SelectCommand = sqlSELECTbyID;
				sqlDataAdapter1.Fill(messageTable);
				sqlDataAdapter1.SelectCommand = sqlSelectCommand1;
			}
			finally
			{
				if(sqlConnection1.State != ConnectionState.Closed)
				{sqlConnection1.Close();}
				
				System.Threading.Monitor.Exit(sqlConnection1);//Unlock the sqlconnection
			}
			return messageTable;
		}		
		public void AddRecord(DateTime timestamp, string messagetxt)
		{
			try
			{
				ConsoleDataSet.TCPIP_MessagesRow row = _table.NewTCPIP_MessagesRow();
				row.Time_Stamp = timestamp;
				row.Message_Text = messagetxt;
				_table.Rows.Add(row);
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
                foreach (ConsoleDataSet.TCPIP_MessagesRow mRow in _table.Rows)
                {//This will set the TimeStamp to match the message, ignore commands & Headers
                    if (!mRow.Message_Text.StartsWith(">") && !mRow.Message_Text.StartsWith("-"))
                    { mRow.Time_Stamp = DateUnformatter(mRow.Message_Text.Substring(0, 18)); }
                }

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

        private DateTime DateUnformatter(string date)
        {
            int year = Convert.ToUInt16(date.Substring(0, 4));
            int month = Convert.ToUInt16(date.Substring(4, 2));
            int day = Convert.ToUInt16(date.Substring(6, 2));
            int hour = Convert.ToUInt16(date.Substring(9, 2));
            int minute = Convert.ToUInt16(date.Substring(11, 2));
            int second = Convert.ToUInt16(date.Substring(13, 2));
            int millisecond = Convert.ToUInt16(date.Substring(16, 2));

            return new DateTime(year, month, day, hour, minute, second, millisecond);
        }

	}
}
