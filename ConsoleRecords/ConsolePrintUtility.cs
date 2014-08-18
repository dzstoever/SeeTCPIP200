using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for ConsolePrintUtility.
	/// </summary>
	public class ConsolePrintUtility : System.ComponentModel.Component
	{
		private System.Drawing.Printing.PrintDocument document;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Font font;
		private string title;
		private string header;
		private System.Windows.Forms.PrintDialog dialogPrint;
		private System.Windows.Forms.PrintPreviewDialog dialogPrintPreview;
		private String text;
		private System.Windows.Forms.PageSetupDialog dialogPageSetup;
		private int gridWidth = 1;
		private int page;

		public ConsolePrintUtility(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public ConsolePrintUtility()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();
			
			document.DefaultPageSettings.Landscape = true;
			document.DefaultPageSettings.Margins.Left = 100;
			document.DefaultPageSettings.Margins.Right = 100;
			document.DefaultPageSettings.Margins.Top = 100;
			document.DefaultPageSettings.Margins.Bottom = 100;
			
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


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ConsolePrintUtility));
			this.dialogPrintPreview = new System.Windows.Forms.PrintPreviewDialog();
			this.document = new System.Drawing.Printing.PrintDocument();
			this.dialogPrint = new System.Windows.Forms.PrintDialog();
			this.dialogPageSetup = new System.Windows.Forms.PageSetupDialog();
			// 
			// dialogPrintPreview
			// 
			this.dialogPrintPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.dialogPrintPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.dialogPrintPreview.ClientSize = new System.Drawing.Size(400, 300);
			this.dialogPrintPreview.Document = this.document;
			this.dialogPrintPreview.Enabled = true;
			this.dialogPrintPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("dialogPrintPreview.Icon")));
			this.dialogPrintPreview.Location = new System.Drawing.Point(118, 17);
			this.dialogPrintPreview.MinimumSize = new System.Drawing.Size(375, 250);
			this.dialogPrintPreview.Name = "dialogPrintPreview";
			this.dialogPrintPreview.TransparencyKey = System.Drawing.Color.Empty;
			this.dialogPrintPreview.Visible = false;
			// 
			// document
			// 
			this.document.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.document_BeginPrint);
			this.document.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.document_PrintPage);
			// 
			// dialogPrint
			// 
			this.dialogPrint.Document = this.document;
			// 
			// dialogPageSetup
			// 
			this.dialogPageSetup.Document = this.document;
			this.dialogPageSetup.MinMargins = new System.Drawing.Printing.Margins(50, 50, 50, 50);

		}
		#endregion

		public void Print(string title, string header, string text, Font font)  
		{
			try 
			{
				this.text = text;
				this.header = header;
				this.font = font;
				this.title = title;
				this.document.DocumentName = title;
				
				if  (dialogPrint.ShowDialog() == DialogResult.OK)
					document.Print();
			}
			catch(Exception e)
			{
				Debug.WriteLine(e.Message.ToString());
			}
		}

		public void PageSetup() 
		{
			try 
			{
				dialogPageSetup.ShowDialog();
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message.ToString());
			}
		}

		public void Preview(string title, string text, Font font) 
		{
			try 
			{
				this.text = text;
				this.font = font;
				this.title = title;
				this.document.DocumentName = title;

				
				dialogPrintPreview.ShowDialog();
			}
			catch(Exception e)
			{
				Debug.WriteLine(e.Message.ToString());
			}
		}

		public void Preview(string title, string header, string text, Font font)  
		{
			try 
			{
				this.title = title;
				this.header = header;
				this.text = text;
				this.font = font;
				this.document.DocumentName = title;
				
				foreach (Control c in dialogPrintPreview.Controls)
					if (c.GetType().Name.Equals("PrintPreviewControl"))
						((PrintPreviewControl) c).StartPage = 0;
				
				dialogPrintPreview.ShowDialog();
			}
			catch(Exception e)
			{
				Debug.WriteLine(e.Message.ToString());		
			}
		}
		
		int tcount = 0;
		int region = 0;

		private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			float linesPerPage = 0;
			float yPosition = 0;
			int count = 0;
			float leftMargin = e.MarginBounds.Left;
			float rightMargin = e.MarginBounds.Right;
			float topMargin = e.MarginBounds.Top;

			
			SolidBrush myBrush = new SolidBrush(Color.Black);
			float printArea = rightMargin - leftMargin;
			float xPosition = leftMargin;
			float width;

			yPosition = topMargin + (count++ * font.GetHeight(e.Graphics));
			
			// Print Page Header
			int headerLines = 4;

			// Print title on each page of the document.
			
			
			width = e.Graphics.MeasureString(DateTime.Now.ToString(), font).Width;
			//e.Graphics.DrawString(DateTime.Now.ToString(), font, myBrush, rightMargin - width, yPosition, new StringFormat());
			e.Graphics.DrawString("printed on " + DateTime.Now.ToString(), font, myBrush, leftMargin, yPosition, new StringFormat());
			e.Graphics.DrawString("page " + ++page, font, myBrush, rightMargin - width, yPosition, new StringFormat());
			yPosition = topMargin + (count++ * font.GetHeight(e.Graphics));

			width = e.Graphics.MeasureString(document.DocumentName, font).Width;
			if (width < printArea)
				xPosition = (e.PageBounds.Width - width) / 2;														
		
			e.Graphics.DrawString(document.DocumentName, new Font(font, FontStyle.Bold), myBrush, xPosition, yPosition, new StringFormat());
			yPosition = topMargin + (count++ * font.GetHeight(e.Graphics));
			e.Graphics.DrawString("", new Font(font, FontStyle.Bold), myBrush, leftMargin, yPosition, new StringFormat());
			yPosition = topMargin + (count++ * font.GetHeight(e.Graphics));
			
			myBrush.Color = Color.FromArgb(0, 0, 192);
			e.Graphics.DrawString((string) headers[region], new Font(font, FontStyle.Bold), myBrush, leftMargin, yPosition, new StringFormat());
			myBrush.Color = Color.Black;
			
			// Compute the number of lines per page, using the MarginBounds.
			linesPerPage = e.MarginBounds.Height / font.GetHeight(e.Graphics);

			while (count < linesPerPage && (tcount + (count - headerLines)) < lines) 
			{
				yPosition = topMargin + (count * font.GetHeight(e.Graphics));

				string text = regions[region][tcount + (count - headerLines)].ToString();
				if (text.StartsWith("----------")) 
				{
					myBrush.Color = Color.DarkGray;
					Font fontBanner = new Font(font.FontFamily, 7);
					width = e.Graphics.MeasureString(text, fontBanner).Width;
					if (width < printArea)
						xPosition = (e.PageBounds.Width - width) / 2;
					else
						xPosition = leftMargin;

					e.Graphics.DrawString(text, fontBanner, myBrush, xPosition, yPosition, new StringFormat());
					myBrush.Color = Color.Black;
				} else if (text.StartsWith(">"))
                    e.Graphics.DrawString(text, new Font(font, FontStyle.Bold), myBrush, leftMargin, yPosition, new StringFormat());
				else
					e.Graphics.DrawString(text, font, myBrush, leftMargin, yPosition, new StringFormat());
				
				count++;
			}

			if (region == regions.Length - 1)
				tcount += (count - headerLines);

			if (tcount < lines) 
			{
				region++;
				if (region == regions.Length)
					region = 0;
				e.HasMorePages = true;
			} 
			else 
			{
				region++;
				if (region == regions.Length)
					e.HasMorePages = false;
			}
				
			myBrush.Dispose();
		}

		ArrayList[] regions;
		ArrayList headers;
		int lines;

		private void document_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			tcount = 0;
			region = 0;
			lines = 0;
			page = 0;
			float leftMargin = dialogPageSetup.PageSettings.Bounds.Left + dialogPageSetup.PageSettings.Margins.Left;
			float rightMargin = dialogPageSetup.PageSettings.Bounds.Right - dialogPageSetup.PageSettings.Margins.Right;
			Graphics g = document.PrinterSettings.CreateMeasurementGraphics();
		
			float printArea = rightMargin - leftMargin;
			
			if (printArea < 250) 
			{
				e.Cancel = true;
				return;
			}

			string longestLine = null;
			string line;
			float width;
			StringReader treader = new StringReader(text);
	
			while ((line = treader.ReadLine()) != null) 
			{
				if (longestLine == null || line.Length > longestLine.Length)
                    longestLine = line;
			}
			
			width = g.MeasureString(longestLine, font).Width / printArea;

			int charPerLine = (int) ((float) longestLine.Length / width);


			// Find logical boundary breaks for lines that exceed a single page width.
				

			string theader = header.ToString();
			
			ArrayList breakPoints = new ArrayList();
			headers = new ArrayList();
			int ri = 0;
			int end;

			do 
			{
				if (theader.Length > charPerLine) 
				{ 
					end = charPerLine;
					while (theader[end] == ' ')
						end--;
					
					while (!(theader[end] == ' ' && theader[end - 1] == ' '))
						end--;
					
					breakPoints.Add(++end);
					headers.Add(theader.Substring(0, end));
					theader = theader.Substring(end);
				}
				else 
				{
					end = theader.Length;
					breakPoints.Add(charPerLine);
					headers.Add(theader.Substring(0, end));
					theader = theader.Substring(end);
				}
			} while (theader.Length > 0);
			
			//
			ri = 0;
			gridWidth = 0;
			
			do 
			{
				if (ri == breakPoints.Count) 
				{
					breakPoints.Add(charPerLine);
					headers.Add("");
				}

				if (longestLine.Length > (int) breakPoints[ri]) 
					end = (int) breakPoints[ri];
				else
					end = longestLine.Length;
				
				longestLine = longestLine.Substring(end);
				ri++;
				
			} while (longestLine.Length > 0);



			gridWidth = ri;


			//gridWidth = headers.Count;

					
			regions = new ArrayList[gridWidth];
			for (int i = 0; i < gridWidth; i++)
				regions[i] = new ArrayList(50);
			

			treader = new StringReader(text);

			while ((line = treader.ReadLine()) != null) 
			{
				ri = 0;
				lines++;
				do 
				{
					if (line.Length > (int) breakPoints[ri]) 
						end = (int) breakPoints[ri];
					else
						end = line.Length;

					if (end > 0) 
					{
						regions[ri++].Add(line.Substring(0, end));
						line = line.Substring(end);
					}
					else 
						break;
				
				} while (line.Length > 0);
				
				while (ri < gridWidth)

					regions[ri++].Add("");
			}
		}
	}
}
