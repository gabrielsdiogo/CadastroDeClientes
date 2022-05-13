using System;

namespace Gcsb.CadastroDeClientes.Infrastructure
{
    public class InfrastructureException : Exception
    {
        internal InfrastructureException(String businessMessage) : base(businessMessage) { }
    }
}
