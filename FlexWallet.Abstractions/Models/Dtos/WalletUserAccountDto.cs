using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Abstractions.Models.Dtos
{
    public class WalletUserAccountDto
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public double AccountBalance { get; set; }
        public int WalletUserId { get; set; }
        public int WalletUserAccountId { get; set; }
    }
}
