using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TicketingSystem.Models;

namespace TicketingSystem.ViewModels
{
    public class TicketsListViewModel
    {

        public int TicketId { get; set; }

        [Required]
        public string Title { get; set; }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public Priority Priority { get; set; }

        public string Author { get; set; }

        public static Expression<Func<Ticket, TicketsListViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketsListViewModel
                {
                    TicketId = ticket.TicketId,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                    Title = ticket.Title,
                    Priority = ticket.Priority
                };
            }
        }

        public string PriorityAsString
        {
            get 
            {
                return this.Priority.ToString();
            }
        }
    }
}