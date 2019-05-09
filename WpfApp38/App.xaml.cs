﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApp38
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Window win = new Window();
            win.Title = "This is generated in App()";
            win.BorderBrush = new SolidColorBrush(Colors.Red);
            win.Background=new SolidColorBrush(Colors.Red);

            win.Show();
        }       
    }
}
