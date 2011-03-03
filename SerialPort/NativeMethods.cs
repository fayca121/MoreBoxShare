using System;
using System.Runtime.InteropServices;

namespace XSerialPort
{
	internal static class NativeMethods
	{
	 [DllImport("kernel32.dll", SetLastError=true)]
     internal extern static int ClearCommError(IntPtr hFile, out int lpErrors, ref COMSTAT lpComStat);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal extern static bool GetCommModemStatus(IntPtr hObject, ref ulong lpModemStat);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal extern static int GetCommState(IntPtr hCommDev, ref DCB lpDCB);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal extern static int PurgeComm(IntPtr hFile, int dwFlags);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal extern static int ReadFile(IntPtr hFile, byte[] Buffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, int Flags);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal extern static int SetCommState(IntPtr hCommDev, ref DCB lpDCB);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal extern static int SetCommTimeouts(IntPtr hFile, ref COMMTIMEOUTS lpCommTimeouts);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal extern static bool SetupComm(IntPtr hObject, int InBuffer, int OutBuffer);
     
     [DllImport("winmm.dll")]
     internal extern static uint timeBeginPeriod(uint period);
     
     [DllImport("winmm.dll")]
     internal extern static uint timeEndPeriod(uint period);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal extern static int WriteFile(IntPtr hFile, byte[] Buffer, int nNumberOfBytesToWrite, ref int lpNumberOfBytesWritten, int Flags);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal extern static bool EscapeCommFunction(IntPtr hFile, uint dwFunc);
     
     [DllImport("kernel32.dll", SetLastError=true)]
     internal extern static bool CloseHandle(IntPtr hObject);
     
     [DllImport("kernel32.dll", CharSet=CharSet.Auto, SetLastError=true)]
     internal extern static IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, int lpSecurityAttributes, uint dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);
     
	}
}
