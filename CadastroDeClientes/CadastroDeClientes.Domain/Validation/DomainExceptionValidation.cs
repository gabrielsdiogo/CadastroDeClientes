using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(String error) : base(error)
        {}

        public static void When(bool HasError, String error)
        {
            if (HasError)
                throw new DomainExceptionValidation(error);
        }

    }
}
