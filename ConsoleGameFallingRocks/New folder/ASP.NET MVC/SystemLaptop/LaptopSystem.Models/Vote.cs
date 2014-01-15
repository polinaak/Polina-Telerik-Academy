using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LaptopSystem.Models
{
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }

        [Required]
        public string VotedBy { get; set; }

        public int LaptopId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Laptop Laptop { get; set; }
    }
}
