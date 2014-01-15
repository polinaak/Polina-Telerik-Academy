using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LaptopSystem.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string AuthorId { get; set; }

        public int LaptopId { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual Laptop Laptop { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
