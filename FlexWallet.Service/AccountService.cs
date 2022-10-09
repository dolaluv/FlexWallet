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

        public async Task<(StatusMessage, WalletUserDto)> WalletLogin(WalletUserLogin walletUserLogin)
        {
            var result = await this.accountDataService.WalletAuthenticateLoginUser(walletUserLogin); 
            var UserAccount = result.Item2 != null ? new WalletUserDto 
            {
                AccountNumber= result.Item2.WalletAccountNumber,
                Email = result.Item2.walletUser.Email,
                FirstName = result.Item2.walletUser.FirstName
            } : null;

            return (result.Item1, UserAccount);
        }

        public async Task<StatusMessage> WalletRegistration(WalletUserRegister walletUserRegister)
        {
            var walletUser = _mapper.Map<WalletUserRegister, WalletUser>(walletUserRegister);
            return await this.accountDataService.WalletRegistration(walletUser);
        }
    }
}
