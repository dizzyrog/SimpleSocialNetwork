using DAL.Domain;
using DAL.EF.Configurations;
using DAL.EF.DataSeeders;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
          DbContextOptions<ApplicationDbContext> options,
          IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FriendshipConfiguration());
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());

            //UserSeeder.SeedDatabase(modelBuilder);
            //ChatSeeder.SeedDatabase(modelBuilder);
            //FriendshipSeeder.SeedDatabase(modelBuilder);
            //MessageSeeder.SeedDatabase(modelBuilder);
        }
    }
}
