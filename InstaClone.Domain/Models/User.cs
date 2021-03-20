using InstaClone.Domain.SeedWork;
using InstaClone.Domain.ValueObjects;
using InstaClone.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstaClone.Domain.Models
{
    public class User : Notification
    {
        public int UserId { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public User()  { }

        public User(string email, string nick, Password pass)
        {
            NickName = nick;
            Email = email;
            Password = pass;
        }
        public User(string email, string nick, string pass)
        {
            NickName = nick;
            Email = email;
            Password = new Password(pass);
        }
        public Password Password { get; set; }
        public List<User> Followers { get; set; }
        public List<User> Following { get; set; }
        public List<Post> MyPosts { get; set; }
        public List<Comment> MyCommments { get; set; }
        public Photo UserPhoto { get; set; }
        public void Validate()
        {
            AddErrors(Password.Errors);

            AddErrors(UserPhoto.Errors);

            if (NickName.Length < 6 || NickName.Length > 15)
                AddError(new Error("NickName", "Nickname invalido."));

            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                if (addr.Address != Email) AddError(new Error("Email", "Email invalido."));

            }
            catch
            {
                AddError(new Error("Email", "Email Incorreto"));
            }


        }

    }
}
