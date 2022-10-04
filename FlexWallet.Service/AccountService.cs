using FlexWallet.Abstractions.Services.Business;
using FlexWallet.Abstractions.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Data.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDataService accountDataService;

        public AccountService(IAccountDataService accountDataService)
        {
            this.accountDataService = accountDataService ?? throw new ArgumentNullException(nameof(accountDataService));
        }
    }
}
