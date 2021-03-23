using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.ViewModels.Post
{
    public class CreatePostViewModel
    {
        public string Photo { get; set; }
        public string Location { get; set; }
        public string Descritpion { get; set; }
        public int UserId { get; set; }
    }
}
