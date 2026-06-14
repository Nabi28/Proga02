using Microsoft.EntityFrameworkCore;
using Entities;
namespace DATA
{
    public class RestauranteDbContext : DbContext 
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Bloqueo> Bloqueos { get; set; }
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<ListaDeEspera> ListasDeEsperas { get; set; }
        public DbSet<Horario> Horarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Capa8;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Deshabilitar cascade delete en todas las relaciones
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }

}
