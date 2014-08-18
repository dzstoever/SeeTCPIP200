using csi.see.classlib1;
using System;
using System.Diagnostics;


namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for TcpIpMessage.
	/// </summary>
	public class TcpIpMessage
	{
        private static RawDataConverter converter = new RawDataConverter();
        public static string GetMessage(byte[] blok)
        { return converter.GetEBCDIC(16, blok, converter.GetUINT16(14, blok)); }
        public static DateTime GetTimeStamp(byte[] blok)
        { return converter.GetDTutc(16, blok); }            

		private byte[] blok;
		private string text;
		public const string STANDARD_VSE_DATE = "yyyyMMdd hhmmss.ff";
		private string format = STANDARD_VSE_DATE;
		
		private DateTime timeStamp;
		/// <summary>
		/// 
		/// </summary>
		public DateTime TimeStamp 
		{
			get { return timeStamp; }
		}

		private string taskId;
		/// <summary>
		/// 
		/// </summary>
		public string TaskId 
		{
			get { return taskId; }
		}

		private string code;
		/// <summary>
		/// 
		/// </summary>
		public string Code 
		{
			get { return code; }
		}

		private string message;
		/// <summary>
		/// 
		/// </summary>
		public string Message 
		{
			get 
			{ return message; }
		}

        public TcpIpMessage(byte[] blok)
        {
            this.blok = blok;
            try
            {
                taskId = converter.GetEBCDIC(35, blok, 5);
                if (taskId.EndsWith(":") == false)
                    taskId = null;

                if (taskId == null)
                {
                    code = converter.GetEBCDIC(35, blok, 7);
                    if (IsCode(code) == true)
                        message = converter.GetEBCDIC(43, blok, converter.GetUINT16(14, blok) - 27);
                    else
                    {
                        code = null;
                        message = converter.GetEBCDIC(35, blok, converter.GetUINT16(14, blok) - 19);
                    }
                }
                else
                {
                    code = converter.GetEBCDIC(41, blok, 7);
                    if (IsCode(code) == true)
                        message = converter.GetEBCDIC(49, blok, converter.GetUINT16(14, blok) - 33);
                    else
                    {
                        code = null;
                        message = converter.GetEBCDIC(41, blok, converter.GetUINT16(14, blok) - 25);
                    }
                }
            }
            catch (IndexOutOfRangeException ioore)
            {
                message = converter.GetEBCDIC(35, blok, converter.GetUINT16(14, blok) - 19);
                Debug.WriteLine(ioore.Message + "message=" + message);
            }
        }
        public TcpIpMessage(String text) 
		{
            this.text = text;
			this.timeStamp = DateUnformatter(text.Substring(0, 18));
			
			try 
			{
				taskId = text.Substring(19, 5);
				if (taskId.EndsWith(":") == false)
					taskId = null;

				if (taskId == null) 
				{
					code = text.Substring(19, 7);
					if (IsCode(code) == true) 
						message = text.Substring(27);
					else 
					{
						code = null;
						message = text.Substring(19);
					}	
				}
				else 
				{ 
					code = text.Substring(25, 7);
					if (IsCode(code) == true)
						message = text.Substring(33);
					else 
					{
						code = null;
						message = text.Substring(25);
					}
				}
			} 
			catch (ArgumentOutOfRangeException) 
			{
				message = text.Substring(19);
				//Debug.WriteLine(ioore.Message + "message=" + message);
			}

			
		}
	
		private bool IsCode(string code) 
		{
			if (code.Length != 7)
				return false;

			char[] ca = code.ToCharArray();
			if (Char.IsLetter(ca[0])
				&& Char.IsLetter(ca[1])
				&& Char.IsLetterOrDigit(ca[2])
				&& Char.IsDigit(ca[3])
				&& Char.IsDigit(ca[4])
				&& Char.IsDigit(ca[5])
				&& Char.IsLetter(ca[6]))
				return true;
			else
				return false;
		}
				
        public override string ToString() 
		{
			if (blok != null)
				return converter.GetEBCDIC(16, blok, converter.GetUINT16(14, blok));				
			else
				return text;
		}
		
		/// <summary>
		/// Format the date and time as a string one of the following.
		///		STANDARD_VSE_DATE "yyyyMMdd hhmmss.f"
		/// </summary>
		/// <param name="dt">Date and time.</param>
		/// <returns>A string representation of the specified date and time</returns>	
		public string DateFormatter(DateTime dt) 
		{
			return dt.ToString(format);
		}

        private DateTime DateUnformatter(string date)
        {
            int year = Convert.ToUInt16(date.Substring(0, 4));
            int month = Convert.ToUInt16(date.Substring(4, 2));
            int day = Convert.ToUInt16(date.Substring(6, 2));
            int hour = Convert.ToUInt16(date.Substring(9, 2));
            int minute = Convert.ToUInt16(date.Substring(11, 2));
            int second = Convert.ToUInt16(date.Substring(13, 2));
            int millisecond = Convert.ToUInt16(date.Substring(16, 2));

            return new DateTime(year, month, day, hour, minute, second, millisecond);
        }
	} // end of TcpIpMessage
}
