using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Abstractions.Models.Dtos
{
    public class WalletFundTransferDto
    {
        public string TransactionType { get; set; }
        public string AccountmNumber { get; set; }
        public double TransactionAmount { get; set; }
        public string TransactionAccount { get; set; }
        public string TransactionAccountName { get; set; }
        public string TransactionBankName { get; set; }
        public string TransactionStatus { get; set; }
        public string CreatedBy { get; set; } 
      
    }
}
