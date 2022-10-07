using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWallet.Abstractions.Models.Dtos
{
    public class WalletUserLogin
    {
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
