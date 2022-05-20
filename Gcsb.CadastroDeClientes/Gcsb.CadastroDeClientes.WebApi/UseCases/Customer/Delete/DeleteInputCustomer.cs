using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.Delete
{
    public class DeleteInputCustomer
    {
        [Required]
        public Guid CustomerId { get; set; }
    }
}
