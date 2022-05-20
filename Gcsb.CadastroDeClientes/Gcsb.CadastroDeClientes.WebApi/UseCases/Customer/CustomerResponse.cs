using System;

namespace Gcsb.CadastroDeClientes.WebApi.UseCases.Customer
{
    public class CustomerResponse
    {

        public Guid Id { get; private set; }
        public String Nome { get; private set; }
        public String DataDeNascimento { get; private set; }
        public Int64 Documento { get; private set; }


        public String Endereco { get; private set; }
        public String DataDoCadastro { get; private set; }
        public Boolean ClienteAtivo { get; private set; }

        

        public CustomerResponse(Guid id, String nome, String dataDeNascimento, Int64 documento, String endereco, String dataDoCadastro, Boolean clienteAtivo)
        {
            Id = id;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Documento = documento;
            Endereco = endereco;
            DataDoCadastro = dataDoCadastro;
            ClienteAtivo = clienteAtivo;
        }
    }
}
