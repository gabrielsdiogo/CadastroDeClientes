using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Application.UseCases.Customer.Save.Handlers
{
    public abstract class Handler<T>
    {
        protected Handler<T> sucessor;

        public void SetSucessor(Handler<T> sucessor)
        {
            this.sucessor = sucessor;
        }

        public abstract void ProcessRequest(T request);
    }
}
