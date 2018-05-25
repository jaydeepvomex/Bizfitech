using Bizfitech.Web.Controllers;
using Bizfitech.Web.Repository;
using Moq;
using NUnit.Framework;

namespace Bizfitech.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        [SetUp]
        public void Setup()
        {
            //var users = new Mock<IUsersController>(MockBehavior.Strict);  
        }

        [Test]
        public void UsersController_Get_ReturnsUsersIsNotNull()
        {
            //UsersController usersController = new UsersController(new UsersRepository());
            //var users = usersController.Get();

            //Assert.IsNotNull(users);
        }
    }
}
