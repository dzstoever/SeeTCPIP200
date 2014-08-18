using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
//using csi.util;

namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for Console.
	/// </summary>
	public class Console : System.Windows.Forms.UserControl
	{        
		#region MEMBER VARIABLES
		private System.Timers.Timer selectTimer;

		protected string END_BANNER		= "-------------------- END --------------------";
		protected string START_BANNER	= "------------------- START -------------------";
		protected Rtf rtf = new Rtf();

		private string selectedText;
		public string SelectedText
		{
			get { return selectedText; }
		}
		private string title = "Console";
		protected string Title 
		{
			get { return title; }
			set { title = value; }
		}

		/// <summary>
		/// Active console property.  An active console displays messages as the are received. 
		/// </summary> 
		protected bool active = true;
		public bool Active 
		{
			get { return active; }
			set 
			{ 
				active = value;
                //This dispatcher is fake and will never be connected
				//if (dispatcher != null && dispatcher.IsConnected() == true) 
				//{
					if (active == true)
						rtbConsole.BackColor = Color.White;
					else
                        rtbConsole.BackColor = System.Drawing.SystemColors.Control;
				//} 
				//else
					//rtbConsole.BackColor = System.Drawing.SystemColors.Control;
			}
		}

		protected int displaySize;
		/// <summary>
		/// Display size (number of lines displayed) property.
		/// </summary>
		public int DisplaySize 
		{
			get { return displaySize; }
			set 
			{ 
				displaySize = value; 
			}
		}

		protected ConsoleDispatcher dispatcher;
		public virtual ConsoleDispatcher Dispatcher 
		{
			set 
			{
				dispatcher = value;
				dispatcher.OnConnected += new ConsoleDispatcher.ConnectionHandler(dispatcher_OnConnected);
				dispatcher.OnDisconnected += new ConsoleDispatcher.ConnectionHandler(dispatcher_OnDisconnected);
			}
		}
		
		protected System.Windows.Forms.ToolBar toolMain;
		protected System.Windows.Forms.ToolBarButton tbPrint;
		protected System.Windows.Forms.ImageList images;
		protected System.Windows.Forms.ToolBarButton tbPrintPreview;
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ContextMenu cmnuRightClick;
		private System.Windows.Forms.Panel panel2;
		protected ScrollEnhancedRichTextBox rtbConsole;
		protected System.Windows.Forms.RichTextBox rtbHeader;
		protected System.Windows.Forms.ToolBarButton tbPageSetup;
		private System.Windows.Forms.MenuItem cmnuiCopy;
		#endregion
		public event EventHandler OnAction;
		
		public Console()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			rtbConsole.Click += new EventHandler(rtbConsole_Click);
			toolMain.Parent.BackColor = System.Drawing.SystemColors.Control;
		}
        
        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Console));
            this.cmnuRightClick = new System.Windows.Forms.ContextMenu();
            this.cmnuiCopy = new System.Windows.Forms.MenuItem();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.toolMain = new System.Windows.Forms.ToolBar();
            this.tbPrint = new System.Windows.Forms.ToolBarButton();
            this.tbPrintPreview = new System.Windows.Forms.ToolBarButton();
            this.tbPageSetup = new System.Windows.Forms.ToolBarButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtbHeader = new System.Windows.Forms.RichTextBox();
            this.rtbConsole = new ConsoleRecords.ScrollEnhancedRichTextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmnuRightClick
            // 
            this.cmnuRightClick.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmnuiCopy});
            // 
            // cmnuiCopy
            // 
            this.cmnuiCopy.Index = 0;
            this.cmnuiCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.cmnuiCopy.Text = "Copy";
            this.cmnuiCopy.Click += new System.EventHandler(this.cmnuiCopy_Click);
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            // 
            // toolMain
            // 
            this.toolMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbPrint,
            this.tbPrintPreview,
            this.tbPageSetup});
            this.toolMain.ButtonSize = new System.Drawing.Size(23, 22);
            this.toolMain.DropDownArrows = true;
            this.toolMain.ImageList = this.images;
            this.toolMain.Location = new System.Drawing.Point(0, 0);
            this.toolMain.Name = "toolMain";
            this.toolMain.ShowToolTips = true;
            this.toolMain.Size = new System.Drawing.Size(664, 30);
            this.toolMain.TabIndex = 1;
            this.toolMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolMain_ButtonClick);
            // 
            // tbPrint
            // 
            this.tbPrint.ImageIndex = 0;
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.ToolTipText = "Print";
            // 
            // tbPrintPreview
            // 
            this.tbPrintPreview.ImageIndex = 1;
            this.tbPrintPreview.Name = "tbPrintPreview";
            this.tbPrintPreview.ToolTipText = "Print Preview";
            // 
            // tbPageSetup
            // 
            this.tbPageSetup.ImageIndex = 2;
            this.tbPageSetup.Name = "tbPageSetup";
            this.tbPageSetup.ToolTipText = "Page Setup";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtbHeader);
            this.panel2.Controls.Add(this.toolMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(664, 48);
            this.panel2.TabIndex = 2;
            // 
            // rtbHeader
            // 
            this.rtbHeader.BackColor = System.Drawing.SystemColors.Control;
            this.rtbHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHeader.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rtbHeader.Location = new System.Drawing.Point(0, 30);
            this.rtbHeader.Multiline = false;
            this.rtbHeader.Name = "rtbHeader";
            this.rtbHeader.ReadOnly = true;
            this.rtbHeader.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbHeader.Size = new System.Drawing.Size(664, 18);
            this.rtbHeader.TabIndex = 2;
            this.rtbHeader.Text = "";
            this.rtbHeader.WordWrap = false;
            this.rtbHeader.SelectionChanged += new System.EventHandler(this.rtbConsole_SelectionChanged);
            this.rtbHeader.Enter += new System.EventHandler(this.rtbHeader_Enter);
            // 
            // rtbConsole
            // 
            this.rtbConsole.BackColor = System.Drawing.SystemColors.Control;
            this.rtbConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbConsole.ContextMenu = this.cmnuRightClick;
            this.rtbConsole.DetectUrls = false;
            this.rtbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbConsole.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rtbConsole.Location = new System.Drawing.Point(0, 48);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.rtbConsole.Size = new System.Drawing.Size(664, 568);
            this.rtbConsole.TabIndex = 3;
            this.rtbConsole.TabStop = false;
            this.rtbConsole.Text = "";
            this.rtbConsole.WordWrap = false;
            this.rtbConsole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbConsole_KeyDown);
            this.rtbConsole.SelectionChanged += new System.EventHandler(this.rtbConsole_SelectionChanged);
            // 
            // Console
            // 
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.panel2);
            this.Name = "Console";
            this.Size = new System.Drawing.Size(664, 616);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
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
		
		protected void Append(ArrayList list, bool banner) 
		{
			int count = rtbConsole.Lines.Length;
			if (count == 0) 
			{
				rtbConsole.Rtf = 
					rtf.Header() 
					+ rtf.FontTable() 
					+ rtf.ColorTable() 
					+ rtf.DocumentDefinition() 
					+ FormatText(END_BANNER)
					+ rtf.Footer();
				return;
			}
			
			StringBuilder text = new StringBuilder(DisplaySize * 80);
			text.Append(rtf.Header());
			text.Append(rtf.FontTable());
			text.Append(rtf.ColorTable());
			text.Append(rtf.DocumentDefinition());
							
			for (int i = 0; i < count - 1; i++)
				text.Append(FormatText(rtbConsole.Lines[i]));

			for (int i = 0; i < list.Count; i++)
				text.Append(FormatText(new TcpIpMessage((byte[]) list[i])));

			if (banner == true)
				text.Append(FormatText(END_BANNER));
			text.Append(rtf.Footer());
			rtbConsole.Rtf = text.ToString();
			ScrollToEnd();
		}
		protected void Append(object message) {
			Append(message, true);
		}
		protected void Append(object message, bool banner) 
		{
			int count = rtbConsole.Lines.Length;
			if (count == 0) 
			{
				rtbConsole.Rtf = 
					rtf.Header() 
					+ rtf.FontTable() 
					+ rtf.ColorTable() 
					+ rtf.DocumentDefinition() 
					+ FormatText(END_BANNER)
					+ rtf.Footer();
				return;
			}
			
			StringBuilder text = new StringBuilder(DisplaySize * 80);
			text.Append(rtf.Header());
			text.Append(rtf.FontTable());
			text.Append(rtf.ColorTable());
			text.Append(rtf.DocumentDefinition());

			int i = 0;
			if (count >= DisplaySize && banner == true) i++; // skip first line
            
            for (; i < count - 1 /* skip last line */; i++) 
			{ text.Append(FormatText(rtbConsole.Lines[i])); }
			
			if (message is String)
				text.Append(FormatText(message));
			else
				text.Append(FormatText((TcpIpMessage) message));

			if (banner == true)
				text.Append(FormatText(END_BANNER));
			text.Append(rtf.Footer());

			rtbConsole.Rtf = text.ToString();
			
			ScrollToEnd();
		}
        
        protected void ScrollToEnd() 
		{ SendMessage(rtbConsole.Handle, WM_VSCROLL, SB_BOTTOM, 0); }
		public virtual string FormatText(object text) 
		{
			if (text is string)
				return @"\pard\cf1\fs16 " + text + @"\par";
			else
				return @"\pard\cf1\fs16 " + text.ToString() + @"\par";
		}

		#region DLL IMPORTS  
		const int WM_VSCROLL = 0x115; //&H115;
		const int WM_HSCROLL = 0x114;
		const int SB_BOTTOM = 7;

		[DllImport("kernel32.dll")]
		public static extern bool Beep(int Frequency, int Duration);

		[DllImport("user32", CharSet=CharSet.Auto)] 
		public static extern bool GetScrollRange(IntPtr hWnd, int nBar, out int lpMinPos, out int lpMaxPos); 

		[DllImport("user32", CharSet=CharSet.Auto)] 
		public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
					
		#endregion

		#region EVENT HANDLERS (Dispatcher)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="code"></param>
		/// <param name="description"></param>
		protected virtual void dispatcher_OnConnected(int code, String description) 
		{
			if (this.InvokeRequired)
			{
				BeginInvoke(new ConsoleDispatcher.ConnectionHandler(dispatcher_OnConnected),
					new object[] {code, description});
				return;
			}			
			
			if (code == 0)
				Active = active;

			

		//	if (code == 0) 
		//		rtbConsole.Enabled = true;
		//	else 
		//		rtbConsole.Enabled = false;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="code"></param>
		/// <param name="description"></param>
		protected virtual void dispatcher_OnDisconnected(int code, String description) 
		{
			if (this.InvokeRequired)
			{
				BeginInvoke(new ConsoleDispatcher.ConnectionHandler(dispatcher_OnDisconnected),
					new object[] {code, description});
				return;
			}			

			rtbConsole.BackColor = System.Drawing.SystemColors.Control;

			///Enabled = false;
			//rtbConsole.Enabled = false;
			///for (int i = 0; i < toolMain.Buttons.Count; i++)
			///	toolMain.Buttons[i].Enabled = false;
		}
		#endregion
		
		#region EVENT HANDLERS (Tool Bar)
		public const int PRINT = 0;
		public const int PRINT_PREVIEW = 1;
		public const int PAGE_SETUP = 2;

		private ConsolePrintUtility printUtility = new ConsolePrintUtility();

		/// <summary>
		/// Handler for toolbar button click events.  When a user clicks a
		/// toolbar button, the corresponding action is executed.
		/// </summary>
		/// <param name="sender">Object that caused this event.</param>
		/// <param name="e">Details of the event.</param>
		private void toolMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (OnAction != null && OnAction.GetInvocationList() != null)
				OnAction(sender, e);

			switch (toolMain.Buttons.IndexOf(e.Button))
			{
				case PRINT:
					printUtility.Print(title, rtbHeader.Text, rtbConsole.Text, new Font("Courier New", 9));
					break;
				case PRINT_PREVIEW:
					printUtility.Preview(title, rtbHeader.Text, rtbConsole.Text, new Font("Courier New", 9));
					break;
				case PAGE_SETUP:
					printUtility.PageSetup();
					break;
				default:  // ignore other buttons
					break;
			}
		}
		#endregion

		#region EVENT HANDLERS (Context Menu)
		/// <summary>
		/// Handler for context menu click events.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmnuiCopy_Click(object sender, System.EventArgs e)
		{
			Clipboard.SetDataObject(rtbConsole.SelectedText);
		}
		#endregion

		private void rtbConsole_SelectionChanged(object sender, System.EventArgs e)
		{
			selectedText = rtbConsole.SelectedText;
			if (selectedText.Length > 0) 
			{
				dispatcher.Suspend = true;
			
				if (selectTimer != null)
					selectTimer.Stop();

				selectTimer = new System.Timers.Timer(3000);
				selectTimer.AutoReset = false;
				selectTimer.Elapsed += new System.Timers.ElapsedEventHandler(selectTimer_Elapsed);
				selectTimer.Start();
			}
		}

		private void selectTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			dispatcher.Suspend = false;
		}

		/// <summary>
		/// Handler for enter events on the header.  When a user clicks
		/// on the header, focus is shifted to the rich text box.
		/// </summary>
		/// <param name="sender">Object that caused this event.</param>
		/// <param name="e">Details of the event.</param>
		private void rtbHeader_Enter(object sender, System.EventArgs e)
		{
			rtbConsole.Focus();
		}
		/// <summary>
		/// Handler for click events on the console.  When a user clicks on 
		/// the rich text box, a generalized action event is forwarded to 
		/// any interested listeners.
		/// </summary>
		/// <param name="sender">Object that caused this event.</param>
		/// <param name="e">Details of the event.</param>
		private void rtbConsole_Click(object sender, EventArgs e)
		{
			FireActionEvent(sender, e);
		}

		private void rtbConsole_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			FireActionEvent(sender, e);
		}

		protected void FireActionEvent(object sender, EventArgs e) 
		{
			if (OnAction != null && OnAction.GetInvocationList() != null)
				OnAction(sender, e);
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}
	} // end of Console
}
