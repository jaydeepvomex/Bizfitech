using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizfitech.Web.ViewModels
{
    public class OverdraftViewModel
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}