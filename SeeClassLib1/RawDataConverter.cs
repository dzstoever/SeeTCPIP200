using System;
using System.Text;

namespace csi.see.classlib1
{
	/// <summary>
	/// Returns .net data types from the raw data bloks returned by SVSESRVR.
    /// </summary>
	public class RawDataConverter
	{
		public RawDataConverter()
		{}
		
		public int		GetINT32 (int oset, byte[] datablock)
		{
			int data_32 = 0;
			const int length = 4;
			int last_ind = 3;
			int high_byte = oset + length;
			byte[] rev_data = new byte[length];
			for(int cnt=oset; cnt<high_byte; cnt++)//Reverse byte order
			{
				rev_data[last_ind] = datablock[cnt];
				last_ind--;
			}
			data_32 = BitConverter.ToInt32(rev_data,0);//Convert the count to an integer 
			return data_32;
		}
		public ulong	GetUINT64 (int oset, byte[] datablock)
		{
			ulong data_64 = 0;
			const int length = 8;
			int last_ind = 7; 
			int high_byte = oset + length;
			byte[] rev_data = new byte[length];
			for(int cnt=oset; cnt<high_byte; cnt++)//Reverse byte order
			{
				rev_data[last_ind] = datablock[cnt];
				last_ind--;
			}	
			data_64 = BitConverter.ToUInt64(rev_data,0);//Convert the count to an integer
			return data_64;
		}		
		public uint		GetUINT32 (int oset, byte[] datablock)
		{
			uint data_32 = 0;
			const int length = 4;
			int last_ind = 3;
			int high_byte = oset + length;
			byte[] rev_data = new byte[length];
			for(int cnt=oset; cnt<high_byte; cnt++)//Reverse byte order
			{
				rev_data[last_ind] = datablock[cnt];
				last_ind--;
			}
			data_32 = BitConverter.ToUInt32(rev_data,0);//Convert the count to an integer
			return data_32;
		}
		public ushort	GetUINT16 (int oset, byte[] datablock)
		{
			ushort data_16 = 0;
			const int length = 2;
			int last_ind = 1;
			int high_byte = oset + length;
			byte[] rev_data = new byte[length];
			for(int cnt=oset; cnt<high_byte; cnt++)//Reverse byte order
			{
				rev_data[last_ind] = datablock[cnt];
				last_ind--;
			}
			data_16 = BitConverter.ToUInt16(rev_data,0); 
			return data_16;
		}		
		public byte		GetBYTE (int oset, byte[] datablock)
		{
			byte data_8 = new byte();
			data_8 = datablock[oset];
			return data_8;
		}
		public string	GetHEX(int oset, byte[] datablock, int len)
		{
			string strHEX = "";
			StringBuilder sb = new StringBuilder(len*2);
			for(int cnt=oset; cnt<oset + len; cnt++)
			{
				string hex_b = Convert.ToString(datablock[cnt],16);//convert to a HEX value
				if(datablock[cnt]<16)
				{hex_b = "0" + hex_b;}
				sb.Append(hex_b);
			}
			strHEX = sb.ToString();
			sb = null;
			strHEX = strHEX.ToUpper();
			return strHEX;
		}		
		public string	GetEBCDIC(int oset, byte[] datablock, int len)
		{
			string result = "";
			int[] e2a = new int[256] { 0, 1, 2, 3,156, 9,134,127,151,141,142, 11, 12, 13, 14, 15, 16, 17, 18, 19,157,133, 8,135, 24, 25,146,143, 28, 29, 30, 31, 128,129,130,131,132, 10, 23, 27,136,137,138,139,140, 5, 6, 7, 144,145, 22,147,148,149,150, 4,152,153,154,155, 20, 21,158, 26, 32,160,161,162,163,164,165,166,167,168, 91, 46, 60, 40, 43, 33, 38,169,170,171,172,173,174,175,176,177, 93, 36, 42, 41, 59, 94, 45, 47,178,179,180,181,182,183,184,185,124, 44, 37, 95, 62, 63, 186,187,188,189,190,191,192,193,194, 96, 58, 35, 64, 39, 61, 34, 195, 97, 98, 99,100,101,102,103,104,105,196,197,198,199,200,201, 202,106,107,108,109,110,111,112,113,114,203,204,205,206,207,208, 209,126,115,116,117,118,119,120,121,122,210,211,212,213,214,215, 216,217,218,219,220,221,222,223,224,225,226,227,228,229,230,231, 123, 65, 66, 67, 68, 69, 70, 71, 72, 73,232,233,234,235,236,237, 125, 74, 75, 76, 77, 78, 79, 80, 81, 82,238,239,240,241,242,243, 92,159, 83, 84, 85, 86, 87, 88, 89, 90,244,245,246,247,248,249, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57,250,251,252,253,254,255 };
			int end = oset + len;
			int e_val = 0;
			int a_val = 0;
			char m_char = ' ';
			StringBuilder sb = new StringBuilder(); 
			//Get bytes and replace the EBCDIC value with an ASCII value
			for(int cnt=oset; cnt<end; cnt++)
			{
				e_val = Convert.ToInt32(datablock[cnt]);
				a_val = e2a[Convert.ToUInt32(e_val)];
				m_char = Convert.ToChar(a_val);
				sb.Append(m_char);
			}
			result = sb.ToString(); 
			sb = null; 
			return result;
		}			
		public string	GetIPAD (int oset, byte[] datablock)
		{
			string data_A = "";
			const int length = 4;//One byte for each octet
			int end = oset + length;
			int byteval = 0;
			StringBuilder sb = new StringBuilder(); 
			for(int i =oset;i < end;i++) 
			{ 
				byteval = Convert.ToInt32(datablock[i]);
				sb.Append(Convert.ToString(byteval));
				sb.Append(".");		
			} 
			int lastperiod = sb.Length - 1;	
			sb.Remove(lastperiod,1);
			data_A = sb.ToString(); 
			sb = null;  
			return data_A;
		}
		public string	GetCPUID(int oset, byte[] datablock)
		{
			string strCPUID = "";
			StringBuilder sb = new StringBuilder(17,17);
			for(int cnt=oset; cnt<oset+8; cnt++)
			{
				string hex_b = Convert.ToString(datablock[cnt],16);//convert to a HEX value
				if(datablock[cnt]<16)
				{hex_b = "0" + hex_b;}
				sb.Append(hex_b);
			}
			sb.Insert(8,' ');
			strCPUID = sb.ToString();
			sb = null;
			strCPUID = strCPUID.ToUpper();
			return strCPUID;
		}
		public string	GetVRM(int oset, byte[] datablock)
		{
			string strVRM = "";
			StringBuilder sb = new StringBuilder(5,5);
			for(int cnt=oset; cnt<oset+2; cnt++)
			{
				string hex_b = Convert.ToString(datablock[cnt],16);//convert to a HEX value
				if(datablock[cnt]<16)
				{hex_b = "0" + hex_b;}
				sb.Append(hex_b);
			}
			sb.Insert(2,'.');
			strVRM = sb.ToString();
			sb = null;
			strVRM = strVRM.ToUpper();
			return strVRM;
		}
		public DateTime GetDTutc(int oset, byte[] datablock)
		{
			return ConvertSTCKtoDTutc(GetUINT64(oset,datablock));
		}		
		public DateTime ConvertSTCKtoDTutc(ulong STCK)
		{
			/*
			DateTime dt0001 = new DateTime(1,1,1,0,0,0,0,		//DateTime on 01/01/0001 00:00:00
				new System.Globalization.GregorianCalendar());	//Ticks = 0
			DateTime dt2000 = new DateTime(2000,1,1,0,0,0,0,	//DateTime on 01/01/2000 00:00:00
				new System.Globalization.GregorianCalendar());	//Ticks = 630822816000000000
			const ulong STCK2000 = 12925639065600000000;		//UTC STCK value on 01/01/2000 00:00:00 = 0xB361183F48000000
			ulong STCKdiff = STCK - STCK2000;						//difference between STCK and STCK2000
			double msecdiff = Convert.ToDouble(STCKdiff/4096000);	//# of millasec. since 01/01/2000 00:00:00
			DateTime dtSTCK = dt2000.AddMilliseconds(msecdiff);	//Add the msec between STCK2000 and STCK to the dt2000
			*/
			DateTime dt1900 = new DateTime(1900,1,1,0,0,0,0,	//DateTime on 01/01/0001 00:00:00 ?same as STCK=0
				new System.Globalization.GregorianCalendar());	//Ticks = 
			
			return dt1900.AddMilliseconds(Convert.ToDouble(STCK/4096000));
		}

	}

    /// <summary>
    /// Utility class to convert a stored numeric value from big-endian to 
    /// little-endian or from little-endian to big-endian.
    /// </summary>
    /// <remarks>
    /// 2006210 P. McClain		initial version
    /// </remarks>
    public class Endian
    {
        /// <summary>
        /// Swap the bytes of an unsigned integer from low (high) order to
        /// high (low) order.
        /// </summary>
        /// <param name="value">Number to reorder.</param>
        /// <returns>Reordered number.</returns>
        public static uint Swap(uint value)
        {
            return ((value & 0xFF000000) >> 24)
                 | (((value & 0x00FF0000) >> 16) << 8)
                 | (((value & 0x0000FF00) >> 8) << 16)
                 | ((value & 0x000000FF) << 24);
        }
    } // end of Endian
}
