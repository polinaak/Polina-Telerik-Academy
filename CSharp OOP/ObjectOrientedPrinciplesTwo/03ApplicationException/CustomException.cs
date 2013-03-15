using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03ApplicationException
{
    class CustomException
    {
        const int MaxValue = 100;
        const int MinValue = 0;

        static void Main(string[] args)
        {

            //Test for int
            Console.WriteLine("Enter number in range [ 0 : 100 ]");
            int number = int.Parse(Console.ReadLine());
            if (number > MaxValue || number < MinValue)
            {
                throw new InvalidRangeException<int>("Number is out of range!", MinValue, MaxValue);
            }
            else
            {
                Console.WriteLine("Correct number!");
            }

            //Test for DateTime
            Console.WriteLine("Enter date in range [1.1.1980 … 31.12.2013]:");
            string date = Console.ReadLine();
            DateTime testDate = DateTime.Parse(date);
            DateTime start = new DateTime(1980, 1, 1);
            DateTime end = new DateTime(2013, 12, 31);
            if (testDate > end || testDate < start)
            {
                throw new InvalidRangeException<DateTime>("The date is out of range!", start, end);
            }
            else
            {
                Console.WriteLine("Correct date!");
            }
        }
    }
}
