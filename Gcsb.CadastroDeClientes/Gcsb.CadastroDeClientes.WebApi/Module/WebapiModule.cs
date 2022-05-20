using Autofac;

namespace Gcsb.CadastroDeClientes.WebApi.Module
{
    public class WebapiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly).Where(w => w.Namespace.Contains("UseCases")).AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly).Where(type => type.Namespace.Contains("Notification")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly).Where(type => type.Namespace.Contains("Infrastructure")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
