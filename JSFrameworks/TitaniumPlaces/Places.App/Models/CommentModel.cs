using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Places.App.Models
{
    [DataContract]
    public class CommentModel
    {
        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "postedBy")]
        public string PostedBy { get; set; }
    }
}