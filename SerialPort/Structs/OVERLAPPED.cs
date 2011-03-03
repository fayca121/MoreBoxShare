using System;
using System.Runtime.InteropServices;

namespace XSerialPort
{
	[StructLayout(LayoutKind.Sequential, Pack=1)]
	public struct OVERLAPPED
	{
		public int Internal;
		public int InternalHigh;
		public int Offset;
		public int OffsetHigh;
		public IntPtr hEvent;
	}
}
