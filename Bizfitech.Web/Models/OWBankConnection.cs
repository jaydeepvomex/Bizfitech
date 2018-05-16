using Bizfitech.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bizfitech.Web.Models
{
    public class OWBankConnection : IBankConnector
    {
        public Task<HttpResponseMessage> RetrieveTransactions(int accountNumber, string type)
        {
            throw new NotImplementedException();
        }
    }
}