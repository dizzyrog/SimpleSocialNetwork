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
            modelBuilder.Entity<UserRoleEntity>().HasData(
                new UserRoleEntity()
                { 
                    Name = "user",
                    NormalizedName = "USER"
                },
                new UserRoleEntity()
                {
                    Name = "admin",
                    NormalizedName ="ADMIN"
                }
                );
        }

     }
}
