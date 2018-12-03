using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;

namespace ConsoleApp296
{
    class Program
    {
        static void Main(string[] args)
        {
            string myXML = @"<Departments>
                        <Department>Sales</Department>
                        <Department>IT</Department>
                        <Department>Finance</Department>
                        </Departments>";

            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(myXML);

            //Add new Element
            xdoc.Element("Departments").Add(new XElement("Department", "RD"));
            xdoc.Element("Departments").AddFirst(new XElement("Department", "PreSales"));

            

            var result = xdoc.Element("Departments").Descendants();

            foreach(XElement item in result)
            {
                Console.WriteLine("Department Name:- " + item.Value);
            }

            Console.ReadLine();
        }

        static void LINQDATASET()
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2012Entities"].ToString();
            string selectSQL = "select * from HumanResources.Department;" + "select* from HumanResources.Employee;" +
                " select * from HumanResources.EmployeeDepartmentHistory";

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

            foreach (var q in query)
            {
                Console.WriteLine("BusinessEntityID={0},Name={1},DepartmentId={2},DepartmentName={3}", q.BusinessEntityID, q.Name, q.DepartmentId, q.DepartmentName);
            }
        }
    }
}
