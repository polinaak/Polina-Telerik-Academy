using System;
using System.Linq;

namespace Bank.Services.Models
{
    public class LoggedUserModel
    {
        public string Username { get; set; }

        public string SessionKey { get; set; }
    }
}