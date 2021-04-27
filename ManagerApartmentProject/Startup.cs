using System.Net;
using System;
using System.Security.Claims;
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
                        config.LoginPath = "/Auth/Login";
                        config.ExpireTimeSpan = TimeSpan.FromMinutes(120);
                        config.AccessDeniedPath = "/Error/ErrorPage/403";
                    });

            services.AddAuthorization(config =>
            {
                #region default
                // Add policy Defalaut
                config.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireClaim("Id")
                    .RequireClaim(ClaimTypes.Name)
                    .RequireClaim(ClaimTypes.Email)
                    .Build();
                #endregion                
                
                config.AddPolicy("DeleteActionPolicy", policy => policy.RequireRole("SuperAdmin"));

                config.AddPolicy("UpdateActionPolicy", policy => policy.RequireRole("SuperAdmin", "Admin"));
                
                // config.AddPolicy("ViewAndCreate", )
            });
            // End Cau hinh phan quyen

            // Add service for Respositories
            services.AddScoped<IApartmentRes, ApartmentRes>();
            services.AddScoped<IFloorRes, FloorRes>();
            services.AddScoped<IEquipmentRes, EquipmentRes>();
            services.AddScoped<INotificationRes, NotificationRes>();
            services.AddScoped<IMaintenanceRes, MaintenanceRes>();
            services.AddScoped<IInvoiceBuildingRes, InvoiceBuildingRes>();
            services.AddScoped<IInvoiceApartmentRes, InvoiceApartmentRes>();
            services.AddScoped<IEmployeeRes, EmployeeRes>(); 
            services.AddScoped<ITenantRes, TenantRes>(); 
            services.AddScoped<IAccountRes, AccountRes>();
            //  End add service for Respositories
            
            DataProvider.AddInstance(Configuration.GetConnectionString("DefaultConnection"));
            
            // ConstValue.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
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

            app.UseStatusCodePagesWithRedirects("~/Error/ErrorPage/{0}");

            app.UseHttpsRedirection();

            // Who are you?
            app.UseAuthentication();
            // are you allowed?
            app.UseAuthorization();

            app.UseStaticFiles();
            // app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "error",
                    template: "Error/ErrorPage/{code}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "notification",
                    template: "{controller=Notification}/{action=Index}/{pageAll?}/{pageMy}"
                );
                routes.MapRoute(
                    name: "login",
                    template: "{controller=Auth}/{action=Login}"
                );
                
            });

        }
    }
}
