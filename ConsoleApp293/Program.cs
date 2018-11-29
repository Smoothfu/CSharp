using System;
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
            string[] words = { "humpty", "dumpty", "set", "on", "a", "wall" };
            IEnumerable<string> query = from word in words where word.Length == 2 select word;
            foreach(string q in query)
            {
                Console.WriteLine(q);
            }

            Console.ReadLine();
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
            string[] words = { "hello", "wonderful", "LINQ", "beautifulgril", "World" };

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
    }
}
