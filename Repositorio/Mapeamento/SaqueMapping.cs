using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mapeamento
{
    public class SaqueMapping : IEntityTypeConfiguration<Saque>
    {
        public void Configure(EntityTypeBuilder<Saque> builder)
        {
            builder.ToTable("Saque");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdConta)
                   .HasColumnName("IdConta")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.IdentificadorCaixaEletronico)
                   .HasColumnName("IdentificadorCaixaEletronico")
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();
            builder.Property(x => x.Valor)
                   .HasColumnName("Valor")
                   .HasColumnType("numeric")
                   .IsRequired();
            builder.HasOne(x => x.Movimentacao)
                   .WithMany(x => x.Saques)
                   .HasForeignKey(x => x.IdMovimentacao)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
