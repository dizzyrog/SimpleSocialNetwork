using DAL.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.DataSeeders
{
    public static class ChatSeeder
    {
        public static void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>().HasData(
               new Chat
               {
                   Id = 1,
                   FriendshipId = 1,
               },
                new Chat
                {
                    Id = 2,
                    FriendshipId = 2,
                },
                new Chat
                {
                    Id = 3,
                    FriendshipId = 4,
                },
                new Chat
                {
                    Id = 4,
                    FriendshipId = 3,
                },
                new Chat
                {
                    Id = 5,
                    FriendshipId = 7,
                }
               );
        }
    }
}

