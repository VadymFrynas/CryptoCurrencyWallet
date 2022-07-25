using CryptoCurrencyWallet.Data.Models;
using CryptoCurrencyWallet.Service.Interfaces;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json.Linq;

using System;
using System.Net;
using System.Web;

namespace CryptoCurrencyWallet.Service
{
    public class CurrencyServices : ICurrencyServices
    {
        private readonly IConfiguration config;
        private readonly string apiKey;
        public CurrencyServices(IConfiguration config) 
        { 
            this.config = config;
            apiKey = config["API_KEY"];
        }

        public async void GetInfoAboutAllCurrencies()
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/map");
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["sort"] = "cmc_rank";
            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", apiKey);
            client.Headers.Add("Accepts", "application/json");
            var resonse = await client.DownloadStringTaskAsync(URL.ToString());
            JObject jsonResponse = JObject.Parse(resonse);
            MarketCapResponse marketCapResponse = jsonResponse.ToObject<MarketCapResponse>();
        }

        public async void GetInfoAboutCurrencyByShortName()
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/map");
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["symbol"] = "USDT";
            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", apiKey);
            client.Headers.Add("Accepts", "application/json");
            var resonse = await client.DownloadStringTaskAsync(URL.ToString());
            JObject jsonResponse = JObject.Parse(resonse);
            MarketCapResponse marketCapResponse = jsonResponse.ToObject<MarketCapResponse>();
        }

    }
}
