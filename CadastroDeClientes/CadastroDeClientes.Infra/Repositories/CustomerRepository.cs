using CadastroDeClientes.Domain.Entities;
using CadastroDeClientes.Domain.Interfaces;
using CadastroDeClientes.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        ApplicationDbContext _customerContext;

        public CustomerRepository(ApplicationDbContext context)
        {
            _customerContext = context;
        }


        public async Task<Customer> Create(Customer customer)
        {
            _customerContext.Add(customer);
            await _customerContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> GetCustomerByDoc(int documento)
        {
            return await _customerContext.Customers.FindAsync(documento);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerContext.Customers.ToListAsync();
        }

        public async Task<Customer> Remove(Customer customer)
        {
            _customerContext.Remove(customer);
            await _customerContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            _customerContext.Update(customer);
            await _customerContext.SaveChangesAsync();
            return customer;
        }
    }
}
