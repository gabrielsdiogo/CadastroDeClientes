using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.Get
{
    public class GetInputCustomer
    {
        [Required]
        public Guid CustomerId { get; set; }
    }
}
