using System;

namespace XSerialPort
{
    public class LineStatusEventArgs : EventArgs
    {
        private ulong m_LineStatus;

        public LineStatusEventArgs(ulong lineStatus)
        {
            this.m_LineStatus = lineStatus;
        }

        public ulong LineStatus
        {
            get
            {
                return this.m_LineStatus;
            }
        }
    }
}
