using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string AddMethod(int x, int y)
        {
            return string.Format("{0}+{1}={2}\n", x, y, x + y);
        }

        public List<Inventory> GetAllInventory()
        {
            List<Inventory> inventoryList = new List<Inventory>();
            //string connectionString = ConfigurationManager.AppSettings["connString"].ToString();
            //string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            string connectionString = @"Server=FRED\SQLEXPRESS;Database=AutoLot;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            if(conn.State==System.Data.ConnectionState.Open)
            {
                string selectSQL = "select * from inventory";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectSQL, conn);
                DataSet ds = new DataSet("Retrieving data from db");

                sqlDataAdapter.Fill(ds);

                if (ds.Tables[0].Rows.Count>0)
                {
                    for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        inventoryList.Add(new Inventory()
                        {
                            CarID = (int)ds.Tables[0].Rows[i][0],
                            Make=(string)ds.Tables[0].Rows[i][1],
                            Color=(string)ds.Tables[0].Rows[i][2],
                            PetName=(string)ds.Tables[0].Rows[i][3]
                        });
                    }
                }
            }
            return inventoryList;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }

    public class Inventory
    {
        public int CarID { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
        public string PetName { get; set; }

        public override string ToString()
        {
            return string.Format("CarID:{0},Make:{1},Color:{2},PetName:{3}\n", CarID, Make, Color, PetName);
        }
    }
}
