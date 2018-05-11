using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizfitech.Web.ViewModels
{
    public class TransactionViewModel
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("transactionInformation")]
        public string TransactionInformation { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } // [0,1] credit or debit

        [JsonProperty("bookedDate")]
        public DateTime BookedDate { get; set; }

        public TransactionViewModel()
        {

        }
    }
}