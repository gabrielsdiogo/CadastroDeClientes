using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes.Application.DTOs
{
    public class CustomerDTO
    {
        [Required(ErrorMessage = "The Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public String Nome { get;  set; }

        [Required(ErrorMessage = "The Date is required")]
        public DateOnly DataDeNascimento { get;  set; }

        [Required(ErrorMessage = "Document is required")]
        public int Documento { get;  set; }

        [Required(ErrorMessage = "The Endereco is required")]
        public String Endereco { get;  set; }

    }
}
