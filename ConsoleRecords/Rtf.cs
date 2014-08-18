using System;
using System.Collections;
using System.Drawing;
using System.Text;

namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for Rtf.
	/// </summary>
	public class Rtf
	{
		private Color[] colors;
		//private Font[] fonts;
		private const String header = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033";
		private const String fontTable = @"{\fonttbl{\f0\fnil Courier New;}}\r\n";
		private const String documentDefinition = @"\viewkind4\uc1";
		//String footer = @"}\n";
		private const string footer = @"}";
		public Rtf()
		{
			colors = new Color[4];
			colors[0] = Color.Black;	// cf1
			colors[1] = Color.Gray;		// cf2	
			colors[2] = Color.Red;		// cf3
			colors[3] = Color.Blue;		// cf4
		}

		public int ColorIndex(Color color) 
		{
			for (int i = 0; i < colors.Length; i++) 
			{
				if (color.Equals(colors[i]))
					return i + 1;
			}

			Color[] tmp = new Color[colors.Length + 1];
			colors.CopyTo(tmp, 0);
			colors = tmp;
			colors[colors.Length - 1] = color;
			return colors.Length;
		}
		
		public String ColorTable() 
		{
			StringBuilder colorTable = new StringBuilder();

			// Append color table control string and default font (;)
			colorTable.Append(@"{\colortbl ;");

			// Append the text color

			for (int i = 0; i < colors.Length; i++)
				colorTable.Append("\\red" + colors[i].R + "\\green" + (int) colors[i].G + "\\blue" + (int) colors[i].B + ";");
			
			colorTable.Append(@"}");
					
			return colorTable.ToString() + "\n";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string ReplaceControlCodes(string text) 
		{
			return text.Replace(@"\", @"\\").Replace(@"{", @"\{").Replace(@"}", @"\}");
		}


		/*public string FormatText(String text, Color color, FontStyle style, float size, int justification) 
		{
			string f = "\\pard";
            if (justification == 0)
				f += "\\qc";
			if (style == FontStyle.Bold)
				f += "\\b";
					
			f += "\\cf" + ColorIndex(color);
			
			f += text;

			for (int i = 0; i < colors.Length; i++)
				f += "\\cf" + i + "x";

			if (style == FontStyle.Bold)
				f += "\\b0";
			f += "\\cf" + ColorIndex(Color.White) + "\\f1\\fs1\\par";
			return f;
		}
*/


		public String Header() 
		{
			return header;
		}

		public String Footer() 
		{
			return footer;
		}

		public String FontTable() 
		{
			return fontTable;
		}
		public String DocumentDefinition() 
		{
			return documentDefinition; 
		}
	} // end of Rtf
}
