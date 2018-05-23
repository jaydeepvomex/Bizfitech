using Bizfitech.Web.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizfitech.Tests
{
    [TestFixture]
    public class TransactionControllerTests
    {
        [SetUp]
        public void Setup()
        {
            var client = new Mock<IBaseHttpClient>(MockBehavior.Strict);
            var transactionsController = new Mock<ITransactionController>(MockBehavior.Strict);
        }
    }
}
