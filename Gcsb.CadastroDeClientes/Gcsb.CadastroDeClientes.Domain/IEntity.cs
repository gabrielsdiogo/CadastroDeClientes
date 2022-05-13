using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
