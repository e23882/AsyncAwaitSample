using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {

        #region Declarations
        private static Stopwatch watch = new Stopwatch();
        #endregion

        #region Property
        #endregion

        #region Memberfunction
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("0.exit  1.call api common  2.call api async");
                var key = Console.ReadLine().ToString();
                if (key.Equals("0"))
                    break;
                else
                {
                    Console.WriteLine("");
                    watch.Reset();
                    switch (key)
                    {
                        case "1":
                            watch.Start();
                            for (int i=0;i<5;i++)
                                GetApi();
                            watch.Stop();
                            Console.WriteLine(watch.Elapsed);

                            break;
                        case "2":
                            watch.Start();
                            for (int i = 0; i < 5; i++)
                                GetApiAsync();
                            watch.Stop();
                            Console.WriteLine(watch.Elapsed);
                            
                            break;
                    }
                }
            }
            
        }

        public static void GetApi()
        {
            HttpClient client = new HttpClient();
            var result = client.GetStringAsync("http://localhost:49913/api/Values/1").Result;
            Console.WriteLine(result);
        }
        public static async Task GetApiAsync()
        {
            HttpClient client = new HttpClient();
            var result =await client.GetStringAsync("http://localhost:49913/api/Values/1");
            
            Console.WriteLine($"CurrentResult : {result}" );
        }
        #endregion


    }
}
