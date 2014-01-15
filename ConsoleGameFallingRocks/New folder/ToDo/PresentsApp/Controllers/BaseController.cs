using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresentsApp.Models.Data;

namespace PresentsApp.Controllers
{
    public class BaseController : Controller
    {
        protected IUowData data;

        public BaseController(IUowData data)
        {
            this.data = data;
        }

        public BaseController()
            : this(new UowData())
        {

        }
    }
}
