using FlexWallet.Abstractions.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Data.Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<WalletUser> WalletUsers { get; set; }
        public DbSet<WalletUserAccount>  WalletUserAccounts { get; set; }
        public DbSet<WalletFundTransaction> WalletFundTransactions { get; set; }
    }
}
