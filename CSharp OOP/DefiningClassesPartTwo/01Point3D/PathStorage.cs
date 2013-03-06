using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01Point3D
{
    static class PathStorage
    {
        public static void Save(List<Point3D> points)
        {
            using (StreamWriter writer = new StreamWriter("../../savePath.txt"))
            {
                foreach (var point in points)
                {
                    writer.WriteLine(point);
                }
            }
        }

        public static List<Point3D> Load()
        {
            using (StreamReader reader = new StreamReader("../../loadPath.txt"))
            {
                string line = reader.ReadLine();
                List<Point3D> loadPath = new List<Point3D>();
                while(line != null)
                {                    
                    string[] splitLine = line.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                    int xCoord = int.Parse(splitLine[0]);
                    int yCoord = int.Parse(splitLine[1]);
                    int zCoord = int.Parse(splitLine[2]);
                    Point3D point = new Point3D(xCoord, yCoord, zCoord);
                    loadPath.Add(point);
                    line = reader.ReadLine();
                }
                return loadPath;
            }
        }
    }
}
