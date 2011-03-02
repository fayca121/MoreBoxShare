using System;

namespace XSerialPort
{
    public struct DCB
    {
        public int DCBLength;
        public int BaudRate;
        public uint Flags;
        public short wReserved1;
        public short XonLim;
        public short XoffLim;
        public byte ByteSize;
        public byte Parity;
        public byte StopBits;
        public char XonChar;
        public char XoffChar;
        public char ErrorChar;
        public char EofChar;
        public char EvtChar;
        public short wReserved2;
    }
}
