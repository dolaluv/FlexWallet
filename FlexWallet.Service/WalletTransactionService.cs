﻿
using AutoMapper;
using FlexWallet.Abstractions.Helpers;
using FlexWallet.Abstractions.Models;
using FlexWallet.Abstractions.Models.Dtos;
using FlexWallet.Abstractions.Services.Business;
using FlexWallet.Abstractions.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Data.Service
{
    public class WalletTransactionService : IWalletTransactionService
    {
      private  readonly IWalletTransactionDataService walletTransactionDataService;
      private readonly IMapper _mapper;

        public WalletTransactionService(IWalletTransactionDataService walletTransactionDataService, IMapper mapper)
        {
            this.walletTransactionDataService = walletTransactionDataService ?? throw new ArgumentNullException(nameof(walletTransactionDataService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<StatusMessage> FundTransfer(WalletFundTransferDto walletFundTransferDto)
        {
            var getAccountBalance = await GetAccountBalance(walletFundTransferDto.AccountmNumber);

            if(getAccountBalance == null || getAccountBalance?.AccountBalance < walletFundTransferDto?.TransactionAmount )
            {


                return new StatusMessage
                {
                    Status= false,
                    Message = getAccountBalance != null? $"insufficient funds" : "Un able to verify accoun Number"
                };
            }
            var walletFundTransaction = _mapper.Map<WalletFundTransferDto, WalletFundTransaction>(walletFundTransferDto);
            return await this.walletTransactionDataService.WalletFundTransfer(walletFundTransaction);
        }

        public async Task<WalletUserAccountDto> GetAccountBalance(string WallectAccountNumber)
        {
           var walletAccount =   await this.walletTransactionDataService.GetWalletAccountBalance(WallectAccountNumber);
            if (walletAccount == null)
                return null;
            return new WalletUserAccountDto
            {
                AccountName =  $"{walletAccount?.walletUser?.FirstName}  {walletAccount?.walletUser?.FirstName}",
                AccountNumber = WallectAccountNumber,
                AccountBalance = walletAccount.WalletAccountBalance

            };
        }
    }
}
