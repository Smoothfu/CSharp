﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //Form wide DataSet.
        private DataSet _autoLotDs = new DataSet("AutoLot");

        //Make use of command builders to simplify data adapter configuration.
        private SqlCommandBuilder _sqlCbInventory;
        private SqlCommandBuilder _sqlCbCustomers;
        private SqlCommandBuilder _sqlCbOrders;

        //Our data adapters for each table.
        private SqlDataAdapter _invTableAdapter;
        private SqlDataAdapter _custTableAdapter;
        private SqlDataAdapter _ordersTableAdapter;

        //Form wide connection string.
        private String _connectionString;
        InventoryDALDC _dal = null;
        public Form1()
        {
            InitializeComponent();

            //Get connection string.
            _connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            //Create adapters.
            _invTableAdapter = new SqlDataAdapter("select * from inventory", _connectionString);
            _custTableAdapter = new SqlDataAdapter("select * from Customers", _connectionString);
            _ordersTableAdapter = new SqlDataAdapter("select * from orders", _connectionString);

            //Autogenerate commands/
            _sqlCbInventory = new SqlCommandBuilder(_invTableAdapter);
            _sqlCbOrders = new SqlCommandBuilder(_ordersTableAdapter);
            _sqlCbCustomers = new SqlCommandBuilder(_custTableAdapter);

            //Fill tables in DataSet.
            _invTableAdapter.Fill(_autoLotDs, "Inventory");
            _custTableAdapter.Fill(_autoLotDs, "Customers");
            _ordersTableAdapter.Fill(_autoLotDs, "Orders");

            //Build relations between tables.
            BuildTableRelationShip();

            //Bind to grids.
            dataGridView1.DataSource = _autoLotDs.Tables["Inventory"];
            dataGridView2.DataSource = _autoLotDs.Tables["Customers"];
            dataGridView3.DataSource = _autoLotDs.Tables["Orders"];
        }

        private void BuildTableRelationShip()
        {
            //Create CustomerOrder data relation object.
            DataRelation dr = new DataRelation("CustomerOrder", _autoLotDs.Tables["Customers"].Columns["CustID"],
                _autoLotDs.Tables["Orders"].Columns["CustId"]);
            _autoLotDs.Relations.Add(dr);

            //Create InventoryOrder data relation object.
            dr = new DataRelation("InventoryOrder",
                _autoLotDs.Tables["Inventory"].Columns["CarID"],
                _autoLotDs.Tables["Orders"].Columns["CarID"]);

            _autoLotDs.Relations.Add(dr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _invTableAdapter.Update(_autoLotDs, "Inventory");
                _custTableAdapter.Update(_autoLotDs, "Customers");
                _ordersTableAdapter.Update(_autoLotDs, "Orders");

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
