using Autofac;
using Gcsb.CadastroDeClientes.Infrastructure.Modules;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestCollectionOrderer("Gcsb.CadastroDeClientes.Tests.TestCaseOrdering", "Gcsb.CadastroDeClientes.Tests")]
[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestFramework("Gcsb.CadastroDeClientes.Tests.ConfigureTestFramework", "Gcsb.CadastroDeClientes.Tests")]
namespace Gcsb.CadastroDeClientes.Tests
{
    public class ConfigureTestFramework : AutofacTestFramework
    {

        public ConfigureTestFramework(IMessageSink diagnosticMessageSink) : base(diagnosticMessageSink)
        {

        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            //builder.RegisterModule<WebapiModule>();

            SetMockedDependencies(builder);
        }

        private void SetMockedDependencies(ContainerBuilder builder)
        {
            //builder.RegisterInstance(new GetInvoicesMock().GetInvoices().object).As<IGetInvoices>();
        }
    }
}
