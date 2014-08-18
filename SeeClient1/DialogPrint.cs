using ReportPrinting;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace csi.see.client1
{
	/// <summary>
	/// Summary description for DialogPrint.
	/// </summary>
	public class DialogPrint : System.Windows.Forms.Form
	{
		private PrintDocument _printDocument;
		private ReportPrinting.ReportDocument _reportDocument;
		private ReportPrinting.PrintDataGrid _datagridMaker;
		//private ReportPrinting.ReportBuilder _reportBuilder;
		private ReportPrinting.PrintControlToolBar printControlToolBar1;
		private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DialogPrint(System.Drawing.Printing.PrintDocument printDocument)
		{
			InitializeComponent();// Required for Windows Form Designer support
			textBox1.Text = printDocument.DocumentName;
			_printDocument = printDocument;
			printControlToolBar1.Document = printDocument;
		}

		public DialogPrint(string title, DataGrid dataGrid)
		{
			InitializeComponent();// Required for Windows Form Designer support
			textBox1.Text = title;
			_reportDocument = new ReportDocument();
			
            
            _datagridMaker = new PrintDataGrid(dataGrid);
			_datagridMaker.AddHeader(title);
			_datagridMaker.MakeDocument(_reportDocument);
			printControlToolBar1.Document = _datagridMaker.ReportDocument;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogPrint));
            this.printControlToolBar1 = new ReportPrinting.PrintControlToolBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // printControlToolBar1
            // 
            this.printControlToolBar1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.printControlToolBar1.Document = null;
            this.printControlToolBar1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printControlToolBar1.Location = new System.Drawing.Point(56, 55);
            this.printControlToolBar1.Name = "printControlToolBar1";
            this.printControlToolBar1.Size = new System.Drawing.Size(226, 40);
            this.printControlToolBar1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(16, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(312, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Document Title";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DialogPrint
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(343, 103);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.printControlToolBar1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(352, 144);
            this.MinimizeBox = false;
            this.Name = "DialogPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			if(_datagridMaker != null)
			{_datagridMaker.AddHeader(textBox1.Text);}
            else if(_printDocument != null)
			{_printDocument.DocumentName = textBox1.Text;}
		}

		
	}
}
