using Gcsb.CadastroDeClientes.Application.UseCases.Customer.Get;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.Get
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCustomerController : ControllerBase
    {
        private readonly CustomerPresenter presenter;
        private readonly ICustomerGetUseCase customerGetUseCase;

        public GetCustomerController(CustomerPresenter presenter, ICustomerGetUseCase customerGetUseCase)
        {
            this.presenter = presenter;
            this.customerGetUseCase = customerGetUseCase;
        }

        [HttpGet]
        [Route("GetCustomer")]
        [ProducesResponseType(typeof(CustomerResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetCustomer([FromBody] GetInputCustomer input)
        {
            var request = new CustomerGetRequest(input.CustomerId);
            customerGetUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
