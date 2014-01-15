using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using TicketingSystem.Data;
using TicketingSystem.ViewModels;
using TicketingSystem.Models;

namespace TicketingSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesAdministrationController : BaseController
    {
         UowData data;

         public CategoriesAdministrationController()
        {
            this.data = new UowData();
        }

        //
        // GET: /CategoriesAdministration/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadCategories([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.data.Categories.All()
                .Select(x => new CategoryViewModel
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name
                });

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategories([DataSourceRequest] DataSourceRequest request, CategoryViewModel comment)
        {
            var commentDb = this.data.Categories.GetById(comment.CategoryId);

            commentDb.Name = comment.Name;
            this.Data.SaveChanges();

            return Json(new[] { comment }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DestroyCategories([DataSourceRequest] DataSourceRequest request, CategoryViewModel comment)
        {
            this.data.Categories.Delete(comment.CategoryId);

            var tickets = this.data.Tickets.All().Where(x => x.CategoryId == comment.CategoryId).ToList();

            foreach (var ticket in tickets)
            {
                this.data.Tickets.Delete(ticket.TicketId);
            }

            this.Data.SaveChanges();

            return Json(new[] { comment }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategories([DataSourceRequest] DataSourceRequest request, CategoryViewModel town)
        {
            if (town != null && ModelState.IsValid)
            {
                var category = this.Data.Categories.GetById(town.CategoryId);

                var newTown = new Category
                {
                    Name = town.Name,
                    CategoryId = town.CategoryId,

                };

                this.Data.Categories.Add(newTown);
                this.Data.SaveChanges();

                town.CategoryId = newTown.CategoryId;
            }

            return Json(new[] { town }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
	}
}