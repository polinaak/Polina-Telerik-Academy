using System;
using System.Linq;

namespace Bank.Services.Models
{
    public class UserModel
    {
        public string Username { get; set; }

        public string SessionKey { get; set; }

        public string AuthCode { get; set; }
    }
}