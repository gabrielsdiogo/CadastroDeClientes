using System;

namespace Gcsb.CadastroDeClientes.Infrastructure
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
