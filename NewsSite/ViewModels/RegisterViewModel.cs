using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(25, ErrorMessage ="Name can not be longer than 25 characters")]
        [MinLength(3, ErrorMessage = "Name can not be less than 3 characters")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
