using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Abstractions.Models
{
    public class WalletUserAccount
    {
        public int Id { get; set; }
        public string WalletAccountNumber { get; set; }
        public double WalletAccountBalance { get; set; }
        public double WalletAccountOpeningBalance { get; set; }
        public double WalletAccountTotalSavedFunds { get; set; }
        public double WalletAccountTotalWithdrawFunds { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
        [ForeignKey("WalletUser")]
        public int WalletUserId { get; set; }
        public WalletUser walletUser { get; set; }



    }
}
