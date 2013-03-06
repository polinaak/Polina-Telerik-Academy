using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Point3D
{
    class Path
    {
        List<Point3D> path = new List<Point3D>();

        public Path(params Point3D[] point)
        {
            for (int i = 0; i < point.Length; i++)
            {
                this.path.Add(point[i]);
            }
        }

        public void AddPoint(Point3D point)
        {
            this.path.Add(point);
        }

        public void Clear()
        {
            this.path.Clear();
        }
    }
}
