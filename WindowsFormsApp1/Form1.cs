using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp175.DisconnectedLayer;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        InventoryDALDC _dal = null;

        //Form wide DataSet.
        private DataSet _autoLotDs = new DataSet("AutoLot");

        //Make use of command builders to simplify data adapter configuration.
        private SqlCommandBuilder _sqlCbInventory;
        private SqlCommandBuilder _sqlCbCustomers;
        private SqlCommandBuilder _SqlCbOrders;

        //Our data adapters(for each table).
        private SqlDataAdapter _invTableAdapter;
        private SqlDataAdapter _cusTableAdapter;
        private SqlDataAdapter _ordersTableAdapter;

        //Form wide connection string.
        private string _connectionString;
        public Form1()
        {
            InitializeComponent();

            //Get connection string.
            _connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            //Create adapters
            _invTableAdapter = new SqlDataAdapter("select * from Inventory", _connectionString);
            _cusTableAdapter = new SqlDataAdapter("select * from customers", _connectionString);
            _ordersTableAdapter = new SqlDataAdapter("select * from Orders", _connectionString);


            //Autogenerate commands.
            _sqlCbInventory = new SqlCommandBuilder(_invTableAdapter);
            _SqlCbOrders = new SqlCommandBuilder(_ordersTableAdapter);
            _sqlCbCustomers = new SqlCommandBuilder(_cusTableAdapter);

            //Fill tables in DataSet.
            _invTableAdapter.Fill(_autoLotDs, "Inventory");
            _cusTableAdapter.Fill(_autoLotDs, "Customers");
            _ordersTableAdapter.Fill(_autoLotDs, "Orders");

            //Build relations betweeb tables.
            BuildTableRelationShip();

            //Bind to grid.
            dgv1.DataSource = _autoLotDs.Tables["Inventory"];
            dataGridView2.DataSource = _autoLotDs.Tables["Customers"];
            dataGridView3.DataSource = _autoLotDs.Tables["Orders"];

        }

        private void BuildTableRelationShip()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Get modified data from the grid.
            DataTable changedDT = (DataTable)dgv1.DataSource;

            try
            {
                //Commit our changes.
                _dal.UpdateInventory(changedDT);
                dgv1.DataSource = _dal.GetAllInventory();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
