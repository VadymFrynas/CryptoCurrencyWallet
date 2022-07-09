using System;

namespace CryptoCurrency.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public DateTime Time { get; set; }

        public Currency Currency { get; set; }
    }
}
