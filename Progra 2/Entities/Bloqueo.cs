namespace Entities
{
    public class Bloqueo
    {
        public int Id { get; set; }
        public int? ZonaId { get; set; }
        public int? MesaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string Motivo { get; set; } = string.Empty;

        //relationships
        public Zona Zona { get; set; }
    }
}
