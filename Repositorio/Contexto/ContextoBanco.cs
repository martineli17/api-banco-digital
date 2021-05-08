using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Contexto
{
    public class ContextoBanco : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Agencia> Agencia { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<Transferencia> Transferencia { get; set; }
        public DbSet<Saque> Saque { get; set; }
        public DbSet<Deposito> Deposito { get; set; }
        public DbSet<Cartao> Cartao { get; set; }
        public ContextoBanco(DbContextOptions<ContextoBanco> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}