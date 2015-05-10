using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace TrafficSignRecognition
{
    public partial class Form1 : Form
    {
        private List<Image<Bgr, Byte>> imageToAnalize;
        private Image<Bgr, Byte> orginalImage;
        private Image<Bgr, Byte> convertedImage;
        private const int guassianKernelSizeDefault = 5;
        private const int apertureSizeDefault = 3;
        private const double threshCanny1ValueDefault = 40;
        private const double threshCanny2ValueDefault = 80;
        private const double threshCircle1ValueDefault = threshCanny2ValueDefault;
        private const double accumulatorCircleNumericValueDefault = 2 * threshCircle1ValueDefault;
        private const double resolutionCricleValueDefault = 2;
        private const double minDistCircleValueDefault = 30;
        private const double minRadCircleNumericValueDefault = 30;
        private const double maxRadCirclNumericValueDefault = 100;
        private const double accuracyTriRecNumericValueDefault = 0.05;
        private const double minPoleTriRecNumericValueDefault = 400;
        private const double minRectAngleTriRecNumericValueDefault = 80;
        private const double maxRectAngleTriRecNumericValueDefault = 100;


        public Form1()
        {
            InitializeComponent();
            InitializeGuassianKernelNumeric();
            InitializeCannyParameters();
            InitializeCircleParameters();
            InitializeTriRecParameters();
            imageToAnalize = new List<Image<Bgr, byte>>();
        }

        private void InitializeGuassianKernelNumeric()
        {
            guassianKernelNumeric.Value = guassianKernelSizeDefault;
            guassianKernelNumeric.Maximum = 101;
            guassianKernelNumeric.Minimum = 1;
        }

        private void InitializeCannyParameters()
        {
            threshCanny1Numeric.Minimum = 0;
            threshCanny1Numeric.Maximum = 255;
            threshCanny1Numeric.Value = (decimal)threshCanny1ValueDefault;

            threshCanny2Numeric.Minimum = 0;
            threshCanny2Numeric.Maximum = 255;
            threshCanny2Numeric.Value = (decimal)threshCanny2ValueDefault;

            apertureNumeric.Minimum = 0;
            apertureNumeric.Maximum = 100;
            apertureNumeric.Value = apertureSizeDefault;
        }

        private void InitializeCircleParameters()
        {
            threshCircle1Numeric.Minimum = 0;
            threshCircle1Numeric.Maximum = 255;
            threshCircle1Numeric.Value = (decimal)threshCircle1ValueDefault;

            accumulatorCircleNumeric.Minimum = 0;
            accumulatorCircleNumeric.Maximum = 255;
            accumulatorCircleNumeric.Value = (decimal)accumulatorCircleNumericValueDefault;


            resolutionCricleNumeric.Value = (decimal)resolutionCricleValueDefault;
            minDistCircleNumeric.Value = (decimal)minDistCircleValueDefault;
            minRadCircleNumeric.Value = (decimal)minRadCircleNumericValueDefault;
            maxRadCirclNumeric.Value = (decimal)maxRadCirclNumericValueDefault;
        }

        private void InitializeTriRecParameters()
        {
            accuracyTriRecNumeric.Minimum = 0;
            accuracyTriRecNumeric.Maximum = 1;
            accuracyTriRecNumeric.Value = (decimal)accuracyTriRecNumericValueDefault;

            minPoleTriRecNumeric.Minimum = 0;
            minPoleTriRecNumeric.Maximum = 5000;
            minPoleTriRecNumeric.Value = (decimal)minPoleTriRecNumericValueDefault;

            minPoleTriRecNumeric.Minimum = 0;
            minPoleTriRecNumeric.Maximum = 360;
            minRectAngleTriRecNumeric.Value = (decimal)minRectAngleTriRecNumericValueDefault;
            minPoleTriRecNumeric.Minimum = 0;
            minPoleTriRecNumeric.Maximum = 360;
            maxRectAngleTriRecNumeric.Value = (decimal)maxRectAngleTriRecNumericValueDefault;
                   
      


        }





        private void loadImageBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog Openfile = new OpenFileDialog())
            {
                if (Openfile.ShowDialog() == DialogResult.OK)
                {
                    orginalImage = new Image<Bgr, byte>(Openfile.FileName);
                    convertedImage = new Image<Bgr, byte>(orginalImage.Bitmap);
                    imageBox.Image = convertedImage.ToBitmap();
                }
            }
        }



        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            imageBox.Focus();
        }
        private void findBtn_Click(object sender, EventArgs e)
        {

        }

        private void graScaleBtn_Click(object sender, EventArgs e)
        {
            Image<Gray, Byte> grayImage = convertedImage.Convert<Gray, Byte>();
            convertedImage = new Image<Bgr, byte>(grayImage.Bitmap);
            imageBox.Image = convertedImage.Bitmap;
        }

        private void gaussianBtn_Click(object sender, EventArgs e)
        {
            try
            {
                convertedImage = convertedImage.SmoothGaussian((int)guassianKernelNumeric.Value);
            }
            catch (Emgu.CV.Util.CvException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            imageBox.Image = convertedImage.Bitmap;
        }
        private void cannyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                convertedImage = new Image<Bgr, byte>(convertedImage.Canny((double)threshCanny1Numeric.Value, (double)threshCanny2Numeric.Value, (int)apertureNumeric.Value).Bitmap);
                imageBox.Image = convertedImage.Bitmap;
            }
            catch (Emgu.CV.Util.CvException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            convertedImage = new Image<Bgr, byte>(orginalImage.Bitmap);
            imageBox.Image = convertedImage.Bitmap;
        }

        #region ScaleMoveImageSection
        private bool Dragging;
        private int xPos;
        private int yPos;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Dragging = true;
                xPos = e.X;
                yPos = e.Y;
            }
        }


        private void pictureBox1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (imageBox.Image != null)
            {

                if (e.Delta > 0)
                {
                    imageBox.Scale(new SizeF(1.1F, 1.1F));
                }
                else
                {
                    imageBox.Scale(new SizeF(0.9F, 0.9F));
                }

            }
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (Dragging && c != null)
            {
                c.Top = e.Y + c.Top - yPos;
                c.Left = e.X + c.Left - xPos;
            }
        }
        #endregion

        private void circlesBtn_Click(object sender, EventArgs e)
        {
            int gray1 = (int)threshCircle1Numeric.Value;
            int gray2 = (int)accumulatorCircleNumeric.Value;

            try
            {
                CircleF[] circles = convertedImage.Clone().HoughCircles(
                new Bgr(gray1, gray1, gray1),
                new Bgr(gray2, gray2, gray2),
                (double)resolutionCricleNumeric.Value, //Resolution of the accumulator used to detect centers of the circles
                (double)minDistCircleNumeric.Value, //min distance 
                (int)minRadCircleNumeric.Value, //min radius
                (int)maxRadCirclNumeric.Value //max radius
                )[0]; //Get the circles from the first channel

                Image<Bgr, Byte> circleImage = new Image<Bgr, byte>(orginalImage.Bitmap);

                foreach (CircleF circle in circles)
                {
                    int radius = (int)Math.Ceiling(circle.Radius); // gora, zeby wziac wiecej
                    int x = (int)Math.Floor(circle.Center.X) - radius; // podloga, zeby wziac szerszy obszar
                    int y = (int)Math.Floor(circle.Center.Y) - radius; // podloga, zeby wziac szerszy obszar
                    Point point = new Point(x, y);
                    var imageToAdd = circleImage.GetSubRect(new Rectangle(point, new Size(radius * 2, radius * 2)));
                    imageToAnalize.Add(imageToAdd.Resize(30,30, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, false));
                    circleImage.Draw(circle, new Bgr(Color.Lime), 4);
                }

                imageBox.Image = circleImage.Bitmap;
            }
            catch (Emgu.CV.Util.CvException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }



        }

        private void threshCanny2Numeric_ValueChanged(object sender, EventArgs e)
        {
            threshCircle1Numeric.Value = ((NumericUpDown)sender).Value;
        }

        private void triRecBtn_Click(object sender, EventArgs e)
        {
            List<Triangle2DF> triangleList = new List<Triangle2DF>();
            List<MCvBox2D> boxList = new List<MCvBox2D>();

            try
            {
                using (MemStorage storage = new MemStorage())
                {
                    Image<Gray, Byte> grayscaleImage = convertedImage.Convert<Gray, Byte>();
                    for (
                       Contour<Point> contours = grayscaleImage.FindContours(
                          Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                          Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST,
                          storage);
                       contours != null;
                       contours = contours.HNext)
                    {
                        Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * (double)accuracyTriRecNumeric.Value, storage);

                        if (currentContour.Area > (double)minPoleTriRecNumeric.Value)
                        {
                            if (currentContour.Total == 3) //The contour has 3 vertices, it is a triangle
                            {
                                Point[] pts = currentContour.ToArray();
                                triangleList.Add(new Triangle2DF(
                                   pts[0],
                                   pts[1],
                                   pts[2]
                                   ));
                            }
                            else if (currentContour.Total == 4) //The contour has 4 vertices.
                            {
                                bool isRectangle = true;
                                Point[] pts = currentContour.ToArray();
                                LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                                for (int i = 0; i < edges.Length; i++)
                                {
                                    double angle = Math.Abs(
                                       edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                                    if (angle < (double)minRectAngleTriRecNumeric.Value || angle > (double)maxRectAngleTriRecNumeric.Value)
                                    {
                                        isRectangle = false;
                                        break;
                                    }
                                }

                                if (isRectangle) boxList.Add(currentContour.GetMinAreaRect());
                            }
                        }

                        Image<Bgr, Byte> triangleImage = new Image<Bgr, byte>(orginalImage.Bitmap);

                        foreach (var t in triangleList)
                        {
                            float[] xTable = new float[3] { t.V0.X, t.V1.X, t.V2.X };
                            float[] yTable = new float[3] { t.V0.Y, t.V1.Y, t.V2.Y };
                            int minX =  (int)Math.Floor(xTable.Min());
                            int maxX = (int)Math.Floor(xTable.Max());
                            int minY = (int)Math.Floor(yTable.Min());
                            int maxY =  (int)Math.Floor(yTable.Max());
                            Point point = new Point(minX, minY);
                            int lengthX = maxX - minX;
                            int lengthY = maxY - minY;
                            var imageToAdd = triangleImage.GetSubRect(new Rectangle(point, new Size(maxX - minX, maxY - minY)));
                            imageToAnalize.Add(imageToAdd.Resize(30, 30, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, false));
                            triangleImage.Draw(t, new Bgr(Color.Lime), 4);
                        }
                        imageBox.Image = triangleImage.Bitmap;

                        Image<Bgr, Byte> rectangleImage = new Image<Bgr, byte>(triangleImage.Bitmap);

                        foreach (var r in boxList)
                        {
                            int xLength = (int)Math.Ceiling(r.size.Width); // gora, zeby wziac wiecej
                            int yLength = (int)Math.Ceiling(r.size.Height); // gora, zeby wziac wiecej
                            int x = (int)Math.Floor(r.center.X) - xLength/2; // podloga, zeby wziac szerszy obszar
                            int y = (int)Math.Floor(r.center.Y) - yLength/2; // podloga, zeby wziac szerszy obszar
                            Point point = new Point(x, y);
                            var imageToAdd = rectangleImage.GetSubRect(new Rectangle(point, new Size(xLength, yLength)));
                            imageToAnalize.Add(imageToAdd.Resize(30,30, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, false));
                            rectangleImage.Draw(r, new Bgr(Color.Lime), 4);
                        }
                        imageBox.Image = rectangleImage.Bitmap;

                    }
                }
            }
            catch (Emgu.CV.Util.CvException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }





        }
    }
}





