﻿using FlexWallet.Abstractions.Helpers;
using FlexWallet.Abstractions.Models;
using FlexWallet.Abstractions.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Data.Service
{
    public class AccountDataService : IAccountDataService
    {
        public Task<StatusMessage> WalletRegistration(WalletUser walletUser)
        {
            throw new NotImplementedException();
        }
    }
}
