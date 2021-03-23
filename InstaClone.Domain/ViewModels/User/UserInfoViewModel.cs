using InstaClone.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InstaClone.Domain.ViewModels.User
{
    public class UserInfoViewModel
    {
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password{ get; set; }
        public string Photo { get; set; }
    }
}
