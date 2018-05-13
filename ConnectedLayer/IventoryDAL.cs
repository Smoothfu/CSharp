using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ConnectedLayer.Models;
using static System.Console;


namespace ConnectedLayer
{
    public class IventoryDAL
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

        public void InsertAuto(int id,string color,string make,string petName,string founder)
        {
            //Format and execute SQL statement.
            string sql="Insert into iventory "+$"(Make,Color,PetName,Founder) values('{make}','{color}','{petName}','{founder}')";

            //Execute using our connection.
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void InsertAuto(NewCar car)
        {
            //Format and execute SQL statement.
            string sql = "Insert into iventory " + "(Make,Color,PetName,Founder) Values" + $"('{car.Make}','{car.Color}','{car.PetName}','{car.Founder}')";

            //Execute using our connection.
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }               
        }

        public void DeleteCar(int carId)
        {
            //Delete the car with the specified CarId
            string sql = $"Delete from iventory where CarId={carId}";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    command.ExecuteNonQuery();
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
            string sql = $"Update iventory set petName= '{newPetName}' where CarId= '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<NewCar> GetAllIventoryAsList()
        {
            //This will hold the records.
            List<NewCar> inv = new List<NewCar>();

            //Prep command object.
            string sql = "select * from iventory";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    inv.Add(new NewCar
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"],
                        Founder = (string)dataReader["Founder"]
                    });
                }
                dataReader.Close();
            }
            return inv;
        }

        public DataTable GetAllIventoryAsDataTable()
        {
            //This will hold the records.
            DataTable dataTable = new DataTable();

            //Prep command object.
            string sql = "select * from iventory";
            using (SqlCommand cmd = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader dataReader = cmd.ExecuteReader();

                //Fill the DataTable with data from the reader and clean up.
                dataTable.Load(dataReader);
                dataReader.Close();
            }
            return dataTable;
        }        

        public void InsertAutoTable(int id,string color,string make,string petName,string founder)
        {
            //Note the "placeholder" in the SQL query.

            string sql = "Insert into iventory (make,color,petName) values (@Make,@Color,@PetName)";

            //This command will have internal parameters.
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {

                //Fill params collection.
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Make",
                    Value = make,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };

                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Color",
                    Value = color,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };

                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@PetName",
                    Value = petName,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Founder",
                    Value = founder,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }

        }

        public string LookUpPetName(int carID)
        {
            string carPetName;

            //Establish name of stored proc.
            using (SqlCommand command = new SqlCommand("GetPetName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                //Input param.
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@carID",
                    SqlDbType = SqlDbType.Int,
                    Value = carID,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(param);

                //Output param.
                param = new SqlParameter
                {
                    ParameterName = "@petName",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(param);

                //Execute the stored proc.
                command.ExecuteNonQuery();

                //Return output param.
                carPetName = (string)command.Parameters["@petName"].Value;
            }
            return carPetName;
        }
        
        //A new member of the IventoryDAL class.
        public void ProcessCreditRisk(bool throwEx,int custId)
        {
            //First,look up current name based on customer ID.
            string fName = string.Empty, lName=string.Empty;
            string sql = $"select * from Customers where CustId={custId}";
            SqlCommand sqlCmd = new SqlCommand(sql, _sqlConnection);
            using (var dataReader = sqlCmd.ExecuteReader())
            {
                if(dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        fName = dataReader.GetString(1);
                        lName = dataReader.GetString(2);
                    }                          
                }
                else
                {
                    return;
                }
            }

            //Create command objects that represent each step of the operation.
            string removeSql = $"delete from Customers where CustID={custId}";
            SqlCommand removeCmd = new SqlCommand(removeSql, _sqlConnection);

            string insertSql = $"Insert into creditrisks (firstName,lastname) values ('{fName}','{lName}')";
            SqlCommand insertCmd = new SqlCommand(insertSql, _sqlConnection);

            //We will get this from the connection object.
            SqlTransaction tx = null;
            try
            {
                tx = _sqlConnection.BeginTransaction();

                //Enlist the commands into this transaction.
                insertCmd.Transaction = tx;
                removeCmd.Transaction = tx;

                //Execute the commands.
                insertCmd.ExecuteNonQuery();
                removeCmd.ExecuteNonQuery();

                //Simulate error.
                if(throwEx)
                {
                    throw new Exception("Sorry! Database error! Tx failed...");
                }

                //Commit it!
                tx.Commit();
            }

            catch(Exception ex)
            {
                WriteLine(ex.Message);

                //Any error will roll back transaction.
                //Using the new conditional access operator to check for null.
                tx?.Rollback();
            }
        }
    }
}
