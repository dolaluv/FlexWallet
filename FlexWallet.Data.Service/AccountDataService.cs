using FlexWallet.Abstractions.Helper;
using FlexWallet.Abstractions.Helpers;
using FlexWallet.Abstractions.Models;
using FlexWallet.Abstractions.Models.Dtos;
using FlexWallet.Abstractions.Services.Data;
using FlexWallet.Data.Service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Data.Service
{
    public class AccountDataService : IAccountDataService
    {
        private readonly ApplicationDbContext _db;
        public AppSettings appSettings;
        StatusMessage statusMessage = new();

        public AccountDataService(ApplicationDbContext db, AppSettings appSettings)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            this.appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
        }

        public async Task<(StatusMessage, WalletUserAccount)> WalletAuthenticateLoginUser(WalletUserLogin walletUserLogin)
        {
            try
            {
                var UserExist = _db.WalletUsers.FirstOrDefault(f => f.Email.ToLower().Trim() == walletUserLogin.Email.ToLower().Trim() && f.Password.Trim() == walletUserLogin.Password.Trim());
                statusMessage.Status = UserExist != null;
                statusMessage.Message = UserExist != null ? "User Login Successfully " : "Invalid Email/Password" ;
                
                    var GetWalletAccount = UserExist != null ? await _db.WalletUserAccounts
                  .Include(u => u.walletUser)
                  .Where(em => em.WalletUserId == UserExist.Id)
                  .FirstOrDefaultAsync(): null;
               
                return (statusMessage, GetWalletAccount);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to load data {ex.Message}");
            }
        }

        public async Task<StatusMessage> WalletRegistration(WalletUser walletUser)
        {
            try
            {
                var CheckIfMailExist = _db.WalletUsers.FirstOrDefault(f=> f.Email.ToLower().Trim() == walletUser.Email.ToLower().Trim());
                if(CheckIfMailExist != null)
                {

                    statusMessage.Status = false;
                    statusMessage.Message = $"A user with this mail {walletUser.Email} already exist";
                    return statusMessage;
                }
               var CreateWalleUser = await  _db.WalletUsers.AddAsync(walletUser);
                var result = await _db.SaveChangesAsync();
                if(result > 0)
                {
                    statusMessage.Status = true;
                    var GetAccount = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                    WalletUserAccount walletUserAccount = new WalletUserAccount
                    {
                        WalletAccountNumber = GetAccount,
                        WalletAccountBalance = appSettings.DefaultFund,
                        WalletAccountOpeningBalance = appSettings.DefaultFund,
                        WalletAccountTotalSavedFunds = appSettings.DefaultFund,
                        WalletAccountTotalWithdrawFunds = 0,
                        WalletUserId = CreateWalleUser.Entity.Id,
                        CreatedBy = ""
                    };

                    var CreateWalletAccount = await _db.WalletUserAccounts.AddAsync(walletUserAccount);
                    var checkAccountCreate = await _db.SaveChangesAsync();
                    
                    statusMessage.Message = checkAccountCreate > 0 ? $"User Account Registered Successfully. Wallet Account Number {GetAccount} " : "Unable to generate Account Nuber for User";
                    

                    return statusMessage;
                }

                statusMessage.Status = false;
                statusMessage.Message = "Uable to regster user suceesfully";

            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to load data {ex.Message}");
            }
            return statusMessage;
        }
    }
}
