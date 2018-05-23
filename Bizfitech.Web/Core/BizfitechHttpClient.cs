using Bizfitech.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace Bizfitech.Web.Core
{
    public class BizfitechHttpClient : IBaseHttpClient
    {
        public HttpClient HttpClient()
        {
            return new HttpClient();
        }
    }
}