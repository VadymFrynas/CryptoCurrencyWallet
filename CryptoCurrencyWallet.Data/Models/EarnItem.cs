using System;

namespace CryptoCurrencyWallet.Data.Models
{
    public class EarnItem
    {
        public int Id { get; set; }

        public Currency Currency { get; set; }

        public int EarnTime { get; set; }

        public DateTime StartingDate { get; set; }

        public int Percentage { get; set; }
    }
}
