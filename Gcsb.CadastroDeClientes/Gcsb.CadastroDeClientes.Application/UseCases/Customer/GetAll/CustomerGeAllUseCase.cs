using Gcsb.CadastroDeClientes.Application.Boundaries.Customer;
using Gcsb.CadastroDeClientes.Application.Repositories;
using Gcsb.CadastroDeClientes.Domain.Customer;
using System.Collections.Generic;

namespace Gcsb.CadastroDeClientes.Application.UseCases.Customer.GetAll
{
    public class CustomerGetAllUseCase : ICustomerGetAllUseCase
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IOutputPort<List<Domain.Customer.Customer>> output;

        public CustomerGetAllUseCase(ICustomerReadOnlyRepository customerReadOnlyRepository, IOutputPort<List<Domain.Customer.Customer>> output)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.output = output;
        }

        public void Execute()
        {
            try
            {
                var customers = customerReadOnlyRepository.GetAll();
                output.Standard(customers);
            }
            catch (System.Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
