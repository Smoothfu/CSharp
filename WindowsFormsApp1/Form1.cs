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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        InventoryDALDC _dal = null;
        public Form1()
        {
            InitializeComponent();

            string conStr = @"Data Source=FRED\SQLEXPRESS;Initial Catalog=AutoLot; Integrated Security=SSPI;Pooling=False";

            //Creat our data access object.
            _dal = new InventoryDALDC(conStr);

            //Fill up your grid.
            dataGridView1.DataSource = _dal.GetAllInventory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Get modified data from the grid.
            DataTable changedDT = (DataTable)dataGridView1.DataSource;

            try
            {
                //Commit our changes.
                _dal.UpdateInventory(changedDT);
                dataGridView1.DataSource = _dal.GetAllInventory();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
