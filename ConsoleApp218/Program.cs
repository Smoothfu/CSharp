using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp218
{
    class Program
    {
        static int x = 3452345, y = 32545235;
        static void Main(string[] args)
        {
            Func<int> func = AddXY;
            int finalResult = func.Invoke() ;
            Console.WriteLine(finalResult);
            Console.ReadLine();
        }

        static async void AddMethod()
        {
            int result = await GetIntAsync(243345234, 3452345);
            Console.WriteLine(result);
        }
        static Task<int> GetIntAsync(int x,int y)
        {
            return Task.Run(() => {
                return x + y;
            });
                
        }

        static int AddXY()
        {
            return x + y;
        }
    }
}
