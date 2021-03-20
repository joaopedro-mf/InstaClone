﻿using InstaClone.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InstaClone.Domain.ViewModels.User
{
    public class CreateUserViewModel
    {
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password{ get; set; }
        public string Photo_b64 { get; set; }
    }
}