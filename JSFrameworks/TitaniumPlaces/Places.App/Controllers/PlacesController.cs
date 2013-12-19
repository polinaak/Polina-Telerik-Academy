using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Places.Data;
using Places.App.Attributes;
using Places.App.Models;
using Places.Models;

namespace Places.App.Controllers
{
    public class PlacesController : BaseApiController
    {
        #region test place json

        /*
        * admin sessionkey:
        X-sessionKey: 1uTEgInMUChMTFVnGqpNbZwBjSRUeCpOSYZNIiqUIteCrAmZBJ
        {
            "name": "Telerik Academy",
            "townId": 1,
            "content": "The Academy",
            "imageUrls": ["http://localhost", "http://url.com", "http://example.com"]
        }   
        */

        #endregion

        // GET api/places
        [HttpGet]
        public HttpResponseMessage GetAllPlaces(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();

                    using (context)
                    {
                        UsersController.GetUserBySessionKey(context, sessionKey);
                        var placeModels = new HashSet<PlaceGetModel>();
                        foreach (var place in GetAllPlaces(context))
                        {
                            var model = new PlaceGetModel()
                            {
                                Id = place.Id,
                                Name = place.Name,
                                Town = new TownModel()
                                {
                                    Id = place.Town.Id,
                                    Name = place.Town.Name,
                                    CountryId = place.Town.Country.Id
                                },
                                Country = new CountrySmallModel()
                                {
                                    Id = place.Town.Country.Id,
                                    Name = place.Town.Country.Name
                                },
                                Content = place.Content,
                                ImageUrls = place.Images.Select(i => i.Url),
                                Comments = (from comment in place.Comments
                                            select new CommentModel()
                                            {
                                                Content = comment.Content,
                                                Date = comment.Date,
                                                PostedBy = comment.User.Nickname
                                            })
                            };
                            placeModels.Add(model);
                        }

                        return this.Request.CreateResponse(HttpStatusCode.OK, placeModels);
                    }
                });

            return responseMsg;
        }

        // GET api/places/town/{townId}
        [HttpGet]
        [ActionName("town")]
        public HttpResponseMessage GetPlacesByTownId(int townId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();

                    using (context)
                    {
                        UsersController.GetUserBySessionKey(context, sessionKey);
                        var placeModels = new HashSet<PlaceGetModel>();

                        var allPlaces = GetAllPlaces(context).Where(p => p.Town.Id == townId);

                        if (allPlaces == null || allPlaces.Count() == 0)
                        {
                            throw new ArgumentException("No such town");
                        }
                        foreach (var place in allPlaces)
                        {
                            var model = new PlaceGetModel()
                            {
                                Id = place.Id,
                                Name = place.Name,
                                Town = new TownModel()
                                {
                                    Id = place.Town.Id,
                                    Name = place.Town.Name,
                                    CountryId = place.Town.Country.Id
                                },
                                Country = new CountrySmallModel()
                                {
                                    Id = place.Town.Country.Id,
                                    Name = place.Town.Country.Name
                                },
                                Content = place.Content,
                                ImageUrls = place.Images.Select(i => i.Url),
                                Comments = (from comment in place.Comments
                                            select new CommentModel()
                                            {
                                                Content = comment.Content,
                                                Date = comment.Date,
                                                PostedBy = comment.User.Nickname
                                            })
                            };
                            placeModels.Add(model);
                        }

                        return this.Request.CreateResponse(HttpStatusCode.OK, placeModels);
                    }
                });

            return responseMsg;
        }

        // GET api/places/{id}
        [HttpGet]
        public HttpResponseMessage GetPlaceById(
            int placeId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();

                    using (context)
                    {
                        UsersController.GetUserBySessionKey(context, sessionKey);
                        var place = GetAllPlaces(context).FirstOrDefault(p => p.Id == placeId);
                        if (place == null)
                        {
                            throw new ArgumentNullException("place", "A place with the specified ID does not exist.");
                        }
                        var model = new PlaceGetModel()
                        {
                            Id = place.Id,
                            Name = place.Name,
                            Town = new TownModel()
                            {
                                Id = place.Town.Id,
                                Name = place.Town.Name,
                                CountryId = place.Town.Country.Id
                            },
                            Country = new CountrySmallModel()
                            {
                                Id = place.Town.Country.Id,
                                Name = place.Town.Country.Name
                            },
                            Content = place.Content,
                            ImageUrls = place.Images.Select(i => i.Url),
                            Comments = (from comment in place.Comments
                                        select new CommentModel()
                                        {
                                            Content = comment.Content,
                                            Date = comment.Date,
                                            PostedBy = comment.User.Nickname
                                        }).OrderByDescending(c => c.Date)
                        };

                        return this.Request.CreateResponse(HttpStatusCode.OK, model);
                    }
                });

            return responseMsg;
        }

        // POST api/places/
        [HttpPost]
        public HttpResponseMessage PostPlace(
            PlaceModel placeModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();

                    using (context)
                    {
                        var user = UsersController.GetUserBySessionKey(context, sessionKey);
                        if (user.Role != Role.Admin)
                        {
                            throw new InvalidOperationException("User is not admin and cannot see admin information.");
                        }

                        var place = new Place();
                        place.Name = placeModel.Name;
                        place.User = user;
                        if (placeModel.TownId != 0)
                        {
                            var contextTown = context.Towns.Find(placeModel.TownId);
                            if (contextTown != null)
                            {
                                place.Town = contextTown;
                            }
                            else
                            {
                                throw new ArgumentNullException("town", "The town does not exist.");
                            }
                        }

                        place.Content = placeModel.Content;
                        if (placeModel.ImageUrls != null)
                        {
                            foreach (var imageUrl in placeModel.ImageUrls)
                            {
                                place.Images.Add(new Image()
                                {
                                    Place = place,
                                    Url = imageUrl,
                                    User = user
                                });
                            }
                        }

                        context.Places.Add(place);
                        context.SaveChanges();
                        placeModel.Id = place.Id;
                    }
                    return this.Request.CreateResponse(HttpStatusCode.Created, placeModel);
                });

            return responseMsg;
        }

        // POST api/places/{placeId}/comment
        [HttpPost]
        [ActionName("comment")]
        public HttpResponseMessage AddComment(
            int placeId,
            CommentModel commentModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();

                    using (context)
                    {
                        var user = UsersController.GetUserBySessionKey(context, sessionKey);
                        var place = context.Places.FirstOrDefault(p => p.Id == placeId);
                        if (place == null)
                        {
                            throw new ArgumentNullException("place", "A place with the specified ID does not exist.");
                        }

                        place.Comments.Add(new Comment()
                        {
                            Content = commentModel.Content,
                            Date = DateTime.Now,
                            Place = place,
                            User = user,
                        });
                        context.SaveChanges();

                        return this.Request.CreateResponse(HttpStatusCode.OK, commentModel);
                    }
                });

            return responseMsg;
        }

        // POST api/places/{placeId}/image
        [HttpPost]
        [ActionName("image")]
        public HttpResponseMessage AddImage(
            int placeId,
            ImageModel imageModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();

                    using (context)
                    {
                        var user = UsersController.GetUserBySessionKey(context, sessionKey);
                        var place = GetAllPlaces(context).FirstOrDefault(p => p.Id == placeId);
                        place.Images.Add(new Image()
                        {
                            Url = imageModel.ImageUrl,
                            Place = place,
                            User = user
                        });
                        context.SaveChanges();

                        return this.Request.CreateResponse(HttpStatusCode.NoContent);
                    }
                });

            return responseMsg;
        }

        private IQueryable<Place> GetAllPlaces(PlacesContext context)
        {
            return context.Places
                .Include(p => p.Town)
                .Include(p => p.Town.Country)
                .Include(p => p.Images)
                .Include(p => p.Comments)
                .Include(p => p.Comments
                    .Select(c => c.User));
        }
    }
}