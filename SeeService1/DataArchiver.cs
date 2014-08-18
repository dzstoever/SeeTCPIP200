using csi.see.classlib1;
using ConsoleRecords;
using System;
using System.Collections;
using System.Text;
using System.Diagnostics;

namespace csi.see.service1
{
	/// <summary>
	/// Summary description for ConsoleArchiver.
	/// </summary>
	public class DataArchiver
	{
        public DataArchiver(String dbName)
        {
            managerCTM.SetDbName(dbName);//Messages
            managerCFTR.SetDbName(dbName);//FTPs
            managerCCR.SetDbName(dbName);//Connections
            managerJSR.SetDbName(dbName);//Job Steps
            managerCSR.SetDbName(dbName);//Startups									
        }

        private ManTcpipMessages    managerCTM = new ManTcpipMessages();
        private ManStartupRecs      managerCSR = new ManStartupRecs();
        private ManConnectionRecs   managerCCR = new ManConnectionRecs();
        private ManFtpRecs          managerCFTR = new ManFtpRecs();
        private ManJobStepRecs      managerJSR = new ManJobStepRecs();
		        				
		public bool CacheCommandSent(DateTime timestamp, string command)
        {
            managerCTM.AddRecord(timestamp, command);
            return true;
        }
        public bool CacheTcpIpMessage(DateTime timestamp, string message) 
		{
			managerCTM.AddRecord(timestamp, message);
			return true;
		}
		public bool CacheSeeVseStartupRecord(RecStartup record) 
		{
			ConsoleDataSet ds = new ConsoleDataSet();
			ConsoleDataSet.Startup_RecordsRow row = ds.Startup_Records.NewStartup_RecordsRow();
			
			row.Start_Time = record.StartTime;
			row.Cpu_ID = record.CpuId;
			row.Program_ID = record.ProgramId;
			row.Program_Version = record.ProgramVersion;

			ds.Startup_Records.AddStartup_RecordsRow(row);
			managerCSR.AddRecord(row);
			return true;
		}
        public bool CacheTcpIpTerminationRecord(RecConnection record)
        {
            ConsoleDataSet ds = new ConsoleDataSet();
            ConsoleDataSet.Connection_RecordsRow row = ds.Connection_Records.NewConnection_RecordsRow();

            row.Conn_End_Time = record.EndTime;
            row.Conn_PID = record.PartitionId;
            row.Conn_Protocol = record.ProtocolFormatter(record.Protocol, record.FlagAA);
            row.Conn_Start_Time = record.StartTime;
            row.Conn_State = record.StateFormatter(record.State);
            row.Foreign_IP = record.ForeignIp;
            row.Foreign_Port = record.ForeignPort;
            row.Highest_Depth = record.HighestDepth;
            row.In_Retr_Mode = record.InRetransmitMode;
            row.Inbound_Bytes = record.InboundByte;
            row.Inbound_Bytes_Dup = record.InboundByteDup;
            row.Inbound_Data = record.InboundIBBK;
            row.Inbound_Data_Dup = record.InboundIBBKDup;
            row.Inbound_Eff = record.InboundEfficiency;
            row.INT_EXT = record.LocalCallFormatter(record.LocalCall);
            row.Local_Port = record.LocalPort;
            row.Max_Recv_Window = record.MaxRecvWindow;
            row.Max_Send_Window = record.MaxSendWindow;
            row.Outbound_Bytes = record.OutboundByte;
            row.Outbound_Bytes_Retr = record.OutboundByteDup;
            row.Outbound_Data = record.OutboundIBBK;
            row.Outbound_Data_Retr = record.OutboundIBBKDup;
            row.Outbound_Eff = record.OutboundEfficiency;
            row.Recv_Window_Closed = record.RecvWindowClosed;
            row.Recvs_Issued = record.RcvdSocket;
            row.Retransmits = record.Retransmitted;
            row.Sends_Issued = record.SendSocket;
            row.SWS_Count = record.Sws;

            ds.Connection_Records.AddConnection_RecordsRow(row);
            managerCCR.AddRecord(row);

            return true;
        }
        public bool CacheFtpTerminationRecord(RecFtp record) 
		{
			ConsoleDataSet ds = new ConsoleDataSet();
			ConsoleDataSet.FTP_RecordsRow row = ds.FTP_Records.NewFTP_RecordsRow();
			
			row.FTP_Node_Name = record.FtpNodeName;
			row.FTP_User_ID = record.FtpUserId;
			row.Bytes_SentAcked = record.BytesSentAcked;
			row.Bytes_Received = record.BytesReceived;
			row.Start_Time = record.StartTime;
			row.End_Time = record.EndTime;
			row.Files_Received = record.FilesReceived;
			row.Files_Sent = record.FilesSent;
			row.Vse_IP = record.VseIp;
			row.Client_IP = record.ClientIp;
			row.Vse_Port = record.VsePort;
			row.Client_Port = record.ClientPort;
			row.Vse_Task_ID = record.VseTaskId;
			row.SSL_Flag = record.SslFlag;
			
			row.General_Flag = record.GeneralFlag;
			row.Foreign_Data_IP = record.ForeignDataIp;
			
			ds.FTP_Records.AddFTP_RecordsRow(row);
			managerCFTR.AddRecord(row);

			return true;
		}
        public bool CacheJobStepTerminationRecord(RecJobStep record) 
		{
			ConsoleDataSet ds = new ConsoleDataSet();
			ConsoleDataSet.JobStep_RecordsRow row = ds.JobStep_Records.NewJobStep_RecordsRow();

			row.Cpu_Time_Sec = record.CpuUsed;
			row.Duration_Sec = record.Duration;
			row.Job_Name = record.JobName;
			row.PID = record.PartitionId;
			row.Step_End_Time = record.StepStop;
			row.Step_Name = record.StepName;
			row.Step_Start_Time = record.StepStart;
			row.Total_IO = record.IoCount;
			
			ds.JobStep_Records.AddJobStep_RecordsRow(row);
			managerJSR.AddRecord(row);

			return true;
		}		
		/// <summary>
		/// Update the archive with the cached records for the specified type.
		/// </summary>
		/// <param name="type">Indicates type of records to archive</param>
		/// <returns>ID of the last record added to the database</returns>
		public int UpdateArchive(int type) 
		{
            int recID = 0;
            if (type == ConsoleDispatcher.SEEVSE_STARTUP_TYPE)
            {
                managerCSR.UpdateDb();
                recID = managerCSR.GetLastId();
            }
            //else if (type == ConsoleDispatcher.COMMAND_SENT_TYPE) managerCTM.UpdateDb();
            else if (type == ConsoleDispatcher.TCPIP_MESSAGE_TYPE)
            {
                managerCTM.UpdateDb();
                recID = managerCTM.GetLastId();
            }
            else if (type == ConsoleDispatcher.CONNECTION_TYPE)
            {
                managerCCR.UpdateDb();
                recID = managerCCR.GetLastId();
            }
            else if (type == ConsoleDispatcher.FTP_TERMINATION_TYPE)
            {
                managerCFTR.UpdateDb();
                recID = managerCFTR.GetLastId();
            }
            else if (type == ConsoleDispatcher.JOB_STEP_TERMINATION_TYPE)
            {
                managerJSR.UpdateDb();
                recID = managerJSR.GetLastId();
            }
		
			return recID;
		} 				
		
	}//end of DataArchiver
    
    
}
