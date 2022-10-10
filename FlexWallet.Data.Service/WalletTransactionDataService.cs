using FlexWallet.Abstractions.Helpers;
using FlexWallet.Abstractions.Models;
using FlexWallet.Abstractions.Services.Data;
using FlexWallet.Data.Service.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Data.Service
{
    public class WalletTransactionDataService : IWalletTransactionDataService
    {
        private readonly ApplicationDbContext _db;
        StatusMessage statusMessage = new();

        public WalletTransactionDataService(ApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<WalletUserAccount> GetWalletAccountBalance(string WallectAccountNumber)
        {
            try
            {
             return await  _db.WalletUserAccounts.FirstOrDefaultAsync(f => f.WalletAccountNumber == WallectAccountNumber);

            }
            catch(Exception ex)
            {
                throw new Exception($"Unable to load data {ex.Message}");
            }
          
        }

        public async  Task<StatusMessage> WalletFundTransfer(WalletFundTransaction walletFundTransaction)
        {
            try
            {
                var CreateWalleUser = await _db.WalletFundTransactions.AddAsync(walletFundTransaction);
                var result = await _db.SaveChangesAsync();
                if(result > 0)
                {
                    await FundTransfer(walletFundTransaction.AccountmNumber, walletFundTransaction.TransactionAccount, walletFundTransaction.TransactionAmount);
                   
                }
                statusMessage.Status = result > 0;
                statusMessage.Message = result > 0 ? $"Fund Transfer to {walletFundTransaction.TransactionAccountName} was successful " : "Fund Transfer Failed";

            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to load data {ex.Message}");
            }
            return statusMessage;
        }
        private async Task FundTransfer(string DebitAccountNumber, string CreditAccountNumber, double Amount)
        {
            var DebitAccount = await GetWalletAccountBalance(DebitAccountNumber);
            DebitAccount.WalletAccountBalance = DebitAccount.WalletAccountBalance - Amount;
            DebitAccount.WalletAccountTotalWithdrawFunds = DebitAccount.WalletAccountTotalWithdrawFunds + Amount;
            DebitAccount.LastUpdatedDate = DateTime.Now;
            _db.WalletUserAccounts.Update(DebitAccount);

            var AccounCreditted = await GetWalletAccountBalance(CreditAccountNumber);
            AccounCreditted.WalletAccountBalance = AccounCreditted.WalletAccountBalance + Amount;
            AccounCreditted.WalletAccountTotalSavedFunds = AccounCreditted.WalletAccountTotalSavedFunds + Amount;
            DebitAccount.LastUpdatedDate = DateTime.Now;
            _db.WalletUserAccounts.Update(AccounCreditted);

           await _db.SaveChangesAsync();
        }
       
    }
}
 