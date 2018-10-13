using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitWin();
        }

        private void InitWin()
        {
            //The name of the window.
            string win = "Emgu Window";

            //Create the window using the specific name
            CvInvoke.NamedWindow(win);

            //Create a 3 channel image of 400*200
            using (Mat img = new Mat(200, 400, DepthType.Cv8U, 3))
            {
                //set it to blue color.
                img.SetTo(new Bgr(255, 0, 0).MCvScalar);


                //Draw "hello world" on the image using the specific font.
                CvInvoke.PutText(
                    img,
                    "Hello Emgu",
                    new System.Drawing.Point(10, 80),
                    FontFace.HersheyComplex,
                    1.0,
                    new Bgr(0, 255, 0).MCvScalar);

                //Show the image using ImageViewer from Emgu.CV.UI
                ImageViewer.Show(img, "Emgu Test Window");
            }
            
        }
    }
}
