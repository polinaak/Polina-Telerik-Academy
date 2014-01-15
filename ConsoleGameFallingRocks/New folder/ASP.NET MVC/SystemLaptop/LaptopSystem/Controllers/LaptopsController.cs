using LaptopSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopSystem.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using LaptopSystem.Models;

namespace LaptopSystem.Controllers
{
    public class LaptopsController : BaseController
    {
        UowData data;

        public LaptopsController()
        {
            this.data = new UowData();
        }

        //
        // GET: /Laptop/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var laptopDetails = this.data.Laptops
                .All()
                .Where(x => x.LaptopId == id)
                .Select(LaptopDetailsViewModel.FromLaptop)
                .FirstOrDefault();
            return View(laptopDetails);
        }

        [Authorize]
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Search(SearchViewModel query)
        {
            var result = this.data.Laptops.All();

            if (!string.IsNullOrEmpty(query.ModelSearch))
            {
                result = result.Where(x => x.Model.ToLower().Contains(query.ModelSearch.ToLower()));
            }

            if (query.ManufacturerSearch != "All")
            {
                result = result.Where(x => x.Manufacturer.Name == query.ManufacturerSearch);
            }

            if (query.PriceSearch != 0)
            {
                result = result.Where(x => x.Price < query.PriceSearch);
            }

            var laptops = result.Select(x =>
                new LaptopViewModel
                {
                    LaptopId = x.LaptopId,
                    Model = x.Model,
                    Manufacturer = x.Manufacturer.Name,
                    Price = x.Price,
                    ImageUrl = x.ImageUrl
                });

            return View(laptops);
        }

        public ActionResult Vote(int id)
        {
            var userId = User.Identity.GetUserId();
            var UserCanVote = !this.data.Votes.All().Any(x => x.LaptopId == id && x.VotedBy == userId);

            if (UserCanVote)
            {
                this.data.Laptops.GetById(id).Votes.Add(new Vote
                {
                    VotedBy = userId,
                    LaptopId = id
                });

                this.data.SaveChanges();
            }

            var votes = this.data.Laptops.GetById(id).Votes.Count();

            return Content(votes.ToString());
        }

        [Authorize]
        //[ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmittedCommentModel comment)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                this.Data.Comments.Add(new Comment()
                {
                    AuthorId = userId,
                    Content = comment.Comment,
                    LaptopId = comment.LaptopId,
                });

                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { CommentedBy = username, Content = comment.Comment };
                return PartialView("_CommentPartial", viewModel);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        private IEnumerable<LaptopViewModel> GetAllLaptops()
        {
            var laptops = this.data.Laptops
                .All()
                .Select(LaptopViewModel.FromLaptop)
                .ToList();

            return laptops;
        }

        public JsonResult GetAllLaptopsKendo([DataSourceRequest] DataSourceRequest request)
        { 
            var laptops = this.GetAllLaptops();
            return Json(laptops.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLaptopsModels(string query)
        {
            var result = this.data.Laptops
                .All()
                .Where(x => x.Model.ToLower().Contains(query.ToLower()))
                .Select(x => new
                {
                    Model = x.Model
                });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetManufacturers()
        {
            var manufacturers = this.data.Manufacturers
                .All()
                .Select(x => new
                {
                    ManufacturerName = x.Name
                });

            return Json(manufacturers, JsonRequestBehavior.AllowGet);
        }
	}
}