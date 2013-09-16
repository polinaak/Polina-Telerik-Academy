using System;
using System.Linq;

namespace BloggingSystem.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }
    }
}
