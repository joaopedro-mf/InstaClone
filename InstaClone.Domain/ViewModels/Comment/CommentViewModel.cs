using InstaClone.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.ViewModels.Comment
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public UserViewModel UserAuthor { get; set; }
    }
}
