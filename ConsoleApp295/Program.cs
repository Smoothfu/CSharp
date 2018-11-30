using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ConsoleApp295
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AdventureWorks2012Entities context = new AdventureWorks2012Entities())
            {
                //get the list of departments from database
                var departmentList = from d in context.Departments
                                     select d;

                foreach(var d  in departmentList)
                {
                    Console.WriteLine("DepartmentId:{0,-3} DepartName:{1,-30}\n", d.DepartmentID, d.Name);
                }

                ////Add new Department
                //Department dept = new Department();
                //dept.Name = "Support";
                //context.Departments.Add(dept);
                //context.SaveChanges();
                //Console.WriteLine("Department name=Support is inserted in Database!");

                ////update existing department.
                //Department updateDept = context.Departments.FirstOrDefault(x => x.DepartmentID == 1);
                //updateDept.Name = "Sales First";
                //context.SaveChanges();

                Console.WriteLine("Department name=Account is updated in Database");
                Console.ReadLine();
                
            }
        }
    }
}
