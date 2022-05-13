using Autofac;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Gcsb.CadastroDeClientes.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Gcsb.CadastroDeClientes.Infrastructure.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();

            Mapper(builder);
            DataAccess(builder);
        }

        private void DataAccess(ContainerBuilder builder)
        {
            var connection = Environment.GetEnvironmentVariable("DBCONN");

            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(t => (t.Namespace ?? string.Empty).Contains("Database"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            if (!string.IsNullOrEmpty(connection))
            {
                using Context context = new Context();
                context.Database.Migrate();
            }
        }

        private void Mapper(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(t => (t.Namespace ?? string.Empty).Contains("Database") && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                    cfg.AddProfile(profile);
                
                cfg.AddExpressionMapping();
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
