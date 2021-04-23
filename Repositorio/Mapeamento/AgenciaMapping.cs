using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace Repositorio.Mapeamento
{
    public class AgenciaMapping : IEntityTypeConfiguration<Agencia>
    {
        public void Configure(EntityTypeBuilder<Agencia> builder)
        {
            builder.ToTable("Deposito");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasColumnName("IdAgencia")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.Numero)
                   .HasColumnName("Numero")
                   .HasColumnType("numeric")
                   .IsRequired();
        }
    }
}
