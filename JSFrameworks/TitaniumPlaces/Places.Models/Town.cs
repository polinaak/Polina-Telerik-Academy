using System;
using System.Collections.Generic;
using System.Linq;

namespace Places.Models
{
    public class Town
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Place> Places { get; set; }

        public Town()
        {
            this.Places = new HashSet<Place>();
        }
    }
}
