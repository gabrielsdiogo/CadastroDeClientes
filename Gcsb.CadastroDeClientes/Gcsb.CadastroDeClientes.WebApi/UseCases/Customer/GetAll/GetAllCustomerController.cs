using Gcsb.CadastroDeClientes.Application.UseCases.Customer.GetAll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.GetAll
{

    [Route("api/[controller]")]
    [ApiController]
    public class GetAllCustomerController : ControllerBase
    {
        private readonly CustomerPresenter presenter;
        private readonly ICustomerGetAllUseCase customerGetAllUseCase;

        public GetAllCustomerController(CustomerPresenter presenter, ICustomerGetAllUseCase customerGetAllUseCase)
        {
            this.presenter = presenter;
            this.customerGetAllUseCase = customerGetAllUseCase;
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        [ProducesResponseType(typeof(List<CustomerResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllCustomers()
        {
            customerGetAllUseCase.Execute();
            return presenter.ViewModel;
        }
    }
}
