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

        [HttpGet("{doc:int}", Name = "GetCustomer")]
        public async Task<ActionResult<CustomerDTO>> Get(int doc)
        {
            var customer = _customerService.GetCustomerByDoc(doc);
            if (customer == null)
            {
                return NotFound("Customer Not Found");
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerDTO customerDto)
        {
            if(customerDto == null)
            {
                return BadRequest("Invalid Data");
            }
            await _customerService.Add(customerDto);

            return new CreatedAtRouteResult("GetCustomer", new { doc = customerDto.Documento });
        }

        [HttpPut]
        public async Task<ActionResult> Put(int doc, [FromBody] CustomerDTO customerDto)
        {
            if(doc != customerDto.Documento)
                return BadRequest();
            if (customerDto == null)
                return BadRequest();

            await _customerService.Update(customerDto);

            return Ok(customerDto);

        }
    }
}
