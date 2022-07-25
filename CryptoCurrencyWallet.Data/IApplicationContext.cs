using CryptoCurrencyWallet.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoCurrencyWallet.Data
{
    public interface IApplicationContext
    {
        DbSet<AccountProfile> Accounts { get; set; }
        DbSet<Currency> Currencies { get; set; }
        DbSet<EarnItem> EarnItems { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<Wallet> Wallets { get; set; }
    }
}
