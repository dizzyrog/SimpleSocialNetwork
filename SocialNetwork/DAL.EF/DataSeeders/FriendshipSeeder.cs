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

            modelBuilder.Entity<Friendship>().HasData(
                new Friendship
                {
                    Id =1,
                    UserId = 5,
                    FriendId =2,
                    ChatId =1,
                },
                new Friendship
                {
                    Id = 2,
                    UserId = 1,
                    FriendId =3,
                    ChatId = 1,
                },
                new Friendship
                {
                    Id = 3,
                    UserId = 1,
                    FriendId =3,
                    ChatId =1,
                },
                new Friendship
                {
                    Id = 4,
                    UserId = 3,
                    FriendId =1,
                    ChatId =1,
                },
                new Friendship
                {
                    Id = 5,
                    UserId = 3,
                    FriendId =2,
                    ChatId = 1,
                },
                new Friendship
                {
                    Id = 6,
                    UserId = 3,
                    FriendId =4,
                    ChatId = 1,
                },
                new Friendship
                {
                    Id = 7,
                    UserId = 4,
                    FriendId =1,
                    ChatId =1,
                },
                new Friendship
                {
                    Id = 8,
                    UserId = 4,
                    FriendId =3,
                    ChatId = 1,
                },
                new Friendship
                {
                    Id = 9,
                    UserId = 2,
                    FriendId =3,
                    ChatId = 1,
                },
                new Friendship
                {
                    Id = 10,
                    UserId = 2,
                    FriendId =5,
                    ChatId = 1,
                }
                );

        }
    }
}
