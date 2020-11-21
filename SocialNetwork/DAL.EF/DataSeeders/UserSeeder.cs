using DAL.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DAL.EF.DataSeeders
{
    public static class UserSeeder
    {

        public static void SeedDatabase(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasData(
            //    new User {
            //        Id = 1,
            //        FirstName = "Ada",
            //        LastName = "Lovelace",
            //        Email = "ada.love@gmail.com",
            //        UserName = "ada.love",
            //        PhoneNumber = "+380 44 446 6356",
            //        City = "London",
            //        Country = "England",
            //        University = "Oxford",
            //        AboutMe = "In love with math and computing. Do you dare to complete? DM me then",
            //        Age = 25 ,
            //        Friendships = new Collection<Friendship>() 
            //        { 
            //            //new Friendship()
            //            //{
            //            //    Id = 1,
            //            //    UserId = 1,
            //            //    FriendId = 3,
            //            //},
            //            //new Friendship()
            //            //{
            //            //    Id = 2,
            //            //    UserId = 1,
            //            //    FriendId = 4,
            //            //}
            //        },
            //        Messages = new Collection<Message>() { }
            //        },
            //    new User
            //    {
            //        Id = 2,
            //        Email = "tim@gmail.com",
            //        UserName = "timmy",
            //        FirstName = "Tim",
            //        LastName = "Delaney",
            //        PhoneNumber = "+380 44 538 6141",
            //        City = "New York",
            //        Country = "USA",
            //        University = "Grand Army",
            //        AboutMe = "Shy fancy boy",
            //        Age = 18,
            //        Friendships = new Collection<Friendship>() {
                    
            //            //new Friendship()
            //            //{
            //            //    Id = 3,
            //            //    UserId = 2,
            //            //    FriendId = 3,
            //            //},
            //            //new Friendship()
            //            //{
            //            //    Id = 4,
            //            //    UserId = 2,
            //            //    FriendId = 5,
            //            //}
            //        },
            //        Messages = new Collection<Message>() { }
            //    },
            //    new User
            //    {
            //        Id = 3,
            //        Email = "rory.gilmore@gmail.com",
            //        UserName = "rory",
            //        FirstName = "Lorelai",
            //        LastName = "Gilmore",
            //        PhoneNumber = "+380 44 193 0152",
            //        City = "Starts Hollow",
            //        Country = "USA",
            //        University = "Harvard",
            //        AboutMe = "I live in two worlds, one of them is the world of books",
            //        Age = 23,
            //        Friendships = new Collection<Friendship>()
            //        {
            //            //new Friendship()
            //            //{
            //            //    Id = 5,
            //            //    UserId = 3,
            //            //    FriendId = 1,
            //            //},
            //            //new Friendship()
            //            //{
            //            //    Id = 6,
            //            //    UserId = 3,
            //            //    FriendId = 2,
            //            //},
            //            //new Friendship()
            //            //{
            //            //    Id =7,
            //            //    UserId = 3,
            //            //    FriendId = 4,
            //            //}
            //        },
            //        Messages = new Collection<Message>() { }
            //    },
            //    new User
            //    {
            //        Id = 4,
            //        Email = "luke.danes@gmail.com",
            //        UserName = "luke`s",
            //        FirstName = "Luke",
            //        LastName = "Danes",
            //        PhoneNumber = "+380 44 038 0434",
            //        City = "Vinnytsia",
            //        Country = "Ukraine",
            //        University = null,
            //        AboutMe = "I run the dinner in the downtown, come only hungry",
            //        Age = 45,
            //        Friendships = new Collection<Friendship>()
            //        {

            //            //new Friendship()
            //            //{
            //            //    Id =8 ,
            //            //    UserId = 4,
            //            //    FriendId = 1,
            //            //},
            //            //new Friendship()
            //            //{
            //            //    Id = 9,
            //            //    UserId = 4,
            //            //    FriendId = 3,
            //            //}
            //        },
            //        Messages = new Collection<Message>() { }
            //    },
            //    new User
            //    {
            //        Id = 5,
            //        Email = "del.marco@gmail.com",
            //        UserName = "jojo",
            //        FirstName = "Joey",
            //        LastName = "Del Marco",
            //        PhoneNumber = "+380 44 177 6783",
            //        City = "New York",
            //        Country = "USA",
            //        University = "NYU",
            //        AboutMe = "In love with dancing and music, protecting girls` rights",
            //        Age = 17,
            //        Friendships = new Collection<Friendship>() 
            //        {
            //            //new Friendship()
            //            //{
            //            //    Id =10 ,
            //            //    UserId = 5,
            //            //    FriendId = 2,
            //            //}
            //        },
            //        Messages = new Collection<Message>() { }
            //    }
            //    );
        }
    }
}
