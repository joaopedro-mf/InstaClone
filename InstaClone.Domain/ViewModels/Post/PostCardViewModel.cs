using InstaClone.Domain.ValueObjects;
using InstaClone.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.ViewModels.Post
{
    public class PostCardViewModel
    {
        public int PostId { get; set; }
        public string Photo { get; set; }
    }
}
