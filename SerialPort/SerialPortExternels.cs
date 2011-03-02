using System;
using System.Runtime.InteropServices;

namespace XSerialPort
{
	public class SerialPortExternels
	{
	 [DllImport("kernel32.dll", SetLastError=true)]
     internal static extern int ClearCommError(IntPtr hFile, out int lpErrors, ref COMSTAT lpComStat);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal static extern bool GetCommModemStatus(IntPtr hObject, ref ulong lpModemStat);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal static extern int GetCommState(IntPtr hCommDev, ref DCB lpDCB);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal static extern int PurgeComm(IntPtr hFile, int dwFlags);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal static extern int ReadFile(IntPtr hFile, byte[] Buffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, int Flags);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal static extern int SetCommState(IntPtr hCommDev, ref DCB lpDCB);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal static extern int SetCommTimeouts(IntPtr hFile, ref COMMTIMEOUTS lpCommTimeouts);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal static extern bool SetupComm(IntPtr hObject, int InBuffer, int OutBuffer);
     
     [DllImport("winmm.dll")]
     internal static extern uint timeBeginPeriod(uint period);
     
     [DllImport("winmm.dll")]
     internal static extern uint timeEndPeriod(uint period);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal static extern int WriteFile(IntPtr hFile, byte[] Buffer, int nNumberOfBytesToWrite, ref int lpNumberOfBytesWritten, int Flags);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal static extern bool EscapeCommFunction(IntPtr hFile, uint dwFunc);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal static extern bool CloseHandle(IntPtr hObject);
     
     [DllImport("kernel32.dll", CharSet=CharSet.Auto, SetLastError=true)]
     internal static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, int lpSecurityAttributes, uint dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);
     
	}
}
