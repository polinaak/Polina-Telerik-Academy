using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Define a class that holds information about a mobile phone device:
//model, manufacturer, price, owner, battery characteristics 
//(model, hours idle and hours talk) and display characteristics 
// (size and number of colors). Define 3 separate classes (class GSM holding instances of the classes Battery and Display).

namespace _01PhoneDevice
{
    class GSMTest
    {
        static void Main()
        {
            Console.WriteLine("Enter the size of the array:");
            int size = int.Parse(Console.ReadLine());
            GSM[] testArr = new GSM[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter manufacturer:");
                string manufacturer = Console.ReadLine();
                Console.WriteLine("Enter model");
                string model = Console.ReadLine();
                Console.WriteLine("Enter price:");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter owner:");
                string owner = Console.ReadLine();
                testArr[i] = new GSM(manufacturer, model, price, owner);
                Console.WriteLine(testArr[i]);
                Console.WriteLine();
            }
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
