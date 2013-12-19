using Places.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Places.App.Models
{
    [DataContract]
    public class CountrySmallModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        //[DataMember(Name = "towns")]
        //public IEnumerable<TownModel> Towns { get; set; }
    }
}