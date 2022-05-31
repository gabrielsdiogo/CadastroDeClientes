using FluentAssertions;
using Gcsb.CadastroDeClientes.Application.Repositories;
using Gcsb.CadastroDeClientes.Domain.Customer;
using Gcsb.CadastroDeClientes.Tests.TestCaseOrdering;
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
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly ICustomerWriteOnlyRepository customerWriteOnly;
        private static Guid id;

        public CustomerRepositoryTest(ICustomerWriteOnlyRepository customerWriteOnlyRepository, ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            this.customerWriteOnly = customerWriteOnlyRepository;
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        [Theory]
        [InlineData("Gabriel", "16/09/2000", 45961919708, "Rua ten-cel", "23/05/2022", true)]
        [TestPriority(1)]
        public void CustomerAddRepository(String nome, String DataDeNascimento, long doc, String endereco, String DataDoCadastro, bool ClienteAtivo)
        {
            id = Guid.NewGuid();
            var customer = new Customer(id, nome, DataDeNascimento, doc, endereco, DataDoCadastro, ClienteAtivo);
            var ret = customerWriteOnly.Add(customer);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void CustomerGetAllValidate()
        {
            var models = customerReadOnlyRepository.GetAll();
            models.Should().HaveCountGreaterOrEqualTo(1);
        }

        [Fact]
        [TestPriority(2)]
        public void CustomerGetByIdValidate()
        {
            var model = customerReadOnlyRepository.GetById(id);
            model.Should().NotBeNull();
        }


        [Theory]
        [InlineData("Gabriel", "16/09/2001", 45961919708, "Rua ten-cel", "23/05/2022", true)]
        [TestPriority(3)]
        public void CustomerUpdateValidate(String nome, String DataDeNascimento, long doc, String endereco, String DataDoCadastro, bool ClienteAtivo)
        {
            var model = customerReadOnlyRepository.GetById(id);
            model.Should().NotBeNull();
            var newModel = new Customer(id, nome, DataDeNascimento, doc, endereco, DataDoCadastro, ClienteAtivo);
            customerWriteOnly.Update(newModel);
        }

        [Fact]
        [TestPriority(4)]
        public void CustomerDeleteValidate()
        {
            var model = customerReadOnlyRepository.GetById(id);
            var ret = customerWriteOnly.Delete(model.Id);
            ret.Should().Be(1);
        }

    }
}
