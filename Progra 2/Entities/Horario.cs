namespace Entities;

public class Horario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string DiaSemana { get; set; }
    public TimeOnly HoraInicio { get; set; }
    public TimeOnly HoraFin { get; set; }

    //relationships
    public ICollection<Reserva> Reservas { get; set; }
    public ICollection<ListaDeEspera> ListaDeEsperas { get; set; }
}
