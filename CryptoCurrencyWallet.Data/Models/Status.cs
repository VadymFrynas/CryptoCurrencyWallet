using System;

namespace CryptoCurrencyWallet.Data.Models
{
    public partial class Status
    {
        public DateTimeOffset Timestamp { get; set; }

        public long ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public long Elapsed { get; set; }

        public long CreditCount { get; set; }
    }
}
