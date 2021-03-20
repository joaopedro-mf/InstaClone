using InstaClone.Domain.Models;
using InstaClone.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>

    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(prop => prop.UserId);

            builder.Property(prop => prop.NickName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.OwnsOne(prop => prop.Password) ;

            builder.OwnsOne(prop => prop.UserPhoto);
        
            builder
                .HasMany(prop => prop.MyPosts)
                .WithOne()
                .HasForeignKey(x => x.Id);

            builder
                .HasMany(prop => prop.Followers)
                .WithMany(prop => prop.Following);

        }
    }
}
