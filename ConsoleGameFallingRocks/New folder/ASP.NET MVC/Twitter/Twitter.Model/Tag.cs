using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Tag
    {
        [Key]
        [Required(ErrorMessage="Tag must have name!")]
        [StringLength(50, MinimumLength=1, ErrorMessage="Tag name must be between 1 and 50 symbols!")]
        public string Name { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }

        public Tag()
        {
            this.Tweets = new HashSet<Tweet>();
        }
    }
}
