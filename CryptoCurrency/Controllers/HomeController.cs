using CryptoCurrency.Data;
using CryptoCurrency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCurrency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly AccountContext accountContext;

        public HomeController(ILogger<HomeController> logger, AccountContext accountContext)
        {
            this.logger = logger;
            this.accountContext = accountContext;
        }

        public IActionResult Index()
        {
            var r = GetAccountProfiles();
            ViewBag.AccountProfiles = GetAccountProfiles();
            ViewBag.Currencies = GetCurrencies();
            ViewBag.EarnItems = GetEarnItems();
            ViewBag.Transactions = GetTransactions();
            ViewBag.Wallets = GetWallets();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<AccountProfile> GetAccountProfiles() => new List<AccountProfile>
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

        private List<Currency> GetCurrencies() => new List<Currency>
        {
            new Currency
            {
                Id = 1,
                WorldRank = 1,
                MarketCap = 100000,
                Name = "Bitcoin",
                Price = 22000,
                LinkToBio = "https://coinmarketcap.com/currencies/bitcoin/"
            },
            new Currency
            {
                Id = 2,
                WorldRank = 2,
                MarketCap = 100000,
                Name = "Ethereum",
                Price = 1300,
                LinkToBio = "https://coinmarketcap.com/currencies/ethereum/"
            }
        };

        private List<EarnItem> GetEarnItems() => new List<EarnItem>
        {
            new EarnItem
            {
                Id = 1,
                Currency = new Currency(){Name = "Currency1" },
                EarnTime = 30,
                Percentage = 15,
                StartingDate = DateTime.Now,
            },
            new EarnItem
            {
                Id = 2,
                Currency = new Currency(){Name = "Currency2" },
                EarnTime = 60,
                Percentage = 25,
                StartingDate = DateTime.Now,
            }
        };

        private List<Transaction> GetTransactions() => new List<Transaction>
        {
            new Transaction
            {
                Id = 1,
                Currency = new Currency(){Name = "Currency1" },
                Amount = 100,
                Time = DateTime.Now
            },new Transaction
            {
                Id = 1,
                Currency = new Currency(){Name = "Currency2" },
                Amount = 100,
                Time = DateTime.Now
            }
        };

        private List<Wallet> GetWallets() => new List<Wallet>
        {
            new Wallet
            {
                Id = 1,
                Profile = new AccountProfile(){FirstName = "FirstName1" },
                ProfileCurrencies = GetCurrencies(),
                Earn = GetEarnItems()
            },
            new Wallet
            {
                Id = 1,
                Profile = new AccountProfile(){FirstName = "FirstName2" },
                ProfileCurrencies = GetCurrencies(),
                Earn = GetEarnItems()
            }
        };
    }
}
