using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that prints from given array of integers all numbers that are 
//divisible by 7 and 3. Use the built-in extension methods and lambda expressions.
//Rewrite the same with LINQ.

namespace _06DivisibleBy3and7
{
    class Program
    {
        static void Main()
        {
            int[] numbers = new int[]{ 2, 23, 3, 21, 7, 42, 456 };
            var divisible = numbers.Where(x => (x % 21) == 0);
            Console.WriteLine("Numbers divisible by 3 and 7 with Lambda expression:");
            foreach (var number in divisible)
            {
                Console.WriteLine(number);
            }
        }
    }
}
