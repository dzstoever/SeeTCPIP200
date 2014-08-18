using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace csi.splash
{
	public class SeeVseSplash : csi.splash.Splash
	{
		#region CLASS AND MEMBER VARIABLES
		private const int BLUR_TIMER_INTERVAL = 150;
		private const int FRAME_COUNT = 25;
		private int frame = FRAME_COUNT;
		private Bitmap[] animation = new Bitmap[FRAME_COUNT];	
		private System.Windows.Forms.Timer deblurTimer;
		#endregion

		#region CONSTRUCTORS AND DECONSTRUCTORS
		public SeeVseSplash()	
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			pnlLogo.DockPadding.Top = ImagePadding / 2;
			pnlLogo.DockPadding.Bottom = ImagePadding / 2;
			pnlLogo.DockPadding.Left = ImagePadding;
			pnlLogo.DockPadding.Right = ImagePadding;
						
			int width = pnlLogo.BackgroundImage.Width + 2 * ImagePadding;
			int height = pnlLogo.BackgroundImage.Height + 2 * ImagePadding + DockPadding.Top + DockPadding.Bottom;
			ClientSize = new Size(width, height);
			
			animation[0] = new Bitmap(pnlLogo.BackgroundImage);
			for (int i = 1; i < animation.Length; i++) 
			{
				lock (mutex) 
				{
					if (interrupted == true)
						break;
				}

				animation[i] = (Bitmap) animation[i - 1].Clone();
				if (i > 10) 
				{
					csi.imaging.BitmapFilter.GaussianBlur(animation[i], 1);
					csi.imaging.BitmapFilter.GaussianBlur(animation[i], 1);
				}
				else 
					csi.imaging.BitmapFilter.GaussianBlur(animation[i], 8);
			}
				
			pnlLogo.BackgroundImage = animation[--frame];
			
			// Fade (all at once) in the splash screen.	
			Opacity = 0.0;
			opacityRate = 1.0;
			opacityTimer.Interval = OPACITY_TIMER_INTERVAL;
			opacityTimer.Start();
			
			deblurTimer.Interval = BLUR_TIMER_INTERVAL;
			deblurTimer.Start();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SeeVseSplash));
			this.deblurTimer = new System.Windows.Forms.Timer(this.components);
			this.pnlLogo.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblCopyright
			// 
			this.lblCopyright.Font = new System.Drawing.Font("Verdana", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.Size = new System.Drawing.Size(304, 16);
			// 
			// lblLogo
			// 
			this.lblLogo.Image = ((System.Drawing.Image)(resources.GetObject("lblLogo.Image")));
			this.lblLogo.Name = "lblLogo";
			this.lblLogo.Size = new System.Drawing.Size(304, 214);
			// 
			// pnlLogo
			// 
			this.pnlLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLogo.BackgroundImage")));
			this.pnlLogo.Name = "pnlLogo";
			this.pnlLogo.Size = new System.Drawing.Size(304, 214);
			// 
			// deblurTimer
			// 
			this.deblurTimer.Tick += new System.EventHandler(this.deblurTimer_Tick);
			// 
			// SeeVseSplash
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ClientSize = new System.Drawing.Size(304, 240);
			this.DockPadding.Bottom = 5;
			this.DockPadding.Top = 5;
			this.Name = "SeeVseSplash";
			this.pnlLogo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	
		#region CLASS AND MEMBER METHODS
		/// <summary>
		/// Open the See VSE splash screen window from a separate thread.
		/// </summary>
		/// <param name="copyright">Software copyright.</param>
		/// <param name="version">Application version number.</param>
		static public void OpenWindow(string copyright, string version)
		{
			// Limit to one splash screen window opened.
			if (splash != null)
				return;
			
			Version = version != null ? version : "";
			Copyright = copyright != null ? copyright : "";
			
			// Execute the splash screen on a separate background thread.
			thread = new Thread(new ThreadStart(SeeVseSplash.Run));
			thread.IsBackground = true;
			//thread.ApartmentState = ApartmentState.STA;
            thread.SetApartmentState(ApartmentState.STA);
			thread.Name = "SeeVseSplash";
			thread.Start();
		}
		
		static private void Run() 
		{
			splash = new SeeVseSplash();
			//Application.Run(splash);
			splash.ShowDialog();

		}


		/// <summary>
		/// Entry point into the splash screen application.
		/// </summary>
		static private void Main()
		{
			splash = new SeeVseSplash();
			Application.Run(splash);
		}
			
		/// <summary>
		/// Handle tick events from the blur timer.  When a tick occurs, the
		/// background image of the logo pane is set to the next of the 
		/// animation series.  This produces the unblurring effect. 
		/// increment.  When the blur reaches the end of the series, the 
		/// timer is stopped.
		/// </summary>
		/// <param name="sender">Object that caused this event.</param>
		/// <param name="e">Descriptive information about the event.</param>
		private void deblurTimer_Tick(object sender, System.EventArgs e)
		{
			lock (mutex) 
			{
				if (interrupted == true) 
					frame = 0;
			}

			// Keep the first frame frozen to help establish a visual start to
			// the animation sequence.
			if (frame == FRAME_COUNT - 1) 
				Thread.Sleep(250);

			if (frame < 0) /* animation sequence complete */ 
			{
				deblurTimer.Stop();
				deblurTimer = null;
				return;
			} else
				pnlLogo.BackgroundImage = animation[frame--];
		}

		/// <summary>
		/// Close the splash screen window.
		/// </summary>
		protected override void CloseWindow()
		{
			if (splash != null) 
			{
				while (deblurTimer != null)
					Thread.Sleep(BLUR_TIMER_INTERVAL);

				Thread.Sleep(250);
			}

			base.CloseWindow();
		}
		#endregion
	} // end of SeeVseSplash
}

