using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PresentationWeb_ASPCore.Utils;
using Repositories;
using Repositories.APIRequester;
using Repositories.Data;
using Repositories.Data.Forms;

namespace PresentationWeb_ASPCore
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
            
            services.AddHttpContextAccessor();
            services.AddTransient<ISessionManager, SessionManager>();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(3);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddSingleton(p => new string("http://localhost:56586/api/"));          
            services.AddSingleton<IAuthAPIRequester<RegisterForm, LoginForm, User>, AuthRepository>();
            services.AddSingleton<IUserAPIRequester<User>, UserRepository>();
            services.AddSingleton<IEventAPIRequester<Event>, EventRepository>();
            services.AddSingleton<ICommentAPIRequester<Comment, Comment_User_Event>, CommentRequester>();
            services.AddSingleton<IReservationAPIRequester<Reservation, Reservation_User_Event>, ReservationRepository>();

            //services.AddScoped<ICryptoRSA, CryptoRSA>(c => new CryptoRSA());
            services.AddDistributedMemoryCache();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
