using Autofac;
using Autofac.Extensions.DependencyInjection;
using BCR.Business.Domain.Commands.Seguridad;
using BCR.Business.Domain.Queries.Seguridad;
using BCR.Business.Queries;
using BCR.DataAccess.Base;
using BCR.DataAccess.Seguridad;
using BCR.Service.Infrastructure;
using BCR.Service.Seguridad;
using BCR.Web.Api.Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Reflection;

namespace BCR.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //services.AddTransient<IContainer, Container>();
            services.AddTransient<ICommandProcessor, CommandProcessor>();
            services.AddTransient<IQueryProcessor, QueryProcessor>();
            services.AddTransient<IJwtSecurityTokenHandlerAdapter, JwtSecurityTokenHandlerAdapter>();
            services.AddTransient<IJwtConfig, JwtConfig>();
            services.AddTransient<IJwtSecurityTokenHandlerFactory, JwtSecurityTokenHandlerFactory>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(x => {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });


            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<BcrContext>(options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("BCRConnectionString"),
                                            sqlOptions => sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name));
                    },
                        ServiceLifetime.Scoped
                    );
            //AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
            //LoggingConfig.RegisterLogger(Configuration);

            //var container = new Container();

            //container.Configure(config =>
            //{
            //    config.AddRegistry(new ContainerRegistry());
            //    config.Populate(services);
            //});   

            services.AddOptions();
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).AsClosedTypesOf(typeof(ICommandHandler<>));

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).AsClosedTypesOf(typeof(IQuery<>)).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).AsClosedTypesOf(typeof(IQueryHandler<,>)).AsImplementedInterfaces();

            builder.RegisterModule(new AutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // If, for some reason, you need a reference to the built container, you
            // can use the convenience extension method GetAutofacRoot.
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
