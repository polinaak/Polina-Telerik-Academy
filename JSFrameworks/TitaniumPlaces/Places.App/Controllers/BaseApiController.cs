namespace Places.App.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        protected T PerformOperationAndHandleExceptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (ArgumentNullException e)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
                throw new HttpResponseException(errResponse);
            }
            catch (Exception e)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
                throw new HttpResponseException(errResponse);
            }
        }
    }
}
