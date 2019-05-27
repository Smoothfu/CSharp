using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp349.MathServiceWCF;
using ConsoleApp349.ToUpperServiceWCF;
using ConsoleApp349.StringGetLengthService;
using ConsoleApp349.GetDataTableService;
using System.Data;

namespace ConsoleApp349
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDataTableFromDBClient client = new GetDataTableFromDBClient();
            string result = client.GetDataTableFromDBResult();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
