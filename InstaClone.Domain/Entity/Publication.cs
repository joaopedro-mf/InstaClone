using InstaClone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.Entity
{
    public abstract class Publication
    {
        //TODO
        //Adicionar Like

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public int UserId{get;set;}
        public User User { get; set; }
        public abstract bool Validate();
    }
}
