using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Application.UseCases.Customer.Get
{
    public class CustomerGetRequest
    {
        public Guid CustomerId { get; private set; }

        public CustomerGetRequest(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
