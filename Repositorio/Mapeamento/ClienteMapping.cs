using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Mapeamento
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.Nome)
                   .HasColumnName("Nome")
                   .HasColumnType("varchar(100)")
                   .IsRequired();
            builder.Property(x => x.Cpf)
                   .HasColumnName("Cpf")
                   .HasColumnType("varchar(11)")
                   .IsRequired();
            builder.Property(x => x.DataCriacao)
                   .HasColumnName("DataCriacao")
                   .HasColumnType("Datetime")
                   .IsRequired();
            builder.Property(x => x.Telefone)
                  .HasColumnName("Telefone")
                  .HasColumnType("varchar(11)")
                  .IsRequired();
            builder.HasOne(x => x.Conta)
                   .WithOne(x => x.Cliente)
                   .HasForeignKey<Conta>(x => x.IdCliente)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Cartao)
                   .WithOne(x => x.Cliente)
                   .HasForeignKey<Cartao>(x => x.IdCliente)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
