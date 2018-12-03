using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ConsoleApp297
{
    class Program
    {
        delegate int Del(int i);
        delegate bool D();
        delegate bool D2(int i);

        class Test
        {
           public D del;
           public  D2 del2;

            public void TestMethod(int input)
            {
                int j = 0;

                //Initialize the delegates with lambda expressions.
                del = () => { j = 10; return j > input; };

                //del2 will be invoked after TestMethod goes out of scope.
                del2 = (x) => { return x == j; };

                //Demonstrate value of j：
                //The delegate has not been invoked yet.
                Console.WriteLine("j={0}", j);
                bool boolResult = del();

                Console.WriteLine("j={0},b={1}\n", j, boolResult);
            }
        }
        static void Main(string[] args)
        {
            int[] source = new[] { 3, 8, 4, 6, 1, 7, 9, 2, 4, 8 };

            foreach (int i in source.Where(x =>
             {
                 if (x <= 3)
                 {
                     return true;
                 }
                 else if (x >= 7)
                 {
                     return true;
                 }
                 return false;
             }))
                Console.WriteLine(i);
            

            Console.ReadLine();
        }

        static void LINQVariable()
        {
            Test test = new Test();
            test.TestMethod(5);

            //Prove that del2 still has a copy of local variable j from TestMethod.
            bool result = test.del2(10);
            Console.WriteLine(result);
        }
        static void LINQAVG()
        {
            int[] fibNum = { 1, 1, 2, 3, 5, 8, 13, 21, 34 };
            double avgValue = fibNum.Average();
            Console.WriteLine(avgValue);
        }

        static void LINQLambdaExpression()
        {
            Del myDel = y => y * y * y;
            int j = myDel(5);
            Console.WriteLine("The cube of {0} is {1}", 5, j);
            Console.ReadLine();
        }

        static void LinqEntity()
        {
            using (AdventureWorks2012Entities context = new AdventureWorks2012Entities())
            {
                //Get the list of department from database.
                var departList = from d in context.Departments select d;

                foreach (var de in departList)
                {
                    Console.WriteLine("Department Id={0},Department Name={1}\n", de.DepartmentID, de.Name);
                }

                ////Add new Department.
                //Department dept = new Department();
                //dept.Name = "Support2";
                //dept.GroupName = "IT2";
                //dept.ModifiedDate = DateTime.Now;
                //context.Departments.Add(dept);
                //context.SaveChanges();



                //Update existing Department.
                Department updateDept = context.Departments.FirstOrDefault(x => x.Name == "SupportTeam2");

                context.Departments.Remove(updateDept);
                context.SaveChanges();

                Console.WriteLine("Department Name=Support is inserted in Database");
                var latestDeptList = from d in context.Departments select d;
                foreach (var d in latestDeptList)
                {
                    Console.WriteLine(d.Name);
                }
            }
        }
    }

   
}

