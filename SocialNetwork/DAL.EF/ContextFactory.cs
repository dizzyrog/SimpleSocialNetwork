using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace DAL.EF
{
    public class ContextFactory //: IDesignTimeDbContextFactory<AuthenticationContext>
    {

        //AuthenticationContext IDesignTimeDbContextFactory<AuthenticationContext>.CreateDbContext(string[] args)
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<AuthenticationContext>();
        //    //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"));
        //    optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=IdentityDB1;Trusted_Connection=True;MultipleActiveResultSets=true");
        //    return new AuthenticationContext(optionsBuilder.Options);
        //}
        public AuthenticationContext CreateDbContext(string[] args)
        {
            throw new System.NotImplementedException();
        }
    }

}

