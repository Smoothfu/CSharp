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
using System.Diagnostics;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DetectRectangleEllipseCircles();
        }

        static void InitImageViewer()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
               
                Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(ofd.FileName);
                //create an image viewer.
                ImageViewer viewer = new ImageViewer(My_Image,"ImageViewer Name");
                 
                viewer.ShowDialog();
            }
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

                //Colour Image
                Color R = Color.Red;
                //Write to the Red Spectrum.
                My_Image.Data[0, 0, 2] = R.R;
                //Write to the Green Spectrum.
                My_Image.Data[0, 0, 1] = R.G;
                //Write to the Blue Spectrum.
                My_Image.Data[0, 0, 0] = R.B;
                panAndZoomPictureBox1.Image = My_Image.ToBitmap();
                //Colour Image.
                Bgr my_Bgr = My_Image[0, 0];
                Color my_Color = Color.FromArgb(My_Image.Data[0, 0, 0], My_Image.Data[0, 0, 1], My_Image.Data[0, 0, 2]);

                Image<Gray, byte> gray_Image = My_Image.Convert<Gray, byte>();

                //Gray Image
                gray_Image[0, 0] = new Gray(200);
                Gray my_Gray = gray_Image[0, 0];
                int my_Intensity = gray_Image.Data[0, 0, 0];
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

        private void DetectRectangleEllipseCircles()
        {
            StringBuilder msgBuilder = new StringBuilder("Performance: ");
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Load the image from file and resize it for display.
                Image<Bgr, Byte> img = new Image<Bgr, byte>(ofd.FileName).Resize(1300, 800,
                    Emgu.CV.CvEnum.Inter.Linear, true);

                //Convert the image to grayscale and filter out the noise 
                UMat uImg = new UMat();
                CvInvoke.CvtColor(img, uImg, ColorConversion.Bgr2Gray);

                //use image pyr to remove noise.
                UMat pyrDown = new UMat();
                CvInvoke.PyrDown(uImg, pyrDown);
                CvInvoke.PyrUp(pyrDown, uImg);



                #region circle detection
                Stopwatch watch = Stopwatch.StartNew();
                double cannyThreshold = 180.0;
                double circleAccumulatorThreshold = 120;
                CircleF[] circles = CvInvoke.HoughCircles(uImg, HoughType.Gradient,
                    2.0, 20.0, cannyThreshold, circleAccumulatorThreshold, 5);


                watch.Stop();
                msgBuilder.Append(string.Format("Hough circles -{0} ms;", watch.ElapsedMilliseconds));

                string circleCaption = string.Format("Hough circles -{0} ms;", watch.ElapsedMilliseconds);

                #endregion

                #region draw circles
                Image<Bgr, Byte> circleImage = img.CopyBlank();
                foreach (CircleF circle in circles)
                {
                    circleImage.Draw(circle, new Bgr(Color.Brown), 5);
                }

                panAndZoomPictureBox1.Image = img.ToBitmap();
                panAndZoomPictureBox2.Image = circleImage.ToBitmap();

                #endregion

                #region Canny and edge detection
                watch.Reset();
                watch.Start();
                double cannyThreadsholdLinking = 120.0;
                UMat cannyEdges = new UMat();
                CvInvoke.Canny(uImg, cannyEdges, cannyThreshold, cannyThreadsholdLinking);

                LineSegment2D[] lines = CvInvoke.HoughLinesP(
                    cannyEdges,

                    //Distance resolution in pixel-related units 
                    1,
                    //Angle resolution measured in radians.
                    Math.PI / 45.0,
                    //threshold
                    20,
                    //min Line width
                    30,
                    //gap between lines
                    10);
                watch.Stop();
                string cannyMsg = string.Format("Canny & Hough lines -{0} ms", watch.ElapsedMilliseconds);
                #endregion

                #region
                watch.Reset();
                watch.Start();
                List<Triangle2DF> triangleList = new List<Triangle2DF>();

                //a box is a rotated rectangle.
                List<RotatedRect> rectangleList = new List<RotatedRect>();
                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {
                    CvInvoke.FindContours(cannyEdges, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                    int count = contours.Size;
                    for(int i=0;i<count;i++)
                    {
                        using (VectorOfPoint contour = contours[i])
                        using (VectorOfPoint approxContour = new VectorOfPoint())
                        {
                            CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                            if(CvInvoke.ContourArea(approxContour,false)>250)
                            {
                                if(approxContour.Size==3)
                                {
                                    Point[] pts = approxContour.ToArray();
                                    triangleList.Add(new Triangle2DF(
                                        pts[0],
                                        pts[1],
                                        pts[2]
                                        ));
                                }
                                else
                                //The contour has 4 vertices.
                                if(approxContour.Size==4)
                                {
                                    #region determine if all the angles in the contour are within[80,100] degree.
                                    bool isRectangle = true;
                                    Point[] pts = approxContour.ToArray();
                                    LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                                    for(int j=0;j<edges.Length;j++)
                                    {
                                        double angle = Math.Abs(edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                                        if(angle<80 || angle>100)
                                        {
                                            isRectangle = false;
                                            break;
                                        }
                                    }

                                    #endregion

                                    if(isRectangle)
                                    {
                                        rectangleList.Add(CvInvoke.MinAreaRect(approxContour));
                                    }
                                }
                            }
                        }
                    }
                }

                watch.Stop();
                string triangleRectMsg = string.Format("Triangles & Rectangles -{0} ms;", watch.ElapsedMilliseconds);


                #endregion


                #region draw triangles and rectangles
                Image<Bgr, Byte> triangleRectangleImage = img.CopyBlank();
                foreach(Triangle2DF triangle in triangleList)
                {
                    triangleRectangleImage.Draw(triangle, new Bgr(Color.DarkBlue), 2);
                }

                foreach(RotatedRect box in rectangleList)
                {
                    triangleRectangleImage.Draw(box, new Bgr(Color.DarkOrange), 2);
                    
                }
                panAndZoomPictureBox2.Image = triangleRectangleImage.ToBitmap();
                #endregion


            }
        }
    }
}
