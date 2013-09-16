using System;
using System.Linq;

namespace Bank.Services.Models
{
    public class TransactionModel
    {
        public string TransactionType { get; set; }

        public DateTime Date { get; set; }

        public decimal Sum { get; set; }
    }
}