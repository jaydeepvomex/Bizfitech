using Bizfitech.Web.Core;
using Bizfitech.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bizfitech.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransactionController _transactionsController;

        public HomeController()
        {
            _transactionsController = new TransactionsController(new BizfitechHttpClient());
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
