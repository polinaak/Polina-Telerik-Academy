using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Tweet
    {
        [Key]
        public int TweetId { get; set; }

        public ApplicationUser User { get; set; }

        [Required(ErrorMessage="You must enter message to post a tweet!")]
        [StringLength(500, MinimumLength=1, ErrorMessage="Message must be between 1 and 500 symbols!")]
        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Tweet()
        {
            this.Tags = new HashSet<Tag>();
        }
    }
}
