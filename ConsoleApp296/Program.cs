using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace ConsoleApp296
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2012Entities"].ToString();
            string selectSQL = "select * from HumanResources.Department;" + "select* from HumanResources.Employee;";

            //Create the data adpater to retrieve data from the database.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSQL, connString);

            //Create table mappings.
            dataAdapter.TableMappings.Add("Table", "Department");
            dataAdapter.TableMappings.Add("Table1", "Employee");

            //Create and fill the dataset
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            
            DataTable department = ds.Tables["Department"];
            DataTable employee = ds.Tables["Employee"];

            var query = from d in department.AsEnumerable()
                        join e in employee.AsEnumerable()
                        on d.Field<Int16>("DepartmentId") equals
                        e.Field<int>("BusinessEntityID")
                        select new
                        {
                            BusinessEntityID = e.Field<int>("BusinessEntityID"),
                            Name = e.Field<string>("JobTitle"),
                            DepartmentId = d.Field<Int16>("DepartmentId"),
                            DepartmentName = d.Field<string>("Name")
                        };

            foreach(var q in query)
            {
                Console.WriteLine("BusinessEntityID={0},Name={1},DepartmentId={2},DepartmentName={3}", q.BusinessEntityID, q.Name, q.DepartmentId, q.DepartmentName);
            }

            Console.ReadLine();
        }
    }
}
