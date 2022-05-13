using System;

namespace Gcsb.CadastroDeClientes.Domain
{
    public class DomainException : Exception
    {
        internal DomainException(String businessMessage) : base(businessMessage) { }
    }
}
