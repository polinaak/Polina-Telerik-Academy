using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Places.App.Models
{
    [DataContract]
    public class PlaceModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "townId")]
        public int TownId { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "imageUrls")]
        public IEnumerable<string> ImageUrls { get; set; }
    }
}