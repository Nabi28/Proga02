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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=restaurante.db");
        }
    }
}
