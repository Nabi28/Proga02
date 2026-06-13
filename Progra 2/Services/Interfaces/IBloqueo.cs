using DTOs;
using Entities;

namespace Services.Interfaces
{
    public interface IBloqueo
    {
        public List<Bloqueo> GetAllBloqueos();
        public Bloqueo GetBloqueoById(int id);
        public Bloqueo CreateBloqueoMesa(BloqueoMesaDTOs dto);
        public Bloqueo CreateBloqueoZona(BloqueoZonaDTOs dto);
        public bool VerificarBloqueo(int mesaId, DateTime fechaHora);
        public Bloqueo DeleteBloqueo(int id);

    }
}
