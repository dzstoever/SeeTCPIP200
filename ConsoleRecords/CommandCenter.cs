using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
//using csi.seevse.MsdeDataAccess;

//using csi.property;

namespace ConsoleRecords
{
	/// <summary>
	/// Represents a command center to search and display documention and  
	/// parameter settings for TCP/IP for VSE commands.
	/// </summary>
	public class CommandCenter : System.Windows.Forms.UserControl
	{
		#region MEMBER VARIABLES
		private Parameters available;
		private ManageCM managerCM = null;
		
		private string release;
		public string Release 
		{
			get { return release; }
			set { release = value; }
		}
		
		private TcpIpCommand tcpIpCommand;
		public TcpIpCommand TcpIpCommand 
		{
			get { return tcpIpCommand; } 
			set 
			{
				if (tcpIpCommand != null 
					&& value != null 
					&& tcpIpCommand.Name.Equals(((TcpIpCommand)value).Name))
					return;

				if (tcpIpCommand != null && value == null) 
				{
					Display(value);
					comboCommand.Text = "";
				}

				tcpIpCommand = value;
				gridCommand.SelectedObject = value;
								
				if (value != null) 
				{
					//tcpIpCommand.OnPropertyError += new csi.seevse.TcpIpCommand.OnPropertyErrorHandler(tcpIpCommand_OnPropertyError);
					gridCommand.AdjustHelpHeight(100);
					 gridCommand.AutoPropertySplitter();

					comboCommand.Text = tcpIpCommand.Name;
					Display(tcpIpCommand);
					available = new Parameters(tcpIpCommand);
					foreach (VirtualProperty vp in TcpIpCommand.GetProperties()) 
						available.Add(vp, false);
				}
			}
		}

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RichTextBox rtbDocumentation;
		private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ComboBox comboCommand;
		//private csi.seevse.HistoryDropDown dropHistory;
		//private csi.seevse.TcpIpCommandDropDown dropCommand;
		private TcpIpCommandTree treeCommand;
		private TcpIpCommandPropertyGrid gridCommand;
		public TcpIpCommandPropertyGrid PropertyGrid 
		{
			get { return gridCommand; }
        }
		private System.Windows.Forms.Panel panel3;
		#endregion
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip;
        private TcpIpCommandDropDown dropCommand;
        private HistoryDropDown dropHistory;
		private System.ComponentModel.IContainer components;
		
		#region EVENTS THROWN
		public event OnCommandChangedHandler OnCommandChanged;

		public delegate void OnCommandChangedHandler(string command);
		#endregion
		
		#region CONSTRUCTORS AND DECONSTRUCTORS
		/// <summary>
		/// 
		/// </summary>
		public CommandCenter()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			gridCommand.SelectedObject = null;

			//treeCommand.Location = new System.Drawing.Point(comboCommand.Location.X, comboCommand.Location.Y + comboCommand.Height);
			
			dropHistory.Location = new System.Drawing.Point(comboCommand.Location.X, comboCommand.Location.Y + comboCommand.Height);
			dropHistory.list.MouseDown += new MouseEventHandler(dropHistory_MouseDown);
			dropHistory.VisibleChanged += new EventHandler(dropHistory_VisibleChanged);
			dropHistory.list.KeyPress += new KeyPressEventHandler(list_KeyPress); 
			dropHistory.Leave += new EventHandler(dropHistory_Leave);
			
			dropCommand.Location = new System.Drawing.Point(comboCommand.Location.X, comboCommand.Location.Y + comboCommand.Height);
			dropCommand.VisibleChanged += new EventHandler(dropCommand_VisibleChanged);		
			dropCommand.treeView.Release = "15E";	
			dropCommand.Leave += new EventHandler(dropCommand_Leave);
			treeCommand = dropCommand.treeView;
			treeCommand.MouseDown += new MouseEventHandler(treeCommand_MouseDown);
			treeCommand.MouseUp += new MouseEventHandler(treeCommand_MouseUp);
			treeCommand.KeyPress += new KeyPressEventHandler(treeCommand_KeyPress);		
			panel3.Visible = false;

            toolTip.SetToolTip(comboCommand,
                "Click the drop down to see all commands." + Environment.NewLine +
                "Right-click the drop down to see recent history.");
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
		
		#region DLL IMPORTS
		[DllImport("kernel32.dll")]
		public static extern bool Beep(int Frequency, int Duration);
		#endregion
				
		#region MEMBER METHODS

	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public string NextAvailable(string text) 
		{
			if (Parse(text) != null)
				return available.Next();
			else
				return "";
		}

		private TcpIpCommand ParsePositional(string[] parameters) 
		{
			available.Reset();
			foreach (VirtualProperty property in tcpIpCommand.GetProperties()) 
				property.ResetValue(TcpIpCommand);
					

			PropertyDescriptorCollection pdc = tcpIpCommand.GetProperties();
			string pvalue;

			for (int i = 0; i < parameters.Length; i++) 
			{
				if (parameters[i].IndexOf("=") > 0) 
					pvalue = parameters[i].Split('=')[0];
				else 
					pvalue = parameters[i];

				//bool valid = false;

				if (i < pdc.Count) 
				{
					//valid = true;
					available.Set(pdc[i].Name, true);
					try 
					{
						pdc[i].SetValue(tcpIpCommand, pvalue);
					}
					catch (Exception) 
					{
						((VirtualProperty) pdc[i]).SetUnrestrictedValue(tcpIpCommand, pvalue);
						//Debug.WriteLine(e.Source + " invalid value " +  pdc[i].Name + "=" + pvalue);
					}
				} 
				//else
				//	Debug.WriteLine("too many position parameters");
			}

			gridCommand.Refresh();
			
			return tcpIpCommand;
		}

		ArrayList twoPartCommands = new ArrayList(new string[] {
																   "DEF", 													   
																   "DEFINE", 
																   "DEL", 
																   "DELETE", 
																   "Q", 
																   "QUERY", 
																   "SET" });


		public string[] ParseCommand(string text) 
		{
			if (text.Length == 0)
				return new string[0];
			
			char[] ca = text.ToCharArray();

			int j = 0;
			for (int i = 0; i < ca.Length; i++) 
			{
				if (ca[i] == ',') 
				//{
					ca[i] = ' ';
				//	if (j == 0 || ca[j - 1] == ' ')
				//		continue;
				//	else 
				//		ca[j++] = ca[i];

				//	continue;
				//}

				if (ca[i] == ' ') 
				{
					if (j == 0
						|| ca[j - 1] == '='
						|| ca[j - 1] == ' ')
						continue;
					else
						ca[j++] = ca[i];
				} 
				else if (ca[i] == '=') 
				{
					if (ca[j - 1] == ' ')
						ca[j - 1] = '=';
					else
						ca[j++] = '=';
				} 
				else
					ca[j++] = ca[i];
			}

			if (j > 0 && ca[j - 1] == ' ')
				j--;
		
			return new string(ca, 0, j).ToUpper().Split(' ');
		}


		private bool ParseValue(string parameter) 
		{
			bool isValid = false;
			
			if (parameter.IndexOf("=") > 0) 
			{ // assigned
				string[] val = parameter.Split('=');
			}
			else 
			{
				string val = parameter;
			}

			return isValid;
		}


		public TcpIpCommand Parse(string text) 
		{

			string[] parameters = ParseCommand(text);

			int count = 0;
			for (int i = 0; i < parameters.Length; i++) 
			{
				if (parameters[i].Length == 0)
					continue;
				else
					parameters[count++] = parameters[i];
			}
				
			int start = 1;
			string name;

			if (count >= 2) 
			{
				if (twoPartCommands.BinarySearch(parameters[0]) >= 0) 
				{
					name = parameters[0] + " " + parameters[1];
					start++;
				} 
				else
					name = parameters[0];
			} 
			else if (count >= 1)
				name = parameters[0];
			else 
				name = "";

			//string[] parameters = text.ToUpper().Split(',');
			//string name = parameters[0].Trim();
			
			if (TcpIpCommand == null || name.Equals(TcpIpCommand.Name) == false)
				TcpIpCommand = Lookup(name);
							
			if (TcpIpCommand == null) 
			{
				string[] sname = name.Split('=');
				int i = name.IndexOf(' ');
				if (sname.Length > 1 && i > 0) // check format as: command parm=
				{
					TcpIpCommand = Lookup(sname[0]);
					if (TcpIpCommand == null)
						return null;

					ArrayList tmp = new ArrayList(parameters);
					tmp.Add(name.Substring(i + 1));
					parameters = (string[]) tmp.ToArray(typeof(string));
				} 
				else if (i > 1) // check format as: command value  
				{
					TcpIpCommand = Lookup(name.Substring(0, i));
					if (TcpIpCommand == null)
						return null;
					parameters[0]= name.Substring(i).Trim();
					return ParsePositional(parameters);
				}
				else
					return null;
			}

			PropertyDescriptorCollection pdc = tcpIpCommand.GetProperties();
			if (pdc.Count >= 1
				&& ((VirtualProperty) pdc[0]).Assigned == false
				&& ((VirtualProperty) pdc[0]).Keyword == false)
				return ParsePositional(parameters, start);
			else
				return ParseNonPositional(parameters, start);
		}
			

		private void ParseAssigned(string parameter) 
		{
			string[] parsed = parameter.Split('=');
			string propName = parsed[0].ToUpper();
			string propValue = parsed[1];

			bool valid = false;
			
			foreach (VirtualProperty property in tcpIpCommand.GetProperties()) 
			{
				if (property.Name.Equals(propName)) 
				{
					available.Set(property.Name, true);
					
					try 
					{	
						if (propValue.Equals("?"))
							propValue = "";
						property.SetValue(tcpIpCommand, propValue);
					} 
					catch (Exception) 
					{
						property.SetUnrestrictedValue(tcpIpCommand, propValue);
						//addError(property.Name, e.Message);
					}

					valid = true;	
					break;
				}
			}

			if (valid == false) 
				addError(propName, "property does not exist");
		}

		private void ParseKeyword(string parameter) 
		{
			//bool valid = false;
			string propName = parameter.ToUpper();

			foreach (VirtualProperty property in tcpIpCommand.GetProperties()) 
			{
				if (property.Assigned == false && property.Name.Equals(propName))
				{		
					available.Set(property.Name, true);

					try 
					{	
						if (property.Keyword == false)
							property.SetValue(tcpIpCommand, propName);
						else
							property.SetValue(tcpIpCommand, "YES");
					} 
					catch (Exception) 
					{
						property.SetUnrestrictedValue(tcpIpCommand, propName);
						//addError(property.Name, e.Message);
					}

					//valid = true;
					break;
				}
			}

			//if (valid == false)
			//	addError(parameter, "property does not exist");
		}


		public TcpIpCommand ParseNonPositional(string[] parameters, int start) 
		{
			available.Reset();

			foreach (VirtualProperty property in tcpIpCommand.GetProperties()) 
				property.ResetValue(TcpIpCommand);
		
			//errorDescription = "";
			
			for (int i = start; i < parameters.Length; i++) 
			{
				if (parameters[i].IndexOf("=") > 0) // assigned
					ParseAssigned(parameters[i]);
				else 
					ParseKeyword(parameters[i]);
			}

			//if (errorDescription.Equals("") == false) 
			//{
			//	label1.Text = "One or more properties are invalid";
			//	panel3.Visible = true;
			//	toolTip.SetToolTip(label1, errorDescription);
			//} 
			//else 
			//{
			//	toolTip.SetToolTip(label1, "");
			//	label1.Text = "";
			//	panel3.Visible = false;
			//}

			gridCommand.Refresh();
			return tcpIpCommand;
		}

		public TcpIpCommand ParsePositional(string[] parameters, int start) 
		{
			available.Reset();
			foreach (VirtualProperty property in tcpIpCommand.GetProperties()) 
				property.ResetValue(TcpIpCommand);
					
			PropertyDescriptorCollection pdc = tcpIpCommand.GetProperties();
			string pvalue;

			for (int i = start; i < parameters.Length; i++) 
			{
				if (parameters[i].IndexOf("=") > 0) 
					pvalue = parameters[i].Split('=')[0];
				else 
					pvalue = parameters[i];

				if (i - start < pdc.Count) 
				{
					available.Set(pdc[i - start].Name, true);
					try 
					{
						pdc[i - start].SetValue(tcpIpCommand, pvalue);
					}
					catch (Exception) 
					{
						((VirtualProperty) pdc[i - start]).SetUnrestrictedValue(tcpIpCommand, pvalue);
						//Debug.WriteLine(e.Source + " invalid value " +  pdc[i - start].Name + "=" + pvalue);
					}
				} 
				//else
				//	Debug.WriteLine("too many position parameters");					
			}

			gridCommand.Refresh();
			
			return tcpIpCommand;
		}

		private string errorDescription = "";

		private void addError(string name, string description) 
		{
			if (errorDescription.Equals("") == false)
				errorDescription += "\n";
			errorDescription += (name + "\n" + description);
		}


		public TcpIpCommand Lookup(string text) 
		{
			TcpIpCommand command = null;

			if (managerCM == null)
				managerCM = new ManageCM();

			object[] o = managerCM.GetCommandByName(Release, text.ToUpper());
			if (o != null) 
			{
				command = new TcpIpCommand(
					o[0] is DBNull ? null : (string) o[0],
					o[1] is DBNull ? null : (string) o[1],
					o[2] is DBNull ? null : (string) o[2],
					o[3] is DBNull ? null : (string) o[3],
					o[4] is DBNull ? null : (string) o[4],
					o[5] is DBNull ? null : (string) o[5],
					o[6] is DBNull ? null : (string) o[6]);
					//o[7] is DBNull ? null : (string) o[7] The Notes have moved
					//o[8] is DBNull ? null : (string) o[8] The Exposition has moved
			} 
			else 
			{
				o = managerCM.GetCommandByShortcut(Release, text.ToUpper());

				if (o != null) 
				{
					command = new TcpIpCommand(
						o[0] is DBNull ? null : (string) o[0],
						o[1] is DBNull ? null : (string) o[1],
						o[2] is DBNull ? null : (string) o[2],
						o[3] is DBNull ? null : (string) o[3],
						o[4] is DBNull ? null : (string) o[4],
						o[5] is DBNull ? null : (string) o[5],
						o[6] is DBNull ? null : (string) o[6]);
                        //o[7] is DBNull ? null : (string) o[7] The Notes have moved
                        //o[8] is DBNull ? null : (string) o[8] The Exposition has moved
				}
			}

			// Add a command to the search list. 
			if (command != null) 
			{
				bool duplicate = false;
				for (int i = 0; i < dropHistory.list.Items.Count; i++) 
				{
					if (command.Name.ToUpper().Equals(dropHistory.list.Items[i])) 
					{
						duplicate = true;
						break;
					}
				}

				if (duplicate == false) 
				{
					dropHistory.list.Items.Insert(0, text);
					if (dropHistory.list.Items.Count > 25)
						dropHistory.list.Items.RemoveAt(25);
				}
					
			}

			if (command != null) 
			{
				ArrayList al = managerCM.GetParametersByCommandName("15E", command.Name);
				if (al != null) 
				{
					VirtualProperty vp;
					foreach (object[] parameter in al) 
					{
                        try
                        {
                            vp = command.Add(
                                parameter[1] is DBNull ? null : (string)parameter[1],
                                parameter[8] is DBNull ? null : (string)parameter[8],
                                parameter[7] is DBNull ? null : VirtualProperty.createConstraint((string)parameter[7]),
                                (bool)parameter[3],
                                parameter[9] is DBNull ? null : (string)parameter[9]);
                            vp.Assigned = (bool)parameter[4];
                            vp.Keyword = (bool)parameter[5];
                            vp.Delimited = (bool)parameter[6];
                        }
                        catch (InvalidCastException ignoreExc)//this may cause some parameters to be missing
                        {
                            System.Diagnostics.Debug.WriteLine("PARAMETER ERROR: " + (string)parameter[0] + ": " + (string)parameter[1]
                            + Environment.NewLine + ignoreExc.ToString()); }
					}
				}
				return command;
			} 

			return null;
		}


/*		private GridItem ValidateGridItem(string label) 
		{
			// Find the GridItem root.
			GridItem root;
			// System.Windows.Forms.PropertyGridInternal.SingleSelectRootGridEntry
		
			root = this.gridCommand.SelectedGridItem;
			while (root.Parent != null)
				root = root.Parent;

			ArrayList nodes = new ArrayList();
			nodes.Add(root);
			
			GridItem parent;
			while (nodes.Count > 0) 
			{			
				parent = (GridItem) nodes[0];
				nodes.RemoveAt(0);
				if (parent.Label.Equals(label)) 
				{
					return parent;
					
				}

				foreach (object child in parent.GridItems)
					nodes.Add(child);
			}

			return null;		
		}
*/



		/// <summary>
		/// Display documentation for a specified TCP/IP for VSE command.
		/// </summary>
		/// <param name="command">TCP/IP command to display</param>
		public void Display(TcpIpCommand command) 
		{
			Font fontHeader = new Font("Verdana", (float) 8.25, FontStyle.Bold);
			Font fontText = new Font("Verdana", (float) 8.25, FontStyle.Regular);
					
			if (command == null) 
			{
				CenterEmptyCommand();
				return;
			}

			rtbDocumentation.Clear();

			rtbDocumentation.SelectionColor = Color.Black;
			rtbDocumentation.SelectionAlignment = HorizontalAlignment.Left;

			if (command.Description != null) 
			{
				rtbDocumentation.SelectionFont = fontText;
				rtbDocumentation.SelectionIndent = 0;
				rtbDocumentation.AppendText(command.Description + "\n\n");
			}

			if (command.Syntax != null) 
			{
				rtbDocumentation.SelectionFont = fontHeader;
				rtbDocumentation.AppendText("Syntax:\n\n");
				rtbDocumentation.SelectionFont = fontText;
				rtbDocumentation.SelectionIndent = 15;
				rtbDocumentation.AppendText(command.Syntax + "\n\n");
				rtbDocumentation.SelectionIndent = 0;
			}

			if (command.Example != null) 
			{
				rtbDocumentation.SelectionFont = fontHeader;
				rtbDocumentation.AppendText("Example:\n\n");
				rtbDocumentation.SelectionFont = fontText;
				rtbDocumentation.SelectionIndent = 15;
				rtbDocumentation.AppendText(command.Example + "\n\n");
				rtbDocumentation.SelectionIndent = 0;
			}

			if (command.Exposition != null) 
			{
				rtbDocumentation.SelectionFont = fontHeader;
				rtbDocumentation.AppendText("Exposition:\n\n");
				rtbDocumentation.SelectionFont = fontText;
				rtbDocumentation.SelectionIndent = 15;
				rtbDocumentation.AppendText(command.Exposition + "\n\n");
				rtbDocumentation.SelectionIndent = 0;
			}

			if (command.Notes != null) 
			{
				rtbDocumentation.SelectionFont = fontHeader;
				rtbDocumentation.AppendText("Notes:\n\n");
				rtbDocumentation.SelectionFont = fontText;
				rtbDocumentation.SelectionIndent = 15;
				rtbDocumentation.AppendText(command.Notes + "\n\n");
				rtbDocumentation.SelectionIndent = 0;
			}

			if (command.Related != null) 
			{
				rtbDocumentation.SelectionFont = fontHeader;
				rtbDocumentation.AppendText("Related:\n\n");
				rtbDocumentation.SelectionFont = fontText;
				rtbDocumentation.SelectionIndent = 15;
				rtbDocumentation.AppendText(command.Related + "\n\n");
				rtbDocumentation.SelectionIndent = 0;
			}

			rtbDocumentation.SelectionStart = 0;
		}

		private void Lookup(string text, bool user) 
		{
			TcpIpCommand command = Lookup(text);
						
			if (command == null 
				|| TcpIpCommand == null 
				|| TcpIpCommand.Name.Equals(command.Name) == false) 
			{
				TcpIpCommand = command;

				//if (bind != null) 
				//{
				if (TcpIpCommand == null) 
				{
					//bind.Text = "";
					if (OnCommandChanged != null
						&& OnCommandChanged.GetInvocationList() != null)
						OnCommandChanged("");
				}

				else 
				{
					//bind.Text = available.ToString();
					if (OnCommandChanged != null
						&& OnCommandChanged.GetInvocationList() != null)
						OnCommandChanged(available.ToString());
				}
				//}
			}

			if (TcpIpCommand == null)
				Beep(400, 125);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandCenter));
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboCommand = new System.Windows.Forms.ComboBox();
            this.rtbDocumentation = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.gridCommand = new ConsoleRecords.TcpIpCommandPropertyGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dropCommand = new ConsoleRecords.TcpIpCommandDropDown();
            this.dropHistory = new ConsoleRecords.HistoryDropDown();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboCommand);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(416, 32);
            this.panel1.TabIndex = 0;
            // 
            // comboCommand
            // 
            this.comboCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboCommand.Location = new System.Drawing.Point(5, 5);
            this.comboCommand.Name = "comboCommand";
            this.comboCommand.Size = new System.Drawing.Size(406, 21);
            this.comboCommand.TabIndex = 0;
            this.comboCommand.Enter += new System.EventHandler(this.comboCommand_Enter);
            this.comboCommand.MouseUp += new System.Windows.Forms.MouseEventHandler(this.comboCommand_MouseUp);
            this.comboCommand.Resize += new System.EventHandler(this.comboCommand_Resize);
            this.comboCommand.MouseMove += new System.Windows.Forms.MouseEventHandler(this.comboCommand_MouseMove);
            this.comboCommand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboCommand_MouseDown);
            this.comboCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboCommand_KeyPress);
            this.comboCommand.DropDown += new System.EventHandler(this.comboCommand_DropDown);
            // 
            // rtbDocumentation
            // 
            this.rtbDocumentation.BackColor = System.Drawing.Color.Ivory;
            this.rtbDocumentation.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbDocumentation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDocumentation.Location = new System.Drawing.Point(5, 0);
            this.rtbDocumentation.Name = "rtbDocumentation";
            this.rtbDocumentation.ReadOnly = true;
            this.rtbDocumentation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbDocumentation.Size = new System.Drawing.Size(406, 160);
            this.rtbDocumentation.TabIndex = 0;
            this.rtbDocumentation.TabStop = false;
            this.rtbDocumentation.Text = "";
            this.rtbDocumentation.Resize += new System.EventHandler(this.rtbDocumentation_Resize);
            this.rtbDocumentation.Enter += new System.EventHandler(this.rtbDocumentation_Enter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.gridCommand);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.rtbDocumentation);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panel2.Size = new System.Drawing.Size(416, 504);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(5, 168);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(406, 26);
            this.panel3.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.ImageIndex = 0;
            this.label2.ImageList = this.images;
            this.label2.Location = new System.Drawing.Point(390, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 26);
            this.label2.TabIndex = 5;
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "");
            // 
            // gridCommand
            // 
            this.gridCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCommand.HelpForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridCommand.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.gridCommand.Location = new System.Drawing.Point(5, 168);
            this.gridCommand.Name = "gridCommand";
            this.gridCommand.Size = new System.Drawing.Size(406, 331);
            this.gridCommand.TabIndex = 7;
            this.gridCommand.TabStop = false;
            this.gridCommand.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.gridCommand_PropertyValueChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(5, 160);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(406, 8);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // dropCommand
            // 
            this.dropCommand.Location = new System.Drawing.Point(118, 178);
            this.dropCommand.Name = "dropCommand";
            this.dropCommand.Size = new System.Drawing.Size(180, 180);
            this.dropCommand.TabIndex = 4;
            this.dropCommand.TabStop = false;
            this.dropCommand.Visible = false;
            // 
            // dropHistory
            // 
            this.dropHistory.Location = new System.Drawing.Point(130, 200);
            this.dropHistory.Name = "dropHistory";
            this.dropHistory.Size = new System.Drawing.Size(180, 180);
            this.dropHistory.TabIndex = 5;
            this.dropHistory.TabStop = false;
            this.dropHistory.Visible = false;
            // 
            // CommandCenter
            // 
            this.Controls.Add(this.dropHistory);
            this.Controls.Add(this.dropCommand);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CommandCenter";
            this.Size = new System.Drawing.Size(416, 536);
            this.Resize += new System.EventHandler(this.CommandCenter_Resize);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region EVENT HANDLERS (Command Properties)
		private void gridCommand_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{				
			if (OnCommandChanged != null
			  && OnCommandChanged.GetInvocationList() != null)
				OnCommandChanged(available.ToString());
		}
		#endregion
	
		private void btnGo_Click(object sender, System.EventArgs e)
		{
			Lookup(comboCommand.Text.Trim().ToUpper(), true);
		}
		
		#region EVENT HANDLERS (Command Combobox)

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
		private void comboCommand_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.X >= comboCommand.Width - 2 - SystemInformation.VerticalScrollBarWidth)
				InDropDownButton = true;
			else
				InDropDownButton = false;
		}

		/// <summary>
		/// Handle a drop down event from the message code combination box.
		/// The normal drop down box is suppressed.
		/// </summary>
		/// <param name="sender">Object that caused the event.</param>
		/// <param name="e">Descriptive details about the event.</param>
		private void comboCommand_DropDown(object sender, System.EventArgs e)
		{
			comboCommand.IntegralHeight = !comboCommand.IntegralHeight;
			comboCommand.IntegralHeight = !comboCommand.IntegralHeight;
		}

		/// <summary>
		/// Handle a key press event from the command search box.  The text of  
		/// the box is searched to find a matching message code. 
		/// </summary>
		/// <param name="sender">Object that caused the event.</param>
		/// <param name="e">Descriptive details about the event.</param>
		private void comboCommand_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 0x0D) 
			{
				Lookup(comboCommand.Text.Trim().ToUpper(), true);
				e.Handled = true;
			} 
		}
		
		
		private void comboCommand_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (InDropDownButton == true) 
			{
				if (e.Button == MouseButtons.Right) 
				{
					if (dropHistory.Visible == true)
						BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
					else if (dropCommand.Visible == true)
						BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
					else 
						BeginInvoke(new ShowHistoryDelegate(ShowHistory));						
				}

				if (e.Button == MouseButtons.Left) 
				{
					if (dropHistory.Visible == true)
						BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
					else if (dropCommand.Visible == true)
						BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
					else if (treeCommand.Nodes.Count > 0)
                            BeginInvoke(new ShowCommandDelegate(ShowCommand));
				}
			} 
			else 
			{
				if (dropHistory.Visible == true)
					HideHistory();

				if (dropCommand.Visible == true)
					HideCommand();
			}
		}		
		#endregion

		private void rtbDocumentation_Resize(object sender, System.EventArgs e)
		{
			if (TcpIpCommand == null)
				CenterEmptyCommand();
		}

		private void CenterEmptyCommand() 
		{
			Font fontMessage = new Font("Verdana", (float) 8.25, FontStyle.Italic);
			int center = (int) ((rtbDocumentation.Height / fontMessage.GetHeight() - 1) / 2);
			string verticalSpace = "";
			for (int i = 0; i < center; i++)
				verticalSpace += "\n";

			rtbDocumentation.Clear();

			rtbDocumentation.SelectionAlignment = HorizontalAlignment.Center;
			rtbDocumentation.SelectionColor = Color.Red;
			rtbDocumentation.SelectionFont = fontMessage;
			rtbDocumentation.AppendText(verticalSpace + "<no command to display>");
		}
		
		private int oldHeight = 0;
		private void CommandCenter_Resize(object sender, System.EventArgs e)
		{
			if (oldHeight != Height) 
			{
				rtbDocumentation.Size = new Size(Width, (int) (Height * 0.40F));
				oldHeight = Height;
				//dropCommand.Height = rtbDocumentation.Height * 0.75 > 250 ? 250 : (int) (rtbDocumentation.Height * 0.75);
				//dropHistory.Height = rtbDocumentation.Height * 0.75 > 250 ? 250 : (int) (rtbDocumentation.Height * 0.75);
                int dropHeight = (int)(panel2.Height * 0.90);
                dropCommand.Height = dropHeight;
                dropHistory.Height = dropHeight;
			}
		}

        private void treeCommand_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) 
		{
			treeCommand.SelectedNode = treeCommand.GetNodeAt(e.X, e.Y);
			string text;
			if (treeCommand.SelectedNode.Nodes.Count == 0) 
			{
				if (treeCommand.SelectedNode.Parent == null)
					text = treeCommand.SelectedNode.Text;
				else
					text = treeCommand.SelectedNode.Parent.Text + " " + treeCommand.SelectedNode.Text;

				Lookup(text, true);
				BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
			}
		}

		private void treeCommand_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//if (treeCommand.SelectedNode.Nodes.Count == 0)
			//	BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
		}

		private void treeCommand_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 0x0D) 
			{
				string text;
				TreeNode node = treeCommand.SelectedNode;
				if (node.Nodes.Count == 0) 
				{
					if (node.Parent == null)
						text = node.Text;
					else
						text = node.Parent.Text + " " + node.Text;
					
					Lookup(text, true);
					BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
				}
				else
				{
					if (node.IsExpanded == true)
						node.Collapse();
					else
						node.Expand();
				}

				e.Handled = true;
			}
		}

		private void FocusToSearchBox() 
		{
			//btnGo.Enabled = true;
			comboCommand.Focus();
			comboCommand.SelectionStart = comboCommand.Text.Length;
			comboCommand.SelectionLength = 0;
		}

		#region DELEGATES
		private delegate void FocusToSearchBoxDelegate();
		private delegate void ShowCommandDelegate();
		private delegate void ShowHistoryDelegate();
		private delegate void HideHistoryDelegate();
		private delegate void HideCommandDelegate();
		private delegate void UnHighlightDelegate();
		#endregion

		private void HideCommand() 
		{
			dropCommand.Visible = false;
			dropCommand.Enabled = false;
		}

		private void HideHistory() 
		{
			dropHistory.Visible = false;
			//btnGo.Enabled = true;
		}

		private void ShowCommand() 
		{
			//btnGo.Enabled = false;
			dropCommand.Enabled = true;
			dropCommand.Width = comboCommand.Width;
			treeCommand.SelectClosestCommand(comboCommand.Text, true);
			dropCommand.Visible = true;
			dropCommand.BringToFront();
			
			dropCommand.Focus();
		}

		private void ShowHistory() 
		{
			//btnGo.Enabled = false;
			dropHistory.Width = comboCommand.Width;
			int i = dropHistory.list.FindString(comboCommand.Text, -1);
			if (i >= 0)
				dropHistory.list.SelectedIndex = i;
			dropHistory.Visible = true;
			dropHistory.BringToFront();
			dropHistory.Focus();
		}




		private void dropHistory_MouseDown(object sender, MouseEventArgs e)
		{
			int i = dropHistory.list.IndexFromPoint(e.X, e.Y);
			if (i == -1)
				return;
			Lookup(dropHistory.list.Items[i].ToString(), true);
			BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
			//Lookup(dropHistory.list.SelectedItem.ToString(), true);
			//HideHistory();
		}

		private void dropHistory_VisibleChanged(object sender, EventArgs e)
		{
			//if (dropHistory.Visible == false && dropCommand.Focused == false)
			//	BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
		}

		private void dropCommand_VisibleChanged(object sender, EventArgs e)
		{
			//if (dropCommand.Visible == false && dropHistory.Focused == false)
				
		}

		
				

		private void list_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 0x0D) 
			{
				Lookup(dropHistory.list.SelectedItem.ToString(), true);
				//panel3.Visible = true;

				//GridItem item = this.ValidateGridItem("TYPE");
				//if (item != null)
				//	errorProvider1.SetError(item, "this is an error");
				BeginInvoke(new FocusToSearchBoxDelegate(FocusToSearchBox));
			}
		}

		private void dropHistory_Leave(object sender, EventArgs e)
		{
			BeginInvoke(new HideHistoryDelegate(HideHistory));
			comboCommand.SelectionStart = comboCommand.Text.Length;
			comboCommand.SelectionLength = 0;
			//btnGo.Enabled = true;
		}

		private void dropCommand_Leave(object sender, EventArgs e)
		{
			BeginInvoke(new HideCommandDelegate(HideCommand));
			comboCommand.SelectionStart = comboCommand.Text.Length;
			comboCommand.SelectionLength = 0;
			//btnGo.Enabled = true;
		}

		private void comboCommand_Enter(object sender, System.EventArgs e)
		{
			//btnGo.Enabled = true;
			//BeginInvoke(new UnHighlightDelegate(UnHighlight));
		}

		private void UnHighlight() 
		{
			comboCommand.SelectionStart = comboCommand.Text.Length;
			comboCommand.SelectionLength = 0;
		}

		private void comboCommand_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			SetCaretPos(comboCommand, e.X, e.Y);
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

		private void SetCaretPos(ComboBox cb, int x, int y) 
		{		
			cb.Select(cb.Text.Length, 0);
						
			IntPtr edit = FindWindowEx(cb.Handle, new IntPtr(0), null, null);
			
			POINT pt = new POINT();
			pt.x = x;
			pt.y = y;

            // MCCLAIN 20061026 fix PInvoke issue		
            //IntPtr index = SendMessage(edit, EM_CHARFROMPOS, new IntPtr(0), pt);
            IntPtr index = SendMessage(new HandleRef(edit, edit), EM_CHARFROMPOS, new IntPtr(0), ref pt);
           
			if (index.ToInt32() != -1)
				cb.SelectionStart = index.ToInt32();
		}

		private void rtbDocumentation_Enter(object sender, System.EventArgs e)
		{
			panel1.Focus();
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
			//panel3.Visible = false;
		}
		
		private void tcpIpCommand_OnPropertyError(object sender, string property, string message)
		{
			MessageBox.Show(this, "yet another handled error");
		}

		private void comboCommand_Resize(object sender, System.EventArgs e)
		{
			comboCommand.Focus();
			comboCommand.SelectionStart = comboCommand.Text.Length;
			comboCommand.SelectionLength = 0;
		}
	}

	internal class ParameterComparer : IComparer
	{
		#region IComparer Members
		public int Compare(object x, object y)
		{
			if (x is Parameter == false || y is Parameter == false)
				return 0;

			Parameter xp = (Parameter) x;
			Parameter yp = (Parameter) y;

			if (xp.Order > yp.Order) 
				return 1;
			else if (xp.Order < yp.Order)
				return -1;
			else 
				return 0;
		}
		#endregion
	}

	internal class Parameter 
	{
		public VirtualProperty Property;
		public bool Used;
		public int Order;

		public Parameter(VirtualProperty property, bool used, int order) 
		{
			Property = property;
			Used = used;
			Order = order;
		}
	}

	internal class Parameters 
	{
		private ArrayList parameters = new ArrayList();
		private TcpIpCommand Command;
		
		private int current = 0;
		private int order = 0;

		public Parameters(TcpIpCommand command) 
		{
			Command = command;
		} 
		
		public void Add(VirtualProperty property, bool used) 
		{
			if (used == true) 
			{
				//Debug.WriteLine("value of true is not implemented for Parameters.Add");
				return;
			}

			parameters.Add(new Parameter(property, used, -1));
		}
		
		public void Set(string name, bool used) 
		{
			if (used == false) 
			{
				//Debug.WriteLine("value of false is not implemented for Parameters.Set");
				return;
			}

			foreach (Parameter parameter in parameters) 
			{
				if (parameter.Property.Name.Equals(name) && parameter.Used == false) 
				{
					parameter.Used = used;
					parameter.Order = order++;
					break;
				}
			}
		}

		public void Reset() 
		{
			foreach (Parameter parameter in parameters) 
			{
				parameter.Used = false;
				parameter.Order = -1;
				order = 0;
			}
		}

		public string Next() 
		{
			VirtualProperty property;
			string delimiter;

			if (parameters.Count == 0)
				return "";

			// Scan for any missing required parameters.  If any exist, they
			// are returned;

			string text = "";
			foreach (Parameter parameter in parameters) 
			{
				property = parameter.Property;

				if (property.Delimited == true)
					delimiter = ",";
				else
					delimiter = "";

				if (property.Category.Equals("*Required") 
					&& parameter.Used == false) 
				{
					Set(property.Name, true);
					if (property.Assigned == true) 
					{
						string pValue = (string) property.GetValue(Command);
						if (pValue.Equals(""))
							pValue = "?";
					
						if (Command.Family.Equals("SET"))
							text += "=" + pValue;
						else 
							text += delimiter + property.Name + "=" + pValue;
					}
					else 
					{
						if (property.Keyword == false)
							text += delimiter + property.GetValue(Command);
						else 
							text += delimiter + property.Name;
					}
				}
			}
			
			if (text.Equals("") == false) 
			{
				current = 0;
				return text;
			}

			int next = current;

			do 
			{
				if (next > parameters.Count - 1) 
					next = 0;
				
				if (((Parameter) parameters[next]).Used == false) 
				{
					current = next;				
					property = ((Parameter) parameters[current]).Property;
					Set(property.Name, true);
					if (++current > parameters.Count - 1)
						current = 0;

					return Command.formatProperty(property);
				}
				
				if (++next > parameters.Count - 1) 
					next = 0;
			} while (next != current); 

			return "";
		}

		public override string ToString() 
		{
			VirtualProperty property;
			ArrayList sorted = (ArrayList) parameters.Clone();
			
			if (Command.Name.Equals("FLUSH") == false) 
				sorted.Sort(new ParameterComparer());
			
			string text = "";
			if (Command.Family != null && Command.Family.Equals("SET"))
				text = Command.Family + " ";
			else if (Command.Name.IndexOf(" ") > 0)
				text = Command.Name;
			else 
				text = Command.Name + " ";

			foreach (Parameter parameter in sorted) 
			{
				property = parameter.Property;	
				
				if (parameter.Used == true) 
				{
					if (property.Category.Equals("Optional") && property.ShouldSerializeValue(Command) == false)
						continue;
					else
						text += Command.formatProperty(property);
				
				}
			}

			foreach (Parameter parameter in sorted) 
			{
				property = parameter.Property;
								
				if (parameter.Used == false) 
				{	
					if (property.Category.Equals("*Required")) 
					{
						text += Command.formatProperty(property);
						parameter.Used = true;
					}
		
					else if (property.ShouldSerializeValue(Command) == true) 
					{
						text += Command.formatProperty(property);
						parameter.Used =true;
					}
				}
			}

			return text;		
		}
	}	
} // end of CommandCenter
