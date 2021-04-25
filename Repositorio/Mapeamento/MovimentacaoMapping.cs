using Dominio.Entidades;
using Dominio.ValuesType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Repositorio.Mapeamento
{
    public class MovimentacaoMapping : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.ToTable("Movimentacao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdConta)
                   .HasColumnName("IdConta")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.Evento)
                   .HasColumnName("Evento")
                   .HasColumnType("nvarchar(10)")
                   .HasConversion(new EnumToStringConverter<EnumEventoMovimentacao>())
                   .IsRequired();
            builder.Property(x => x.Tipo)
                   .HasColumnName("Tipo")
                   .HasColumnType("nvarchar(10)")
                   .HasConversion(new EnumToStringConverter<EnumTipoMovimentacao>())
                   .IsRequired();
            builder.Property(x => x.Valor)
                   .HasColumnName("Valor")
                   .HasColumnType("numeric")
                   .IsRequired();
            builder.HasOne(x => x.Conta)
                   .WithMany(x => x.Movimentacoes)
                   .HasForeignKey(x => x.IdConta)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Saques)
                   .WithOne(x => x.Movimentacao)
                   .HasForeignKey(x => x.IdMovimentacao)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Depositos)
                   .WithOne(x => x.Movimentacao)
                   .HasForeignKey(x => x.IdMovimentacao)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Transferencias)
                   .WithOne(x => x.Movimentacao)
                   .HasForeignKey(x => x.IdMovimentacao)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
