using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp16
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //A collection of Car objects.
        static List<Car> listCars = null;

        //Invetory information.
        static DataTable inventoryTable = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
            InitData();
            dg.ItemsSource = listCars;
        }

        static void InitData()
        {
            //Fill the list with some cars.
            listCars = new List<Car>
            {
                new Car { Id = 11, PetName = "Chucky", Make = "BMW", Color = "Green" },
                new Car { Id = 12, PetName = "Tiny", Make = "Yugo", Color = "White" },
                new Car { Id = 13, PetName = "Ami", Make = "Jeep", Color = "Tan" },
                new Car { Id = 14, PetName = "Pain Inducer", Make = "Caravan", Color = "Pink" },
                new Car { Id = 15, PetName = "Fred", Make = "BMW", Color = "Green" },
                new Car { Id = 16, PetName = "Sidd", Make = "BMW", Color = "Black" },
                new Car { Id = 17, PetName = "Mel", Make = "Firebird", Color = "Red" },
                new Car { Id = 18, PetName = "Sarah", Make = "Colt", Color = "Black" }
            };
        }

        static void CreateDataTable()
        {
            //Create table schema.
            var carIDColumn = new DataColumn("Id", typeof(int));
            var carMakeColumn = new DataColumn("Make", typeof(string));
            var carColorColumn = new DataColumn("Color", typeof(string));
            var carPetNameColumn = new DataColumn("PetName", typeof(string));
            inventoryTable.Columns.AddRange(new[]
            {
                carIDColumn,carMakeColumn,carColorColumn,carPetNameColumn
            });

            //Iterate over the array list to make rows.
            foreach(var c in listCars)
            {
                var newRow = inventoryTable.NewRow();
                newRow["Id"] = c.Id;
                newRow["Make"] = c.Make;
                newRow["Color"] = c.Color;
                newRow["PetName"] = c.PetName;
                inventoryTable.Rows.Add(newRow);
            }

            //Bind the DataTable to the carInventoryGridView
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Find the correct row to delete.
                var  deleteCar =
                    from car in listCars
                    where car.Id == int.Parse(tbID.Text)
                    select car;


                //int indexDelete = listCars.IndexOf(deleteCar.FirstOrDefault());
                ////Delete it!
                //listCars.RemoveAt(indexDelete);
                listCars.Remove(deleteCar.FirstOrDefault());
                dg.ItemsSource = null;
                dg.ItemsSource = listCars;                 
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            //Build a filter based on user input
            string specifiedMake = tbMake.Text;

            //Find all rows matching the filter.
            var matchedCars = from car
                              in listCars
                              where car.Make == specifiedMake
                              select car;

           if(!matchedCars.Any())
            {
                MessageBox.Show("Sorry,no cars...", "Selection error!");                 
            }
           else
            {
                string strMake = null;

                matchedCars.ToList().ForEach(x =>
                {
                    strMake += x.PetName + "\n";
                });

                MessageBox.Show(strMake);
            }

        }
    }

    public class Car
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
    }
}
