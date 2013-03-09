using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Implement an extension method Substring(int index, int length) for the class StringBuilder
//that returns new StringBuilder and has the same functionality as Substring in the class String.

namespace _01ExtensionMethodSubstring
{
    class Program
    {
        static void Main()
        {
            StringBuilder input = new StringBuilder();
            input.Append("Hello extensions methods!");
            input = input.Substring(6, 10);
            Console.WriteLine(input.ToString());
        }
    }
}
