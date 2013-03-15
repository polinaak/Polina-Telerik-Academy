using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Bank
{
    public class Deposit : Account, IDepositable
    {
        public Deposit(decimal balance, decimal interestRate, Customer type)
            : base(balance, interestRate, type)
        { }

        public void WithDraw(decimal money)
        {
            if (money < this.balance)
            {
                balance -= money;
                Console.WriteLine("Your balance is: " + this.balance);
            }
            else
            {
                throw new ArgumentException("Can`t withdraw more than the current balance!");
            }
        }
        public void AddDeposit(decimal deposit)
        {
            if (deposit > 0)
            {
                this.balance += deposit;
            }
            else
            {
                throw new ArgumentException("Deposit can not be negative!");
            }
        }
        public override decimal CalculateInterestAmount(int months)
        {
            if (this.balance > 0 && this.balance < 1000)
            {
                return 0;
            }
            else
            { 
                decimal result = 0;
                result = (this.interestRate / 100) * this.balance * months;
                return result;
            }
        }
    }
}
