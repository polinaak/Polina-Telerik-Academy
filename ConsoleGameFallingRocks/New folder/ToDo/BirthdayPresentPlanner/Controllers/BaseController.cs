using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BirthdayPresentPlanner.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork Data;

        public BaseController(IUnitOfWork data)
        {
            this.Data = data;
        }

        public BaseController()
            :this(new UowData())
        {

        }
	}
}