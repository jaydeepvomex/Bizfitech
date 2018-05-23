using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bizfitech.Web.Interfaces
{
    public interface ITransactionController
    {
        Task<HttpResponseMessage> RetrieveUserTransactions(int accountNumber, string type);
    }
}
