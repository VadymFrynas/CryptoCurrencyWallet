using System;
using System.Collections.Generic;

using CryptoCurrency.Models;

using Microsoft.EntityFrameworkCore;

namespace CryptoCurrency.Data
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<AccountProfile> Accounts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<EarnItem> EarnItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
