using BirthdayPresentPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BirthdayPresentPlanner.Models.ViewModels;

namespace BirthdayPresentPlanner.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var result = this.Data.Users.All().Where(u => u.Id != userId).Select(EmployeeViewModel.FromApplicationUser).ToList();
            return View(result);
        }

        public ActionResult ShowQuests(string id)
        {
            var result = this.Data.Questionnaries.All().Where(u => u.EmployeeId == id)
                .Select(QuestionnaireViewModel.FromQuestionnaire).ToList();
            ViewBag.EmployeeId = id;
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = this.Data.Presents.All().ToList();
            ViewBag.QuestId = id;
            return View(result);
        }

        public ActionResult VotePresent(int id, int questId)
        {

            var employeeId = User.Identity.GetUserId();
            var check = this.Data.Votes.All().Where(v => v.EmployeeId == employeeId &&
                v.QuestionnaireId == questId).Select(VoteViewModel.FromVote).FirstOrDefault();

            if (check == null)
            {
                Vote vote = new Vote();
                vote.EmployeeId = employeeId;
                vote.PresentId = id;
                vote.QuestionnaireId = questId;

                this.Data.Votes.Add(vote);
                this.Data.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Create(string employeeId)
        {
            ViewBag.EmployeeID = employeeId;

            return View();
        }

        public ActionResult Save(Questionnaire questionnaire, string id)
        {
            if (ModelState.IsValid)
            {
                this.Data.Questionnaries.Add(questionnaire);

                questionnaire.EmployeeId = id;
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionnaire);
        }

        public ActionResult ShowStat(int questId)
        {
            var result = this.Data.Votes.All().Where(v => v.QuestionnaireId == questId)
                .Select(VoteViewModel.FromVote).FirstOrDefault();
            //ViewBag.ChosenPresent = this.Data.Votes.All().Where(v => v.QuestionnaireId == questId && v.Present.Votes.Count)
            //    .Count();
            ViewBag.Voted = this.Data.Votes.All().Where(v => v.QuestionnaireId == questId)
                .Count();
            ViewBag.NotVoted = this.Data.Users.All().Count() - ViewBag.Voted;
            return View(result);
        }

    }
}