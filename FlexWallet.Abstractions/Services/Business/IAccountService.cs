using FlexWallet.Abstractions.Helpers;
using FlexWallet.Abstractions.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Abstractions.Services.Business
{
    public interface IAccountService
    {
        Task<StatusMessage> WalletRegistration (WalletUserRegister walletUserRegister);
        Task<(StatusMessage, WalletUserDto)> WalletLogin(WalletUserLogin walletUserLogin );
    }
}
