using DAL.Domain;
using DAL.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
//using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;
//using AutoMapper;
using DAL;
using AspNet.Security.OpenIdConnect.Primitives;
using WebAPI.Models;
using DAL.EF.Contexts;
using AutoMapper;
using DAL.Interfaces;
using BLL.Interfaces;
using BLL.Infrastructure.Services;
using WebAPI.AutomapperProfiles;
using BLL.Infrastructure.AutomapperProfiles;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"))
                   .EnableSensitiveDataLogging());

            services.AddDbContext<AuthenticationContext>(
            (options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"));
        }
       ));
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            //needed fot Add-Migration to work
            services.AddIdentity<UserEntity, UserRoleEntity>()
              .AddEntityFrameworkStores<AuthenticationContext>();

            // Add ASP.NET Core Identity
            //AddIdentityCoreServices(services);

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSignalR(); 
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );

            services.AddCors(options => options.AddPolicy("CorsPolicy",
               builder =>
               {
                   builder.AllowAnyMethod().AllowAnyHeader()
                   .WithOrigins("https://localhost:44316")
                   .AllowCredentials();
               }));
            services.AddControllers().AddNewtonsoftJson() ;


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserAutomapperProfile());
                mc.AddProfile(new FriendshipAutomapperProfile());
                mc.AddProfile(new MessageAutomapperProfile());
                mc.AddProfile(new SearchAutomapperProfile());

            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFriendshipService, FriendshipService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddTransient<IMessageService, MessageService>();

            services.AddHttpContextAccessor();

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chatsocket");     // path will look like this https://localhost:44379/chatsocket
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
        
    }
}
