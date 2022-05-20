using Gcsb.CadastroDeClientes.Application.UseCases.Customer.Delete;
using Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.Add;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteCustomerController : ControllerBase
    {
        private readonly CustomerPresenter presenter;
        private readonly ICustomerDeleteUseCase customerDeleteUseCase;

        public DeleteCustomerController(CustomerPresenter presenter, ICustomerDeleteUseCase customerDeleteUseCase)
        {
            this.presenter = presenter;
            this.customerDeleteUseCase = customerDeleteUseCase;
        }

        [HttpDelete("{id}")]
        //[Route("DeleteCustomer")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeleteCustomer(Guid id)
        {
            var request = new CustomerDeleteRequest(id);
            customerDeleteUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
