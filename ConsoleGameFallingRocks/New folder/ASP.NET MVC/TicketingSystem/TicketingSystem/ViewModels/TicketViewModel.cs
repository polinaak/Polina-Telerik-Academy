using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TicketingSystem.Models;

namespace TicketingSystem.ViewModels
{
    public class TicketViewModel
    {
        public int TicketId { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public int Comments { get; set; }

        public static Expression<Func<Ticket, TicketViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketViewModel
                {
                    TicketId = ticket.TicketId,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                    Comments = ticket.Comments.Count,
                    Title = ticket.Title 
                };
            }
        }
    }
}