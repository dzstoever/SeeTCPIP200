using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
//using csi.seevse.MsdeDataAccess;

namespace ConsoleRecords
{
	/// <summary>
	/// Represents a console that can page forward and backward through an archive.  
	/// </summary>
	public class PageableConsole : Console, Pageable
	{
		#region MEMBER VARIABLES
		protected ManageRecs manager;
		
		private StatusEventArgs START_OF_CONSOLE = new StatusEventArgs(600, StatusEventArgs.WARNING, "Start of Console");
		private StatusEventArgs END_OF_CONSOLE = new StatusEventArgs(601, StatusEventArgs.WARNING, "End of Console");

		protected bool startOfConsole = false;
		protected bool endOfConsole = false;

		private int current;
		protected int Current 
		{
			get { return current; }
			set { current = value; }
		}

		private String archive;
		protected System.Windows.Forms.ToolBarButton tbFirstPage;
		protected System.Windows.Forms.ToolBarButton tbPreviousPage;
		protected System.Windows.Forms.ToolBarButton tbNextPage;
		protected System.Windows.Forms.ToolBarButton tbLastPage;
		protected System.Windows.Forms.ToolBarButton separator;
		protected System.Windows.Forms.ToolBarButton separator2;
		
		private StatusEventArgs status;
		protected System.Windows.Forms.ToolBarButton separator3;
		protected System.Windows.Forms.ToolBarButton tbLineUp;
		protected System.Windows.Forms.ToolBarButton tbLineDown;
		/// <summary>
		/// Status of the Database connectivity;
		/// </summary>
		protected StatusEventArgs Status 
		{
			get { return status; }
			set 
			{ 
				status = value;
				if (OnDbError != null && OnDbError.GetInvocationList() != null)
					OnDbError(status);
			}
		}

		public String Archive 
		{ 
			get { return archive; }
			set 
			{
				archive = value;

				if (archive != null) 
				{
					manager.SetDbName(value);
					//current = CurrentPage();
					//current = ActiveHalfPage();
					//current = ActivePage(PROPORTIONAL_FULL_PAGE);
				}
			}
		}

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		
		#region EVENTS THROWN
		public event OnDbErrorHandler OnDbError;
		public delegate void OnDbErrorHandler(StatusEventArgs status);
		#endregion

		#region CONSTRUCTORS AND DECONSTRUCTORS
		public PageableConsole()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			rtbConsole.MouseWheel += new MouseEventHandler(rtbConsole_MouseWheel);
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageableConsole));
            this.tbFirstPage = new System.Windows.Forms.ToolBarButton();
            this.tbPreviousPage = new System.Windows.Forms.ToolBarButton();
            this.tbNextPage = new System.Windows.Forms.ToolBarButton();
            this.tbLastPage = new System.Windows.Forms.ToolBarButton();
            this.separator = new System.Windows.Forms.ToolBarButton();
            this.separator2 = new System.Windows.Forms.ToolBarButton();
            this.separator3 = new System.Windows.Forms.ToolBarButton();
            this.tbLineUp = new System.Windows.Forms.ToolBarButton();
            this.tbLineDown = new System.Windows.Forms.ToolBarButton();
            this.SuspendLayout();
            // 
            // toolMain
            // 
            this.toolMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.separator,
            this.tbFirstPage,
            this.tbPreviousPage,
            this.separator2,
            this.tbNextPage,
            this.tbLastPage,
            this.separator3,
            this.tbLineUp,
            this.tbLineDown});
            this.toolMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolMain_ButtonClick);
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            this.images.Images.SetKeyName(3, "");
            this.images.Images.SetKeyName(4, "");
            this.images.Images.SetKeyName(5, "");
            this.images.Images.SetKeyName(6, "");
            this.images.Images.SetKeyName(7, "");
            this.images.Images.SetKeyName(8, "");
            // 
            // rtbConsole
            // 
            this.rtbConsole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbConsole_KeyDown);
            this.rtbConsole.Resize += new System.EventHandler(this.rtbConsole_Resize);
            // 
            // rtbHeader
            // 
            this.rtbHeader.ForeColor = System.Drawing.Color.Blue;
            // 
            // tbFirstPage
            // 
            this.tbFirstPage.ImageIndex = 3;
            this.tbFirstPage.Name = "tbFirstPage";
            this.tbFirstPage.ToolTipText = "First Page";
            // 
            // tbPreviousPage
            // 
            this.tbPreviousPage.ImageIndex = 4;
            this.tbPreviousPage.Name = "tbPreviousPage";
            this.tbPreviousPage.ToolTipText = "Previous Page";
            // 
            // tbNextPage
            // 
            this.tbNextPage.ImageIndex = 5;
            this.tbNextPage.Name = "tbNextPage";
            this.tbNextPage.ToolTipText = "Next Page";
            // 
            // tbLastPage
            // 
            this.tbLastPage.ImageIndex = 6;
            this.tbLastPage.Name = "tbLastPage";
            this.tbLastPage.ToolTipText = "Last Page";
            // 
            // separator
            // 
            this.separator.Enabled = false;
            this.separator.Name = "separator";
            this.separator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // separator2
            // 
            this.separator2.Enabled = false;
            this.separator2.Name = "separator2";
            this.separator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            this.separator3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbLineUp
            // 
            this.tbLineUp.ImageIndex = 7;
            this.tbLineUp.Name = "tbLineUp";
            this.tbLineUp.ToolTipText = "Line Up";
            // 
            // tbLineDown
            // 
            this.tbLineDown.ImageIndex = 8;
            this.tbLineDown.Name = "tbLineDown";
            this.tbLineDown.ToolTipText = "Line Down";
            // 
            // PageableConsole
            // 
            this.DisplaySize = 10;
            this.Name = "PageableConsole";
            this.Load += new System.EventHandler(this.PageableConsole_Load);
            this.ResumeLayout(false);

		}
		#endregion

		#region IMPLEMENTATION (Pageable Members)
		private int pageSize;
		/// <summary>
		/// 
		/// </summary>
		public int PageSize
		{
			get { return pageSize; }
			set { pageSize = value; }
		}

		/// <summary>
		/// Display the next page of the console.
		/// </summary>
		public void NextPage()
		{
			int start, end;
			int lastId;
			int requested = PageSize;

			if (endOfConsole == true) {
				Status = END_OF_CONSOLE;
				return;
			}
				
			dispatcher.Suspend = true;
					
			lastId = GetLastId();
			start = current + 1;
			end = start + requested - 1;
						
			DataTable table = GetData(start, end);
			if (table == null)
			{
				dispatcher.Suspend = false;
				return;
			}

			if (table.Rows.Count < requested)
				endOfConsole = true;
			
			startOfConsole = false;

			Page(table, startOfConsole, endOfConsole);
			
			if (endOfConsole == true)
				Active = true;
			
			dispatcher.Suspend = false;
		}

		/// <summary>
		/// Display the next line of the console.
		/// </summary>
		/// <returns></returns>
		public bool NextLine() 
		{
			int start, end;
			int lastId;
			int requested = PageSize;

			if (endOfConsole == true) 
			{
				Status = END_OF_CONSOLE;
				return false;
			}
				
			dispatcher.Suspend = true;
					
			lastId = GetLastId();
			end = current + 1;
			start = end - (PageSize - 1);
					
			if (start <= 0) 
			{
				start = 1;
				requested = end;
				startOfConsole = true;
			} else
				startOfConsole = false;

			DataTable table = GetData(start, end);
			if (table == null)
			{
				dispatcher.Suspend = false;
				return true;
			}

			if (table.Rows.Count < requested)
				endOfConsole = true;
			
			//startOfConsole = false;

			Page(table, startOfConsole, endOfConsole);
			
			if (endOfConsole == true)
				Active = true;
			
			dispatcher.Suspend = false;

			return true;
		}

		/// <summary>
		/// Display the previous line of the console.
		/// </summary>
		/// <returns></returns>
		public bool PreviousLine() 
		{
			int requested = PageSize;
			int start, end;
			int lastId;

			if (startOfConsole == true && endOfConsole == true) 
			{
				if (GetLastId() >= PageSize - 1) // account for banner
					startOfConsole = false;
			}

			if (startOfConsole == true) 
			{ 
				Status = START_OF_CONSOLE;
				return false;
			}
								
			dispatcher.Suspend = true;

			lastId = GetLastId();

			if (Active == true) 
			{
				end = lastId /* account for end banner */;
				if (rtbConsole.Lines.Length < PageSize)
					requested = rtbConsole.Lines.Length;
			}
			else if (rtbConsole.Lines.Length < PageSize) 
			{
				end = current - 1;
				requested = rtbConsole.Lines.Length;
			}
			else
				end = current - 1;
						
			start = end - requested + 1;
			
			DataTable table = GetData(start, end);
			if (table == null || lastId == -1) 
			{
				dispatcher.Suspend = false;
				return true;
			}
				
			if (table.Rows.Count < requested)
				startOfConsole = true;
			
			if (table.Rows.Count == PageSize) 
			{
				endOfConsole = false;
				Active = false;
			}
			
			dispatcher.Suspend = false;

			Page(table, startOfConsole, endOfConsole);

			return true;
		}

		/// <summary>
		/// Display the previous page of the console.
		/// </summary>
		public void PreviousPage()
		{
			int requested = PageSize;
			int start, end;
			int lastId;

			if (startOfConsole == true && endOfConsole == true) 
			{
				if (GetLastId() >= PageSize - 1) // account for banner
					startOfConsole = false;
			}

			if (startOfConsole == true) 
			{ 
				Status = START_OF_CONSOLE;
				return;
			}
								
			dispatcher.Suspend = true;

			lastId = GetLastId();

			if (Active == true) 
				end = lastId - (rtbConsole.Lines.Length - 1 /* account for end banner */); 
			else
				end = current - PageSize;
						
			start = end - requested + 1;
			
			DataTable table = GetData(start, end);
			if (table == null || lastId == -1) 
			{
				dispatcher.Suspend = false;
				return;
			}
				
			if (table.Rows.Count < requested)
				startOfConsole = true;
			
			endOfConsole = false;
			Active = false;
			
			dispatcher.Suspend = false;

			Page(table, startOfConsole, endOfConsole);
		}

		/// <summary>
		/// Display the first page of the console.
		/// </summary>
		public void FirstPage()
		{					
			if (startOfConsole == true && endOfConsole == true) 
			{
				if (GetLastId() >= PageSize - 1)  // account for banner
					startOfConsole = false;
			}

			if (startOfConsole == true) {
				Status = START_OF_CONSOLE;
				return;
			}

			int requested = PageSize - 1; // account for the start banner

			DataTable table = GetData(1, requested);
			if (table == null)
				return;

			//if (table.Rows.Count < requested)
			//	endOfConsole = true;
			//else 
			//	endOfConsole = false;
			endOfConsole = false;
			startOfConsole = true;

			Active = false;
			
			Page(table, startOfConsole, endOfConsole);
		}

		/// <summary>
		/// Display the last page of the console.
		/// </summary>
		public void LastPage()
		{
			if (endOfConsole == true) 
			{
				Status = END_OF_CONSOLE;
				return;
			}

			ActivePage(HALF_PAGE);
		}

		/// <summary>
		/// Display a page of the console.
		/// </summary>
		/// <param name="table">Contains the lines of console.</param>
		/// <param name="sbanner">Flag indicating whether a start of console banner should be displayed.</param>
		/// <param name="ebanner">Flag indicating whether an end of console banner should be displayed.</param>
		public void Page(DataTable table, bool sbanner, bool ebanner) 
		{
			string text = rtf.Header() + rtf.FontTable() + rtf.ColorTable() + rtf.DocumentDefinition();
			int banners = 0;
			
			if (sbanner == true)
				banners++;
			if (ebanner == true)
				banners++;

			if (sbanner == true && ebanner == false) 
			{
				for (int i = 0; i < PageSize - table.Rows.Count - banners; i++)
					text += FormatText("");

				text += FormatText(START_BANNER);
			} else if (sbanner == true)
				text += FormatText(START_BANNER);

			for (int i = 0; i < table.Rows.Count; i++)
				text += GetTextAt(table, i); 

			if (ebanner == true) 
				text += FormatText(END_BANNER);

			text += rtf.Footer();
			
			rtbConsole.Rtf = text;
			if (ebanner == true)
				ScrollToEnd();

			if (table.Rows.Count > 0)
				Current = GetLastIdIn(table);
		}
		#endregion
		
		#region MEMBER METHODS
				
		private const float HALF_PAGE = 0.5f;
		private const float THREE_FOURTHS_PAGE = 0.75f;
		private const float FULL_PAGE = 1.0f;

		/// <summary>
		/// Display a page on the active console. 
		/// </summary>
		/// <param name="proportion">Percentage of the page to display</param>
		/// <returns>ID of the last record.</returns>
		private int ActivePage(float percentage) 
		{
			int requested; 
			int start, end;
			           			
			dispatcher.Suspend = true;
			
			end = manager.GetLastId();
			requested = (int) (PageSize * percentage) - 1; // account for end banner
			start = end - requested + 1;
			
			DataTable table = GetData(start, end);
			if (table == null || end == -1) 
			{
				dispatcher.Suspend = false;
				return end;
			}
		
			if (start <= 1)
				startOfConsole = true;
			else 
				startOfConsole = false;
			
			endOfConsole = true;
			            					
			Page(table, startOfConsole, endOfConsole);

			Active = true;
			dispatcher.Suspend = false;
			return end;
		}

		/// <summary>
		/// Displays the current page of console records.
		/// </summary>
		/// <returns>Id of the last record in the set.</returns>
		private int CurrentPage() 
		{
			int requested; 
			int start, end;
			           			
			dispatcher.Suspend = true;
			
			if (current == 0 || Active) 
			{
				end = manager.GetLastId();
				requested = PageSize - 1; // account for the end banner 
			}
			else 
			{
				end = current;
				requested = PageSize;
			}

			start = end - requested + 1;
			
			DataTable table = GetData(start, end);
			if (table == null || end == -1) 
			{
				dispatcher.Suspend = false;
				return end;
			}
		
			if (end < PageSize)
				startOfConsole = true;
			else 
				startOfConsole = false;

			if (end == manager.GetLastId()) 
			{
				endOfConsole = true;
				Active = true;
			}
			else
				endOfConsole = false;
            					
			Page(table, startOfConsole, endOfConsole);

			dispatcher.Suspend = false;
			return end;
		}
		
		/// <summary>
		/// Get the ID of the last record in the database.
		/// </summary>
		/// <returns>Last ID: successful >= 0; otherwise -1.</returns>
		protected int GetLastId() 
		{
			try 
			{
				return manager.GetLastId();
			} 
			catch (System.Data.SqlClient.SqlException sqle) 
			{
				Status = new StatusEventArgs(622, StatusEventArgs.SEVERE, sqle.Message);
				return -1;
			}
		}
		#endregion
		
		#region VIRTUAL METHODS
		/// <summary>
		/// Get a table containing the data for the specified ID range.
		/// </summary>
		/// <param name="start">Start ID.</param>
		/// <param name="end">End ID.</param>
		/// <returns>Data table for specified ID range.</returns>
		public virtual DataTable GetData(int start, int end) { return null; }

		/// <summary>
		/// Get the text at a specified row in a data table.
		/// </summary>
		/// <param name="table">Data table.</param>
		/// <param name="row">Row to retrieve text.</param>
		/// <returns>Text from row specified.</returns>
		public virtual string GetTextAt(DataTable table, int row) { return ""; }

		/// <summary>
		/// Get the ID of the last item in the data table.  
		/// </summary>
		/// <param name="table">Data table.</param>
		/// <returns>last ID.</returns>
		public virtual int GetLastIdIn(DataTable table) { return 0; }
		#endregion

		#region EVENT HANDLERS (Toolbar)
		public const int FIRST_PAGE = 4;
		public const int PREVIOUS_PAGE = 5;
		public const int NEXT_PAGE = 7;
		public const int LAST_PAGE = 8;
		public const int PREVIOUS_LINE = 10;
		public const int NEXT_LINE = 11;

		/// <summary>
		/// Handler for receiving a notification of a button click.
		/// </summary>
		/// <param name="sender">Object that caused this event.</param>
		/// <param name="e">Descriptive information about the event.</param>
		private void toolMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (toolMain.Buttons.IndexOf(e.Button))
			{
				case PREVIOUS_PAGE:
					PreviousPage();
					break;
				case NEXT_PAGE:
					NextPage();
					break;
				case FIRST_PAGE:
					FirstPage();
					break;
				case LAST_PAGE:
					LastPage();
					break;
				case PREVIOUS_LINE:
					PreviousLine();
					break;
				case NEXT_LINE:
					NextLine();
					break;
				default:  // ignore other buttons
					break;
			}
		} 
		#endregion

		#region EVENT HANDLERS (Console RTB)
		/// <summary>
		/// Mouse wheel scrolled down.
		/// </summary>
		/// 
		private const bool WHEEL_SCROLL_DOWN = true;
		
		/// <summary>
		/// Mouse wheel scrolled up;
		/// </summary>
		private const bool WHEEL_SCROLL_UP = false;
		
		/// <summary>
		/// According to Microsoft, the value of 120 is currently the standard
		/// for one detent (a rotation of the scroll wheel). 
		/// </summary>
		private const int ONE_DETENT = 120;

		/// <summary>
		/// Handler for receiving resize events from the console.  When the 
		/// console is resized, the lines displayed are adjusted in order
		/// to fit the new console size.
		/// </summary>
		/// <param name="sender">Object that caused this event.</param>
		/// <param name="e">Descriptive information about the event.</param>
		private void rtbConsole_Resize(object sender, System.EventArgs e)
		{
			float adjustedPS = (float) rtbConsole.ClientSize.Height / (float) rtbConsole.Font.Height;	
			
			//adjustedPS--;
					
			// Prevent the page size from becoming zero.
			if (adjustedPS < 1)
				adjustedPS = 1;

			// Determine whether the page size is being increased or decreased.
			bool larger = adjustedPS > PageSize ? true : false;
			
			// Adjust the page and display sizes.
			PageSize = (int) adjustedPS;
			DisplaySize = (int) adjustedPS;


			// Get the lines necessary to display the adjusted page.
			if (dispatcher != null && Archive != null) 
			{
				if (Active) 
				{
					if (larger == false && rtbConsole.Lines.Length > PageSize)
						CurrentPage();
					ScrollToEnd();
				}
				else
					CurrentPage();	
			}
		}

		/// <summary>
		/// Handler for receiving key down events from the console.  
		/// </summary>
		/// <param name="sender">Object that caused this event.</param>
		/// <param name="e">Descriptive information about the event.</param>
		private void rtbConsole_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			FireActionEvent(sender, e);
			if (PagingKeyHandler(e.KeyCode, e.Shift, e.Control, e.Alt) == true) 
				e.Handled = true;
		}
		
		/// <summary>
		/// Handler for receiving events from scrolling the mouse wheel.  The
		/// previous line is retrieved when the mouse is scrolled up.  The 
		/// next line is retrieved when the mouse is scrolled down.  
		/// </summary>
		/// <param name="sender">Object that caused this event.</param>
		/// <param name="e">Descriptive information about the event.</param>
		private void rtbConsole_MouseWheel(object sender, MouseEventArgs e)
		{
			FireActionEvent(sender, e);
			
			bool wheelDirection = e.Delta > 0 ? WHEEL_SCROLL_UP : WHEEL_SCROLL_DOWN;
			
			// Convert the number of detents into rotations of the mouse wheel.
			int wheelRotations = Math.Abs(e.Delta) / ONE_DETENT;
			bool scrolled;

			for (int i = 0; i < wheelRotations; i++) 
			{
				scrolled = wheelDirection == WHEEL_SCROLL_DOWN ? NextLine() : PreviousLine();
				if (scrolled == false)
					return;
			}	
		}

		/// <summary>
		/// Process the paging key pressed.  The following keys are handled:
		///		PageUp, F7				Get previous page.
		///		PageDown, F8			Get next page.
		///		Up						Get previous line.
		///		Down					Get next line.
		///		Home					Get first page.
		///		End						Get last page.
		/// </summary>
		/// <param name="keyCode">Key to process.</param>
		/// <param name="shift">Shift pressed in conjunction with key.</param>
		/// <param name="control">Control pressed in conjuction with key.</param>
		/// <param name="alt">Alt pressed in conjunction with key.</param>
		/// <returns>true when processed; false otherwise.</returns>
		protected bool PagingKeyHandler(Keys keyCode, bool shift, bool control, bool alt) 
		{		
			if (shift == false && control == false && alt == false) 
			{
				if (keyCode == Keys.PageUp || keyCode == Keys.F7) 
				{
					PreviousPage();
					return true;
				}
				else if (keyCode == Keys.PageDown || keyCode == Keys.F8) 
				{
					NextPage();
					return true;
				}
				else if (keyCode == Keys.Up) 
				{
					PreviousLine();
					return true;
				}
				else if (keyCode == Keys.Down) 
				{
					NextLine();
					return true;
				} 
				else if (keyCode == Keys.Home) 
				{
					FirstPage();
					return true;
				}
				else if (keyCode == Keys.End) 
				{
					LastPage();
					return true;
				}
			}
			return false;
		}
		#endregion

		private void PageableConsole_Load(object sender, System.EventArgs e)
		{
			if (DesignMode == false)
				current = ActivePage(HALF_PAGE);
		}
	} // end of PageableConsole
}