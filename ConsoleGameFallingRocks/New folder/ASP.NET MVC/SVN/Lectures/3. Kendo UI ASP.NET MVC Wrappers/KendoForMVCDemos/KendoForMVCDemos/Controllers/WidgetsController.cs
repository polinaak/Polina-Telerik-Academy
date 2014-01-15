using KendoForMVCDemos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KendoForMVCDemos.ViewModels;

namespace KendoForMVCDemos.Controllers
{
    public class WidgetsController : Controller
    {
        public WidgetsController()
        {
            this.Data = new ApplicationDbContext();
        }

        public ApplicationDbContext Data { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult AutoComplete()
        {
            var books = this.Data.Books.Select(ShortBookViewModel.FromBook);

            return View(books);
        }
	}
}