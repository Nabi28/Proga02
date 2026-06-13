using Entities;
using Services.Interfaces;
using DATA;
using DTOs;

namespace Services
{
    public class BloqueoServicios : IBloqueo
    {
        private readonly RestauranteDbContext _RestauranteDbcontext;

        public BloqueoServicios(RestauranteDbContext restauranteDbContext)
        {
            _RestauranteDbcontext = restauranteDbContext;
        }



        public List<Bloqueo> GetAllBloqueos()
        {
            return _RestauranteDbcontext.Bloqueos.ToList();
        }

        public Bloqueo GetBloqueoById(int bloqueoId)
        {
            var result = _RestauranteDbcontext.Bloqueos.Find(bloqueoId);
            if (result == null)
                throw new Exception("Bloqueo no encontrado");
            return result;
        }



        public Bloqueo CreateBloqueoMesa(BloqueoMesaDTOs dto)
        {
            var mesa = _RestauranteDbcontext.Mesas.Find(dto.MesaId);
            if (mesa == null)
                throw new Exception("Mesa no encontrada");

            mesa.Estado = "En Mantenimiento";

            var bloqueo = new Bloqueo
            {
                MesaId = dto.MesaId,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Motivo = dto.Motivo,
                Estado = "Activo"
            };

            _RestauranteDbcontext.Bloqueos.Add(bloqueo);
            _RestauranteDbcontext.SaveChanges();
            return bloqueo;
        }

        public Bloqueo CreateBloqueoZona(BloqueoZonaDTOs dto)
        {
            var zonaExiste = _RestauranteDbcontext.Zonas.Any(z => z.Id == dto.ZonaId);
            if (!zonaExiste)
                throw new Exception("La zona no existe");

            var mesas = _RestauranteDbcontext.Mesas
                .Where(mesa => mesa.ZonaId == dto.ZonaId)
                .ToList();

            foreach (var mesa in mesas)
            {
                mesa.Estado = "En Mantenimiento";
            }

            var bloqueo = new Bloqueo
            {
                ZonaId = dto.ZonaId,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Motivo = dto.Motivo,
                Estado = "Activo"
            };

            _RestauranteDbcontext.Bloqueos.Add(bloqueo);
            _RestauranteDbcontext.SaveChanges();
            return bloqueo;
        }

        public Bloqueo DeleteBloqueo(int bloqueoId)
        {
            var bloqueo = _RestauranteDbcontext.Bloqueos.Find(bloqueoId);
            if (bloqueo == null)
                throw new Exception("Bloqueo no encontrado");

            if (bloqueo.MesaId != null)
            {
                var mesa = _RestauranteDbcontext.Mesas.Find(bloqueo.MesaId);
                if (mesa != null) mesa.Estado = "Disponible";
            }
            else if (bloqueo.ZonaId != null)
            {
                var mesas = _RestauranteDbcontext.Mesas
                    .Where(mesa => mesa.ZonaId == bloqueo.ZonaId)
                    .ToList();

                foreach (var mesa in mesas)
                {
                    mesa.Estado = "Disponible";
                }
            }

            _RestauranteDbcontext.Bloqueos.Remove(bloqueo);
            _RestauranteDbcontext.SaveChanges();
            return bloqueo;
        }

        public bool VerificarBloqueo(int mesaId, DateTime fechaHora)
        {
            return _RestauranteDbcontext.Bloqueos.Any(bloqueo =>
                bloqueo.MesaId == mesaId &&
                fechaHora >= bloqueo.FechaInicio &&
                fechaHora <= bloqueo.FechaFin &&
                bloqueo.Estado == "Activo");
        }
    }
}

