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
                        config.AccessDeniedPath = "/Error/403";
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
                
                config.AddPolicy("SuperAdmin", policy => policy.RequireRole("SuperAdmin"));

                config.AddPolicy("AdminOrGreater", policy => policy.RequireRole("SuperAdmin", "Admin"));

                config.AddPolicy("EmployeeOrTenant", policy => policy.RequireRole("Employee", "Tenant"));

                config.AddPolicy("Employee", policy => policy.RequireRole("Employee"));

                config.AddPolicy("Tenant", policy => policy.RequireRole("Tenant"));

                config.AddPolicy("AllowedAll", policy => policy.RequireRole("SuperAdmin", "Employee", "Admin"));
            });
            // End Cau hinh phan quyen

            // Add service for Respositories
            services.AddScoped<IAdminRes, AdminRes>();
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
            services.AddScoped<IComplaintRes, ComplaintRes>();
            services.AddScoped<IEmployeeFormRes, EmployeeFormRes>();
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

            app.UseStatusCodePagesWithRedirects("~/Error/{0}");

            app.UseHttpsRedirection();
            app.UseSession();
            // Who are you?
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
                    template: "Notification/Index/{pageAll?}/{pageMy}"
                );
                routes.MapRoute(
                    name: "login",
                    template: "Auth/{action=Login}"
                );
                
            });

        }
    }
}
