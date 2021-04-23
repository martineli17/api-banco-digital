using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mapeamento
{
    public class TransferenciaMapping : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.ToTable("Transferencia");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdConta).HasColumnName("IdConta")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.IdContaOrigem)
                   .HasColumnName("IdContaOrigem")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.DataAgendamento)
                   .HasColumnName("DataAgendamento")
                   .HasColumnType("DateTime");
            builder.Property(x => x.Valor)
                   .HasColumnName("Valor")
                   .HasColumnType("numeric")
                   .IsRequired();
            builder.HasOne(x => x.Movimentacao)
                   .WithMany(x => x.Transferencias)
                   .HasForeignKey(x => x.IdMovimentacao)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.ContaOrigem)
                   .WithMany(x => x.TransferenciasOrigem)
                   .HasForeignKey(x => x.IdContaOrigem)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
