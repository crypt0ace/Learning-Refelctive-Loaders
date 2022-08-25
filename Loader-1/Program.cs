using System;
using System.Reflection;

namespace Loader_1
{
    internal class Program
    {
        public void Load(string path)
        {
            var asm = Assembly.LoadFile(path);
            Object[] param = new String[] { null };
            asm.EntryPoint.Invoke(null, param);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Load(@"C:\\Users\\crypt0ace\\Desktop\\VisualStudio\\Offensive-CSharp\\Learning-Reflective-Loaders\\LoadMe\\bin\\Release\\LoadMe.exe");
        }
    }
}
