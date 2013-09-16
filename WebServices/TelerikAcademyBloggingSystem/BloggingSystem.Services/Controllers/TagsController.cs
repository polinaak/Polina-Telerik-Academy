using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using BloggingSystem.Data;
using BloggingSystem.Services.Attributes;
using BloggingSystem.Services.Models;

namespace BloggingSystem.Services.Controllers
{
    public class TagsController : BaseController
    {
        public TagsController()
        {
        }

        [HttpGet]
        public IQueryable<TagModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMsg = this.ExceptionHandling(
                () =>
                {
                    var context = new BloggingSystemContext();

                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password!");
                    }

                    var tagsEntities = context.Tags;
                    var models =
                        (from tagEntity in tagsEntities
                         select new TagModel()
                         {
                             Id = tagEntity.Id,
                             Name = tagEntity.Name,
                             NumberOfPosts = tagEntity.Post.Tags.Count
                         });
                    return models.OrderBy(t => t.Name);
                });
            return responseMsg;
        }

        [HttpGet]
        [ActionName("posts")]
        public IQueryable<TagModel> GetTagsById(int tagId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMsg = this.ExceptionHandling(
                () =>
                {
                    var context = new BloggingSystemContext();
               
                    var entityTags = context.Tags.FirstOrDefault(x => x.Id == tagId).Post.Tags;
                    var tagModels = new List<TagModel>();
                    foreach (var entityTag in entityTags)
                    {
                        tagModels.Add(new TagModel()
                        {
                            Name = entityTag.Name,
                            Id = entityTag.Id,
                            NumberOfPosts = entityTag.Post.Tags.Count,
                            PostDate = entityTag.Post.PostDate
                        });
                    }
                    return tagModels.OrderByDescending(t => t.PostDate);
                });

            return responseMsg.AsQueryable();
        }
    }
}