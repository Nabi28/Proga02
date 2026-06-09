using Entities;
using Services.Interfaces;
using DATA;
using DTOs;

namespace Services
{
    public class BloqueoServicios : Ibloqueo
    {
        private readonly RestauranteDbContext _RestauranteContext;

        public BloqueoServicios(RestauranteDbContext context)
        {
            _RestauranteContext = context;
        }

        public Bloqueo AddBloqueo(Bloqueo bloqueo)
        {
            _RestauranteContext.Bloqueos.Add(bloqueo);
            _RestauranteContext.SaveChanges();
            return bloqueo;
        }

        public Bloqueo CreateBloqueoMesa(BloqueoMesaDto dto)
        {
            throw new NotImplementedException();
        }

        public Bloqueo CreateBloqueoZona(BloqueoZonaDto dto)
        {
            throw new NotImplementedException();
        }

        public bool VerificarBloqueo(int mesaId, DateTime fechaHora)
        {
            throw new NotImplementedException();
        }

        public Bloqueo DeleteBloqueo(int id)
        {
            throw new NotImplementedException();
        }

        public List<Bloqueo> GetAllBloqueos()
        {
            throw new NotImplementedException();
        }

        public Bloqueo GetBloqueoById(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente UpdateCliente(int clienteId, Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}

