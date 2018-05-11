using Bizfitech.Web.Controllers;
using Bizfitech.Web.Repository;
using NUnit.Framework;

namespace Bizfitech.Tests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void UsersController_Get_ReturnsUsersIsNotNull()
        {
            UsersController usersController = new UsersController(new UsersRepository());
            var users = usersController.Get();

            Assert.IsNotNull(users);
        }
    }
}
