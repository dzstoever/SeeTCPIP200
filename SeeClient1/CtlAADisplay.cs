using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using csi.see.classlib1.DataSets;

namespace csi.see.client1
{
    
    public partial class CtlAADisplay : UserControl
    {
        public CtlAADisplay()
        {
            InitializeComponent();
            string tip1 = "There are two types of charts available:" + Environment.NewLine + 
                Environment.NewLine +
                "Interval (Delta)" + Environment.NewLine +  
                "X : a time interval." + Environment.NewLine +
                "Y : change in value during the interval." + Environment.NewLine +
                "Example: 100 TCP/IP connections were established between 10:00 and 10:05." + Environment.NewLine +
                Environment.NewLine +
                "Totals (Absolute)" + Environment.NewLine +
                "X : a point in time." + Environment.NewLine +
                "Y : actual value for counters that accumulate over time." + Environment.NewLine +
                "Example: 10000 TCP/IP connections were established since the stack was brought up.";
            
            toolTip1.SetToolTip(label1, tip1);
            toolTip1.SetToolTip(comboBox1, tip1); 
        }       
       
        //public virtual void Bind(VseDbDataSet dataSet)
        //{ }
       
    }
}
