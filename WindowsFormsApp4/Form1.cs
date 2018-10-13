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
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.Util;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitPanAndZoomPictureBoxes();
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

        private void InitPanAndZoomPictureBoxes()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(ofd.FileName);
                panAndZoomPictureBox1.Image = My_Image.ToBitmap();
                Image<Gray, byte> gray_Image = My_Image.Convert<Gray, byte>();
                panAndZoomPictureBox2.Image = gray_Image.ToBitmap();
            }
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(ofd.FileName);
                panAndZoomPictureBox1.Image = My_Image.ToBitmap();
                Image<Gray, byte> gray_Image = My_Image.Convert<Gray, byte>();
                panAndZoomPictureBox2.Image = gray_Image.ToBitmap();
            }
        }
    }
}
