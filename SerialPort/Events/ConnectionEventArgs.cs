using System;

namespace XSerialPort
{
    public class ConnectionEventArgs : EventArgs
    {
        private SerialCommPort m_Port;

        public ConnectionEventArgs(SerialCommPort port)
        {
            this.m_Port = port;
        }

        public SerialCommPort Port
        {
            get
            {
                return this.m_Port;
            }
        }
    }
}
