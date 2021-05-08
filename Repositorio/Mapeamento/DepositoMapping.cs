using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mapeamento
{
    public class DepositoMapping : IEntityTypeConfiguration<Deposito>
    {
        public void Configure(EntityTypeBuilder<Deposito> builder)
        {
            builder.ToTable("Deposito");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdConta)
                   .HasColumnName("IdConta")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.Credenciador)
                   .HasColumnName("Credenciador")
                   .HasColumnType("varchar(50)")
                   .IsRequired();
            builder.Property(x => x.NumeroBoleto)
                   .HasColumnName("NumeroBoleto")
                   .HasColumnType("varchar(100)")
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
                   .WithMany(x => x.Depositos)
                   .HasForeignKey(x => x.IdMovimentacao)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
