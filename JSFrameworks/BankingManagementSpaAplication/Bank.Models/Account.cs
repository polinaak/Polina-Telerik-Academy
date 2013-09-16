using System;
using System.Linq;

namespace Bank.Models
{
    public class Account
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }
    }
}
