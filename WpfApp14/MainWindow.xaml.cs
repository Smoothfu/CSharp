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
using System.Threading;
using System.IO;
using System.Reflection;
using System.Drawing;

namespace WpfApp14
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

            //Start a new "task" to process the files.
            Task.Factory.StartNew(() =>
            {
                ProcessFiles();
            });           
        }

        private void ProcessFiles()
        {
            //Load up all *.jpg files,and make a new folder for the modified data.
            string[] allFiles = Directory.GetFiles(@"C:\Users\Fred\Pictures", "*.jpg", SearchOption.AllDirectories);

            string newDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+@"\ModifiedFile";
            Directory.CreateDirectory(newDir);

            //Process the image data in a parallel manner!
            Parallel.ForEach(allFiles, currentFile =>
            {
                string fileName = System.IO.Path.GetFileName(currentFile);

                using (Bitmap bp = new Bitmap(currentFile))
                {
                    bp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bp.Save(System.IO.Path.Combine(newDir, fileName));

                    //Print out the ID of the thread processing the current image.
                    this.Dispatcher.Invoke(()=>
                    {
                        this.tbx.Text += string.Format("Processing {0} on thread {1}\n", fileName, Thread.CurrentThread.ManagedThreadId)+Environment.NewLine;
                    }); 
                }
            });
            ////Process the image data in a blocking manner.
            //foreach(string currentFile in allFiles)
            //{
            //    string fileName = System.IO.Path.GetFileName(currentFile);

            //    using (Bitmap bp = new Bitmap(currentFile))
            //    {
            //        bp.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //        bp.Save(System.IO.Path.Combine(newDir, fileName));

            //        //Print out the ID of the thread processing the current image.
            //        this.tbx.Text = string.Format("Processing {0} on thread {1}\n", fileName, Thread.CurrentThread.ManagedThreadId);
            //    }
            //}            
        }
    }
}
