using DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.Configurations
{
     public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {

            builder
                .HasKey(f => new { f.FriendId, f.UserId });

            //builder
            //    .HasOne(f => f.User)
            //    .WithMany(u => u.Friends)
            //    .HasForeignKey(f => f.UserId);

            //builder
            //    .HasOne(f => f.Friend)
            //    .WithMany(u => u.Friendships)
            //    .HasForeignKey(f => f.FriendId);

            //builder
            //    .HasOne(f => f.Chat)
            //    .WithMany(c => c.Friendships)
            //    .HasForeignKey(f => f.ChatId);

        }
     }
}
