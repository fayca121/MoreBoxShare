using System;
using System.Text;

namespace XSerialPort
{
	/// <summary>
	/// Description of SerialPortUtils.
	/// </summary>
	public class SerialPortUtils
	{
		public static byte[] StringToASCIIByteArray(string text)
		{
			ASCIIEncoding encoding = new ASCIIEncoding();
			return encoding.GetBytes(text);
		}

		public static byte[] StringToUnicodeByteArray(string text)
		{
			UnicodeEncoding encoding = new UnicodeEncoding();
			return encoding.GetBytes(text);
		}

		public static byte[] StringToUTF7ByteArray(string text)
		{
			UTF7Encoding encoding = new UTF7Encoding();
			return encoding.GetBytes(text);
		}

		public static byte[] StringToUTF8ByteArray(string text)
		{
			UTF8Encoding encoding = new UTF8Encoding();
			return encoding.GetBytes(text);
		}

		public static string UnicodeByteArrayToString(byte[] characters)
		{
			UnicodeEncoding encoding = new UnicodeEncoding();
			return encoding.GetString(characters);
		}

		public static string UTF7ByteArrayToString(byte[] characters)
		{
			UTF7Encoding encoding = new UTF7Encoding();
			return encoding.GetString(characters);
		}

		public static string UTF8ByteArrayToString(byte[] characters)
		{
			UTF8Encoding encoding = new UTF8Encoding();
			return encoding.GetString(characters);
		}
		
		public static string ASCIIByteArrayToString(byte[] characters)
		{
			ASCIIEncoding encoding = new ASCIIEncoding();
			return encoding.GetString(characters);
		}

		public static string ByteArrayToDecimalString(byte[] data)
		{
			string str = string.Empty;
			for (int i = 0; i < (data.Length - 1); i++)
			{
				str = str + data[i].ToString();
			}
			return str;
		}
		
		public static string ByteArrayToHexaString(byte[] data)
        {
            string str = string.Empty;
            for (int i = 0; i < (data.Length - 1); i++)
            {
                str = str + data[i].ToString("x");
            }
            return str;
        }
	}
}
