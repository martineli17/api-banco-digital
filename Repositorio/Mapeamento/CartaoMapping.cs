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
                   .HasColumnType("numeric")
                   .IsRequired();
            builder.Property(x => x.Vencimento)
                   .HasColumnName("Vencimento")
                   .HasColumnType("date")
                   .IsRequired();
            builder.Property(x => x.Tipo)
                    .HasColumnName("Tipo")
                    .HasColumnType("varchar(15)")
                    .HasConversion(new EnumToStringConverter<EnumTipoCartao>());
           //To do 
        }
    }
}
