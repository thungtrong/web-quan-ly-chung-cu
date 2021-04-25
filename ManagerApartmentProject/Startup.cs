using System;

using ManagerApartmentProject.Const;
using ManagerApartmentProject.Repositories;
using Microsoft.AspNetCore.Authorization;
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
            services.AddSession();

            // Cau hinh phan quyen
            services.AddAuthentication("AuthCookie")
                    .AddCookie("AuthCookie", config =>
                    {  
                        config.Cookie.Name = "Auth.Cookie";
                        config.LoginPath = "/Home/Login";
                        config.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                    });

            services.AddAuthorization(config =>
            {
                // Add policy
                config.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                // config.AddPolicy()
            });
            // End Cau hinh phan quyen

            // Add service for Respositories
            services.AddTransient<IApartmentRes, ApartmentRes>();
            services.AddTransient<IFloorRes, FloorRes>();
            services.AddTransient<IEquipmentRes, EquipmentRes>();
            services.AddSingleton<INotificationRes, NotificationRes>();
            services.AddTransient<IMaintenanceRes, MaintenanceRes>();
            services.AddTransient<IInvoiceBuildingRes, InvoiceBuildingRes>();
            services.AddTransient<IInvoiceApartmentRes, InvoiceApartmentRes>();
            services.AddTransient<IEmployeeRes, EmployeeRes>(); 
            services.AddTransient<IAdminRes, AdminRes>(); 
            services.AddTransient<ITenantRes, TenantRes>(); 
            //  End add service for Respositories
            
            DataProvider.AddInstance(Configuration.GetConnectionString("DefaultConnection"));
            ConstValue.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
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


            app.UseHttpsRedirection();

            // Who are you?
            // app.UseSession();
            app.UseAuthentication();
            // are you allowed?
            app.UseAuthorization();

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
