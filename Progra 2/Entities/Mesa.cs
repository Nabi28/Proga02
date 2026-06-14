namespace Entities
{
    public class Mesa
    {
        public int Id { get; set; }
        public int NumMesa { get; set; }
        public int Capacidad { get; set; }
        public int ZonaId { get; set; }
        public string Estado { get; set; }

        //relationships

        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Bloqueo> Bloqueos { get; set; }

        //relationships - propiedades de navegación

        public Zona Zona { get; set; }

    }
}
