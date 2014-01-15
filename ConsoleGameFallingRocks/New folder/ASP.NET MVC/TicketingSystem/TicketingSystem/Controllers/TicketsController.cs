using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketingSystem.Data;
using TicketingSystem.Models;
using TicketingSystem.ViewModels;
using Microsoft.AspNet.Identity;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace TicketingSystem.Controllers
{
    public class TicketsController : Controller
    {
        UowData data;

        public TicketsController()
        {
            this.data = new UowData();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var ticketDetails = this.data.Tickets
                .All()
                .Where(x => x.TicketId == id)
                .Select(TicketDetailsViewModel.FromTicket)
                .FirstOrDefault();
            return View(ticketDetails);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(this.data.Categories.All(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatingTicketViewModel ticketModel)
        {
            var author = User.Identity.GetUserName();
            var authorId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                var ticket = new Ticket
                {
                    AuthorId = authorId,
                    Category = ticketModel.Category,
                    CategoryId = ticketModel.CategoryId,
                    Description = ticketModel.Description,
                    Priority = ticketModel.Priority,
                    ScreenshotUrl = ticketModel.ScreenshotUrl,
                    Title = ticketModel.Title,
                };

                var currentUser = this.data.Users.All().Where(x => x.Id == authorId).FirstOrDefault();
                currentUser.Points++;

                this.data.Tickets.Add(ticket);
                this.data.SaveChanges();
                return Redirect("/Home/Index");
            }

            ViewBag.CategoryId = new SelectList(this.data.Categories.All(), "CategoryId", "Name");
            return View(ticketModel);
        }

        [Authorize]
        public ActionResult List()
        {
            return View();
        }

        [Authorize]
        public ActionResult Search(string categorySearch)
        {
            var result = this.data.Tickets.All();
            if (!string.IsNullOrEmpty(categorySearch))
            {
                result = result.Where(x => x.Category.Name == categorySearch);
            }
            var foundTickets = result.Select(TicketViewModel.FromTicket);
            return View(foundTickets);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmittedCommentViewModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                this.data.Comments.Add(new Comment()
                {
                    AuthorId = userId,
                    Content = commentModel.Comment,
                    TicketId = commentModel.TicketId,
                });

                this.data.SaveChanges();

                var viewModel = new CommentViewModel { Author = username, Content = commentModel.Comment };
                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        public JsonResult GetAllTickets([DataSourceRequest] DataSourceRequest request)
        {
            var tickets = this.data.Tickets
               .All()
               .Select(TicketsListViewModel.FromTicket)
               .ToList();
           
            return Json(tickets.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTicketsByCategory()
        {
            var manufacturers = this.data.Categories
                .All()
                .Select(x => new
                {
                    CategoryName = x.Name
                });

            return Json(manufacturers, JsonRequestBehavior.AllowGet);
        }
	}
}