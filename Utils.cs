using System;
using System.Diagnostics;
using System.Linq;
using System.Globalization;


namespace Motion.Mobile.Utilities
{
	public static class Utils
	{
		public const int INDEX_ONE = 1;

		public static string StringToHexString(string param)
		{
			char[] charValues = param.ToCharArray();
			string hexOutput="";
			foreach (char _eachChar in charValues )
			{
				// Get the integral value of the character.
				int value = Convert.ToInt32(_eachChar);
				// Convert the decimal value to a hexadecimal value in string form.
				hexOutput += String.Format("{0:X}", value);
				// to make output as your eg 
				//  hexOutput +=" "+ String.Format("{0:X}", value);
			}
			return hexOutput;
		}

		public static byte[] StringToByteArray(string str) 
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

		public static string GetString(byte[] bytes)
		{
			char[] chars = new char[bytes.Length / sizeof(char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}

		public static string getMonthFullName(DateTime date)
		{
			return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName (date.Month);
		}

		public static string getMonthShortName(DateTime date)
		{
			return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName (date.Month);
		}

		public static long getDecimalValue(byte[] byte_param)
		{
			long value = 0;
			if(BitConverter.IsLittleEndian)
				Array.Reverse(byte_param);
			for (int i = 0; i < byte_param.Length; i++)
			{
				value += (byte_param[i] << (i * 8));
			}

			return value;
		}

		public static void reverseBytesForEndianessHandling(byte[] byte_param)
		{
			byte temp;
			for (int i = 0; i+1 < byte_param.Length;)
			{
				temp = byte_param[i + 1];
				byte_param[i + 1] = byte_param[i];
				byte_param[i] = temp;
				i += 2;
			}

		}

		public static string ByteArrayToHexString(byte[] data)
		{
			string hex = BitConverter.ToString(data);
			return hex.Replace("-", " ");
		}

		public static bool isValidYear(int year_value)
		{
			return (year_value <= DateTime.Now.Year && year_value >= 2013) ? true : false;
		}

		public static bool isValidMonth(int month_value)
		{
			return (month_value <= 12 && month_value >= 0) ? true : false;
		}

		public static bool isValidDay(int year_value, int month_value, int day_value)
		{
			bool isValid = true;
			int febMaxDayValue = (year_value % 4 == 0) ? 29 : 28;
			switch (month_value)
			{
				case 1:
					isValid = (day_value > 0 && day_value <= 31) ? true : false;
					break;
				case 2:
					isValid = (day_value > 0 && day_value <= febMaxDayValue) ? true : false;
					break;
				case 3:
					isValid = (day_value > 0 && day_value <= 31) ? true : false;
					break;
				case 4:
					isValid = (day_value > 0 && day_value <= 30) ? true : false;
					break;
				case 5:
					isValid = (day_value > 0 && day_value <= 31) ? true : false;
					break;
				case 6:
					isValid = (day_value > 0 && day_value <= 30) ? true : false;
					break;
				case 7:
					isValid = (day_value > 0 && day_value <= 31) ? true : false;
					break;
				case 8:
					isValid = (day_value > 0 && day_value <= 31) ? true : false;
					break;
				case 9:
					isValid = (day_value > 0 && day_value <= 30) ? true : false;
					break;
				case 10:
					isValid = (day_value > 0 && day_value <= 31) ? true : false;
					break;
				case 11:
					isValid = (day_value > 0 && day_value <= 30) ? true : false;
					break;
				case 12:
					isValid = (day_value > 0 && day_value <= 31) ? true : false;
					break;
				default:
					isValid = false;
					break;
			}

			return isValid;
		}

		public static string GetDeviceServicesURL()
		{
			//Currently return the Model Environment
			//return "https://atl.sync.hattrickmotion.com/api/Pedometer/";
			return "https://test.savvysherpa.com/DeviceServices/api/Pedometer/";
		}

		public static int GetCheckSumWithBytes(byte[] data)
		{ 
			int checksum = 0;

			for (int i = 0; i < data.Length; i++)
			{
				checksum += data[i];
			}

			checksum &= 0xffff;

			return checksum;
		}

		public static DateTime GetServerDateTimeFromString(string dateTimeString)
		{
			string[] serverTimeComponents = dateTimeString.Split(new Char[] { '-', ':', ' ' });
			int[] dateComponents = new int[]{ 0, 0, 0, 0, 0, 0 };
			int i = 0;
			Debug.WriteLine("Printing out DateTime Array");
			foreach (string word in serverTimeComponents)
			{
				Debug.WriteLine(word);
				dateComponents[i++] = Convert.ToInt32(word);

			}


			DateTime st = new DateTime(dateComponents[0] + 2000, dateComponents[1], dateComponents[2], dateComponents[3], dateComponents[4], dateComponents[5]);
			return st;
		}

		public static double DateTimeToUnixTimestamp(DateTime dateTime)
		{
			DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			long unixTimeStampInTicks = (dateTime.ToUniversalTime() - unixStart).Ticks;
			return (double)unixTimeStampInTicks / TimeSpan.TicksPerSecond;
		}

		public static DateTime GetUTCDateWithDate(DateTime dateTime)
		{ 
			DateTime utcDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, System.DateTimeKind.Utc);
			return utcDate;
		}

		public static DateTime GetDeviceDateTimeWithFormat(DateTime unformattedDate)
		{
			DateTime currentDT = unformattedDate;
			DateTime dt = new DateTime(currentDT.Year, currentDT.Month, currentDT.Day, currentDT.Hour, currentDT.Minute, currentDT.Second);
			String.Format("{0:yy-MM-dd HH:mm:ss}", dt);
			return dt;
		}

		public static string GetStringDateV1(int year, int month, int day, int hour, int min, int sec)
		{
			DateTime dt = new DateTime(year, month, day,hour,min,sec);
			String.Format("{0:yy-MM-dd HH:mm:ss}", dt);
			return dt.ToString();
		}

		public static DateTime GetDateFromDateComponentsV1(int year, int month, int day)
		{
			DateTime dt = new DateTime(year, month, day);
			String.Format("{0:yyyy-MM-dd}", dt);
			return dt;
		}

	}
}

