using Gcsb.CadastroDeClientes.Domain.Validator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Domain.Customer
{
    public class Customer : Entity
    {
        //- Nome Completo
        //- Data de Nascimento
        //- Documentos(RG/CPF)
        //- Endereço
        //- Data do cadastro
        //- Cliente ativo
        public String Nome { get; private set; }
        public String DataDeNascimento { get; private set; }
        public Int64 Documento { get; private set; }


        public String Endereco { get; private set; }
        public String DataDoCadastro { get; private set; }
        public Boolean ClienteAtivo { get; private set; }

        

        public Customer(Guid id,string nome, string dataDeNascimento, long documento, string endereco, string dataDoCadastro, bool clienteAtivo)
        {
            Id = id;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Documento = documento;
            Endereco = endereco;
            DataDoCadastro = dataDoCadastro;
            ClienteAtivo = clienteAtivo;

            Validate(this, new CustomerValidator());
        }
    }
}
