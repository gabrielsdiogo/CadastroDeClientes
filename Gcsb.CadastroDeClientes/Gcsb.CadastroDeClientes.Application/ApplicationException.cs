using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Application
{
    public class ApplicationException : Exception
    {
        internal ApplicationException(String businessMessage) : base(businessMessage) { }
    }
}
