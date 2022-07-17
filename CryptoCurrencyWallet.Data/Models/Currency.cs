namespace CryptoCurrency.Models
{
    public class Currency
    {
        public int Id { get; set; }

        public int WorldRank { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public double Price { get; set; }

        public double MarketCap { get; set; }

        public string LinkToBio { get; set; }
    }
}
