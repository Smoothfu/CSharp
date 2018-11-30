using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ConsoleApp294
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConsoleApp294.Properties.Settings.AdventureWorks2012ConnectionString"].ToString();
            string selectSQL = "select  * from HumanResources.Department " + " select   * from HumanResources.Employee ";

            //Create the data adpater to retrieve data from the database
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSQL, conString);

            //Create table mappings.
            dataAdapter.TableMappings.Add("Table", "Department");
            dataAdapter.TableMappings.Add("Table1", "Employee");

            //Create and fill the DataSet
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            //DataRelation dr = ds.Relations.Add("FK_Employee_Department", ds.Tables["Department"].Columns["DepartmentID"], ds.Tables["Employee"].Columns["BusinessEntityID"]);
            DataTable department = ds.Tables["Department"];
            DataTable employee = ds.Tables["Employee"];

            var query = from d in department.AsEnumerable()
                        join e in employee.AsEnumerable()
                        on d.Field<Int16>("DepartmentID") equals
                        e.Field<int>("BusinessEntityID")
                        select new
                        {
                            EmployeeId = e.Field<string>("NationalIDNumber"),
                            Name = e.Field<string>("JobTitle"),
                            DepartmentId = d.Field<Int16>("DepartmentID"),
                            DepartmentName = d.Field<string>("Name")
                        };

            foreach(var q in query)
            {
                Console.WriteLine("Employee Id={0},Name={1},Department Name={2}", q.EmployeeId, q.Name, q.DepartmentName);
            }


            Console.ReadLine();
        }

        static void LINQToObject()
        {
            List<DepartM> departList = new List<DepartM>();
            departList.Add(new DepartM { DeptId = 1, DeptName = "IT" });
            departList.Add(new DepartM { DeptId = 2, DeptName = "RD" });
            departList.Add(new DepartM { DeptId = 3, DeptName = "Finance" });

            var departsList = from dept in departList
                              select dept;
            foreach (DepartM dept in departsList)
            {
                Console.WriteLine("Department Id={0},Department Name={1}", dept.DeptId, dept.DeptName);
            }
        }
        static void LINQToObjects()
        {
            string[] tools = { "Tablesaw", "Bandsaw", "Planer", "Jointer", "Drill", "Sander" };
            var list = from t in tools
                       select t;

            StringBuilder sb = new StringBuilder();
            foreach (string str in list)
            {
                sb.Append(str + Environment.NewLine);
            }
            Console.WriteLine(sb.ToString(), "a");
        }
        static void LINQToSQL()
        {
            string connString = ConfigurationManager.
               ConnectionStrings["ConsoleApp294.Properties.Settings.AdventureWorks2012ConnectionString"].
               ToString();
            LINQToSQLDataContext db = new LINQToSQLDataContext(connString);

            ////Create new department
            //Department department = new Department();
            ////department.DepartmentID = 17;            
            //department.Name = "Board Chairman2";
            //department.GroupName = "SmoothInfo Group2";
            //department.ModifiedDate = DateTime.Now;

            //////Add new department to database
            ////db.Departments.InsertOnSubmit(department);

            //////save changes to database
            ////db.SubmitChanges();

            ////get new inserted departement 

            //Department newDepart = db.Departments.FirstOrDefault(x => x.DepartmentID == 18);
            //Console.WriteLine("DepartmentId={0},Name={1},GroupName={2},ModifiedDate={3}\n", newDepart.DepartmentID,
            //    newDepart.Name, newDepart.GroupName, newDepart.ModifiedDate);
            //Department updateDepartment = db.Departments.FirstOrDefault(x => x.DepartmentID == 19);
            //updateDepartment.Name = "Great!";
            //updateDepartment.ModifiedDate = DateTime.Now;
            //db.SubmitChanges();

            Department deleteDepartment = db.Departments.FirstOrDefault(x => x.DepartmentID == 19);
            //Delete Employee
            if (deleteDepartment != null)
            {
                db.Departments.DeleteOnSubmit(deleteDepartment);
            }


            //Save changes to Database
            db.SubmitChanges();

            //Get all departments from database;
            var departmentList = db.Departments;

            foreach (Department dept in departmentList)
            {
                Console.WriteLine("DepartmentId:{0,-5} Name:{1,-30} GroupName:{2,-50} ModifiedDate:{3,-20},", dept.DepartmentID, dept.Name, dept.GroupName, dept.ModifiedDate);
            }

        }
        static void LINQLast()
        {
            int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54, 83, 23, 87, 435, 67, 12, 19 };
            int last = numbers.Last();
            Console.WriteLine(last);
        }
        static void LINQFirst()
        {
            int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54, 83, 23, 87, 435, 67, 12, 19 };
            int first = numbers.First();
            Console.WriteLine(first);
        }
        static void LINQElementAt()
        {
            string[] names = { "Hartono", "Tommy", "Adams", "Terry", "Andersen,Henriette Thaulow", "Hedlund,Magnus", "Tto,Shu" };
            Random rnd = new Random(DateTime.Now.Millisecond);
            string name = names.ElementAt(rnd.Next(0, names.Length));
            Console.WriteLine("The name chosen at random is '{0}'.", name);
        }
        static void LINQSequenceEqual()
        {
            Pet barley = new Pet { Name = "Barley", Age = 4 };
            Pet boots = new Pet() { Name = "Boots", Age = 1 };
            Pet whiskers = new Pet() { Name = "Whiskers", Age = 6 };

            List<Pet> pets1 = new List<Pet>() { barley, boots };
            List<Pet> pets2 = new List<Pet> { barley, boots };
            List<Pet> pets3 = new List<Pet> { barley, boots, whiskers };

            bool equal = pets1.SequenceEqual(pets2);
            bool equal2 = pets1.SequenceEqual(pets3);

            Console.WriteLine("The lists pets1 and pets2 {0} equal.", equal ? "are" : "are not");
            Console.WriteLine("The lists pets1 and pets3 {0} equal.", equal2 ? "are" : "are not");
        }
        static void LINQExcept()
        {
            double[] numbers1 = { 2.0, 2.1, 2.2, 2.3, 2.4, 2.5 };
            double[] numbers2 = { 2.2 };
            IEnumerable<double> onlyInFirstSet = numbers1.Except(numbers2);
            foreach (double number in onlyInFirstSet)
            {
                Console.WriteLine(number);
            }

        }
        static void LINQEnumerableRepeat()
        {
            IEnumerable<string> strings = Enumerable.Repeat("I like programming.", 30);

            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }
        }
        static void LINQEnumerangeRange()
        {
            //Generate a sequence of integers from 1 to 5
            //and select their squares.
            IEnumerable<int> cubes = Enumerable.Range(1, 50).Select(x => x * x * x);
            foreach (int i in cubes)
            {
                Console.WriteLine(i);
            }
        }
        static void  LINQDefaultIfEmpty()
        {

            Pet barley = new Pet() { Name = "Barley", Age = 4 };
            Pet boots = new Pet() { Name = "Boots", Age = 1 };
            Pet whiskers = new Pet() { Name = "Whiskers", Age = 6 };
            Pet bluemoon = new Pet() { Name = "Blue Moon", Age = 9 };
            Pet daisy = new Pet() { Name = "Daisy", Age = 3 };

            List<Pet> pets = new List<Pet>() { barley, boots, whiskers, bluemoon, daisy };

            foreach (var pet in pets.DefaultIfEmpty())
            {
                Console.WriteLine("Name={0}\n", pet.Name);
            }
        }
        static void PartitionOperators()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<int> lessThan5 = arr.OrderByDescending(x=>x).TakeWhile(x => x >= 5);
            foreach(int i in lessThan5)
            {
                Console.WriteLine(i);
            }

        }
        static void LINQQuantifierOperator()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bool AllBiggerThan5 = arr.All(x => x > 5);
            Console.WriteLine("AllBiggerthan5={0}\n", AllBiggerThan5);
            bool AnyBiggerThan5 = arr.Any(x => x > 5);
            Console.WriteLine("AnyBiggerThan5={0}\n", AnyBiggerThan5);
            bool Contain10 = arr.Contains(10);
            Console.WriteLine("Contain10={0}\n", Contain10);
        }
        static void LINQSum()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int sum = arr.Sum(x => x);
            Console.WriteLine("Sum={0}\n", sum);
            int max = arr.Max();
            Console.WriteLine("Max={0}\n", max);
            int min = arr.Min();
            Console.WriteLine("Min={0}\n",min);
            double avg = arr.Average();
            Console.WriteLine("Avg={0}\n",avg);
        }
    }

    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class DepartM
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
