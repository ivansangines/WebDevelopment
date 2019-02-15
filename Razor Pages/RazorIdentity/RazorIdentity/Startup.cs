using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorIdentity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazorIdentity.Areas.Identity.Services;

namespace RazorIdentity
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<Models.ComplexDb2Context>(options =>
 options.UseSqlServer(
 Configuration.GetConnectionString("ComplexDb2")));

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
            Configuration.GetConnectionString("ComplexDb2")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //----------------following added by AM--------------------------
            services.AddCors(o => o.AddPolicy("MyCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
               .AllowAnyHeader();
            }));
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;
                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;
                // User settings
                options.User.RequireUniqueEmail = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });
            // Add application services.
            services.AddTransient<Microsoft.AspNetCore.Identity.UI.Services.IEmailSender,EmailSender>();
            services.AddSingleton<IConfiguration>(Configuration); // for reading from config file
            //--------------------------------------------------------
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc();
            CreateUserRoles(services).Wait();

        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager =
           serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager =
           serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            //add Admin role to the database
            IdentityResult roleResult;
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
            // Assign Admin role to the Admin user
            IdentityUser user = await UserManager.FindByEmailAsync("admin@xyz.com");
            // var User = new ApplicationUser();
            var User = new IdentityUser();
            await UserManager.AddToRoleAsync(user, "Admin");
        }
    }
}
