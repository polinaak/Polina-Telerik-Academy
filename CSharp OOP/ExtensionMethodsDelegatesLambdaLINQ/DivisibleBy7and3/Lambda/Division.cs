using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06DivisibleBy3and7
{
    public class Division
    {
        public static void DivideBy7and3Lambda(List<int> numbers)
        {
            List<int> divisible = numbers.FindAll(x => (x % 21) == 0);
            Console.WriteLine("Numbers divisible by 3 and 7 with Lambda expression:");
            foreach (var number in divisible)
            {
                Console.WriteLine(number);
            }
        }

        public void DivideBy7and3LINQ(List<int> numbers)
        {
            var divisible =
                from number in numbers
                where number % 21 == 0
                select number;
            Console.WriteLine("Numbers divisible by 3 and 7 with LINQ:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
