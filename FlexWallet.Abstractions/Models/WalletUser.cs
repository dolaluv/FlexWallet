using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Abstractions.Models
{
    public class WalletUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public string Email { get; set; }

    }
}
