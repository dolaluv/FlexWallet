
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

        public WalletTransactionService(IWalletTransactionDataService walletTransactionDataService)
        {
            this.walletTransactionDataService = walletTransactionDataService ?? throw new ArgumentNullException(nameof(walletTransactionDataService));
        }


    }
}
