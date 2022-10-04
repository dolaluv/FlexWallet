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
    public class AccountService : IAccountService
    {
        private readonly IAccountDataService accountDataService;
        private readonly IMapper _mapper;

        public AccountService(IAccountDataService accountDataService, IMapper mapper)
        {
            this.accountDataService = accountDataService ?? throw new ArgumentNullException(nameof(accountDataService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<StatusMessage> WalletRegistration(WalletUserDto walletUserDto)
        {
            var walletUser = _mapper.Map<WalletUserDto, WalletUser>(walletUserDto);
            return await this.accountDataService.WalletRegistration(walletUser);
        }
    }
}
