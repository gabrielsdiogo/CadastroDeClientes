using Gcsb.CadastroDeClientes.Application.UseCases.Customer.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.Update
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateCustomerController : ControllerBase
    {
        private readonly CustomerPresenter presenter;
        private readonly ICustomerSaveUseCase customerSaveUseCase;

        public UpdateCustomerController(CustomerPresenter presenter, ICustomerSaveUseCase customerSaveUseCase)
        {
            this.presenter = presenter;
            this.customerSaveUseCase = customerSaveUseCase;
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdateCustomer([FromBody] UpdateInputCustomer input)
        {
            var request = new CustomerSaveRequest(input.Id, input.Nome, input.DataDeNascimento, input.DataDoCadastro, input.Documento, input.Endereco, input.ClienteAtivo);
            customerSaveUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
