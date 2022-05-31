using FluentAssertions;
using Gcsb.CadastroDeClientes.Application.Repositories;
using Gcsb.CadastroDeClientes.Application.UseCases.Customer.Delete;
using Gcsb.CadastroDeClientes.Application.UseCases.Customer.Get;
using Gcsb.CadastroDeClientes.Application.UseCases.Customer.GetAll;
using Gcsb.CadastroDeClientes.Application.UseCases.Customer.Save;
using Gcsb.CadastroDeClientes.Tests.TestCaseOrdering;
using Gcsb.CadastroDeClientes.WebApi.UseCases.Customer;
using Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.Add;
using Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.Delete;
using Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.Get;
using Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.GetAll;
using Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.Update;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.CadastroDeClientes.Tests.Cases.Webapi.Controllers.Customer
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("Gcsb.CadastroDeClientes.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.CadastroDeClientes.Tests")]
    public class CustomerControllersTest
    {
        private readonly ICustomerSaveUseCase customerSaveUseCase;
        private readonly CustomerPresenter presenter;
        private readonly ICustomerDeleteUseCase customerDeleteUseCase;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly ICustomerGetUseCase customerGetUseCase;
        private readonly ICustomerGetAllUseCase customerGetAllUseCase;
        private static Guid id;

        public CustomerControllersTest(ICustomerSaveUseCase customerSaveUseCase, CustomerPresenter presenter, ICustomerDeleteUseCase customerDeleteUseCase, ICustomerWriteOnlyRepository customerWriteOnlyRepository, ICustomerGetUseCase customerGetUseCase, ICustomerGetAllUseCase customerGetAllUseCase)
        {
            this.customerSaveUseCase = customerSaveUseCase;
            this.presenter = presenter;
            this.customerGetUseCase = customerGetUseCase;
            this.customerDeleteUseCase = customerDeleteUseCase;
            this.customerGetAllUseCase = customerGetAllUseCase;
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
        }

        [Theory]
        [InlineData("Gabriel", "16/09/2000", 45961919708, "Rua ten-cel", "23/05/2022", true)]
        [TestPriority(1)]
        public void ShouldCreateCustomer(String nome, String DataDeNascimento, long doc, String endereco, String DataDoCadastro, bool ClienteAtivo)
        {
            var input = new AddInputCustomer() {Nome = nome, DataDeNascimento = DataDeNascimento, Documento = doc, Endereco = endereco, DataDoCadastro = DataDoCadastro, ClienteAtivo = ClienteAtivo};
            var controller = new AddCustomerController(presenter, customerSaveUseCase);
            var output = controller.CreateCustomer(input);
            var cid = output as OkObjectResult;
            id = Guid.Parse(cid.Value.ToString());
            output.Should().BeOfType<OkObjectResult>();
        }



        [Fact]
        [TestPriority(2)]
        public void ShouldGetCustomer()
        {
            var input = new GetInputCustomer() { CustomerId = id };
            var controller = new GetCustomerController(presenter, customerGetUseCase);
            var output = controller.GetCustomer(input);
            output.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetAllCustomers()
        {
            var controller = new GetAllCustomerController(presenter, customerGetAllUseCase);
            var output = controller.GetAllCustomers();
            output.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [InlineData("Jorge", "16/09/2000", 45961919708, "Rua ten-cel", "23/05/2022", true)]
        [TestPriority(2)]
        public void ShouldUpdateCustomer(String nome, String DataDeNascimento, long doc, String endereco, String DataDoCadastro, bool ClienteAtivo)
        {
            var input = new UpdateInputCustomer() { Id = id, Nome = nome, DataDeNascimento = DataDeNascimento, Documento = doc, Endereco = endereco, DataDoCadastro = DataDoCadastro, ClienteAtivo = ClienteAtivo };
            var controller = new UpdateCustomerController(presenter, customerSaveUseCase);
            var output = controller.UpdateCustomer(input);
            output.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(3)]
        public void ShouldDeleteCustomer()
        {
            var controller = new DeleteCustomerController(presenter, customerDeleteUseCase);
            var output = controller.DeleteCustomer(id);
            output.Should().BeOfType<OkObjectResult>();
        }



    }
}
