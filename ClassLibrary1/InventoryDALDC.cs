﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary1
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
            //Create the adapter and set up the SelectCommand/
            adapter = new SqlDataAdapter("select * from inventory", _connectionString);

            //Obtain the remaining command objects dynamically at runtime using the SqlCommandBuilder.
            var builder = new SqlCommandBuilder(adapter);
        }

        public DataTable GetAllInventory()
        {
            DataTable inv = new DataTable("Inventory");
            _adapter.Fill(inv);
            return inv;
        }

        public void UpdateInventory(DataTable modifiedTable)
        {
            _adapter.Update(modifiedTable);
        }
    }
}
