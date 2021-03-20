using InstaClone.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaClone.Domain.Models
{
    public class Comment : Publication
    {
        public Post PostCommentary { get; set; }
        //TODO
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
