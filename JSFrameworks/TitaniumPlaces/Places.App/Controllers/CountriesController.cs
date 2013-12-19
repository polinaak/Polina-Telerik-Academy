using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Places.Models;
using Places.Data;
using System.Web.Http.ValueProviders;
using Places.App.Attributes;
using Places.App.Models;

namespace Places.App.Controllers
{
    public class CountriesController : BaseApiController
    {
        // GET api/countries
        public HttpResponseMessage GetCountries([ValueProvider(typeof(HeaderValueProviderFactory<string>))]
                                                string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();
                    UsersController.GetUserBySessionKey(context, sessionKey);
                    var countriesModel = context.Countries
                                                .Select(c => new CountrySmallModel()
                                                       {
                                                           Id = c.Id,
                                                           Name = c.Name
                                                       });

                    return this.Request.CreateResponse(HttpStatusCode.OK, countriesModel);
                });

            return responseMessage;
        }

        // GET api/countries/{id}
        public HttpResponseMessage GetCountry(
            int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new PlacesContext();
                    using (context)
                    {
                        UsersController.GetUserBySessionKey(context, sessionKey);
                        Country country = context.Countries.Find(id);
                        if (country == null)
                        {
                            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                        }

                        var countryModel = new CountryFullModel()
                        {
                            Towns = country.Towns.Select(
                                c => new TownModel()
                                {
                                    CountryId = c.Country.Id,
                                    Id = c.Id,
                                    Name = c.Name
                                }),
                            Id = country.Id,
                            Name = country.Name
                        };

                        return this.Request.CreateResponse(HttpStatusCode.OK, countryModel);
                    }
                });

            return responseMessage;
        }

        // POST api/Country
        public HttpResponseMessage PostCountry(
            CountrySmallModel countryModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMessage = PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();
                    var country = new Country()
                    {
                        Name = countryModel.Name,
                        Id = countryModel.Id
                    };

                    if (!context.Countries.Any(c => c.Name.ToLower() == countryModel.Name.ToLower()))
                    {
                        context.Countries.Add(country);
                        context.SaveChanges();
                    }

                    countryModel.Id = country.Id;
                    return this.Request.CreateResponse(HttpStatusCode.Created, countryModel);
                });

            return responseMessage;
        }
    }
}