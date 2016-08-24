using System;
using System.Linq;
using System.Globalization;


namespace Motion.Mobile.Utilities
{
	public static class Utils
	{
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
			Array.Reverse(byte_param);
			for (int i = 0; i < byte_param.Length; i++)
			{
				value += (byte_param[i] << (i * 8));
			}

			return value;
		}

		public static String ByteArrayToHexString(byte[] data)
		{
			string hex = BitConverter.ToString(data);
			return hex.Replace("-", " ");
		}

	}
}

