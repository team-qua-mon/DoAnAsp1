using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DoAnAsp.Areas.ADmin.Data;

namespace DoAnAsp
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
            services.AddDbContext<DPContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DPContext")));
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(5);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                name: "MyArea",
                areaName: "Admin",
                pattern: "Admin/{controller=Login}/{action=loginIndex}/{id?}");

               // endpoints.MapControllerRoute(
               //name: "areas",
               //pattern: "{area:exists}/{controller=HomeAdmin}/{action=Index}/{id?}"
               //);

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ShopBanDT}/{action=Index}/{id?}");
            });
        }
    }
}
