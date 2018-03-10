﻿using System;
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
using System.Threading;
using System.IO;
using System.Drawing;

namespace WpfApp9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadImg_Click(object sender, RoutedEventArgs e)
        {
            //Start a new "task" to process the files.
            Task.Factory.StartNew(() =>
            {
                ProcessFiles();
            });
        }

        private void ProcessFiles()
        {
            StringBuilder sb = new StringBuilder();
            //Load up all *.jpg files,and make a new folder for the modified data.
            string[] files = Directory.GetFiles(@"C:\Users\Fred\Pictures", "*.jpg",SearchOption.AllDirectories);
            string newDir = @"C:\ModifiedImages";
            Directory.CreateDirectory(newDir);


            ////Process the image data in a bloacking manner.
            //foreach(string currentFile in files)
            //{
            //    string fileName = System.IO.Path.GetFileName(currentFile);

            //    using (Bitmap bitmap = new Bitmap(currentFile))
            //    {
            //        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //        bitmap.Save(System.IO.Path.Combine(newDir, fileName));

            //        //Print out the ID of the thread processing the current image.

            //        sb.Append(string.Format("Processing {0} on thread {1}\n.", fileName, Thread.CurrentThread.ManagedThreadId));
            //      }

            //    txt.Text = sb.ToString();
            //}


            //Process the image data in a parallel manner!
            Parallel.ForEach(files, x =>
            {
                string fileName = System.IO.Path.GetFileName(x);
                using (Bitmap bp = new Bitmap(x))
                {
                    bp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bp.Save(System.IO.Path.Combine(newDir, fileName));
                }

                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
                {
                    sb.Append(string.Format("Processing {0} on thread {1}\n", fileName, Thread.CurrentThread.ManagedThreadId));
                    this.txt.Text = sb.ToString();
                })); 
            });         

        }
    }
}
