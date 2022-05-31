using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Application.Boundaries.Customer
{
    public interface IOutputPort<T>
    {
        void Standard(T result);

        //void Standard(Domain.Customer.Customer customer);

        //void Standard(IList<Domain.Customer.Customer> customer);

        void NotFound(string message);

        void Error(string message);
    }
}
