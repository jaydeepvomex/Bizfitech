using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizfitech.Web.ViewModels
{
    public class ErrorViewModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("status")]
        public Int32 Status { get; set; }

        [JsonProperty("errorCode")]
        public Int64 ErrorCode { get; set; }
    }
}