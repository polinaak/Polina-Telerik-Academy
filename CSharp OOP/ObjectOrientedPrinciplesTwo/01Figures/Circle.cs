using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Figures
{
    class Circle : Shape
    {
        public Circle(double radius)
            : this(radius, radius)
        { }
        private Circle(double radius, double radius2)
            : base(radius, radius2)
        { }

        public double Radius
        {
            get { return this.width; }
            set 
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("The radius must be greater than 0!");
                }
            }
        }

        public override double CalculateSurface()
        {
            return  this.width*this.width* Math.PI;
        }
    }
}
