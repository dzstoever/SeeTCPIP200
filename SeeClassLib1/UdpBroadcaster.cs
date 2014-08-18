using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace csi.see.classlib1
{
    /// <summary>
    /// Declare two instances of this class to send text messages internally between 
    /// two processes on the same machine.
    /// </summary>
    public partial class UdpBroadcaster : Component
    {
        public UdpBroadcaster()
        {
            InitializeComponent();
        }
        public UdpBroadcaster(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        
        /// <summary>
        /// This event is thrown when a message is recieved.
        /// </summary>
        public event UdpDelegate MessageRcvd;
        private void udpport2_OnDataIn(object sender, nsoftware.IPWorks.UdpportDataInEventArgs e)
        { MessageRcvd(UdpMessage.Convert(e.Datagram)); }//Throw a public event
        
        /// <summary>
        /// This method sets the ports used to send and recieve messages 
        /// and must be called prior to calling Send().
        /// </summary>
        /// <param name="portSend"></param>
        /// <param name="portRecv"></param>
        public void SetPorts(int portSend, int portRecv)
        {
            //Sender
            udpport1.LocalHost = "localhost";
            udpport1.LocalPort = 0;
            udpport1.RemoteHost = "localhost";
            udpport1.RemotePort = portSend;
            udpport1.Active = true;//allow sends & recieves
            udpport1.AcceptData = false;//disable recieves
            //Reciever
            udpport2.LocalHost = "localhost";
            udpport2.LocalPort = portRecv;
            udpport2.RemoteHost = "localhost";
            udpport2.RemotePort = 0;
            udpport2.Active = true;//allow sends & recieves
            udpport2.AcceptData = true;//allow recieves
        }
        /// <summary>
        /// Sends a text message to corresponding listener 
        /// </summary>
        /// <param name="message"></param>
        /// <returns>true - if the message is sent successfully</returns>
        public bool Send(UdpMessage message)
        {
            bool success = true;
            try { udpport1.DataToSend = UdpMessage.Convert(message); }
            catch (Exception e)
            {
                success = false;
                Debug.WriteLine(e.ToString());
            }
            return success;
        }       
        
    }

    public class UdpMessage
    {
        public UdpMessage(){}
        public UdpMessage(int type, DateTime timestamp, string recipient, string info)
        {
            
            Type = type;
            Timestamp = timestamp;
            Recipient = recipient;
            Info = info;
        }

        private static string split = "_#_";
        public int Type = 0;        //This is the message category 
        public DateTime Timestamp;  //This will be sent as the number of ticks
        public string Recipient;       //This is the name of the System it pertains to        
        public string Info;         //This is additional information
        
        public static UdpMessage Convert(string txt)
        {         
            string[] parts = txt.Split(new string[1] { UdpMessage.split }, StringSplitOptions.None);
            UdpMessage message = new UdpMessage();

            message.Type = System.Convert.ToInt32(parts[0]);
            message.Timestamp = new DateTime(System.Convert.ToInt64(parts[1]));
            message.Recipient = parts[2];
            message.Info = parts[3];

            return message;
        }
        public static string Convert(UdpMessage message)
        {
            string s1 = message.Type.ToString();
            string s2 = message.Timestamp.Ticks.ToString();
            string s3 = message.Recipient;
            string s4 = message.Info;

            return s1 + UdpMessage.split + s2 + UdpMessage.split + s3 + UdpMessage.split + s4;
        }
    }

    
}
