using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizfitech.Web.ViewModels
{
    public class BalanceViewModel
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("type")]
        public Int32 Type { get; set; }

        [JsonProperty("overdraft")]
        public OverdraftViewModel Overdraft { get; set; }

        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }
    }
}