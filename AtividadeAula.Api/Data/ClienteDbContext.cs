using AtividadeAula.Api.Models;
using System.Data.Entity;

namespace AtividadeAula.Api.Data
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext() : base("GamaApp")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        // Outras DbSet para outras entidades

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public"); // Define o esquema padrão como "public"
            base.OnModelCreating(modelBuilder);
        }
    }
}