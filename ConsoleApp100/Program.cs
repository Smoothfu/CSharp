using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp100
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = " ";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            if(conn.State==ConnectionState.Open)
            {
                Console.WriteLine("Connect the database successfully.\n");
            }
            string sql = "select CustomerID,NameStyle,Title,FirstName,MiddleName,LastName,Suffix," +
                "CompanyName,SalesPerson,EmailAddress,phone,PasswordHash,PasswordSalt,rowguid,ModifiedDate from saleslt.customer";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                Console.WriteLine("CustomerID:{0},NameStyle:{1},Title:{2},FirstName:{3},MiddleName:{4},LastName:{5}," +
                    "Suffix:{6},CompanyName:{7},SalesPerson:{8},EmailAddress:{9},phone:{10},PasswordHash:{11}," +
                    "PasswordSalt:{12},rowguid:{13},ModifiedDate:{14}", ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString(),
                    ds.Tables[0].Rows[i][3].ToString(), ds.Tables[0].Rows[i][4].ToString(), ds.Tables[0].Rows[i][5].ToString(), ds.Tables[0].Rows[i][6].ToString(),
                    ds.Tables[0].Rows[i][7].ToString(), ds.Tables[0].Rows[i][8].ToString(), ds.Tables[0].Rows[i][9].ToString(), ds.Tables[0].Rows[i][10].ToString(),
                    ds.Tables[0].Rows[i][11].ToString(), ds.Tables[0].Rows[i][12].ToString(), ds.Tables[0].Rows[i][13].ToString(), ds.Tables[0].Rows[i][14].ToString());                 
            }
            Console.WriteLine(conn.State);
            Console.ReadLine();
        }
    }
}
