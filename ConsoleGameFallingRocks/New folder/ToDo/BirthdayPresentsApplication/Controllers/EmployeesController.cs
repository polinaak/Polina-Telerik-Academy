using BirthdayPresentPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthdayPresentPlanner.Controllers
{
    public class EmployeesController : BaseController
    {
        //
        // GET: /Employees/
        public ActionResult Index()
        {
            var result = this.Data.Users.All().Select(EmployeeViewModel.FromApplicationUser).ToList();
            return View(result);
        }
	}
}