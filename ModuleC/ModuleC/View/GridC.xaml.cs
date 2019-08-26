using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

namespace ModuleC.View
{
    /// <summary>
    /// Interaction logic for GridC.xaml
    /// </summary>
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export]
    public partial class GridC : Grid
    {
        public GridC()
        {
            InitializeComponent();
        }
    }
}
