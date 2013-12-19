using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Places.App.Attributes;
using Places.App.Models;
using Places.Data;
using Places.Models;

namespace Places.App.Controllers
{
    public class CommentsController : BaseApiController
    {
        public CommentsController()
        { }

        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage CreateComment(CommentModel commentModel, int id,
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        { 
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();
                    using (context)
                    {
                        var user = UsersController.GetUserBySessionKey(context, sessionKey);
                        var place = context.Places.FirstOrDefault(p => p.Id == id);

                        if (user == null)
                        {
                            throw new InvalidOperationException("Invalid username or password!");
                        }

                        var comment = new Comment()
                        {
                            Content = commentModel.Content,
                            Date = DateTime.Now,
                            User = user
                        };

                        place.Comments.Add(comment);
                        context.SaveChanges();

                        var createdComment = new CommentModel()
                        {
                            Date = comment.Date,
                            Content = comment.Content,
                            PostedBy = comment.User.Nickname
                        };


                        var response = this.Request.CreateResponse(HttpStatusCode.Created, createdComment);
                        return response;
                    }
                });

            return responseMessage;
        }
    }
}
