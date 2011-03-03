using System;
using System.Text;

namespace XSerialPort
{
	/// <summary>
	/// Description of SerialPortUtils.
	/// </summary>
	public static class Strings
	{
		public static byte[] ToASCIIByteArray(string s)
		{
			return Encoding.ASCII.GetBytes(s);
		}
		
		public static byte[] ToUnicodeByteArray(string s)
		{
			return Encoding.Unicode.GetBytes(s);
		}

		public static byte[] ToUTF7ByteArray(string s)
		{
			return Encoding.UTF7.GetBytes(s);
		}

		public static byte[] ToUtf8ByteArray(string s)
		{
			return Encoding.UTF8.GetBytes(s);
		}

		public static string FromUnicodeByteArray(byte[] bytes)
		{
			return Encoding.Unicode.GetString(bytes,0,bytes.Length);
		}

		public static string FromUTF7ByteArray(byte[] bytes)
		{
			return Encoding.UTF7.GetString(bytes,0,bytes.Length);
		}

		public static string FromUtf8ByteArray(byte[] bytes)
		{
			return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
		}
		
		public static string FromASCIIByteArray(byte[] bytes)
		{
			return Encoding.ASCII.GetString(bytes,0,bytes.Length);
		}

		public static string FromByteArray(byte[] bytes)
		{
			char[] cs = new char[bytes.Length];
			for (int i = 0; i < bytes.Length; i++)
			{
				cs[i]=Convert.ToChar(bytes[i]);
			}
			return new string(cs);
		}
		
		public static byte[] ToByteArray(string s)
		{
			byte[] bs = new byte[s.Length];
			for (int i = 0; i < bs.Length; ++i)
			{
				bs[i] = Convert.ToByte(s[i]);
			}
			return bs;
		}
		
		public static string ToHex(byte[] data)
		{
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < data.Length; i++)
				builder.Append(data[i].ToString("X2"));
			
			return builder.ToString();
		}
	}
}
