using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Point3D
{
    class Program
    {
        static void Main()
        {
            Point3D pointA = new Point3D();
            Point3D pointB = new Point3D(1, 1, 1);
            double distance = 0;
            Console.WriteLine(pointB);
            Console.WriteLine(Point3D.pointZero);

            distance = DistanceBetweenTwoPoints.CalculateDistance(pointA, pointB);
            Console.WriteLine("The distance between two points is: " + distance);
        }
    }
}
