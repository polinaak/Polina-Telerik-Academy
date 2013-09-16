﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloggingSystem.Services.Models
{
    [DataContract]
    public class CommentCreatedModel
    {
        public int Id { get; set; }

        [DataMember(Name="text")]
        public string Text { get; set; }
    }
}