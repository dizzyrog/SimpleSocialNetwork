using DAL.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.DataSeeder
{
     public static class IdentityDataSeeder
    {

        public static void SeedDatabase(ModelBuilder modelBuilder)
        {
            #region Identity

            modelBuilder.Entity<UserRoleEntity>().HasData(new UserRoleEntity
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<UserRoleEntity>().HasData(new UserRoleEntity
            {
                Id = "2",
                Name = "User",
                NormalizedName = "USER"
            });
        }
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Id = "3",
            //    Name = "Manager",
            //    NormalizedName = "MANAGER"
            //});

            //var hasher = new PasswordHasher<ApplicationUser>();
            //modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            //{
            //    Id = "1",
            //    UserName = "admin",
            //    NormalizedUserName = "ADMIN",
            //    Email = "cheban.lesia@gmail.com",
            //    NormalizedEmail = "cheban.lesia@gmail.com".ToUpper(),
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "admin"),
            //    FirstName = "Olesia",
            //    LastName = "Cheban",
            //    PhoneNumber = "503703419",
            //    DateOfBirth = new DateTime(2001, 4, 26, 8, 30, 52)

                //SecurityStamp = Guid.NewGuid().ToString()
            //});
        
            //modelBuilder.Entity<Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole>().HasData(new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole
            //{
            //    RoleId = "1",
            //    UserId = "1"
            //});

            #endregion

        //    modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
        //    {
        //        Id = "2",
        //        UserName = "max.medina",
        //        NormalizedUserName = "max.medina".ToUpper(),
        //        Email = "max.medina@gmail.com",
        //        NormalizedEmail = "max.medina@gmail.com".ToUpper(),
        //        EmailConfirmed = true,
        //        PasswordHash = hasher.HashPassword(null, "we99vmjdpr-"),
        //        FirstName = "Max",
        //        LastName = "Medina",
        //        PhoneNumber = "567340872",
        //        DateOfBirth = new DateTime(1978, 5, 1)

        //    });
        //    public static async Task InitializeAsync(IServiceProvider services)
        //{
        //    return await AddTestUsers(
        //        services.GetRequiredService<RoleManager<UserRoleEntity>>(),
        //        services.GetRequiredService<UserManager<UserEntity>>());
        //}

        //public static async Task AddTestData(
        //    HotelApiDbContext context,
        //    IDateLogicService dateLogicService,
        //    UserManager<UserEntity> userManager)
        //{
        //    if (context.Rooms.Any())
        //    {
        //        // Already has data
        //        return;
        //    }

        //    context.Rooms.Add(new RoomEntity
        //    {
        //        Id = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e9195976"),
        //        Name = "Driscoll Suite",
        //        Rate = 23959
        //    });

        //    var oxford = context.Rooms.Add(new RoomEntity
        //    {
        //        Id = Guid.Parse("301df04d-8679-4b1b-ab92-0a586ae53d08"),
        //        Name = "Oxford Suite",
        //        Rate = 10119,
        //    }).Entity;

        //    var today = DateTimeOffset.Now;
        //    var start = dateLogicService.AlignStartTime(today);
        //    var end = start.Add(dateLogicService.GetMinimumStay());

        //    var adminUser = userManager.Users
        //        .SingleOrDefault(u => u.Email == "admin@landon.local");

        //    context.Bookings.Add(new BookingEntity
        //    {
        //        Id = Guid.Parse("2eac8dea-2749-42b3-9d21-8eb2fc0fd6bd"),
        //        Room = oxford,
        //        CreatedAt = DateTimeOffset.UtcNow,
        //        StartAt = start,
        //        EndAt = end,
        //        Total = oxford.Rate,
        //        User = adminUser
        //    });

        //    await context.SaveChangesAsync();
        //}

        //private static async Task AddTestUsers(
        //    RoleManager<UserRoleEntity> roleManager,
        //    UserManager<UserEntity> userManager)
        //{
        //    var dataExists = roleManager.Roles.Any() || userManager.Users.Any();
        //    if (dataExists)
        //    {
        //        return;
        //    }

        //    // Add a test role
        //    await roleManager.CreateAsync(new UserRoleEntity("Admin"));

        //    // Add a test user
        //    var user = new UserEntity
        //    {
        //        Email = "admin@landon.local",
        //        UserName = "admin@landon.local",
        //        FirstName = "Admin",
        //        LastName = "Tester",
        //        CreatedAt = DateTimeOffset.UtcNow
        //    };

        //    await userManager.CreateAsync(user, "Supersecret123!!");

        //    // Put the user in the admin role
        //    await userManager.AddToRoleAsync(user, "Admin");
        //    await userManager.UpdateAsync(user);
        //}


    }
}
