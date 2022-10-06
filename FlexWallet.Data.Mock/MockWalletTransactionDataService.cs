using FlexWallet.Abstractions.Helpers;
using FlexWallet.Abstractions.Models;
using FlexWallet.Abstractions.Services.Data;
using FlexWallet.Data.Mock.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Data.Mock
{
    public class MockWalletTransactionDataService : IWalletTransactionDataService
    {
        public Task<WalletUserAccount> GetWalletAccountBalance(string WallectAccountNumber)
        {
            try
            {
                var result = ResourceHelper.GetObject<WalletUser>("WalletUsers.json", Constants.MockDataNamespace);
                return Task.FromResult(new WalletUserAccount());
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to load data {ex.Message}");
            }
        }

        public Task<StatusMessage> WalletFundTransfer(WalletFundTransaction walletFundTransaction)
        {
            try
            {
                var result = ResourceHelper.GetObject<WalletUser>("WalletUsers.json", Constants.MockDataNamespace);
                return Task.FromResult(new StatusMessage());
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to load data {ex.Message}");
            }
        }
    }
}
