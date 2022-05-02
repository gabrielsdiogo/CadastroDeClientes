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
        public DateOnly DataDeNascimento { get; private set; }
        public int Documento { get; private set; }
        public String Endereco { get; private set; }
        public DateOnly DataDoCadastro { get; private set; }
        public Boolean ClienteAtivo { get; private set; }

        
        public Customer(string nome, DateOnly dataDeNascimento, int documento, string endereco, DateOnly dataDoCadastro, bool clienteAtivo)
        {
            ValidateDomain(nome, dataDeNascimento, documento, endereco, dataDoCadastro, clienteAtivo); 
        }


        public void Update(string nome, DateOnly dataDeNascimento, int documento, string endereco, DateOnly dataDoCadastro, bool clienteAtivo)
        {
            ValidateDomain(nome, dataDeNascimento, documento, endereco, dataDoCadastro, clienteAtivo);
        }

        private void  ValidateDomain(string nome, DateOnly dataDeNascimento, int documento, string endereco, DateOnly dataDoCadastro, bool clienteAtivo)
        {

            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome is invalid!");

            DomainExceptionValidation.When(documento < 0, "Documento is invalid!");

            DomainExceptionValidation.When(string.IsNullOrEmpty(endereco), "Endereço is invalid!");

          

            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Documento = documento;
            Endereco = endereco;
            DataDoCadastro = dataDoCadastro;
            ClienteAtivo = clienteAtivo;
        }
    }
}
