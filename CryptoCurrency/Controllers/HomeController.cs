using CryptoCurrency.Data;
using CryptoCurrency.Models;
using CryptoCurrencyWallet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CryptoCurrency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ApplicationContext accountContext;

        public HomeController(ILogger<HomeController> logger, ApplicationContext accountContext)
        {
            this.logger = logger;
            this.accountContext = accountContext;
        }

        public IActionResult Index()
        {
            //var r = GetAccountProfiles();
            //ViewBag.AccountProfiles = GetAccountProfiles();
            //ViewBag.EarnItems = GetEarnItems();
            //ViewBag.Transactions = GetTransactions();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //private List<AccountProfile> GetAccountProfiles() => new List<AccountProfile>
        //{
        //    new AccountProfile
        //    {
        //        Id = 1,
        //        FirstName = "SomeName1",
        //        LastName = "SomeLastName1",
        //    },
        //    new AccountProfile
        //    {
        //        Id = 2,
        //        FirstName = "SomeName2",
        //        LastName = "SomeLastName2",
        //       }
        //    };


        //private List<EarnItem> GetEarnItems() => new List<EarnItem>
        //{
        //    new EarnItem
        //    {
        //        Id = 1,
        //        Currency = new Currency(){Name = "Currency1" },
        //        EarnTime = 30,
        //        Percentage = 15,
        //        StartingDate = DateTime.Now,
        //    },
        //    new EarnItem
        //    {
        //        Id = 2,
        //        Currency = new Currency(){Name = "Currency2" },
        //        EarnTime = 60,
        //        Percentage = 25,
        //        StartingDate = DateTime.Now,
        //    }
        //};

        //private List<Transaction> GetTransactions() => new List<Transaction>
        //{
        //    new Transaction
        //    {
        //        Id = 1,
        //        Currency = new Currency(){Name = "Currency1" },
        //        Amount = 100,
        //        Time = DateTime.Now
        //    },new Transaction
        //    {
        //        Id = 1,
        //        Currency = new Currency(){Name = "Currency2" },
        //        Amount = 100,
        //        Time = DateTime.Now
        //    }
        //};

    }
}
