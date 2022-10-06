using FlexWallet.Abstractions.Helpers;
using FlexWallet.Abstractions.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Abstractions.Services.Business
{
    public interface IWalletTransactionService
    {
        Task<StatusMessage> FundTransfer(WalletFundTransferDto walletFundTransferDto);
        Task<WalletUserAccountDto> GetAccountBalance(string WallectAccountNumber);
    }
}
