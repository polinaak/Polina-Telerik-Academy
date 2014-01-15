using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TicketingSystem.Models;

namespace TicketingSystem.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return comment => new CommentViewModel
                {
                    Author = comment.Author.UserName,
                    Content = comment.Content,
                    CommentId = comment.CommentId
                };
            }
        }
    }
}
