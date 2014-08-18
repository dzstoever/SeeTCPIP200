using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ConsoleRecords 
{
	/// <summary>
	/// Represents a scroll-enhanced rich text box.  The enhance feature allows
	/// the scroll bar of the rich text box to control scrolling of other 
	/// components.
	/// </summary>
	public class ScrollEnhancedRichTextBox : System.Windows.Forms.RichTextBox
	{
		#region MEMBER VARIABLES
		private ArrayList RegisteredControls = new ArrayList();
		private int x;
		private int y;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region CONSTRUCTORS AND DECONSTRUCTORS
		/// <summary>
		/// 
		/// </summary>
		public ScrollEnhancedRichTextBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			SetStyle(ControlStyles.StandardClick, true);
			UpdateStyles();
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
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// WMRichTextBox
			// 
			this.VScroll += new System.EventHandler(this.this_VScroll);
			this.HScroll += new System.EventHandler(this.this_HScroll);
		}
		#endregion	

		#region WINDOWS, EDIT CONTROL, AND STATUS BAR WINDOW MESSAGE CONSTANTS
		private const int WM_USER   = 0x400;
		private const int EM_GETSCROLLPOS = WM_USER+221;
		private const int EM_SETSCROLLPOS = WM_USER+222;
		private const int WM_VSCROLL = 0x115;
		private const int WM_HSCROLL = 0x114;
		private const int WM_MBUTTONDOWN = 0x207;
		private const int WM_MBUTTONDBLCLK = 0X209;

		//private const int SB_LINEUP = 0;
		//private const int SB_LINEDOWN = 1;
		//private const int SB_PAGEUP = 2;
		//private const int SB_PAGEDOWN = 3;
		private const int SB_THUMBPOSITION = 4;
		private const int SB_THUMBTRACK = 5;
		//private const int SB_TOP = 6;
		//private const int SB_BOTTOM = 7;
		//private const int SB_ENDSCROLL = 8;
		#endregion
		
		#region WINDOWS DLLS
		[StructLayout(LayoutKind.Sequential)]
			public struct POINT
		{
			public System.Int32 x;
			public System.Int32 y;
		}
		
		[DllImport("user32.Dll", CharSet=CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int
			msg, IntPtr wParam, out POINT lParam);
		
		[DllImport("user32.Dll", EntryPoint="SendMessage",
			 CharSet=CharSet.Auto)]
		private static extern IntPtr SendMessage1(IntPtr hWnd, int
			msg, IntPtr wParam, ref POINT lParam);
		#endregion
			
		#region MEMBER METHODS
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WM_MBUTTONDOWN:
					break;
				case WM_MBUTTONDBLCLK:
					break;
				case WM_VSCROLL:
					base.WndProc(ref m);
					if ((m.WParam.ToInt32() & 0xffff) == SB_THUMBTRACK)
					{
						this_VScroll(this, EventArgs.Empty);
					}
					if ((m.WParam.ToInt32() & 0xffff) == SB_THUMBPOSITION)
					{
						this_VScroll(this, EventArgs.Empty);
					}
					break;
					
				case WM_HSCROLL:
					base.WndProc(ref m);
					if ((m.WParam.ToInt32() & 0xffff) == SB_THUMBTRACK)
					{
						this_HScroll(this, EventArgs.Empty);
					}
					if ((m.WParam.ToInt32() & 0xffff) == SB_THUMBPOSITION)
					{
						this_HScroll(this, EventArgs.Empty);
					}
					break;

				default:
					base.WndProc(ref m);
					break;
			}
		} 

		/// <summary>
		/// 
		/// </summary>
		/// <param name="control"></param>
		public void RegisterToBeScrolled(Control control) 
		{
			bool registered = false;
			for (int i = 0; i < RegisteredControls.Count; i++) 
			{
				if (RegisteredControls[i].Equals(control)) 
				{
					registered = true;
					break;
				}
			}

			if (registered == false)
				RegisteredControls.Add(control);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="control"></param>
		public void UnregisterToBeScrolled(Control control)
		{
			for (int i = 0; i < RegisteredControls.Count; i++) 
			{
				if (RegisteredControls[i].Equals(control)) 
				{
					RegisteredControls.RemoveAt(i);
					break;
				}
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void GetScrollPos()
		{
			POINT point = new POINT();
			IntPtr res;
			IntPtr wPar = new IntPtr(0);

				res = SendMessage(Handle, EM_GETSCROLLPOS, wPar,
					out point);
			x = point.x;
			y = point.y;
		}

		/// <summary>
		/// 
		/// </summary>
		public void SetScrollPos()
		{
			POINT point = new POINT();
			point.x = x;
			point.y = y;
			IntPtr res;
			IntPtr wPar = new IntPtr(0);
			
			foreach (Control control in RegisteredControls) 
				res = SendMessage1(control.Handle, EM_SETSCROLLPOS, wPar, ref point);
			//for (int i = 0; i < RegisteredControls.Count; i++) 
			//	res = SendMessage1(((Control) RegisteredControls[i]).Handle, EM_SETSCROLLPOS, wPar, ref point);
		}
		#endregion
		
		#region EVENT HANDLERS (Scroll Events)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void this_HScroll(object sender, System.EventArgs e)
		{
			GetScrollPos();
			SetScrollPos();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void this_VScroll(object sender, System.EventArgs e)
		{
			GetScrollPos();
			SetScrollPos();
		}
		#endregion
	} // end of ScrollEnhancedRichTextBox
}
