using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Places.App.Models
{
    [DataContract]
    public class ImageModel
    {
        [DataMember(Name="imageUrl")]
        public string ImageUrl { get; set; }
    }
}