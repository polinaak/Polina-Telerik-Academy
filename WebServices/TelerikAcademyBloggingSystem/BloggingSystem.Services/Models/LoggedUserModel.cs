using System;
using System.Linq;

namespace BloggingSystem.Services.Models
{
    public class LoggedUserModel
    {
        public string Displayname { get; set; }

        public string SessionKey { get; set; }
    }
}