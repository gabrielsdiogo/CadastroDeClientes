using FluentAssertions;
using Gcsb.CadastroDeClientes.Application.UseCases.Customer.Save;
using Gcsb.CadastroDeClientes.WebApi.UseCases.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.CadastroDeClientes.Tests.Cases.Application.Customer.Save
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("Gcsb.CadastroDeClientes.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.CadastroDeClientes.Tests")]
    public class CustomerSaveTest
    {
        private readonly ICustomerSaveUseCase customerSaveUseCase;
        private readonly CustomerPresenter presenter;

        public CustomerSaveTest(ICustomerSaveUseCase customerSaveUseCase, CustomerPresenter presenter)
        {
            this.customerSaveUseCase = customerSaveUseCase;
            this.presenter = presenter;
        }

        [Theory]
        [InlineData("Gabriel", "16/09/2000", 45961919708, "Rua ten-cel", "23/05/2022", true)]
        public void CustomerSaveUseCaseValidation(String nome, String DataDeNascimento, long doc, String endereco, String DataDoCadastro, bool ClienteAtivo)
        {
            var request = new CustomerSaveRequest(nome, DataDeNascimento, DataDoCadastro, doc, endereco, ClienteAtivo);
            customerSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();

        }
    }
}
