﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloggingSystem.Services.Controllers
{
    public class BaseController : ApiController
    {
        protected T ExceptionHandling<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }

            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }
    }
}
