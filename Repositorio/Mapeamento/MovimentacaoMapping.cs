using Dominio.Entidades;
using Dominio.ValuesType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
                   .HasConversion(v => v.ToString(),
                                  v => (EnumEventoMovimentacao)Enum.Parse(typeof(EnumEventoMovimentacao), v))
                   .IsRequired();
            builder.Property(x => x.Tipo)
                   .HasColumnName("Tipo")
                   .HasColumnType("nvarchar(10)")
                   .HasConversion(v => v.ToString(),
                                  v => (EnumTipoMovimentacao)Enum.Parse(typeof(EnumTipoMovimentacao), v))
                   .IsRequired();
            builder.Property(x => x.Valor)
                   .HasColumnName("Valor")
                   .HasColumnType("numeric")
                   .IsRequired();
            builder.HasOne(x => x.Conta)
                   .WithMany(x => x.Movimentacoes)
                   .HasForeignKey(x => x.IdConta)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
