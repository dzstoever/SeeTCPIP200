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

	public class TcpIpMessageTree : TreeView, ISupportInitialize
	{
		private bool designMode;
		private ManageCM managerCM = null;

		private string release;
		public string Release 
		{
			get { return release; }
			set 
			{ 
				release = value; 
				if (value != null && value.Equals("") == false) 
				{
                    // MCCLAIN 20061026 change for .NET 2.0
					//if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
		            if (DesignMode == false)
						InitMessages();
				}
			}
		}
		
		private TreeNode[] internalNodes;

		public new TreeNodeCollection Nodes 
		{
			get 
			{ 
				return base.Nodes; 
			}
		}
		
		private ArrayList list = null;
		public ArrayList List 
		{
			get 
			{ 
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
		public TcpIpMessageTree()
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
			this.Name = "TcpIpMessageTree";
			this.Size = new System.Drawing.Size(144, 152);

		}
		#endregion
		
		
		public TreeNode FindClosestMessage(string message) 
		{
            //if (Nodes.Count == 0)
                //return null;

			int[] i = FindMessage(message, true);
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
		public bool SelectClosestMessage(string text, bool ignoreCase) 
		{
			if (ignoreCase == true)
				text = text.Trim().ToUpper();

			SelectedNode = FindClosestMessage(text);

			if (SelectedNode.Parent != null) 
			{
				SelectedNode.Parent.Expand();
				if (text.Equals(SelectedNode.Parent.Text + SelectedNode.Text))
					return true;
			}

			if (SelectedNode.Text.Equals(text))
				return true;
			else
				return false;
		}
		
		public int[] FindMessage(string message, bool ignoreCase) 
		{
			// Break message into two parts.

			int[] index = {-1, -1};

			
			if (message.Length == 0)
				return index;

			// Break a message into two major pieces: Family and Id/Level pair.

			string family = TcpIpMessageCode.GetFamily(message);
			string id = TcpIpMessageCode.GetId(message);
			string level = TcpIpMessageCode.GetLevel(message);

			string[] split = new string[2] { family, id + level }; 
			
			if (split.Length > 0) 
			{
				index[0] = Array.BinarySearch(internalNodes, new TreeNode(split[0]), new MessageComparer(ignoreCase));
			
				if (index[0] >= 0) 
				{
					TreeNode node = internalNodes[index[0]];
					if (node.Nodes.Count > 0 && split.Length > 1) 
						index[1] = new ArrayList(node.Nodes).BinarySearch(new TreeNode(split[1]), new MessageComparer(ignoreCase));
				}
			}

			return index;
		}
				
		private void InitMessages() 
		{
			if (managerCM == null)
				managerCM = new ManageCM();

			if (managerCM == null)
				return;

			ArrayList all = managerCM.GetAllMessages(release);
			ArrayList messages = new ArrayList();

			foreach (object[] o in all) 
			{
				messages.Add(new TcpIpMessageCode(
					o[0] is DBNull ? null : (string) o[0],
					o[1] is DBNull ? null : (string) o[1],
					o[2] is DBNull ? null : (string) o[2],
					o[3] is DBNull ? null : (string) o[3],
					o[4] is DBNull ? null : (string) o[4],
					o[5] is DBNull ? null : (string) o[5]));
			}
			
			Nodes.Clear();

			TreeNode node = null;

			foreach (TcpIpMessageCode message in messages)  
			{
				if (node == null || node.Text.Equals(message.Family) == false) 
				{
					node = new TreeNode(message.Family);
					Nodes.Add(node);
				}
									
				string subCommand = message.Id + message.Level;
				node.Nodes.Add(new TreeNode(subCommand));
			}
		
			list = new ArrayList();
			
			foreach (TreeNode message in Nodes) 
			{
				if (message.Nodes.Count > 0) 
				{
					foreach (TreeNode child in message.Nodes) 
						list.Add(message.Text + child.Text);
				} 
				else
					list.Add(message.Text);
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
		public void EndInit() 
		{
            // MCCLAIN 20061026 changed for .NET 2.0
			//designMode = System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";
            designMode = DesignMode;
		}
		#endregion
	}

	internal class MessageComparer : IComparer
	{
		private bool ignoreCase = false;

		#region IComparer Members

		public MessageComparer(bool ignoreCase) : base() 
		{
			this.ignoreCase = ignoreCase;
		}

		public int Compare(object x, object y)
		{
			if (ignoreCase == true) 
			{
				string xc;
				//if (((TreeNode) x).Text.Length > 0)
					xc = ((TreeNode) x).Text.ToLower();
				//else 
				//	xc = ((TreeNode) x).Text;

				string yc;
				//if (((TreeNode) y).Text.Length == 0)
					yc = ((TreeNode) y).Text.ToLower();
				//else
				//	yc = ((TreeNode) y).Text;

				return xc.CompareTo(yc);
			} 
			else 
				return ((TreeNode) x).Text.CompareTo(((TreeNode) y).Text);
		}
		#endregion
	}
}
