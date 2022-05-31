using Gcsb.CadastroDeClientes.Application.Repositories;
using Gcsb.CadastroDeClientes.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.CadastroDeClientes.Tests.Cases.Infrastructure.Repository
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("Gcsb.CadastroDeClientes.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.CadastroDeClientes.Tests")]
    public class CustomerRepositoryTest
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnly;

        public CustomerRepositoryTest(ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.customerWriteOnly = customerWriteOnlyRepository;
        }

        [Theory]
        [InlineData("Gabriel", "16/09/2000", 45961919708, "Rua ten-cel", "23/05/2022", true)]
        public void CustomerAddRepository(String nome, String DataDeNascimento, long doc, String endereco, String DataDoCadastro, bool ClienteAtivo)
        {
            var customer = new Customer(Guid.NewGuid(), nome, DataDeNascimento, doc, endereco, DataDoCadastro, ClienteAtivo);
            var ret = customerWriteOnly.Add(customer);
            Assert.Equal(1, ret);
        }


    }
}
