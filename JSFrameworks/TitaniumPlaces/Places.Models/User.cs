using System;
using System.Collections.Generic;
using System.Linq;

namespace Places.Models
{
    public class User
    {
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Places = new HashSet<Place>();
            this.Images = new HashSet<Image>();
        }

        public int Id { get; set; }

        public string Nickname { get; set; }

        public string Username { get; set; }

        public string AuthCode { get; set; }

        public string SessionKey { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        
        public virtual ICollection<Place> Places { get; set; }
        
        public virtual ICollection<Image> Images { get; set; }
    }
}