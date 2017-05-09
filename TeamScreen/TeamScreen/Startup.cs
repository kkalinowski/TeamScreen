using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using TeamScreen.Data.Context;
using TeamScreen.Data.Services;
using TeamScreen.Models;
using TeamScreen.Plugin.Base.Extensions;
using TeamScreen.Services.Plugins;
using Microsoft.AspNetCore.Identity;

namespace TeamScreen
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connString, x => x.MigrationsAssembly("TeamScreen.Data"))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            var pluginAssemblies = GetPluginAssemblies();
            RegisterMvc(services, pluginAssemblies);
            SetupEmbeddedViewsForPlugins(services, pluginAssemblies);

            var builder = new ContainerBuilder();
            builder.Populate(services);

            //builder.RegisterGeneric(typeof(UserManager<>));
            builder.RegisterType<SettingsService>().As<ISettingsService>();
            builder.RegisterType<PluginService>().As<IPluginService>();
            builder.RegisterAssemblyModules(pluginAssemblies);

            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        private void SetupEmbeddedViewsForPlugins(IServiceCollection services, IEnumerable<Assembly> pluginAssemblies)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                foreach (var assembly in pluginAssemblies)
                {
                    var embeddedFile = new EmbeddedFileProvider(assembly);
                    options.FileProviders.Add(embeddedFile);
                }
            });
        }

        private void RegisterMvc(IServiceCollection services, IEnumerable<Assembly> pluginAssemblies)
        {
            var mvcBuilder = services.AddMvc();
            pluginAssemblies.ForEach(x => mvcBuilder.AddApplicationPart(x));
            mvcBuilder.AddControllersAsServices();
        }

        private Assembly[] GetPluginAssemblies()
        {
            return Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "TeamScreen.Plugin.*.dll", SearchOption.AllDirectories)
                .Where(x => !x.Contains("TeamScreen.Plugin.Base.dll"))
                .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                .ToArray();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                // Browser Link is not compatible with Kestrel 1.1.0
                // For details on enabling Browser Link, see https://go.microsoft.com/fwlink/?linkid=840936
                // app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Container}/{action=Index}/{id?}");
            });
            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }
    }
}
