using Places.App.Attributes;
using Places.App.Models;
using Places.Data;
using Places.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace Places.App.Controllers
{
    public class TownsController : BaseApiController
    {
        #region town post json
        /*
          {
            "name": "Ruse",
            "countryId": "1"
            }
         */
        #endregion
        // POST api/towns
        [HttpPost]
        public HttpResponseMessage PostTown(TownModel model, [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
                                               string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new PlacesContext();

                    using (context)
                    {
                        Town townEntity = new Town();
                        CountrySmallModel countryModel = new CountrySmallModel();
                        var countryEntity = context.Countries.Where(c => c.Id == model.CountryId).FirstOrDefault();

                        if (countryEntity != null)
                        {
                            countryModel.Id = countryEntity.Id;
                            countryModel.Name = countryEntity.Name;
                            townEntity.Country = countryEntity;
                        }
                        else
                        {
                            throw new ArgumentException("No town with this id was found");
                        }

                        townEntity.Name = model.Name;
                        context.Towns.Add(townEntity);
                        context.SaveChanges();

                        // get the id from the entity added in the db
                        model.Id = townEntity.Id;

                        return this.Request.CreateResponse(HttpStatusCode.Created, model);
                    }
                }
            );

            return responseMsg;
        }

        // This method is not needed since there is the same in CountriesController
        // GET api/towns/
        //[HttpGet]
        //public IQueryable<TownModel> GetAll([ValueProvider(typeof(HeaderValueProviderFactory<string>))]
        //                                      string sessionKey)
        //{
        //    var responseMsg = this.PerformOperationAndHandleExceptions(
        //        () =>
        //        {
        //            var context = new PlacesContext();
        //            var townEntities = context.Towns;

        //            var townModels =
        //                from townEntity in townEntities
        //                select new TownModel()
        //                {
        //                    Id = townEntity.Id,
        //                    Name = townEntity.Name,
        //                    CountryId = townEntity.Country.Id
        //                };

        //            return townModels;
        //        }
        //    );

        //    return responseMsg;
        //}

        // GET api/towns/{townId}
        
        [HttpGet]
        public HttpResponseMessage GetTownById(int townId, [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
                                              string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new PlacesContext();

                    using (context)
                    {
                        var townEntities = context.Towns;
                        var townEntity = townEntities.Where(t => t.Id == townId).FirstOrDefault();

                        var townModel = new TownModelFull();
                        townModel.Id = townEntity.Id;
                        townModel.Name = townEntity.Name;
                        townModel.Country = new CountrySmallModel()
                        {
                            Id = townEntity.Country.Id,
                            Name = townEntity.Country.Name
                        };
                        townModel.Places =
                            from placeEntity in townEntity.Places
                            select new PlaceModelSmall()
                            {
                                Id = placeEntity.Id,
                                Name = placeEntity.Name,
                                Content = placeEntity.Content
                            };

                        return this.Request.CreateResponse(HttpStatusCode.OK, townModel);
                    }
                }
            );

            return responseMsg;
        }

    }
}
