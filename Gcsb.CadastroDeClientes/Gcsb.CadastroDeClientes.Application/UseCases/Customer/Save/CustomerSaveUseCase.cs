﻿using Gcsb.CadastroDeClientes.Application.Boundaries.Customer;
using Gcsb.CadastroDeClientes.Application.UseCases.Customer.Save.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Application.UseCases.Customer.Save
{
    public class CustomerSaveUseCase : ICustomerSaveUseCase
    {
        private readonly IOutputPort output;
        private readonly ValidateHandler validateHandler;

        public CustomerSaveUseCase(IOutputPort output, ValidateHandler validateHandler, SaveHandler saveHandler)
        {
            this.output = output;
            this.validateHandler = validateHandler;
            this.validateHandler.SetSucessor(saveHandler);
        }
        public void Execute(CustomerSaveRequest request)
        {
            try
            {
                validateHandler.ProcessRequest(request);
                output.Standard(request.Customer.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
