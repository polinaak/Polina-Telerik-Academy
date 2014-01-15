using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TicketingSystem.Models;

namespace TicketingSystem.ViewModels
{
    public class CreatingTicketViewModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual Category Category { get; set; }

        public Priority Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        [ShouldNotContainBug(ErrorMessage="The word 'bug' should not be used in description!")]
        public string Description { get; set; }

    }
}