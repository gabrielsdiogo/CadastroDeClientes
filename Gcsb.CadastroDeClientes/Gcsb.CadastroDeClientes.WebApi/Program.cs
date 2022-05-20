using Autofac.Extensions.DependencyInjection;
using Gcsb.Connect.Pkg.Serilog.Implementation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;


namespace Gcsb.CadastroDeClientes.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool logEnable = Environment.GetEnvironmentVariable("POSTGRES_LOG_CONN") != null;
            Log.Logger = new Logger().ConfigureLogger(logEnable);
            Log.Information("Starting web host");

            try
            {
                CreateHostBuilder(args).Build().Run();


            }
            catch (Exception ex)
            
            {
                Log.Fatal(ex, "Host terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
                
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
