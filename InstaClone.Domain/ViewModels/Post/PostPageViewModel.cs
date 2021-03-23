using InstaClone.Domain.ViewModels.Comment;
using InstaClone.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.ViewModels.Post
{
    public class PostPageViewModel
    {
        public int PostId { get; set; }
        public string Location { get; set; }
        public string Photo { get; set; }
        public string Descritpion { get; set; }
        public UserIconViewModel User { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
