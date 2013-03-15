using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Figures
{
    class Rectangle : Shape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        { }

        public double Width
        {
            get { return this.width;  }
            set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("The width must be greater than 0!");
                }
            }
        }
        public double Height
        {
            get { return this.height;  }
            set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("The height must be greater than 0!");
                }
            }
        }

        public override double CalculateSurface()
        {
            return width * height;
        }


    }
}
