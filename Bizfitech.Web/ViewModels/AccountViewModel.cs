using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizfitech.Web.ViewModels
{
    public class AccountViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("identifier")]
        public AccountIdentifierViewModel Identifier { get; set; }
    }
}