using Entities;
using Services.Interfaces;
using DATA;

namespace Services
{
    public class SeccionServicios : ISeccion
    {

        private readonly RestauranteDbContext _RestauranteDbcontext;
        public SeccionServicios(RestauranteDbContext restauranteDbContext)
        {
            _RestauranteDbcontext = restauranteDbContext;
        }


        public Seccion CreateSeccion(Seccion seccion)
        {
            _RestauranteDbcontext.Secciones.Add(seccion);
            _RestauranteDbcontext.SaveChanges();
            return seccion;
        }

        public List<Seccion> GetAllSecciones()
        {
            return _RestauranteDbcontext.Secciones.ToList();
        }

        public Seccion GetSeccionById(int seccionId)
        {
            var result = _RestauranteDbcontext.Secciones.Find(seccionId);
            if (result == null)
                throw new Exception("Seccion no encontrada");

            return result;
        }


    }
}
