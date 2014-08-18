namespace csi.see.classlib1
{
    partial class UdpBroadcaster
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
            this.udpport1 = new nsoftware.IPWorks.Udpport(this.components);
            this.udpport2 = new nsoftware.IPWorks.Udpport(this.components);
            // 
            // udpport1
            // 
            this.udpport1.About = "";
            // 
            // udpport2
            // 
            this.udpport2.About = "";
            this.udpport2.OnDataIn += new nsoftware.IPWorks.Udpport.OnDataInHandler(this.udpport2_OnDataIn);

        }

        #endregion

        private nsoftware.IPWorks.Udpport udpport1;
        private nsoftware.IPWorks.Udpport udpport2;

    }
}
