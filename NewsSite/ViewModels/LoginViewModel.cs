using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email or name")]
        public string EmailOrName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
