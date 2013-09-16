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
    public class TransactionsController : BaseController
    {
        [HttpGet]
        public IQueryable<TransactionModel> GetAll(
             [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.ExceptionHandling(
                () =>
                {
                    var context = new BankContext();

                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password!");
                    }

                    var transactionsEntities = context.Transactions
                        .Where(t => t.User.Id == user.Id);
                    var models =
                        (from tranEntity in transactionsEntities
                         select new TransactionModel()
                         {
                             TransactionType = tranEntity.TransactionType,
                             Date = tranEntity.Date,
                             Sum = tranEntity.Sum
                         });
                    return models.OrderByDescending(t => t.Date);
                });
            return responseMsg;
        }

        [HttpPut]
        [ActionName("deposit")]
        public HttpResponseMessage PutDeposit(TransactionModel transactionModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new BankContext();
            using (context)
            {
                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                var entityAccount = context.Accounts.FirstOrDefault(a => a.User.Id == user.Id);

                entityAccount.Balance = entityAccount.Balance + transactionModel.Sum;

                var newTransaction = new Transaction()
                {
                   Date = DateTime.Now,
                   Sum = transactionModel.Sum,
                   User = entityAccount.User,
                   Account = entityAccount,
                   Id = entityAccount.Id,
                   TransactionType = transactionModel.TransactionType
                };

                context.Transactions.Add(newTransaction);
                context.SaveChanges();

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpPut]
        [ActionName("withdraw")]
        public HttpResponseMessage PutWithdraw(TransactionModel transactionModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new BankContext();
            using (context)
            {

                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                var entityAccount = context.Accounts.FirstOrDefault(a => a.User.Id == user.Id);


                if (entityAccount.Balance > transactionModel.Sum)
                {
                    entityAccount.Balance = entityAccount.Balance - transactionModel.Sum;
                }
                else 
                {
                    throw new InvalidOperationException("There isn`t enough money!");
                }

                var newTransaction = new Transaction()
                {
                    Date = DateTime.Now,
                    Sum = transactionModel.Sum,
                    User = entityAccount.User,
                    Account = entityAccount,
                    Id = entityAccount.Id,
                    TransactionType = transactionModel.TransactionType
                };

                context.Transactions.Add(newTransaction);
                context.SaveChanges();

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
        }

    }
}
