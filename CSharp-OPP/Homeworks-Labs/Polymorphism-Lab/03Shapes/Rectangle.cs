using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Height { get; private set; }

        public int Width { get; private set; }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return this.Height * 2 + this.Width * 2;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
