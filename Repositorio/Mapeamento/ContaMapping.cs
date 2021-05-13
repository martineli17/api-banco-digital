using Dominio.Entidades;
using Dominio.ValuesType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Repositorio.Mapeamento
{
    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Conta");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.Numero)
                   .HasColumnName("Numero")
                   .HasColumnType("varchar(20)")
                   .IsRequired();
            builder.Property(x => x.DataCriacao)
                   .HasColumnName("DataCriacao")
                   .HasColumnType("Datetime")
                   .IsRequired();
            builder.Property(x => x.IdCliente)
                   .HasColumnName("IdCliente")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.Saldo)
                  .HasColumnName("Saldo")
                  .HasColumnType("numeric(19,2)")
                  .IsRequired();
            builder.Property(x => x.Tipo)
                  .HasColumnName("Tipo")
                  .HasColumnType("varchar(15)")
                  .HasConversion(new EnumToStringConverter<EnumTipoConta>())
                  .IsRequired();
            builder.HasMany(x => x.TransferenciasRecebidas)
                   .WithOne(x => x.ContaDestino)
                   .HasForeignKey(x => x.IdContaDestino)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Movimentacoes)
                   .WithOne(x => x.Conta)
                   .HasForeignKey(x => x.IdConta)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Cliente)
                   .WithOne(x => x.Conta)
                   .HasForeignKey<Conta>(x => x.IdCliente)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
