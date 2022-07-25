namespace CryptoCurrencyWallet.Data.Models
{
    public class MarketCapResponse
    {
        public Currency[] Currencies { get; set; }

        public Status Status { get; set; }
    }
}
