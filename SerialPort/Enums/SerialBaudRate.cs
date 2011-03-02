using System;

namespace XSerialPort
{
    public enum SerialBaudRate
    {
        br000075 = 0x4b,
        br000110 = 110,
        br000134 = 0x86,
        br000150 = 150,
        br000300 = 300,
        br000600 = 600,
        br001200 = 0x4b0,
        br001800 = 0x708,
        br002400 = 0x960,
        br004800 = 0x12c0,
        br007200 = 0x1c20,
        br009600 = 0x2580,
        br014400 = 0x3840,
        br019200 = 0x4b00,
        br038400 = 0x9600,
        br057600 = 0xe100,
        br115200 = 0x1c200,
        br128000 = 0x1f400,
        br230400 = 0x38400,
        br256000 = 0x3e800,
        br460800 = 0x70800,
        br921600 = 0xe1000,
        brCustom = 0
    }
}
