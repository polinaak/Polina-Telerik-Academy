using LaptopSystem.Data;
using LaptopSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopSystem.Controllers
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
            if (this.HttpContext.Cache["LaptopViewModel"] == null)
            {
                var laptopsByVotes = this.data.Laptops.All()
                    .OrderByDescending(x => x.Votes.Count)
                    .Take(6)
                    .Select(LaptopViewModel.FromLaptop)
                    .ToList();

                this.HttpContext.Cache.Add("LaptopViewModel", laptopsByVotes, null, DateTime.Now.AddHours(1),
                    TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["LaptopViewModel"]);
        }
    }
}