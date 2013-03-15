using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Define abstract class Shape with only one abstract method CalculateSurface()
//and fields width and height. Define two new classes Triangle and Rectangle
//that implement the virtual method and return the surface of the figure 
//(height*width for rectangle and height*width/2 for triangle). Define class 
//Circle and suitable constructor so that at initialization height must be kept
//equal to width and implement the CalculateSurface() method. Write a program that 
//tests the behavior of  the CalculateSurface() method for different shapes
//(Circle, Rectangle, Triangle) stored in an array.

namespace _01Figures
{
    class Test
    {
        static void Main()
        {
            Shape rectangle = new Rectangle(3, 6);
            Console.WriteLine("The surface of rectangle is: " + rectangle.CalculateSurface());
            Shape circle = new Circle(3);
            Console.WriteLine("The surface of circle is: " + circle.CalculateSurface());
            Shape triangle = new Triangle(3, 4);
            Console.WriteLine("The surface of triangle is: " + triangle.CalculateSurface());
            Shape[] figures = { rectangle, circle, triangle };
            Console.WriteLine();
            Console.WriteLine("Figures in array:");
            foreach (var figure in figures)
            {
                Console.WriteLine(figure.CalculateSurface());
            }
            
        }
    }
}
