using InstaClone.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.ViewModels.User
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string NickName { get; set; }
        public string UserPhoto { get; set; }
    }
}
