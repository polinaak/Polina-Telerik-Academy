using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Bank
{
    public abstract class Account : IDepositable
    {
        public enum Customer
        {
            Individual,
            Company
        }
        protected Customer type;
        protected decimal balance;
        protected decimal interestRate;

        protected Account(decimal balance, decimal interestRate, Customer type)
        {
            this.balance = balance;
            this.interestRate = interestRate;
            this.type = type;
        }

        public decimal Balance
        {
            get { return this.balance; }
            set
            {
                if (value > 0)
                {
                    this.balance = value;
                }
                else
                {
                    throw new ArgumentException("The balance can`t be negative!");
                }
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
        public decimal InterestRate
        {
            get { return this.interestRate; }
            set
            {
                if (value > 0)
                {
                    this.interestRate = value;
                }
                else
                {
                    throw new ArgumentException("The interest rate can`t be negative!");
                }
            }
        }

        public Customer Type
        {
            get { return this.type; }
            private set { }
        }

        public abstract decimal CalculateInterestAmount(int months);
    }
}
