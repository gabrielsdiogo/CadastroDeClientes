using CadastroDeClientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();

        Task<Customer> GetCustomerByDoc(int? documento);

        Task<Customer> Create(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<Customer> Remove(Customer customer);
    }
}
            