using InstaClone.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaClone.Domain.Models
{
    public class Comment : Publication
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        //TODO
        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
