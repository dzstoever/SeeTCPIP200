using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for AConsoleRecords.
	/// </summary>
	public class ManageRecs : System.ComponentModel.Component
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ManageRecs(System.ComponentModel.IContainer container)
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

		public ManageRecs()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			components = new System.ComponentModel.Container();
		}
		#endregion

		public virtual void SetDbName(string dbname)
		{
			Debug.WriteLine("AConsoleRecords.SetDbName...Not Implemented.");
		}
		public virtual int GetLastId()
		{
			Debug.WriteLine("AConsoleRecords.GetLastId...Not Implemented.");
			return 0;
		}
	}
}
