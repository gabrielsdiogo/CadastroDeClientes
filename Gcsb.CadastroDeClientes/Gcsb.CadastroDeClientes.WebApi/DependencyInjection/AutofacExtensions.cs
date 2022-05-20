using Autofac;
using Gcsb.CadastroDeClientes.Infrastructure.Modules;
using Gcsb.CadastroDeClientes.WebApi.Module;

namespace Gcsb.CadastroDeClientes.WebApi.DependencyInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<WebapiModule>();

            return builder;
        }
    }
}
