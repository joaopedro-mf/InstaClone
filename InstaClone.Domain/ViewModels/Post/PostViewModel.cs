using InstaClone.Domain.ValueObjects;
using InstaClone.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.ViewModels.Post
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public UserViewModel UserAuthor { get; set; }
        public Photo Image { get; set; }
        public string CommentText { get; set; }
    }
}
