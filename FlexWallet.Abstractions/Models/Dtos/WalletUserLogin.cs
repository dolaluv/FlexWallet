using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Abstractions.Models.Dtos
{
    public class WalletUserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
