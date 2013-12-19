using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Places.App.Models
{
    [DataContract]
    public class TownModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name="countryId")]
        public int CountryId { get; set; }
    }
}