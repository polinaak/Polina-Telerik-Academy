using System;
using System.Collections.Generic;
using System.Linq;

namespace Places.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }

        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
    }
}
