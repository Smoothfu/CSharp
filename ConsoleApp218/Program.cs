using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp218
{
    class Program
    {
        static void Main(string[] args)
        {
            AddMethod();
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
    }
}
