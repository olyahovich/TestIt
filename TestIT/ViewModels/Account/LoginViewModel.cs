﻿using System.ComponentModel.DataAnnotations;
using TestIT.Web.Api;

namespace TestIT.Web.ViewModels.Account
{
    public class LoginViewModel: ForgotPasswordViewModel
    {

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}