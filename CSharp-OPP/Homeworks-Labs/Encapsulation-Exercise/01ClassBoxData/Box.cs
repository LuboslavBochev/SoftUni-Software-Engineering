using System;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value > 0)
                {
                    this.length = value;
                }
                else throw new ArgumentException("Length cannot be zero or negative.");
            }
        }

        private double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else throw new ArgumentException("Width cannot be zero or negative.");
            }
        }

        private double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else throw new ArgumentException("Height cannot be zero or negative.");
            }
        }

        public double SurfaceArea(double length, double width, double height)
        {
            return (2 * this.length * this.Width) + (2 * this.length * this.height) + (2 * this.width * this.height);
        }

        public double LateralSurfaceArea(double length, double width, double height)
        {
            return (2 * this.length * this.height) + (2 * this.width * this.height);
        }

        public double Volume(double length, double width, double height)
        {
            return this.length * this.width * this.height;
        }
    }
}
