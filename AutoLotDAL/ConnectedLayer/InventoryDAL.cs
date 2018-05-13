using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AutoLotDAL.Models;

namespace AutoLotDAL.ConnectedLayer
{
    public class InventoryDAL
    {
        //This member will be used by all methods.
        private SqlConnection _sqlConnection = null;

       public void OpenConnection(string connectionString)
        {
            _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();
        }

        public void CloseConnection()
        {
            _sqlConnection.Close();
        }

        public void InsertAuto(int id,string color,string make,string petName)
        {
            //Format and execute SQL statement.
            string sql = $"Insert into inventory (Make,Color,PetName) values('{make}','{color}','{petName}')";

            //Execute using our connection.
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void InsertAuto(NewCar car)
        {
            //Format and execute SQL statement.
            string insertSQL = $"Insert into inventory (make,color,petname) values('{car.Make}','{car.Color}','{car.PetName}')";

            //Execute using our connection.
            using (SqlCommand cmd = new SqlCommand(insertSQL, _sqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int id)
        {
            //Delete the car with the specified CarId
            string deleteSQL = $"delete from inventory where CarId='{id}'";
            using (SqlCommand deleteCmd = new SqlCommand(deleteSQL, _sqlConnection))
            {
                try
                {
                    deleteCmd.ExecuteNonQuery();
                }
                catch(SqlException ex)
                {
                    Exception error = new Exception("Sorry! That car is on order!", ex);
                    throw error;
                }
            }
        }

        public void UpdateCarPetName(int id,string newPetName)
        {
            //Update the PetName of the car with the specified CarId.
            string updateSQL = $"update inventory set PetName='{newPetName}' where CarId= '{id}'";
            using (SqlCommand updateCmd = new SqlCommand(updateSQL, _sqlConnection))
            {
                updateCmd.ExecuteNonQuery();
            }
        }

        public List<NewCar> GetAllInventoryAsList()
        {
            //This will hold the records.
            List<NewCar> carList = new List<NewCar>();

            //Prep command object.
            string getAllSQL = "select * from inventory";
            using (SqlCommand getAllCmd = new SqlCommand(getAllSQL, _sqlConnection))
            {
                SqlDataReader dataReader = getAllCmd.ExecuteReader();
                while(dataReader.Read())
                {
                    carList.Add(new NewCar
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    });
                }
                dataReader.Close();
            }

            return carList;
        }

        public DataTable GetAllInventoryAsDataTable()
        {
            //This will hold the records.
            DataTable dt = new DataTable();

            //Prep command object.
            string dtSQL = "select * from inventory";
            using (SqlCommand dtCmd = new SqlCommand(dtSQL, _sqlConnection))
            {
                SqlDataReader dataReader = dtCmd.ExecuteReader();

                //Fill the DataTable with data from the reader and clean up.
                dt.Load(dataReader);
                dataReader.Close();
            }
            return dt;
        }
    }
}
