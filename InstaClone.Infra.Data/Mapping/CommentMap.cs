using InstaClone.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Infra.Data.Mapping
{
    class CommentMap
    {

        public void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.CreationDate)
                .IsRequired()
                .HasColumnType("Date");

            builder.Property(prop => prop.Description)
                .HasColumnType("varchar(255)");

        }
    }

}
