using CadastroDeClientes.Application.DTOs;
using CadastroDeClientes.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeClientes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> Get()
        {
            var customers = await _customerService.GetCustomers();
            if(customers == null)
            {
                return NotFound("Customers Not Found");
            }

            return Ok(customers);
        }

        [HttpGet("{doc}", Name = "GetCustomer")]
        public async Task<ActionResult<CustomerDTO>> Get(long doc)
        {
            var customer = _customerService.GetCustomerByDoc(doc);
            if (customer == null)
            {
                return NotFound("Customer Not Found");
            }

            return Ok(customer.Result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerDTO customerDto)
        {
            var hasCustomer = _customerService.GetCustomerByDoc(customerDto.Documento).Result;
            if (customerDto == null)
                return BadRequest("Invalid Data");
            if (hasCustomer != null)
                return BadRequest("The Customer has been created");
            
            await _customerService.Add(customerDto);

            return new CreatedAtRouteResult("GetCustomer", new { Nome = customerDto.Nome, documento = customerDto.Documento });
        }

        [HttpPut]
        public async Task<ActionResult> Put(Int64 doc, [FromBody] CustomerDTO customerDto)
        {
            if(doc != customerDto.Documento)
                return BadRequest();
            if (customerDto == null)
                return BadRequest();

            await _customerService.Update(customerDto);

            return Ok(customerDto);

        }

        [HttpDelete("{doc:long}")]
        public async Task<ActionResult<CustomerDTO>> Delete(long doc)
        {
            var customer = _customerService.GetCustomerByDoc(doc);
            if (customer == null)
                return NotFound("Category not found");

            await _customerService.Remove(doc);
            return Ok(customer.Result);

        }
    }
}
