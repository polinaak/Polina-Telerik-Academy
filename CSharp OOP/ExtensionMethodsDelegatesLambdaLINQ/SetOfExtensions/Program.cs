using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

namespace _02SetOfExtensions
{
    class Program
    {
        static void Main()
        {
            int[] numbers = new int[4];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            
            //tests extensions methods
            Console.WriteLine("Average: "+ numbers.Average());
            Console.WriteLine("Sum: " + numbers.Sum());
            Console.WriteLine("Min: " + numbers.Min());
            Console.WriteLine("Max: " + numbers.Max());
            Console.WriteLine("Product: " + numbers.Product());
        }
    }
}
