using System;

namespace Gcsb.CadastroDeClientes.Domain
{
    public class DomainException : Exception
    {
        public DomainException(String businessMessage) : base(businessMessage) { }
    }
}
