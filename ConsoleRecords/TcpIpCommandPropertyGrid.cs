using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using System.Runtime.CompilerServices;
using System.Reflection;

//using csi.property;

namespace ConsoleRecords
{
	/// <summary>
	/// Represents a specialized property grid that sets the width of the 
	/// property name column and resize the help section in the grid. 
	/// </summary>
	public class TcpIpCommandPropertyGrid : PropertyGrid
	{
		#region MEMBER VARIABLES
		/// <summary>
		/// Property grid view.
		/// </summary>
		protected object propertyGridView;

		/// <summary>
		/// Thickness of the splitter between the property name and property
		/// value columns. (TODO: dynamically obtain the size.)
		/// </summary>
		private const int SPLITTER_THICKNESS = 4;
		
		/// <summary>
		/// Gap between the longest property name and the property value. 
		/// </summary>
		private int PROPERTY_NAME_GAP = 5;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region CONSTRUCTORS AND DECONSTRUCTORS
		public TcpIpCommandPropertyGrid()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Get a reference to the gridView field.
			propertyGridView = RuntimeHelpers.GetObjectValue(
			  base.GetType().BaseType.InvokeMember(
				"gridView", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance, null, this, null));				
			
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
			// TcpIpCommandPropertyGrid
			// 
			this.Resize += new System.EventHandler(this.TcpIpCommandPropertyGrid_Resize);

		}
		#endregion

		#region MEMBER METHODS 
		
		
        /*
        public int AdjustHelpHeight(int height) 
		{
			int heightToolBar = 0;
			int heightHelpPane;
			int heightPropertyView = 0;
			
			if (Height / 3 < height)
				heightHelpPane = Height / 3;
			else
				heightHelpPane = height;

			PropertyInfo property;
			PropertyInfo controlsProp = GetType().GetProperty("Controls");
			Control.ControlCollection collection = (Control.ControlCollection) controlsProp.GetValue(this, null);
			
			// Adjust the height of each control in the property grid.

			foreach(Control c in collection)
			{
				Type type = c.GetType();
				
				if (type.Name == "GridToolBar") 
				{
					property = type.GetProperty("Height");
					heightToolBar = (int) property.GetValue(c, null);
				}
				else if(type.Name == "DocComment")
				{
					property = type.GetProperty("Height");
					property.SetValue(c, heightHelpPane, null );
					
					property = type.GetProperty("Location");
					property.SetValue(c, new Point(0, heightToolBar + SPLITTER_THICKNESS + heightPropertyView), null);
					
					FieldInfo userSizedField = type.BaseType.GetField("userSized", BindingFlags.Instance | BindingFlags.NonPublic);
					userSizedField.SetValue(c, true); 
					
					c.Refresh();
				}
				else if (type.Name == "PropertyGridView")
				{
					heightPropertyView = Height - (SPLITTER_THICKNESS + heightToolBar) - heightHelpPane;
					property = type.GetProperty("Height");
					property.SetValue(c, heightPropertyView , null);
				} 
			}

			return heightHelpPane;
		}
*/
        /// <summary>
        /// Set the height of the help pane in the grid.  
        /// </summary>
        /// <param name="height">Requested height of the pane.</param>
        /// <returns>Actual adjusted height of the pane.</returns>
        public int AdjustHelpHeight(int height)
        {
            Control toolStrip = null;
            Control docComment = null;
            Control propertyGridView = null;
            Control hotCommands = null;

            int heightToolStrip = 0;
            int heightHelpPane;
            int heightPropertyView = 0;

            if (Height / 3 < height)
                heightHelpPane = Height / 3;
            else
                heightHelpPane = height;

            PropertyInfo property;
            PropertyInfo controlsProp = GetType().GetProperty("Controls");
            Control.ControlCollection collection = (Control.ControlCollection)controlsProp.GetValue(this, null);

            // Adjust the height of each control in the property grid.
            
            foreach (Control c in collection)
            {
                Type type = c.GetType();

                if (type.Name == "ToolStrip")
                    toolStrip = c;
                else if (type.Name == "DocComment")
                    docComment = c;
                else if (type.Name == "PropertyGridView")
                    propertyGridView = c;
                else if (type.Name == "HotCommands")
                    hotCommands = c;
            }

            property = toolStrip.GetType().GetProperty("Height");
            heightToolStrip = (int)property.GetValue(toolStrip, null);
            
            heightPropertyView = Height - (SPLITTER_THICKNESS + heightToolStrip) - heightHelpPane;
            property = propertyGridView.GetType().GetProperty("Height");
            property.SetValue(propertyGridView, heightPropertyView, null);

            property = docComment.GetType().GetProperty("Height");
            property.SetValue(docComment, heightHelpPane, null);

            property = docComment.GetType().GetProperty("Location");
            property.SetValue(docComment, new Point(0, heightToolStrip + SPLITTER_THICKNESS + heightPropertyView), null);

            FieldInfo userSizedField = docComment.GetType().BaseType.GetField("userSized", BindingFlags.Instance | BindingFlags.NonPublic);
            userSizedField.SetValue(docComment, true);

            docComment.Refresh();

            return heightHelpPane;
        }
        
		/// <summary>
		/// Adjust the splitter to best fit the property names in the grid. 
		/// </summary>
		public void AutoPropertySplitter() 
		{
			if (SelectedObject == null)
				return;

			PropertyDescriptorCollection pdc = ((TcpIpCommand) SelectedObject).GetProperties();
			if (pdc.Count == 0)
				return;

			Graphics graphics = Graphics.FromHwnd(Handle);
			int current = 0;
			int maximum = 0;
			
			foreach (VirtualProperty property in pdc)				
			{
				current =  (int) graphics.MeasureString(property.Name, Font).Width + PROPERTY_NAME_GAP + 15;
				if (current > maximum)
					maximum = current;
			}

			MovePropertySplitterTo(maximum);			
		}

		/// <summary>
		/// Move the property splitter to a specific location in the grid.
		/// </summary>
		/// <param name="x"></param>
		public void MovePropertySplitterTo(int x) 
		{
			propertyGridView.GetType().InvokeMember("MoveSplitterTo", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, propertyGridView, new object[] { x });
			this.Refresh();
		}
		#endregion

		#region EVENT HANDLERS
		/// <summary>
		/// Handle resize events.  When the property grid is resized, the
		/// splitter is adjusted to properly display the longest parameter
		/// name. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TcpIpCommandPropertyGrid_Resize(object sender, System.EventArgs e)
		{
			AutoPropertySplitter(); 
		}
		#endregion
	} // end of TcpIpCommandPropertyGrid
}
