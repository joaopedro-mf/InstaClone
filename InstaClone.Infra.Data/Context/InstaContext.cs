using InstaClone.Domain.Models;
using InstaClone.Domain.SeedWork;
using InstaClone.Domain.ValueObjects;
using InstaClone.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Infra.Data.Context
{
    public class InstaContext : DbContext
    {
        public InstaContext(DbContextOptions<InstaContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Error>();
            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Post>(new PostMap().Configure);
            modelBuilder.Entity<Comment>(new CommentMap().Configure);

        }
    }
}
