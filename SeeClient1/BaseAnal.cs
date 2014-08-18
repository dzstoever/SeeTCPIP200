using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ConsoleRecords;

namespace csi.see.client1
{
    public partial class BaseAnal : UserControl
    {
        public BaseAnal()
        {
            InitializeComponent();
        }

        public virtual void AddData(DateTime dt) { }
        public virtual void InvokeCrossTabUpdate() { }
        //public virtual void AddData(FtpTerminationRecord record) { }
    }
}
