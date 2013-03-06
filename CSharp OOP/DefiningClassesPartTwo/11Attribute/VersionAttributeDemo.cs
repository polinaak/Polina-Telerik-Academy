using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a [Version] attribute that can be applied to structures, classes, interfaces,
//enumerations and methods and holds a version in the format major.minor (e.g. 2.11).
//Apply the version attribute to a sample class and display its version at runtime.

namespace _11Attribute
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class
        | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]

    public class VersionAttribute : System.Attribute
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }

        //Constructor
        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }
    }
    [VersionAttribute(2,10)]
    class VersionAttributeDemo
    {
        static void Main()
        {
            Type type = typeof(VersionAttributeDemo);
            object[] attr = type.GetCustomAttributes(false);
            foreach (VersionAttribute version in attr)
            {
                Console.WriteLine("Version {0}.{1}", version.Major, version.Minor );
            }
            Console.WriteLine();
        }
    }
}
