using Bizfitech.Web.Core;
using Bizfitech.Web.Interfaces;
using Bizfitech.Web.ViewModels;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Bizfitech.Web.Controllers
{
    //[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/transactions")]
    public class TransactionsController : ApiController, ITransactionController
    {
        private IBaseHttpClient _baseHttpClient;

        public TransactionsController(IBaseHttpClient baseHttpClient)
        {
            _baseHttpClient = baseHttpClient;
        }

        [HttpGet]
        [Route("{accountNumber}/{type:alpha}")]
        public async Task<HttpResponseMessage> RetrieveUserTransactionsAsync(int accountNumber, string type = "all")
        {
           var response = await _baseHttpClient.GetAsync("http://fairwaybank-bizfitech.azurewebsites.net/api/v1/accounts/" + accountNumber + "/transactions");

           var userTransactions = await response.Content.ReadAsStringAsync();

            if (userTransactions != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    var transactions = JsonConvert.DeserializeObject<List<TransactionViewModel>>(userTransactions);

                    if (type == "all")
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, transactions);
                    }
                    else if (string.Equals(type, "credit", StringComparison.OrdinalIgnoreCase))
                    {
                        var creditTransactions = transactions.Where(x => x.Type == "Credit").ToList();
                        return Request.CreateResponse(HttpStatusCode.OK, creditTransactions);
                    }
                    else if (string.Equals(type, "debit", StringComparison.OrdinalIgnoreCase))
                    {
                        var debitTransactions = transactions.Where(x => x.Type == "Debit").ToList();
                        return Request.CreateResponse(HttpStatusCode.OK, debitTransactions);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                }
                else
                {
                    var errorMessage = JsonConvert.DeserializeObject<ErrorViewModel>(userTransactions);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorMessage);
                }
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
