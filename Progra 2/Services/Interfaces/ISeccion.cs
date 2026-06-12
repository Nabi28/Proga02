using DTOs;
using Entities;

namespace Services.Interfaces
{
    public interface ISeccion
    {
        public List<Seccion> GetAllSecciones();
        public Seccion GetSeccionById(int SeccionId);
        public Seccion CreateSeccion(Seccion seccion);
    }
}
