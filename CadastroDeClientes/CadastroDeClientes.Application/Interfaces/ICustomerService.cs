using CadastroDeClientes.Application.DTOs;
using CadastroDeClientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetCustomers();
        Task<CustomerDTO> GetCustomerByDoc(int documento);

        Task Add(CustomerDTO customerDTO);
        Task Update(CustomerDTO customerDTO);
        Task Remove(int documento);
        
    }
}
