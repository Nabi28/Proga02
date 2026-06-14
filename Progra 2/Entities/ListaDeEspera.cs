namespace Entities
{
    public class ListaDeEspera
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int HorarioId { get; set; }
        public int ZonaId { get; set; }
        public DateTime Fecha { get; set; }
        public int NumPersonas { get; set; }
        public string Estado { get; set; }

        //relationships - propiedades de navegación
        public Zona Zona { get; set; }
        public ListaDeEspera ListaDeEsperas { get; set; }
        public Horario Horario { get; set; }
    }
}
