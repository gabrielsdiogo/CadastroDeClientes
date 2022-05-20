﻿using Gcsb.CadastroDeClientes.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Gcsb.CadastroDeClientes.Application.Repositories
{
    public interface ICustomerReadOnlyRepository
    {
        Customer GetById(Guid id);

        IList<Customer> GetByFilter(Expression<Func<Customer, bool>> filter);

        IList<Customer> GetAll();
    }
}