using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSignRecognition
{
    /// <summary>
    /// Klasa zajmująca się wstępnym przetwarzaniem obrazu.
    /// </summary>
    public class Preprocessing
    {
        public class FindTrianglesAndRectanglesParameters
        {
            public double accuracy;
            public double minArea;
            public double minRectangleAngle;
            public double maxRectangleAngle;

            public static class Defaults
            {
                public const double accuracy = 0.05;
                public const double maxRectangleAngle = 100;
                public const double minArea = 400;
                public const double minRectangleAngle = 80;
            }

            public FindTrianglesAndRectanglesParameters()
            {
                accuracy = Defaults.accuracy;
                minArea = Defaults.minArea;
                minRectangleAngle = Defaults.minRectangleAngle;
                maxRectangleAngle = Defaults.maxRectangleAngle;
            }
        }

        public class FindCirclesParameters
        {
            public int thresholdMax;
            public int accumulator;
            public double resolution;
            public double minDistance;
            public int minRadius;
            public int maxRadius;

            public static class Defaults
            {
                public const int thresholdMax = 80;
                public const int accumulator = 160;
                public const double resolution = 2;
                public const double minDistance = 30;
                public const int minRadius = 30;
                public const int maxRadius = 100;
            }

            public FindCirclesParameters()
            {
                thresholdMax = Defaults.thresholdMax;
                accumulator = Defaults.accumulator;
                resolution = Defaults.resolution;
                minDistance = Defaults.minDistance;
                minRadius = Defaults.minRadius;
                maxRadius = Defaults.maxRadius;
            }
        }

        public class FindEdgesCannyParameters
        {
            public double thresh;
            public double threshLinking;
            public int apertureSize;

            public static class Defaults
            {
                public const double thresh = 40;
                public const int apertureSize = 3;
                public const double threshLinking = 80;
            };

            public FindEdgesCannyParameters()
            {
                thresh = Defaults.thresh;
                threshLinking = Defaults.threshLinking;
                apertureSize = Defaults.apertureSize;
            }
        }

        public class GaussianBlurParameters
        {
            public int kernelSize;

            public static class Defaults
            {
                public const int kernelSize = 9;
            };

            public GaussianBlurParameters()
            {
                kernelSize = Defaults.kernelSize;
            }

        }

        public class PreprocessImageParameters
        {
            public FindCirclesParameters circleParameters;
            public FindEdgesCannyParameters edgesParameters;
            public FindTrianglesAndRectanglesParameters triangleRectangleParameters;
            public GaussianBlurParameters blurParameters;
        }

        public static Image<Bgr, byte> findEdgesCanny(FindEdgesCannyParameters parameters, Image<Bgr, byte> image)
        {
            try
            {
                return new Image<Bgr, byte>(image.Canny(parameters.thresh, parameters.threshLinking, parameters.apertureSize).Bitmap);
            }

            catch (Emgu.CV.Util.CvException ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static Image<Bgr, byte> gaussianBlur(GaussianBlurParameters parameters, Image<Bgr, byte> image)
        {
            try
            {
                return image.SmoothGaussian(parameters.kernelSize);
            }
            catch (Emgu.CV.Util.CvException ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static Bitmap findTrianglesAndRectangles(FindTrianglesAndRectanglesParameters parameters, Image<Bgr, byte> inputImage, Image<Bgr, byte> originalImage, string inputImageName, IList<ImageInfo> imagesToAnalyze)
        {
            try
            {
                using (MemStorage storage = new MemStorage())
                {
                    
                    Image<Gray, Byte> grayscaleImage = inputImage.Convert<Gray, Byte>();

                    Image<Bgr, Byte> toReturn = new Image<Bgr, byte>(originalImage.Bitmap);

                    for (
                       Contour<Point> contours = grayscaleImage.FindContours(
                          Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                          Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST,
                          storage);
                       contours != null;
                       contours = contours.HNext)
                    {
                        Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * parameters.accuracy, storage);

                        List<Triangle2DF> triangleList = new List<Triangle2DF>();
                        List<MCvBox2D> boxList = new List<MCvBox2D>();

                        if (currentContour.Area > parameters.minArea)
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
                                    if (angle < parameters.minRectangleAngle || angle > parameters.maxRectangleAngle)
                                    {
                                        isRectangle = false;
                                        break;
                                    }
                                }

                                if (isRectangle) boxList.Add(currentContour.GetMinAreaRect());
                            }
                        }

                        foreach (var t in triangleList)
                        {
                            float[] xTable = new float[3] { t.V0.X, t.V1.X, t.V2.X };
                            float[] yTable = new float[3] { t.V0.Y, t.V1.Y, t.V2.Y };
                            int minX = (int)Math.Floor(xTable.Min());
                            int maxX = (int)Math.Floor(xTable.Max());
                            int minY = (int)Math.Floor(yTable.Min());
                            int maxY = (int)Math.Floor(yTable.Max());
                            Point point = new Point(minX, minY);
                            int lengthX = maxX - minX;
                            int lengthY = maxY - minY;
                            var imageToAdd = inputImage.GetSubRect(new Rectangle(point, new Size(maxX - minX, maxY - minY)));
                            var resized = imageToAdd.Resize(30, 30, Emgu.CV.CvEnum.INTER.CV_INTER_NN, false);

                            var originalResized = originalImage.GetSubRect(new Rectangle(point, new Size(maxX - minX, maxY - minY)))
                                .Resize(30, 30, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, false);
                            double r = 0;
                            double g = 0;
                            double b = 0;
                            for (int i = 0; i < 30; i++)
                            {
                                for (int j = 0; j < 30; j++)
                                {
                                    r += originalResized[i, j].Red;
                                    g += originalResized[i, j].Green;
                                    b += originalResized[i, j].Blue;
                                }
                            }
                            imagesToAnalyze.Add(new ImageInfo(resized.Convert<Gray, byte>(), r / 900, g / 900, b / 900, inputImageName));
                            toReturn.Draw(t, new Bgr(Color.Lime), 4);
                        }

                        foreach (var rec in boxList)
                        {
                            int xLength = (int)Math.Ceiling(rec.size.Width); // gora, zeby wziac wiecej
                            int yLength = (int)Math.Ceiling(rec.size.Height); // gora, zeby wziac wiecej
                            int x = (int)Math.Floor(rec.center.X) - xLength / 2; // podloga, zeby wziac szerszy obszar
                            int y = (int)Math.Floor(rec.center.Y) - yLength / 2; // podloga, zeby wziac szerszy obszar
                            Point point = new Point(x, y);
                            var imageToAdd = inputImage.GetSubRect(new Rectangle(point, new Size(xLength, yLength)));
                            var resized = imageToAdd.Resize(30, 30, Emgu.CV.CvEnum.INTER.CV_INTER_NN, false);
                            var originalResized = originalImage.GetSubRect(new Rectangle(point, new Size(xLength, yLength)))
                                .Resize(30, 30, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, false);
                            double r = 0;
                            double g = 0;
                            double b = 0;
                            for (int i = 0; i < 30; i++)
                            {
                                for (int j = 0; j < 30; j++)
                                {
                                    r += originalResized[i, j].Red;
                                    g += originalResized[i, j].Green;
                                    b += originalResized[i, j].Blue;
                                }
                            }
                            imagesToAnalyze.Add(new ImageInfo(resized.Convert<Gray, byte>(), r / 900, g / 900, b / 900, inputImageName));
                            toReturn.Draw(rec, new Bgr(Color.Aquamarine), 4);
                        }
                    }
                    return toReturn.Bitmap;
                }
            }
            catch (Emgu.CV.Util.CvException ex)
            {
                // MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static Bitmap findCircles(FindCirclesParameters parameters, Image<Bgr, byte> inputImage, Image<Bgr, byte> originalImage, string inputImageName, IList<ImageInfo> imagesToAnalyze)
        {
            try
            {
                int gray1 = parameters.thresholdMax;
                int gray2 = parameters.accumulator;
                CircleF[] circles = inputImage.HoughCircles(
                new Bgr(gray1, gray1, gray1),
                new Bgr(gray2, gray2, gray2),
                parameters.resolution, //Resolution of the accumulator used to detect centers of the circles
                parameters.minDistance, //min distance 
                parameters.minRadius, //min radius
                parameters.maxRadius //max radius
                )[0]; //Get the circles from the first channel

                Image<Bgr, Byte> circleImage = new Image<Bgr, byte>(originalImage.Bitmap);

                foreach (CircleF circle in circles)
                {
                    int radius = (int)Math.Ceiling(circle.Radius); // gora, zeby wziac wiecej
                    int x = (int)Math.Floor(circle.Center.X) - radius; // podloga, zeby wziac szerszy obszar
                    int y = (int)Math.Floor(circle.Center.Y) - radius; // podloga, zeby wziac szerszy obszar
                    Point point = new Point(x, y);
                    var imageToAdd = inputImage.GetSubRect(new Rectangle(point, new Size(radius * 2, radius * 2)));
                    var resized = imageToAdd.Resize(30, 30, Emgu.CV.CvEnum.INTER.CV_INTER_NN, false);
                    var originalResized = originalImage.GetSubRect(new Rectangle(point, new Size(radius * 2, radius * 2)))
                                .Resize(30, 30, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, false);
                    double r = 0;
                    double g = 0;
                    double b = 0;
                    for (int i = 0; i < 30; i++)
                    {
                        for (int j = 0; j < 30; j++)
                        {
                            r += originalResized[i, j].Red;
                            g += originalResized[i, j].Green;
                            b += originalResized[i, j].Blue;
                        }
                    }
                    imagesToAnalyze.Add(new ImageInfo(resized.Convert<Gray, byte>(), r / 900, g / 900, b / 900, inputImageName));
                    circleImage.Draw(circle, new Bgr(Color.Lime), 4);
                }

                return circleImage.ToBitmap();
            }
            catch (Emgu.CV.Util.CvException ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Do listy imagesToAnalyze dodane zostaną wszystkie znalezione interesujące nas obszary
        /// </summary>
        public static void preprocessImage(string filename, PreprocessImageParameters parameters, IList<ImageInfo> imagesToAnalyze)
        {
            var originalImage = new Image<Bgr, byte>(filename);
            var convertedImage = new Image<Bgr, byte>(originalImage.Bitmap);

            // grayscale
            Image<Gray, Byte> grayImage = convertedImage.Convert<Gray, Byte>();
            convertedImage = new Image<Bgr, byte>(grayImage.Bitmap);

            // blur
            convertedImage = gaussianBlur(parameters.blurParameters, convertedImage);

            // edge detection
            convertedImage = findEdgesCanny(parameters.edgesParameters, convertedImage);

            // finding shapes
            findCircles(parameters.circleParameters, convertedImage, originalImage, filename, imagesToAnalyze);
            findTrianglesAndRectangles(parameters.triangleRectangleParameters, convertedImage, originalImage, filename, imagesToAnalyze);
        }
    }
}
