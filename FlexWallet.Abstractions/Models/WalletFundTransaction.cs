using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Abstractions.Models
{
    public class WalletFundTransaction
    {
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public string AccountmNumber { get; set; }
        public double TransactionAmount { get; set; }
        public string TransactionAccount { get; set; }
        public string TransactionAccountName { get; set; }
        public string TransactionBankName { get; set; }
        public string TransactionStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        [ForeignKey("WalletUserAccount")]
        public int WalletUserAccountId { get; set; }
        public WalletUserAccount wallet { get; set; }

        [ForeignKey("WalletUser")]
        public int WalletUserId { get; set; }
        public WalletUser walletUser { get; set; }
    }
}
