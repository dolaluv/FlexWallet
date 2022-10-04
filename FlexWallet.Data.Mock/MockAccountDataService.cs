using FlexWallet.Abstractions.Helpers;
using FlexWallet.Abstractions.Models;
using FlexWallet.Abstractions.Services.Data;
using FlexWallet.Data.Mock.Helper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Data.Mock
{
    public class MockAccountDataService : IAccountDataService
    {
        public Task<StatusMessage> WalletRegistration(WalletUser walletUser)
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
