using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Point3D
{
    static class DistanceBetweenTwoPoints
    {
        static public double CalculateDistance(Point3D point1, Point3D point2)
        {
            double result = 0;
            result = Math.Sqrt((point1.x - point2.x) * (point1.x - point2.x) + (point1.y - point2.y)*(point1.y - point2.y) + (point1.z - point2.z)*(point1.z - point2.z));
            return result;
        }
    }
}
