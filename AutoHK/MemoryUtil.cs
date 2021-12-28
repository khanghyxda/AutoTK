using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AutoHK
{
    class MemoryUtil
    {
        [DllImport("kernel32.dll")]
        public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
          [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);


        public static int ReadInt32(long Address, uint length = 4, IntPtr? Handle = null)
        {
            return BitConverter.ToInt32(ReadBytes((IntPtr)Handle, Address, length), 0);
        }

        public static byte[] ReadBytes(IntPtr Handle, Int64 Address, uint BytesToRead)
        {
            IntPtr ptrBytesRead;
            byte[] buffer = new byte[BytesToRead];
            ReadProcessMemory(Handle, new IntPtr(Address), buffer, BytesToRead, out ptrBytesRead);
            return buffer;
        }

        public static string ReadString(long Address, uint length = 32, IntPtr? Handle = null)
        {
            string temp3 = Encoding.Unicode.GetString(ReadBytes((IntPtr)Handle, Address, length));

            string[] temp3str = temp3.Split('\0');
            return temp3str[0];
        }
    }

}
