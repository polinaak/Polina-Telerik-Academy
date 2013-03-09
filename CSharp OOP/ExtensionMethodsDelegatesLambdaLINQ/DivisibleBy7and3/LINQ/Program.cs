using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06LINQDivision
{
    class Program
    {
        static void Main()
        {
            int[] numbers = new int[]{ 2, 23, 3, 21, 7, 42, 456 };
            var divisible =
                from number in numbers
                where (number % 21) == 0
                select number;
            Console.WriteLine("Numbers divisible by 3 and 7 with LINQ:");
            foreach (var number in divisible)
            {
                Console.WriteLine(number);
            }
        }
    }
}
