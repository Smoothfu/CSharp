using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp297
{
    class Program
    {
        delegate int Del(int i);
        static void Main(string[] args)
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

