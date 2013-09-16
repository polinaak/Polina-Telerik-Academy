using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string SessionKey { get; set; }

        public string  AuthCode { get; set; }

        public IEnumerable<Account> Accounts { get; set; }

        public User()
        {
            this.Accounts = new HashSet<Account>();
        }
    }
}
