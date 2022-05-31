using Xunit;
using Gcsb.CadastroDeClientes.Domain.Customer;
using System;

namespace Gcsb.CadastroDeClientes.Tests.Cases.Domain.Customer
{
    
    public class CustomerTest
    {
        

        [Theory(DisplayName = "Validação de instancia")]
        [InlineData("Gabriel", "16/09/2000", 45961919708, "Rua ten-cel", "23/05/2022", true)]
        public void EntityInstanceTest(String nome, String DataDeNascimento, long doc, String endereco, String DataDoCadastro, bool ClienteAtivo)
        {
            var customer = new Gcsb.CadastroDeClientes.Domain.Customer.Customer(Guid.NewGuid(), nome, DataDeNascimento, doc, endereco, DataDoCadastro, ClienteAtivo);
            Assert.True(customer.IsValid);
        }

        [Theory(DisplayName = "Validação Nome")]
        [InlineData("16/09/2000", 45961919708, "Rua ten-cel", "23/05/2022", true)]
        public void EntityNameFieldValidation(String DataDeNascimento, long doc, String endereco, String DataDoCadastro, bool ClienteAtivo)
        {
            var customer = new Gcsb.CadastroDeClientes.Domain.Customer.Customer(Guid.NewGuid(), new string('A', 3000), DataDeNascimento, doc, endereco, DataDoCadastro, ClienteAtivo);
            Assert.False(customer.IsValid);
        }

        [Theory(DisplayName = "Validação Documento")]
        [InlineData("Gabriel", "16/09/2000", "Rua ten-cel", "23/05/2022", true)]
        public void EntityDocumentFieldValidation(String nome, String DataDeNascimento, String endereco, String DataDoCadastro, bool ClienteAtivo)
        {
            var customer = new Gcsb.CadastroDeClientes.Domain.Customer.Customer(Guid.NewGuid(), nome, DataDeNascimento, 0, endereco, DataDoCadastro, ClienteAtivo);
            Assert.False(customer.IsValid);
        }

        [Theory(DisplayName = "Validação Endereco")]
        [InlineData("Gabriel", "16/09/2000", 45961919708, "23/05/2022", true)]
        public void EntityEnderecoFieldValidation(String nome, String DataDeNascimento, long doc, String DataDoCadastro, bool ClienteAtivo)
        {
            var customer = new Gcsb.CadastroDeClientes.Domain.Customer.Customer(Guid.NewGuid(), nome, DataDeNascimento, doc, new String('A', 3000), DataDoCadastro, ClienteAtivo);
            Assert.False(customer.IsValid);
        }

        [Theory(DisplayName = "Validação Data Nascimento")]
        [InlineData("Gabriel",  45961919708, "Rua ten-cel", "23/05/2022", true)]
        public void EntityDataNascFieldValidation(String nome,  long doc, String endereco, String DataDoCadastro, bool ClienteAtivo)
        {
            var customer = new Gcsb.CadastroDeClientes.Domain.Customer.Customer(Guid.NewGuid(), nome, new string('A', 3000), doc, endereco, DataDoCadastro, ClienteAtivo);
            Assert.False(customer.IsValid);
        }

        [Theory(DisplayName = "Validação Data Cadastro")]
        [InlineData("Gabriel", "16/09/2000", 45961919708, "Rua ten-cel", true)]
        public void EntityDataCadFieldValidation(String nome, String DataDeNascimento, long doc, String endereco, bool ClienteAtivo)
        {
            var customer = new Gcsb.CadastroDeClientes.Domain.Customer.Customer(Guid.NewGuid(), nome, DataDeNascimento, doc, endereco, new string('A', 3000), ClienteAtivo);
            Assert.False(customer.IsValid);
        }


    }
}
