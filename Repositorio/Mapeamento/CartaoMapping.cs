using Dominio.Entidades;
using Dominio.ValuesType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Repositorio.Mapeamento
{
    public class CartaoMapping : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable("Cartao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.Numero)
                   .HasColumnName("Numero")
                   .HasColumnType("varchar(20)")
                   .IsRequired();
            builder.Property(x => x.Vencimento)
                   .HasColumnName("Vencimento")
                   .HasColumnType("date")
                   .IsRequired();
            builder.Property(x => x.Ativo)
                   .HasColumnName("Ativo")
                   .HasColumnType("Bit");
            builder.Property(x => x.Tipo)
                    .HasColumnName("Tipo")
                    .HasColumnType("varchar(15)")
                    .HasConversion(new EnumToStringConverter<EnumTipoCartao>())
                    .IsRequired();
            builder.HasOne(x => x.Cliente)
                    .WithOne(x => x.Cartao)
                    .HasForeignKey<Cartao>(x => x.IdCliente)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
