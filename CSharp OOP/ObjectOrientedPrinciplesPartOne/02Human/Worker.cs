using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Human
{
    class Worker : Human
    {
        //Fields
        private decimal weekSalary;
        private int workHoursPerDay;

        //Constructor
        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
        :base(firstName, lastName)
        {
            this.weekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
        }

        //Properties
        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (weekSalary < 100)
                {
                    throw new ArgumentException("This is not a salary!");
                }
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (workHoursPerDay < 4 && workHoursPerDay > 16)
                {
                    throw new ArgumentException("Enter hours between 4 and 16!");
                }
            }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour = weekSalary / (5 * workHoursPerDay);
            return moneyPerHour;
        }

        public static void SortByMoneyPerHourDescending(List<Worker> workers)
        {
            var sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour());
            Console.WriteLine("Workers sorted by money per hours in descending order:");
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine(worker.firstName + " " + worker.lastName);
            }
        }

        public string GetFirstName()
        {
            return this.firstName;
        }

        public string GetLastName()
        {
            return this.lastName;
        }
    }
}
