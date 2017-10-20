using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp79
{
    delegate T NumberChange<T>(T n);
    class Program
    {
        static int num = 10;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }

        public static int getNum()
        {
            return num;
        }
        static void Main(string[] args)
        {
            //创建委托实例
            NumberChange<int> nc1 = new NumberChange<int>(AddNum);
            NumberChange<int> nc2 = new NumberChange<int>(MultNum);

            //使用委托对象调用方法
            nc1(25);
            Console.WriteLine("Value of Num: {0}", getNum());
            nc2(5);
            Console.WriteLine("Value of Num:{0}", getNum());

            Console.ReadLine();
        }
    }
}
 