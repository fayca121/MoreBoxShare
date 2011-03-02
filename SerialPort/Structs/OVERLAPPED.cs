using System;

namespace XSerialPort
{

        public struct OVERLAPPED
        {
            public int Internal;
            public int InternalHigh;
            public int Offset;
            public int OffsetHigh;
            public IntPtr hEvent;
        }

}
