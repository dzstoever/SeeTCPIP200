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
	/// Summary description for ConsoleFtpRecords.
	/// </summary>
	public class ManFtpRecs : ManageRecs
	{
		ConsoleDataSet.FTP_RecordsDataTable _table = 
			new ConsoleDataSet.FTP_RecordsDataTable();
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
		public ManFtpRecs(System.ComponentModel.IContainer container)
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
		public ManFtpRecs()
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
        public ConsoleDataSet.FTP_RecordsDataTable GetIdRange(int firstId, int lastId)
		{
			ConsoleDataSet.FTP_RecordsDataTable ftpTable = new ConsoleDataSet.FTP_RecordsDataTable();
			sqlSELECTbyID.Parameters["@FirstID"].Value = firstId;
			sqlSELECTbyID.Parameters["@LastID"].Value = lastId;
			try
			{
				System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
				if(sqlConnection1.State == ConnectionState.Closed)
				{sqlConnection1.Open();}
				sqlDataAdapter1.SelectCommand = sqlSELECTbyID;
				sqlDataAdapter1.Fill(ftpTable);
				sqlDataAdapter1.SelectCommand = sqlSelectCommand1;
			}
			finally
			{
				if(sqlConnection1.State != ConnectionState.Closed)
				{sqlConnection1.Close();}
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
					Cursor.Current = pCursor;
					System.Threading.Monitor.Exit(sqlDataAdapter1);//Unlock the sqlconnection
				}
			}
			
		}
	    public void AddRecord(ConsoleDataSet.FTP_RecordsRow ftpRow)
		{
			try
			{
				ConsoleDataSet.FTP_RecordsRow row = _table.NewFTP_RecordsRow();
				row.ItemArray = ftpRow.ItemArray;//Copy the values	
				_table.AddFTP_RecordsRow(row);
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
