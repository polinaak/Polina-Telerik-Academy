using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresentsApp.Filters;
using PresentsApp.Models;
using WebMatrix.WebData;

namespace PresentsApp.Controllers
{
    public class QuestController : BaseController
    {
        //
        // GET: /Quest/

        public ActionResult ShowQuests(int userId)
        {
            var quests = this.data.Quests.All().Where(x => x.EmployeeId == userId)
                .Select(PresentsApp.Models.ViewModels.QuestViewModel.FromQuest).ToList();
            return View(quests);
        }

         [InitializeSimpleMembership]
        public ActionResult Create() 
        {
            var userId = WebSecurity.CurrentUserId; 
            ViewBag.UserId = new SelectList(this.data.Users.All().Where(x => x.UserId != userId), "UserId", "UserName");
            return View();
        }

        [HttpPost]
        [InitializeSimpleMembership]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Quest questModel)
        {
            var userId = WebSecurity.CurrentUserId;
            if (ModelState.IsValid)
            {
                var iSExistQuest = this.data.Quests.All().Where(x => x.Year == questModel.Year);

                if (iSExistQuest == null)
                {
                    var quest = new Quest
                    {
                        EmployeeId = userId,
                        Year = questModel.Year
                    };

                    this.data.Quests.Add(quest);
                    this.data.SaveChanges();
                    return Redirect("/Home/Index");
                }
            }
            
            ViewBag.UserId = new SelectList(this.data.Users.All().Where(x => x.UserId == userId), "UserId", "UserName");
            return View(questModel); 
        }
    }
}
