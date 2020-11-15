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
               }
               );
        }
    }
}

