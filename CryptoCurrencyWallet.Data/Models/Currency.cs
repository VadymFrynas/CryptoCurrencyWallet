using System;

namespace CryptoCurrencyWallet.Data.Models
{
    public class Currency
    {
        public long Id { get; set; }

        public long Rank { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public string Slug { get; set; }

        public long IsActive { get; set; }

        public DateTimeOffset FirstHistoricalData { get; set; }

        public DateTimeOffset LastHistoricalData { get; set; }

        public Platform Platform { get; set; }
    }
}
