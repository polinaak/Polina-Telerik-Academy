using System;
using System.Data.Entity;
using System.Linq;
using Bank.Models;

namespace Bank.Data
{
    public class BankContext : DbContext
    {
        public BankContext()
            : base("BankDb")
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
