using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Laptop> Laptops { get; set; }

        public Manufacturer()
        {
            this.Laptops = new HashSet<Laptop>();
        }
    }
}
