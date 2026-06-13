namespace Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int MesaId { get; set; }
        public int HorarioId { get; set; }
        public int NumPersonas { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

    }
}
