using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.Util;
using System.Windows.Forms;
using Emgu.CV.Structure;

namespace ConsoleApp4
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            InitImageViewer();
            Console.ReadLine();
        }

        static void InitImageViewer()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                Image<Bgr, byte> img = new Image<Bgr, byte>(ofd.FileName);
                ImageViewer imageViewer = new ImageViewer(img, "ImageViewer in Console");
                imageViewer.ShowDialog();
            }

        }

    }


     
}
