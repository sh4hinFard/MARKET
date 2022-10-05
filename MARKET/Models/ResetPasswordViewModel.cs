using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MARKET.Models
{
    public class ResetPasswordViewModel
    {
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [MaxLength(200)]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [MaxLength(200)]
        [Compare("Password", ErrorMessage = "رمز عبور مغایرت دارد")]
        public string RePassword { get; set; }

        public string ActiveCode { get; set; }
    }
}
