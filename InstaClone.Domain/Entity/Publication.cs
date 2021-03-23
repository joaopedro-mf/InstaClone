using InstaClone.Domain.Models;
using InstaClone.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.Entity
{
    public abstract class Publication : Notification
    {
        //TODO
        //Adicionar Like

        public int Id { get; set; }
        public DateTime CreationDate { get { return DateTime.Now; } set { this.CreationDate = value; } }
        public string Description { get; set; }
        public int UserId{get;set;}
        public User User { get; set; }
        public abstract void Validate();
    }
}
