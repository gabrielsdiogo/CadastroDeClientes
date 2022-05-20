using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.CadastroDeClientes.Infrastructure.Database.Entities.Map.Customer
{
    public class CustomerMap : IEntityTypeConfiguration<Entities.Customer.Customer>
    {
        public void Configure(EntityTypeBuilder<Entities.Customer.Customer> builder)
        {
            builder.ToTable("Customer", "CustomerRefac");
            builder.HasKey(s => s.Id);
            builder.Property(d => d.Nome).IsRequired();


            builder.Property(d => d.Documento).IsRequired();
            builder.Property(d => d.DataDeNascimento).IsRequired();
            builder.Property(d => d.Endereco).IsRequired();
            builder.Property(d => d.DataDoCadastro).IsRequired();
            builder.Property(d => d.ClienteAtivo).IsRequired();


            builder.Property(d => d.Nome).HasMaxLength(300);
            builder.Property(d => d.Endereco).HasMaxLength(300);
            
        }
    }
}
