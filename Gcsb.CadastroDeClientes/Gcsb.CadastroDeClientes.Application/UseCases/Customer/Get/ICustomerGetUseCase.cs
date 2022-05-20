using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Application.UseCases.Customer.Get
{
    public interface ICustomerGetUseCase
    {
        void Execute(CustomerGetRequest request);
    }
}
