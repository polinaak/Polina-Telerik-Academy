using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BirthdayPresentPlanner.Models.ViewModels;

namespace BirthdayPresentPlanner.Controllers
{
    public class QuestionnairesController : BaseController
    {
        //
        // GET: /Questionnaires/
        public ActionResult Index()
        {
            var employeeId = User.Identity.GetUserId();
            var result = this.Data.Questionnaries.All().Where(u => u.EmployeeId != employeeId)
                .Select(QuestionnaireViewModel.FromQuestionnaire).ToList();          
            return View(result);
        }

    }
}