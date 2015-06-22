using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.IO;

namespace TrafficSignRecognition
{
    public partial class Form1 : Form
    {
        private List<ImageInfo> imagesToAnalyze;
        private Image<Bgr, Byte> originalImage;
        private Image<Bgr, Byte> convertedImage;
        private string imageFileName;
        private const int gaussianKernelSizeDefault = Preprocessing.GaussianBlurParameters.Defaults.kernelSize;
        private const int apertureSizeDefault = Preprocessing.FindEdgesCannyParameters.Defaults.apertureSize;
        private const double threshCanny1ValueDefault = Preprocessing.FindEdgesCannyParameters.Defaults.thresh;
        private const double threshCanny2ValueDefault = Preprocessing.FindEdgesCannyParameters.Defaults.threshLinking;
        private const double threshCircle1ValueDefault = Preprocessing.FindCirclesParameters.Defaults.thresholdMax;
        private const double accumulatorCircleNumericValueDefault = Preprocessing.FindCirclesParameters.Defaults.accumulator;
        private const double resolutionCircleValueDefault = Preprocessing.FindCirclesParameters.Defaults.resolution;
        private const double minDistCircleValueDefault = Preprocessing.FindCirclesParameters.Defaults.minDistance;
        private const double minRadCircleNumericValueDefault = Preprocessing.FindCirclesParameters.Defaults.minRadius;
        private const double maxRadCirclNumericValueDefault = Preprocessing.FindCirclesParameters.Defaults.maxRadius;
        private const double accuracyTriRecNumericValueDefault = Preprocessing.FindTrianglesAndRectanglesParameters.Defaults.accuracy;
        private const double minPoleTriRecNumericValueDefault = Preprocessing.FindTrianglesAndRectanglesParameters.Defaults.minArea;
        private const double minRectAngleTriRecNumericValueDefault = Preprocessing.FindTrianglesAndRectanglesParameters.Defaults.minRectangleAngle;
        private const double maxRectAngleTriRecNumericValueDefault = Preprocessing.FindTrianglesAndRectanglesParameters.Defaults.maxRectangleAngle;


        public Form1()
        {
            InitializeComponent();
            InitializeGaussianKernelNumeric();
            InitializeCannyParameters();
            InitializeCircleParameters();
            InitializeTriRecParameters();
            imagesToAnalyze = new List<ImageInfo>();
        }

        private void InitializeGaussianKernelNumeric()
        {
            gaussianKernelNumeric.Value = gaussianKernelSizeDefault;
            gaussianKernelNumeric.Maximum = 101;
            gaussianKernelNumeric.Minimum = 1;
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


            resolutionCricleNumeric.Value = (decimal)resolutionCircleValueDefault;
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

        private Preprocessing.PreprocessImageParameters GetUserSelectedParameters()
        {
            return new Preprocessing.PreprocessImageParameters()
            {
                blurParameters = new Preprocessing.GaussianBlurParameters()
                {
                    kernelSize = (int)gaussianKernelNumeric.Value
                },
                circleParameters = new Preprocessing.FindCirclesParameters()
                {
                    accumulator = (int)accumulatorCircleNumeric.Value,
                    maxRadius = (int)maxRadCirclNumeric.Value,
                    minDistance = (double)minDistCircleNumeric.Value,
                    minRadius = (int)minRadCircleNumeric.Value,
                    resolution = (double)resolutionCricleNumeric.Value,
                    thresholdMax = (int)threshCircle1Numeric.Value
                },
                edgesParameters = new Preprocessing.FindEdgesCannyParameters()
                {
                    apertureSize = (int)apertureNumeric.Value,
                    thresh = (double)threshCanny1Numeric.Value,
                    threshLinking = (double)threshCanny2Numeric.Value
                },
                triangleRectangleParameters = new Preprocessing.FindTrianglesAndRectanglesParameters()
                {
                    accuracy = (double)accuracyTriRecNumeric.Value,
                    maxRectangleAngle = (double)maxRectAngleTriRecNumeric.Value,
                    minArea = (double)minPoleTriRecNumeric.Value,
                    minRectangleAngle = (double)minRectAngleTriRecNumeric.Value
                }
            };
        }
        
        private void loadImageBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog Openfile = new OpenFileDialog())
            {
                if (Openfile.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Image<Bgr, byte>(Openfile.FileName);
                    imageFileName = Openfile.FileName;
                    convertedImage = new Image<Bgr, byte>(originalImage.Bitmap);
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
            var parameters = GetUserSelectedParameters().blurParameters;

            convertedImage = Preprocessing.gaussianBlur(parameters, convertedImage);

            imageBox.Image = convertedImage.Bitmap;
        }
        private void cannyBtn_Click(object sender, EventArgs e)
        {
            var parameters = GetUserSelectedParameters().edgesParameters;

            convertedImage = Preprocessing.findEdgesCanny(parameters, convertedImage);

            imageBox.Image = convertedImage.Bitmap;

        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            convertedImage = new Image<Bgr, byte>(originalImage.Bitmap);
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
            var parameters = GetUserSelectedParameters().circleParameters;

            imageBox.Image = Preprocessing.findCircles(parameters, convertedImage, originalImage, imageFileName, imagesToAnalyze);
        }
        
        private void threshCanny2Numeric_ValueChanged(object sender, EventArgs e)
        {
            threshCircle1Numeric.Value = ((NumericUpDown)sender).Value;
        }

        private void triRecBtn_Click(object sender, EventArgs e)
        {
            var parameters = GetUserSelectedParameters().triangleRectangleParameters;

            imageBox.Image = Preprocessing.findTrianglesAndRectangles(parameters, convertedImage, originalImage, imageFileName, imagesToAnalyze);
        }
        
        private void saveImgBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Jpeg Image|*.jpg";
            saveFileDialog.Title = "Save image to file";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                imageBox.Image.Save(saveFileDialog.FileName);
            }
        }

        private void preprocessBatchBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select image files to preprocess";
            openFileDialog.Multiselect = true;
            openFileDialog.ShowDialog();

            foreach (var filename in openFileDialog.FileNames)
            {
                var imagesToAnalyze = new List<ImageInfo>();
                var parameters = GetUserSelectedParameters();
                
                var blurKernelSizes = new[] {3,5,7,9};
                foreach(var blurKernelSize in blurKernelSizes){
                    parameters.blurParameters.kernelSize = blurKernelSize;
                    Preprocessing.preprocessImage(filename, parameters, imagesToAnalyze);
                }

                imagesToAnalyze = imagesToAnalyze.Distinct().ToList();

                SaveImageInfo(imagesToAnalyze);
            }
        }

        private void SaveImageInfo(List<ImageInfo> imagesToAnalyze)
        {
            foreach (var im in imagesToAnalyze)
            {
                //imageBox.Image = im.Image.ToBitmap();

                string dir = Path.GetDirectoryName(im.OriginalFileName) + "\\processed";

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                im.Image.Save(
                    dir + "\\" +
                    imagesToAnalyze.IndexOf(im) + "_" +
                    Path.GetFileNameWithoutExtension(im.OriginalFileName) + "_" +
                    im.R + "_" + im.G + "_" + im.B +
                    ".bmp");
            }
        }
    }

}





