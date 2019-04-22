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
using System.Windows.Shapes;
using WpfApp32.Models;

namespace WpfApp32.Controls
{
    /// <summary>
    /// Interaction logic for TreeViewControl.xaml
    /// </summary>
    public partial class TreeViewControl : Window
    {
        public TreeViewControl()
        {
            InitializeComponent();
            InitMenuItems();
        }

        private void InitMenuItems()
        {
            WpfApp32.Models.MenuItem root = new WpfApp32.Models.MenuItem()
            {
                Title = "Menu"
            };
            WpfApp32.Models.MenuItem childItem1 = new Models.MenuItem()
            {
                Title = "Child item #1"
            };
            childItem1.Items.Add(new Models.MenuItem()
            {
                Title = "Child item #1.1"
            });
            childItem1.Items.Add(new Models.MenuItem()
            {
                Title="Child item #1.2"
            });

            root.Items.Add(childItem1);
            root.Items.Add(new Models.MenuItem()
            {
                Title = "Child item #2"
            });
            trvMenu.Items.Add(root);
        }
    }
}
