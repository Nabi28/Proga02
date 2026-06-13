using DATA;
using Entities;
using Services.Interfaces;

namespace Services
{
    public class MesaServicios : IMesa
    {
        private readonly RestauranteDbContext _RestauranteDbcontext;
        public MesaServicios(RestauranteDbContext Context)
        {
            _RestauranteDbcontext = Context;
        }
        public Mesa CreateMesa(Mesa mesa)
        {
            _RestauranteDbcontext.Mesas.Add(mesa);
            _RestauranteDbcontext.SaveChanges();
            return mesa;
        }

        public void DeleteMesa(int mesaId)
        {
            var result = _RestauranteDbcontext.Mesas.Find(mesaId);
            if (result == null)
                throw new Exception("Mesa no encontrada");

            _RestauranteDbcontext.Mesas.Remove(result);
            _RestauranteDbcontext.SaveChanges();
        }

        public List<Mesa> GetAllMesas()
        {
            return _RestauranteDbcontext.Mesas.ToList();
        }

        public Mesa GetMesaById(int mesaId)
        {
            var result = _RestauranteDbcontext.Mesas.Find(mesaId);
            if (result == null)
                throw new Exception("Mesa no encontrada");
            return result;
        }

        public Mesa UpdateMesa(int mesaId, Mesa mesa)
        {
            var result = _RestauranteDbcontext.Mesas.Find(mesaId);
            if (result == null)
                throw new Exception("Mesa no encontrada");

            result.NumMesa = mesa.NumMesa;
            result.Capacidad = mesa.Capacidad;
            result.ZonaId = mesa.ZonaId;
            result.Estado = mesa.Estado;

            _RestauranteDbcontext.SaveChanges();
            return result;
        }
        public Mesa CambiarEstadoMesa(int mesaId, string estado)
        {
            var mesa = _RestauranteDbcontext.Mesas.Find(mesaId);
            if (mesa == null)
                throw new Exception("Mesa no encontrada");

            mesa.Estado = estado;
            _RestauranteDbcontext.SaveChanges();
            return mesa;
        }
    }
}
