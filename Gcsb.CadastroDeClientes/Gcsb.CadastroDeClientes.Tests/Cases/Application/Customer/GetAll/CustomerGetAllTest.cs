using FluentAssertions;
using Gcsb.CadastroDeClientes.Application.UseCases.Customer.GetAll;
using Gcsb.CadastroDeClientes.WebApi.UseCases.Customer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.CadastroDeClientes.Tests.Cases.Application.Customer.GetAll
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("Gcsb.CadastroDeClientes.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.CadastroDeClientes.Tests")]
    public class CustomerGetAllTest
    {
        private readonly ICustomerGetAllUseCase customerGetAllUseCase;
        private readonly CustomerPresenter presenter;

        public CustomerGetAllTest(ICustomerGetAllUseCase customerGetAllUseCase, CustomerPresenter presenter)
        {
            this.customerGetAllUseCase = customerGetAllUseCase;
            this.presenter = presenter;
        }

        [Fact]
        public void CustomerGetAllValidate()
        {
            customerGetAllUseCase.Execute();
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }
    }
}
