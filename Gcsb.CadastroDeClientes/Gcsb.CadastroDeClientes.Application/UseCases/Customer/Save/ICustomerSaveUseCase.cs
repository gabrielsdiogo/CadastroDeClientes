using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Application.UseCases.Customer.Save
{
    public interface ICustomerSaveUseCase
    {
        void Execute(CustomerSaveRequest request);
    }
}
