using DTOs;
using Entities;

namespace Services.Interfaces
{
    public interface Ibloqueo
    {
        public List<Bloqueo> GetAllBloqueos();
        public Bloqueo GetBloqueoById(int id);
        public Bloqueo CreateBloqueoMesa(BloqueoMesaDto dto);
        public Bloqueo CreateBloqueoZona(BloqueoZonaDto dto);
        public bool VerificarBloqueo(int mesaId, DateTime fechaHora);
        public Bloqueo DeleteBloqueo(int id);

    }
}
