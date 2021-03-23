using InstaClone.Domain.ValueObjects;
using InstaClone.Domain.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.ViewModels.User
{
    public class UserPageViewModel
    {
        public int UserId { get; set; }
        public string NickName { get; set; }
        public string UserPhoto { get; set; }
        public List<PostCardViewModel> PostViewModel { get; set; }
        public int NumberFollowers { get; set; }
        public int NumberPosts { get; set; }
        public int NumberFollowing{ get; set; }
    }
}
