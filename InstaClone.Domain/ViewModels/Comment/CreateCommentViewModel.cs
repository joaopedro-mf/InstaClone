using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.ViewModels.Comment
{
    public class CreateCommentViewModel
    {
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
