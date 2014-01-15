using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Models
{
    public class Laptop
    {
        [Key]
        public int LaptopId { get; set; }

        [Required]
        public string Model { get; set; }

        public double Monitor { get; set; }

        public string ImageUrl { get; set; }

        public int? HardDisk { get; set; }

        public int? RAM { get; set; }

        public decimal Price { get; set; }

        public double? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public Laptop()
        {
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }
    }
}
