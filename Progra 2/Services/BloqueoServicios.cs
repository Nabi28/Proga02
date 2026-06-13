using Entities;
using Services.Interfaces;
using DATA;
using DTOs;

namespace Services
{
    public class BloqueoServicios : Ibloqueo
    {
        private readonly RestauranteDbContext _RestauranteDbContext;

        public BloqueoServicios(RestauranteDbContext context)
        {
            _RestauranteDbContext = context;
        }

        public Bloqueo AddBloqueo(Bloqueo bloqueo)
        {
            _RestauranteDbContext.Bloqueos.Add(bloqueo);
            _RestauranteDbContext.SaveChanges();
            return bloqueo;
        }

        public Bloqueo CreateBloqueoMesa(BloqueoMesaDTOs dto)
        {
            throw new NotImplementedException();
        }

        public Bloqueo CreateBloqueoZona(BloqueoZonaDTOs dto)
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

