using InstaClone.Domain.Entity;
using InstaClone.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaClone.Domain.Models
{
    public class Post : Publication
    {
        public Post() { }
        public Photo PostImage { get; set; }
        public Location Local { get; set; }
        public List<Comment> Comments { get; set; }
        public override void Validate()
        {
            AddErrors(PostImage.Errors);

            AddErrors(Local.Errors);
        }
    }
}
