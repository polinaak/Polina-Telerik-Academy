using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TicketingSystem.Models;

namespace TicketingSystem.ViewModels
{
    public class TicketDetailsViewModel
    {
        public int TicketId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Ticket, TicketDetailsViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketDetailsViewModel
                {
                    TicketId = ticket.TicketId,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                    Title = ticket.Title,
                    Description = ticket.Description,
                    Priority = ticket.Priority,
                    ScreenshotUrl = ticket.ScreenshotUrl,
                    Comments = ticket.Comments.Select(x => new CommentViewModel
                    {
                        Author = x.Author.UserName,
                        Content = x.Content,
                        CommentId = x.CommentId
                    })
                };
            }
        }
    }
}