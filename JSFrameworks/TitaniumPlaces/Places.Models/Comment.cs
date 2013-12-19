using System;
using System.Linq;

namespace Places.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public virtual User User { get; set; }

        public virtual Place Place { get; set; }
    }
}
