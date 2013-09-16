using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloggingSystem.Services.Models
{
    [DataContract]
    public class PostModel
    {
        public int Id { get; set; }

        [DataMember(Name="title")]
        public string Title { get; set; }

        [DataMember(Name="text")]
        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public string PostedBy { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }

        [DataMember(Name="tags")]
        public IEnumerable<string> Tags { get; set; }

        public PostModel()
        {
            this.Comments = new HashSet<CommentModel>();
            this.Tags = new HashSet<string>();
        }
    }
}