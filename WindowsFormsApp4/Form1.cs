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
using Emgu.CV.Features2D;
using Emgu.CV.Cuda;
using Emgu.CV.XFeatures2D;
using System.Runtime.InteropServices;
using Emgu.CV.OCR;
using Emgu.CV.Stitching;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            ImageDetect();
        }

        static void InitImageViewer()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(ofd.FileName);
                //create an image viewer.
                ImageViewer viewer = new ImageViewer(My_Image, "ImageViewer Name");

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
            if (ofd.ShowDialog() == DialogResult.OK)
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
                    for (int i = 0; i < count; i++)
                    {
                        using (VectorOfPoint contour = contours[i])
                        using (VectorOfPoint approxContour = new VectorOfPoint())
                        {
                            CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                            if (CvInvoke.ContourArea(approxContour, false) > 250)
                            {
                                if (approxContour.Size == 3)
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
                                if (approxContour.Size == 4)
                                {
                                    #region determine if all the angles in the contour are within[80,100] degree.
                                    bool isRectangle = true;
                                    Point[] pts = approxContour.ToArray();
                                    LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                                    for (int j = 0; j < edges.Length; j++)
                                    {
                                        double angle = Math.Abs(edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                                        if (angle < 80 || angle > 100)
                                        {
                                            isRectangle = false;
                                            break;
                                        }
                                    }

                                    #endregion

                                    if (isRectangle)
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
                foreach (Triangle2DF triangle in triangleList)
                {
                    triangleRectangleImage.Draw(triangle, new Bgr(Color.DarkBlue), 2);
                }

                //foreach(RotatedRect box in rectangleList)
                //{
                //    triangleRectangleImage.Draw(box, new Bgr(Color.DarkOrange), 2);

                //}
                panAndZoomPictureBox2.Image = triangleRectangleImage.ToBitmap();
                #endregion


            }
        }

        private void DetectRectangles()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image<Bgr, Byte> img = new Image<Bgr, byte>(ofd.FileName).
                    Resize(400, 400, Emgu.CV.CvEnum.Inter.Linear, true);

                //Convert the image to grayscale and filter out the noise.
                UMat uMatImg = new UMat();
                CvInvoke.CvtColor(img, uMatImg, ColorConversion.Bgr2Gray);

                ImageViewer imgViewer = new ImageViewer();
                imgViewer.Image = uMatImg.ToImage<Bgr,Byte>();
                imgViewer.ShowDialog();

                //Use image pyr to remove noise
                UMat pyrDown = new UMat();
                CvInvoke.PyrDown(uMatImg, pyrDown);
                CvInvoke.PyrUp(pyrDown, uMatImg);

                #region rectangle detection
                double cannyThreshold = 180.0;
                double cannyThreadsholdLinking = 120.0;
                UMat cannyEdges = new UMat();
                CvInvoke.Canny(uMatImg, cannyEdges, cannyThreshold, cannyThreadsholdLinking);

                LineSegment2D[] lines = CvInvoke.HoughLinesP(cannyEdges,
                    //Distance resolution in pixel-related units.
                    1,
                    //Angle resolution measured in radians.
                    Math.PI / 45.0,
                    //threshold
                    20,
                    //min line width
                    30,
                    //gap between lines
                    10);

                //a box is a rotated rectangle.
                List<RotatedRect> boxList = new List<RotatedRect>();

                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {
                    CvInvoke.FindContours(cannyEdges, contours, null, RetrType.List,
                        ChainApproxMethod.ChainApproxSimple);
                    int contourCount = contours.Size;
                    for (int i = 0; i < contourCount; i++)
                    {
                        using (VectorOfPoint contour = contours[i])
                        using (VectorOfPoint approxContour = new VectorOfPoint())
                        {
                            CvInvoke.ApproxPolyDP(contour, approxContour,
                                CvInvoke.ArcLength(contour, true) * 0.05, true);

                            //only consider contours with area greater than 250.
                            if (CvInvoke.ContourArea(approxContour, false) > 250)
                            {
                                //The contour has 4 vertices.
                                if (approxContour.Size == 4)
                                {
                                    #region determine if all the angles in the contour are within[80,100] degree

                                    bool isRectangle = true;
                                    Point[] pts = approxContour.ToArray();
                                    LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                                    for (int j = 0; j < edges.Length; j++)
                                    {
                                        double angle = Math.Abs(edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                                        if (angle < 80 || angle > 100)
                                        {
                                            isRectangle = false;
                                            break;
                                        }
                                    }
                                    #endregion

                                    if (isRectangle)
                                    {
                                        boxList.Add(CvInvoke.MinAreaRect(approxContour));
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                panAndZoomPictureBox1.Image = img.ToBitmap();

                #region draw rectangles.
                Image<Bgr, Byte> rectangleImage = img.CopyBlank();
                foreach (RotatedRect box in boxList)
                {
                    rectangleImage.Draw(box, new Bgr(Color.DarkOrange), 1);
                }
                panAndZoomPictureBox2.Image = rectangleImage.ToBitmap();
                #endregion
            }
        }

        //Delete a GDI object.
        [DllImport("gdi32")]
        private static extern int DeleteObject(IntPtr o);

        //Convert an Image to a WPF BitMapSource.The result can be used in the Set Property
        //of Image.Source


        private static void StitchImages()
        {
            Image<Bgr, Byte> img;
            Image<Bgr, Byte> img2;
            Image<Bgr, Byte>[] ImageSources = new Image<Bgr, Byte>[2];
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    img = new Image<Bgr, byte>(ofd.FileName);
                    ImageSources[0] = img;
                }
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        img2 = new Image<Bgr, byte>(ofd.FileName);
                        ImageSources[1] = img2;
                    }
                }
            }

            //This indicate if the Stitcher should use GPU for processing.
            //There is currently a bug in OpenCV such that GPU processing can not produce the correct result.
            //Must specify false as parameter.Hope this will be fixed soon to enable GPU processing.
            using (Stitcher stitcher = new Stitcher(false))
            {
                VectorOfMat vectorOfMat = new VectorOfMat();
                vectorOfMat.Push(ImageSources);

                Mat result = new Mat();

                Stitcher.Status stitchStatus = stitcher.Stitch(vectorOfMat, result);
                ImageBox imgBox = new ImageBox();
                imgBox.Image = result;
                imgBox.Show();
            }
        }

        public static void PlanarSubdivision()
        {
            float maxValue = 600;
            #region create random points in the range of [0,maxValue]
            PointF[] pts = new PointF[20];
            Random rnd = new Random((int)(DateTime.Now.Ticks & 0x0000ffff));
            for(int i = 0; i < pts.Length; i++)
            {
                pts[i] = new PointF((float)rnd.NextDouble() * maxValue, (float)rnd.NextDouble() * maxValue);
                
            }

            #endregion


            Triangle2DF[] delaunayTriangles;
            VoronoiFacet[] voronoiFacets;
            //using (PlanarSubdivision subdivision = new PlanarSubdivision(pts))
            //{
            //    //obtain the delaunay's triangulation from the set of points.
            //    delaunayTriangles = subdivision.GetDelaunayTriangles();

            //    //obtain the voronoi facets from the set of points.
            //    voronoiFacets = subdivision.GetVoronoiFaces();
            //}

            //Create an image for display purpose.
            Image<Bgr, Byte> img = new Image<Bgr, byte>((int)maxValue, (int)maxValue);

            ////Create the voronoi Facets.
            //foreach(VoronoiFacet facet in voronoiFacets)
            //{
            //    Point[] points = Array.ConvertAll<PointF, Point>(facet.Vertices, Point.Round);

            //    //Draw the facet in color.
            //    img.FillConvexPoly(points,
            //        new Bgr(rnd.NextDouble() * 120, rnd.NextDouble() * 120, rnd.NextDouble() * 120));

            //    //Highlight the edge of the facet in blank.
            //    img.DrawPolyline(points, true, new Bgr(Color.Black), 2);

            //    //draw the points associated with each facet in red.
            //    img.Draw(new CircleF(facet.Point, 5.0f), new Bgr(Color.Red), 0);
               
            //}

            ////Draw the Delaunay triangulation
            //foreach(Triangle2DF triagnles in delaunayTriangles)
            //{
            //    img.Draw(triagnles, new Bgr(Color.White), 1);
            //}

            //display the image.
            ImageViewer.Show(img, "Plannar subdivision");             
        }

        public static void ConvexHull()
        {
            #region Create some random points.
            Random rnd = new Random();
            PointF[] pts = new PointF[50];
            for(int i=0;i<pts.Length;i++)
            {
                pts[i] = new PointF((float)(100 + rnd.NextDouble() * 400), (float)(100 + rnd.NextDouble() * 400));
            }

            #endregion

            Mat img = new Mat(600, 600, DepthType.Cv8U, 3);
            img.SetTo(new MCvScalar(255.0, 255.0, 255.0));

            //Draw the points.

            foreach(PointF pt in pts)
            {
                CvInvoke.Circle(img, Point.Round(pt), 3, new MCvScalar(0.0, 0.0, 0.0));
            }

            //Find and draw the convex hull.
            Stopwatch watch = Stopwatch.StartNew();
            PointF[] hull = CvInvoke.ConvexHull(pts, true);
            watch.Stop();

            CvInvoke.Polylines(img,
#if NETFX_CORE
                Extensions.ConvertAll<PointF,Point>(hull,Point.Round),
#else
                Array.ConvertAll<PointF, Point>(hull, Point.Round),
#endif
                true, new MCvScalar(255.0, 0.0, 0.0));

            Emgu.CV.UI.ImageViewer.Show(img, string.Format("Convex Hull Computed in {0} milliseconds", watch.ElapsedMilliseconds));
        }

        public static void EllipseFitting()
        {
            #region generate random points
            Random rnd = new Random();
            int sampleCount = 100;
            Ellipse modelEllipse = new Ellipse(new PointF(200, 200), 
                new SizeF(150, 60), 90);
            PointF[] pts = PointCollection.GeneratePointCloud(modelEllipse, sampleCount);
            #endregion

            Stopwatch watch = Stopwatch.StartNew();
            Ellipse fittedEllipse = PointCollection.EllipseLeastSquareFitting(pts);
            watch.Stop();

            #region draw the points and the fitted ellips.
            Mat img = new Mat(400, 400, DepthType.Cv8U, 3);
            img.SetTo(new MCvScalar(255, 255, 255));

            foreach(PointF pf in pts)
            {
                CvInvoke.Circle(img, Point.Round(pf), 2, new MCvScalar(0, 255, 0), 1);
            }

            RotatedRect rect = fittedEllipse.RotatedRect;

            //the detected ellipse was off by 90 degree.
            rect.Angle += 90;

            CvInvoke.Ellipse(img, rect, new MCvScalar(0, 0, 255), 2);

            #endregion

            Emgu.CV.UI.ImageViewer.Show(img, string.Format("Time used:{0} milliseconds", watch.ElapsedMilliseconds));

        }

        public static void MinAreaRect()
        {
            #region generate random points.
            Random rnd = new Random();
            int sampleCount = 100;
            Ellipse modelEllipse = new Ellipse(new PointF(200, 200), new SizeF(90, 60), -60);
            PointF[] pts = PointCollection.GeneratePointCloud(modelEllipse, sampleCount);

            #endregion

          
        }

        public  static void ImageDetect()
        {
            StringBuilder msgBuilder = new StringBuilder("Performance: ");
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image<Bgr, byte> img = new Image<Bgr, byte>(ofd.FileName).
                    Resize(600, 600, Emgu.CV.CvEnum.Inter.Linear, true);

                //Convert the image to grayscale and filter out the noise.
                UMat uMatImg = new UMat();
                CvInvoke.CvtColor(img, uMatImg, ColorConversion.Bgr2Gray);

                //use image pyr to remove noise.
                UMat pyrDown = new UMat();
                CvInvoke.PyrDown(uMatImg, pyrDown);
                CvInvoke.PyrUp(pyrDown, uMatImg);

                #region circle detection
                Stopwatch watch = Stopwatch.StartNew();
                double cannyThreshold = 180.0;
                double circleAccumulatorThreshold = 120;
                CircleF[] circles = CvInvoke.HoughCircles(uMatImg, HoughType.Gradient,
                    2.0, 2.0, cannyThreshold, circleAccumulatorThreshold, 5);

                watch.Stop();
                msgBuilder.Append(string.Format("Hough circle -{0} ms;", watch.ElapsedMilliseconds));

                #endregion

                #region Canny and edge detection
                watch.Reset();
                watch.Start();
                double cannyThresholdLinking = 120.0;
                UMat cannyEdges = new UMat();
                CvInvoke.Canny(uMatImg, cannyEdges, cannyThreshold, cannyThresholdLinking);

                LineSegment2D[] lines = CvInvoke.HoughLinesP(
                    cannyEdges,
                    //Distance resolution in pixel-related units.
                    1,
                    //Angle resolution measured in radius
                    Math.PI / 45,
                    //threshold
                    20,
                    //min line width 
                    30,
                    //gap between lines
                    10);
                watch.Stop();
                msgBuilder.Append(string.Format("Canny & Hough lines -{0} ms;", watch.ElapsedMilliseconds));



                #endregion

                #region Find rectangles
                watch.Reset();

                watch.Start();

                //a box is a rotated rectangle.
                List<RotatedRect> boxList = new List<RotatedRect>();
                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {
                    CvInvoke.FindContours(cannyEdges, contours, null, RetrType.List,
                        ChainApproxMethod.ChainApproxSimple);

                    int count = contours.Size;
                    for (int i = 0; i < count; i++)
                    {
                        using (VectorOfPoint contour = contours[i])
                        using (VectorOfPoint approxContour = new VectorOfPoint())
                        {
                            CvInvoke.ApproxPolyDP(contour, approxContour,
                                CvInvoke.ArcLength(contour, true) * 0.05, true);

                            if (CvInvoke.ContourArea(approxContour, false) > 250)
                            {
                                if (approxContour.Size == 4)
                                {
                                    #region determine if all the angles in the contour are within [80,100] degree
                                    bool isRectangle = true;
                                    Point[] pts = approxContour.ToArray();
                                    LineSegment2D[] edges = PointCollection.PolyLine(pts, true);
                                    for (int j = 0; j < edges.Length; j++)
                                    {
                                        double angle = Math.Abs(edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));

                                        if (angle < 80 || angle > 100)
                                        {
                                            isRectangle = false;
                                            break;
                                        }
                                    }

                                    #endregion

                                    if (isRectangle)
                                    {
                                        boxList.Add(CvInvoke.MinAreaRect(approxContour));
                                    }
                                }
                            }
                        }
                    }
                }

                #endregion

                #region draw rectanles.
                Image<Bgr, Byte> rectangleImage = img.CopyBlank();

                foreach(RotatedRect box in boxList)
                {
                    rectangleImage.Draw(box, new Bgr(Color.Red), 2);
                }
                ImageViewer.Show(rectangleImage, "Rotated Rectangle!");
                
                #endregion             

            }
        }
    }

    public static class DrawMatches
    {
        public static void FindMatch(Mat modelImage, Mat observedImage, out long matchTime,
            out VectorOfKeyPoint modelKeyPoints, out VectorOfKeyPoint observedKeyPoints,
            VectorOfVectorOfDMatch matches, out Mat mask, out Mat homography)
        {
            int k = 2;
            double uniquenessThreshold = 0.8;
            double hessianThresh = 300;
            Stopwatch watch;
            homography = null;

            modelKeyPoints = new VectorOfKeyPoint();
            observedKeyPoints = new VectorOfKeyPoint();

#if !_IOS_
            if (CudaInvoke.HasCuda)
            {
                CudaSURF surfCuda = new CudaSURF((float)hessianThresh);
                using (GpuMat gpuModelImage = new GpuMat(modelImage))
                //extract features from the object image
                using (GpuMat gpuModelKeyPoints = surfCuda.DetectKeyPointsRaw(gpuModelImage, null))
                using (GpuMat gpuModelDescriptors = surfCuda.ComputeDescriptorsRaw(gpuModelImage, null, gpuModelKeyPoints))
                using (CudaBFMatcher matcher = new CudaBFMatcher(DistanceType.L2))
                {
                    surfCuda.DownloadKeypoints(gpuModelKeyPoints, modelKeyPoints);
                    watch = Stopwatch.StartNew();

                    //extract features from the observed image.
                    using (GpuMat gpuObservedImage = new GpuMat(observedImage))
                    using (GpuMat gpuObservedKeyPoints = surfCuda.DetectKeyPointsRaw
                    (gpuObservedImage, null))
                    using (GpuMat gpuObservedDescriptors = surfCuda.ComputeDescriptorsRaw
                        (gpuObservedImage, null, gpuObservedKeyPoints))
                    {
                        matcher.KnnMatch(gpuObservedDescriptors, gpuModelDescriptors, matches, k);
                        surfCuda.DownloadKeypoints(gpuObservedKeyPoints, observedKeyPoints);

                        mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
                        Features2DToolbox.VoteForUniqueness(matches, uniquenessThreshold, mask);

                        int nonZeroCount = CvInvoke.CountNonZero(mask);
                        if(nonZeroCount>=4)
                        {
                            nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints,
                                observedKeyPoints, matches, mask, 1.5, 20);
                            if(nonZeroCount>=4)
                            {
                                homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures
                                    (modelKeyPoints, observedKeyPoints, matches, mask, 2);
                            }
                        }
                    }
                    watch.Stop();

                }
            }

#endif
            else
            {
                using (UMat uModelImage = modelImage.GetUMat(AccessType.Read))
                using (UMat uObservedImage = observedImage.GetUMat(AccessType.Read))
                {
                    SURF surfCPU = new SURF(hessianThresh);

                    //extract features from the object image.
                    UMat modelDescriptors = new UMat();
                    surfCPU.DetectAndCompute(uModelImage, null, modelKeyPoints, modelDescriptors, false);

                    watch = Stopwatch.StartNew();

                    //extract features from the observed image.s
                    UMat observedDescriptors = new UMat();
                    surfCPU.DetectAndCompute(uObservedImage, null, observedKeyPoints,
                        observedDescriptors, false);

                    BFMatcher matcher = new BFMatcher(DistanceType.L2);
                    matcher.Add(modelDescriptors);

                    matcher.KnnMatch(observedDescriptors, matches, k, null);
                    mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
                    mask.SetTo(new MCvScalar(255));
                    Features2DToolbox.VoteForUniqueness(matches, uniquenessThreshold, mask);

                    int nonZeroCount = CvInvoke.CountNonZero(mask);
                    if(nonZeroCount>=4)
                    {
                        nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(
                            modelKeyPoints, observedKeyPoints,
                            matches, mask, 1.5, 20);
                        if(nonZeroCount>=4)
                        {
                            homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures
                                (modelKeyPoints, observedKeyPoints, matches, mask, 2);
                        }
                    }

                    watch.Stop();

                }
            }

            matchTime = watch.ElapsedMilliseconds;
        }

        //Draw the model image and observed image,the matched features and homography projection.
        //returns the model image and observed image,the matched featuresand homography projection
        public static Mat Draw(Mat modelImage,Mat observedImage,out long matchTime)
        {
            Mat homography;
            VectorOfKeyPoint modelKeyPoints;
            VectorOfKeyPoint observedKeyPoints;
            using (VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch())
            {
                Mat mask;
                FindMatch(modelImage, observedImage, out matchTime, out modelKeyPoints,
                    out observedKeyPoints, matches, out mask, out homography);

                //Draw the matched keypoints
                Mat result = new Mat();
                Features2DToolbox.DrawMatches(modelImage, modelKeyPoints,
                    observedImage, observedKeyPoints,
                    matches, result, new MCvScalar(255, 255, 255), new MCvScalar(255,
                    255, 255), mask);

#region draw the projected region on the image.

                if(homography!=null)
                {
                    //draw a rectangle along the projected model.
                    Rectangle rect = new Rectangle(Point.Empty, modelImage.Size);

                    PointF[] pts = new PointF[]
                    {
                        new PointF(rect.Left,rect.Bottom),
                        new PointF(rect.Right,rect.Bottom),
                        new PointF(rect.Right,rect.Top),
                        new PointF(rect.Left,rect.Top)
                    };

                    pts = CvInvoke.PerspectiveTransform(pts, homography);

                    Point[] points = Array.ConvertAll<PointF, Point>(pts, Point.Round);

                    using (VectorOfPoint vp = new VectorOfPoint(points))
                    {
                        CvInvoke.Polylines(result, vp, true, new MCvScalar(255, 0, 0, 255), 5);
                    }
                }
#endregion
                return result;
            }
        }

    }

    public class StopSignDetector : DisposableObject
    {
       
        protected override void DisposeObject()
        {
            this.Dispose();
        }
    }

    //A simple license plate detector.
    public class LicensePlateDetector : DisposableObject
    {
        //The OCR engine
        private Tesseract _ocr;

        //create a license plate detector.
        public LicensePlateDetector(string dataPath)
        {
            //Create OCR engine
            _ocr = new Tesseract(dataPath, "eng", OcrEngineMode.TesseractLstmCombined);
            _ocr.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ-1234567890");
        }

        //Detect license plate from the given image.
        //returns the list of words for each license plate.
        public List<string> DetectLicensePlate(
            IInputArray img,
            List<IInputOutputArray>  licensePlateImagesList,
            List<IInputOutputArray> filteredLicensePlateImagesList,
            List<RotatedRect> detectedLicensePlateRegionList)
        {
            List<string> licenseList = new List<string>();
            using (Mat gray = new Mat())
            using (Mat canny = new Mat())
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.CvtColor(img, gray, ColorConversion.Bgr2Gray);
                CvInvoke.Canny(gray, canny, 100, 50, 3, false);
                int[,] hierarchy = CvInvoke.FindContourTree(canny, contours,
                    ChainApproxMethod.ChainApproxSimple);
                FindLicensePlate(contours, hierarchy, 0, gray, canny,
                    licensePlateImagesList, filteredLicensePlateImagesList,
                    detectedLicensePlateRegionList, licenseList);                
            }
            return licenseList;
        }

        private static int GetNumberOfChildern(int[,] hierarchy,int idx)
        {
            //first child.
            idx = hierarchy[idx, 2];
            if(idx<0)
            {
                return 0;
            }

            int count = 1;
            while(hierarchy[idx,0]>0)
            {
                count++;
                idx = hierarchy[idx, 0];
            }
            return count;
        }

        private void FindLicensePlate(VectorOfVectorOfPoint contours,
            int[,] hierarchy,int idx,IInputArray gray,IInputArray canny,
            List<IInputOutputArray> licensePlateImagesList,
            List<IInputOutputArray> filteredLicensePlateImagesList,
            List<RotatedRect> detectedLicensePlateRegionList,
            List<string> licenseList) 
        {

            for(;idx>=0;idx=hierarchy[idx,0])
            {
                int numberOfChildern = GetNumberOfChildern(hierarchy, idx);

                //if it does not contain any children(character),it is not a license plate region
                if(numberOfChildern==0)
                {
                    continue;
                }

                using (VectorOfPoint contour = contours[idx])
                {
                    if(CvInvoke.ContourArea(contour)>400)
                    {
                        if (numberOfChildern < 3)
                        {
                            //If the contour has less than 3 children,it is not a license plate
                            //However we should search the children of this contour to see if any
                            //of them is a license plate.

                            FindLicensePlate(contours, hierarchy, hierarchy[idx, 2], gray, 
                                canny, licensePlateImagesList,filteredLicensePlateImagesList,
                                detectedLicensePlateRegionList, licenseList);
                            continue;
                        }

                        RotatedRect box = CvInvoke.MinAreaRect(contour);
                        if(box.Angle<-45.0)
                        {
                            float tmp = box.Size.Width;
                            box.Size.Width = box.Size.Height;
                            box.Size.Height = tmp;
                            box.Angle += 90.0f;
                        }
                        else if(box.Angle>45.0)
                        {
                            float tmp = box.Size.Width;
                            box.Size.Width = box.Size.Height;
                            box.Size.Height = tmp;
                            box.Angle -= 90.0f;                           
                        }

                        double whRatio = (double)box.Size.Width / box.Size.Height;
                        if(!(whRatio>3.0 && whRatio<10.0))
                        {
                            if(hierarchy[idx,2]>0)
                            {
                                FindLicensePlate(contours, hierarchy, hierarchy[idx, 2], 
                                    gray, canny,licensePlateImagesList,
                                    filteredLicensePlateImagesList,
                                    detectedLicensePlateRegionList,licenseList);
                                continue;
                            }

                            using (UMat temp1 = new UMat())
                            using (UMat temp2 = new UMat())
                            {
                                PointF[] srcCorners = box.GetVertices();
                                PointF[] destCorners = new PointF[]
                                {
                                    new PointF(0,box.Size.Height-1),
                                    new PointF(0,0),
                                    new PointF(box.Size.Width-1,0),
                                    new PointF(box.Size.Width-1,box.Size.Height-1)
                                };
                                
                                using (Mat rot = CvInvoke.GetAffineTransform(srcCorners, destCorners))
                                {
                                    CvInvoke.WarpAffine(gray, temp1, rot, Size.Round(box.Size));                                    
                                }

                                //resize the license plate such that the front is ~10-12.
                                //The size of front results in better accuracy from tesseract.
                                Size approxSize = new Size(240, 180);
                                double scale = Math.Min(approxSize.Width / box.Size.Width,
                                    approxSize.Height / box.Size.Height);
                                Size newSize = new Size((int)Math.Round(box.Size.Width * scale), 
                                    (int)Math.Round(box.Size.Height * scale));
                                CvInvoke.Resize(temp1, temp2, newSize, 0, 0, Inter.Cubic);


                                //removes some pixels from the edge.
                                int edgePixelSize = 2;
                                Rectangle newRoi = new Rectangle(new Point(edgePixelSize, edgePixelSize),
                                    temp2.Size - new Size(2 * edgePixelSize, 2 * edgePixelSize));

                                UMat plate = new UMat(temp2, newRoi);
                                UMat filteredPlate = FilterPlate(plate);

                                Tesseract.Character[] words;
                                StringBuilder strBuilder = new StringBuilder();
                                using (UMat tmp = filteredPlate.Clone())
                                {
                                    _ocr.Recognize();
                                    words = _ocr.GetCharacters();

                                    if(words.Length==0)
                                    {
                                        continue;
                                    }

                                    for(int i=0;i<words.Length;i++)
                                    {
                                        strBuilder.Append(words[i].Text);
                                    }
                                }

                                licenseList.Add(strBuilder.ToString());
                                licensePlateImagesList.Add(plate);
                                filteredLicensePlateImagesList.Add(filteredPlate);
                                detectedLicensePlateRegionList.Add(box);                                
                            }
                        }
                    }
                }
            }
             
        }

        //Filter the license plate to remove noise
        private static UMat FilterPlate(UMat plate)
        {
            UMat thresh = new UMat();
            CvInvoke.Threshold(plate, thresh, 120, 255, ThresholdType.BinaryInv);

            Size plateSize = plate.Size;
            using (Mat plateMask = new Mat(plateSize.Height, plateSize.Width, 
                DepthType.Cv8U, 1))
            using (Mat plateCanny = new Mat())
            using(VectorOfVectorOfPoint contours=new VectorOfVectorOfPoint())
            {
                plateMask.SetTo(new MCvScalar(255, 0));
                CvInvoke.Canny(plate, plateCanny, 100, 50);
                CvInvoke.FindContours(plateCanny, contours, null, RetrType.External,
                    ChainApproxMethod.ChainApproxSimple);

                int count = contours.Size;
                for(int i=1;i<count;i++)
                {
                    using (VectorOfPoint contour = contours[i])
                    {
                        Rectangle rect = CvInvoke.BoundingRectangle(contour);
                        if(rect.Height>(plateSize.Height>>1))
                        {
                            rect.X -= 1;
                            rect.Y -= 1;
                            rect.Width += 2;
                            rect.Height += 2;
                            Rectangle roi = new Rectangle(Point.Empty, plate.Size);
                            rect.Intersect(roi);

                            CvInvoke.Rectangle(plateMask, rect, new MCvScalar(), -1);                            
                        }
                    }
                }
                thresh.SetTo(new MCvScalar(), plateMask);
            }

            CvInvoke.Erode(thresh, thresh, null, new Point(-1, -1), 1,
                BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);

            CvInvoke.Dilate(thresh, thresh, null, new Point(-1, -1), 1,
                BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
            return thresh;
        }
        protected override void DisposeObject()
        {
            base.Dispose();
        }
    }

    public static class DrawSubDivision
    {
        //Create planar subdivision for random points.
        public static void CreateSubdivision(float maxValue,int pointCount,
            out Triangle2DF[] delaunayTriagnles,out VoronoiFacet[] voronoiFacets)
        {
#region create random points in the range of [0,maxValue]
            PointF[] pts = new PointF[pointCount];
            Random rnd = new Random((int)(DateTime.Now.Ticks & 0x0000ffff));
            for(int i=0;i<pts.Length;i++)
            {
                pts[i] = new PointF((float)rnd.NextDouble() * maxValue,
                   (float)rnd.NextDouble() * maxValue);
            }

#endregion
            using (Subdiv2D subDivision = new Subdiv2D(pts))
            {
                //obtain the delaunay's triangulation from the set of points.
                delaunayTriagnles = subDivision.GetDelaunayTriangles();

                //Obtain the voronoi facets from the set of points.
                voronoiFacets = subDivision.GetVoronoiFacets();
            }            
        }

        //Draw the planar subdivison.
        public static Mat  Draw(float maxValue,int pointCount)
        {
            Triangle2DF[] delaunyTriangles;
            VoronoiFacet[] voronoiFacets;
            Random rnd = new Random((int)(DateTime.Now.Ticks & 0x0000ffff));

            CreateSubdivision(maxValue, pointCount, out delaunyTriangles, out voronoiFacets);

            //create an image for display purpose.
            Mat img = new Mat((int)maxValue, (int)maxValue, DepthType.Cv8U, 3);

            //Draw the voronoi Facets.
            foreach(VoronoiFacet facet in voronoiFacets)
            {
#if NETFX_CORE
               Point[] polyline=Extensions.ConvertAll<PointF,Point>(facet.Vertices,
                Point.Round);

#else
                Point[] polyline = Array.ConvertAll<PointF, Point>(facet.Vertices,
                    Point.Round);
#endif
                using (VectorOfPoint vp = new VectorOfPoint(polyline))
                using (VectorOfVectorOfPoint vvp = new VectorOfVectorOfPoint(vp))
                {
                    //Draw the facet in color
                    CvInvoke.FillPoly(img, vvp, new Bgr(rnd.NextDouble() * 120,
                        rnd.NextDouble() * 120, rnd.NextDouble() * 120).MCvScalar);

                    //highlight the edge of the facet in black
                    CvInvoke.Polylines(img, vp, true, new Bgr(0, 0, 0).MCvScalar, 2);
                }

                //draw the points associated with each facet in red.
                CvInvoke.Circle(img, Point.Round(facet.Point), 5, new Bgr(0, 0, 255).MCvScalar, -1);
            }

            //Draw the Delaunay triangulation.
            foreach(Triangle2DF triangle in delaunyTriangles)
            {
#if NETFX_CORE
                Point[] vertices=Extensions.ConvertAll<PointF,Point>(triangle.GetVertices(),Point.Round);
#else
                Point[] vertices = Array.ConvertAll<PointF, Point>(triangle.GetVertices(), Point.Round);
#endif

                using (VectorOfPoint vp = new VectorOfPoint(vertices))
                {
                    CvInvoke.Polylines(img, vp, true, new Bgr(255, 255, 255).MCvScalar);
                }

            }
            return img;
        }
    }
}
