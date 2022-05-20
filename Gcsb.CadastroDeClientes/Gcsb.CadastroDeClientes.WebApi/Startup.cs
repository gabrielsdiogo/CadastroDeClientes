using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using Gcsb.CadastroDeClientes.Infrastructure.Modules;
using Gcsb.CadastroDeClientes.WebApi.DependencyInjection;
using Gcsb.CadastroDeClientes.WebApi.Module;
using Gcsb.CadastroDeClientes.WebApi.Pipeline;
using Gcsb.CadastroDeClientes.WebApi.Swagger;
using Gcsb.Connect.Pkg.Serilog.Implementation;
using Gcsb.Connect.Pkg.Startup.Webapi.DependencyInjection;
using Gcsb.Connect.Pkg.Startup.Webapi.Resources;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System;
using System.Linq;

[assembly: ApiConventionType(typeof(ApiConventions))]
namespace Gcsb.CadastroDeClientes.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ConfigurationModule(Configuration));
            builder.AddAutofacRegistration();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRazorPages();

            services.AddLocalization();
            services.AddVersioning();
            services.AddProblemDetails();
            services.AddCustomFilters();
            
            //services.Cors();
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });
            //services.AddSwaggerGenNewtonsoftSupport();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo() { Title = "Cadastro de Clientes", Version = "v1" });
                config.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });



            var builder = new ContainerBuilder();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<Infrastructure.Modules.InfrastructureModule>();
            builder.RegisterModule<WebapiModule>();
            builder.Populate(services);

            builder.Build();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            var serviceProvider = app.ApplicationServices;
            var resouces = serviceProvider.GetService<IStringLocalizer<ReturnMessages>>();

            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new ErrorHandlerMiddleware(env, resouces).Invoke
            });

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseMiddleware<LogRequestMiddleware>();
            app.AddLocalization();
            app.UseDeveloperExceptionPage();
            //app.UseCors();
            app.UseProblemDetails();
            //app.UseVersionedSwagger(provider);
            app.UseRouting();
            app.UseEndpoints(e => e.MapControllers());
            app.AddOptions();

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Gcsb.CadastroDeClientes");
            });
            

        }


        private string ExtractHost(HttpRequest request) =>
            request.Headers.ContainsKey("X-Forwarded-Host") ?
                new Uri($"{ExtractProto(request)}://{request.Headers["X-Forwarded-Host"].First()}").Host :
                    request.Host.Value;

        private string ExtractProto(HttpRequest request) =>
            request.Headers["X-Forwarded-Proto"].FirstOrDefault() ?? request.Protocol;

        private string ExtractPath(HttpRequest request) =>
            request.Headers.ContainsKey("X-Forwarded-Prefix") ?
                request.Headers["X-Forwarded-Prefix"].FirstOrDefault() :
                string.Empty;
    }
}
