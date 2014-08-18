namespace csi.see.service1
{
    partial class ManageComm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.ipportComm = new nsoftware.IPWorks.Ipport(this.components);
            this.ipportData = new nsoftware.IPWorks.Ipport(this.components);
            this.ipportConsole = new nsoftware.IPWorks.Ipport(this.components);
            // 
            // ipportComm
            // 
            this.ipportComm.About = "";
            this.ipportComm.EOL = "";
            this.ipportComm.EOLB = new byte[0];
            this.ipportComm.FirewallPort = 1080;
            this.ipportComm.FirewallType = nsoftware.IPWorks.IpportFirewallTypes.fwNone;
            this.ipportComm.OnDataIn += new nsoftware.IPWorks.Ipport.OnDataInHandler(this.ipportComm_OnDataIn);
            this.ipportComm.OnReadyToSend += new nsoftware.IPWorks.Ipport.OnReadyToSendHandler(this.ipportComm_OnReadyToSend);
            this.ipportComm.OnDisconnected += new nsoftware.IPWorks.Ipport.OnDisconnectedHandler(this.ipportComm_OnDisconnected);
            this.ipportComm.OnConnected += new nsoftware.IPWorks.Ipport.OnConnectedHandler(this.ipportComm_OnConnected);
            // 
            // ipportData
            // 
            this.ipportData.About = "";
            this.ipportData.EOL = "";
            this.ipportData.EOLB = new byte[0];
            this.ipportData.FirewallPort = 1080;
            this.ipportData.FirewallType = nsoftware.IPWorks.IpportFirewallTypes.fwNone;
            this.ipportData.OnDataIn += new nsoftware.IPWorks.Ipport.OnDataInHandler(this.ipportData_OnDataIn);
            this.ipportData.OnReadyToSend += new nsoftware.IPWorks.Ipport.OnReadyToSendHandler(this.ipportData_OnReadyToSend);
            this.ipportData.OnDisconnected += new nsoftware.IPWorks.Ipport.OnDisconnectedHandler(this.ipportData_OnDisconnected);
            this.ipportData.OnConnected += new nsoftware.IPWorks.Ipport.OnConnectedHandler(this.ipportData_OnConnected);
            // 
            // ipportConsole
            // 
            this.ipportConsole.About = "";
            this.ipportConsole.EOL = "";
            this.ipportConsole.EOLB = new byte[0];
            this.ipportConsole.FirewallPort = 1080;
            this.ipportConsole.FirewallType = nsoftware.IPWorks.IpportFirewallTypes.fwNone;
            this.ipportConsole.OnDataIn += new nsoftware.IPWorks.Ipport.OnDataInHandler(this.ipportConsole_OnDataIn);
            this.ipportConsole.OnReadyToSend += new nsoftware.IPWorks.Ipport.OnReadyToSendHandler(this.ipportConsole_OnReadyToSend);
            this.ipportConsole.OnDisconnected += new nsoftware.IPWorks.Ipport.OnDisconnectedHandler(this.ipportConsole_OnDisconnected);
            this.ipportConsole.OnConnected += new nsoftware.IPWorks.Ipport.OnConnectedHandler(this.ipportConsole_OnConnected);

        }

        #endregion

        private nsoftware.IPWorks.Ipport ipportComm;
        private nsoftware.IPWorks.Ipport ipportData;
        private nsoftware.IPWorks.Ipport ipportConsole;
    }
}
