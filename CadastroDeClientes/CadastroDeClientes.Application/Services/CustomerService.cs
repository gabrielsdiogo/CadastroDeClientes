using AutoMapper;
using CadastroDeClientes.Application.DTOs;
using CadastroDeClientes.Application.Interfaces;
using CadastroDeClientes.Domain.Entities;
using CadastroDeClientes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomers()
        {
            var customerEntity = await _customerRepository.GetCustomers();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customerEntity);
        }

        public async Task<CustomerDTO> GetCustomerByDoc(int documento)
        {
            var customerEntity = await _customerRepository.GetCustomerByDoc(documento);
            return _mapper.Map<CustomerDTO>(customerEntity);
        }

        public async Task Add(CustomerDTO customerDTO)
        {
            var customerEntity = _mapper.Map<Customer>(customerDTO);
            await _customerRepository.Create(customerEntity);
        }

        public async Task Update(CustomerDTO customerDTO)
        {
            var customerEntity = _mapper.Map<Customer>(customerDTO);
            await _customerRepository.Update(customerEntity);
        }

        public async Task Remove(int documento)
        {
            var customerEntity = _customerRepository.GetCustomerByDoc(documento).Result;
            await _customerRepository.Remove(customerEntity);
        }
    }
}
