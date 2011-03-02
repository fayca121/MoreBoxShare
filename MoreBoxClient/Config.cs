using System;
using XSerialPort;
using System.Configuration;

namespace MoreBoxClient
{
    class Config
    {
        private readonly SerialBaudRate baudRate;
        private readonly SerialDataWidth dataWidth;
        private readonly SerialCommPort port;
        private readonly SerialStopBits stopBits;
        private readonly SerialParityBits parityBits;

        public Config()
        {
            switch (ConfigurationManager.AppSettings["BaudRate"])
            {
                case "115200": baudRate = SerialBaudRate.br115200;
                    break;
                case "9600": baudRate = SerialBaudRate.br009600;
                    break;
                case "14400": baudRate = SerialBaudRate.br014400;
                    break;
                case "19200": baudRate = SerialBaudRate.br019200;
                    break;
                case "38400": baudRate = SerialBaudRate.br038400;
                    break;
                case "57600": baudRate = SerialBaudRate.br057600;
                    break;
                case "128000": baudRate = SerialBaudRate.br128000;
                    break;
                case "7200": baudRate = SerialBaudRate.br007200;
                    break;
                case "4800": baudRate = SerialBaudRate.br004800;
                    break;
                case "2400": baudRate = SerialBaudRate.br002400;
                    break;
                case "1800": baudRate = SerialBaudRate.br001800;
                    break;
                case "1200": baudRate = SerialBaudRate.br001200;
                    break;
                case "600": baudRate = SerialBaudRate.br000600;
                    break;
                default: baudRate = SerialBaudRate.br000300;
                    break;
            }

            switch (Int32.Parse(ConfigurationManager.AppSettings["DataWidth"]))
            {
                case 8: dataWidth = SerialDataWidth.dw8Bits;
                    break;
                case 7: dataWidth = SerialDataWidth.dw7Bits;
                    break;
                case 6: dataWidth = SerialDataWidth.dw6Bits;
                    break;
                default:
                    dataWidth = SerialDataWidth.dw5Bits;
                    break;
            }

            switch (Int32.Parse(ConfigurationManager.AppSettings["StopBits"]))
            {
                case 1: stopBits = SerialStopBits.sb1Bit;
                    break;
                case 2: stopBits = SerialStopBits.sb2Bits;
                    break;
                default:
                    stopBits = SerialStopBits.sb1_5Bits;
                    break;

            }

            switch (ConfigurationManager.AppSettings["ParityBits"].ToUpper())
            {
                case "NONE": parityBits = SerialParityBits.pbNone;
                    break;
                case "EVEN": parityBits = SerialParityBits.pbEven;
                    break;
                case "ODD": parityBits = SerialParityBits.pbOdd;
                    break;
                case "SPACE": parityBits = SerialParityBits.pbSpace;
                    break;
                default: parityBits = SerialParityBits.pbMark;
                    break;
            }

            port = SerialPort.StringToSerialCommPort(ConfigurationManager.AppSettings["Port"].ToUpper());
        }

        public SerialBaudRate BaudRate
        {
            get { return baudRate; }
        }
        public SerialDataWidth DataWidth
        {
            get { return dataWidth; }
        }
        public SerialCommPort Port
        {
            get { return port; }
        }
        public SerialStopBits StopBits
        {
            get { return stopBits; }
        }

        public SerialParityBits ParityBits
        {
            get { return parityBits; }
        }
    }
}
