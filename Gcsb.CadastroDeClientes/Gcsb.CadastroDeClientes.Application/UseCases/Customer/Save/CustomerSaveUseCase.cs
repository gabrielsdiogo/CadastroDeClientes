using Gcsb.CadastroDeClientes.Application.Boundaries.Customer;
using Gcsb.CadastroDeClientes.Application.UseCases.Customer.Save.Handlers;
using System;

namespace Gcsb.CadastroDeClientes.Application.UseCases.Customer.Save
{
    public class CustomerSaveUseCase : ICustomerSaveUseCase
    {
        private readonly IOutputPort<Guid> output;
        private readonly ValidateHandler validateHandler;

        public CustomerSaveUseCase(IOutputPort<Guid> output, ValidateHandler validateHandler, SaveHandler saveHandler)
        {
            this.output = output;
            this.validateHandler = validateHandler;
            this.validateHandler.SetSucessor(saveHandler);
        }
        public void Execute(CustomerSaveRequest request)
        {
            try
            {
                validateHandler.ProcessRequest(request);
                output.Standard(request.Customer.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
