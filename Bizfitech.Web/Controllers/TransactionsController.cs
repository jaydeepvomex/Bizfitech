using Bizfitech.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace Bizfitech.Web.Controllers
{
    //[Authorize]
    [RoutePrefix("api/v1/transactions")]
    public class TransactionsController : ApiController
    {
        [HttpGet]
        [Route("{accountNumber}/{type}")]
        public async Task<HttpResponseMessage> RetrieveUserTransactions(int accountNumber, string type = "all")
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://fairwaybank-bizfitech.azurewebsites.net/");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/v1/accounts/" + accountNumber + "/transactions");

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
                    else if (type == "Credit")
                    {
                        var creditTransactions = transactions.Where(x => x.Type == "Credit").ToList();
                        return Request.CreateResponse(HttpStatusCode.OK, creditTransactions);
                    }
                    else if (type == "Debit")
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
