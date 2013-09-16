using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using BloggingSystem.Data;
using BloggingSystem.Models;
using BloggingSystem.Services.Attributes;
using BloggingSystem.Services.Models;

namespace BloggingSystem.Services.Controllers
{
    public class PostsController : BaseController
    {
        public PostsController()
        { }

        [HttpPost]
        public HttpResponseMessage PostCreate(PostModel postModel, 
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.ExceptionHandling(
            () =>
            {
                var context = new BloggingSystemContext();
                using (context)
                {
                    var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password!");
                    }

                    List<string> tags = new List<string>();
                    tags = TakeTags(postModel.Title);
                    foreach (var tagEntity in tags)
                	{
                        var tagInDb = context.Tags.FirstOrDefault(t => t.Name == tagEntity);
                        
                        if(tagInDb == null)
                        {
                            var tag = new Tag()
                            {
                                Name = tagEntity,
                                User = user
                            };
                            context.Tags.Add(tag);
                            context.SaveChanges();
                        }
	                }

                    foreach (var tag in postModel.Tags)
                    {
                        var tagInDb = context.Tags.FirstOrDefault(t => t.Name == tag);

                        if (tagInDb == null)
                        {
                            var newTag = new Tag()
                            {
                                Name = tag,
                                User = user
                            };
                            context.Tags.Add(newTag);
                            context.SaveChanges();
                        }
                    } 

                    var post = new Post()
                    {
                        Title = postModel.Title,
                        Text = postModel.Text, 
                        User = user,
                        PostDate = DateTime.Now
                    };

                    context.Posts.Add(post);
                    context.SaveChanges();

                    var postCreated = new PostCreatedModel()
                    {
                        Id = post.Id,
                        Title = post.Title
                    };

                    var response =
                        this.Request.CreateResponse(HttpStatusCode.Created, postCreated);
                    return response;
                }
            });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<PostModel> GetAll(
             [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
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

                        var postsEntities = context.Posts;
                        var models =
                            (from postEntity in postsEntities
                             select new PostModel()
                             {
                                 Id = postEntity.Id,
                                 Title = postEntity.Title,
                                 Text = postEntity.Text,
                                 PostDate = postEntity.PostDate,
                                 PostedBy = postEntity.User.Displayname,
                                 Comments = (from commentEntity in postEntity.Comments
                                             select new CommentModel()
                                             {
                                                 Text = commentEntity.Text,
                                                 PostDate = commentEntity.PostDate,
                                                 CommentedBy = commentEntity.User.Displayname
                                             }),
                                Tags = (from tagEntity in postEntity.Tags
                                        select tagEntity.Name)
                             });
                        return models.OrderByDescending(p => p.PostDate);
                });
            return responseMsg;
        }

        [HttpGet]
        public IQueryable<PostModel> GetPostsByPageAndCount(int page, int count,
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Skip(page * count)
                .Take(count);
            return models;
        }

        [HttpGet]
        public IQueryable<PostModel> GetPostByKeyword(string keyword,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Where(x => x.Title.Contains(keyword));
            return models;   
        }

        [HttpPut]
        [ActionName("comment")]
        public HttpResponseMessage PutComment(CommentCreatedModel leavedCommentModel, int postId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new BloggingSystemContext();
            using (context)
            {
                var entityComment = context.Posts.FirstOrDefault(p => p.Id == postId);
                var commentModel = new CommentCreatedModel()
                {
                    Id = entityComment.Id,
                    Text = leavedCommentModel.Text
                };

                var newComment = new Comment()
                {
                    Text = commentModel.Text,
                    PostDate = DateTime.Now,
                    Id = commentModel.Id,
                };

                context.Comments.Add(newComment);
                context.SaveChanges();

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        public List<string> TakeTags(string title)
        {
            string[] tags = title.Split(
            new char[] { ' ', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> tagsList = new List<string>();
            foreach (var tag in tags)
            {
                tagsList.Add(tag);
            }
            return tagsList;
        }
    }
}
