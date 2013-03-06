using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _01PhoneDevice
{
    class CallTest
    {
        static void Main(string[] args)
        {
            GSM testPhone = new GSM("Sony Experia", "Sony");

            testPhone.AddCall("0883456789", 3);
            testPhone.AddCall("0889454322", 2);
            testPhone.AddCall("0888344384", 8);

            testPhone.GetCalls();
            Console.WriteLine("The total price of the calls in the history is:");
            Console.WriteLine(testPhone.CalculatePrice(0.37m)); 
            testPhone.RemoveLongestCall();
            Console.WriteLine("The total price of these calls:");
            testPhone.GetCalls();
            Console.WriteLine("is:");
            Console.WriteLine(testPhone.CalculatePrice(0.37m)); 
            testPhone.ClearCalls();
            Console.WriteLine("After clear history there are calls:" );
            testPhone.GetCalls();
        }
    }
}
