using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Application.UseCases.Customer.Save
{
    public class CustomerSaveRequest
    {
        public Domain.Customer.Customer Customer { get; private set; }

        public CustomerSaveRequest(string nome, string dataDeNascimento, string dataDoCadastro, long documento, string endereco, bool clienteAtivo)
        {
            Customer = new Domain.Customer.Customer(Guid.NewGuid(), nome, dataDeNascimento, documento, endereco, dataDoCadastro, clienteAtivo);
        }

        public CustomerSaveRequest(Guid id, string nome, string dataDeNascimento, string dataDoCadastro, long documento, string endereco, bool clienteAtivo)
        {
            Customer = new Domain.Customer.Customer(id, nome, dataDeNascimento, documento, endereco, dataDoCadastro, clienteAtivo);
        }
    }
}
