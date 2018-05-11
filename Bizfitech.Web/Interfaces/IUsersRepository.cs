using Bizfitech.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Bizfitech.Web.Interfaces
{
    public interface IUsersRepository
    {
        UserModel AddUser(UserModel userModel);
        IEnumerable<UserModel> GetAllUsers();
    }
}