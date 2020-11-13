using DAL.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.EF
{
    public class AuthenticationContext : IdentityDbContext<UserEntity, UserRoleEntity, string>
    {
        
            public AuthenticationContext(DbContextOptions options)
                : base(options) { }
            
        //public DbSet<UserEntity> UserEntities { get; set; }
    }
}
