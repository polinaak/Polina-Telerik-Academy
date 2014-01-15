using LaptopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LaptopSystem.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        public string CommentedBy { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return comment => new CommentViewModel 
                {
                    CommentedBy = comment.User.UserName,
                    Content = comment.Content,
                    CommentId = comment.CommentId
                };
            }
        }
    }
}