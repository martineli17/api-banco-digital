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
            builder.Property(x => x.IdContaDestino)
                   .HasColumnName("IdContaDestino")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.Valor)
                   .HasColumnName("Valor")
                   .HasColumnType("numeric")
                   .IsRequired();
            builder.Property(x => x.IdMovimentacao)
                 .HasColumnName("IdMovimentacao")
                 .HasColumnType("UNIQUEIDENTIFIER")
                 .IsRequired();
            builder.HasOne(x => x.Movimentacao)
                   .WithMany(x => x.Transferencias)
                   .HasForeignKey(x => x.IdMovimentacao)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ContaDestino)
                   .WithMany(x => x.TransferenciasRecebidas)
                   .HasForeignKey(x => x.IdContaDestino)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
