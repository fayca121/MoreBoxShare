using System;
using System.Runtime.InteropServices;

namespace XSerialPort
{
	[StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct COMSTAT
    {
        public int fBitFields;
        public int cbInQue;
        public int cbOutQue;
    }
}
