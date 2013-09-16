using System;
using System.Linq;

namespace Bank.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public virtual Account Account { get; set; }

        public DateTime Date { get; set; }

        public decimal Sum { get; set; }

        public string TransactionType { get; set; }
    }
}
