using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentsApp.Controllers
{
    public class PresentController : BaseController
    {
        //
        // GET: /Present/

        public ActionResult ShowPresents(int questId)
        {

            var presents = this.data.Presents.All().ToList();
            return View(presents);
        }

    }
}
