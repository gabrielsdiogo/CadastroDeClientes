using Gcsb.CadastroDeClientes.Application.UseCases.Customer.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.Add
{

        [Route("api/[controller]")]
        [ApiController]
        public class AddCustomerController : ControllerBase
        {
            private readonly CustomerPresenter presenter;
            private readonly ICustomerSaveUseCase customerSaveUseCase;

            public AddCustomerController(CustomerPresenter presenter, ICustomerSaveUseCase customerSaveUseCase)
            {
                this.presenter = presenter;
                this.customerSaveUseCase = customerSaveUseCase;
            }

            [HttpPost]
            [Route("CreateCustomer")]
            [ProducesResponseType(typeof(Guid), 200)]
            [ProducesResponseType(typeof(ProblemDetails), 400)]
            public IActionResult CreateCustomer([FromBody] AddInputCustomer input)
            {
                var request = new CustomerSaveRequest(input.Nome, input.DataDeNascimento, input.DataDoCadastro, input.Documento, input.Endereco, input.ClienteAtivo);
                customerSaveUseCase.Execute(request);
                return presenter.ViewModel;
            }
        }
    
}
