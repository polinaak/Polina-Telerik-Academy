using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Models
{
    public class Studio
    {
        [Key]
        public int StudioId { get; set; }

        public string StudioAddress { get; set; }
    }
}
