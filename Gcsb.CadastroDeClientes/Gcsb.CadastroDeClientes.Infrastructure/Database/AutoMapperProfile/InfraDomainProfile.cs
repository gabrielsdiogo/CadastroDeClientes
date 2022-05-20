using AutoMapper;
using Gcsb.CadastroDeClientes.Domain.Customer;

namespace Gcsb.CadastroDeClientes.Infrastructure.Database.AutoMapperProfile
{
    public class InfraDomainProfile : Profile
    {
        public InfraDomainProfile()
        {
            CreateMap<Customer, Entities.Customer.Customer>().ReverseMap();
        }
        
    }
}
