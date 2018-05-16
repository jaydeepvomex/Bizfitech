using Bizfitech.Web.Interfaces;
using Bizfitech.Web.Models;
using Bizfitech.Web.Repository;
using Bizfitech.Web.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;

namespace Bizfitech.Web.Controllers
{
    //[Authorize]
    [RoutePrefix("api/v1/users")]
    public class UsersController : ApiController
    {
        IUsersRepository _userRepository;

        public UsersController(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Add users via the API
        // POST api/users
        [HttpPost]
        [Route()]
        public void Post([FromBody]UserModel user)
        {
            var users = _userRepository.GetAllUsers();

            var userExist = users.Where(x => x.Id == user.Id).Any();

            if (userExist)
            {
                // return user already exist!
            }
            else
            {
                _userRepository.AddUser(user);
                // return Created("api/users/", user);
            }
        }

        // Retrieve users via the API
        // GET api/users
        [Route("all")]
        public IEnumerable<UserModel> Get()
        {
            return _userRepository.GetAllUsers();
        }

        [HttpGet]
        [Route("accounts/{accountNumber}")]
        public async Task<HttpResponseMessage> RetrieveUserAccountsAsync(int accountNumber)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://fairwaybank-bizfitech.azurewebsites.net/");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string uri = "api/v1/accounts/" + accountNumber;

            HttpResponseMessage response = await client.GetAsync(uri);

            string json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var userAccounts = JsonConvert.DeserializeObject<AccountViewModel>(json);
                return Request.CreateResponse(HttpStatusCode.OK, userAccounts);
            }
            else
            {
                var errorMessage = JsonConvert.DeserializeObject<ErrorViewModel>(json);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errorMessage);
            }
        }
    }
}
