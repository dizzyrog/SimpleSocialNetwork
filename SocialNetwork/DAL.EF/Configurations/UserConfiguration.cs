using DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasKey(u=> u.UserIdentityId);
            builder
              .HasIndex(u => u.UserName)
              .IsUnique();

            //builder
            //    .HasIndex(u => u.Email)
            //    .IsUnique();
        }
    }
}
