using System.Net.Http;
using System.Threading.Tasks;

namespace Bizfitech.Web.Interfaces
{
    public interface IBaseHttpClient
    {
        HttpClient HttpClient();
        HttpResponseMessage Get(string url);
        HttpResponseMessage Post(string url, HttpContent content);
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    }
}
