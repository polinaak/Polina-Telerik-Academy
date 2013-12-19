using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Places.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int PlaceId { get; set; }

        [ForeignKey("PlaceId")]
        public virtual Place Place { get; set; }

        public virtual User User { get; set; }
    }
}
