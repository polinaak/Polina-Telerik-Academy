using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketingSystem.Data;
using TicketingSystem.ViewModels;

namespace TicketingSystem.Controllers
{
    public class HomeController : BaseController
    {
        UowData data;

        public HomeController()
        {
            this.data = new UowData();
        }

        public ActionResult Index()
        {
            if (this.HttpContext.Cache["TicketViewModel"] == null)
            {
                var ticketsByComments = this.data.Tickets.All()
                    .OrderByDescending(x => x.Comments.Count)
                    .Take(6)
                    .Select(TicketViewModel.FromTicket)
                    .ToList();

                this.HttpContext.Cache.Add("TicketViewModel", ticketsByComments, null, DateTime.Now.AddMinutes(1),
                    TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["TicketViewModel"]);
        }
	}
}