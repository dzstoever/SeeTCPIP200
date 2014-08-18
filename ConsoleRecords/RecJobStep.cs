using csi.see.classlib1;
using System;
using System.Diagnostics;


namespace ConsoleRecords
{
	/// <summary>
	/// Represents an end of job step record.  The data secton of the record
	/// adheres to the following format:
	/// 0010 T005_STEPJBNM DS	CL8		Job name
	/// 0018 T005_STEPSTEP DS	CL8     Exec step name
	/// 0020 T005_STEPDURT DS	XL4     Step duration(binary 300=1second)
	/// 0024 T005_STEPCPUT DS	XL4     CPU time used(binary 300=1second)
	/// 0028 T005_STEPTSIO DS	XL8     Total i/o count to all devices
	/// 0030 T005_STEPDATE DS	CL8     Job date(ccyymmdd)
	/// 0038 T005_STEPSTRT DS	CL6     Step start time(hhmmss)
	/// 003E T005_STEPSTOP DS	CL6     Step stop  time(hhmmss)
	/// 0044 T005_STEPPTID DS	CL2     Partition id
	/// </summary>
	public class RecJobStep
	{
		#region MEMBER PROPERTIES
		private string jobName = "";
		/// <summary>
		/// Get job name property.
		/// </summary>
		public string JobName 
		{
			get { return jobName; }
		}
		
		private string stepName = "";
		/// <summary>
		/// Get step name property.
		/// </summary>
		public string StepName
		{
			get { return stepName; }
		}
		
		private float duration = 0;
		/// <summary>
		/// Get step duration property.
		/// </summary>
		public float Duration 
		{
			get { return duration; }
		}
		
		private float cpuUsed = 0;
		/// <summary>
		/// Get CPU time used property.
		/// </summary>
		public float CpuUsed 
		{
			get { return cpuUsed; }
		}

		private ulong ioCount = 0;
		/// <summary>
		/// Get total I/O count to all devices property.
		/// </summary>
		public ulong IoCount 
		{
			get { return ioCount; }
		}
		
		private string jobDate;
		/// <summary>
		/// Get job date property: ccyymmdd.
		/// </summary>
		public string JobDate 
		{
			get { return jobDate; }
		}
				
		private DateTime stepStart;
		/// <summary>
		/// Get step start time property: hhmmss.
		/// </summary>
		public DateTime StepStart 
		{
			get { return stepStart; }
		}

		private DateTime stepStop;
		/// <summary>
		/// Get step stop time property: hhmmss.
		/// </summary>
		public DateTime StepStop 
		{
			get { return stepStop; }
		}

		private string partitionId = "";
		/// <summary>
		/// Get partition ID property.
		/// </summary>
		public string PartitionId 
		{
			get { return partitionId; }
		}
		#endregion

		//public const string STANDARD_VSE_DATE = "yyyyMMdd";
		public const string STANDARD_VSE_TIME = "hhmmss";

		#region CONSTRUCTORS AND DECONSTRUCTORS
		/// <summary>
		/// Create an instance of a JobStep object.
		/// </summary>
		/// <param name="blok">Job step record in EBCDIC format.</param>
		public RecJobStep(byte[] blok)
		{
			RawDataConverter converter = new RawDataConverter();
			
			try 
			{
				stepName = converter.GetEBCDIC(0x10, blok, 8);
				jobName = converter.GetEBCDIC(0x18, blok, 8);
				duration = (float) converter.GetUINT32(0x20, blok) / 300F;
				cpuUsed = (float) converter.GetUINT32(0x24, blok) / 300F;
				ioCount = converter.GetUINT64(0x28, blok);

				jobDate = converter.GetEBCDIC(0x30, blok, 8);
				int year = Convert.ToInt32(converter.GetEBCDIC(0x30, blok, 4));
				int month = Convert.ToInt32(converter.GetEBCDIC(0x34, blok, 2));
				int day = Convert.ToInt32(converter.GetEBCDIC(0x36, blok, 2));
								
				DateTime dt = new DateTime(year, month, day);
			
				int hour = Convert.ToInt32(converter.GetEBCDIC(0x38, blok, 2));
				int minute = Convert.ToInt32(converter.GetEBCDIC(0x3A, blok, 2));
				int second = Convert.ToInt32(converter.GetEBCDIC(0x3C, blok, 2));
				
				stepStart = new DateTime(year, month, day, hour, minute, second);

				stepStop = stepStart.AddSeconds(duration);
							
				partitionId = converter.GetEBCDIC(0x44, blok, 2);
			} 
			catch (IndexOutOfRangeException ioore) 
			{
				Debug.WriteLine(ioore.Message);
			}
		}
		

		public RecJobStep(
			string stepName,
			string jobName,
			float duration,
			float cpuUsed,
			ulong ioCount,
			DateTime stepStart,
			DateTime stepStop,
			string partitionId) 
		{
			this.stepName = stepName;
			this.jobName = jobName;
			this.duration = duration;
			this.cpuUsed = cpuUsed;
			this.ioCount = ioCount;
			this.stepStart = stepStart;
			this.stepStop = stepStop;
			this.partitionId = partitionId;

			// create a job date using the date from the step start time.

			jobDate = stepStart.ToString("yyyyMMdd");
		}

		#endregion

		#region MEMBER METHODS
		
		/// <summary>
		/// Returns the string representation of the job step record.
		/// </summary>
		/// <returns>Job step record.</returns>
		public override string ToString()
		{
			return 
			 partitionId.PadRight(3, ' ')
			 + "  " + jobName.PadRight(8, ' ')
			 + "  " + stepName.PadRight(9, ' ')
			 + "  " + CpuFormatter(cpuUsed).PadRight(13, ' ')
			 + "  " + ioCount.ToString().PadRight(13, ' ')
			 + "  " + DurationFormatter(duration).PadRight(13, ' ')
			 //+ "  " + jobDate.PadRight(8, ' ')
			 + "  " + stepStart.ToString().PadRight(22, ' ')
			 //+ "  " + stepStart     TimeFormatter(stepStart)
			 + "  " + stepStop.ToString().PadRight(22, ' ');
			 //+ "  " + TimeFormatter(stepStop);
			 
			 
		}

		public static string TimeFormatter(DateTime dt) 
		{
			return dt.ToString(STANDARD_VSE_TIME);
		}

		public static string DurationFormatter(float duration) 
		{
			return duration.ToString("n3");
		}

		public static string CpuFormatter(float cpuUsed) 
		{
			return cpuUsed.ToString("n3");
		}
		#endregion
	} // end of JobStep
}
