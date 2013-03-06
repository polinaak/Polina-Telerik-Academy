using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01PhoneDevice
{
    public enum BatteryType 
    { 
        Li_lon, NiMH, NiCD 
    }
    class Battery
    {
        //Fields
        private BatteryType type;
        private string model = null;
        private int hoursIdle;
        private int hoursTalk;

        //Constructors
        public Battery()
        { }
        public Battery(string model)
            : this()
        {
            this.model = model;
        }

        //Properties
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int HoursIdle
        {
            get { return this.HoursIdle; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("The hours idle can not be negative!");
                }
                this.hoursIdle = value;
            }
        }
        public int HoursTalk
        {
            get { return this.hoursTalk; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("The hours talk can not be negative!");
                }
                this.hoursTalk = value;
            }
        }

    }
}
