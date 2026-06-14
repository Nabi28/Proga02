namespace Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        //relationships
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<ListaDeEspera> ListasDeEsperas { get; set; }
    }
}
