using CryptoCurrencyWallet.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CryptoCurrencyWallet.Data;

namespace CryptoCurrency.Data
{
    public class ApplicationContext : IdentityDbContext<User>, IApplicationContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }


        public DbSet<AccountProfile> Accounts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<EarnItem> EarnItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
