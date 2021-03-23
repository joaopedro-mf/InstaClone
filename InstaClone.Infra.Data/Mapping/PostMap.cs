using InstaClone.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Infra.Data.Mapping
{
    class PostMap
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.CreationDate)
                .HasColumnType("Date");

            builder.Property(prop => prop.Description)
                .HasColumnType("varchar(255)");

            builder
                .HasOne<User>(prop => prop.User)
                .WithMany()
                .HasForeignKey(prop => prop.UserId);

            builder.OwnsOne(prop => prop.Local);

            builder.OwnsOne(prop => prop.PostImage);


        }
    }
}
