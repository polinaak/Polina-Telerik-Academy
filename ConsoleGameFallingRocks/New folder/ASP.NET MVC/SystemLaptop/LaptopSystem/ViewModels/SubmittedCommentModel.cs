using LaptopSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaptopSystem.ViewModels
{
    public class SubmittedCommentModel
    {
        [Required]
        [ShouldNotContainEmailAttribute]
        public string Comment { get; set; }

        public int LaptopId { get; set; }
    }
}