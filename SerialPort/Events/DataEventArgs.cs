using System;

namespace XSerialPort
{
    public class DataEventArgs : EventArgs
    {
        private byte[] m_Buffer;

        public DataEventArgs(byte[] bufferArray)
        {
            this.m_Buffer = bufferArray;
        }

        public byte[] Buffer
        {
            get
            {
                return this.m_Buffer;
            }
        }
    }
}
