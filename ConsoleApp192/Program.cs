using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp192
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = @"Server=FRED\SQLEXPRESS;Database=AdventureWorks2014;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            if(conn.State==ConnectionState.Open)
            {
                Console.WriteLine(conn.State.ToString());
                Console.WriteLine();
                string selectSQL = "select BusinessEntityID,PersonType,NameStyle,Title,FirstName,MiddleName,LastName,Suffix,EmailPromotion,rowguid,ModifiedDate from AdventureWorks2014.Person.Person where AdditionalContactInfo is not null";

                SqlCommand cmd = new SqlCommand(selectSQL, conn);
                SqlDataReader sda = cmd.ExecuteReader();
                while(sda.Read())
                {
                    for(int i=0;i<sda.FieldCount;i++)
                    {
                        Console.Write("{0,-30}",sda.GetValue(i));
                    }
                    Console.WriteLine("\n\n\n\n\n");
                }
            }

            Console.ReadLine(); 
        }
    }
}
