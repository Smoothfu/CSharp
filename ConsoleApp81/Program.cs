using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp81
{
    delegate void NumberChanger(int n);
    class Program
    {
        static int num = 10;
        public static void AddNum(int p)
        {
            num += p;
            Console.WriteLine("Named method: {0}", num);
        }

        public static void MultNum(int q)
        {
            num *= q;
            Console.WriteLine("Named Method:{0}", num);
        }

        public static int GetNum()
        {
            return num;
        }
        static void Main(string[] args)
        {

            //使用匿名方法创建委托实例
            NumberChanger nc = delegate (int x)
              {
                  Console.WriteLine("Anonymous Method:{0}", x);
              };

            //使用匿名方法调用委托
            nc(10);

            //使用命名方法实例化委托
            nc = new NumberChanger(AddNum);

            //使用命名方法调用委托
            nc(5);

            //使用命名方法调用委托
            nc(2);
            Console.ReadKey();
        }
    }
}
