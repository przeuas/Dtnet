using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using ZadanieLaboratoryjneDotNet.Model;

namespace ZadanieLaboratoryjneDotNet
{
    public class Startup
    {
        /// <summary>
        /// Kontener, fabryka do wstrzykiwania zależności (DI)
        /// </summary> gowno
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            using (var client = new DatabaseContext())
            {
                client.Database.EnsureCreated();
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "WebAPI",
                    Description = "Proste API do agregacji wiadomości",
                    TermsOfService = "None"
                });
                options.DescribeAllEnumsAsStrings();

                // gdy będziemy używać dokumentacji generowanej z komentarzy to możemy ją zawrzeć w naszym API
                // options.IncludeXmlComments(Path.ChangeExtension(Assembly.GetEntryAssembly().Location, "xml"));
            });
            
            services.AddEntityFrameworkSqlite().AddDbContext<DatabaseContext>();

            services.AddMvc()
                .AddMvcOptions(options =>
                {
                    options.CacheProfiles.Add("NoCache", new CacheProfile
                    {
                        NoStore = true,
                        Duration = 0
                    });
                });

            // Autofac - DI
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetEntryAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Repository") ||
                            t.Name.EndsWith("Service")
                )
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.Populate(services);
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUi();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("WebAPI - Wytw. oprogram. w środow. NET - Zadanie laboratoryjne");
            });
        }
    }
}
