using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.CadastroDeClientes.WebApi.UseCases.Customer.Add
{
    public class AddInputCustomer
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string DataDeNascimento { get;  set; }
        [Required]
        public Int64 Documento { get;  set; }

        [Required]
        public string Endereco { get;  set; }
        [Required]
        public string DataDoCadastro { get;  set; }
        [Required]
        public bool ClienteAtivo { get;  set; }
    }
}
