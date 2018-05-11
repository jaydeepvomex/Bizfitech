using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizfitech.Web.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BankNumber { get; set; }
        public string AccountNumber { get; set; }
    }
}