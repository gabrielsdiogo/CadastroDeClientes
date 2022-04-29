using CadastroDeClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes.Infra.EntitiesConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(t => t.Documento);
            builder.Property(t => t.Nome).IsRequired();
            builder.Property(t => t.DataDeNascimento).IsRequired();
            builder.Property(t => t.Endereco).IsRequired();
            builder.Property(t => t.DataDoCadastro).IsRequired();
            builder.Property(t => t.ClienteAtivo).IsRequired();
        }
    }
}
