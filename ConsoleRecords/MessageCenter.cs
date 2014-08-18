using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

//using csi.seevse.MsdeDataAccess;

namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for MessageCodes.
	/// </summary>
	public class MessageCenter : System.Windows.Forms.UserControl
	{
		#region MEMBER VARIABLES
		private ManageCM managerCM = null;

		private string release;
		public string Release 
		{
			get { return release; }
			set { release = value; }
		}

		private TcpIpMessageCode message;
		/// <summary>
		/// 
		/// </summary>
		public TcpIpMessageCode Message 
		{
			get { return message; }
			set 
			{ 
				message = value;
				OnMessageChanged(value);
			}
		}

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboCode;
		private TcpIpMessageTree treeMessage;
        private System.Windows.Forms.RichTextBox rtbMessage;
		#endregion
        private ToolTip toolTip;
        private TcpIpMessageDropDown dropMessage;
        private HistoryDropDown history;
        private IContainer components;

		#region EVENTS THROWN
		public event OnMessageChangedHandler OnMessageChanged;
		public delegate void OnMessageChangedHandler(TcpIpMessageCode code);
		#endregion

		#region CONSTRUCTORS AND DECONSTRUCTORS
		public MessageCenter()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			//treeMessage.Location = new System.Drawing.Point(comboCode.Location.X, comboCode.Location.Y + comboCode.Height);
			
			dropMessage.Location = new System.Drawing.Point(comboCode.Location.X, comboCode.Location.Y + comboCode.Height);
			history.Location = new System.Drawing.Point(comboCode.Location.X, comboCode.Location.Y + comboCode.Height);
			//history.list.SelectedIndexChanged += new EventHandler(history_SelectedIndexChanged);
			history.list.MouseDown += new MouseEventHandler(history_MouseDown);
			//history.VisibleChanged += new EventHandler(history_VisibleChanged);
			history.list.KeyPress += new KeyPressEventHandler(history_KeyPress);
			history.Leave += new EventHandler(history_Leave);
			treeMessage = dropMessage.treeView;

			treeMessage.MouseDown += new MouseEventHandler(treeMessage_MouseDown);
			treeMessage.KeyPress += new KeyPressEventHandler(treeMessage_KeyPress);
			//dropMessage.VisibleChanged += new EventHandler(dropMessage_VisibleChanged);
			dropMessage.Leave += new EventHandler(dropMessage_Leave);
			//treeMessage.Leave += new EventHandler(treeMessage_Leave);
            dropMessage.treeView.Release = "15E";

            //dzs
            OnMessageChanged += new OnMessageChangedHandler(MessageCenter_OnMessageChanged);
            toolTip.SetToolTip(comboCode,
                "Click the drop down to see all messages." + Environment.NewLine +
                "Right-click the drop down to see recent history.");
		}

        void MessageCenter_OnMessageChanged(TcpIpMessageCode code)
        {}

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
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboCode = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dropMessage = new ConsoleRecords.TcpIpMessageDropDown();
            this.history = new ConsoleRecords.HistoryDropDown();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(600, 32);
            this.panel1.TabIndex = 0;
            // 
            // comboCode
            // 
            this.comboCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboCode.Location = new System.Drawing.Point(5, 5);
            this.comboCode.MaxDropDownItems = 1;
            this.comboCode.Name = "comboCode";
            this.comboCode.Size = new System.Drawing.Size(590, 21);
            this.comboCode.TabIndex = 1;
            this.comboCode.Enter += new System.EventHandler(this.comboCode_Enter);
            this.comboCode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.comboCode_MouseUp);
            this.comboCode.Resize += new System.EventHandler(this.comboCode_Resize);
            this.comboCode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.comboCode_MouseMove);
            this.comboCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboCode_MouseDown);
            this.comboCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboCode_KeyPress);
            this.comboCode.DropDown += new System.EventHandler(this.comboCode_DropDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtbMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(600, 456);
            this.panel2.TabIndex = 0;
            // 
            // rtbMessage
            // 
            this.rtbMessage.BackColor = System.Drawing.Color.Ivory;
            this.rtbMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMessage.Location = new System.Drawing.Point(5, 5);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.ReadOnly = true;
            this.rtbMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbMessage.Size = new System.Drawing.Size(590, 446);
            this.rtbMessage.TabIndex = 0;
            this.rtbMessage.TabStop = false;
            this.rtbMessage.Text = "";
            this.rtbMessage.Resize += new System.EventHandler(this.rtbMessage_VisibleChanged);
            this.rtbMessage.Enter += new System.EventHandler(this.rtbMessage_Enter);
            // 
            // dropMessage
            // 
            this.dropMessage.Location = new System.Drawing.Point(210, 154);
            this.dropMessage.Name = "dropMessage";
            this.dropMessage.Size = new System.Drawing.Size(180, 180);
            this.dropMessage.TabIndex = 2;
            this.dropMessage.Visible = false;
            // 
            // history
            // 
            this.history.Location = new System.Drawing.Point(218, 177);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(180, 180);
            this.history.TabIndex = 3;
            this.history.Visible = false;
            // 
            // MessageCenter
            // 
            this.Controls.Add(this.history);
            this.Controls.Add(this.dropMessage);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MessageCenter";
            this.Size = new System.Drawing.Size(600, 488);
            this.Resize += new System.EventHandler(this.MessageCenter_Resize);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region DLL IMPORTS
		[DllImport("kernel32.dll")]
		public static extern bool Beep(int Frequency, int Duration);
		#endregion

		#region MEMBER METHODS

		/// <summary>
		/// Display an empty message.
		/// </summary>
		private void CenterEmptyMessage() 
		{
			Font fontMessage = new Font("Verdana", (float) 8.25, FontStyle.Italic);
			int center = (int) ((rtbMessage.Height / fontMessage.GetHeight() - 1)/ 2);
			string verticalSpace = "";
			for (int i = 0; i < center; i++)
				verticalSpace += "\n";

			rtbMessage.Clear();

			rtbMessage.SelectionColor = Color.Red;
			rtbMessage.SelectionAlignment = HorizontalAlignment.Center;
			rtbMessage.SelectionFont = fontMessage;
			rtbMessage.AppendText(verticalSpace + "<no message to display>");
			rtbMessage.SelectionColor = Color.Black;
		}
		
		public void Display(TcpIpMessageCode message) 
		{
			Font fontHeader = new Font("Verdana", (float) 8.25, FontStyle.Bold);
			Font fontText = new Font("Verdana", (float)8.25, FontStyle.Regular);
			
			if (message == null)
			{	
				CenterEmptyMessage();
				rtbMessage.Select(0, 0);  // set cursor to beginning of text
				return;
			}

			rtbMessage.Clear();
			rtbMessage.SelectionAlignment = HorizontalAlignment.Left;
			
			TcpIpMessageCode m = (TcpIpMessageCode) message;
			if (m.Level[0] == TcpIpMessageCode.INFORMATIONAL)
				rtbMessage.SelectionColor = Color.Black;
			else if (m.Level[0] == TcpIpMessageCode.WARNING)
				rtbMessage.SelectionColor = Color.Blue;
			else
				rtbMessage.SelectionColor = Color.Red; 
		
			// Title
			rtbMessage.SelectionFont = fontHeader;
			rtbMessage.AppendText(m.Name + "   " + TcpIpMessageCode.LevelFormatter(m.Level[0]) + "\n\n");
		
			// Summary
			rtbMessage.SelectionFont = fontText;
			rtbMessage.SelectionColor = Color.Black;
			rtbMessage.AppendText(m.Summary + "\n\n");
		
			// Details
			rtbMessage.SelectionFont = fontText;
			rtbMessage.SelectionColor = Color.Black;
			rtbMessage.AppendText(m.Detail + "\n\n");

			if (m.SystemAction != null) 
			{
				rtbMessage.SelectionFont = fontHeader;
				rtbMessage.AppendText("System Action:\n\n");
				rtbMessage.SelectionFont = fontText;
				rtbMessage.SelectionIndent = 15;
				rtbMessage.AppendText(m.SystemAction + "\n\n");
				rtbMessage.SelectionIndent = 0;
			}

			if (m.OperatorAction != null) 
			{ 
				rtbMessage.SelectionFont = fontHeader;
				rtbMessage.AppendText("Operator Action:\n\n");
				rtbMessage.SelectionFont = fontText;
				rtbMessage.SelectionIndent = 15;
				rtbMessage.AppendText(m.OperatorAction + "\n\n");
				rtbMessage.SelectionIndent = 0;
			}

			if (m.AdministratorAction != null) 
			{ 
				rtbMessage.SelectionFont = fontHeader;
				rtbMessage.AppendText("Administrator Action:\n\n");
				rtbMessage.SelectionFont = fontText;
				rtbMessage.SelectionIndent = 15;
				rtbMessage.AppendText(m.AdministratorAction + "\n\n");
				rtbMessage.SelectionIndent = 0;
			}

			rtbMessage.Select(0, 0);  // set cursor to beginning of text
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		public bool Lookup(string text) 
		{
			bool duplicate = false;
			
			if (managerCM == null)
				managerCM = new ManageCM();

			comboCode.Text = text.Trim();
			
			object[] result = managerCM.GetMessageByName(release, comboCode.Text);
			if (result != null) 
			{
				Message = new TcpIpMessageCode(
					result[0] is DBNull ? null : (string) result[0], 
					result[2] is DBNull ? null : (string) result[2],
					result[3] is DBNull ? null : (string) result[3], 
					result[4] is DBNull ? null : (string) result[4], 
					result[5] is DBNull ? null : (string) result[5], 
					result[6] is DBNull ? null : (string) result[6]);

				//Display(Message);
			} 
			else
				Message = null;
			
			Display(Message);
			
			if (Message != null) 
			{
				for (int i = 0; i < history.list.Items.Count; i++)
				{
					if (text.ToLower().Equals(history.list.Items[i].ToString().ToLower())) 
					{
						duplicate = true;
						break;
					}
				}

				if (duplicate == false) 
				{
					history.list.Items.Insert(0, text);
					if (history.list.Items.Count > 25)
						history.list.Items.RemoveAt(25);
				}
			}


			if (Message == null) 
			{
				Beep(400, 125);
				return false;
			}
			else 
				return true;
			
		}
		#endregion

		#region EVENT HANDLERS (Message RichTextBox)
		/// <summary>
		/// Handle visible property change events from the rich text box when
		/// the message is undefined.
		/// </summary>
		/// <param name="sender">Object that caused the event.</param>
		/// <param name="e">Descriptive details about the event.</param>
		private void rtbMessage_VisibleChanged(object sender, System.EventArgs e)
		{
			if (Message == null && rtbMessage.Visible == true)
				CenterEmptyMessage();
		}
		#endregion

		#region EVENT HANDLERS (Go Button)
		/// <summary>
		/// Handle a button click event from the Lookup (go) button.  The
		/// text of the combination box is search to find a matching message
		/// code.
		/// </summary>
		/// <param name="sender">Object that caused the event.</param>
		/// <param name="e">Descriptive details about the event.</param>
		private void btnGo_Click(object sender, System.EventArgs e)
		{
			Lookup(comboCode.Text);
		}
		#endregion		

		#region EVENT HANDLERS (Message ComboBox)
		/// <summary>
		/// Flag indicates whether the last mouse movement detected occurred
		/// within the drop down button of the message code combination box.
		/// </summary>
		bool InDropDownButton = false;
		
		/// <summary>
		/// Handle a mouse move event from the message code combination box.
		/// A determination is made to whether the mouse is within the 
		/// boundaries of the combination box drop down button.
		/// </summary>
		/// <param name="sender">Object that caused the event.</param>
		/// <param name="e">Descriptive details about the event.</param>
		private void comboCode_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.X >= comboCode.Width - 2 - SystemInformation.VerticalScrollBarWidth)
				InDropDownButton = true;
			else
				InDropDownButton = false;
		}

		/// <summary>
		/// Handle a drop down event from the message code combination box.
		/// When the message code tree is visible the normal drop down 
		/// box is suppressed.
		/// </summary>
		/// <param name="sender">Object that caused the event.</param>
		/// <param name="e">Descriptive details about the event.</param>
		private void comboCode_DropDown(object sender, System.EventArgs e)
		{
			comboCode.IntegralHeight = !comboCode.IntegralHeight;
			comboCode.IntegralHeight = !comboCode.IntegralHeight;
		}

		/// <summary>
		/// Handle a key press event from the message code combination box.  
		/// The text of the box is searched to find a matching message code. 
		/// </summary>
		/// <param name="sender">Object that caused the event.</param>
		/// <param name="e">Descriptive details about the event.</param>
		private void comboCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 0x0D) 
			{
				Lookup(comboCode.Text);			
				e.Handled = true;
			} 
		}
		
		private void comboCode_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (InDropDownButton == true) 
			{
				if (e.Button == MouseButtons.Right) 
				{
					if (history.Visible == true)
						BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
					else if (dropMessage.Visible == true)
						BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
					else
						BeginInvoke(new ShowHistoryDelegate(ShowHistory));
				}

				if (e.Button == MouseButtons.Left) 
				{
					if (history.Visible == true)
						BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
                    else if (dropMessage.Visible == true)
                        BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
                    else
                    {
                        if (treeMessage.Nodes.Count > 0)
                            BeginInvoke(new ShowMessageDropDownDelegate(ShowMessageDropDown));
                    }
				}
			} 
		}
		#endregion

		#region EVENT HANDLERS (Message Tree)
		/// <summary>
		/// Handle a message tree leave event.  When the user acts outside of
		/// the message tree, hide the tree.
		/// </summary>
		/// <param name="sender">Object that caused the event.</param>
		/// <param name="e">Descriptive details about the event.</param>
		
		
		/// <summary>
		/// Handle a mouse down event from the message code tree.  Set the 
		/// selected node based on the position of the mouse.  When child
		/// node is selected, build the message code and search for the 
		/// full text description. 
		/// </summary>
		/// <param name="sender">Object that caused the event.</param>
		/// <param name="e">Descriptive details about the event.</param>
		/// 
		private void treeMessage_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) 
		{
			treeMessage.SelectedNode = treeMessage.GetNodeAt(e.X, e.Y);
			string text;
			if (treeMessage.SelectedNode.Nodes.Count == 0) 
			{
				text = treeMessage.SelectedNode.Parent.Text + treeMessage.SelectedNode.Text;
				Lookup(text);
				BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
			}
		}
			
		/// <summary>
		/// Handle a key press event from the message tree.  When the return
		/// key is pressed determine the type of node selected.  Parent nodes
		/// are either expanded or collapsed inverse to their current state. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeMessage_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 0x0D) 
			{
				string text;
				TreeNode node = treeMessage.SelectedNode;
				if (node.Nodes.Count == 0)
					text = node.Parent.Text + node.Text;
				else
				{
					if (node.IsExpanded == true)
						node.Collapse();
					else
						node.Expand();

					return;
				}

				Lookup(text);
				BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
			}

			e.Handled = true;
		}

		private void FocusToSearchBox() 
		{
			//btnGo.Enabled = true;
			comboCode.Focus();
			comboCode.SelectionLength = 0;
			comboCode.SelectionStart = comboCode.Text.Length;
			
		}

		private delegate void ShowMessageDropDownDelegate();
		private delegate void ShowHistoryDelegate();
		private delegate void HideMessageDropDownDelegate();
		private delegate void HideHistoryDelegate();
		private delegate void FocusToSearchBoxDelegate();
		private delegate void UnHighlightDelegate();
		/// <summary>
		/// 
		/// </summary>
		private void HideMessageDropDown() 
		{
			dropMessage.Visible = false;
			dropMessage.Enabled = false;
			//btnGo.Enabled = true;
		}

		private void HideHistory() 
		{
			history.Visible = false;
			//btnGo.Enabled = true;
		}

		private void ShowMessageDropDown() 
		{
			//btnGo.Enabled = false;
			dropMessage.Enabled = true;
			dropMessage.Width = this.comboCode.Width;
            
            treeMessage.SelectClosestMessage(comboCode.Text, true);
            dropMessage.Visible = true;
            dropMessage.BringToFront();
            dropMessage.Focus();
		}

		private void ShowHistory() 
		{
			//btnGo.Enabled = false;
			history.Width = this.comboCode.Width;
			int i = history.list.FindString(comboCode.Text, -1);
			if (i >= 0)
				history.list.SelectedIndex = i;
			history.Visible = true;
			history.BringToFront();
			history.Focus();
		}
		#endregion
				
		

		private void dropMessage_Leave(object sender, EventArgs e)
		{
			BeginInvoke(new HideMessageDropDownDelegate(HideMessageDropDown));
			comboCode.SelectionStart = comboCode.Text.Length;
			comboCode.SelectionLength = 0;
			//btnGo.Enabled = true;
		}
		
		private void MessageCenter_Resize(object sender, System.EventArgs e)
		{
			//dropMessage.Height = rtbMessage.Height / 3 > 250 ? 250 : rtbMessage.Height / 3;
			//history.Height = rtbMessage.Height / 3 > 250 ? 250 : rtbMessage.Height / 3;
            int dropHeight = (int)(panel2.Height * 0.90);
            dropMessage.Height = dropHeight;
            history.Height = dropHeight;
		}
		
		private void history_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 0x0D) 
			{
				Lookup(history.list.SelectedItem.ToString());
				BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
			}
		}

		private void history_Leave(object sender, EventArgs e)
		{
			BeginInvoke(new HideHistoryDelegate(HideHistory));
			comboCode.SelectionStart = comboCode.Text.Length;
			comboCode.SelectionLength = 0;
			//btnGo.Enabled = true;
		}

		private void history_MouseDown(object sender, MouseEventArgs e)
		{
			int i = history.list.IndexFromPoint(e.X, e.Y);
			if (i == -1)
				return;
			Lookup(history.list.Items[i].ToString());
			BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
		}

		private void comboCode_Enter(object sender, System.EventArgs e)
		{
			//btnGo.Enabled = true;
			//BeginInvoke(new UnHighlightDelegate(UnHighlight));
		}

		private void UnHighlight() 
		{
			comboCode.SelectionStart = comboCode.Text.Length;
			comboCode.SelectionLength = 0;
		}

		private void comboCode_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			SetCursorPos(comboCode, e.X, e.Y);
		}

		private const int EM_CHARFROMPOS = 0x00D7;

		[StructLayout(LayoutKind.Sequential)]
			public struct POINT
		{
			public System.Int32 x;
			public System.Int32 y;
		}
        // MCCLAIN 20061026 fix PInvoke issue
		//[DllImport("user32.Dll", CharSet=CharSet.Auto)]
		//private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, POINT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(HandleRef hWnd, uint msg, IntPtr wParam, ref POINT lParam);

		[DllImport("user32.Dll", CharSet=CharSet.Auto)]
		private static extern IntPtr FindWindowEx(
			IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);

		private void SetCursorPos(ComboBox cb, int x, int y) 
		{		
			cb.Select(cb.Text.Length, 0);
						
			IntPtr edit = FindWindowEx(cb.Handle, new IntPtr(0), null, null);
			
			POINT pt = new POINT();
			pt.x = x;
			pt.y = y;
            
            IntPtr index = SendMessage(new HandleRef(edit, edit), EM_CHARFROMPOS, new IntPtr(0), ref pt);
            // MCCLAIN 20061026 fix PInvoke issue
            //IntPtr index = SendMessage(edit, EM_CHARFROMPOS, new IntPtr(0), pt);
			if (index.ToInt32() != -1)
				cb.SelectionStart = index.ToInt32();
		}

		private void rtbMessage_Enter(object sender, System.EventArgs e)
		{
			this.panel1.Focus();
		}

		private void comboCode_Resize(object sender, System.EventArgs e)
		{
			comboCode.Focus();
			comboCode.SelectionStart = comboCode.Text.Length;
			comboCode.SelectionLength = 0;
		}
	} // end of MessageCodes
}
