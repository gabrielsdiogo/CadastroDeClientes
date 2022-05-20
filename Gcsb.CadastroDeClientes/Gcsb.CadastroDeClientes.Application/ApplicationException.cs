using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Application
{
    public class ApplicationException : Exception
    {
        public ApplicationException(String businessMessage) : base(businessMessage) { }
    }
}
