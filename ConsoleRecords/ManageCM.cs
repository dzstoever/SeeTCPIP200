using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for ManCM.
	/// </summary>
	public class ManageCM : System.ComponentModel.Component
    {
        private System.Data.SqlClient.SqlConnection SeeCM;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ManageCM(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();            
		}
		public ManageCM()
		{
			InitializeComponent();            
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
            this.SeeCM = new System.Data.SqlClient.SqlConnection();
            // 
            // SeeCM
            // 
            this.SeeCM.ConnectionString = "Integrated Security=True;Data Source=.\\SQLEXPRESS;Initial Catalog=SeeCommon;";
            this.SeeCM.FireInfoMessageEventOnUserErrors = false;

		}
		#endregion
        private string _baseTblNameMess = "Messages";
        private string _baseTblNameComm = "Commands";
        private string _baseTblNamePara = "Parameters";

        public ArrayList GetAllMessages(string TcpIpRelease)
        {
            ArrayList messageList = new ArrayList();
            string sqlText = String.Format("SELECT * FROM {0}{1} ",
                _baseTblNameMess, TcpIpRelease);
            SqlCommand sqlSELECT = new SqlCommand(sqlText, SeeCM);
            if (!DesignMode)
            {
                try
                {
                    SeeCM.Open();
                    SqlDataReader sqlReader = sqlSELECT.ExecuteReader();
                    while (sqlReader.Read())//Read each result row
                    {
                        object[] message = new object[sqlReader.FieldCount];
                        int valCnt = sqlReader.GetValues(message);
                        messageList.Add(message);
                    }
                }
                catch (Exception exc)
                { Debug.WriteLine(exc.ToString()); }
                finally
                {
                    if (SeeCM != null && SeeCM.State != ConnectionState.Closed)
                    { SeeCM.Close(); }
                }
            }
            return messageList;
        }
        public object[] GetMessageByName(string TcpIpRelease, string Name)
        {
            object[] message = null;
            string sqlText = String.Format("SELECT * FROM {0}{1} " +
                "WHERE (Name = @Name)", _baseTblNameMess, TcpIpRelease);
            SqlCommand sqlSELECT = new SqlCommand(sqlText, SeeCM);
            sqlSELECT.Parameters.Add("@Name", SqlDbType.VarChar, 7, "Name");
            sqlSELECT.Parameters["@Name"].Value = Name;
            try
            {
                SeeCM.Open();
                SqlDataReader sqlReader = sqlSELECT.ExecuteReader();
                while (sqlReader.Read())//Read each result row
                {
                    message = new object[sqlReader.FieldCount];
                    int valCnt = sqlReader.GetValues(message);
                }
            }
            catch (Exception exc)
            { Debug.WriteLine(exc.ToString()); }
            finally
            {
                if (SeeCM != null && SeeCM.State != ConnectionState.Closed)
                { SeeCM.Close(); }
            }
            return message;
        }
        public ArrayList GetMessagesByFamily(string TcpIpRelease, string Family)
        {
            ArrayList messageList = new ArrayList();
            string sqlText = String.Format("SELECT * FROM {0}{1} " +
                "WHERE (Family = @Family)", _baseTblNameMess, TcpIpRelease);
            SqlCommand sqlSELECT = new SqlCommand(sqlText, SeeCM);
            sqlSELECT.Parameters.Add("@Family", SqlDbType.VarChar, 3, "Family");
            sqlSELECT.Parameters["@Family"].Value = Family;
            try
            {
                SeeCM.Open();
                SqlDataReader sqlReader = sqlSELECT.ExecuteReader();
                while (sqlReader.Read())//Read each result row
                {
                    object[] message = new object[sqlReader.FieldCount];
                    int valCnt = sqlReader.GetValues(message);
                    messageList.Add(message);
                }
            }
            catch (Exception exc)
            { Debug.WriteLine(exc.ToString()); }
            finally
            {
                if (SeeCM != null && SeeCM.State != ConnectionState.Closed)
                { SeeCM.Close(); }
            }
            return messageList;
        }

        public ArrayList GetAllCommands(string TcpIpRelease, string Family)
        {
            ArrayList commandList = new ArrayList();
            string sqlText = String.Format("SELECT * FROM {0}{1} ",
                _baseTblNameComm, TcpIpRelease);
            SqlCommand sqlSELECT = new SqlCommand(sqlText, SeeCM);
            if (!DesignMode)
            {
                try
                {
                    SeeCM.Open();
                    SqlDataReader sqlReader = sqlSELECT.ExecuteReader();
                    while (sqlReader.Read())//Read each result row
                    {
                        object[] command = new object[sqlReader.FieldCount];
                        int valCnt = sqlReader.GetValues(command);
                        commandList.Add(command);
                    }
                }
                catch (Exception exc)
                { Debug.WriteLine(exc.ToString()); }
                finally
                {
                    if (SeeCM != null && SeeCM.State != ConnectionState.Closed)
                    { SeeCM.Close(); }
                }
            }
            return commandList;
        }
        public object[] GetCommandByName(string TcpIpRelease, string Name)
        {
            object[] command = null;
            try
            {
                string sqlText = String.Format("SELECT * FROM {0}{1} " +
                    "WHERE (Name = @Name)", _baseTblNameComm, TcpIpRelease);
                SqlCommand sqlSELECT = new SqlCommand(sqlText, SeeCM);
                sqlSELECT.Parameters.Add("@Name", SqlDbType.VarChar, 32, "Name");
                sqlSELECT.Parameters["@Name"].Value = Name;

                SeeCM.Open();
                SqlDataReader sqlReader = sqlSELECT.ExecuteReader();
                while (sqlReader.Read())//Read each result row
                {
                    command = new object[sqlReader.FieldCount];
                    int valCnt = sqlReader.GetValues(command);
                }
            }
            catch (Exception exc)
            { Debug.WriteLine(exc.ToString()); }
            finally
            {
                if (SeeCM != null && SeeCM.State != ConnectionState.Closed)
                { SeeCM.Close(); }
            }
            return command;
        }
        public object[] GetCommandByShortcut(string TcpIpRelease, string Shortcut)
        {
            object[] command = null;
            try
            {
                string sqlText = String.Format("SELECT * FROM {0}{1} " +
                    "WHERE (Shortcut = @Shortcut)", _baseTblNameComm, TcpIpRelease);
                SqlCommand sqlSELECT = new SqlCommand(sqlText, SeeCM);
                sqlSELECT.Parameters.Add("@Shortcut", SqlDbType.VarChar, 32, "Shortcut");
                sqlSELECT.Parameters["@Shortcut"].Value = Shortcut;

                SeeCM.Open();
                SqlDataReader sqlReader = sqlSELECT.ExecuteReader();
                while (sqlReader.Read())//Read each result row
                {
                    command = new object[sqlReader.FieldCount];
                    int valCnt = sqlReader.GetValues(command);
                }
            }
            catch (Exception exc)
            { Debug.WriteLine(exc.ToString()); }
            finally
            {
                if (SeeCM != null && SeeCM.State != ConnectionState.Closed)
                { SeeCM.Close(); }
            }
            return command;
        }
        public ArrayList GetCommandsByFamily(string TcpIpRelease, string Family)
        {
            ArrayList commandList = new ArrayList();
            string sqlText = String.Format("SELECT * FROM {0}{1} " +
                "WHERE (Family = @Family)", _baseTblNameComm, TcpIpRelease);
            SqlCommand sqlSELECT = new SqlCommand(sqlText, SeeCM);
            sqlSELECT.Parameters.Add("@Family", SqlDbType.VarChar, 32, "Family");
            sqlSELECT.Parameters["@Family"].Value = Family;
            try
            {
                SeeCM.Open();
                SqlDataReader sqlReader = sqlSELECT.ExecuteReader();
                while (sqlReader.Read())//Read each result row
                {
                    object[] command = new object[sqlReader.FieldCount];
                    int valCnt = sqlReader.GetValues(command);
                    commandList.Add(command);
                }
            }
            catch (Exception exc)
            { Debug.WriteLine(exc.ToString()); }
            finally
            {
                if (SeeCM != null && SeeCM.State != ConnectionState.Closed)
                { SeeCM.Close(); }
            }
            return commandList;
        }

        public ArrayList GetParametersByCommandName(string TcpIpRelease, string CommandName)
        {
            ArrayList parameterList = new ArrayList();
            string sqlText = String.Format("SELECT * FROM {0}{1} " +
                "WHERE (CommandName = @CommandName)", _baseTblNamePara, TcpIpRelease);
            SqlCommand sqlSELECT = new SqlCommand(sqlText, SeeCM);
            sqlSELECT.Parameters.Add("@CommandName", SqlDbType.VarChar, 32, "CommandName");
            sqlSELECT.Parameters["@CommandName"].Value = CommandName;
            try
            {
                SeeCM.Open();
                SqlDataReader sqlReader = sqlSELECT.ExecuteReader();
                while (sqlReader.Read())//Read each result row
                {
                    object[] parameter = new object[sqlReader.FieldCount];
                    int valCnt = sqlReader.GetValues(parameter);
                    parameterList.Add(parameter);
                }
            }
            catch (Exception exc)
            { Debug.WriteLine(exc.ToString()); }
            finally
            {
                if (SeeCM != null && SeeCM.State != ConnectionState.Closed)
                { SeeCM.Close(); }
            }
            return parameterList;
        }
        public ArrayList GetParametersByShortcut(string TcpIpRelease, string shortCut)
        {
            ArrayList parameterList = new ArrayList();
            string sqlText = String.Format("SELECT * FROM {0}{1} " +
                "WHERE (Shortcut = @Shortcut)", _baseTblNamePara, TcpIpRelease);
            SqlCommand sqlSELECT = new SqlCommand(sqlText, SeeCM);
            sqlSELECT.Parameters.Add("@Shortcut", SqlDbType.VarChar, 32, "Shortcut");
            sqlSELECT.Parameters["@Shortcut"].Value = shortCut;
            try
            {
                SeeCM.Open();
                SqlDataReader sqlReader = sqlSELECT.ExecuteReader();
                while (sqlReader.Read())//Read each result row
                {
                    object[] parameter = new object[sqlReader.FieldCount];
                    int valCnt = sqlReader.GetValues(parameter);
                    parameterList.Add(parameter);
                }
            }
            catch (Exception exc)
            { Debug.WriteLine(exc.ToString()); }
            finally
            {
                if (SeeCM != null && SeeCM.State != ConnectionState.Closed)
                { SeeCM.Close(); }
            }
            return parameterList;
        }
	
    }
}
