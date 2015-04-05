using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficSignRecognition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeGuassianKernelNumeric();
            InitializeCannyParameters();
           
        }

        private void InitializeGuassianKernelNumeric()
        {
            guassianKernelNumeric.Value = guassianKernelSizeDefault;
            guassianKernelNumeric.Maximum = 101;
            guassianKernelNumeric.Minimum = 1;
        }

        private  void InitializeCannyParameters()
        {
            thresh1Numeric.Minimum = 0;
            thresh1Numeric.Value = (decimal)thresh1ValueDefault;

            thresh2Numeric.Minimum = 0;
            thresh2Numeric.Value = (decimal)thresh2ValueDefault;

            apertureNumeric.Minimum = 0;
            apertureNumeric.Maximum = 100;
            apertureNumeric.Value = apertureSizeDefault;
        }

        private Image<Bgr, Byte> orginalImage;
        private Image<Bgr, Byte> convertedImage;
        private const int guassianKernelSizeDefault = 5;
        private const int apertureSizeDefault = 5;
        private const double thresh1ValueDefault = 40;
        private const double thresh2ValueDefault = 100;



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
            Image<Gray, Byte> grayImage = convertedImage.Convert<Gray,Byte>();
            convertedImage= new Image<Bgr,byte>(grayImage.Bitmap);
            imageBox.Image = convertedImage.Bitmap;
        }

        private void gaussianBtn_Click(object sender, EventArgs e)
        {
            try
            {
                convertedImage = convertedImage.SmoothGaussian((int)guassianKernelNumeric.Value);
            }
            catch(Emgu.CV.Util.CvException ex)
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
                convertedImage = new Image<Bgr, byte>(convertedImage.Canny((double)thresh1Numeric.Value, (double)thresh2Numeric.Value, (int)apertureNumeric.Value).Bitmap);
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


        //Find shapes from internet example
        //private void findBtn_Click(object sender, EventArgs e)
        //{
        //    grayImage = orginalImage.Convert<Gray, Byte>().PyrDown().PyrUp();
        //    convertedImgBox.Image = grayImage.ToBitmap();

        //    Gray cannyThreshold = new Gray(180);
        //    Gray cannyThresholdLinking = new Gray(120);
        //    Gray circleAccumulatorThreshold = new Gray(120);

        //    CircleF[] circles = grayImage.HoughCircles(
        //    cannyThreshold,
        //    circleAccumulatorThreshold,
        //    5.0, //Resolution of the accumulator used to detect centers of the circles
        //    10.0, //min distance 
        //    5, //min radius
        //    0 //max radius
        //    )[0]; //Get the circles from the first channel


        //    Image<Gray, Byte> cannyEdges = grayImage.Canny(cannyThreshold.Intensity, cannyThresholdLinking.Intensity);
        //    LineSegment2D[] lines = cannyEdges.HoughLinesBinary(
        //        1, //Distance resolution in pixel-related units
        //        Math.PI / 45.0, //Angle resolution measured in radians.
        //        20, //threshold
        //        30, //min Line width
        //        10 //gap between lines
        //        )[0]; //Get the lines from the first channel

        //    #region Find triangles and rectangles
        //    List<Triangle2DF> triangleList = new List<Triangle2DF>();
        //    List<MCvBox2D> boxList = new List<MCvBox2D>();

        //    using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation
        //        for (Contour<Point> contours = cannyEdges.FindContours(); contours != null; contours = contours.HNext)
        //        {
        //            Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);

        //            if (contours.Area > 100) //only consider contours with area greater than 250
        //            {
        //                if (currentContour.Total == 3) //The contour has 3 vertices, it is a triangle
        //                {
        //                    Point[] pts = currentContour.ToArray();
        //                    triangleList.Add(new Triangle2DF(
        //                       pts[0],
        //                       pts[1],
        //                       pts[2]
        //                       ));
        //                }
        //                else if (currentContour.Total == 4) //The contour has 4 vertices.
        //                {
        //                    #region determine if all the angles in the contour are within the range of [80, 100] degree
        //                    bool isRectangle = true;
        //                    Point[] pts = currentContour.ToArray();
        //                    LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

        //                    for (int i = 0; i < edges.Length; i++)
        //                    {
        //                        double angle = Math.Abs(
        //                           edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
        //                        if (angle < 80 || angle > 100)
        //                        {
        //                            isRectangle = false;
        //                            break;
        //                        }
        //                    }
        //                    #endregion

        //                    if (isRectangle) boxList.Add(currentContour.GetMinAreaRect());
        //                }
        //            }

        //            #region draw triangles and rectangles
        //            Image<Bgr, Byte> triangleRectangleImage = orginalImage.CopyBlank();
        //            foreach (Triangle2DF triangle in triangleList)
        //                triangleRectangleImage.Draw(triangle, new Bgr(Color.DarkBlue), 2);
        //            foreach (MCvBox2D box in boxList)
        //                triangleRectangleImage.Draw(box, new Bgr(Color.DarkOrange), 2);
        //            triangleRectangleImageBox.Image = triangleRectangleImage.Bitmap;
        //            #endregion

        //            #region draw circles
        //            Image<Bgr, Byte> circleImage = orginalImage.CopyBlank();
        //            foreach (CircleF circle in circles)
        //                circleImage.Draw(circle, new Bgr(Color.Brown), 2);
        //            circleImageBox.Image = circleImage.Bitmap;
        //            #endregion

        //            #region draw lines
        //            Image<Bgr, Byte> lineImage = orginalImage.CopyBlank();
        //            foreach (LineSegment2D line in lines)
        //                lineImage.Draw(line, new Bgr(Color.Green), 2);
        //            lineImageBox.Image = lineImage.Bitmap;
        //            #endregion


        //        }
        //    #endregion




        //}

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





    }
}





