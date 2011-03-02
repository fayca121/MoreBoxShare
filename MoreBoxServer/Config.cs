using System;
using System.Configuration;
using ZylSerialPort;

namespace MoreBoxServer
{
    /// <summary>
    /// Description of Config.
    /// </summary>
    public class Config
    {
        private readonly int capacity;
        private readonly SerialPort.SerialBaudRate baudRate;
        private readonly SerialPort.SerialDataWidth dataWidth;
        private readonly SerialPort.SerialCommPort port;
        private readonly SerialPort.SerialStopBits stopBits;
        private readonly SerialPort.SerialParityBits parityBits;
        private readonly string server;
        private readonly int serverPort;

        public Config()
        {
            switch (ConfigurationManager.AppSettings["BaudRate"])
            {
                case "115200": baudRate = SerialPort.SerialBaudRate.br115200;
                    break;
                case "9600": baudRate = SerialPort.SerialBaudRate.br009600;
                    break;
                case "14400": baudRate = SerialPort.SerialBaudRate.br014400;
                    break;
                case "19200": baudRate = SerialPort.SerialBaudRate.br019200;
                    break;
                case "38400": baudRate = SerialPort.SerialBaudRate.br038400;
                    break;
                case "57600": baudRate = SerialPort.SerialBaudRate.br057600;
                    break;
                case "128000": baudRate = SerialPort.SerialBaudRate.br128000;
                    break;
                case "7200": baudRate = SerialPort.SerialBaudRate.br007200;
                    break;
                case "4800": baudRate = SerialPort.SerialBaudRate.br004800;
                    break;
                case "2400": baudRate = SerialPort.SerialBaudRate.br002400;
                    break;
                case "1800": baudRate = SerialPort.SerialBaudRate.br001800;
                    break;
                case "1200": baudRate = SerialPort.SerialBaudRate.br001200;
                    break;
                case "600": baudRate = SerialPort.SerialBaudRate.br000600;
                    break;
                default: baudRate = SerialPort.SerialBaudRate.br000300;
                    break;
            }

            switch (Int32.Parse(ConfigurationManager.AppSettings["DataWidth"]))
            {
                case 8: dataWidth = SerialPort.SerialDataWidth.dw8Bits;
                    break;
                case 7: dataWidth = SerialPort.SerialDataWidth.dw7Bits;
                    break;
                case 6: dataWidth = SerialPort.SerialDataWidth.dw6Bits;
                    break;
                default:
                    dataWidth = SerialPort.SerialDataWidth.dw5Bits;
                    break;
            }

            switch (ConfigurationManager.AppSettings["Port"].ToUpper())
            {
                case "COM1": port = SerialPort.SerialCommPort.COM01;
                    break;
                case "COM2": port = SerialPort.SerialCommPort.COM02;
                    break;
                case "COM3": port = SerialPort.SerialCommPort.COM03;
                    break;
                case "COM4": port = SerialPort.SerialCommPort.COM04;
                    break;
                case "COM5": port = SerialPort.SerialCommPort.COM05;
                    break;
                case "COM6": port = SerialPort.SerialCommPort.COM06;
                    break;
                case "COM7": port = SerialPort.SerialCommPort.COM07;
                    break;
                case "COM8": port = SerialPort.SerialCommPort.COM08;
                    break;
                case "COM9": port = SerialPort.SerialCommPort.COM09;
                    break;
                default:
                    port = SerialPort.SerialCommPort.COM10;
                    break;


            }

            switch (Int32.Parse(ConfigurationManager.AppSettings["StopBits"]))
            {
                case 1: stopBits = SerialPort.SerialStopBits.sb1Bit;
                    break;
                case 2: stopBits = SerialPort.SerialStopBits.sb2Bits;
                    break;
                default:
                    stopBits = SerialPort.SerialStopBits.sb1_5Bits;
                    break;

            }

            switch (ConfigurationManager.AppSettings["ParityBits"].ToUpper())
            {
                case "NONE": parityBits = SerialPort.SerialParityBits.pbNone;
                    break;
                case "EVEN": parityBits = SerialPort.SerialParityBits.pbEven;
                    break;
                case "ODD": parityBits = SerialPort.SerialParityBits.pbOdd;
                    break;
                case "SPACE": parityBits = SerialPort.SerialParityBits.pbSpace;
                    break;
                default: parityBits = SerialPort.SerialParityBits.pbMark;
                    break;
            }

            server = ConfigurationManager.AppSettings["MbServer"];
            serverPort = Int32.Parse(ConfigurationManager.AppSettings["SPort"]);
            capacity = Int32.Parse(ConfigurationManager.AppSettings["Users"]);
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public SerialPort.SerialBaudRate BaudRate
        {
            get { return baudRate; }
        }
        public SerialPort.SerialDataWidth DataWidth
        {
            get { return dataWidth; }
        }
        public SerialPort.SerialCommPort Port
        {
            get { return port; }
        }
        public SerialPort.SerialStopBits StopBits
        {
            get { return stopBits; }
        }

        public SerialPort.SerialParityBits ParityBits
        {
            get { return parityBits; }
        }

        public string Server
        {
            get { return server; }
        }

        public int ServerPort
        {
            get { return serverPort; }
        }
    }
}
