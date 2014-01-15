using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresentsApp.Filters;
using WebMatrix.WebData;

namespace PresentsApp.Controllers
{
     [InitializeSimpleMembership]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
           var userId = WebSecurity.CurrentUserId;
           var users = this.data.Users.All().Where(x => x.UserId != userId).Select(PresentsApp.Models.ViewModels.EmployeeViewModel.FromUserProfile).ToList();

           return View(users);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
