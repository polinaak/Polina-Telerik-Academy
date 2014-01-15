using Kendo.Mvc.UI;
using LaptopSystem.Data;
using LaptopSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;

namespace LaptopSystem.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class CommentsAdministrationController : BaseController
    {
        UowData data;

        public CommentsAdministrationController()
        {
            this.data = new UowData();
        }
        //
        // GET: /CommentsAdministration/
        public ActionResult Index()
        {
            return View();
        }

         public JsonResult ReadComments([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Comments.All()
                .Select(x => new CommentViewModel
                    {
                        CommentId = x.CommentId,
                        Content = x.Content,
                        CommentedBy = x.User.UserName
                    });

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
	}
}