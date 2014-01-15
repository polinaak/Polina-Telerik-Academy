using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string AuthorId { get; set; }

        public int TicketId { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual Ticket Ticket{ get; set; }

    }
}
