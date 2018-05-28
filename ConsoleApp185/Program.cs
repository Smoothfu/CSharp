using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp185
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.AppSettings["connString"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            
            if(conn.State==ConnectionState.Open)
            {
                string selectSQL = "select * from AdventureWorks2014.sales.vStoreWithContacts;select * from AdventureWorks2014.Production.ProductCostHistory;select * from AdventureWorks2014.Sales.vStoreWithDemographics";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectSQL, conn);
                DataSet ds = new DataSet("SqlDataAdapterDataSet");
                sqlDataAdapter.Fill(ds);

                for(int i=0;i<ds.Tables.Count;i++)
                {                   
                    if(ds.Tables[i].Rows.Count>0)
                    {
                        Console.WriteLine("\n\nThis is the table{0}\n\n", i + 1);
                        for(int c=0;c<ds.Tables[i].Columns.Count;c++)
                        {
                            string columnName = ds.Tables[i].Columns[c].ColumnName;
                            Console.Write(string.Format("{0,-20}", columnName));
                        }
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        for (int j=0;j<ds.Tables[i].Rows.Count;j++)
                        {
                            for(int k=0;k<ds.Tables[i].Columns.Count;k++)
                            {
                                Console.Write(string.Format("{0,-20}", ds.Tables[i].Rows[j][k].ToString()));
                            }
                            Console.WriteLine();
                        }

                        Console.WriteLine("\n\n\n\n\n");
                    }
                }
            }

            conn.Close();
            Console.ReadLine();
        }
    }
}
