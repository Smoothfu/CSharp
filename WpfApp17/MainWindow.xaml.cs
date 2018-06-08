using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;


namespace WpfApp17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event EventHandler myEvent;
        public MainWindow()
        {
            InitializeComponent();
            btn.Content = "This button";
            this.DataContext = this;
            dg.ItemsSource = InitDataGrid();
            InitDataGrid();
            myEvent += MainWindow_myEvent;
        }


        static List<ProdInv> InitDataGrid()
        {
            string connSource = @"Server=FRED\SQLEXPRESS;Database=AdventureWorks2014;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connSource);
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetProductInventory";
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sda.SelectCommand = cmd;
                sda.Fill(ds);

                if(ds.Tables[0].Rows.Count>0)
                {
                    for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        prodList.Add(new ProdInv()
                        {
                            PId = (int)ds.Tables[0].Rows[i][0],
                            LId = (short)ds.Tables[0].Rows[i][1],
                            Shelf = (string)ds.Tables[0].Rows[i][2],
                            Bin = (byte)ds.Tables[0].Rows[i][3],
                            Quantity = (short)ds.Tables[0].Rows[i][4],
                            RowGuid=(Guid)ds.Tables[0].Rows[i][5],
                            MD=(DateTime)ds.Tables[0].Rows[i][6]
                        });
                    }
                }

                return prodList;    
            }
            return null;

        }
        private void MainWindow_myEvent(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(e.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(e.Source.ToString());
        }

        private void dg_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            MessageBox.Show(e.Row.Item.ToString());
        }

        public  static List<ProdInv> prodList = new List<ProdInv>();
    }
}
