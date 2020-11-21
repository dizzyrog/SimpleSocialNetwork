using DAL.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.DataSeeders
{
    public static class FriendshipSeeder
    {
        public static void SeedDatabase(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Friendship>().HasData(
            //     new Friendship()
            //     {
            //         Id = 1,
            //         UserId = 1,
            //         ChatId =1,
            //         FriendId = 3,
            //     },
            //    new Friendship()
            //    {
            //        Id = 2,
            //        UserId = 1,
            //        ChatId = 2,
            //        FriendId = 4,
            //    },
            //    new Friendship()
            //    {
            //        Id = 3,
            //        UserId = 2,
            //        ChatId = 4,
            //        FriendId = 3,
            //    },
            //    new Friendship()
            //    {
            //        Id = 4,
            //        UserId = 2,
            //        ChatId = 3,
            //        FriendId = 5,
            //    },
            //    new Friendship()
            //    {
            //        Id = 7,
            //        UserId = 3,
            //        ChatId = 5,
            //        FriendId = 4,
            //    }
                //new Friendship()
                //{
                //    Id = 5,
                //    UserId = 3,
                //    ChatId = 1,
                //    FriendId = 1,
                //},
                //new Friendship()
                //{
                //    Id = 6,
                //    UserId = 3,
                //    ChatId = 4,
                //    FriendId = 2,
                //},
                //new Friendship()
                //{
                //    Id = 8,
                //    UserId = 4,
                //    ChatId = 2,
                //    FriendId = 1,
                //},
                //new Friendship()
                //{
                //    Id = 9,
                //    UserId = 4,
                //    ChatId = 5,
                //    FriendId = 3,
                //},

                //new Friendship()
                //{
                //    Id = 10,
                //    UserId = 5,
                //    ChatId = 3,
                //    FriendId = 2,
                //}
            //);
        }
    }
}
