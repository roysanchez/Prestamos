using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Prestamos.Models;
using Prestamos.ViewModels.Cliente;
using Prestamos.ViewModels.Prestamo;
using Prestamos.Services;
using Negocios;
using Microsoft.Dnx.Runtime.Infrastructure;
using System.IO;

namespace Prestamos
{
    public class AppSettings
    {
        public string Roy { get; set; }
    }

    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.

            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // This reads the configuration keys from the secret store.
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }   
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            ConfigureMapper();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
               // Add Entity Framework services to the services container.
               var directory = CrearDirectorio();
            var filename = Configuration["Data:Sqlite:Filename"];

            var stringdb = $"Data Source={directory}/{filename}.db";

            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<PrestamoContext>(
                    option => option.UseSqlite(stringdb)
                )
                .AddDbContext<ApplicationDbContext>(
                    option => option.UseSqlite(stringdb)
                );

            // Add Identity services to the services container.
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add MVC services to the services container.
            services.AddMvc();

            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();

            // Register application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            // Add Application settings to the services container.
            services.AddSingleton<IConfiguration>(c => Configuration);
            //services.AddOptions();
            services.Configure<AppSettings>(Configuration);
            /*services.Configure<AppSettings>(c =>
            {
                c.Roy = Configuration["Roy"];
            });*/

        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                loggerFactory.AddDebug();
            }

            // Configure the HTTP request pipeline.

            // Add the following to the request pipeline only in development environment.
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                //app.UseErrorPage();
                //app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // sends the request to the following path or controller action.
                //app.UseErrorHandler("/Home/Error");
            }
            app.UseErrorPage();
            app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline.
            app.UseIdentity();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });

        }

        string CrearDirectorio()
        {
            var env = CallContextServiceLocator.Locator.ServiceProvider.GetRequiredService<IApplicationEnvironment>();
            var location = Configuration["Data:Sqlite:Location"];
            var directory = $"{env.ApplicationBasePath}/{location}";

            DirectoryInfo di = Directory.CreateDirectory(directory);

            return di.FullName;
        }

        void ConfigureMapper()
        {
            AutoMapper.Mapper.CreateMap<ClienteViewModel, Cliente>().ReverseMap();
            AutoMapper.Mapper.CreateMap<PrestamoViewModel, Prestamo>().ReverseMap();
        }
    }
}
