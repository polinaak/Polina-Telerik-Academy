using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Bank.Data;
using Bank.Models;
using Bank.Services.Models;
using BloggingSystem.Services.Attributes;

namespace Bank.Services.Controllers
{
    public class AccountsController : BaseController
    {
        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage PostCreateAccount(AccountModel accountModel,
             [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.ExceptionHandling(
           () =>
           {
               var context = new BankContext();
               using (context)
               {
                   var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                   if (user == null)
                   {
                       throw new InvalidOperationException("Invalid username or password!");
                   }

                  
                   var post = new Account()
                   {
                        AccountNumber = accountModel.AccountNumber,
                        Balance = accountModel.Balance,
                        User = user
                   };

                   context.Accounts.Add(post);
                   context.SaveChanges();

                   var response =
                       this.Request.CreateResponse(HttpStatusCode.Created);
                   return response;
               }
           });

            return responseMsg;
        }
    }
}
