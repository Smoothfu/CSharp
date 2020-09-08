using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Delegates.Dels;
using Delegates.Dynamic;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = (int)Calculate("2*3");
            Console.WriteLine(result);
            Console.ReadLine();
        }

        static object Calculate(string expression)
        {
            ScriptEngine engine = Python.CreateEngine();
            return engine.Execute(expression);
        }

        static void ExpandObjectDemo()
        {
            dynamic x = new ExpandoObject();
            x.FavoriteColor = ConsoleColor.Green;
            x.FavoriteNumber = 7;
            Console.WriteLine(x.FavoriteColor);
            Console.WriteLine(x.FavoriteNumber);

            var dict = (IDictionary<string, object>)x;
            Console.WriteLine(dict["FavoriteColor"]);
            Console.WriteLine(dict["FavoriteNumber"]);
            Console.WriteLine(dict.Count);
        }

        static void DynamicInvokeMemberDemo()
        {
            dynamic doi = new DynamicObjectInvoker();
            doi.MakeMoney();
            doi.MakeBigMoney();
        }

        static void WebClientDownloadProgressChanged()
        {
            string url = "https://download.microsoft.com/download/d/1/c/d1c74788-0c6b-4d23-896e-67cf849d31ed/SSMS-Setup-ENU.exe";
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged1;
                wc.DownloadFileAsync(new Uri(url), "ssms.exe");
            }
        }

        private static void Wc_DownloadProgressChanged1(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine($"TotalBytesToReceive:{e.TotalBytesToReceive},BytesReceived:{e.BytesReceived},ProgressPercentage:{e.ProgressPercentage}");
        }

        static void DelBeginEndInvoke()
        {
            DelDemo demo = new DelDemo();
            MathDel mathDel = demo.Add;
            int x = 1, y = 10000000;
            IAsyncResult asyncResult = mathDel.BeginInvoke(x, y, DelCB, "Test this");
            int result = mathDel.EndInvoke(asyncResult);
            Console.WriteLine(result);
        }

        private static void DelCB(IAsyncResult ar)
        {
            Console.WriteLine(ar.AsyncState.ToString());
        }

        static void DelDemo()
        {
            DelDemo demo = new DelDemo();
            PrintMsgDel printDel = demo.PrintTime;
            printDel(null);
        }
    }
}
