using DATA;
using DTOs;
using Entities;
using Services.Interfaces;

namespace Services
{
    public class ListaDeEsperaServicios : IListaDeEspera
    {
        private readonly RestauranteDbContext _RestauranteDbContext;
        public ListaDeEsperaServicios(RestauranteDbContext restauranteDbContext)
        {
            _RestauranteDbContext    = restauranteDbContext;
        }


        public ListaDeEspera CreateListaDeEspera(ListaDeEsperaDTOs dto)
        {
            var listaDeEspera = new ListaDeEspera
            {
                ClienteId = dto.ClienteId,
                HorarioId = dto.HorarioId,
                ZonaId = dto.ZonaId,
                Fecha = dto.Fecha,
                NumPersonas = dto.NumPersonas,
                Estado = "Pendiente"
            };

            _RestauranteDbContext.ListasDeEsperas.Add(listaDeEspera);
            _RestauranteDbContext.SaveChanges();
            return listaDeEspera;
        }

        public List<ListaDeEspera> GetAllListasDeEsperas()
        {
            return _RestauranteDbContext.ListasDeEsperas.ToList();
        }

        public ListaDeEspera GetListaDeEsperaById(int listaDeEsperaId)
        {
            var result = _RestauranteDbContext.ListasDeEsperas.Find(listaDeEsperaId);
            if (result == null)
                throw new Exception("Id no encontrado");
            return result;
        }


        public ListaDeEspera CancelarEspera(int listaDeEsperaId)
        {
            var result = _RestauranteDbContext.ListasDeEsperas.Find(listaDeEsperaId);
            if (result == null)
                throw new Exception("Id no encontrado");

            result.Estado = "Cancelada";
            _RestauranteDbContext.SaveChanges();
            return result;
        }

        public ListaDeEspera AtenderSiguienteEnLista(int horarioId, DateTime fecha, int zonaId)
        {
            var siguiente = _RestauranteDbContext.ListasDeEsperas
        .Where(lista => lista.HorarioId == horarioId
            && lista.ZonaId == zonaId
            && lista.Fecha.Date == fecha.Date
            && lista.Estado == "Pendiente")
        .OrderBy(lista => lista.Id)
        .FirstOrDefault();

            if (siguiente == null)
                throw new Exception("No hay entradas pendientes en la lista de espera con esos parámetros");

            siguiente.Estado = "Asignada";
            _RestauranteDbContext.SaveChanges();
            return siguiente;
        }
    }
}