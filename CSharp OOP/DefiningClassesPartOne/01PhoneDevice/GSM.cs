using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01PhoneDevice
{
    public class GSM
    {
        //Fields
        private string model = null;
        private string manufacturer = null;
        private decimal price;
        private string owner = null;
        private static GSM iPhone4S = new GSM("IPhone4S", "Apple");

        //Instances
        Battery battery = new Battery();
        Display display = new Display();

        private List<Call> historyCalls = new List<Call>();

        //Properties
        static public GSM IPhone4S
        {
            get { return iPhone4S; }
        }
        public string Model
        {
            get { return this.model; }
            set 
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("model can not be empty");
                }
                this.model = value;
            }

        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("manufacturer can not be empty");
                }
                this.manufacturer = value;
            }
        }
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("price can not be negative");
                }
                this.price = value;
            }
        }
         public string Owner
        {
            get { return this.owner; }
            set
            {
                foreach (char ch in value)
                {
                    if (!IsLetterAllowedInNames(ch))
                    {
                        throw new ArgumentException("Invalid name! Use only letters, space and hyphen");
                    }
                }
                this.owner = value;
            }
        }
        public List<Call> HistoryCalls
        {
            get { return this.historyCalls; }
        }

        //Constructors
        public GSM(string manufacturer, string model)
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }
        public GSM(string manufacturer, string model, decimal price)
            : this(manufacturer, model)
        {
            this.price = price;
        }
        public GSM(string manufacturer, string model, string owner)
            :this(manufacturer, model)
        {
            this.owner = owner;
        }
        public GSM(string manufacturer, string model, decimal price, string owner)
            : this(manufacturer, model, price)
        {
            this.owner = owner;
        }

        //Methods
        public override string ToString()
        {
            return string.Format("THe phone device is model: {0}, the manufacturer is {1}, its price is {2} and its owner is {3} ",
                this.model, this.manufacturer, this.price, this.owner);
        }
        private bool IsLetterAllowedInNames(char ch)
        {
            bool isAllowed =
                char.IsLetter(ch) || ch == '-' || ch == ' ';
            return isAllowed;
        }
        public void AddCall(string dialedNumber, uint duration )
        {
            Call addCall = new Call(dialedNumber, duration);
            this.historyCalls.Add(addCall);
        }
        public void RemovaCall(int index)
        {
           this. HistoryCalls.RemoveAt(index);
        }
        public void ClearCalls()
        {
            this.HistoryCalls.Clear();
        }
        public decimal CalculatePrice(decimal pricePerMinute)
        {
            ulong minutes = 0;
            foreach (var call in historyCalls)
            {
                minutes += (ulong)call.Duration;
            }
            return minutes * pricePerMinute;
        }
        public void GetCalls()
        {
             if (historyCalls.Count == 0)
                {
                    Console.WriteLine("There are no calls.");
                }
             else
             {
                foreach (var call in historyCalls)
                {
                Console.WriteLine(call);
                }
             }
        }
        public void RemoveLongestCall()
        {
            this.historyCalls.RemoveAll(x => x.Duration == this.historyCalls.Max(y => y.Duration));
        }

    }
}
