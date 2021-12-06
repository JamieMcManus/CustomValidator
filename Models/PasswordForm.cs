using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomValidator.Models
{
    public class PasswordForm
    {
        [Required]
        [Display(Name = "Current Password")]
        public string Password { get; set; }

        [Required]
        [NotEqualto("Password")]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

    }
}
