using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSignRecognition
{

    public class ImageInfo : IEquatable<ImageInfo>
    {
        public Image<Gray, Byte> Image { get; set; }
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }

        public string OriginalFileName { get; set; }

        public ImageInfo(Image<Gray, Byte> image, double r, double g, double b, string filename)
        {
            Image = image;
            R = r;
            G = g;
            B = b;
            OriginalFileName = filename;
        }

        public bool Equals(ImageInfo obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (this.Image.Rows != obj.Image.Rows || this.Image.Cols != obj.Image.Cols)
            {
                return false;
            }

            for (int i = 0; i < this.Image.Rows; i++)
            {
                for (int j = 0; j < this.Image.Cols; j++)
                {
                    if (this.Image[i, j].Intensity != obj.Image[i, j].Intensity)
                    {
                        return false;
                    }
                }
            }

            return
                this.R.Equals(obj.R) &&
                this.G.Equals(obj.G) &&
                this.B.Equals(obj.B);
        }

        public override int GetHashCode()
        {
            int imgHashCode = 0;

            for (int i = 0; i < this.Image.Rows; i++)
            {
                for (int j = 0; j < this.Image.Cols; j++)
                {
                    imgHashCode ^= (int)this.Image[i, j].Intensity;
                }
            }


            //Calculate the hash code for the GPOPolicy.  
            return this.R.GetHashCode() ^
                this.G.GetHashCode() ^
                this.B.GetHashCode() ^
                imgHashCode;

        }

    }
}
