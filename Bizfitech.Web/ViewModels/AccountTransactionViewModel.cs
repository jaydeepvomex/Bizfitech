using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizfitech.Web.ViewModels
{
    public class AccountTransactionViewModel
    {
        public List<AccountViewModel> Accounts { get; set; }
        public List<TransactionViewModel> Transactions { get; set; }
    }
}