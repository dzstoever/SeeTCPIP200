using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

//using csi.seevse.MsdeDataAccess;

namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for TcpIpCommandTree.
	/// </summary>
	public class TcpIpCommandTree : TreeView, ISupportInitialize
	{
		private bool designMode;
		private ManageCM managerCM = null;

		private string release;
		public string Release 
		{
			get { return release; }
			set { 
				release = value; 
				// MCCLAIN 20061026 updated for .NET 2.0
                //if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv") 
                if (DesignMode == false) 
                {
					if (release != null)
						InitCommands();
				}
			}
		}
		
		private TreeNode[] internalNodes;

		//private TreeNodeCollection nodes;
		public new TreeNodeCollection Nodes 
		{
			get { 
				return base.Nodes; 
			}
		}
		
		private ArrayList list = null;
		public ArrayList List 
		{
			get { 
				return list; 
			}
		}

       
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		/// <summary>
		/// 
		/// </summary>
		public TcpIpCommandTree()
		{
			InitializeComponent();
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
			// 
			// TcpIpCommandTree
			// 
			this.Name = "TcpIpCommandTree";
			this.Size = new System.Drawing.Size(144, 152);

		}
		#endregion
		

		public TreeNode FindClosestCommand(string text) 
		{
			int[] i = FindCommand(text, true);
			int i1 = i[0];
			int i2 = i[1];

			if (i1 >= 0) 
			{
				if (i2 >= 0) 
					return Nodes[i1].Nodes[i2];
				else 
				{
					TreeNode parent = Nodes[i1];
					i2 = -i2;
					if (parent.Nodes.Count == 0)
						return parent;
					else 
					{
						if (i2 >= parent.Nodes.Count)
							return parent.Nodes[parent.Nodes.Count - 1];
						else
							return parent.Nodes[i2 - 1];
					}
				}
			}
			else 
			{
				i1 = -i1;
				if (i1 >= Nodes.Count)
					return Nodes[Nodes.Count - 1];
				else
					return Nodes[i1 - 1];
			}
		}

		/// <summary>
		/// Select the node (set as SelectedNode in the tree) that matches 
		/// closest to the specified text.
		/// </summary>
		/// <param name="text">Text to match</param>
		/// <param name="ignoreCase">true ignore case; false otherwise</param>
		/// <returns>true indicates a match; false otherwise</returns>
		public bool SelectClosestCommand(string text, bool ignoreCase) 
		{
			if (ignoreCase == true)
				text = text.Trim().ToUpper();

			SelectedNode = FindClosestCommand(text);

			if (SelectedNode.Parent != null)
				SelectedNode.Parent.Expand();

			if (SelectedNode.Text.Equals(text))
				return true;
			else
				return false;
		}
		
		public string[] GetCommandsStartsWith(string command) 
		{
			if (List == null)
				return new string[0];
			else if (command.Equals(""))
				return (string[]) List.ToArray(typeof(string));

			ArrayList match = new ArrayList();
			
			foreach (string list in List) 
			{
				if (list.StartsWith(command.ToUpper()) == true)
					match.Add(list);
			}
			
			return (string[]) match.ToArray(typeof(string));
		}

		public int[] FindCommand(string command, bool ignoreCase) 
		{
			// Break command into two parts (if necessary)
			string[] split = command.Split(' ');
			int[] index = {-1, -1};

			if (split.Length > 0) 
			{
				index[0] = Array.BinarySearch(internalNodes, new TreeNode(split[0]), new CommandComparer(ignoreCase));
					
				if (index[0] >= 0) 
				{
					TreeNode node = internalNodes[index[0]];
					if (node.Nodes.Count > 0 && split.Length > 1) 
						index[1] = new ArrayList(node.Nodes).BinarySearch(new TreeNode(split[1]), new CommandComparer(ignoreCase));
				}
			}

			return index;
		}



		private void InitCommands() 
		{
			if (managerCM == null)
				managerCM = new ManageCM();

			if (managerCM == null)
				return;

			ArrayList all = managerCM.GetAllCommands(release, "");
			ArrayList commands = new ArrayList();

			foreach (object[] o in all) 
			{
				commands.Add(new TcpIpCommand(
					o[0] is DBNull ? null : (string) o[0],
					o[1] is DBNull ? null : (string) o[1],
					o[2] is DBNull ? null : (string) o[2]));
			}
			
			Nodes.Clear();

			TreeNode node = null;
			
			foreach (TcpIpCommand command in commands)  
			{
				if (command.Family == null)	
				{
					Nodes.Add(new TreeNode(command.Name));
					node = null;
				}
				else 
				{
					if (node == null || node.Text.Equals(command.Family) == false) 
					{
						node = new TreeNode(command.Family);
						Nodes.Add(node);
					}

					string subCommand = command.Name.Substring(command.Name.IndexOf(" ") + 1);
					node.Nodes.Add(new TreeNode(subCommand));
				}
			}
		
			list = new ArrayList();
			
			foreach (TreeNode command in Nodes) 
			{
				if (command.Nodes.Count > 0) 
				{
					foreach (TreeNode child in command.Nodes) 
						list.Add(command.Text + " " + child.Text);
				} 
				else
					list.Add(command.Text);
			}

			internalNodes = new TreeNode[Nodes.Count];
			Nodes.CopyTo(internalNodes, 0);
		}

		#region IMPLEMENATION (ISupportInitialize)
		/// <summary>
		/// 
		/// </summary>
		public void BeginInit() {}

		/// <summary>
		/// 
		/// </summary>
		public void EndInit() {
			designMode = DesignMode;
		}
		#endregion
	}

	internal class CommandComparer : IComparer
	{
		private bool ignoreCase = false;

		#region IComparer Members

		public CommandComparer(bool ignoreCase) : base() 
		{
			this.ignoreCase = ignoreCase;
		}

		public int Compare(object x, object y)
		{
			if (ignoreCase == true) 
			{
				string xc = ((TreeNode) x).Text.ToLower();
				string yc = ((TreeNode) y).Text.ToLower();

				return xc.CompareTo(yc);
			} 
			else 
				return ((TreeNode) x).Text.CompareTo(((TreeNode) y).Text);
		}
		#endregion
	}
}
