using System;
using System.Collections.Generic;
using System.Linq;

namespace Places.Models
{
    public class Place
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Town Town { get; set; }

        public string Content { get; set; }

        public ICollection<Image> Images { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual User User { get; set; }

        public Place()
        {
            this.Images = new HashSet<Image>();
            this.Comments = new HashSet<Comment>();
        }
    }

}
