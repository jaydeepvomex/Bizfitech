using System.Net.Http;

namespace Bizfitech.Web.Interfaces
{
    public interface IBaseHttpClient
    {
        HttpClient HttpClient();
    }
}
