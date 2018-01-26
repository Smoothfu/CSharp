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
using System.Drawing;

namespace WpfApp5
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProcessImages();
        }

        private void ProcessImages()
        {
            //Load up all *.jpg files,and make a few folder for the modified data.
            string path = @"C:\Users\Default\Pictures";
            string[] allFiles = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
            string newDir = @"C:\Users\Default\Pictures\NewImages";
            Directory.CreateDirectory(newDir);

            string fullName = "";
            string threadMsg = "";
            //Process the image data in a parallel manner!
            Parallel.ForEach(allFiles, x =>
            {                
                fullName += System.IO.Path.GetFullPath(x)+"\t\t";               

                using (Bitmap bitMap = new Bitmap(x))
                { 
                    //Invoke on the form object,to allow secondary threads to access controls in a thread-safe manner.
                    this.Dispatcher.BeginInvoke((Action)delegate
                    {
                         threadMsg+= Thread.CurrentThread.ManagedThreadId.ToString()+ "\t\t";
                    });
                }
            });

            MessageBox.Show(fullName);
            MessageBox.Show(threadMsg);
        }
    }
}
