using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizfitech.Web.ViewModels
{
    public class AccountIdentifierViewModel
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("sortCode")]
        public string Sortcode { get; set; }
    }
}