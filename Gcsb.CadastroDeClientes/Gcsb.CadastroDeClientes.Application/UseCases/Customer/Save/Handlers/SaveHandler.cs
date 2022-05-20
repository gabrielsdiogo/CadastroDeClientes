using Gcsb.CadastroDeClientes.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Application.UseCases.Customer.Save.Handlers
{
    public class SaveHandler : Handler<CustomerSaveRequest>
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public SaveHandler(ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
        }

        public override void ProcessRequest(CustomerSaveRequest request)
        {
            var ret = customerWriteOnlyRepository.Save(request.Customer);
            if (ret == 0)
                throw new ArgumentException("Problem to save model");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
