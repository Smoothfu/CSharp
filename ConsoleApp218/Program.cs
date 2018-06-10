using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp218
{
    class Program
    {
        static int x = 3452345, y = 32545235;
        static void Main(string[] args)
        {
            AsyncMethodswithMultipleAwaits();


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

        static  Task AddMethodXY(int x,int y)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
            });
        }

        static async void AsyncMethodswithMultipleAwaits()
        {
            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with the first task!");

            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with the second task!");

            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Donw with third task!");
        }
    }
}
