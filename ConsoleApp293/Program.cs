﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp293
{
    class Program
    {
        static void Main(string[] args)
        {
            Plant[] plants = new Plant[]
            {
                new CarnivorousPlant{Name="Venus Fly Trap",TrapType="Snap Trap"},
                new CarnivorousPlant{Name="Pitcher Plant",TrapType="Pitfall Trap"},
                new CarnivorousPlant{Name="Sundew",TrapType="Flypaper Trap"},
                new CarnivorousPlant{Name="Waterwheel",TrapType="Snap Trap"}
            };

            var query = from CarnivorousPlant cPlant in plants
                        where cPlant.TrapType == "Snap Trap"
                        select cPlant;

            foreach(var e in query)
            {
                Console.WriteLine("Name={0},Trap Type={1}\n", e.Name, e.TrapType);
            }

            Console.ReadLine();
        }


        static void LINQIGroup()
        {
            List<int> numbers = new List<int> { 35, 44, 200, 84, 3987, 4, 199, 329, 446, 208 };

            IEnumerable<IGrouping<int, int>> query = from n in numbers
                                                     group n by n % 2;
            foreach (var q in query)
            {
                Console.WriteLine(q.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");
                foreach (int i in q)
                {
                    Console.WriteLine(i);
                }

            }
        }
        static void LinqOrderbyOrderbyDescending()
        {
            int[] num = { -20, 12, 6, 10, 0, -3, 1 };

            //create a query that obtain the values in sorted order
            var posNums = from n in num
                          orderby n
                          select n;
            Console.WriteLine("Values in ascending order:\n");

            //Execute the query and diplay the results
            foreach (int i in posNums)
            {
                Console.Write(i + "\t");
            }


            var posNumsDesc = from n in num
                              orderby n descending
                              select n;
            Console.WriteLine("\nValues in descending order:\n");
            //Execute the query and display the results.
            foreach (int i in posNumsDesc)
            {
                Console.WriteLine(i);
            }
        }
        static void LINQFrompInPhrasesfromwinpSplitselectw()
        {
            List<string> phrases = new List<string>() { "an apple a day", "the quick brown fox" };

            var query = from p in phrases
                        from w in p.Split(' ')
                        select w;

            foreach (var q in query)
            {
                Console.WriteLine(q);
            }

        }
        static void LINQSubstring()
        {
            List<string> words = new List<string>() { "an", "apple", "a", "day" };
            var query = from q in words select q.Substring(0, 1);

            Parallel.ForEach(query, x =>
            {
                Console.WriteLine(x);
            });
        }
        static void ADONETSample()
        {
            string conString = ConfigurationManager.AppSettings["conString"].ToString();

            using (SqlConnection conn = new SqlConnection(conString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string selectSQL = "select ProductID,Name,ProductNumber," +
                    "MakeFlag,FinishedGoodsFlag,SafetyStockLevel,ReorderPoint " +
                    "from Production.Product where SafetyStockLevel is not null";
                using (SqlCommand cmd = new SqlCommand(selectSQL, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        string productIdCN = reader.GetName(0);
                        string nameCN = reader.GetName(1);
                        string productNumberCN = reader.GetName(2);
                        string makeFlagCN = reader.GetName(3);
                        string finishedGoodsFlagCN = reader.GetName(4);
                        string safetyStockLevelCN = reader.GetName(5);
                        string reorderPointCN = reader.GetName(6);

                        string formatHeaderName = string.Format("{0,-10}  {1,-20}  {2,20}  {3,0}  {4,20}  {5,20}  {6,20}\n\n",
                            productIdCN, nameCN, productNumberCN, makeFlagCN, finishedGoodsFlagCN, safetyStockLevelCN, reorderPointCN);
                        Console.WriteLine(formatHeaderName);
                        int rowCount = 0;
                        while (reader.Read())
                        {
                            int productId = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string productNumber = reader.GetString(2);
                            bool makeFlag = reader.GetBoolean(3);
                            bool finishedGoodsFlag = reader.GetBoolean(4);
                            Int16 safetyStockLevel = reader.GetInt16(5);
                            Int16 reorderPoint = reader.GetInt16(6);

                            string msg = string.Format("{0,-10} {1,-30} {2,-15} {3,-20} {4,-20} {5,-20} {6,-20}",
                                productId, name, productNumber, makeFlag, finishedGoodsFlag, safetyStockLevel, reorderPoint);
                            Console.WriteLine(msg + "\n");
                            ++rowCount;
                            Console.WriteLine();
                        }

                        reader.NextResult();

                        Console.WriteLine("There are totally {0} rows data!\n", rowCount);
                    }

                }
            }
        }
        static void LINQWords()
        {
            string[] words = { "humpty", "dumpty", "set", "on", "a", "wall" };
            IEnumerable<string> query = from word in words where word.Length == 2 select word;
            foreach (string q in query)
            {
                Console.WriteLine(q);
            }

            string[] words2 = { "hello", "wonderful", "LINQ", "beautifulgril", "World" };

            ////get only short words
            //var shortWords = from word in words
            //                 where word.Length <= 5
            //                 select word;
            var shortWords = words.Where(x => x.Length <= 5);

            //print each word out.
            foreach (var word in shortWords)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("The following are longer words:\n");
            var longWords = from w in words where w.Length >= 10 select w;
            foreach (var word in longWords)
            {
                Console.WriteLine(word);
            }


            //Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };


            //Define the query expression.
            IEnumerable<int> scoreQuery = from s in scores where s > 80 select s;

            //Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.WriteLine(i);
            }
        }
        static void LINQJoinInOn()
        {
            List<DepartmentClass> departments = new List<DepartmentClass>();
            departments.Add(new DepartmentClass { DepartmentId = 1, Name = "Account" });
            departments.Add(new DepartmentClass { DepartmentId = 2, Name = "Sales" });
            departments.Add(new DepartmentClass { DepartmentId = 3, Name = "Marketing" });
            List<EmployeeClass> employeesList = new List<EmployeeClass>();
            employeesList.Add(new EmployeeClass { DepartmentId = 1, EmployeeId = 1, EmployeeName = "Fred1" });
            employeesList.Add(new EmployeeClass { DepartmentId = 2, EmployeeId = 2, EmployeeName = "Fred2" });
            employeesList.Add(new EmployeeClass { DepartmentId = 1, EmployeeId = 3, EmployeeName = "Fred3" });

            var list = (from e in employeesList
                        join d in departments on e.DepartmentId equals d.DepartmentId
                        select new
                        {
                            EmployeeName = e.EmployeeName,
                            DepartmentName = d.Name
                        });

            Parallel.ForEach(list, x =>
            {
                Console.WriteLine("Employee Name={0},Department Name={1}\n", x.EmployeeName, x.DepartmentName);
            });
        }
    }

    class DepartmentClass
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }

    class EmployeeClass
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
    }

    class Plant
    {
        public string Name { get; set; }
    }

    class CarnivorousPlant:Plant
    {
        public string TrapType { get; set; }
    }
}
