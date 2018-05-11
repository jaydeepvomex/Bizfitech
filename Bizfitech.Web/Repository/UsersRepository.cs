using Bizfitech.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bizfitech.Web.Models;
using System.Net.Http;
using System.Net;

namespace Bizfitech.Web.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public UserModel AddUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            IEnumerable<UserModel> users = new UserModel[] {
                new UserModel()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Joe",
                    LastName = "Bloggs",
                    AccountNumber = "01020304",
                    BankNumber = "010203"
                },
                new UserModel()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jerry",
                    LastName = "Disney",
                    AccountNumber = "02030405",
                    BankNumber = "020304"
                }
            };

            return users;
        }
    }
}