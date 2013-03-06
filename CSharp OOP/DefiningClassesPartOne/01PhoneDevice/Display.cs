using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01PhoneDevice
{
    class Display
    {
        //Fields
        private double size;
        private int colors;

        //Properties
        public double Size
        {
            get { return this.size; }
            set 
            {
                if (size < 0)
                {
                    throw new ArgumentException("The size can not be negative! ");
                }
                this.size = value;
            }
        }
        public int Colors
        {
            get { return this.colors; }
            set 
            {
                if (colors < 0)
                {
                    throw new ArgumentException("The count of colors can not be negative!");
                }
                this.colors = value;
            }
        }

        //Constructors
        public Display()
        { }
        public Display(double size)
            : this()
        {
            this.size = size;
        }
    }
}
