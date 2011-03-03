using System;
using System.Runtime.InteropServices;

namespace XSerialPort
{
	[StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct COMMTIMEOUTS
    {
        public int ReadIntervalTimeout;
        public int ReadTotalTimeoutMultiplier;
        public int ReadTotalTimeoutConstant;
        public int WriteTotalTimeoutMultiplier;
        public int WriteTotalTimeoutConstant;
    }
}
