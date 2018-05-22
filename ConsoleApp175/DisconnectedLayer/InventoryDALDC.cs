using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace ConsoleApp175.DisconnectedLayer
{
    public class InventoryDALDC
    {
        //Field data.
        private string _connectionString;
        private SqlDataAdapter _adapter = null;

        public InventoryDALDC(string connectionString)
        {
            _connectionString = connectionString;

            //Configure the SqlDataAdapter.
            ConfigureAdapter(out _adapter);
        }

        private void ConfigureAdapter(out SqlDataAdapter adapter)
        {
            //Create the adapter and set up the SelectCommand.
            adapter = new SqlDataAdapter("Select * from inventory", _connectionString);


            //Obtain the remaining command objects dynamically at runtime.
            //using the SqlCommandBuilder.
            var builder = new SqlCommandBuilder(adapter);
        }

        public DataTable GetAllInventory()
        {
            DataTable dt = new DataTable("Inventory");
            _adapter.Fill(dt);
            return dt;
        }

        public void UpdateInventory(DataTable modifiedTable)
        {
            _adapter.Update(modifiedTable);
        }
    }
}
