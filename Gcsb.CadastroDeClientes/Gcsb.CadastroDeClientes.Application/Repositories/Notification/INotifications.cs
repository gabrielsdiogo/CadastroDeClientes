using FluentValidation.Results;
using System.Collections.Generic;
using Domain = Gcsb.CadastroDeClientes.Domain.Commons;

namespace Gcsb.CadastroDeClientes.Application.Repositories.Notification
{
    public interface INotifications
    {
        List<Domain::Notification> Notifications { get; set; }

        bool HasNotifications { get; }

        void AddNotification(string key, string message);

        void AddNotifications(ValidationResult validationResult);
    }
}
