using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Application.UseCases.Customer.Delete
{
    public class CustomerDeleteRequest
    {
        public Guid CustomerId { get; private set; }

        public CustomerDeleteRequest(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
