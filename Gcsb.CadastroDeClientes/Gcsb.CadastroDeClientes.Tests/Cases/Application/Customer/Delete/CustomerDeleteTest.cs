using FluentAssertions;
using Gcsb.CadastroDeClientes.Application.UseCases.Customer.Delete;
using Gcsb.CadastroDeClientes.Application.UseCases.Customer.Save;
using Gcsb.CadastroDeClientes.Tests.TestCaseOrdering;
using Gcsb.CadastroDeClientes.WebApi.UseCases.Customer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.CadastroDeClientes.Tests.Cases.Application.Customer.Delete
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("Gcsb.CadastroDeClientes.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.CadastroDeClientes.Tests")]
    public class CustomerDeleteTest
    {
        private readonly ICustomerDeleteUseCase customerDeleteUseCase;
        private readonly ICustomerSaveUseCase customerSaveUseCase;
        private readonly CustomerPresenter presenter;
        private static Guid id;

        public CustomerDeleteTest(ICustomerDeleteUseCase customerDeleteUseCase, CustomerPresenter presenter, ICustomerSaveUseCase customerSaveUseCase)
        {
            this.customerDeleteUseCase = customerDeleteUseCase;
            this.presenter = presenter;
            this.customerSaveUseCase = customerSaveUseCase;
        }

        [Theory]
        [InlineData("Gabriel", "16/09/2000", 45961919708, "Rua ten-cel", "23/05/2022", true)]
        [TestPriority(1)]
        public void CustomerSaveUseCaseValidation(String nome, String DataDeNascimento, long doc, String endereco, String DataDoCadastro, bool ClienteAtivo)
        {
            id = Guid.NewGuid();
            var request = new CustomerSaveRequest(id, nome, DataDeNascimento, DataDoCadastro, doc, endereco, ClienteAtivo);
            customerSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();

        }

        [Fact]
        [TestPriority(2)]
        public void CustomerDeleteUseCaseValidation()
        {
            var request = new CustomerDeleteRequest(id);
            customerDeleteUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }
    }
}
