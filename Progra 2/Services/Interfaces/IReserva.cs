using Entities;
using DTOs;

namespace Services.Interfaces
{
    public interface IReserva
    {
        //Reads
        public List<Reserva> GetAllReservas();
        public Reserva GetReservaById(int reservaId);
        //writes
        public Reserva CreateReserva(CreateReservaDTOs dto);
        public Reserva AtenderReserva(int reservaId);
        public Reserva CancelarReserva(int reservaId);
        public bool ValidarDisponibilidadMesa(int mesaId, int horarioId, DateTime fecha);
    }
}
