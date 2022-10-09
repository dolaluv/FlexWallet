using FlexWallet.Abstractions.Helpers;
using FlexWallet.Abstractions.Models;
using FlexWallet.Abstractions.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Abstractions.Services.Data
{
    public interface IAccountDataService
    {
        Task<StatusMessage> WalletRegistration(WalletUser walletUser);
        Task<(StatusMessage, WalletUserAccount)> WalletAuthenticateLoginUser(WalletUserLogin walletUserLogin);
    }
}
