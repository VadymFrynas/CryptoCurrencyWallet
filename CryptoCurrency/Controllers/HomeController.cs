using CryptoCurrencyWallet.Data;
using CryptoCurrencyWallet.Data.Models;
using CryptoCurrencyWallet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Collections.Generic;
using System.Diagnostics;

namespace CryptoCurrencyWallet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ApplicationContext accountContext;
        private static readonly List<AccountProfile> accountProfiles;
        private static readonly IList<CommentModel> _comments;

        static HomeController()
        {
            accountProfiles = GetAccountProfiles();
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Daniel Lo Nigro",
                    Text = "Hello ReactJS.NET World!"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Pete Hunt",
                    Text = "This is one comment"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Jordan1 Walke",
                    Text = "This is *another* comment"
                },
            };
        }
        public HomeController(ILogger<HomeController> logger, ApplicationContext accountContext)
        {
            this.logger = logger;
            this.accountContext = accountContext;
            
        }

        [Route("accountProfile")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(accountProfiles);
        }

        [Route("accountProfile/new")]
        [HttpPost]
        public ActionResult AddComment(AccountProfile accountProfile)
        {
            // Create a fake ID for this comment
            accountProfile.Id = accountProfiles.Count + 1;
            accountProfiles.Add(accountProfile);
            return Content("Success :)");
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
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

        private static List<AccountProfile> GetAccountProfiles() => new List<AccountProfile>
        {
            new AccountProfile
            {
                Id = 1,
                FirstName = "SomeName1",
                LastName = "SomeLastName1",
            },
            new AccountProfile
            {
                Id = 2,
                FirstName = "SomeName2",
                LastName = "SomeLastName2",
               }
            };


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
