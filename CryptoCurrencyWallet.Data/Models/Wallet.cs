using System.Collections.Generic;

namespace CryptoCurrency.Models
{
    public class Wallet
    {
        public int Id { get; set; }

        public AccountProfile Profile { get; set; }

        public List<Currency> ProfileCurrencies { get; set; }

        public List<EarnItem> Earn {get; set; }
    }
}
