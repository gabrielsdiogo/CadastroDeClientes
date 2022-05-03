using AutoMapper;
using CadastroDeClientes.Application.DTOs;
using CadastroDeClientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
