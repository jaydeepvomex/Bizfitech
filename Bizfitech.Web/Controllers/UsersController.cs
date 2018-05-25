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
        private readonly IUsersRepository _userRepository;
        private readonly IBaseHttpClient _baseHttpClient;

        public UsersController(IUsersRepository userRepository, IBaseHttpClient baseHttpClient)
        {
            _userRepository = userRepository;
            _baseHttpClient = baseHttpClient;
        }

        // Add users via the API
        // POST api/users
        [HttpPost]
        [Route()]
        public HttpResponseMessage Post([FromBody]UserModel user)
        {
            var users = _userRepository.GetAllUsers();

            var userExist = users.Where(x => x.Id == user.Id).Any();

            if (userExist)
            {
                // return user already exist!
                var error = new ErrorViewModel();
                error.Message = "User already exist!";
                error.Status = 0;
                error.ErrorCode = 400;

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error.Message);
            }
            else
            {
                _userRepository.AddUser(user);
                return Request.CreateResponse(HttpStatusCode.Created, user);
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
        [Route("{accountNumber:int}/accounts")]
        public async Task<HttpResponseMessage> RetrieveUserAccountsAsync(int accountNumber)
        {
            var response = await _baseHttpClient.GetAsync("http://fairwaybank-bizfitech.azurewebsites.net/api/v1/accounts/" + accountNumber);

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
