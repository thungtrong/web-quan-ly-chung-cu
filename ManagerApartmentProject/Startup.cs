using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ManagerApartmentProject
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
            

            services.AddSingleton<INotificationRes, NotificationRes>();

            DataProvider.AddInstance(Configuration.GetConnectionString("DefaultConnection"));

            // services.AddAuthentication("CookieAuth")
            //         .AddCookie(config =>
            //         {
            //             config.Cookie.Name = "Auth.Cookie";
            //             config.LoginPath = "/Home";
            //             config.ExpireTimeSpan = TimeSpan.FromMinutes(120);
            //         });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Who are you?
            // app.UseAuthentication();

            // are you allowed?
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "notification",
                    template: "{controller=Notification}/{action=Index}/{pageAll?}/{pageMy}"
                );
            });

        }
    }
}
