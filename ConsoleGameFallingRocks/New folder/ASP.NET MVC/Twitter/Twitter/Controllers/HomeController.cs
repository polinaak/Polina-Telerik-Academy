using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.ViewModels;
using Microsoft.AspNet.Identity;

namespace Twitter.Controllers
{
    public class HomeController : BaseController
    {
        UowData data;
        public HomeController()
        {
            this.data = new UowData();
        }

       [OutputCache(Duration=900)]
        public ActionResult Index()
        {
            List<SearchedTweet> messages = new List<SearchedTweet>();
            var userId = User.Identity.GetUserId();
            var tweets = this.data.Tweets.All().Where(x => x.User.Id == userId).Select(x => x.Message).ToList();
           
            foreach (var t in tweets)
            {
                SearchedTweet message = new SearchedTweet
                {
                    Message = t                   
                };
                messages.Add(message);
            }

            return View(messages);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AutoComplete()
        {
            return View();
        }

        public JsonResult GetTweets(string text)
        {
           var tweets = this.data.Tweets.All().Where(x => x.Message.ToLower().Contains(text.ToLower())).Select(SearchedTweet.FromTweet);
           return Json(tweets, JsonRequestBehavior.AllowGet);
        }
    }
}