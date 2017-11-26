using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp26;
using System.Reflection;

namespace ConsoleApp26
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(CSharpModule);
            var attrs = type.GetCustomAttributes<CompanyInfoAttribute>();
            foreach(var at in attrs)
            {
                Console.WriteLine(at.CompanyInfo);
                Console.WriteLine(at.CompanyName);
            }
            Console.ReadLine();            
        }
    }

    [CompanyInfo(CompanyName = "SmoothInfo", CompanyInfo = "www.tencent.com")]
    public class CSharpModule : IAppFunctionality
    {
        public void DoIt()
        {
            MessageBox.Show("You have just used the C# snap-in!");
        }
    }


}
