using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace csi.splash
{
	/// <summary>
	/// Represents an application splash screen.
	/// </summary>
	public class Splash : System.Windows.Forms.Form
	{
		#region CLASS AND MEMBER VARIABLES
		protected int ImagePadding = 20;
		protected static int OPACITY_TIMER_INTERVAL = 50;
		protected static double OPACITY_INCREMENT = 0.1;
		protected static double TRANSPARENCY_INCREMENT = -0.1;
		protected static int MAXIMUM_WAIT_TIME = 5000;
		protected static Thread thread = null;
		protected static bool interrupted = false;
		protected double opacityRate = OPACITY_INCREMENT;
		protected static object mutex = new object();
		protected bool joined = false;
		protected IntPtr Window;
		protected static Splash splash = null;
		private static Image Logo;
		protected static string Version;
		protected static string Copyright = "\u00A9 CSI International";
		protected System.Windows.Forms.Timer opacityTimer;
		protected System.Windows.Forms.Label lblCopyright;
		protected System.Windows.Forms.Label lblLogo;
		protected System.Windows.Forms.Panel pnlLogo;
		#endregion
		protected System.Windows.Forms.Panel pnlCopyright;
		protected System.ComponentModel.IContainer components;
				
		#region CONSTRUCTORS AND DECONSTRUCTORS
		/// <summary>
		/// Create an instance of a splash screen.
		/// </summary>
		public Splash()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			lblLogo.Text = Version;
			lblCopyright.Text = Copyright;
			
			if (Logo != null)
			{ 
				lblLogo.Image = Logo;
			
				// Adjust the size of the splash screen based on the size of the image.
				Size size = (Logo == null) ? new Size(300, 200) : lblLogo.Image.Size;
			
				int hPadding = DockPadding.Left + DockPadding.Right + 2 * ImagePadding;
				int vPadding = DockPadding.Top + DockPadding.Bottom + 2 * ImagePadding;

				ClientSize = new Size(size.Width + hPadding, size.Height + vPadding);
		
				// Fade in the splash screen.	
				Opacity = 0.0;
				opacityTimer.Interval = OPACITY_TIMER_INTERVAL;
				opacityTimer.Start();

				
			}
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Splash));
			this.opacityTimer = new System.Windows.Forms.Timer(this.components);
			this.lblCopyright = new System.Windows.Forms.Label();
			this.lblLogo = new System.Windows.Forms.Label();
			this.pnlLogo = new System.Windows.Forms.Panel();
			this.pnlCopyright = new System.Windows.Forms.Panel();
			this.pnlLogo.SuspendLayout();
			this.pnlCopyright.SuspendLayout();
			this.SuspendLayout();
			// 
			// opacityTimer
			// 
			this.opacityTimer.Tick += new System.EventHandler(this.opacityTimer_Tick);
			// 
			// lblCopyright
			// 
			this.lblCopyright.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(191)), ((System.Byte)(175)), ((System.Byte)(148)));
			this.lblCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCopyright.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCopyright.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblCopyright.Image = ((System.Drawing.Image)(resources.GetObject("lblCopyright.Image")));
			this.lblCopyright.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCopyright.Location = new System.Drawing.Point(5, 0);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.Size = new System.Drawing.Size(374, 16);
			this.lblCopyright.TabIndex = 1;
			this.lblCopyright.Text = "ADD COPYRIGHT HERE";
			this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblLogo
			// 
			this.lblLogo.BackColor = System.Drawing.Color.Transparent;
			this.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLogo.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblLogo.ForeColor = System.Drawing.Color.Black;
			this.lblLogo.Location = new System.Drawing.Point(0, 0);
			this.lblLogo.Name = "lblLogo";
			this.lblLogo.Size = new System.Drawing.Size(384, 214);
			this.lblLogo.TabIndex = 0;
			this.lblLogo.Text = "ADD LOGO HERE";
			this.lblLogo.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// pnlLogo
			// 
			this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.pnlLogo.Controls.Add(this.lblLogo);
			this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlLogo.Location = new System.Drawing.Point(0, 5);
			this.pnlLogo.Name = "pnlLogo";
			this.pnlLogo.Size = new System.Drawing.Size(384, 214);
			this.pnlLogo.TabIndex = 2;
			// 
			// pnlCopyright
			// 
			this.pnlCopyright.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(191)), ((System.Byte)(175)), ((System.Byte)(148)));
			this.pnlCopyright.Controls.Add(this.lblCopyright);
			this.pnlCopyright.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCopyright.DockPadding.Left = 5;
			this.pnlCopyright.DockPadding.Right = 5;
			this.pnlCopyright.Location = new System.Drawing.Point(0, 219);
			this.pnlCopyright.Name = "pnlCopyright";
			this.pnlCopyright.Size = new System.Drawing.Size(384, 16);
			this.pnlCopyright.TabIndex = 3;
			// 
			// Splash
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(58)), ((System.Byte)(56)), ((System.Byte)(56)));
			this.ClientSize = new System.Drawing.Size(384, 240);
			this.Controls.Add(this.pnlLogo);
			this.Controls.Add(this.pnlCopyright);
			this.DockPadding.Bottom = 5;
			this.DockPadding.Top = 5;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Splash";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Splash";
			this.TopMost = true;
			this.pnlLogo.ResumeLayout(false);
			this.pnlCopyright.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region DLL IMPORTS
		private static uint SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000;
		private static uint SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001;

		[DllImport("User32")]
		private static extern bool SetForegroundWindow(IntPtr hWND);

		[DllImport("user32.dll", EntryPoint="SystemParametersInfo", SetLastError = true)]
		public static extern bool SystemParametersInfoGet(uint action, uint param, ref uint vparam, uint init);

		[DllImport("user32.dll", EntryPoint="SystemParametersInfo", SetLastError = true)]
		public static extern bool SystemParametersInfoSet(uint action, uint param, uint vparam, uint init);	
		#endregion

		#region CLASS AND MEMBER METHODS
		/// <summary>
		/// Close the splash screen window.  The specified window is activated
		/// and brought to the foreground.
		/// </summary>
		/// <param name="form">Handle of the window to activate.</param>
		static public void CloseWindow(IntPtr window, bool join)
		{
			if (splash != null) 
			{
				splash.Window = window;
				Splash.CloseWindow(join);
				
			} 
			else 
				Cancel(); 
		}

		/// <summary>
		///
		/// </summary>
		static public void CloseWindow(bool join)
		{
			if (splash != null)  
			{
				splash.joined = join;
				splash.CloseWindow();
			}
			else 
				Cancel();
		}


		/// <summary>
		/// Initiate the close of the splash screen window.  Override this 
		/// method to provide any specific actions to be taken before 
		/// closing the window.
		/// </summary>
		protected virtual void CloseWindow() 
		{
			// Fade out the splash window.
			splash.opacityRate = TRANSPARENCY_INCREMENT;
			if (splash.joined == true)
				thread.Join(MAXIMUM_WAIT_TIME);
		}

		/// <summary>
		/// Abort rendering the splash screen window - even when it has not
		/// yet become visible.
		/// </summary>
		private static void Cancel() 
		{
			lock (mutex) 
			{
				interrupted = true;
			}
		}

		/// <summary>
		/// Open the splash screen window from a separate thread.
		/// </summary>
		/// <param name="image">Image to splash</param>
		/// <param name="version">Application version number.</param>
		static public void OpenWindow(Image logo, string copyright, string version)
		{
			// Limit to one splash screen window opened.
			if (splash != null)
				return;
			
			Logo = logo;
			Version = version != null ? version : "";
			Copyright = copyright != null ? copyright : "";
			
			// Execute the splash screen on a separate background thread.
			thread = new Thread(new ThreadStart(Splash.Run));
			thread.IsBackground = true;
			//thread.ApartmentState = ApartmentState.STA;
            thread.SetApartmentState(ApartmentState.STA);
			thread.Name = "Splash";
			thread.Start();
		}
		

		static private void Run() 
		{
			splash = new Splash();
			splash.ShowDialog();
		}

		/// <summary>
		/// Entry point into the splash screen application.
		/// </summary>
		static private void Main()
		{
			splash = new Splash();
			Application.Run(splash);
		}

		/// <summary>
		/// Handle tick events from the opacity timer.  When a tick occurs, the
		/// opacity property of the splash screen is changed by a predetermined 
		/// increment.  When the opacity reaches zero, the form is closed.
		/// </summary>
		/// <param name="sender">Object that caused this event.</param>
		/// <param name="e">Descriptive information about the event.</param>
		private void opacityTimer_Tick(object sender, System.EventArgs e)
		{
			lock (mutex) 
			{
				// Splash screen has been interrupted.
				if (interrupted == true) 
				{
					opacityTimer.Stop();
					thread = null;
					splash = null;
				
					Close();
					return;
				}
			}

			if (opacityRate > 0) // fade image in.
			{
				if (Opacity < 1)
					Opacity += opacityRate;
			}
			else // fade image out.
			{
				if (Opacity > 0)
					Opacity += opacityRate;
				else // image completely faded - close window.
				{
					opacityTimer.Stop();
					thread = null;
					
					uint timeout = 0;

					// Get the current lock timeout.
					bool rc = SystemParametersInfoGet(SPI_GETFOREGROUNDLOCKTIMEOUT, 0, ref timeout, 0);

					// Set the current lock timeout to zero - so the the window 
					// can be brought to the foreground.				
					SystemParametersInfoSet(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, 0, 0);
				
					// Bring the specified window to the foreground.
					rc = SetForegroundWindow(splash.Window);

					// Reset the lock timeout to its initial value.
					SystemParametersInfoSet(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, timeout, 0);
					
					splash = null;
				
					Close();
				}
			}
		}
		#endregion
	} // end of Splash
}
