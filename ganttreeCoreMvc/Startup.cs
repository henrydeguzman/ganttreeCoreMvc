using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganttreeCoreMvc.Data.Entities;
using ganttreeCoreMvc.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ganttreeCoreMvc
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        // This constructor pass the value of configuration so we can access the connection string;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            // Add service so that this application knows about entity framework core
            // options that needs to use sql server

            services.AddDbContext<AppDbContext>(opts =>
            opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<StoreUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddControllersWithViews(); // Simply tell that we have controllers with views

            // knows we add razor pages
            services.AddRazorPages();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection(); //Redirects Http request to Https

            //The generated UI requires support for static files. To add static files to your app:
            app.UseStaticFiles(); // will search in a directory wwwroot for static files

            // Enable mvc to respond to incoming request needs to map an incoming request with the correct code that will execute.
            app.UseRouting();

            // To use ASP.NET Core Identity you also need to enable authentication. To authentication to your app
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Default route
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{Controller=Home}/{Action=Index}/{id?}");
                endpoints.MapRazorPages(); // to know the location route of razor pages added 
            });
        }
    }
}
