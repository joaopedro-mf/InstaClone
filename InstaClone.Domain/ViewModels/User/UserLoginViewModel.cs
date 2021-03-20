using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InstaClone.Domain.ViewModels.User
{
    public class UserLoginViewModel
    {
        [Required]
        public string IdentificationName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
