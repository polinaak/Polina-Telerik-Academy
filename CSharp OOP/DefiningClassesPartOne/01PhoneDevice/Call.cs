using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01PhoneDevice
{
   public class Call
    {
       //Fields
        private readonly DateTime date;
        private readonly string time;
        private readonly string dialedNumber;
        private readonly uint duration;

       //Constructor
        public Call(string dialedNumber, uint duration)
        {
            this.date = DateTime.Now;
            this.time = date.Hour + ":" + date.Minute + ":" + date.Second;
            this.dialedNumber = dialedNumber;
            this.duration = duration;
        }

       //Properties
        public uint Duration
        {
            get
            {
                return this.duration;
            }
        }
        public string DialedNumber
        {
            get
            {
                return this.dialedNumber;
            }
        }
        public string Time
        {
            get
            {
                return this.time;
            }
        }
        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }

        public override string ToString()
        {
            return string.Format("The call is made at {0}, in time: {1}, the duration of call was {2} and the dialed number was: {3}",
                this.date, this.time, this.duration, this.dialedNumber);
        }

    }
}
