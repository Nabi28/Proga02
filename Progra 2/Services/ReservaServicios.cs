using Entities;
using Services.Interfaces;
using DTOs;
using DATA;

namespace Services
{
    public class ReservaServicios : IReserva
    {
        private readonly RestauranteDbContext _RestauranteDbcontext;

        public ReservaServicios(RestauranteDbContext Context)
        {
            _RestauranteDbcontext = Context;
        }

        public List<Reserva> GetAllReservas()
        {
            return _RestauranteDbcontext.Reservas.ToList();
        }

        public Reserva GetReservaById(int reservaId)
        {
            var result = _RestauranteDbcontext.Reservas.Find(reservaId);
            if (result == null)
                throw new Exception("Reserva no encontrada");

            return result;
        }

        public Reserva CreateReserva(CreateReservaDTOs dto)
        {
            var disponible = ValidarDisponibilidadMesa(dto.MesaId, dto.HorarioId, dto.Fecha);
            if (!disponible)
                throw new Exception("La mesa ya tiene una reserva activa en esa fecha y horario");

            var bloqueado = _RestauranteDbcontext.Bloqueos.Any(b =>
                (b.MesaId == dto.MesaId ||
                 _RestauranteDbcontext.Mesas.Any(m => m.Id == dto.MesaId && m.ZonaId == b.ZonaId))
                &&
                b.Estado == "Activo"
                &&
                dto.Fecha.Date >= b.FechaInicio.Date
                &&
                dto.Fecha.Date <= b.FechaFin.Date
            );

            if (bloqueado)
                throw new Exception("La mesa está bloqueada en la fecha seleccionada");

            var mesa = _RestauranteDbcontext.Mesas.Find(dto.MesaId);
            if (mesa == null)
                throw new Exception("La mesa no existe");

            if (dto.NumPersonas > mesa.Capacidad)
                throw new Exception($"La mesa solo tiene capacidad para {mesa.Capacidad} personas");

            var result = new Reserva
            {
                ClienteId = dto.ClienteId,
                MesaId = dto.MesaId,
                HorarioId = dto.HorarioId,
                NumPersonas = dto.NumPersonas,
                Fecha = dto.Fecha,
                Estado = "Activa"
            };

            mesa.Estado = "Ocupada";

            _RestauranteDbcontext.Reservas.Add(result);
            _RestauranteDbcontext.SaveChanges();

            return result;
        }

        public Reserva AtenderReserva(int reservaId)
        {
            var result = _RestauranteDbcontext.Reservas.Find(reservaId);
            if (result == null)
                throw new Exception("Reserva no encontrada");

            result.Estado = "Atendida";

            var mesa = _RestauranteDbcontext.Mesas.Find(result.MesaId);
            if (mesa != null)
                mesa.Estado = "Disponible";

            _RestauranteDbcontext.SaveChanges();

            return result;
        }

        public Reserva CancelarReserva(int reservaId)
        {
            var result = _RestauranteDbcontext.Reservas.Find(reservaId);
            if (result == null)
                throw new Exception("Reserva no encontrada");

            result.Estado = "Cancelada";

            var mesa = _RestauranteDbcontext.Mesas.Find(result.MesaId);
            if (mesa != null)
                mesa.Estado = "Disponible";

            _RestauranteDbcontext.SaveChanges();

            return result;
        }

        public bool ValidarDisponibilidadMesa(int mesaId, int horarioId, DateTime fecha)
        {
            var hayConflicto = _RestauranteDbcontext.Reservas.Any(reserva =>
                reserva.MesaId == mesaId
                &&
                reserva.Fecha.Date == fecha.Date
                &&
                reserva.HorarioId == horarioId
                &&
                reserva.Estado == "Activa"
            );

            return !hayConflicto;
        }
    }
}