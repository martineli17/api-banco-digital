using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mapeamento
{
    public class CartaoMapping : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable("Cartao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasColumnName("IdCartao")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.Numero)
                   .HasColumnName("Numero")
                   .HasColumnType("numeric")
                   .IsRequired();
            builder.Property(x => x.Vencimento)
                   .HasColumnName("Vencimento")
                   .HasColumnType("date")
                   .IsRequired();
            builder.Property(x => x.Tipo)
                    .HasColumnName("Tipo")
                    .HasColumnType("nvarchar(10)")
                    .IsRequired();
            builder.HasOne(x => x.Cliente)
                    .WithOne(x => x.Cartao)
                    .HasForeignKey<Cartao>(x => x.IdCliente)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
