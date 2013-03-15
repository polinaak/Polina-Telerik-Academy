using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Figures
{
    abstract class Shape
    {
        //Fields
        protected double width { get; set; }
        protected double height { get; set; }

        //Constructor
        protected Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public abstract double CalculateSurface();
    }
}
