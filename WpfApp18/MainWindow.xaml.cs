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
using System.IO;
using System.Drawing;
using System.Threading;

namespace WpfApp18
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

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            ProcessFiles();
        }

        private void ProcessFiles()
        {
            //Load up all *.jpg files,and make a new folder for the modified data.
            string[] allFiles = Directory.GetFiles(@"C:\Users\Fred\Pictures","*.jpg",SearchOption.AllDirectories);
            string newDir = @"C:\ModifiedPictures";
            Directory.CreateDirectory(newDir);

            ////Process the image data in a blocking manner.
            //foreach(string cf in allFiles)
            //{
            //    string fileName = Path.GetFileName(cf);
            //    using (Bitmap bm = new Bitmap(cf))
            //    {
            //        bm.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //        bm.Save(Path.Combine(newDir, fileName));

            //        //Print out the ID of the thread processing teh current image.
            //        tb.Text += string.Format("Processing {0} on thread {1}\n", fileName, Thread.CurrentThread.ManagedThreadId);
            //    }
            //}

            //Process the image data in a parallel manner.
            Parallel.ForEach(allFiles, x =>
             {
                 string fileName = Path.GetFileName(x);
                 using (Bitmap bm = new Bitmap(x))
                 {
                     bm.RotateFlip(RotateFlipType.Rotate180FlipNone);
                     bm.Save(Path.Combine(newDir, fileName));                    
                 }
                 Dispatcher.BeginInvoke( new Action(() =>
                 {
                     tb.Text += string.Format("Processing {0} on thread {1}\n", fileName, Thread.CurrentThread.ManagedThreadId);
                 }));
             });

            string str = tb.Text;
            System.Diagnostics.Debug.WriteLine(str);
        }
    }
}
