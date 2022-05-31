using Gcsb.CadastroDeClientes.Application.Boundaries.Customer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.CadastroDeClientes.WebApi.UseCases.Customer
{
    public class CustomerPresenter : IOutputPort<Guid>, IOutputPort<Domain.Customer.Customer>, IOutputPort<List<Domain.Customer.Customer>>
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(Guid id)
            => ViewModel = new OkObjectResult(id);

        public void Standard(Domain.Customer.Customer customer)
            => ViewModel = new OkObjectResult(new CustomerResponse(customer.Id, customer.Nome, customer.DataDeNascimento, customer.Documento, customer.Endereco, customer.DataDoCadastro, customer.ClienteAtivo));

        public void Standard(List<Domain.Customer.Customer> customer)
        {
            var customersResponse = new List<CustomerResponse>();
            customer.ToList().ForEach(s => customersResponse.Add(new CustomerResponse(s.Id, s.Nome, s.DataDeNascimento, s.Documento, s.Endereco, s.DataDoCadastro, s.ClienteAtivo)));
            ViewModel = new OkObjectResult(customersResponse);
        }
    }
}
