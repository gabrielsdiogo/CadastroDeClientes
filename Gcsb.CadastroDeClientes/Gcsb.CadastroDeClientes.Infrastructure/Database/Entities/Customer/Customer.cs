using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Infrastructure.Database.Entities.Customer
{
    public class Customer
    {
        public Guid Id { get; set; }
        public String Nome { get;  set; }
        public String DataDeNascimento { get;  set; }
        public Int64 Documento { get;  set; }


        public String Endereco { get;  set; }
        public String DataDoCadastro { get;  set; }
        public Boolean ClienteAtivo { get;  set; }
    }
}
