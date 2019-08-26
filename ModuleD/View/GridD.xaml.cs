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

namespace ModuleD.View
{
    /// <summary>
    /// Interaction logic for GridD.xaml
    /// </summary>
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export]
    public partial class GridD : Grid
    {
        public GridD()
        {
            InitializeComponent();
        }
    }
}
