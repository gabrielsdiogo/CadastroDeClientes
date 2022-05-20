using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Application.UseCases.Customer.Delete
{
    public interface ICustomerDeleteUseCase
    {
        void Execute(CustomerDeleteRequest request);
    }
}
