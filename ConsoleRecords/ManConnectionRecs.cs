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
	/// Summary description for ConsoleConnectionRecords.
	/// </summary>
	public class ManConnectionRecs : ManageRecs
	{
		ConsoleDataSet.Connection_RecordsDataTable _table = 
			new ConsoleDataSet.Connection_RecordsDataTable();
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

		public ManConnectionRecs(System.ComponentModel.IContainer container)
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

		public ManConnectionRecs()
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

		public ConsoleDataSet.Connection_RecordsDataTable GetIdRange(int firstId, int lastId)
		{
			ConsoleDataSet.Connection_RecordsDataTable connTable = new ConsoleDataSet.Connection_RecordsDataTable();
			sqlSELECTbyID.Parameters["@FirstID"].Value = firstId;
			sqlSELECTbyID.Parameters["@LastID"].Value = lastId;
			try
			{
				System.Threading.Monitor.Enter(sqlConnection1);//Lock the sqlconnection
				if(sqlConnection1.State == ConnectionState.Closed)
				{sqlConnection1.Open();}
				sqlDataAdapter1.SelectCommand = sqlSELECTbyID;
				sqlDataAdapter1.Fill(connTable);
				sqlDataAdapter1.SelectCommand = sqlSelectCommand1;
			}
			finally
			{
				if(sqlConnection1.State != ConnectionState.Closed)
				{sqlConnection1.Close();}
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
				sqlSELECTbyDT.Parameters["@StartTime"].Value = firstTime;
				sqlSELECTbyDT.Parameters["@EndTime"].Value = lastTime;
				try
				{
					System.Threading.Monitor.Enter(sqlDataAdapter1);//Lock the sqlconnection
					if(sqlConnection1.State == ConnectionState.Closed)
					{sqlConnection1.Open();}
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
	

		public void AddRecord(ConsoleDataSet.Connection_RecordsRow connRow)
		{
			try
			{
				ConsoleDataSet.Connection_RecordsRow row = _table.NewConnection_RecordsRow();
				row.ItemArray = connRow.ItemArray;//Copy the values	
				_table.AddConnection_RecordsRow(row);
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
