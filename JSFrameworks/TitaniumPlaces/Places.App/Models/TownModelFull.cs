using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Places.App.Models
{
    [DataContract]
    public class TownModelFull
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "country")]
        public CountrySmallModel Country { get; set; }

        [DataMember(Name = "places")]
        public IEnumerable<PlaceModelSmall> Places { get; set; }
    }
}