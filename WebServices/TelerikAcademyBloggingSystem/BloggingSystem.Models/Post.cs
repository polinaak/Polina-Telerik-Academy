using System;
using System.Collections.Generic;
using System.Linq;

namespace BloggingSystem.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual User User { get; set; }

        public DateTime PostDate { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            this.Tags = new HashSet<Tag>();
            this.Comments = new HashSet<Comment>();
        }
    }
}
