using CadastroDeClientes.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes.Domain.Entities
{
    /*
    - Nome Completo
    - Data de Nascimento
    - Documentos(RG/CPF)
    - Endereço
    - Data do cadastro
    - Cliente ativo
    */
    public sealed class Customer
    {
        public String Nome { get; private set; }
        public String DataDeNascimento { get; private set; }
        public Int64 Documento { get; private set; }


        public String Endereco { get; private set; }
        public String DataDoCadastro { get; private set; }
        public Boolean ClienteAtivo { get; private set; }

       
        public Customer(string nome, String dataDeNascimento, Int64 documento, string endereco, bool clienteAtivo)
        {
            
            ValidateDomain(nome, dataDeNascimento, documento, endereco, clienteAtivo); 
        }


        public void Update(string nome, String dataDeNascimento, Int64 documento, string endereco,  bool clienteAtivo)
        {
            ValidateDomain(nome, dataDeNascimento, documento, endereco,  clienteAtivo);
        }

        private void  ValidateDomain(string nome, String dataDeNascimento, Int64 documento, string endereco, bool clienteAtivo)
        {

            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome is invalid!");

            DomainExceptionValidation.When(documento < 0, "Documento is invalid!");

            DomainExceptionValidation.When(string.IsNullOrEmpty(endereco), "Endereço is invalid!");

          

            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Documento = documento;
            Endereco = endereco;
            DataDoCadastro = DateTime.UtcNow.ToString("dd/MM/yyyy");
            ClienteAtivo = clienteAtivo ? true : false;
        }
    }
}
