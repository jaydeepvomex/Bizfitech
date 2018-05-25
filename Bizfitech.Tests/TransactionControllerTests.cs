using Bizfitech.Web.Controllers;
using Bizfitech.Web.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bizfitech.Tests
{
    [TestFixture]
    public class TransactionControllerTests
    {
        private int accountNumber = 12345678;
        private const string typeAll = "all";
        private const string typeCredit = "Credit";
        private const string typeDebit = "Debit";

        [SetUp]
        public void Setup()
        {
            var clientMock = new Mock<IBaseHttpClient>(MockBehavior.Strict);
            var transactionsControllerMock = new Mock<ITransactionController>(MockBehavior.Strict);
        }

        [Test]
        public void RetrieveUserTransactions_ReturnsSuccessfullDataFromApi()
        {
            var clientMock = new Mock<IBaseHttpClient>(MockBehavior.Strict);
            var transactionsControllerMock = new Mock<ITransactionController>(MockBehavior.Strict);
            
            TransactionsController controller = new TransactionsController(clientMock.Object);

            clientMock.Setup(x => x.HttpClient()).Returns(new HttpClient()).Verifiable();

            //transactionsControllerMock.Setup(t => t.RetrieveUserTransactions(accountNumber, type))
        }

        [Test]
        public void RetrieveUserTransactions_ReturnsCreditTransactions()
        {

        }

        [Test]
        public void RetrieveUserTransactions_ReturnsDebitTransactions()
        {

        }
    }
}
