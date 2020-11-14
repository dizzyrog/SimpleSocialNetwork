using DAL.Domain;
using DAL.EF.DataSeeder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.EF
{
    public class AuthenticationContext : IdentityDbContext<UserEntity, UserRoleEntity, string>
    {
        
            public AuthenticationContext(DbContextOptions options)
                : base(options) 
            {
            // Database.EnsureDeleted();
            }

        //public DbSet<UserEntity> UserEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new SkillConfiguration());
            //modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            //modelBuilder.ApplyConfiguration(new UserSkillConfiguration());

            IdentityDataSeeder.SeedDatabase(modelBuilder);

        }
    }
}
