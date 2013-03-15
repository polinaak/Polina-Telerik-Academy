using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Bank
{
    class Loan : Account, IDepositable
    {
        public Loan(decimal balance, decimal interestRate, Customer type)
            : base(balance, interestRate, type)
        { }

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
            decimal result = 0;
            if (this.type == Customer.Individual)
            {
                if (months <= 3)
                {
                    return 0;
                }
                else
                {
                    result = (this.interestRate / 100) * this.balance * (months-3);
                    return result;
                }
            }
            else
            {
                if (months <= 2)
                {
                    return 0;
                }
                else
                {
                    result = (this.interestRate / 100) * this.balance * (months-2);
                    return result;
                }
            }
        }
    }
}
