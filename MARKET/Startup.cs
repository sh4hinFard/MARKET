using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MARKET.Repositoris;
using Microsoft.AspNetCore.Authentication.Cookies;
using MARKET.Service;
using Microsoft.AspNetCore.Authorization;

namespace MARKET
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
            services.AddControllersWithViews();
            services.AddSession(s =>
            {
                s.IdleTimeout = TimeSpan.FromHours(1);
            });

            services.AddHttpContextAccessor();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<db>();
            services.AddAuthorization(options =>
            options.AddPolicy("admin", Authbuildr =>
            {
                Authbuildr.AddAuthenticationSchemes("admin1");
                Authbuildr.RequireRole("admin");
            })
       
            );

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);

            }).AddCookie("admin1", options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            }
            ) ;
            services.AddTransient<IViewRenderService, RenderViewToString>();
            //.AddGoogle(options =>
            //{
            //    options.ClientId = "597636127689-g50c5hi3q3h8h5dibukijkhv410gbnhp.apps.googleusercontent.com";
            //    options.ClientSecret = "W_xZMX7Mz1hwHcgL-J8eST7A";
            //});
            //services.AddIdentity<Be.User,IdentityRole>(options =>
            //{
            //    options.Password.RequiredUniqueChars = 0;
            //    options.User.RequireUniqueEmail = true;
            //    options.User.AllowedUserNameCharacters =
            //        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-";
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            //})
            //.AddEntityFrameworkStores<db>()
            //.AddDefaultTokenProviders()
            //.AddErrorDescriber<PersianIdentityErrorDescriber>();

            services.AddScoped<MessageSender>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
